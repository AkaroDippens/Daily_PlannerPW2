using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DailyPlanner
{
    public class Note
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Nazvaniye { get; set; }
        public string Opisaniye { get; set; }
        public Note(int id, string nazvanie, string opisanie, DateTime date)
        {
            Id = id;
            Nazvaniye = nazvanie;
            Opisaniye = opisanie;
            Date = date;
        }
    }
}

