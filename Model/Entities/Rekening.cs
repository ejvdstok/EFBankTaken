using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public partial class Rekening
    {
        //--- PROPERTIES---

        public int RekeningId { get; set; }
        public string RekeningNr { get; set; }
        public int KlantId { get; set; }
        public decimal Saldo {get;set;}
        public char Soort { get; set; }

        public virtual Klant Klant { get; set; }
    }
}
