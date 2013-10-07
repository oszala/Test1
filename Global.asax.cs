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
using MVC_PRACA_INZ.Models;
using MVC_PRACA_INZ.Authorization;
using System.Diagnostics;

namespace MVC_PRACA_INZ
{
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
                NHRepository<Administrator> AdministratorRepo = new NHRepository<Administrator>(MvcApplication.SessionFactory.OpenSession());
                NHRepository<Pracownik> PracownikRepo = new NHRepository<Pracownik>(MvcApplication.SessionFactory.OpenSession());
                NHRepository<Wiadomosc> WiadomoscRepo = new NHRepository<Wiadomosc>(MvcApplication.SessionFactory.OpenSession());
                NHRepository<Linki> LinkiRepo = new NHRepository<Linki>(MvcApplication.SessionFactory.OpenSession());
                NHRepository<Droga> DrogaRepo = new NHRepository<Droga>(MvcApplication.SessionFactory.OpenSession());
                NHRepository<Utrudnienie> UtrudnienieRepo = new NHRepository<Utrudnienie>(MvcApplication.SessionFactory.OpenSession());

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
                admin.powiat = "krakowski";
                admin.gmina = "Kraków";
                admin.kod_pocztowy = "31-156";
                admin.miasto = "Kraków";
                admin.ulica = "Basztowa";
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
                moderator.powiat = "krakowski";
                moderator.gmina = "Kraków";
                moderator.kod_pocztowy = "31-156";
                moderator.miasto = "Kraków";
                moderator.ulica = "Basztowa";
                moderator.nr_budynku = 22;
                moderator.telefon = "123921200";
                moderator.rola = Rola.Moderator;
                moderator.aktywny = true;
                AdministratorRepo.Add(moderator);

                var pracownik_malopolski = new Pracownik();
                pracownik_malopolski.login = "jannowak";
                pracownik_malopolski.haslo = Encryption.EncryptPassword("jannowak");
                pracownik_malopolski.imie = "Jan";
                pracownik_malopolski.drugie_imie = "Tomasz";
                pracownik_malopolski.nazwisko = "Nowak";
                pracownik_malopolski.e_mail = "jannowak@zmianynadrogach.pl";
                pracownik_malopolski.pesel = "88020211222";
                pracownik_malopolski.nazwa_urzedu = "Urząd Miejski w Krakowie";
                pracownik_malopolski.wojewodztwo = "Małopolskie";
                pracownik_malopolski.powiat = "krakowski";
                pracownik_malopolski.gmina = "Kraków";
                pracownik_malopolski.kod_pocztowy = "31-004";
                pracownik_malopolski.miasto = "Kraków";
                pracownik_malopolski.ulica = "Wszystkich Świętych";
                pracownik_malopolski.nr_budynku = 3;
                pracownik_malopolski.telefon = "126161207";
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
                pracownik_malopolski2.e_mail = "arturhak@zmianynadrogach.pl";
                pracownik_malopolski2.pesel = "82050612323";
                pracownik_malopolski2.nazwa_urzedu = "Urząd Miejski w Krakowie";
                pracownik_malopolski2.wojewodztwo = "Małopolskie";
                pracownik_malopolski2.powiat = "krakowski";
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

                var pracownik_malopolski3 = new Pracownik();
                pracownik_malopolski3.login = "jaroslawwodnik";
                pracownik_malopolski3.haslo = Encryption.EncryptPassword("arturhak");
                pracownik_malopolski3.imie = "Jarosław";
                pracownik_malopolski3.drugie_imie = "Tomasz";
                pracownik_malopolski3.nazwisko = "Wodnik";
                pracownik_malopolski3.e_mail = "jaroslawwodnik@zmianynadrogach.pl";
                pracownik_malopolski3.pesel = "81020714711";
                pracownik_malopolski3.nazwa_urzedu = "Urząd Miejski w Tarnowie";
                pracownik_malopolski3.wojewodztwo = "Małopolskie";
                pracownik_malopolski3.powiat = "tarnowski";
                pracownik_malopolski3.gmina = "Tarnów";
                pracownik_malopolski3.kod_pocztowy = "33-100";
                pracownik_malopolski3.miasto = "Tarnów";
                pracownik_malopolski3.ulica = "Mickiewicza";
                pracownik_malopolski3.nr_budynku = 2;
                pracownik_malopolski3.telefon = "+48146882400";
                pracownik_malopolski3.stanowisko = "Podinspektor";
                pracownik_malopolski3.dzial = "Wydział Infrastruktury Drogowej i Ochrony Środowiska";
                pracownik_malopolski3.rola = Rola.Pracownik_malopolski;
                pracownik_malopolski3.aktywny = true;
                PracownikRepo.Add(pracownik_malopolski3);

                Wiadomosc[] wiadomosc = new Wiadomosc[7];
                wiadomosc[0] = new Wiadomosc();
                wiadomosc[0].tytul = "Test - Zmiany w Krakowie";
                wiadomosc[0].tresc = "Remont Ronda Mogilskiego za miesiąc.";
                wiadomosc[0].data = new DateTime(2011, 10, 22);
                wiadomosc[0].zrodlo = "Urząd miejski w Krakowie";
                wiadomosc[1] = new Wiadomosc();
                wiadomosc[1].tytul = "Test - Zmiany w Krakowie";
                wiadomosc[1].tresc = "Remont ulicy Lublańskiej za 2 miesiące.";
                wiadomosc[1].data = new DateTime(2011, 10, 23);
                wiadomosc[1].zrodlo = "Urząd miejski w Krakowie";
                wiadomosc[2] = new Wiadomosc();
                wiadomosc[2].tytul = "Test - Zmiany w Nowym Sączu";
                wiadomosc[2].tresc = "Wypadek na ulicy Legionów.";
                wiadomosc[2].data = new DateTime(2011, 12, 22);
                wiadomosc[2].zrodlo = "Urząd miejski w Nowym Sączu";
                wiadomosc[3] = new Wiadomosc();
                wiadomosc[3].tytul = "Test - Remont w Wawrzeńczycach";
                wiadomosc[3].tresc = "Remont drogi krajowej 79.";
                wiadomosc[3].data = new DateTime(2012, 01, 07);
                wiadomosc[3].zrodlo = "Gmina Igołomia-Wawrzeńczyce";
                wiadomosc[4] = new Wiadomosc();
                wiadomosc[4].tytul = "Google Maps API v3";
                wiadomosc[4].tresc = "Zastosowanie na stronie podglądu utrudnień z wykorzystaniem Google Maps API w wersji 3";
                wiadomosc[4].data = new DateTime(2012, 02, 29);
                wiadomosc[4].zrodlo = "Administrator serwisu";
                wiadomosc[5] = new Wiadomosc();
                wiadomosc[5].tytul = "Wprowadzenie nowych funkcjonalności";
                wiadomosc[5].tresc = "Dzisiaj wprowadzono nową funkcjonalność na stronie - odsyłacze do ważnych stron urzędów w Małopolsce.";
                wiadomosc[5].data = new DateTime(2012, 03, 01);
                wiadomosc[5].zrodlo = "Administrator serwisu";
                wiadomosc[6] = new Wiadomosc();
                wiadomosc[6].tytul = "Dodanie geocodingu do mapy";
                wiadomosc[6].tresc = "Na mapie utrudnień działa wyszukiwanie miejsc po podanym adresie.";
                wiadomosc[6].data = new DateTime(2012, 03, 02);
                wiadomosc[6].zrodlo = "Administrator serwisu";
                foreach (var item in wiadomosc)
                {
                    WiadomoscRepo.Add(item);
                }

