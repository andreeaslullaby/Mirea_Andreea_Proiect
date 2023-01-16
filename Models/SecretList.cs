﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Mirea_Andreea_Proiect.Models
{
    public class SecretList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(400), Unique]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
