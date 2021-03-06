using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToDo
{
    public class ToDoViewModel : BindableObject
    {
        private ToDoItem _selectedItem;
        private string _completedHeader;
        private double _completedProgress;

        public event EventHandler<double> UpdateProgressBar;

        public ToDoViewModel()
        {
            Items = new ObservableCollection<ToDoItem>(ToDoItem.GetToDoItems());
            CalculateCompletedHeader();
        }
        public string CompletedHeader
        {
            get => _completedHeader;
            set
            {
                _completedHeader = value;
                OnPropertyChanged();
            }
        }

        public double CompletedProgress
        {
            get => _completedProgress;
            set
            {
                _completedProgress = value;
                OnPropertyChanged();
            }
        }



        public ObservableCollection<ToDoItem> Items { get; set; }

        public string PageTitle { get; set; }
        public ToDoItem SelectedItem { get => _selectedItem;
            set {
                _selectedItem = value;
                PageTitle = value?.Name;
                OnPropertyChanged("PageTitle");
            }
        }

        public ICommand AddItemCommand => new Command(() => AddNewItem());

        public ICommand MarkAsCompletedCommand => new Command<ToDoItem>(MarkAsCompleted);

        private void MarkAsCompleted(ToDoItem obj)
        {
            obj.Completed = true;
            Items.Remove(obj);
            Items.Add(obj);
            CalculateCompletedHeader();
        }

        private void CalculateCompletedHeader()
        {
            CompletedHeader = $"Completed {Items.Count(x => x.Completed)}/{Items.Count}";
            CompletedProgress = (double)Items.Count(x => x.Completed) / (double)Items.Count;
            UpdateProgressBar?.Invoke(this, CompletedProgress);
        }

        private void AddNewItem()
        {
            Items.Add(new ToDoItem($"ToDo Item {Items.Count + 1}"));
            CalculateCompletedHeader();
        }
    }
}
