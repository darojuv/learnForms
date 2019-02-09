using learnForms.Models;
using learnForms.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace learnForms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NowPlaying : ContentPage
	{
        public ObservableCollection<NowPlayingMovies> npms;
		public NowPlaying ()
		{
			InitializeComponent ();
            npms = new ObservableCollection<NowPlayingMovies>();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ApiServices apiServices = new ApiServices();
            var npmsResponse = await apiServices.GetNowPlayingMovies();
            foreach (NowPlayingMovies item in npms)
            {
                npms.Add(item);
            }
            LvNowPlaying.ItemsSource = npms;
        }
	}
}