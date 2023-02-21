using DailyPlanner;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DailyPlanner.List;

namespace DailyPlanner
{
    public class List
    {
        public List<Note> Note { get; set; }
        public DateTime VibData { get; set; }
        public int VibID { get; set; }
        public List<Note> AllNotes { get; set; }

        public List(DateTime date)
        {
            Note = DeserAndSer.LoadNotes(date);
            AllNotes = DeserAndSer.LoadNotes(default);
            VibData = date;
            VibID = -1;
        }
        public void UpNotes()
        {
            UpNotesData();
        }
        private void UpNotesData()
        {
            this.Note = DeserAndSer.LoadNotes(this.VibData);
        }
        public void UpdateNotes()
        {
            UpdateNotesData();
        }
        private void UpdateNotesData()
        {
            DeserAndSer.SaveNotes(this.AllNotes);
        }
        public void NewNote(string nazv, string opis, DateTime date)
        {
            Note note = new Note(this.AllNotes.Count, nazv, opis, date);
            this.AllNotes.Add(note);
            UpdateNotesData();
            UpNotesData();
        }
        public void DeleteNote(int id = -1, int ID_HEAD = -1)
        {
            if (ID_HEAD != -1)
                id = this.Note[ID_HEAD].Id;
            this.AllNotes.RemoveAll(note => note.Id == id);
            UpdateNotesData();
            UpNotesData();
        }
    }
}
