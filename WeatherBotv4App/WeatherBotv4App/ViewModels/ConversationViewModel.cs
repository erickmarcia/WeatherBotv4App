using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using WeatherBotv4App.Helpers;
using WeatherBotv4App.Models;
using WeatherBotv4App.Services;

using Xamarin.Forms;

namespace WeatherBotv4App.ViewModels
{
    public class ConversationViewModel : BaseViewModel
    {
        DirectLineService service;
        public ObservableCollection<Message> Messages { get; set; }

        private string _query;

        public string Query
        {
            get { return _query; }
            set { SetProperty(ref _query, value);  }
        }

        public ICommand SendQueryCommand { get; private set; }

        public ConversationViewModel()
        {
            service = new DirectLineService(Constants.BotUser);
            Messages = new ObservableCollection<Message>();
            SendQueryCommand = new Command(SendMessage);
            StartConversation();
        }

        async Task StartConversation() => await service.GetMessages(Messages);

        void SendMessage()
        {
            if (!string.IsNullOrWhiteSpace(_query))
            {
                var user = service.Account.Name.ToUpper();
                var message = new Message(_query, user);

                Messages.Add(message);
                service.SendMessage(_query);
            }

            Query = string.Empty;
        }
    }
}