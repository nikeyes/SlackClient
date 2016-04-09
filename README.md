# SlackClient
Simple Slack Client to Send Messages 

## Code Example
```C#
//Read https://api.slack.com/incoming-webhooks for a valid API url
String slackUrlWithAccessToken = "https://hooks.slack.com/services/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";
SlackClient slackClient = new SlackClient(slackUrlWithAccessToken);
Payload payload = new Payload()
{
	Username = "contacto",
	Text = @"Text with custom Emoji Icon",
	Channel = "#devtest",
	IconEmoji = @":ghost:"
};
ResponseSlackClientEnum result = slackClient.SendMessage(payload);
```

## See more samples in [IntegrationTests](Slack.ServiceLibrary.IntegrationTests)

