using System;
using MediaExperience.Models;
using MediaExperience.ViewModels;
using MediaExperience.Views;
using Xamarin.Forms;

namespace MediaExperience
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel _vm;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = _vm = GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<MainViewModel>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _vm.Start();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            
            Navigation.PushAsync(new VideoPage((Video) e.SelectedItem, TimeSpan.Zero));
            ((ListView) sender).SelectedItem = null;
        }
    }
}
