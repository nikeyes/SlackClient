﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slack.ServiceLibrary.Contracts;
using Slack.ServiceLibrary.DTO;
using Slack.ServiceLibrary.Implementation;
using System.Collections.Generic;

namespace Slack.ServiceLibrary.UnitTests
{
    [TestClass]
    public class SlackClientTests
    {
        private readonly string _slackUrlWithAccessToken = "https://hooks.slack.com/services/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";

        [TestMethod]
        public void SendMessage_With_Default_Payload()
        {
            //ARRANGE
            SlackClient sut = new SlackClient(_slackUrlWithAccessToken);
            ResponseSlackClientEnum expected = ResponseSlackClientEnum.ok;
            ResponseSlackClientEnum actual;

            Payload payload = new Payload();
            
            //ACT
            actual = sut.SendMessage(payload);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SendMessage_With_Simple_Payload()
        {
            //ARRANGE
            SlackClient sut = new SlackClient(_slackUrlWithAccessToken);
            ResponseSlackClientEnum expected = ResponseSlackClientEnum.ok;
            ResponseSlackClientEnum actual;

            Payload payload = new Payload()
            {
                Username = "contacto",
                Text = "MessageSample From Integrarion Tests .Net",
                Channel = "#devtest"
            };

            //ACT
            actual = sut.SendMessage(payload);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SendMessage_With_Link_In_Payload()
        {

            //ARRANGE
            SlackClient sut = new SlackClient(_slackUrlWithAccessToken);
            ResponseSlackClientEnum expected = ResponseSlackClientEnum.ok;
            ResponseSlackClientEnum actual;

            Payload payload = new Payload()
            {
                Username = "contacto",
                Text = @"https://slack.com/: <https://slack.com/|Click aquí>",
                Channel = "#devtest"
            };

            //ACT
            actual = sut.SendMessage(payload);

            //ASSERT
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void SendMessage_With_IconUrl_In_Payload()
        {
            //ARRANGE
            SlackClient sut = new SlackClient(_slackUrlWithAccessToken);
            ResponseSlackClientEnum expected = ResponseSlackClientEnum.ok;
            ResponseSlackClientEnum actual;

            Payload payload = new Payload()
            {
                Username = "contacto",
                Text = @"Text with custom Icon Url",
                Channel = "#devtest",
                IconUrl = @"https://slack.com/img/icons/app-57.png"
            };

            //ACT
            actual = sut.SendMessage(payload);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SendMessage_With_EmojiUrl_In_Payload()
        {
            //ARRANGE
            SlackClient sut = new SlackClient(_slackUrlWithAccessToken);
            ResponseSlackClientEnum expected = ResponseSlackClientEnum.ok;
            ResponseSlackClientEnum actual;

            Payload payload = new Payload()
            {
                Username = "contacto",
                Text = @"Text with custom Emoji Icon",
                Channel = "#devtest",
                IconEmoji = @":ghost:"
            };

            //ACT
            actual = sut.SendMessage(payload);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Slack.ServiceLibrary.Exceptions.IncomingWebHookDisabledException), AllowDerivedTypes = false)]
        public void SendMessage_With_Incorrect_Slack_Url()
        {
            //ARRANGE
            string incorrectSlackUrlWithAccessToken = "https://hooks.slack.com/services/T0ZA94TDE/B0ZA97MC0/CvraASyHz69dL5VGyE1dbYn";
            SlackClient sut = new SlackClient(incorrectSlackUrlWithAccessToken);

            Payload payload = new Payload();

            //ACT
            sut.SendMessage(payload);

            //ASSERT
            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void SendMessage_With_Incorrect_Url()
        {
            //ARRANGE
            string incorrectSlackUrl = "https://hooks.slack.com";
            SlackClient sut = new SlackClient(incorrectSlackUrl);

            Payload payload = new Payload();

            //ACT
            sut.SendMessage(payload);

            //ASSERT
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SendMessage_With_Attachments_Payload()
        {
            //ARRANGE
            SlackClient sut = new SlackClient(_slackUrlWithAccessToken);
            ResponseSlackClientEnum expected = ResponseSlackClientEnum.ok;
            ResponseSlackClientEnum actual;

            Payload payload = new Payload();
            payload.Attachments.Add(new Attachment("Fallback Attachment, Test from SlackClient.ServiceLibrary.IntegrationTests")
            {
                Color = "danger",
                Text = "Optional Text from test",
                Fields = new List<Field>()
                {
                    new Field("ShortField1")
                    {
                        Short=true,
                        Value ="Value for Short Field 1"
                    },
                    new Field("ShortField2")
                    {
                        Short=true,
                        Value ="Value for Short Field 2"
                    },
                    new Field("LongField1")
                    {
                        Short=false,
                        Value ="Value for *Long Long Long Long* Long Field 1"
                    },
                    new Field("LongField2WithFormat")
                    {
                        Short=false,
                        Value ="```Value for Long Long Long Long Long Field 2```"
                    }
                }
            });

            //ACT
            actual = sut.SendMessage(payload);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

    }
}