                Linki[] linki = new Linki[8];
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
                linki[6].adres = "http://www.bip.krakow.pl/";
                linki[6].opis = "Biuletyn informacji publicznej miasta Krakowa";
                linki[7] = new Linki();
                linki[7].adres = "http://www.mech.pk.edu.pl/";
                linki[7].opis = "Strona Wydziału Mechanicznego Politechniki Krakowskiej (uczelnia autora pracy)";
                foreach (var item in linki)
                {
                    LinkiRepo.Add(item);
                }

                Droga[] droga = new Droga[23];
                droga[0] = new Droga();
                droga[0].kategoria = "Krajowa";
                droga[0].numer = "A4";
                droga[0].dlugosc = 680;
                droga[1] = new Droga();
                droga[1].kategoria = "Krajowa";
                droga[1].numer = "4";
                droga[1].dlugosc = 218;
                droga[2] = new Droga();
                droga[2].kategoria = "Krajowa";
                droga[2].numer = "S7";
                droga[2].dlugosc = 720;
                droga[3] = new Droga();
                droga[3].kategoria = "Wojewódzka";
                droga[3].numer = "768";
                droga[3].dlugosc = 27.4;
                droga[4] = new Droga();
                droga[4].kategoria = "Wojewódzka";
                droga[4].numer = "783";
                droga[4].dlugosc = 60.3;
                droga[5] = new Droga();
                droga[5].kategoria = "Wojewódzka";
                droga[5].numer = "964";
                droga[5].dlugosc = 104;
                droga[6] = new Droga();
                droga[6].kategoria = "Wojewódzka";
                droga[6].numer = "967";
                droga[6].dlugosc = 35;
                droga[7] = new Droga();
                droga[7].kategoria = "Wojewódzka";
                droga[7].numer = "975";
                droga[7].dlugosc = 77.5;
                droga[8] = new Droga();
                droga[8].kategoria = "Powiatowa";
                droga[8].numer = "1992K";
                droga[8].dlugosc = 3.0;
                droga[9] = new Droga();
                droga[9].kategoria = "Powiatowa";
                droga[9].numer = "2125K";
                droga[9].dlugosc = 7.5;
                droga[10] = new Droga();
                droga[10].kategoria = "Powiatowa";
                droga[10].numer = "2133K";
                droga[10].dlugosc = 4.6;
                droga[11] = new Droga();
                droga[11].kategoria = "Powiatowa";
                droga[11].numer = "2183K";
                droga[11].dlugosc = 4.6;
                droga[12] = new Droga();
                droga[12].kategoria = "Gminna";
                droga[12].numer = "340206S"; //slask
                droga[12].dlugosc = 0.631;
                droga[13] = new Droga();
                droga[13].kategoria = "Krajowa";
                droga[13].numer = "7";
                droga[13].dlugosc = 780;
                droga[14] = new Droga();
                droga[14].kategoria = "Krajowa";
                droga[14].numer = "28";
                droga[14].dlugosc = 350;
                droga[15] = new Droga();
                droga[15].kategoria = "Krajowa";
                droga[15].numer = "44";
                droga[15].dlugosc = 108;
                droga[16] = new Droga();
                droga[16].kategoria = "Krajowa";
                droga[16].numer = "47";
                droga[16].dlugosc = 40;
                droga[17] = new Droga();
                droga[17].kategoria = "Krajowa";
                droga[17].numer = "49";
                droga[17].dlugosc = 24;
                droga[18] = new Droga();
                droga[18].kategoria = "Krajowa";
                droga[18].numer = "52";
                droga[18].dlugosc = 74;
                droga[19] = new Droga();
                droga[19].kategoria = "Krajowa";
                droga[19].numer = "75";
                droga[19].dlugosc = 133;
                droga[20] = new Droga();
                droga[20].kategoria = "Krajowa";
                droga[20].numer = "79";
                droga[20].dlugosc = 450;
                droga[21] = new Droga();
                droga[21].kategoria = "Krajowa";
                droga[21].numer = "87";
                droga[21].dlugosc = 28;
                droga[22] = new Droga();
                droga[22].kategoria = "Krajowa";
                droga[22].numer = "E77";
                droga[22].dlugosc = 720;
                foreach (var item in droga)
                {
                    DrogaRepo.Add(item);
                }

