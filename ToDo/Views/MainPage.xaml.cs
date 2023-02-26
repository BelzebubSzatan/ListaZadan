using System;
using System.Collections.ObjectModel;
using System.Linq;
using ToDo.ClassModel;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.IO;
using ToDo.INotificationManager;

namespace ToDo {
    public partial class MainPage : TabbedPage {
        ObservableCollection<ToDoModel> Elements = new ObservableCollection<ToDoModel>();
        public static string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cos.json");
        INotification NotificationMenager;
        public MainPage() {
            InitializeComponent();
            NotificationMenager = DependencyService.Get<INotification>();
            NotificationMenager.Initialize();
            ReadFromFile();
            OpenNotification();
            List.ItemsSource = Elements;

            Time.Time = DateTime.Now.TimeOfDay;
        }
        public MainPage(bool flag) {
            InitializeComponent();
            NotificationMenager = DependencyService.Get<INotification>();
            NotificationMenager.Initialize();
            ReadFromFile();
            List.ItemsSource = Elements;

            Time.Time = DateTime.Now.TimeOfDay;
        }


        void OpenNotification() {
            var TodayTasks = Elements.Where(e => e.Enddate == DateTime.Today);

            if (TodayTasks.Count() > 0)
                NotificationMenager.SendNotification("Dzisiejsze zadania", $"Dzisiaj masz do wykonania {TodayTasks.Count()} zadan/ia");
        }


        private void AddTaks(object sender, EventArgs e) {
            var check = Elements.Where(l => l.Title == Title.Text);

            if (check.Count() == 0) {
                Elements.Add(new ToDoModel(Title.Text, Date.Date, Time.Time));
                NotificationMenager.SendNotification("Konczy sie czas na wykonianie zadania", Title.Text, Date.Date + Time.Time);
                WriteToFile();
            } else
                DisplayAlert("Taki tytul juz istnieje", "", "Powrót");
        }

        public void WriteToFile() {
            string JsonString = JsonConvert.SerializeObject(Elements);
            File.WriteAllText(fileName, JsonString);
        }

        public void ReadFromFile() {
            if (File.Exists(fileName)) {
                string result = File.ReadAllText(fileName);
                Elements = JsonConvert.DeserializeObject<ObservableCollection<ToDoModel>>(result);
            }
            else
                File.WriteAllText(fileName,"");
        }

        private void DeleteElement(object sender, EventArgs e) {
            var element = List.SelectedItem;
            Elements.Remove(element as ToDoModel);
            WriteToFile();
        }

        private void SearchBarTextChanged(object sender, TextChangedEventArgs e) {
            var Search = Elements.Where(el => el.Title.ToLower().Contains(SearchBar.Text));
            List.ItemsSource = Search;
        }
    }
}

