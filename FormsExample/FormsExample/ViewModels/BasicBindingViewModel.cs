using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace FormsExample.ViewModels
{
    public class BasicBindingViewModel : INotifyPropertyChanged
    {
        public string Title
        {
            get { return "Bound Title"; }
        }

        public BasicBindingViewModel()
        {
            Cost = 1234;
            _ChangeCostCommand = new Command(OnChangeCost);
        }

        #region INotifyPropertyChanged
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null )
        {
            var handler = PropertyChanged;
            if ( handler != null ) handler( this, new PropertyChangedEventArgs( propertyName ) );
        }

        #endregion INotifyPropertyChanged

        #region Basic Bindable Property

        private string _Value;
        public string Value
        {
            get { return _Value; }
            set
            {
                if (_Value != value)
                {
                    _Value = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion Basic Bindable Property

        #region Cost

        public int Cost { get; set; }

        private readonly Command _ChangeCostCommand;
        public ICommand ChangeCostCommand
        {
            get { return _ChangeCostCommand;  }
        }

        private void OnChangeCost()
        {
            Cost = new Random().Next();
        }
        #endregion Cost
    }
}