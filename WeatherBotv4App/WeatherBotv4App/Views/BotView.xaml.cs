using WeatherBotv4App.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherBotv4App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BotView : ContentPage
    {
        public BotView()
        {
            InitializeComponent();
            BindingContext = new ConversationViewModel();
        }
    }
}