using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.ServiceLibrary.DTO
{
    public class Payload
    {
        private string _iconUrl;

        [JsonProperty("icon_url")]
        public string IconUrl
        {
            get
            {
                return _iconUrl;
            }
            set
            {
                _iconEmoji = null;
                _iconUrl = value;
            }
        }

        private string _iconEmoji;

        [JsonProperty("icon_emoji")]
        public string IconEmoji
        {
            get
            {
                return _iconEmoji;
            }
            set
            {
                _iconUrl = null;
                _iconEmoji = value;
            }
        }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("attachments")]
        public List<Attachment> Attachments {get; set;}

        public Payload()
        {
            //Configure default configuration in Incoming WebHooks configuration.
            _iconUrl = null;
            _iconEmoji = null;
            Channel = null;
            Attachments = new List<Attachment>();
            Username ="Slack.ServiceLibrary";
            Text = "Default Text from Slack.ServiceLibrary";
        }

    }
}
