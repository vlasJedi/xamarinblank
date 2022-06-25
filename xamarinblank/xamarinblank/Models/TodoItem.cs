﻿using System;

namespace xamarinblank.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Due { get; set; }
        public bool Completed { get; set; }
    }
}
