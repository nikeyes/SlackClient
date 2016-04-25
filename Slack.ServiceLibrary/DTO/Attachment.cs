using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slack.ServiceLibrary.DTO
{
    /// <summary>
    /// It is possible to create more richly-formatted messages using Attachments.
    /// https://api.slack.com/docs/attachments
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Required text summary of the attachment that is shown by clients that understand attachments but choose not to show them.
        /// </summary>
        [JsonProperty("fallback")]
        public string Fallback { get; set; }

        /// <summary>
        /// Optional text that should appear above the formatted data.
        /// </summary>
        [JsonProperty("pretext")]
        public string PreText { get; set; }

        /// <summary>
        /// Optional text that should appear within the attachment.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Can either be one of 'good', 'warning', 'danger', or any hex color code.
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// Fields are displayed in a table on the message.
        /// </summary>
        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }
        [JsonProperty("mrkdwn_in")]
        public List<string> MarkdownIn { get; private set; }

        public Attachment(string fallback)
        {
            Fallback = fallback;
            MarkdownIn = new List<string> { "fields" };
        }
    }
}
