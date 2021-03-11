using Microsoft.AspNetCore.Mvc;
using NotesAPI.Data;
using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Controllers
{
    [ApiController]
    [Route("api/Notes")]
    public class NotesController : ControllerBase
    {
        private readonly DataContext dataContext;
        public NotesController()
        {
            dataContext = DataContext.Context;
        }

        [HttpGet("/api/Notes")]
        public List<Note> GetNotes()
        {
            return dataContext.Notes;
        }

        [HttpGet("/api/Notes/{id}")]
        public Note GetNote(int id)
        {
            var noteData = dataContext.Notes.FirstOrDefault(c => c.Id == id);

            return noteData;
        }

        [HttpPost("/api/Notes")]
        public Note AddNote([FromBody] Note note)
        {
            dataContext.Notes.Add(note);
            dataContext.SaveJsonData();

            return note;
        }

        [HttpPut("/api/Notes/{id}")]
        public void UpdateNote(int id, [FromBody] Note note)
        {
            for (var index = dataContext.Notes.Count - 1; index >= 0; index--)
            {
                if (dataContext.Notes[index].Id == id)
                {
                    dataContext.Notes[index] = note;
                }
            }
            dataContext.SaveJsonData();
        }

        [HttpDelete("/api/Notes/{id}")]
        public void DeleteNote(int id)
        {
            for (var index = dataContext.Notes.Count - 1; index >= 0; index--)
            {
                if (dataContext.Notes[index].Id == id)
                {
                    dataContext.Notes.RemoveAt(index);
                }
            }
            dataContext.SaveJsonData();
        }
    }
}
