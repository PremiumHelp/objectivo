using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.SfCarousel.XForms;
using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class Clothes : ContentPage
    {
        public Clothes()
        {
            InitializeComponent();
            SfCarousel  flash= new SfCarousel() { ItemWidth = 300, ItemHeight = 490 };

            ObservableCollection<SfCarouselItem> allItems = new ObservableCollection<SfCarouselItem>();

            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "ear.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "high.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "jeans.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "neck.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "scarf.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "shirt.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "shoes.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "skirt.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "sunn.png", Aspect = Aspect.AspectFit } });
            allItems.Add(new SfCarouselItem() { ItemContent = new Image() { Source = "swim.png", Aspect = Aspect.AspectFit } });

            flash.ItemsSource = allItems;

            this.Content = flash;
        }
    }
}
