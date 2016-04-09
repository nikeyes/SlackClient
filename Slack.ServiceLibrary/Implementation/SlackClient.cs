using Newtonsoft.Json;
using Slack.ServiceLibrary.Contracts;
using Slack.ServiceLibrary.DTO;
using Slack.ServiceLibrary.Exceptions;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace Slack.ServiceLibrary.Implementation
{ 
    public class SlackClient : ISlackClient
    {
        private readonly Uri _uri;
        private readonly Encoding _encoding = new UTF8Encoding();

        public SlackClient(string urlWithAccessToken)
        {
            _uri = new Uri(urlWithAccessToken);
        }

        public ResponseSlackClientEnum SendMessage(Payload payload)
        {
            ResponseSlackClientEnum result = ResponseSlackClientEnum.ko;

            string payloadJson = JsonConvert.SerializeObject(payload,
                                                                Formatting.None,
                                                                new JsonSerializerSettings
                                                                {
                                                                    NullValueHandling = NullValueHandling.Ignore
                                                                });

            using (WebClient client = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();
                data["payload"] = payloadJson;

                try{
                    var response = client.UploadValues(_uri, "POST", data);

                    //The response text is usually "ok"
                    string responseText = _encoding.GetString(response);
                    result = (ResponseSlackClientEnum)Enum.Parse(typeof(ResponseSlackClientEnum), responseText, true);
                }
                catch(System.Net.WebException ex)
                {
                    ///TODO: Add your favorite log system
                    throw new IncomingWebHookDisabledException("The Slack Incoming WebHooks may be disabled or Slack Url is incorrect.Check it and try again", ex);
                }
                catch
                {
                    ///TODO: Add your favorite log system
                    throw;
                }
            }

            return result;
        }
    }


}