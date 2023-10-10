using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sliding_Block_Puzzle.Views;

namespace Sliding_Block_Puzzle
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
