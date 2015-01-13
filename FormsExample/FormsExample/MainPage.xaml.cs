using FormsExample.Pages;
using Xamarin.Forms;

namespace FormsExample
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            ListView.ItemsSource = new NameValue[]
            {
                new NameValue<LayoutDemoPage>("Layout Demo"),
                new NameValue<BasicBinding>("Basic Binding Demo"),
                new NameValue<ItemSourceBinding>("Item Source Binding"),
            };
            ListView.ItemTapped += ListViewOnItemTapped;
        }

        private async void ListViewOnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var nameValue = e.Item as NameValue;
            if ( nameValue != null )
            {
                await Navigation.PushAsync( nameValue.GetPage() );
            }
        }
    }

    public abstract class NameValue
    {
        public string Name { get; set; }

        protected NameValue( string name )
        {
            Name = name;
        }

        public abstract Page GetPage();
    }

    public class NameValue<T> : NameValue where T : Page, new()
    {
        public NameValue( string name )
            : base( name )
        { }

        public override Page GetPage()
        {
            return new T();
        }
    }
}
