﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetWorld.SQLite
{
    [Table("Requests")]
    public class Request
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdAssortment { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }

        public int Count { get; set; }
        public int Summa { get; set; }
    }
}
