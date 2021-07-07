using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToDo
{
    class ToDoViewModel : BindableObject
    {
        private ToDoItem _selectedItem;
        public ToDoViewModel()
        {
            Items = new ObservableCollection<ToDoItem>(ToDoItem.GetToDoItems());
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

        private void AddNewItem()
        {
            Items.Add(new ToDoItem($"ToDo Item {Items.Count + 1}"));
        }
    }
}
