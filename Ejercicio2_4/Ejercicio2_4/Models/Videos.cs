using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ejercicio2_4.Models
{
    public class Videos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Uri { get; set; }

        public string Descripcion { get; set; }
    }
}
