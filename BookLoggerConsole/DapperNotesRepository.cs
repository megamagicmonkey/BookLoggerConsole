using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookLoggerConsole
{
    class DapperNotesRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperNotesRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Notes> GetAllNotes()
        {
            return _connection.Query<Notes>("SELECT * FROM notes;");
        }


        //arguments use the term old if it is referencing an old item and new if it is creating or editing new information

        public void AddNote(int oldBookID, string newNote)
        {
            _connection.Execute("INSERT INTO notes (BookID, Note) VALUES (@BookID, @Note);",
            new { BookID = oldBookID, Note = newNote });
        }

        public void EditNote(int oldNoteID, string newNote)
        {
            _connection.Execute("UPDATE notes SET Note = @Note WHERE NoteID = @NoteID;",
            new { NoteID = oldNoteID, Note = newNote });
        }

        //Delete method
        public void DeleteEntry(int oldNoteID)
        {
            _connection.Execute("DELETE FROM notes WHERE NoteID = @NoteID;",
            new { BookID = oldNoteID });
        }

    }
}
