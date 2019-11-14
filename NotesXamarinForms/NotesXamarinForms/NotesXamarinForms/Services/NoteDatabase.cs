using NotesXamarinForms.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotesXamarinForms.Services
{
    public class NoteDatabase
    {
        private readonly SQLiteAsyncConnection connection;

        public NoteDatabase(string path)
        {
            this.connection = new SQLiteAsyncConnection(path);
            this.connection.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return this.connection.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return this.connection
                .Table<Note>()
                .Where(n => n.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.Id != 0)
            {
                return this.connection.UpdateAsync(note);
            }

            return this.connection.InsertAsync(note);
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return this.connection.DeleteAsync(note);
        }
    }
}
