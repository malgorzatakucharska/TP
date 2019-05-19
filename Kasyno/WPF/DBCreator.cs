using Kasyno.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WPF
{
    public class DBCreator: DbContext
    {
        public DBCreator() : base("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False") { }

        public DbSet<Gra> Gry { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<StanGry> StanyGier { get; set; }
        public DbSet<UdzialWGrze> Udzialy { get; set; }

        public void inicjalizuj() {
            using (var context = new DBCreator())
            {
                Klient k1 = new Klient()
                {
                    imie = "Jan",
                    nazwisko = "Kowaski",
                    wiek = 35,
                    adresEmail = "kowaskij@gmail.com"
                };
                Klient k2 = new Klient()
                {
                    imie = "Zofia",
                    nazwisko = "Nowak",
                    wiek = 42,
                    adresEmail = "zofianowak@gmail.com"
                };
                Klient k3 = new Klient()
                {
                    imie = "Juliusz",
                    nazwisko = "Dobrowolski",
                    wiek = 50,
                    adresEmail = "jdobrowolski@gmail.com"
                };


                Gra gra1 = new Gra()
                {
                    Id = 0023,
                    nazwa = "Ruletka"
                };
                Gra gra2 = new Gra()
                {
                    Id = 0028,
                    nazwa = "Baccarad",
                };
                Gra gra3 = new Gra()
                {
                    Id = 0037,
                    nazwa = "Craps",
                };


                StanGry stangry1 = new StanGry()
                {
                    gra = gra1,
                    dataUruchomienia = new DateTimeOffset(new DateTime(2010, 01, 10))
                };
                StanGry stangry2 = new StanGry()
                {
                    gra = gra2,
                    dataUruchomienia = new DateTimeOffset(new DateTime(2005, 04, 18))
                };
                StanGry stangry3 = new StanGry()
                {
                    gra = gra3,
                    dataUruchomienia = new DateTimeOffset(new DateTime(2019, 05, 11))
                };


                UdzialWGrze udzial1 = new UdzialWGrze()
                {
                    stangry = stangry1,
                    klient = k1
                };
                UdzialWGrze udzial2 = new UdzialWGrze()
                {
                    stangry = stangry2,
                    klient = k2
                };
                UdzialWGrze udzial3 = new UdzialWGrze()
                {
                    stangry = stangry3,
                    klient = k3
                };

                context.Klienci.Add(k1);
                context.Klienci.Add(k2);
                context.Klienci.Add(k3);
                context.Gry.Add(gra1);
                context.Gry.Add(gra2);
                context.Gry.Add(gra3);
                context.StanyGier.Add(stangry1);
                context.StanyGier.Add(stangry2);
                context.StanyGier.Add(stangry3);
                context.Udzialy.Add(udzial1);
                context.Udzialy.Add(udzial2);
                context.Udzialy.Add(udzial3);


                context.SaveChanges();
            }
        }
        }
    }


