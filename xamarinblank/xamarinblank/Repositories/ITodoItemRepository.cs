using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarinblank.Models;

namespace xamarinblank.Repositories
{
    public interface ITodoItemRepository
    {
        event EventHandler<TodoItem> OnItemAdded;
        event EventHandler<TodoItem> OnItemUpdated;

        List<TodoItem> GetItems();
        void AddItem(TodoItem item);
        void UpdateItem(TodoItem item);
        void AddOrUpdate(TodoItem item);
    }
}
