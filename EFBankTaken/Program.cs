using System;
using System.Reflection;
using Model1.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UI
{
    class Program
    {
        //private static readonly EFOpleidingenContext context = new EFOpleidingenContext();
        static void Main(string[] args)
        {

            // Taak 6: Klanten en hun rekeningen
            static void Item01()
            {
                using var context = new EFBankContext();
                var klanten = (from klant in context.Klanten.Include("Rekeningen")
                               orderby klant.Naam
                               select klant).ToList();
                foreach (var klant in klanten)
                {
                    Console.WriteLine(klant.Naam);
                    var totaleSaldo = Decimal.Zero;
                    foreach (var rekening in klant.Rekeningen)
                    {
                        Console.WriteLine($"{rekening.RekeningNr}: {rekening.Saldo}");
                        totaleSaldo += rekening.Saldo;
                    }
                    Console.WriteLine($"Totaal: {totaleSaldo}");
                    Console.WriteLine();
                }
                Console.ReadKey();
            }

            //Taak7: Zichtrekening Toevoegen
            static void Item02()
            {
                using var context = new EFBankContext();
                var klanten = from klant in context.Klanten.Include("Rekeningen") orderby klant.Naam select klant;
                foreach (var klant in klanten)
                {
                    Console.WriteLine($"{klant.KlantId}: {klant.Naam}");
                }
                Console.Write("KlantId:");
                if (int.TryParse(Console.ReadLine(), out int klantId))
                {
                    var klant = context.Klanten.Find(klantId);
                    if (klant != null)
                    {
                        Console.Write("RekeningNr:");
                        var rekeningNr = Console.ReadLine();
                        var rekening = new Model1.Entities.Rekening { RekeningNr = rekeningNr, Soort = 'Z' };
                        klant.Rekeningen.Add(rekening);
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Klant niet gevonden");
                    }
                }
                else
                {
                    Console.WriteLine("Tik een getal");

                }
            }
        }
    }
}