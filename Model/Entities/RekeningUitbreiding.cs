using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public partial class Rekening
    {
        public void Storten(decimal bedrag)
        {
            Saldo += bedrag;
        }
    }
}
