using mvvm;
using mvvm.Interfaces;
using System.Globalization;
using Xamarin.Forms;

namespace LocaliseText
{
    public partial class App : Application
    {
        public static ViewModelLocator locator;
        public static ViewModelLocator Locator { get { return locator ?? (locator = new ViewModelLocator()); } }
        public App()
        {
            var netLanguage = DependencyService.Get<ILocalize>().GetCurrent();
            mvvm.Languages.Resource.Culture = new CultureInfo(netLanguage);
            DependencyService.Get<ILocalize>().SetLocale();

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
