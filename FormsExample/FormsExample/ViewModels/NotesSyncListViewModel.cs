using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FormsExample.Messages;
using FormsExample.Pages;
using FormsExample.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FormsExample.ViewModels
{
    public class NotesSyncListViewModel : ViewModelBase
    {
        private readonly NoteServiceWithSync _NoteService = NoteServiceWithSync.Instance;
        private readonly ObservableCollection<NoteViewModel> _Notes = new ObservableCollection<NoteViewModel>();
        private readonly RelayCommand _SyncCommand;
        private readonly RelayCommand _CreateCommand;
        private readonly RelayCommand<NoteViewModel> _NoteSelectedCommand;

        public NotesSyncListViewModel()
        {
            _SyncCommand = new RelayCommand( OnSync );
            _CreateCommand = new RelayCommand( OnCreate );
            _NoteSelectedCommand = new RelayCommand<NoteViewModel>( OnNoteSelected );

            SetupAsync();
        }

        public ObservableCollection<NoteViewModel> Notes
        {
            get { return _Notes; }
        }

        public ICommand SyncCommand
        {
            get { return _SyncCommand; }
        }

        public ICommand CreateCommand
        {
            get { return _CreateCommand; }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { Set( ref _Status, value ); }
        }

        private async void SetupAsync()
        {
            await _NoteService.InitLocalStoreAsync();
            await LoadNotesAsync();
        }

        private async Task LoadNotesAsync()
        {
            Notes.Clear();
            foreach ( var note in await _NoteService.GetNotesAsync() )
            {
                Notes.Add( new NoteViewModel( note, _NoteSelectedCommand ) );
            }
        }

        private async void OnSync()
        {
            Status = "Starting sync...";
            await _NoteService.SyncAsync();
            Status = "Reloading notes";
            await LoadNotesAsync();
            Status = "Last Sync: " + DateTime.Now;
        }

        private void OnCreate()
        {
            MessengerInstance.Send( new PushPageMessage( new NoteDetailsPage() ) );
        }

        private void OnNoteSelected( NoteViewModel note )
        {
            MessengerInstance.Send( new PushPageMessage( new NoteDetailsPage( note.Note ) ) );
        }
    }

    public class NoteViewModel : ViewModelBase
    {
        public Note Note { get; private set; }
        public ICommand ItemSelectedCommand { get; private set; }

        public NoteViewModel( Note note, ICommand itemSelectedCommand )
        {
            if ( note == null ) throw new ArgumentNullException( "note" );
            Note = note;
            ItemSelectedCommand = itemSelectedCommand;
        }
    }
}