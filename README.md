# SlackClient
Simple Slack Client to Send Messages 

## Code Example
```C#
String urlWithAccessToken = "https://hooks.slack.com/services/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";
SlackClient slackClient = new SlackClient(urlWithAccessToken);
ResponseSlackClientEnum result = slackClient.SendMessage(payload);
```

