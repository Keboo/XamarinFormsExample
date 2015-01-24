using System;
using Xamarin.Forms;

namespace FormsExample.Messages
{
    public class PushPageMessage
    {
        public Page Page { get; private set; }

        public PushPageMessage(Page page)
        {
            if (page == null) throw new ArgumentNullException("page");
            Page = page;
        }
    }
}