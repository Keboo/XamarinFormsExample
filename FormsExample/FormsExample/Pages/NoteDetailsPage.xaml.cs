

using FormsExample.Services;
using FormsExample.ViewModels;

namespace FormsExample.Pages
{
    public partial class NoteDetailsPage
    {
        public NoteDetailsPage()
        {
            InitializeComponent();
            BindingContext = new NoteDetailsViewModel();
        }

        public NoteDetailsPage( Note note )
        {
            InitializeComponent();
            BindingContext = new NoteDetailsViewModel( note );
        }
    }
}
