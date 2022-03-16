using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetWorld.SQLite
{
    [Table("Assortments")]
    public class Assortment
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Mass { get; set; }
        public string Unit { get; set; }
        public int Price { get; set; }
        public string PhotoPath { get; set; }
        public string Type { get; set; }
    }
}
