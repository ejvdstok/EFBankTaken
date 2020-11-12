using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model1.Entities
{
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
