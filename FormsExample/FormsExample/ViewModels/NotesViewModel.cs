using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FormsExample.Services;
using GalaSoft.MvvmLight;

namespace FormsExample.ViewModels
{
    public class NotesViewModel : ViewModelBase
    {
        private readonly NoteService _NoteService = new NoteService();
        private readonly ObservableCollection<Note> _Notes = new ObservableCollection<Note>();

        public NotesViewModel()
        {
            Notes.Add( new Note { Text = "Loading..." } );
            LoadNotesAsync();
        }

        public async void LoadNotesAsync()
        {
            await Task.Delay(1000);
            bool clear = true;
            foreach ( var note in await _NoteService.GetNotesAsync() )
            {
                Notes.Add( note );
                if ( clear )
                {
                    clear = false;
                    Notes.RemoveAt( 0 );
                }
            }
        }

        public ObservableCollection<Note> Notes
        {
            get { return _Notes; }
        }
    }
}