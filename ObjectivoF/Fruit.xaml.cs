using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.SfCarousel.XForms;
using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class Fruit : ContentPage
    {
        public Fruit()
        {
            InitializeComponent();
            SfCarousel flash = new SfCarousel() 
            {

                ItemHeight = 490 ,
                ItemWidth = 300
            };

            ObservableCollection<SfCarouselItem> allItems = new ObservableCollection<SfCarouselItem>();

            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "banana.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "ananas.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "apple.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "cherry.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "grapes.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "kiwi.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "lemon.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "peach.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "plum.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "straw.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "warm.png", Aspect = Aspect.AspectFit } });

            flash.ItemsSource = allItems;

            this.Content = flash;
        }
    }
}
