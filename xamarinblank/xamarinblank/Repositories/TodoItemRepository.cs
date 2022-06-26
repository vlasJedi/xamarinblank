using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xamarinblank.Models;
using SQLite;

namespace xamarinblank.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private SQLiteConnection _connection;
        public event EventHandler<TodoItem> OnItemAdded;
        public event EventHandler<TodoItem> OnItemUpdated;

        public List<TodoItem> GetItems()
        {
            CreateConnection();
            return _connection.Table<TodoItem>().ToList();
        }

        public void AddItem(TodoItem item)
        {
            CreateConnection();
            _connection.Insert(item);
            OnItemAdded?.Invoke(this, item);
        }

        public void UpdateItem(TodoItem item)
        {
            CreateConnection();
            _connection.Update(item);
            OnItemUpdated?.Invoke(this, item);
        }

        public void AddOrUpdate(TodoItem item)
        {
            if (item.Id == 0)
            {
                AddItem(item);
            }
            else
            {
                UpdateItem(item);
            }
        }

        private void CreateConnection()
        {
            if (_connection != null)
            {
                return;
            }

            var userDocumentsPath = Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments);
            var databasePath = Path.Combine(userDocumentsPath, "todo-items.db");

            _connection = new SQLiteConnection(databasePath);
            _connection.CreateTable<TodoItem>();

            if (_connection.Table<TodoItem>().Any())
            {
                _connection.Insert(new TodoItem()
                {
                    Title = "Welcome to ToDoItems",
                    Due = DateTime.Now
                });
            }
        }
    }
}