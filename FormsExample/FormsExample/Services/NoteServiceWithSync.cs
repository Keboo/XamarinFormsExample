using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Xamarin.Forms;

namespace FormsExample.Services
{
    public class NoteServiceWithSync
    {
        private static readonly Lazy<NoteServiceWithSync> _Instance
            = new Lazy<NoteServiceWithSync>();
        public static NoteServiceWithSync Instance
        {
            get { return _Instance.Value; }
        }

        private readonly MobileServiceClient _MobileService;

        public NoteServiceWithSync()
        {
            _MobileService = new MobileServiceClient(
                "https://xamarinhackday.azure-mobile.net/",
                "cDMvGpxmJhIZJcTWREDcdVJOomKyHr77" );
        }

        public async Task<IList<Note>> GetNotesAsync()
        {
            return await _MobileService.GetSyncTable<Note>().ToListAsync();
        }

        public async Task InitLocalStoreAsync()
        {
            if ( !_MobileService.SyncContext.IsInitialized )
            {
                string dbLocation = DependencyService.Get<ILocalStorage>().GetLocalDatabaseFilePath();

                var store = new MobileServiceSQLiteStore( dbLocation );
                store.DefineTable<Note>();
                await _MobileService.SyncContext.InitializeAsync( store, new MobileServiceSyncHandler() );
            }
        }

        public async Task SyncAsync()
        {
            await _MobileService.SyncContext.PushAsync();
            var noteTable = _MobileService.GetSyncTable<Note>();
            await noteTable.PullAsync( "notes", noteTable.CreateQuery() );
        }

        public async Task CreateNote( string title, string text )
        {
            var noteTable = _MobileService.GetSyncTable<Note>();
            await noteTable.InsertAsync( new Note
            {
                Title = title,
                Text = text
            } );
        }

        public async Task SaveNote( Note note )
        {
            var noteTable = _MobileService.GetSyncTable<Note>();
            await noteTable.UpdateAsync( note );
        }

        public async Task DeleteNote( Note note )
        {
            var noteTable = _MobileService.GetSyncTable<Note>();
            await noteTable.DeleteAsync( note );
        }
    }
}