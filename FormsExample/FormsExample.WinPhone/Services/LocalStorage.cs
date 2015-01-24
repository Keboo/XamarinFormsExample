using System.IO;
using Windows.Storage;
using FormsExample.Services;
using FormsExample.WinPhone.Services;
using Xamarin.Forms;

[assembly: Dependency( typeof( LocalStorage ) )]
namespace FormsExample.WinPhone.Services
{
    public class LocalStorage : ILocalStorage
    {
        public string GetLocalDatabaseFilePath()
        {
            return Path.Combine( ApplicationData.Current.TemporaryFolder.Path, "local.wp.db" );
        }
    }
}