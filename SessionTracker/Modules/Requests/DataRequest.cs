using Newtonsoft.Json.Linq;
using SessionTracker.Modules.Data.Models;
using SessionTracker.Modules.Messaging;
using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace SessionTracker.Modules.Requests
{
    public struct DataRequestPayload
    {
        public readonly string Cookie;
        public readonly Campus Campus;

        public DataRequestPayload(string cookie, Campus campus)
        {
            this.Cookie = cookie;
            this.Campus = campus;
        }
    }

    //TODO: Refactor
    class DataRequest : IRequestHandler<BindingList<SignInData>, DataRequestPayload>
    {
        private static readonly string JsonDataKey = "aaData";

        private IMessageHandler messageHandler;

        private enum JsonDataIndex
        {
            Center = 0,
            Campus = 1,
            StudentID = 2,
            StudentName = 3,
            Course = 4,
            Instructor = 5,
            SignInTime = 6,
            Duration = 7,
            Referal = 8

        }

        public DataRequest(IMessageHandler messageHandler)
        {
            this.messageHandler = messageHandler;
        }

        //TODO: Refactor
        public BindingList<SignInData> MakeRequest(string url, DataRequestPayload data)
        {
            BindingList<SignInData> logData = new BindingList<SignInData>();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.Headers[HttpRequestHeader.Cookie] = data.Cookie;
                request.Method = WebRequestMethods.Http.Get;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (var responseStream = response.GetResponseStream())
                        using (var streamReader = new System.IO.StreamReader(responseStream))
                        {
                            string jsonString = streamReader.ReadToEnd();
                            JObject json = JObject.Parse(jsonString);

                            foreach (var element in json[JsonDataKey])
                            {
                                SignInData row = this.BuildDataRow(element, data.Campus);
                                
                                if (!(row is null))
                                {
                                    logData.Add(row);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.messageHandler.ShowDialog("Request Error", ex.Message, MessageBoxIcon.Error);
            }

            return logData;
        }

        private SignInData BuildDataRow(JToken element, Campus campus)
        {
            const string WORK_INDEPENDENT = "Wrk-Independent";

            string currentCampusName = element[(int)JsonDataIndex.Campus].ToString();

            if (!string.IsNullOrEmpty(currentCampusName))
            {

                if (currentCampusName == campus.Name)
                {
                    Tuple<string, string> name = this.ParseName(element[(int)JsonDataIndex.StudentName].ToString());
                    string course = element[(int)JsonDataIndex.Course].ToString() == WORK_INDEPENDENT ?
                        WORK_INDEPENDENT : element[(int)JsonDataIndex.Course].ToString().Substring(0, 7);

                    return new SignInData(
                        element[(int)JsonDataIndex.Center].ToString(),
                        element[(int)JsonDataIndex.Campus].ToString(),
                        this.ExtractStudentID(element[(int)JsonDataIndex.StudentID].ToString()),
                        name.Item2,
                        name.Item1,
                        course
                    );
                }
            }

            return null;
        }

        //TODO: prepare for the possibility that there are not two parts to the name
        private Tuple<string, string> ParseName(string name)
        {
            string[] parts = name.Split(',');
            return new System.Tuple<string, string>(parts[0], parts[1]);
        }

        private string ExtractStudentID(string value)
        {
            return System.Text.RegularExpressions.Regex.Match(value, @"\d+").Value;
        }
    }
}
