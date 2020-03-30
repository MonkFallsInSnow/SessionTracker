using SessionTracker.Modules.Messaging;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Windows.Forms;

namespace SessionTracker.Modules.Requests
{
    public class LoginRequest : IRequestHandler<string, NameValueCollection>
    {
        public static readonly string LoginURL = @"https://ilctimetrk.waketech.edu/login";

        private readonly IMessageHandler messageHandler;

        public LoginRequest(IMessageHandler messageHandler)
        {
            this.messageHandler = messageHandler;
        }

        public string MakeRequest(string url, NameValueCollection data)
        {
            if (data != null)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(LoginURL);

                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = WebRequestMethods.Http.Post;
                    request.AllowAutoRedirect = false;

                    byte[] postData = System.Text.Encoding.UTF8.GetBytes(data.ToString());
                    request.ContentLength = postData.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(postData, 0, postData.Length);
                    }

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.Found)
                        {
                            return response.Headers[HttpResponseHeader.SetCookie];
                        }
                        else
                        {
                            this.messageHandler.ShowDialog("Login Error", "User not found!", MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.messageHandler.ShowDialog("Login Error", ex.Message, MessageBoxIcon.Error);
                }
            }

            return string.Empty;
        }
    }
}
