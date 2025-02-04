using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToDoDelete.Model;
using ToDoDelete.ViewModel.Commands;

namespace ToDoDelete.ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public TaskViewModel()
        {
            _taskCollection = new ObservableCollection<TaskItem>();
            _newTaskTitle = string.Empty;
            AddTaskCommand = new RelayCommand(AddTask, CanAddTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask, CanDeleteTask);
            IsCompliteCommand = new RelayCommand(CompleteTask);

        }

        private void CompleteTask(object obj)
        {
            if (obj is TaskItem task)
            {
                task.IsCompleted = !task.IsCompleted;
            }
        }

        private bool CanAddTask(object? arg)
        {
            return !string.IsNullOrWhiteSpace(NewTaskTitle);
        }

        private void AddTask(object? obj)
        {
            if (!string.IsNullOrWhiteSpace(NewTaskTitle))
            {
                TaskCollection.Add(new TaskItem { Title = NewTaskTitle, IsCompleted = false });
                NewTaskTitle = "";
            }
        }

        private bool CanDeleteTask(object? arg)
        {
            return arg is TaskItem;
        }

        private void DeleteTask(object? obj)
        {
            if (obj is TaskItem taskToDelete)
            {
                TaskCollection.Remove(taskToDelete);
            }
        }

        private ObservableCollection<TaskItem> _taskCollection;
        public ObservableCollection<TaskItem> TaskCollection
        {
            get { return _taskCollection; }
            set
            {
                _taskCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaskCollection)));
            }
        }

        private string _newTaskTitle;
        public string NewTaskTitle
        {
            get { return _newTaskTitle; }
            set
            {
                _newTaskTitle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewTaskTitle)));
                AddTaskCommand.RaiseCanExecuteChanged();
            }
        }

        private TaskItem _selectedTask;
        public TaskItem SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTask)));
                DeleteTaskCommand.RaiseCanExecuteChanged(); 
            }
        }


        public RelayCommand AddTaskCommand { get; set; }
        public RelayCommand DeleteTaskCommand { get; set; }
        public RelayCommand IsCompliteCommand { get; set; }
    }
}
