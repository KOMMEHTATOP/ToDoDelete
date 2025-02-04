using System.ComponentModel;


namespace ToDoDelete.Model
{
    public class TaskItem :INotifyPropertyChanged
    {
		private string _title = string.Empty;

		public string Title
		{
			get { return _title; }
			set 
			{ 
				_title = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
			}
		}

        public event PropertyChangedEventHandler? PropertyChanged;
		
		private bool _isCompleted;
        public bool IsCompleted
		{
			get { return _isCompleted; }
			set 
			{ 
				_isCompleted = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCompleted)));

            }
        }
	}
}
