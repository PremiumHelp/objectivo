using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.SfCarousel.XForms;
using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class Vegetables : ContentPage
    {
        public Vegetables()
        {
            InitializeComponent();
           
            SfCarousel flash = new SfCarousel()
            {
                ItemHeight = 490,
                ItemWidth = 300 
               
            };

            ObservableCollection<SfCarouselItem> allItems = new ObservableCollection<SfCarouselItem>();

            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "bell.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "carrots.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "corn.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "kohl.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "peas.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "tomato.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "potato.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "cuc.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "egg.png", Aspect = Aspect.AspectFit } });

            flash.ItemsSource = allItems;

            this.Content = flash;
        }
    }
}
