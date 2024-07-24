﻿using System.ComponentModel.DataAnnotations;

namespace ZealandZoo.Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
