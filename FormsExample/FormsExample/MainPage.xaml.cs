using FormsExample.Pages;
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
            };
            ListView.ItemTapped += ListViewOnItemTapped;
        }

        private async void ListViewOnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var nameValue = e.Item as NamedPage;
            if ( nameValue != null )
            {
                await Navigation.PushAsync( nameValue.GetPage() );
            }
        }
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
