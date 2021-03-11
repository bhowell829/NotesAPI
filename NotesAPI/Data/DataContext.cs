using Newtonsoft.Json;
using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Data
{
    public class DataContext
    {
        private static readonly DataContext _dataContext;
        public List<Note> Notes = new List<Note>();

        static DataContext()
        {
            _dataContext = new DataContext();
        }

        private DataContext()
        {
            FillData();
        }

        public static DataContext Context
        {
            get
            {
                return _dataContext;
            }
        }

        public void FillData()
        {
            string noteData = File.ReadAllText("notesdata.json");
            List<Note> tempNotes = JsonConvert.DeserializeObject<List<Note>>(noteData);

            if (tempNotes != null)
            {
                foreach (var note in tempNotes)
                {
                    Notes.Add(new Note { Id = note.Id, Title = note.Title, Body = note.Body, IsComplete = note.IsComplete });
                }
            }
        }

        public void SaveJsonData()
        {
            string newNoteData = JsonConvert.SerializeObject(Notes, Formatting.Indented);
            File.WriteAllText("notesdata.json", newNoteData);
        }
    }
}
