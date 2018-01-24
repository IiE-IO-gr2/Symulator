using System;
using System.Data;
using System.Globalization;
namespace logika_biznesowa {
	public class Samoch�d {
		/// <summary>
		/// numer id samochodu
		/// </summary>
		public int Id_samochodu;
		/// <summary>
		/// marka samochodu
		/// </summary>
		public string Marka;
		/// <summary>
		/// model samochodu
		/// </summary>
		public string Model;
		/// <summary>
		/// pojemno�� silnika samochodu
		/// </summary>
		public double Pojemnosc;
		/// <summary>
		/// rodzaj paliwa w samochodzie
		/// </summary>
		public string Rodzaj_paliwa;
		/// <summary>
		/// typ nadwozia samochodu
		/// </summary>
		public string Typ_nadwozia;
		/// <summary>
		/// ilo�� koni mechanicznych w samochodzie
		/// </summary>
		public int Ilosc_koni;
		/// <summary>
		/// skrzynia bieg�w w samochodzie (manualna/automatyczna)
		/// </summary>
		public string Skrzynia_biegow;
		/// <summary>
		/// ilo�� bieg�w w samochodzie
		/// </summary>
		public int Ilosc_bieg�w;
		/// <summary>
		/// zu�ycie paliwa samochodu na 100km
		/// </summary>
		public double Zu�ycie_paliwa;
		/// <summary>
		/// ilo�� miejsc w samochodzie
		/// </summary>
		public int Ilosc_miejsc;
		/// <summary>
		/// ilo�� drzwi w samochodzie
		/// </summary>
		public int Ilosc_drzwi;
		/// <summary>
		/// rok produkcji samochodu
		/// </summary>
		public int Rocznik;
		/// <summary>
		/// kolor samochodu
		/// </summary>
		public string Kolor;
		/// <summary>
		/// cena za dob� wypo�yczenia samochodu
		/// </summary>
		public double Cena_za_dob�;
		/// <summary>
		/// czy samoch�d jest dost�pny w wypo�yczalni
		/// </summary>
		public bool Dostepnosc;
		/// <summary>
		/// inne uwagi
		/// </summary>
		public string Inne;
		/// <summary>
		/// kaucja zwrotna za samoch�d p�atna przy wypo�yczeniu pod warunkiem, �e nie dokonano �adnych uszkodze�
		/// </summary>
		public int Kaucja;

		/// <summary>
		/// metoda dodaj�ca samoch�d do bazy
		/// </summary>
        public Samoch�d()
        {
            Id_samochodu = 0;
            Marka = "";
            Model = "";
            Pojemnosc = 0.0;
            Rodzaj_paliwa = "";
            Typ_nadwozia = "";
            Ilosc_koni = 0;
            Skrzynia_biegow = "";
            Ilosc_bieg�w = 0;
            Zu�ycie_paliwa = 0.0;
            Ilosc_miejsc = 0;
            Ilosc_drzwi = 0;
            Rocznik = 0;
            Kolor = "";
            Cena_za_dob� = 0.0;
            Dostepnosc = false;
            Inne = "";
            Kaucja = 0;
        }

        /// <summary>
        /// konstruktor Samoch�d
        /// </summary>
        public Samoch�d(int id, string mar, string mod, double poj, string rp, string tn, int ik, string sk, int ib, double zp, int im, int ilodr, int roc, string kol, double czd, bool dostep, string inne, int ka)
        {
            Id_samochodu = id;
            Marka = mar;
            Model = mod;
            Pojemnosc = poj;
            Rodzaj_paliwa = rp;
            Typ_nadwozia = tn;
            Ilosc_koni = ik;
            Skrzynia_biegow = sk;
            Ilosc_bieg�w = ib;
            Zu�ycie_paliwa = zp;
            Ilosc_miejsc = im;
            Ilosc_drzwi = ilodr;
            Rocznik = roc;
            Kolor = kol;
            Cena_za_dob� = czd;
            Dostepnosc = dostep;
            Inne = inne;
            Kaucja = ka;
        }

