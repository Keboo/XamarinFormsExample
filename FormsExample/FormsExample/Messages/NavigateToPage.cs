using System;
using Xamarin.Forms;

namespace FormsExample.Messages
{
    public class NavigateToPage
    {
        public Page Page { get; private set; }

        public NavigateToPage(Page page)
        {
            if (page == null) throw new ArgumentNullException("page");
            Page = page;
        }
    }
}