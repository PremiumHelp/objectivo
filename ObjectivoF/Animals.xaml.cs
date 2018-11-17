using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.SfCarousel.XForms;
using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class Animals : ContentPage
    {
        public Animals()
        {
            InitializeComponent();
            SfCarousel flash = new SfCarousel() 
            { 
                ItemHeight = 490,
                ItemWidth = 300
            };

            ObservableCollection<SfCarouselItem> allItems = new ObservableCollection<SfCarouselItem>();

            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "bear.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "beee.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "dog.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "cat.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "cow.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "bird.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "fox.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "fish.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "horse.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "sheep.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "turtle.png", Aspect = Aspect.AspectFit } });

            flash.ItemsSource = allItems;

            this.Content = flash;
        }
    }
}
