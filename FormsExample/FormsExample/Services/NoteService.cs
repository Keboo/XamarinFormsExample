using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

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

    public class Note
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty( "text" )]
        public string Text { get; set; }
    }
}