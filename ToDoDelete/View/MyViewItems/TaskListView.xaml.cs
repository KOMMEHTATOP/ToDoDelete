using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ToDoDelete.Model;

namespace ToDoDelete.View.MyViewItems
{
    public partial class TaskListView : UserControl
    {
        // Регистрация DependencyProperty
        public static readonly DependencyProperty TasksProperty = DependencyProperty.Register(nameof(Tasks), typeof(ObservableCollection<TaskItem>), typeof(TaskListView), new PropertyMetadata(null));

        public TaskListView()
        {
            InitializeComponent();

            Tasks = new ObservableCollection<TaskItem>();
        }

        // Свойство, которое использует зарегистрированное DependencyProperty
        public ObservableCollection<TaskItem> Tasks
        {
            get => (ObservableCollection<TaskItem>)GetValue(TasksProperty);
            set => SetValue(TasksProperty, value);
        }
    }

}
