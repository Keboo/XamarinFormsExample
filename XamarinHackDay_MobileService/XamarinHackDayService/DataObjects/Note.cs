using Microsoft.WindowsAzure.Mobile.Service;

namespace XamarinHackDayService.DataObjects
{
    public class Note : EntityData
    {
        public string Text { get; set; }

        public string Title { get; set; }
    }
}