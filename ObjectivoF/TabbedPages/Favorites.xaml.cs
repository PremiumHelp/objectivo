using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ObjectivoF.Data;
using ObjectivoF.Models;
using Xamarin.Forms;

namespace ObjectivoF.TabbedPages
{
	public partial class Favorites : ContentPage
	{

		public Favorites()
		{
			InitializeComponent();

			BindingContext = new ViewModelVocab();
		}
	}       }

