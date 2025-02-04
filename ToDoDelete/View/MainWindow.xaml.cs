using System.Windows;
using System.Windows.Data;
using ToDoDelete.View.MyViewItems;

namespace ToDoDelete
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel.TaskViewModel();
            TaskListViewControl.SetBinding(TaskListView.TasksProperty, new Binding("TaskCollection") { Source = this.DataContext });
        }
    }
}