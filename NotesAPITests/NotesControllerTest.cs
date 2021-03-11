using NotesAPI.Controllers;
using NotesAPI.Data;
using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NotesAPITests
{
    public class NotesControllerTest
    {
        NotesController _notesController;

        public NotesControllerTest()
        {
            _notesController = new NotesController();
        }

        [Fact]
        public void GetNotes()
        {
            var response = _notesController.GetNotes();

            Assert.IsType<List<Note>>(response);
            Assert.Equal(3, response.Count);
        }

        [Fact]
        public void GetNote()
        {
            var response = _notesController.GetNote(3);

            Assert.Equal(3, response.Id);
        }

        [Fact]
        public void PostNote()
        {
            var newNote = new Note() { Id = 5, Title = "Hobby", Body = "Play hockey", IsComplete = true };
            var response = _notesController.AddNote(newNote);
            var notes = _notesController.GetNotes();
            var note = notes.SingleOrDefault(x => x.Id == 5);

            Assert.Equal(5, note.Id);
        }

        [Fact]
        public void DeleteNote()
        {
            _notesController.DeleteNote(1);
            var notes = _notesController.GetNotes();

            Assert.False(notes.All(x => x.Id == 1));
        }
    }
}