        /// <summary>
        /// metoda dodania samochodu do bazy
        /// </summary>
        public string DodajSamochod()
        {
            string exmsg = "";
            int dostbool = 0;
            if (Dostepnosc == true)
                dostbool = 1;
            string poj = Pojemnosc.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string zuz = Zu�ycie_paliwa.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string czd = Cena_za_dob�.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string zapytanie = @"insert into [dbo].[Samoch�d] ([Id_samochodu], [Marka], [Model], [Pojemnosc], [Rodzaj_paliwa], [Typ_nadwozia], [Ilosc_koni], [Skrzynia_biegow], [Ilosc_bieg�w], [Zu�ycie_paliwa], [Ilosc_miejsc], [Ilosc_drzwi], [Rocznik], [Kolor], [Cena_za_dob�], [Dostepnosc], [Inne], [Kaucja], [CzyUsuniete] )" +
                @"values (" + Id_samochodu + ", '" + Marka + "' , '" + Model + "', " + Pojemnosc + ", '" + Rodzaj_paliwa + "', '" + Typ_nadwozia + "', " + Ilosc_koni + ", '" + Skrzynia_biegow + "', " + Ilosc_bieg�w + ", " + zuz + ", " + Ilosc_miejsc + ", " + Ilosc_drzwi + ", " + Rocznik + ", '" + Kolor + "', " + czd + ", " + dostbool + ", '" + Inne + "', " + Kaucja + ", 0)";
            FunkcjePomicnicze.WstawDaneSQL(zapytanie, ref exmsg);
            return exmsg;
        }
		
