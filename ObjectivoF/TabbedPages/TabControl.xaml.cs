using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ObjectivoF.TabbedPages;

namespace ObjectivoF
{
    public partial class TabControl : TabbedPage
    {
        public TabControl()
        {
            InitializeComponent();
            BindingContext = this;
            this.Children.Add(new Home());
            this.Children.Add(new Favorites());
            this.Children.Add(new Translate());
            this.Children.Add(new Views.GroupPage());
        }
   
       

    }
}
