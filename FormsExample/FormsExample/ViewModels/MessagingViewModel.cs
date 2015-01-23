using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace FormsExample.ViewModels
{
    public class MessagingViewModel : ViewModelBase
    {
        public MessagingViewModel()
        {
            _SendMessageCommand = new RelayCommand( OnSendMessage );
            _SendMessageWithDataCommand = new RelayCommand<string>( OnSendMessageWithData, CanSendMessageWithData );
            _SendMessageWithMvvmLightCommand = new RelayCommand( OnSendMvvmLightMessage );
        }

        #region Send Message

        private readonly RelayCommand _SendMessageCommand;

        public ICommand SendMessageCommand
        {
            get { return _SendMessageCommand; }
        }

        private void OnSendMessage()
        {
            MessagingCenter.Send( this, "MyMessage" );
        }

        #endregion Send Message

        #region Send Message With Data

        private readonly RelayCommand<string> _SendMessageWithDataCommand;

        public ICommand SendMessageWithDataCommand
        {
            get { return _SendMessageWithDataCommand; }
        }

        private void OnSendMessageWithData( string data )
        {
            MessagingCenter.Send( this, "MyMessageWithData", data );
        }

        private bool CanSendMessageWithData( string data )
        {
            return !string.IsNullOrWhiteSpace( data );
        }

        #endregion Send Message With Data

        #region Send Message With MVVM Light

        private readonly RelayCommand _SendMessageWithMvvmLightCommand;

        public ICommand SendMessageWithMvvmLightCommand
        {
            get { return _SendMessageWithMvvmLightCommand; }
        }

        private void OnSendMvvmLightMessage()
        {
            MessengerInstance.Send( "This is my message" );
        }

        #endregion Send Message With MVVM Light
    }
}