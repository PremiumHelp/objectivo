using System;
using System.Collections.Generic;
using ObjectivoF.Services;
using Xamarin.Forms;
using ObjectivoF.ViewModel;
namespace ObjectivoF.TabbedPages
{
    public partial class Translate : ContentPage
    {

        public Translate()
        {
            InitializeComponent();
            BindingContext = new ViewModelTranslate();

        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;


        }
        void OnPickerSelectedIndexChanged2(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex2 = picker.SelectedIndex;


        }
       
        }
    } 


