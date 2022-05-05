using steam.Data;
using steam.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace steam.Models
{
    public class Game:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }
        public string ImageURL { get; set; }

        public DateTime ReleaseDate { get; set; }
    
        public GameCategory GameCategory  { get; set; }

        //Relationships
        public List<Game_Publisher> Games_Publishers{ get; set; }

        //Developper
        public int DevelopperId { get; set; }
        [ForeignKey("DevelopperId")]
        public Developper Developper{ get; set; }

    }
}
