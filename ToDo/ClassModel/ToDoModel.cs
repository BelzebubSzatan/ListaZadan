using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.ClassModel {
    public class ToDoModel {


        public ToDoModel() {
            Title = "Sample";
            Enddate= DateTime.Now;
        }

        public ToDoModel(string title, DateTime enddate, TimeSpan endtime) {
            Title = title;
            Enddate = enddate;
            Endtime = endtime;
            EndDateTime = enddate + endtime;
        }

        public string Title { get; set; }
        public string Image {
            get {
                return "warning.png";
            }
        }
        public DateTime Enddate { get; set; }
        public TimeSpan Endtime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
