using System;
using System.Collections.Generic;
using System.Text;

namespace Model1.Entities
{
    public partial class Rekening
    {
        //--- PROPERTIES--//
        public int RekeningId { get; set; }
        public string RekeningNr { get; set; }
        public int KlantId { get; set; }
        public decimal Saldo { get; set; }
        public char Soort { get; set; }

        //--NAVIGATIONAL PROPERTIES--//
        public virtual Klant Klant { get; set; }
    }
}
