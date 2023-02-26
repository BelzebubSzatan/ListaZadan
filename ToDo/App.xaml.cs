using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo {
    public partial class App : Application {
        public App(bool flag) {
            InitializeComponent();
            if(flag)
                MainPage = new MainPage(flag);
            else
            MainPage =new MainPage();
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
