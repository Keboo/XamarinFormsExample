using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FormsExample.ViewModels
{
    public class ItemSourceViewModel : ViewModelBase
    {
        private static readonly Random _Random = new Random();
        public event EventHandler<ShowMessageEventArgs> ShowMessage;
        private readonly RelayCommand _AddItemCommand;
        private readonly RelayCommand<Item> _ItemSelectedCommand;

        public ItemSourceViewModel()
        {
            _AddItemCommand = new RelayCommand( OnAddItem );
            _ItemSelectedCommand = new RelayCommand<Item>( OnItemSelected );
            Items = new ObservableCollection<Item>();

            for ( int i = 0; i < 3; i++ )
            {
                OnAddItem();
            }
        }

        public ObservableCollection<Item> Items { get; private set; }

        public ICommand AddItemCommand
        {
            get { return _AddItemCommand; }
        }

        private void OnAddItem()
        {
            Items.Add( new Item( _Random.Next().ToString(), _ItemSelectedCommand ) );
        }

        private void OnItemSelected( Item item )
        {
            var @event = ShowMessage;
            if ( @event != null )
            {
                @event( this, new ShowMessageEventArgs { Message = item.Display } );
            }
        }
    }

    public class Item
    {
        private readonly string _Display;
        private readonly ICommand _TappedCommand;

        public Item( string display, ICommand tappedCommand )
        {
            _Display = display;
            _TappedCommand = tappedCommand;
        }

        public string Display
        {
            get { return _Display; }
        }

        public ICommand TappedCommand
        {
            get { return _TappedCommand; }
        }
    }

    public class ShowMessageEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}