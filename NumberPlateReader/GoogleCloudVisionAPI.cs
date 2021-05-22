using System;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Vision.v1;
using Google.Apis.Vision.v1.Data;
using Google.Apis.Services;

namespace NumberPlateReader
{
    /// <summary>
    /// Google Cloud Vision APIを管理するクラスです。
    /// </summary>
    class GoogleCloudVisionAPI
    {
        /// <summary>
        /// 認証用Jsonファイルのフルパスを設定もしくは取得します。
        /// </summary>
        public string CredentialFile { get; set; }

        /// <summary>
        /// パラメータに指定された画像からテキストを取得します。
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public int GetFullText(byte[] buf, ref string s)
        {
            //参照渡しされた値を初期化します。
            s = "";

            //このクラスをインスタンス化します。
            GoogleCloudVisionAPI gcv = new GoogleCloudVisionAPI();

            //証明用Jsonファイルを指定します。
            gcv.CredentialFile = CredentialFile;

            //認証させ、APIを利用できる状態にします。
            VisionService vs = gcv.CreateAuthorizedClient();

            //画像を読み取り、テキストを取得します。
            int iRet = gcv.DetectTextWord(vs, buf, ref s);

            //DetectTextWordメソッドの実行結果を戻り値として返します。
            return iRet;
        }

        /// <summary>
        /// Google Cloud Vision APIの利用のための認証を試みます。
        /// </summary>
        /// <returns>認証結果を返します。</returns>
        private VisionService CreateAuthorizedClient()
        {
            //認証します。
            GoogleCredential credential = CreateCredential();

            //
            if (credential.IsCreateScopedRequired)
            {
                credential = credential.CreateScoped
                (
                    new []
                    {
                        VisionService.Scope.CloudPlatform
                    }
                );
            }

            //
            return new VisionService
            (
                new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    GZipEnabled = false
                }
            );
        }

        /// <summary>
        /// 指定のjsonファイルを使用して認証を試みます。
        /// </summary>
        /// <returns>認証結果</returns>
        private GoogleCredential CreateCredential()
        {
            //
            using (var stream = new FileStream(CredentialFile, FileMode.Open, FileAccess.Read))
            {
                string[] scopes = { VisionService.Scope.CloudPlatform };

                var credential = GoogleCredential.FromStream(stream);
                credential = credential.CreateScoped(scopes);

                return credential;
            }
        }

        /// <summary>
        /// 画像からテキストを抽出します。
        /// </summary>
        /// <param name="vision">Google Cloud Vision APIのサービス</param>
        /// <param name="buf">画像</param>
        /// <param name="s">抽出したテキスト</param>
        /// <returns>APIの実行結果を返します。</returns>
        private int DetectTextWord(VisionService vision, byte[] buf, ref string s)
        {
            //戻り値となる変数を定義します。
            int result = 1;

            //APIに引き渡す画像イメージを文字列化します。
            string imageContent = Convert.ToBase64String(buf);

            //
            try
            {
                //レスポンスを生成します。
                var responses = vision.Images.Annotate
                (
                    new BatchAnnotateImagesRequest()
                    {
                        Requests = new[]
                        {
                            new AnnotateImageRequest()
                            {
                                Features = new []
                                {
                                    new Feature() { Type = "TEXT_DETECTION" }
                                },
                                Image = new Image() { Content = imageContent }
                            }
                        }
                    }
                ).Execute();

                //リクエストを取得します。
                if (responses.Responses != null)
                {
                    s = responses.Responses[0].TextAnnotations[0].Description;
                    result = 0;
                }
                else
                {
                    s = "";
                    result = -1;
                }
            }
            catch
            {
                s = "";
                result = -1;
            }

            //APIの結果を返します。
            return result;
        }
    }
}
