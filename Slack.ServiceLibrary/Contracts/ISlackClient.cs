using System;
namespace Slack.ServiceLibrary.Contracts
{
    public enum ResponseSlackClientEnum
    {
        ko,
        ok
    }
    public interface ISlackClient
    {
        ResponseSlackClientEnum SendMessage(Slack.ServiceLibrary.DTO.Payload payload);
    }
}
