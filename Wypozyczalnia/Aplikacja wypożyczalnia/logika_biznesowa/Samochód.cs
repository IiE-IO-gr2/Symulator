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
		/// czy samoch�d jest dost�pny w wypo�yczalni czy jest w naprawie
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
        public Samoch�d(int id, string mar, string mod, double poj, string rp, string tn, int ik, string sk, int ib, double zuz, int im, int ilodr, int roc, string kol, double czd, bool dostep, string inne, int ka)
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
            Zu�ycie_paliwa = zuz;
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
        /// <returns>
        /// Zwraca warto�ci samochodu
        /// </returns>
        public string DodajSamochod()
        {
            string exmsg = "";
            int dostbool = 0;
            if (Dostepnosc == true)
                dostbool = 1;
            string poj = Pojemnosc.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string zuz = Zu�ycie_paliwa.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string czd = Cena_za_dob�.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string zapytanie = @"insert into [dbo].[Samoch�d] ([Id_samochodu], [Marka], [Model], [Pojemnosc], " +
                @"[Rodzaj_paliwa], [Typ_nadwozia], [Ilosc_koni], [Skrzynia_biegow], [Ilosc_bieg�w], [Zu�ycie_paliwa], " + 
                @"[Ilosc_miejsc], [Ilosc_drzwi], [Rocznik], [Kolor], [Cena_za_dob�], [Dostepnosc], [Inne], [Kaucja], [CzyUsuniete] )" +
                @"values (" + Id_samochodu + ", '" + Marka + "' , '" + Model + "', " + poj + ", '" + Rodzaj_paliwa + "', '" + 
                Typ_nadwozia + "', " + Ilosc_koni + ", '" + Skrzynia_biegow + "', " + Ilosc_bieg�w + ", " + zuz + ", " + 
                Ilosc_miejsc + ", " + Ilosc_drzwi + ", " + Rocznik + ", '" + Kolor + "', " + czd + ", " + dostbool + ", '" + 
                Inne + "', " + Kaucja + ",0)";
            /// <summary>
            //wstawia warto�ci atrybut�w u�ytych w zapytaniu
            /// </summary>
            FunkcjePomicnicze.WstawDaneSQL(zapytanie, ref exmsg);
            return exmsg;
        }

        /// <summary>
        /// metoda edytuj�ca samoch�d w bazie
        /// </summary>
        /// <returns>
        /// Zwraca warto�ci samochodu do edycji, nast�pnie edytuje samoch�d
        /// </returns>
        public string EdytujSamochod()
        {
            string exmsg = "";
            string poj = Pojemnosc.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string zuz = Zu�ycie_paliwa.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string czd = Cena_za_dob�.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            int dostbool = 0;
            if (Dostepnosc == true)
                dostbool = 1;
            /// <summary>
            ///zapytanie, kt�re umo�liwia edycj� samochodu w opcji edycji
            /// </summary>
            string zapytanie = @"UPDATE [dbo].[Samoch�d] SET [Marka]='" + Marka + "', [Model]='" + Model + "', [Pojemnosc]=" +
                poj + ",[Rodzaj_paliwa]='" + Rodzaj_paliwa + "', [Typ_nadwozia]='" + Typ_nadwozia + "', [Ilosc_koni]=" + 
                Ilosc_koni + ",[Skrzynia_biegow]='" + Skrzynia_biegow + "', [Ilosc_bieg�w]=" + Ilosc_bieg�w + 
                ", [Zu�ycie_paliwa]=" + zuz + ",[Ilosc_miejsc]=" + Ilosc_miejsc + ", [Ilosc_drzwi]= " + Ilosc_drzwi + 
                ", [Rocznik]=" + Rocznik + ", [Kolor]='" + Kolor + "', [Cena_za_dob�]=" + czd + ", [Dostepnosc]=" + dostbool + 
                ", [Inne]='" + Inne + "', [Kaucja]=" + Kaucja + " WHERE [Id_samochodu] = " + Id_samochodu;
            /// <summary>
            ///wstawia warto�ci atrybut�w u�ytych w zapytaniu
            /// </summary>
            FunkcjePomicnicze.WstawDaneSQL(zapytanie, ref exmsg);
            return exmsg;
        }
        /// <summary>
        /// metoda usuwaj�ca samoch�d z bazy
        /// </summary>
        /// <returns>
        /// Zwraca warto�ci samochodu do usuni�cia, nast�pnie usuwa samoch�d
        /// </returns>
        public static string UsunSamochod(int identyfikator)
        {
            /// <summary>
            ///sprawdza czy samoch�d jest w bazie
            /// </summary>
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
                        /// <summary>
                        /// usuni�cie danych z tabeli Samochody
                        /// </summary>
                        string zapytanie1 = @"UPDATE [dbo].[Samoch�d] SET [CzyUsuniete] = 1 WHERE [Id_samochodu] = " + identyfikator;
                        /// <summary>
                        ///wstawia warto�ci atrybut�w u�ytych w zapytaniu
                        /// </summary>
                        FunkcjePomicnicze.WstawDaneSQL(zapytanie1, ref exmsg1);
                        /// <summary>
                        /// budowa informacji wyj�ciowej z funkcji
                        /// </summary>
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
        /// <returns>
        /// Zwraca warto�ci samochodu wyszukiwanego
        /// </returns>
        public static DataTable WyszukajSamochod(int identyfikator, ref string _exmsg)
        {
            DataTable dt = new DataTable();
            /// <summary>
            ///sprawdza czy samoch�d jest w bazie
            /// </summary>
            string zapytanieCzySamochodIstnieje = @"SELECT count(*) from [dbo].[Samoch�d] WHERE (([CzyUsuniete] = 0 or [CzyUsuniete] is null)" +
                @"and [Id_samochodu] = " + identyfikator + ")";
            string exmsgTest = "";
            string zwrotZapytanieCzySamochodIstnieje = FunkcjePomicnicze.PobierzDaneSQLPojedyncze(zapytanieCzySamochodIstnieje, ref exmsgTest);
            if (!string.IsNullOrWhiteSpace(exmsgTest)) // zapytanie testuj�ce, czy w bazie jest samoch�d o danym ID zwr�ci�o b��d
            {
                _exmsg = exmsgTest;
                return dt;
            }
            else // zapytanie nie zwr�ci�o b��du
            {
                if (zwrotZapytanieCzySamochodIstnieje != "0") // zapytanie zwr�ci�o znalezienie w bazie samoch�d rekordu o podanym ID
                {
                    string exmsg = "";
                    string zapytanie = "";
                    /// <summary>
                    ///pokazuje wszystkie warto�ci atrybut�w szukanego samochodu
                    /// </summary>
                    zapytanie = @"SELECT * from[dbo].[Samoch�d] WHERE [Id_samochodu] = " + identyfikator;
                    /// <summary>
                    /// pobranie danych z bazy
                    /// </summary>
                    string exmsg1 = "";
                    /// <summary>
                    ///wstawia warto�ci atrybut�w u�ytych w zapytaniu do tabeli
                    /// </summary>
                    dt = FunkcjePomicnicze.PobierzDaneSQL(zapytanie, ref exmsg1);
                    if (!string.IsNullOrWhiteSpace(exmsg))
                        _exmsg += "\n" + exmsg;
                    if (!string.IsNullOrWhiteSpace(exmsg1))
                        _exmsg += "\n" + exmsg1;
                    return dt;
                }
                else
                {
                    _exmsg = "Nie odnaleziono samochodu o podanym ID";
                    return dt;
                }
            }
        }
        /// <summary>
        ///metoda pokazuj�ca list� samochod�w
        /// </summary>
        /// <returns>
        /// Zwraca warto�ci wszytkich samochod�w w li�cie
        /// </returns>
        public static DataTable PokazSamochody(ref string _exmsg)
        {
            DataTable dt = new DataTable();

            string zapytanie = @"Select * from [dbo].[Samoch�d]  ";
            //Pobieranie danych z bazy
            string exmsg = "";
            dt = FunkcjePomicnicze.PobierzDaneSQL(zapytanie, ref exmsg);
            return dt;
        }
        /// <summary>
        /// metoda sprawdzaj�ca czy samoch�d jest dost�pny w bazie
        /// </summary>
        /*public bool CzyDostepny() {
			throw new System.Exception("Not implemented");
		}*/

        private PanelAdministratora panel_administratora;

		private Rezerwacja rezerwacja;

        /// <summary>
        /// Metoda pobieraj�ca z bazy danych najwy�szy dotychczas uzyty numer ID
        /// </summary>
        /// <returns>
        /// zwraca kolejny numer ID
        /// </returns>
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
