

using FormsExample.ViewModels;

namespace FormsExample.Pages
{
    public partial class ItemSourceBinding
    {
        public ItemSourceBinding()
        {
            InitializeComponent();
            var vm = (ItemSourceViewModel)BindingContext;

            vm.ShowMessage += OnShowMessage;
        }

        private void OnShowMessage(object sender, ShowMessageEventArgs e)
        {
            DisplayAlert("My Title", "You selected " + e.Message, "Cancel " + e.Message);
            //Also DisplayActionSheet
        }
    }
}
