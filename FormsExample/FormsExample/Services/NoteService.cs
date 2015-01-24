using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace FormsExample.Services
{
    public class NoteService
    {
        private readonly MobileServiceClient _MobileService;

        public NoteService()
        {
            _MobileService = new MobileServiceClient(
                "https://xamarinhackday.azure-mobile.net/",
                "cDMvGpxmJhIZJcTWREDcdVJOomKyHr77" );
        }

        public async Task<IList<Note>> GetNotesAsync()
        {
            return await _MobileService.GetTable<Note>().ToListAsync();
        }
    }
}