using System;
using System.Collections.Generic;
using System.Text;
using Ejercicio2_4.Models;
using SQLite;
using System.Threading.Tasks;

namespace Ejercicio2_4.Controllers
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection db;

        public DataBase(string pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<Videos>().Wait();
        }

        public Task<List<Videos>> GetVideoList()
        {
            return db.Table<Videos>().ToListAsync();
        }

        public Task<Videos> GetVideoForId(int pcodigo)
        {
            return db.Table<Videos>()
                .Where(i => i.Id == pcodigo)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveVideoRecord(Videos videos)
        {
            if (videos.Id != 0)
            {
                return db.UpdateAsync(videos);
            }
            else
            {
                return db.InsertAsync(videos);
            }
        }

        public Task<int> DeleteVideo(Videos videos)
        {
            return db.DeleteAsync(videos);
        }
    }
}
