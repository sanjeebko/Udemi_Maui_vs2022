using PropertyChanged;
using System.Collections.ObjectModel;
using Tasker.MVVM.Models;

namespace Tasker.MVVM.ViewModels
{
    internal class MainViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }

        public MainViewModel()
        {
            FillData();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        private void Tasks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void FillData()
        {
            Categories = new ObservableCollection<Category> {
                new Category{Id =1,CategoryName = ".NET MAUI Course", Color="#CF14DF"},
                new Category{Id =2,CategoryName = "Tutorials", Color="#df6f14"},
                new Category{Id =3,CategoryName = "Shopping", Color="#14df80"},
            };
            Tasks = new ObservableCollection<MyTask> {
                new MyTask{CategoryId =1,TaskName = "Upload Excercise files",Completed = false},
                new MyTask{CategoryId =1,TaskName = "Plan next course",Completed = false},
                new MyTask{CategoryId =2,TaskName = "Upload new Asp.Net Video on Youtube",Completed = false},
                new MyTask{CategoryId =2,TaskName = "Fix Settings.cs class of the project",Completed = false},
                new MyTask{CategoryId =2,TaskName = "Update github repository",Completed = true},
                new MyTask{CategoryId =3,TaskName = "Buy Eggs",Completed = false},
                new MyTask{CategoryId =3,TaskName = "Buy apple",Completed = false},
            };
            UpdateData();
        }

        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var tasks = Tasks.Where(a => a.CategoryId == c.Id);
                var completed = tasks.Where(a => a.Completed == true);
                var notCompleted = tasks.Where(a => a.Completed == false);

                c.PendingTasks = notCompleted.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }
            foreach (var t in Tasks)
            {
                var catColor = Categories.Where(a => a.Id == t.CategoryId).Select(a => a.Color).FirstOrDefault();
                t.TaskColor = catColor;
            }
        }
    }
}