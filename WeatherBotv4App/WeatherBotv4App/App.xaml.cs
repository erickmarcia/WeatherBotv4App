using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WeatherBotv4App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.BotView();
        }
    }
}
