
using FormsExample.Droid.Services;
using FormsExample.Services;
using Xamarin.Forms;

[assembly: Dependency( typeof( LocalStorage) )]
namespace FormsExample.Droid.Services
{
    public class LocalStorage : ILocalStorage
    {
        public string GetLocalDatabaseFilePath()
        {
            return "local.andriod.db";
        }
    }
}