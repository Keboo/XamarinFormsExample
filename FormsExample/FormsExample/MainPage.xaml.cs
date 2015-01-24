using FormsExample.Messages;
using FormsExample.Pages;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;

namespace FormsExample
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            ListView.ItemsSource = new NamedPage[]
            {
                new NamedPage<BasicBinding>("Basic Binding Demo"),
                new NamedPage<MVVMLightPage>("MVVMLight Demo"),
                new NamedPage<ItemSourceBinding>("Item Source Binding"),
                new NamedPage<Messaging>("Messaging"),
                new NamedPage<NotesListView>("Notes Mobile Service"),
                new NamedPage<NotesSyncList>("Notes w/ Offline Sync"),
            };
            ListView.ItemTapped += ListViewOnItemTapped;

            #region Note Example Implementation
            Messenger.Default.Register<PushPageMessage>( this, OnPushPage );
            Messenger.Default.Register<PopPageMessage>( this, async msg => await Navigation.PopAsync() );
            #endregion Note Example Implementation
        }

        private async void ListViewOnItemTapped( object sender, ItemTappedEventArgs e )
        {
            var nameValue = e.Item as NamedPage;
            if ( nameValue != null )
            {
                await Navigation.PushAsync( nameValue.GetPage() );
            }
        }

        #region Note Example Implementation

        private async void OnPushPage( PushPageMessage message )
        {
            await Navigation.PushAsync( message.Page );
        }

        #endregion Note Example Implementation
    }

    public abstract class NamedPage
    {
        public string Name { get; set; }

        protected NamedPage( string name )
        {
            Name = name;
        }

        public abstract Page GetPage();
    }

    public class NamedPage<T> : NamedPage where T : Page, new()
    {
        public NamedPage( string name )
            : base( name )
        { }

        public override Page GetPage()
        {
            return new T();
        }
    }
}
