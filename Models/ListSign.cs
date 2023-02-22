using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Mirea_Andreea_Proiect.Models
{
   public class ListSign
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(SignList))]
        public int SignListID { get; set; }
        public int SignID { get; set; }
    }
}
