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
            var controller = new NotesController();
            var response = controller.GetNotes();

            Assert.IsType<List<Note>>(response);
            Assert.Equal(3, response.Count);
        }

        [Fact]
        public void GetNote()
        {
            var controller = new NotesController();
            var response = controller.GetNote(3);

            Assert.Equal(3, response.Id);
        }

        [Fact]
        public void PutNote()
        {
            var controller = new NotesController();
            var updatedNote = new Note() { Id = 2, Title = "Hobby", Body = "Play hockey", IsComplete = true };
            controller.UpdateNote(2, updatedNote);
            var notes = controller.GetNotes();
            var note = notes.SingleOrDefault(x => x.Id == 2);

            Assert.Equal("Hobby", note.Title);
            Assert.Equal("Play hockey", note.Body);
        }

        [Fact]
        public void PostNote()
        {
            var controller = new NotesController();
            var newNote = new Note() { Id = 5, Title = "Hobby", Body = "Play hockey", IsComplete = true };
            var response = controller.AddNote(newNote);
            var notes = controller.GetNotes();
            var note = notes.SingleOrDefault(x => x.Id == 5);

            Assert.Equal(5, note.Id);
        }

        [Fact]
        public void DeleteNote()
        {
            var controller = new NotesController();
            controller.DeleteNote(1);
            var notes = controller.GetNotes();

            Assert.False(notes.All(x => x.Id == 1));
        }
    }
}