                Utrudnienie[] utrudnienie = new Utrudnienie[33];
                utrudnienie[0] = new Utrudnienie();
                utrudnienie[0].droga = droga[2];
                utrudnienie[0].przydzielony_uzytkownik = pracownik_malopolski;
                utrudnienie[0].dlugosc_geograficzna = "50.10194600226033";
                utrudnienie[0].szerokosc_geograficzna = "19.83354091644287";
                utrudnienie[0].nazwa = "Remont drogi";
                utrudnienie[0].opis = "Zawężenie pasa awaryjnego na długości 27 m. (670,640 km drogi)";
                utrudnienie[0].stan_drogi = "Remont";
                utrudnienie[0].odcinek = "Rząska";
                utrudnienie[0].wojewodztwo = "Małopolskie";
                utrudnienie[0].powiat = "krakowski";
                utrudnienie[0].gmina = "Zabierzów";
                utrudnienie[0].miasto = "Rząska";
                utrudnienie[0].data_powstania = new DateTime(2011,09,13);
                utrudnienie[0].data_likwidacji = new DateTime(2011,10,31);
                utrudnienie[0].zatwierdzony = true;
                utrudnienie[0].predkosc = 90;
                utrudnienie[1] = new Utrudnienie();
                utrudnienie[1].droga = droga[2];
                utrudnienie[1].przydzielony_uzytkownik = moderator;
                utrudnienie[1].dlugosc_geograficzna = "50.097491";
                utrudnienie[1].szerokosc_geograficzna = "19.824107";
                utrudnienie[1].nazwa = "Remont drogi";
                utrudnienie[1].opis = "Zawężenie pasa awaryjnego na długości 7 m (671,510 km drogi).";
                utrudnienie[1].stan_drogi = "Remont";
                utrudnienie[1].odcinek = "Rząska";
                utrudnienie[1].wojewodztwo = "Małopolskie";
                utrudnienie[1].powiat = "krakowski";
                utrudnienie[1].gmina = "Zabierzów";
                utrudnienie[1].miasto = "Rząska";
                utrudnienie[1].data_powstania = new DateTime(2011, 09, 14);
                utrudnienie[1].data_likwidacji = new DateTime(2011, 10, 31);
                utrudnienie[1].zatwierdzony = true;
                utrudnienie[1].predkosc = 90;
                utrudnienie[2] = new Utrudnienie();
                utrudnienie[2].droga = droga[1];
                utrudnienie[2].przydzielony_uzytkownik = moderator;
                utrudnienie[2].dlugosc_geograficzna = "50.097491";
                utrudnienie[2].szerokosc_geograficzna = "19.824107";
                utrudnienie[2].nazwa = "Prace przy zabezpieczaniu osuwiska";
                utrudnienie[2].opis = "Prace przy zabezpieczaniu osuwiska na obszarze 100 m, wyłączone pobocze bitumiczne na kierunku do Tarnowa (468,820 km drogi).";
                utrudnienie[2].stan_drogi = "Remont";
                utrudnienie[2].odcinek = "Bochnia";
                utrudnienie[2].wojewodztwo = "Małopolskie";
                utrudnienie[2].powiat = "bocheński";
                utrudnienie[2].gmina = "Bochnia";
                utrudnienie[2].miasto = "Bochnia";
                utrudnienie[2].ulica = "Księdza Władysława Kuca";
                utrudnienie[2].data_powstania = new DateTime(2011, 07, 11);
                utrudnienie[2].data_likwidacji = new DateTime(2011, 10, 29);
                utrudnienie[2].zatwierdzony = true;
                utrudnienie[2].predkosc = 70;
                utrudnienie[3] = new Utrudnienie();
                utrudnienie[3].droga = droga[1];
                utrudnienie[3].przydzielony_uzytkownik = moderator;
                utrudnienie[3].dlugosc_geograficzna = "49.958803340247236";
                utrudnienie[3].szerokosc_geograficzna = "20.43352961540222";
                utrudnienie[3].nazwa = "Zamknięty pas ruchu dla kierunku na Tarnów";
                utrudnienie[3].opis = "Obsunięta część korony drogi, zamknięty pas ruchu (długość 650 m) dla kierunku na Tarnów, ruch w kierunku na Tarnów odbywa się pasem wyprzedzania (469,800 km drogi).";
                utrudnienie[3].stan_drogi = "Uszkodzona droga, zamknięty pas ruchu";
                utrudnienie[3].odcinek = "Bochnia";
                utrudnienie[3].wojewodztwo = "Małopolskie";
                utrudnienie[3].powiat = "nocheński";
                utrudnienie[3].gmina = "Bochnia";
                utrudnienie[3].miasto = "Bochnia";
                utrudnienie[3].data_powstania = new DateTime(2010, 05, 20);
                utrudnienie[3].data_likwidacji = new DateTime(2011, 12, 31);
                utrudnienie[3].zatwierdzony = true;
                utrudnienie[3].predkosc = 70;
                utrudnienie[4] = new Utrudnienie();
                utrudnienie[4].droga = droga[13];
                utrudnienie[4].przydzielony_uzytkownik = admin;
                utrudnienie[4].dlugosc_geograficzna = "49.945963405374656";
                utrudnienie[4].szerokosc_geograficzna = "19.89122986793518";
                utrudnienie[4].nazwa = "Zamknięty pas awaryjny";
                utrudnienie[4].opis = "Umocnienie skarpy. Zamknięty pas awaryjny o długości 130 m (678,700 km drogi).";
                utrudnienie[4].stan_drogi = "Zamknięty pas awaryjny";
                utrudnienie[4].odcinek = "Mogilany";
                utrudnienie[4].wojewodztwo = "Małopolskie";
                utrudnienie[4].powiat = "krakowski";
                utrudnienie[4].gmina = "Mogilany";
                utrudnienie[4].miasto = "Mogilany";
                utrudnienie[4].data_powstania = new DateTime(2011, 09, 19);
                utrudnienie[4].data_likwidacji = new DateTime(2011, 10, 31);
                utrudnienie[4].zatwierdzony = true;
                utrudnienie[4].predkosc = 50;
                utrudnienie[5] = new Utrudnienie();
                utrudnienie[5].droga = droga[13];
                utrudnienie[5].przydzielony_uzytkownik = moderator;
                utrudnienie[5].dlugosc_geograficzna = "49.94738563125844";
                utrudnienie[5].szerokosc_geograficzna = "19.890929460525513";
                utrudnienie[5].nazwa = "Zamknięty pas awaryjny";
                utrudnienie[5].opis = "Na jezdni w kierunku Krakowa zamkniety pas awaryjny o długości 400 m (678,800 km drogi).";
                utrudnienie[5].stan_drogi = "Zamknięty pas awaryjny";
                utrudnienie[5].odcinek = "Mogilany";
                utrudnienie[5].wojewodztwo = "Małopolskie";
                utrudnienie[5].powiat = "krakowski";
                utrudnienie[5].gmina = "Mogilany";
                utrudnienie[5].miasto = "Mogilany";
                utrudnienie[5].data_powstania = new DateTime(2011, 08, 04);
                utrudnienie[5].data_likwidacji = new DateTime(2011, 12, 31);
                utrudnienie[5].zatwierdzony = true;
                utrudnienie[6] = new Utrudnienie();
                utrudnienie[6].droga = droga[13];
                utrudnienie[6].przydzielony_uzytkownik = admin;
                utrudnienie[6].dlugosc_geograficzna = "49.935107";
                utrudnienie[6].szerokosc_geograficzna = "19.887322";
                utrudnienie[6].nazwa = "Zamknięta prawa jezdnia";
                utrudnienie[6].opis = "Zamknięta prawa jezdnia ruch dla obu kierunków odbywa się po jezdni lewej na długości 1680 m (679,600 km drogi).";
                utrudnienie[6].stan_drogi = "Zamknięty pas awaryjny";
                utrudnienie[6].odcinek = "węzeł Mogilany";
                utrudnienie[6].wojewodztwo = "Małopolskie";
                utrudnienie[6].powiat = "krakowski";
                utrudnienie[6].gmina = "Mogilany";
                utrudnienie[6].miasto = "Mogilany";
                utrudnienie[6].ulica = "Zakopiańska";
                utrudnienie[6].data_powstania = new DateTime(2011, 03, 01);
                utrudnienie[6].data_likwidacji = new DateTime(2011, 12, 31);
                utrudnienie[6].zatwierdzony = true;
                utrudnienie[6].predkosc = 50;
                utrudnienie[7] = new Utrudnienie();
                utrudnienie[7].droga = droga[5];
                utrudnienie[7].przydzielony_uzytkownik = pracownik_malopolski2;
                utrudnienie[7].dlugosc_geograficzna = "50.11983033925829";
                utrudnienie[7].szerokosc_geograficzna = "20.85501730442047";
                utrudnienie[7].nazwa = "Remont drogi wojewódzkiej";
                utrudnienie[7].opis = "Zdeformowana nawierzchnia z licznymi ubytkami. Zakaz wyprzedania na drodze oraz obustronne zwężenie jezdni.";
                utrudnienie[7].stan_drogi = "Remont drogi";
                utrudnienie[7].odcinek = "Zabawa - Biskupice Radłowskie";
                utrudnienie[7].wojewodztwo = "Małopolskie";
                utrudnienie[7].powiat = "tarnowski";
                utrudnienie[7].gmina = "Radłów";
                utrudnienie[7].miasto = "Biskupice Radłowskie";
                utrudnienie[7].data_powstania = new DateTime(2012, 01, 03);
                utrudnienie[7].data_likwidacji = new DateTime(2012, 05, 31);
                utrudnienie[7].zatwierdzony = true;
                utrudnienie[7].predkosc = 50;
                utrudnienie[8] = new Utrudnienie();
                utrudnienie[8].droga = droga[7];
                utrudnienie[8].przydzielony_uzytkownik = pracownik_malopolski;
                utrudnienie[8].dlugosc_geograficzna = "49.82910520656716";
                utrudnienie[8].szerokosc_geograficzna = "20.807998180389404";
                utrudnienie[8].nazwa = "Zawężenie drogi";
                utrudnienie[8].opis = "Zawężenie drogi z powodu osuwania się mas ziemnych podnoszących nawierzchnię. Zakaz wyprzedania na drodze.";
                utrudnienie[8].stan_drogi = "Remont drogi, ruch wahadłowy";
                utrudnienie[8].odcinek = "Zaklinczyn - Paleśnica";
                utrudnienie[8].wojewodztwo = "Małopolskie";
                utrudnienie[8].powiat = "tarnowski";
                utrudnienie[8].gmina = "Zaklinczyn";
                utrudnienie[8].miasto = "Zdonia";
                utrudnienie[8].data_powstania = new DateTime(2012, 02, 16);
                utrudnienie[8].data_likwidacji = new DateTime(2012, 12, 31);
                utrudnienie[8].zatwierdzony = true;
                utrudnienie[8].predkosc = 40;
                utrudnienie[9] = new Utrudnienie();
                utrudnienie[9].droga = droga[6];
                utrudnienie[9].przydzielony_uzytkownik = pracownik_malopolski;
                utrudnienie[9].dlugosc_geograficzna = "49.84350603495523";
                utrudnienie[9].szerokosc_geograficzna = "19.96439516544342";
                utrudnienie[9].nazwa = "Remont drogi wojewódzkiej";
                utrudnienie[9].opis = "Zakaz wyprzedania na drodze oraz prawostronne zawęzenie jezdni na długości 50 m.";
                utrudnienie[9].stan_drogi = "Remont drogi, ruch wahadłowy";
                utrudnienie[9].odcinek = "Borzęta";
                utrudnienie[9].wojewodztwo = "Małopolskie";
                utrudnienie[9].powiat = "myślenicki";
                utrudnienie[9].gmina = "Myślenice";
                utrudnienie[9].miasto = "Borzęta";
                utrudnienie[9].ulica = "Juliusza Słowackiego";
                utrudnienie[9].data_powstania = new DateTime(2009, 10, 09);
                utrudnienie[9].data_likwidacji = new DateTime(2012, 06, 30);
                utrudnienie[9].zatwierdzony = true;
                utrudnienie[9].predkosc = 40;
                utrudnienie[10] = new Utrudnienie();
                utrudnienie[10].droga = droga[14];
                utrudnienie[10].przydzielony_uzytkownik = moderator;
                utrudnienie[10].dlugosc_geograficzna = "49.777333";
                utrudnienie[10].szerokosc_geograficzna = "19.590618";
                utrudnienie[10].nazwa = "Zmiany w ruchu";
                utrudnienie[10].opis = "Ruch odbywa się wahadłowo sterowany sygnalizacją świetlną (32,200 km drogi)";
                utrudnienie[10].stan_drogi = "Ruch wahadłowy, sterowany sygnalizacją świetlną";
                utrudnienie[10].odcinek = "Zembrzyce";
                utrudnienie[10].wojewodztwo = "Małopolskie";
                utrudnienie[10].powiat = "suski";
                utrudnienie[10].gmina = "Zembrzyce";
                utrudnienie[10].miasto = "Zembrzyce";
                utrudnienie[10].data_powstania = new DateTime(2011, 08, 02);
                utrudnienie[10].data_likwidacji = new DateTime(2011, 11, 30);
                utrudnienie[10].zatwierdzony = true;
                utrudnienie[11] = new Utrudnienie();
                utrudnienie[11].droga = droga[14];
                utrudnienie[11].przydzielony_uzytkownik = moderator;
                utrudnienie[11].dlugosc_geograficzna = "49.62328178472389";
                utrudnienie[11].szerokosc_geograficzna = "19.953500032424927";
                utrudnienie[11].nazwa = "Remont drogi";
                utrudnienie[11].opis = "Zawężenie pasa ruchu na długości 500 m (68,300 km drogi)";
                utrudnienie[11].stan_drogi = "Remont drogi";
                utrudnienie[11].odcinek = "Rabka-Zdrój";
                utrudnienie[11].wojewodztwo = "Małopolskie";
                utrudnienie[11].powiat = "nowatarski";
                utrudnienie[11].gmina = "Rabka-Zdrój";
                utrudnienie[11].miasto = "Rabka-Zdrój";
                utrudnienie[11].data_powstania = new DateTime(2011, 09, 14);
                utrudnienie[11].data_likwidacji = new DateTime(2011, 11, 30);
                utrudnienie[11].zatwierdzony = true;
                utrudnienie[12] = new Utrudnienie();
                utrudnienie[12].droga = droga[14];
                utrudnienie[12].przydzielony_uzytkownik = admin;
                utrudnienie[12].dlugosc_geograficzna = "49.65867350366509";
                utrudnienie[12].szerokosc_geograficzna = "20.058835744857788";
                utrudnienie[12].nazwa = "Zmiany w ruchu";
                utrudnienie[12].opis = "Ruch prowadzony w obydwu kierunkach po moście objazdowym (77,900 km drogi)";
                utrudnienie[12].stan_drogi = "Ruch po moście objazdowym";
                utrudnienie[12].odcinek = "Mszana Dolna";
                utrudnienie[12].wojewodztwo = "Małopolskie";
                utrudnienie[12].powiat = "limanowski";
                utrudnienie[12].gmina = "Mszana Dolna";
                utrudnienie[12].miasto = "Mszana Dolna";
                utrudnienie[12].data_powstania = new DateTime(2011, 09, 08);
                utrudnienie[12].data_likwidacji = new DateTime(2012, 08, 31);
                utrudnienie[12].zatwierdzony = true;
                utrudnienie[12].predkosc = 50;
                utrudnienie[13] = new Utrudnienie();
                utrudnienie[13].droga = droga[14];
                utrudnienie[13].przydzielony_uzytkownik = admin;
                utrudnienie[13].dlugosc_geograficzna = "49.708290";
                utrudnienie[13].szerokosc_geograficzna = "20.247705";
                utrudnienie[13].nazwa = "Zmiany w ruchu";
                utrudnienie[13].opis = "Ruch odbywa się wahadłowo sterowany sygnalizacją świetlną na 100 m (95,760 km drogi)";
                utrudnienie[13].stan_drogi = "Ruch wahadłowy, sterowany sygnalizacją świetlną";
                utrudnienie[13].odcinek = "Dobra";
                utrudnienie[13].wojewodztwo = "Małopolskie";
                utrudnienie[13].powiat = "limanowski";
                utrudnienie[13].gmina = "Dobra";
                utrudnienie[13].miasto = "Dobra";
                utrudnienie[13].data_powstania = new DateTime(2011, 05, 10);
                utrudnienie[13].data_likwidacji = new DateTime(2011, 10, 20);
                utrudnienie[13].zatwierdzony = true;
                utrudnienie[13].predkosc = 40;
                utrudnienie[14] = new Utrudnienie();
                utrudnienie[14].droga = droga[12];
                utrudnienie[14].przydzielony_uzytkownik = pracownik_malopolski3;
                utrudnienie[14].dlugosc_geograficzna = "49.708890";
                utrudnienie[14].szerokosc_geograficzna = "20.247805";
                utrudnienie[14].nazwa = "Zmiany w ruchu";
                utrudnienie[14].opis = "Brak danych";
                utrudnienie[14].stan_drogi = "Brak danych";
                utrudnienie[14].odcinek = "Brak danych";
                utrudnienie[14].wojewodztwo = "Małopolskie";
                utrudnienie[14].data_powstania = new DateTime(2011, 05, 10);
                utrudnienie[14].data_likwidacji = new DateTime(2020, 10, 20);
                utrudnienie[14].zatwierdzony = false;
                utrudnienie[14].predkosc = 40;
                utrudnienie[14].skrajnia_pionowa = 12;
                utrudnienie[15] = new Utrudnienie();
                utrudnienie[15].droga = droga[14];
                utrudnienie[15].przydzielony_uzytkownik = pracownik_malopolski2;
                utrudnienie[15].dlugosc_geograficzna = "49.722162";
                utrudnienie[15].szerokosc_geograficzna = "20.335445";
                utrudnienie[15].nazwa = "Zmiany w ruchu";
                utrudnienie[15].opis = "Ruch odbywa się wahadłowo sterowany sygnalizacją świetlną na 100 m (103,100 km drogi)";
                utrudnienie[15].stan_drogi = "Ruch wahadłowy, sterowany sygnalizacją świetlną";
                utrudnienie[15].odcinek = "Zamieście";
                utrudnienie[15].wojewodztwo = "Małopolskie";
                utrudnienie[15].powiat = "limanowski";
                utrudnienie[15].gmina = "Tymbark";
                utrudnienie[15].miasto = "Zamieście";
                utrudnienie[15].data_powstania = new DateTime(2011, 08, 23);
                utrudnienie[15].data_likwidacji = new DateTime(2011, 11, 30);
                utrudnienie[15].zatwierdzony = true;
                utrudnienie[15].predkosc = 40;
                utrudnienie[16] = new Utrudnienie();
                utrudnienie[16].droga = droga[14];
                utrudnienie[16].przydzielony_uzytkownik = pracownik_malopolski2;
                utrudnienie[16].dlugosc_geograficzna = "49.721021";
                utrudnienie[16].szerokosc_geograficzna = "20.356979";
                utrudnienie[16].nazwa = "Remont drogi";
                utrudnienie[16].opis = "Objazd dwukierunkowy po obiekcie tymczasowym (104,750 km drogi)";
                utrudnienie[16].stan_drogi = "Remont drogi";
                utrudnienie[16].odcinek = "Zamieście";
                utrudnienie[16].wojewodztwo = "Małopolskie";
                utrudnienie[16].powiat = "limanowski";
                utrudnienie[16].gmina = "Tymbark";
                utrudnienie[16].miasto = "Zamieście";
                utrudnienie[16].data_powstania = new DateTime(2011, 04, 15);
                utrudnienie[16].data_likwidacji = new DateTime(2011, 10, 20);
                utrudnienie[16].zatwierdzony = true;
                utrudnienie[16].predkosc = 40;
                utrudnienie[17] = new Utrudnienie();
                utrudnienie[17].droga = droga[14];
                utrudnienie[17].przydzielony_uzytkownik = pracownik_malopolski;
                utrudnienie[17].dlugosc_geograficzna = "49.632123";
                utrudnienie[17].szerokosc_geograficzna = "20.660185";
                utrudnienie[17].nazwa = "Zmiany w ruchu";
                utrudnienie[17].opis = "Ruch odbywa się wahadłowo po obiekcie tymczasowym, sterowany sygnalizacją świetlną. (104,750 km drogi)";
                utrudnienie[17].stan_drogi = "Ruch wahadłowy, sterowany sygnalizacją świetlną";
                utrudnienie[17].odcinek = "Chełmiec";
                utrudnienie[17].wojewodztwo = "Małopolskie";
                utrudnienie[17].powiat = "nowosądecki";
                utrudnienie[17].gmina = "Chełmiec";
                utrudnienie[17].miasto = "Chełmiec";
                utrudnienie[17].data_powstania = new DateTime(2011, 07, 11);
                utrudnienie[17].data_likwidacji = new DateTime(2011, 10, 31);
                utrudnienie[17].zatwierdzony = true;
                utrudnienie[17].predkosc = 40;
                utrudnienie[18] = new Utrudnienie();
                utrudnienie[18].droga = droga[15];
                utrudnienie[18].przydzielony_uzytkownik = pracownik_malopolski;
                utrudnienie[18].dlugosc_geograficzna = "49.973987";
                utrudnienie[18].szerokosc_geograficzna = "19.814966";
                utrudnienie[18].nazwa = "Zmiany w ruchu";
                utrudnienie[18].opis = "Chwilowe zajęcia 110 m pasa drogowego (103,080 km drogi)";
                utrudnienie[18].stan_drogi = "Zajęty prawy pas";
                utrudnienie[18].odcinek = "Chełmiec";
                utrudnienie[18].wojewodztwo = "Małopolskie";
                utrudnienie[18].powiat = "krakowski";
                utrudnienie[18].gmina = "Skawnia";
                utrudnienie[18].miasto = "Skawnia";
                utrudnienie[18].data_powstania = new DateTime(2011, 10, 01);
                utrudnienie[18].data_likwidacji = new DateTime(2011, 11, 30);
                utrudnienie[18].zatwierdzony = true;
                utrudnienie[19] = new Utrudnienie();
                utrudnienie[19].droga = droga[16];
                utrudnienie[19].przydzielony_uzytkownik = pracownik_malopolski;
                utrudnienie[19].dlugosc_geograficzna = "49.595383";
                utrudnienie[19].szerokosc_geograficzna = "19.930550";
                utrudnienie[19].nazwa = "Zmiany w ruchu";
                utrudnienie[19].opis = "Zawężenie jezdni do jednego pasa ruchu na długość 430 m na kierunku do Krakowa (1,250 km drogi)";
                utrudnienie[19].stan_drogi = "Remont drogi";
                utrudnienie[19].odcinek = "Chabówka";
                utrudnienie[19].wojewodztwo = "Małopolskie";
                utrudnienie[19].powiat = "nowotarski";
                utrudnienie[19].gmina = "Rabka-Zdrój";
                utrudnienie[19].miasto = "Chabówka";
                utrudnienie[19].data_powstania = new DateTime(2011, 08, 10);
                utrudnienie[19].data_likwidacji = new DateTime(2011, 11, 30);
                utrudnienie[19].zatwierdzony = true;
                utrudnienie[19].predkosc = 50;
                utrudnienie[20] = new Utrudnienie();
                utrudnienie[20].droga = droga[16];
                utrudnienie[20].przydzielony_uzytkownik = pracownik_malopolski;
                utrudnienie[20].dlugosc_geograficzna = "49.344640";
                utrudnienie[20].szerokosc_geograficzna = "20.003025";
                utrudnienie[20].nazwa = "Remont mostów i zamknięta droga";
                utrudnienie[20].opis = "Remont dwóch obiektów mostowych. Droga zamknięta na długości 1750 m. (33 km drogi)";
                utrudnienie[20].stan_drogi = "Remont mostów, droga zamknięta";
                utrudnienie[20].objazd = "Ruch puszczony na objazd przez Biały Dunajec i Poronin ul. Piłsuskiego J. i drogą wojewódzką 961.";
                utrudnienie[20].odcinek = "Biały Dunajec - Poronin";
                utrudnienie[20].wojewodztwo = "Małopolskie";
                utrudnienie[20].powiat = "tatrzański";
                utrudnienie[20].gmina = "Poronin";
                utrudnienie[20].miasto = "Poronin";
                utrudnienie[20].data_powstania = new DateTime(2011, 09, 05);
                utrudnienie[20].data_likwidacji = new DateTime(2011, 11, 15);
                utrudnienie[20].zatwierdzony = true;
                utrudnienie[21] = new Utrudnienie();
                utrudnienie[21].droga = droga[17];
                utrudnienie[21].przydzielony_uzytkownik = pracownik_malopolski2;
                utrudnienie[21].dlugosc_geograficzna = "49.434283";
                utrudnienie[21].szerokosc_geograficzna = "20.085109";
                utrudnienie[21].nazwa = "Wyłączenie prawej strony jezdni";
                utrudnienie[21].opis = "Ruch wahadłowy sterowany sygnalizacją świetlną, wyłączona prawa strona jezdni na długości 500 m. (7,300 km drogi)";
                utrudnienie[21].stan_drogi = "Ruch wahadłowy";
                utrudnienie[21].odcinek = "Gronków";
                utrudnienie[21].wojewodztwo = "Małopolskie";
                utrudnienie[21].powiat = "nowotarski";
                utrudnienie[21].gmina = "Nowy Targ";
                utrudnienie[21].miasto = "Gronków";
                utrudnienie[21].data_powstania = new DateTime(2011, 07, 28);
                utrudnienie[21].data_likwidacji = new DateTime(2011, 11, 30);
                utrudnienie[21].zatwierdzony = true;
                utrudnienie[21].predkosc = 40;
                utrudnienie[22] = new Utrudnienie();
                utrudnienie[22].droga = droga[18];
                utrudnienie[22].przydzielony_uzytkownik = moderator;
                utrudnienie[22].dlugosc_geograficzna = "49.866064";
                utrudnienie[22].szerokosc_geograficzna = "19.228157";
                utrudnienie[22].nazwa = "Zmiany w ruchu";
                utrudnienie[22].opis = "Ruch wahadłowy aa długości 480 m. (21,800 km drogi)";
                utrudnienie[22].stan_drogi = "Ruch wahadłowy";
                utrudnienie[22].odcinek = "Kęty";
                utrudnienie[22].wojewodztwo = "Małopolskie";
                utrudnienie[22].powiat = "oświęcimski";
                utrudnienie[22].gmina = "Kęty";
                utrudnienie[22].miasto = "Kęty";
                utrudnienie[22].data_powstania = new DateTime(2011, 08, 30);
                utrudnienie[22].data_likwidacji = new DateTime(2011, 10, 31);
                utrudnienie[22].zatwierdzony = true;
                utrudnienie[23] = new Utrudnienie();
                utrudnienie[23].droga = droga[18];
                utrudnienie[23].przydzielony_uzytkownik = admin;
                utrudnienie[23].dlugosc_geograficzna = "49.880059";
                utrudnienie[23].szerokosc_geograficzna = "19.464277";
                utrudnienie[23].nazwa = "Budowa mostu objazdowego";
                utrudnienie[23].opis = "Budowa mostu objazdowego (42,500 km drogi)";
                utrudnienie[23].stan_drogi = "Budowa mostu";
                utrudnienie[23].odcinek = "Chocznia";
                utrudnienie[23].wojewodztwo = "Małopolskie";
                utrudnienie[23].powiat = "wadowicki";
                utrudnienie[23].gmina = "Wadowice";
                utrudnienie[23].miasto = "Chocznia";
                utrudnienie[23].data_powstania = new DateTime(2011, 09, 20);
                utrudnienie[23].data_likwidacji = new DateTime(2011, 12, 15);
                utrudnienie[23].zatwierdzony = true;
                utrudnienie[24] = new Utrudnienie();
                utrudnienie[24].droga = droga[19];
                utrudnienie[24].przydzielony_uzytkownik = admin;
                utrudnienie[24].dlugosc_geograficzna = "49.805985";
                utrudnienie[24].szerokosc_geograficzna = "20.666566";
                utrudnienie[24].nazwa = "Wyłączonenie prawego pasa ruchu ";
                utrudnienie[24].opis = "Wyłączony prawy pas ruchu na odcinku 200m (39,800 km drogi)";
                utrudnienie[24].stan_drogi = "Ruch wahadłowy, sterowany sygnalizacją świetlną";
                utrudnienie[24].odcinek = "Będzieszyna";
                utrudnienie[24].wojewodztwo = "Małopolskie";
                utrudnienie[24].powiat = "brzeski";
                utrudnienie[24].gmina = "Czchów";
                utrudnienie[24].miasto = "Będzieszyna";
                utrudnienie[24].data_powstania = new DateTime(2011, 08, 12);
                utrudnienie[24].data_likwidacji = new DateTime(2011, 10, 31);
                utrudnienie[24].zatwierdzony = true;
                utrudnienie[24].predkosc = 40;
                utrudnienie[25] = new Utrudnienie();
                utrudnienie[25].droga = droga[19];
                utrudnienie[25].przydzielony_uzytkownik = pracownik_malopolski;
                utrudnienie[25].dlugosc_geograficzna = "49.514876";
                utrudnienie[25].szerokosc_geograficzna = "20.877520";
                utrudnienie[25].nazwa = "Uszkodzona droga";
                utrudnienie[25].opis = "W wyniku wystąpienia obfitych opadów i wysokiego stanu rzeki doszło do obrywu skarpy korpusu drogowego wraz z poboczem i fragmentem jezdni. Miejsce zostało wygrodzone na długości 40 m i wprowadzono ruch wahadłowy (84,350 km drogi)";
                utrudnienie[25].stan_drogi = "Remont drogi, ruch wahadłowy";
                utrudnienie[25].odcinek = "Łabowa";
                utrudnienie[25].wojewodztwo = "Małopolskie";
                utrudnienie[25].powiat = "nowosądecki";
                utrudnienie[25].gmina = "Łabowa";
                utrudnienie[25].miasto = "Łabowa";
                utrudnienie[25].data_powstania = new DateTime(2010, 05, 20);
                utrudnienie[25].data_likwidacji = new DateTime(2011, 11, 30);
                utrudnienie[25].zatwierdzony = true;
                utrudnienie[26] = new Utrudnienie();
                utrudnienie[26].droga = droga[20];
                utrudnienie[26].przydzielony_uzytkownik = moderator;
                utrudnienie[26].dlugosc_geograficzna = "50.117097";
                utrudnienie[26].szerokosc_geograficzna = "19.714540";
                utrudnienie[26].nazwa = "Naprawa drogi";
                utrudnienie[26].opis = "Naprawy gwarancyjne. Zawężenie jezdni na długości 9550 m lokalnie ruch wahadłowy (356,300 km drogi)";
                utrudnienie[26].stan_drogi = "Remont drogi, ruch wahadłowy";
                utrudnienie[26].odcinek = "Zabierzów";
                utrudnienie[26].wojewodztwo = "Małopolskie";
                utrudnienie[26].powiat = "krakowski";
                utrudnienie[26].gmina = "Zabierzów";
                utrudnienie[26].miasto = "Zabierzów";
                utrudnienie[26].data_powstania = new DateTime(2011, 09, 19);
                utrudnienie[26].data_likwidacji = new DateTime(2011, 10, 31);
                utrudnienie[26].zatwierdzony = true;
                utrudnienie[26].predkosc = 50;
                utrudnienie[27] = new Utrudnienie();
                utrudnienie[27].droga = droga[20];
                utrudnienie[27].przydzielony_uzytkownik = moderator;
                utrudnienie[27].dlugosc_geograficzna = "50.127011";
                utrudnienie[27].szerokosc_geograficzna = "19.651943";
                utrudnienie[27].nazwa = "Zmiana w ruchu i remont poboczy";
                utrudnienie[27].opis = "Ruch odbywa się po nowym obiekcie. Trwają prace na poboczach i poza jezdnią (365,600 km drogi)";
                utrudnienie[27].stan_drogi = "Remont poboczy";
                utrudnienie[27].odcinek = "Krzeszowice";
                utrudnienie[27].wojewodztwo = "Małopolskie";
                utrudnienie[27].powiat = "krakowski";
                utrudnienie[27].gmina = "Krzeszowice";
                utrudnienie[27].miasto = "Krzeszowice";
                utrudnienie[27].data_powstania = new DateTime(2009, 05, 11);
                utrudnienie[27].data_likwidacji = new DateTime(2011, 10, 31);
                utrudnienie[27].zatwierdzony = true;
                utrudnienie[27].predkosc = 40;
                utrudnienie[27].skrajnia_pozioma = 8;
                utrudnienie[27].skrajnia_pionowa = 10;
                utrudnienie[28] = new Utrudnienie();
                utrudnienie[28].droga = droga[20];
                utrudnienie[28].przydzielony_uzytkownik = moderator;
                utrudnienie[28].dlugosc_geograficzna = "50.150794";
                utrudnienie[28].szerokosc_geograficzna = "19.440252";
                utrudnienie[28].nazwa = "Zmiana w ruchu";
                utrudnienie[28].opis = "Ruch wahadłowy kierowany ręcznie na odcinku 600 m (381,560 km drogi)";
                utrudnienie[28].stan_drogi = "Ruch wahadłowy";
                utrudnienie[28].odcinek = "Trzebinia";
                utrudnienie[28].wojewodztwo = "Małopolskie";
                utrudnienie[28].powiat = "chrzanowski";
                utrudnienie[28].gmina = "Trzebinia";
                utrudnienie[28].miasto = "Trzebinia";
                utrudnienie[28].data_powstania = new DateTime(2011, 08, 29);
                utrudnienie[28].data_likwidacji = new DateTime(2011, 10, 30);
                utrudnienie[28].zatwierdzony = true;
                utrudnienie[29] = new Utrudnienie();
                utrudnienie[29].droga = droga[21];
                utrudnienie[29].przydzielony_uzytkownik = pracownik_malopolski3;
                utrudnienie[29].dlugosc_geograficzna = "49.922040";
                utrudnienie[29].szerokosc_geograficzna = "19.918848";
                utrudnienie[29].nazwa = "Uszkodzenie drogi spowodowane obfitymi opadami";
                utrudnienie[29].opis = "W wyniku wystąpienia obfitych opadów atmosferycznych nastąpiło oberwanie się skarp korpusu drogowego w kilku miejscach. Obsunięte miejsca wygorodzono barierami i wprowadzono ruch wahadłowy (27,300 km drogi)";
                utrudnienie[29].stan_drogi = "Remont drogi, ruch wahadłowy";
                utrudnienie[29].odcinek = "Piwniczna Zdrój";
                utrudnienie[29].wojewodztwo = "Małopolskie";
                utrudnienie[29].powiat = "nowosądecki";
                utrudnienie[29].gmina = "Piwniczna Zdrój";
                utrudnienie[29].miasto = "Piwniczna Zdrój";
                utrudnienie[29].data_powstania = new DateTime(2010, 05, 20);
                utrudnienie[29].data_likwidacji = new DateTime(2012, 05, 31);
                utrudnienie[29].zatwierdzony = true;
                utrudnienie[29].nosnosc = 8;
                utrudnienie[30] = new Utrudnienie();
                utrudnienie[30].droga = droga[10];
                utrudnienie[30].przydzielony_uzytkownik = admin;
                utrudnienie[30].dlugosc_geograficzna = "49.422040";
                utrudnienie[30].szerokosc_geograficzna = "20.718848";
                utrudnienie[30].nazwa = "Remont drogi";
                utrudnienie[30].opis = "Remont drogi";
                utrudnienie[30].stan_drogi = "Remont drogi, ruch wahadłowy";
                utrudnienie[30].odcinek = "Piwniczna Zdrój";
                utrudnienie[30].wojewodztwo = "Małopolskie";
                utrudnienie[30].powiat = "nowosądecki";
                utrudnienie[30].gmina = "Piwniczna Zdrój";
                utrudnienie[30].miasto = "Piwniczna Zdrój";
                utrudnienie[30].data_powstania = new DateTime(2009, 03, 20);
                utrudnienie[30].data_likwidacji = new DateTime(2011, 05, 22);
                utrudnienie[30].zatwierdzony = true;
                utrudnienie[31] = new Utrudnienie();
                utrudnienie[31].droga = droga[22];
                utrudnienie[31].przydzielony_uzytkownik = pracownik_malopolski3;
                utrudnienie[31].dlugosc_geograficzna = "50.001182561316845";
                utrudnienie[31].szerokosc_geograficzna = "19.741251468658447";
                utrudnienie[31].nazwa = "Brak danych";
                utrudnienie[31].opis = "Brak danych";
                utrudnienie[31].stan_drogi = "Brak danych";
                utrudnienie[31].odcinek = "Piwniczna Zdrój";
                utrudnienie[31].wojewodztwo = "Małopolskie";
                utrudnienie[31].data_powstania = new DateTime(2009, 03, 20);
                utrudnienie[31].data_likwidacji = new DateTime(2011, 05, 22);
                utrudnienie[31].zatwierdzony = false;
                utrudnienie[31].nacisk = 15;
                utrudnienie[31].szerokosc = 20;
                utrudnienie[32] = new Utrudnienie();
                utrudnienie[32].droga = droga[22];
                utrudnienie[32].przydzielony_uzytkownik = moderator;
                utrudnienie[32].dlugosc_geograficzna = "50.08810209393551";
                utrudnienie[32].szerokosc_geograficzna = "19.89622950553894";
                utrudnienie[32].nazwa = "Test - Remont drogi";
                utrudnienie[32].opis = "Test - Remont drogi";
                utrudnienie[32].stan_drogi = "Test - Remont drogi";
                utrudnienie[32].odcinek = "Kraków";
                utrudnienie[32].wojewodztwo = "Małopolskie";
                utrudnienie[32].powiat = "krakowski";
                utrudnienie[32].gmina = "Kraków";
                utrudnienie[32].miasto = "Kraków";
                utrudnienie[32].ulica = "Josepha Conrada";
                utrudnienie[32].data_powstania = new DateTime(2011, 09, 19);
                utrudnienie[32].data_likwidacji = new DateTime(2011, 10, 01);
                utrudnienie[32].zatwierdzony = true;
                utrudnienie[32].predkosc = 50;
                foreach (var item in utrudnienie)
                {
                    UtrudnienieRepo.Add(item);
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

            //Tworzenie schemy do domyślnego katalogu
            //C:\Program Files (x86)\Common Files\Microsoft Shared\DevServer\10.0\
            //SchemaExport.SetOutputFile(@"db.sql");
            
            //Tworzenie schemy do wybranego katalogu (potrzebne do IIS 7)
            SchemaExport.SetOutputFile(@"C:\\schema.sql");

            if (przykladowe_dane == true)
            {
                SchemaExport.Execute(true, true, false);
            }
            /*else
            {
                //DROP DATABASE
                SchemaExport.Execute(false, false, true);
            }*/
            //build our database schema automatically
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
            ISession session = CurrentSessionContext.Unbind(SessionFactory);
            if (session == null) return;
            try
            {
                session.Transaction.Commit();
            }
            catch (Exception)
            {
                session.Transaction.Rollback();
            }
            finally
            {
                session.Close();
                session.Dispose();
            }
            //CurrentSessionContext.Unbind(SessionFactory).Close();
            //CurrentSessionContext.Unbind(SessionFactory).Dispose();
        }
    }
}