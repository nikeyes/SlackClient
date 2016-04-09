using Newtonsoft.Json;

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

        public Payload()
        {
            _iconUrl = null;
            _iconEmoji = ":bug:";
            Channel = "#general";
            Username ="Slack.ServiceLibrary";
            Text = "Default Text from Slack.ServiceLibrary";
        }

    }
}
