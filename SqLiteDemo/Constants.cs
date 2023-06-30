using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqLiteDemo;

public static class Constants
{
    private const string DB_FILE_NAME = "SQLite.db3";

    public const SQLiteOpenFlags FLAGS = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;

    public static string DatabasePath
    {
        get
        {
            return Path.Combine(FileSystem.AppDataDirectory, DB_FILE_NAME);
        }
    }
}