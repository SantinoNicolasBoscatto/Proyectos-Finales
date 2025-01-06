using AutoFixture;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NotesApp.Data;
using NotesApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Mocks
{
    public static class MockDataGenerator
    {
        public static void AddNotesRepository(DbContextNotes context, bool withTasks = false)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var notes = fixture.CreateMany<NoteModel>().ToList();

            // Crearemos un record Streamers pero con su propiedad hija null
            if (!withTasks)
            {
                notes.Add(fixture.Build<NoteModel>().With(x => x.Id, 8001)
                .With(x => x.IdentityUserId, "d6d94155-1a3f-4ce5-a819-eba202ed823d").With(x => x.Name, "Prueba")
                .Without(x => x.ToDoTasks).Create());
            }
            else
            {
                notes.Add(fixture.Build<NoteModel>().With(x => x.Id, 8001)
                .With(x => x.IdentityUserId, "d6d94155-1a3f-4ce5-a819-eba202ed823d").With(x => x.Name, "Prueba").Create());
            }

            context.AddRange(notes);
            context.SaveChanges();
            context.ChangeTracker.Clear();
        }
    }
}