		/// <summary>
		/// metoda edytuj�ca samoch�d w bazie
		/// </summary>
		public static string EdytujSamochod(int identyfikator)
        {
            //throw new System.Exception("Not implemented");
            string zapytanieCzySamochodIstnieje = @"SELECT count(*) FROM [dbo].[Samoch�d] WHERE [Id_samochodu] = " + identyfikator;
            string exmsgTest = "";
            string zwrotZapytanieCzySamochodIstnieje = FunkcjePomicnicze.PobierzDaneSQLPojedyncze(zapytanieCzySamochodIstnieje, ref exmsgTest);
            if (!string.IsNullOrWhiteSpace(exmsgTest)) // zapytanie testuj�ce, czy w bazie jest samoch�d o danym ID zwr�ci�o b��d
                return exmsgTest;
            else
            {
                int licznik;
                if (int.TryParse(zwrotZapytanieCzySamochodIstnieje, out licznik) == true) // uzyskan� warto�� da si� przekonwetowa� na inta
                {
                    if (licznik == 1) // zapytanie zwr�ci�o znalezienie w bazie samochod�w rekordu o podanym ID
                    {
                        string exmsg = "", exmsg1 = "", exmsg2 = "";
                        // edycja danych z tabeli Samochody
                        string zapytanie2 = @"UPDATE [dbo].[Samoch�d] SET ([Id_samochodu], [Marka], [Model], [Pojemnosc], [Rodzaj_paliwa], [Typ_nadwozia], [Ilosc_koni], [Skrzynia_biegow], [Ilosc_bieg�w], [Zu�ycie_paliwa], [Ilosc_miejsc], [Ilosc_drzwi], [Rocznik], [Kolor], [Cena_za_dob�], [Dostepnosc], [Inne], [Kaucja], [CzyUsuniete]) WHERE [Id_klienta] = " + identyfikator;
                        FunkcjePomicnicze.WstawDaneSQL(zapytanie2, ref exmsg1);
                        // budowa informacji wyj�ciowej z funkcji
                        if (!string.IsNullOrWhiteSpace(exmsg1))
                            exmsg += "\n" + exmsg1;
                        if (!string.IsNullOrWhiteSpace(exmsg2))
                            exmsg += "\n" + exmsg2;
                        return exmsg;
                    }
                    else
                        return "Nie odnaleziono samochodu o podanym ID";
                }
                else
                    return "Nie odnaleziono samochodu o podanym ID";
            }
        }
		/// <summary>
		/// metoda usuwaj�ca samoch�d z bazy
		/// </summary>
        public static string UsunSamochod(int identyfikator)
        {
            string zapytanieCzySamochodIstnieje = @"SELECT count(*) FROM [dbo].[Samoch�d] WHERE [Id_samochodu] = " + identyfikator;
            string exmsgTest = "";
            string zwrotZapytanieCzySamochodIstnieje = FunkcjePomicnicze.PobierzDaneSQLPojedyncze(zapytanieCzySamochodIstnieje, ref exmsgTest);
            if (!string.IsNullOrWhiteSpace(exmsgTest)) // zapytanie testuj�ce, czy w bazie jest samoch�d o danym ID zwr�ci�o b��d
                return exmsgTest;
            else // zapytanie nie zwr�ci�o b��du
            {
                int licznik;
                if (int.TryParse(zwrotZapytanieCzySamochodIstnieje, out licznik) == true) // uzyskan� warto�� da si� przekonwetowa� na inta
                {
                    if (licznik == 1) // zapytanie zwr�ci�o znalezienie w bazie samochod�w rekordu o podanym ID
                    {
                        string exmsg = "", exmsg1 = "", exmsg2 = "";
                        // usuni�cie danych z tabeli Samochody
                        string zapytanie1 = @"UPDATE [dbo].[Samoch�d] SET [CzyUsuniete] = 1 WHERE [Id_klienta] = " + identyfikator;
                        FunkcjePomicnicze.WstawDaneSQL(zapytanie1, ref exmsg1);
                        // budowa informacji wyj�ciowej z funkcji
                        if (!string.IsNullOrWhiteSpace(exmsg1))
                            exmsg += "\n" + exmsg1;
                        if (!string.IsNullOrWhiteSpace(exmsg2))
                            exmsg += "\n" + exmsg2;
                        return exmsg;
                    }
                    else
                        return "Nie odnaleziono samochodu o podanym ID";
                }
                else
                    return "Nie odnaleziono samochodu o podanym ID";
            }
		}
        /// <summary>
        /// metoda wyszukuj�ca samoch�d w bazie
        /// </summary>
        public static string WyszukajSamochod(int identyfikator)
        {
            //throw new System.Exception("Not implemented");
            string zapytanieCzySamochodIstnieje = @"SELECT count(*) FROM [dbo].[Samoch�d] WHERE [Id_samochodu] = " + identyfikator;
            string exmsgTest = "";
            string zwrotZapytanieCzySamochodIstnieje = FunkcjePomicnicze.PobierzDaneSQLPojedyncze(zapytanieCzySamochodIstnieje, ref exmsgTest);
            if (!string.IsNullOrWhiteSpace(exmsgTest)) // zapytanie testuj�ce, czy w bazie jest samoch�d o danym ID zwr�ci�o b��d
                return exmsgTest;
            else // zapytanie nie zwr�ci�o b��du
            {
                int licznik;
                if (int.TryParse(zwrotZapytanieCzySamochodIstnieje, out licznik) == true) // uzyskan� warto�� da si� przekonwetowa� na inta
                {
                    if (licznik == 1) // zapytanie zwr�ci�o znalezienie w bazie samochod�w rekordu o podanym ID
                    {
                        string exmsg = "", exmsg1 = "", exmsg2 = "";
                        // usuni�cie danych z tabeli Samochody
                        string zapytanie3 = @"SELECT count(*) FROM [dbo].[Samoch�d] WHERE [Id_samochodu] = " + identyfikator;
                        FunkcjePomicnicze.WstawDaneSQL(zapytanie3, ref exmsg1);
                        // budowa informacji wyj�ciowej z funkcji
                        if (!string.IsNullOrWhiteSpace(exmsg1))
                            exmsg += "\n" + exmsg1;
                        if (!string.IsNullOrWhiteSpace(exmsg2))
                            exmsg += "\n" + exmsg2;
                        return exmsg;
                    }
                    else
                        return "Nie odnaleziono samochodu o podanym ID";
                }
                else
                    return "Nie odnaleziono samochodu o podanym ID";
            }
        }
		/// <summary>
		/// metoda sprawdzaj�ca czy samoch�d jest dost�pny w bazie
		/// </summary>
		public bool CzyDostepny() {
			throw new System.Exception("Not implemented");
		}

		private Panel_administratora panel_administratora;

		private Rezerwacja rezerwacja;

        /// <summary>
        /// Metoda pobieraj�ca z bazy danych najwy�szy dotychczas uzyty numer ID
        /// </summary>
        /// <returns></returns>
        public static int MaksymalnyNumerIdentyfikatoraWBazie()
        {
            string zapytanie = @"select max([Id_samochodu]) from [dbo].[Samoch�d]";
            string exmsg = "";
            string numerZBazy = FunkcjePomicnicze.PobierzDaneSQLPojedyncze(zapytanie, ref exmsg);
            if (!string.IsNullOrWhiteSpace(numerZBazy))
                return int.Parse(numerZBazy);
            else
                return 0;
        }
	}

}
