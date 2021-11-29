using SQLite;
using System.Collections.Generic;


namespace PimApp
{
    public class Akt_Repository : IAkt_Repository
    {
        readonly SQLiteConnection database;

        public Akt_Repository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Akt>();
        }

        public List<Akt> GetList()
        {
            return database.Table<Akt>().ToList();
        }

        public Akt Get(int id)
        {
            return database.Get<Akt>(id);
        }

        public List<Akt> GetByNameOrg(string name)
        {
            return database.Table<Akt>().Where(i => i.Name_Org == name).ToList();
        }

        public int Delete(int id)
        {
            return database.Delete<Akt>(id);
        }

        public int Save(Akt entity)
        {
            if (entity.Id != 0)
            {
                database.Update(entity);
                return entity.Id;
            }
            else
            {
                return database.Insert(entity);
            }
        }
    }
}
