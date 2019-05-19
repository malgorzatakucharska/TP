using Kasyno.MainLogic;
using Kasyno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;

namespace UnitTest
{
    class WypelnianieZPliku:DataFiller
    {
        public override void Fill(DataContext context)
        {

            List<Klient> klienci = context.klienci;
            Dictionary<int, Gra> gry = context.gry;
            ObservableCollection<UdzialWGrze> udzialywgrze = context.udzialywgrze;
            List<StanGry> stanygier = context.stanygier;

            try
            {
                List<string[]> dataList = File.ReadLines("dane.txt").Select(line => line.Split(';')).ToList();

                foreach (string[] line in dataList)
                {
                    Klient klient = new Klient { imie = line[0], nazwisko = line[1], wiek = Int16.Parse(line[2]), adresEmail = line[3]};
                    Gra gra = new Gra { id = Int16.Parse(line[4]), nazwa = line[5]};
                    StanGry stan = new StanGry { gra = gra, dataUruchomienia = new DateTimeOffset(new DateTime(Int32.Parse(line[6]), Int32.Parse(line[7]), Int32.Parse(line[8]))) };
                    UdzialWGrze udzial = new UdzialWGrze { stangry = stan, klient = klient };

                    klienci.Add(klient);
                    gry.Add(gra.id, gra);
                    stanygier.Add(stan);
                    udzialywgrze.Add(udzial);
                }
                Console.Write(klienci.Count);
            }
            catch (FileNotFoundException exception)
            {
                Console.Write(exception.Message);
            }
            catch (IOException exception)
            {
                Console.Write(exception.StackTrace);
            }


        }
    }
}
