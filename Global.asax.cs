using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NHibernate.Tool.hbm2ddl;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using MVC_Nhibernate;
using MVC_PRACA_INZ.Repository;
using MVC_PRACA_INZ.Domain;
using MVC_PRACA_INZ.Authorization;
using System.Diagnostics;

namespace MVC_PRACA_INZ
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801



    public class MvcApplication : System.Web.HttpApplication
    {
        private static bool przykladowe_dane = true;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("ParentChild", "{controller}/{action}/{parentid}/{id}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters

                        new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );


        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //Generowanie przykladowych danych
            if (przykladowe_dane == true)
            {
                NHibernateRepository<Administrator> AdministratorRepo = new NHibernateRepository<Administrator>(MvcApplication.SessionFactory.OpenSession());
                NHibernateRepository<Pracownik> PracownikRepo = new NHibernateRepository<Pracownik>(MvcApplication.SessionFactory.OpenSession());
                NHibernateRepository<Wiadomosc> WiadomoscRepo = new NHibernateRepository<Wiadomosc>(MvcApplication.SessionFactory.OpenSession());
                NHibernateRepository<Linki> LinkiRepo = new NHibernateRepository<Linki>(MvcApplication.SessionFactory.OpenSession());
                NHibernateRepository<Droga> DrogaRepo = new NHibernateRepository<Droga>(MvcApplication.SessionFactory.OpenSession());
                NHibernateRepository<Utrudnienie> UtrudnienieRepo = new NHibernateRepository<Utrudnienie>(MvcApplication.SessionFactory.OpenSession());

                var admin = new Administrator();
                admin.login = "admin";
                admin.haslo = Encryption.EncryptPassword("123456");
                admin.imie = "Ewa";
                admin.nazwisko = "Noc";
                admin.e_mail = "admin@zmianynadrogach.pl";
                admin.drugi_e_mail = "admin@gmail.com";
                admin.gg = 12345678;
                admin.skype = "admin_skype";
                admin.pesel = "88010111211";
                admin.nazwa_urzedu = "Małopolski Urząd Wojewódzki";
                admin.wojewodztwo = "Małopolskie";
                admin.powiat = "Krakowski";
                admin.gmina = "Kraków";
                admin.kod_pocztowy = "31-402";
                admin.miasto = "Kraków";
                admin.ulica = "Warszawska";
                admin.nr_budynku = 22;
                admin.telefon = "777333222";
                admin.rola = Rola.Administrator;
                admin.aktywny = true;
                AdministratorRepo.Add(admin);

                var moderator = new Administrator();
                moderator.login = "admin2";
                moderator.haslo = Encryption.EncryptPassword("123456");
                moderator.imie = "Tomasz";
                moderator.nazwisko = "Kowalski";
                moderator.e_mail = "admin2@zmianynadrogach.pl";
                moderator.drugi_e_mail = "admin2@gmail.com";
                moderator.gg = 1342425;
                moderator.skype = "admin2_skype";
                moderator.pesel = "87032914711";
                moderator.nazwa_urzedu = "Małopolski Urząd Wojewódzki";
                moderator.wojewodztwo = "Małopolskie";
                moderator.powiat = "Krakowski";
                moderator.gmina = "Kraków";
                moderator.kod_pocztowy = "31-402";
                moderator.miasto = "Kraków";
                moderator.ulica = "Warszawska";
                moderator.nr_budynku = 22;
                moderator.telefon = "777333223";
                moderator.rola = Rola.Moderator;
                moderator.aktywny = true;
                AdministratorRepo.Add(moderator);

                var pracownik_malopolski = new Pracownik();
                pracownik_malopolski.login = "jannowak";
                pracownik_malopolski.haslo = Encryption.EncryptPassword("jannowak");
                pracownik_malopolski.imie = "Jan";
                pracownik_malopolski.drugie_imie = "Tomasz";
                pracownik_malopolski.nazwisko = "Nowak";
                pracownik_malopolski.e_mail = "jan.nowak@zmianynadrogach.pl";
                pracownik_malopolski.pesel = "88020211222";
                pracownik_malopolski.nazwa_urzedu = "Urząd Miejski w Krakowie";
                pracownik_malopolski.wojewodztwo = "Małopolskie";
                pracownik_malopolski.powiat = "Krakowski";
                pracownik_malopolski.gmina = "Kraków";
                pracownik_malopolski.kod_pocztowy = "31-405";
                pracownik_malopolski.miasto = "Kraków";
                pracownik_malopolski.ulica = "Warszawska";
                pracownik_malopolski.nr_budynku = 22;
                pracownik_malopolski.telefon = "876876876";
                pracownik_malopolski.stanowisko = "Referent do spraw infrastruktury";
                pracownik_malopolski.dzial = "Wydział Infrastruktury Miejskiej";
                pracownik_malopolski.rola = Rola.Pracownik_malopolski;
                pracownik_malopolski.aktywny = true;
                PracownikRepo.Add(pracownik_malopolski);

                var pracownik_malopolski2 = new Pracownik();
                pracownik_malopolski2.login = "arturhak";
                pracownik_malopolski2.haslo = Encryption.EncryptPassword("arturhak");
                pracownik_malopolski2.imie = "Artur";
                pracownik_malopolski2.drugie_imie = "Franciszek";
                pracownik_malopolski2.nazwisko = "Hak";
                pracownik_malopolski2.e_mail = "artur.hak@zmianynadrogach.pl";
                pracownik_malopolski2.pesel = "82050612323";
                pracownik_malopolski2.nazwa_urzedu = "Urząd Miejski w Krakowie";
                pracownik_malopolski2.wojewodztwo = "Małopolskie";
                pracownik_malopolski2.powiat = "Krakowski";
                pracownik_malopolski2.gmina = "Kraków";
                pracownik_malopolski2.kod_pocztowy = "31-405";
                pracownik_malopolski2.miasto = "Kraków";
                pracownik_malopolski2.ulica = "Warszawska";
                pracownik_malopolski2.nr_budynku = 22;
                pracownik_malopolski2.telefon = "899896896";
                pracownik_malopolski2.stanowisko = "Referent do spraw infrastruktury";
                pracownik_malopolski2.dzial = "Wydział Infrastruktury Miejskiej";
                pracownik_malopolski2.rola = Rola.Pracownik_malopolski;
                pracownik_malopolski2.aktywny = true;
                PracownikRepo.Add(pracownik_malopolski2);

                Wiadomosc[] wiadomosc = new Wiadomosc[6];
                wiadomosc[0] = new Wiadomosc();
                wiadomosc[0].tytul = "Test - Zmiany w Krakowie";
                wiadomosc[0].tresc = "Remont Ronda Mogilskiego za miesiąc.";
                wiadomosc[0].data = System.DateTime.Today;
                wiadomosc[0].zrodlo = "Urząd miejski w Krakowie";
                wiadomosc[1] = new Wiadomosc();
                wiadomosc[1].tytul = "Test - Zmiany w Krakowie";
                wiadomosc[1].tresc = "Remont ulicy Lublańskiej za 2 miesiące.";
                wiadomosc[1].data = System.DateTime.Today;
                wiadomosc[1].zrodlo = "Urząd miejski w Krakowie";
                wiadomosc[2] = new Wiadomosc();
                wiadomosc[2].tytul = "Test - Zmiany w Nowym Sączu";
                wiadomosc[2].tresc = "Wypadek na ulicy Legionów.";
                wiadomosc[2].data = System.DateTime.Today;
                wiadomosc[2].zrodlo = "Urząd miejski w Nowym Sączu";
                wiadomosc[3] = new Wiadomosc();
                wiadomosc[3].tytul = "Test - Remont w Wawrzeńczycach";
                wiadomosc[3].tresc = "Remont drogi krajowej 79.";
                wiadomosc[3].data = System.DateTime.Today;
                wiadomosc[3].zrodlo = "Gmina Igołomia-Wawrzeńczyce";
                wiadomosc[4] = new Wiadomosc();
                wiadomosc[4].tytul = "Google Maps API v3";
                wiadomosc[4].tresc = "Zastosowanie na stronie podglądu utrudnień z wykorzystaniem Google Maps API w wersji 3";
                wiadomosc[4].data = System.DateTime.Today;
                wiadomosc[4].zrodlo = "Administrator serwisu";
                wiadomosc[5] = new Wiadomosc();
                wiadomosc[5].tytul = "Wprowadzenie nowych funkcjonalności";
                wiadomosc[5].tresc = "Dzisiaj wprowadzono nową funkcjonalność na stronie - odsyłacze do ważnych stron urzędów w Małopolsce.";
                wiadomosc[5].data = System.DateTime.Today;
                wiadomosc[5].zrodlo = "Administrator serwisu";
                foreach (var item in wiadomosc)
                {
                    WiadomoscRepo.Add(item);
                }

                Linki[] linki = new Linki[7];
                linki[0] = new Linki();
                linki[0].adres = "http://google.pl";
                linki[0].opis = "Najlepsza wyszukiwarka";
                linki[1] = new Linki();
                linki[1].adres = "http://www.gddkia.gov.pl";
                linki[1].opis = "Oficjalna strona GDDKiA";
                linki[2] = new Linki();
                linki[2].adres = "http://www.gddkia.gov.pl/pl/306/gddkia-krakow";
                linki[2].opis = "Oficjalna strona małopolskiego oddziału GDDKiA";
                linki[3] = new Linki();
                linki[3].adres = "http://www.zdpk.krakow.pl/";
                linki[3].opis = "Zarząd Dróg Powiatu Krakowskiego";
                linki[4] = new Linki();
                linki[4].adres = "http://www.zdw.krakow.pl/";
                linki[4].opis = "Zarząd Dróg wojewódzkich w Krakowie";
                linki[5] = new Linki();
                linki[5].adres = "http://www.zikit.krakow.pl/";
                linki[5].opis = "Zarząd Infrastruktury Komunalnej i Transportu w Krakowie";
                linki[6] = new Linki();
                linki[6].adres = "http://www.mech.pk.edu.pl/";
                linki[6].opis = "Strona Wydziału Mechanicznego Politechniki Krakowskiej (uczelnia autora pracy)";
                foreach (var item in linki)
                {
                    LinkiRepo.Add(item);
                }

                Droga[] droga = new Droga[13];
                droga[0] = new Droga();
                droga[0].kategoria = "Krajowa";
                droga[0].numer = "A4";
                droga[0].dlugosc = "43,963";
                droga[1] = new Droga();
                droga[1].kategoria = "Krajowa";
                droga[1].numer = "4";
                droga[1].dlugosc = "67,006";
                droga[2] = new Droga();
                droga[2].kategoria = "Krajowa";
                droga[2].numer = "S7";
                droga[2].dlugosc = "21,859";
                droga[3] = new Droga();
                droga[3].kategoria = "Wojewódzka";
                droga[3].numer = "768";
                droga[3].dlugosc = "27,4";
                droga[4] = new Droga();
                droga[4].kategoria = "Wojewódzka";
                droga[4].numer = "783";
                droga[4].dlugosc = "60,3";
                droga[5] = new Droga();
                droga[5].kategoria = "Wojewódzka";
                droga[5].numer = "966";
                droga[5].dlugosc = "50,3";
                droga[6] = new Droga();
                droga[6].kategoria = "Wojewódzka";
                droga[6].numer = "984";
                droga[6].dlugosc = "13,3";
                droga[7] = new Droga();
                droga[7].kategoria = "Wojewódzka";
                droga[7].numer = "993";
                droga[7].dlugosc = "16,1";
                droga[8] = new Droga();
                droga[8].kategoria = "Powiatowa";
                droga[8].numer = "1992K";
                droga[8].dlugosc = "3,0";
                droga[9] = new Droga();
                droga[9].kategoria = "Powiatowa";
                droga[9].numer = "2125K";
                droga[9].dlugosc = "7,5";
                droga[10] = new Droga();
                droga[10].kategoria = "Powiatowa";
                droga[10].numer = "2133K";
                droga[10].dlugosc = "4,6";
                droga[11] = new Droga();
                droga[11].kategoria = "Powiatowa";
                droga[11].numer = "2183K";
                droga[11].dlugosc = "4,6";
                droga[12] = new Droga();
                droga[12].kategoria = "Gminna";
                droga[12].numer = "340206S"; //slask
                droga[12].dlugosc = "0,631";
                foreach (var item in droga)
                {
                    DrogaRepo.Add(item);
                }
            }

        }

        public static ISessionFactory SessionFactory = CreateSessionFactory();

        public MvcApplication()
        {
            this.BeginRequest += new EventHandler(MvcApplication_BeginRequest);
            this.EndRequest += new EventHandler(MvcApplication_EndRequest);

        }

        private static ISessionFactory CreateSessionFactory()
        {
            Console.SetOut(new SqlOutput());

            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Entity).Assembly);

            var SchemaExport = new SchemaExport(cfg);
            SchemaExport.SetOutputFile(@"db.sql");

            if (przykladowe_dane == true)
            {
                SchemaExport.Execute(true, true, false);

                //DROP DATABASE
                //SchemaExport.Execute(false, false, true);
            }

            return cfg.BuildSessionFactory();

        }

        void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            ISession session = SessionFactory.OpenSession();
            session.BeginTransaction();
            CurrentSessionContext.Bind(session);
        }

        void MvcApplication_EndRequest(object sender, EventArgs e)
        {
            CurrentSessionContext.Unbind(SessionFactory).Dispose();
        }

    }
}