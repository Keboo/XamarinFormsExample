using FormsExample.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;

namespace FormsExample.Pages
{
    public partial class Messaging
    {
        public Messaging()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<MessagingViewModel>( this, "MyMessage", MyMessageCallback );
            MessagingCenter.Subscribe<MessagingViewModel, string>( this, "MyMessageWithData", MyMessageWithDataCallback );

            Messenger.Default.Register<string>( this, MvvmLightStringCallback );
        }

        private void MyMessageCallback( MessagingViewModel sender )
        {
            DisplayAlert( "Message Received", "Received MyMessage from ViewModel", "Sweet", "I don't care" );
        }

        private void MyMessageWithDataCallback( MessagingViewModel sender, string data )
        {
            DisplayAlert( "Message Received", "Received message with data: " + data, "OK" );
        }

        private void MvvmLightStringCallback( string message )
        {
            DisplayAlert( "MVVM Light Message Received", "Received message: " + message, "OK" );
        }
    }
}
