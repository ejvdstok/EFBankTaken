using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("Klanten")]
    public class Klant
    {
        public Klant() 
        { 
            Rekeningen = new List<Rekening>(); 
        }

        public int KlantId { get; set; }
        public string Naam { get; set; }
        public virtual ICollection<Rekening> Rekeningen { get; set; }
    }
}
