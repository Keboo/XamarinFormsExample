using Newtonsoft.Json;

namespace FormsExample.Services
{
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