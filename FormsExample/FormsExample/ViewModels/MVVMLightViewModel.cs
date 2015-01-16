using GalaSoft.MvvmLight;

namespace FormsExample.ViewModels
{
    public class MVVMLightViewModel : ViewModelBase
    {
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set { Set(ref _Username, value); }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { Set(ref _Password, value); }
        }
    }
}