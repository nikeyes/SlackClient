using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slack.ServiceLibrary.Contracts;
using Slack.ServiceLibrary.DTO;
using Slack.ServiceLibrary.Implementation;

namespace Slack.ServiceLibrary.UnitTests
{
    [TestClass]
    public class SlackClientTests
    {
        private readonly string _urlWithAccessToken = "https://hooks.slack.com/services/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";

        [TestMethod]
        public void SendMessage_With_Default_Payload()
        {
            //ARRANGE
            SlackClient sut = new SlackClient(_urlWithAccessToken);
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
            SlackClient sut = new SlackClient(_urlWithAccessToken);
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
            SlackClient sut = new SlackClient(_urlWithAccessToken);
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
            SlackClient sut = new SlackClient(_urlWithAccessToken);
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
    }
}
