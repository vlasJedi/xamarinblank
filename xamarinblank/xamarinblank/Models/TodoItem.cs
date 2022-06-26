using System;
using SQLite;

namespace xamarinblank.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Due { get; set; }
        public bool Completed { get; set; }
    }
}
