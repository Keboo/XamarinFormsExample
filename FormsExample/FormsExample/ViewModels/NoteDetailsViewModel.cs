using System;
using System.Windows.Input;
using FormsExample.Messages;
using FormsExample.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FormsExample.ViewModels
{
    public class NoteDetailsViewModel : ViewModelBase
    {
        private readonly Note _ExistingNote;
        private readonly RelayCommand _SaveCommand;
        private readonly RelayCommand _DeleteCommand;
        private readonly NoteServiceWithSync _Service = NoteServiceWithSync.Instance;

        public NoteDetailsViewModel()
        {
            _SaveCommand = new RelayCommand( OnSave );
            _DeleteCommand = new RelayCommand( OnDelete, CanDelete );
        }

        public NoteDetailsViewModel( Note note )
            : this()
        {
            if ( note == null ) throw new ArgumentNullException( "note" );
            _ExistingNote = note;
            Title = note.Title;
            Text = note.Text;
        }

        public ICommand SaveCommand
        {
            get { return _SaveCommand; }
        }

        public ICommand DeleteCommand
        {
            get { return _DeleteCommand; }
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { Set( ref _Title, value ); }
        }

        private string _Text;
        public string Text
        {
            get { return _Text; }
            set { Set( ref _Text, value ); }
        }

        private async void OnSave()
        {
            if ( _ExistingNote != null )
            {
                _ExistingNote.Title = Title;
                _ExistingNote.Text = Text;
                await _Service.SaveNote( _ExistingNote );
            }
            else
            {
                await _Service.CreateNote( Title, Text );
            }
            MessengerInstance.Send( new PopPageMessage() );
        }

        private async void OnDelete()
        {
            await _Service.DeleteNote(_ExistingNote);
            MessengerInstance.Send( new PopPageMessage() );
        }

        private bool CanDelete()
        {
            return _ExistingNote != null;
        }
    }
}