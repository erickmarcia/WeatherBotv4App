using System.Collections.ObjectModel;
using System.Threading.Tasks;

using WeatherBotv4App.Models;
using WeatherBotv4App.Helpers;

using Microsoft.Bot.Connector.DirectLine;

namespace WeatherBotv4App.Services
{
    public class DirectLineService
    {
        DirectLineClient Client;
        Conversation Conversation;
        public ChannelAccount Account;

        public DirectLineService(string name)
        {
            var tokenResponse = new DirectLineClient(Constants.DirectLineSecret).Tokens.GenerateTokenForNewConversation();

            Client = new DirectLineClient(tokenResponse.Token);
            Conversation = Client.Conversations.StartConversation();
            Account = new ChannelAccount(name, name);
        }

        public void SendMessage(string message)
        {
            var activity = new Activity
            {
                From = Account,
                Text = message,
                Type = ActivityTypes.Message
            };

            Client.Conversations.PostActivity(Conversation.ConversationId, activity);
        }

        public async Task GetMessages(ObservableCollection<Message> collection)
        {
            string watermark = null;

            while (true)
            {
                var set = await Client.Conversations.GetActivitiesAsync(Conversation.ConversationId, watermark);
                watermark = set?.Watermark;

                foreach (var activity in set.Activities)
                {
                    if (activity.From.Id == Constants.BotID)
                    {
                        var message = new Message(activity.Text, activity.From.Name);
                        collection.Add(message);
                    }
                }

                await Task.Delay(3000);
            }
        }
    }
}
