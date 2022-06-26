using System;
using xamarinblank.Models;

namespace xamarinblank.ViewModels
{
    public class TodoItemViewModel : ViewModel
    {
        public TodoItem Item { get; private set; }
        public event EventHandler ItemStatusChanged; 

        public TodoItemViewModel(TodoItem item) => Item = item;

        public string StatusText => Item.Completed ? "Reactive" : "Completed";
    }
}