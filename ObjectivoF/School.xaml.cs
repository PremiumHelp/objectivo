using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.SfCarousel.XForms;
using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class School : ContentPage
    {
        public School()
        {
            InitializeComponent();
            SfCarousel flash = new SfCarousel() { ItemWidth = 300, ItemHeight = 490 };

            ObservableCollection<SfCarouselItem> allItems = new ObservableCollection<SfCarouselItem>();

            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "desk.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "eraser.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "lineal.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "pen.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "sbag.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "sharp.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "pencil.png", Aspect = Aspect.AspectFit } });

            flash.ItemsSource = allItems;

            this.Content = flash;
        }
    }
}
