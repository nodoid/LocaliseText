using GalaSoft.MvvmLight.Ioc;
using mvvm.ViewModels;

namespace mvvm
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main => SimpleIoc.Default.GetInstance<MainViewModel>();

        public static void Cleanup()
        {
        }
    }
}

