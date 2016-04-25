using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slack.ServiceLibrary.DTO
{
    /// <summary>
    /// Fields are displayed in a table on the message.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// The title may not contain markup and will be escaped for you; required.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// Text value of the field. May contain standard message markup and must be escaped as normal; may be multi-line.
        /// https://get.slack.help/hc/en-us/articles/202288908-Formatting-your-messages
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
        /// <summary>
        /// Optional flag indicating whether the <paramref name="Value"/> is short enough to be displayed side-by-side with other values.
        /// </summary>
        [JsonProperty("short")]
        public bool Short { get; set; }

        public Field(string title)
        {
            Title = title;
        }
    }
}
