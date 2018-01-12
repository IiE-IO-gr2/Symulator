using System;
using System.Data;
using System.Globalization;

namespace logika_biznesowa {
    public class Klient {
        /// <summary>
        /// numer id klienta
        /// </summary>
        public int Id_klienta;
        /// <summary>
        /// telefon kontaktowy do klienta
        /// </summary>
        public string Telefon_kontaktowy;
        /// <summary>
        /// adres zamieszkania klienta
        /// </summary>
        public string Adres;
        /// <summary>
        /// adres e-mail klienta
        /// </summary>
        public string Adres_email;
        /// <summary>
        /// promocja uzale�niona od ilo�ci wypo�ycze� klienta
        /// </summary>
        public double Promocja;
        /// <summary>
        /// ile razy klient wypo�yczy� samoch�d, nast�pnie od tego liczona jest promocja
        /// </summary>
        public int Aktywnosc;
        /// <summary>
        /// w�asno�� wskazuj�ca, czy dany klient zosta� oznaczony w bazie jako usuni�ty
        /// </summary>
        public bool CzyUsuniete;

        /// <summary>
        /// konstruktor bezparametrowy Klient
        /// </summary>
        public Klient()
        {
            Id_klienta = 0;
            Telefon_kontaktowy = "000000000";
            Adres = "";
            Adres_email = "";
            Promocja = 0.0;
            Aktywnosc = 0;
        }

        /// <summary>
        /// konstruktor Klient
        /// </summary>
        public Klient(int id, string tl, string ad, string em, double pr, int ak)
        {
            Id_klienta = id;
            Telefon_kontaktowy = tl;
            Adres = ad;
            Adres_email = em;
            Promocja = pr;
            Aktywnosc = ak;
        }

        /// <summary>
        /// metoda dodania klienta do bazy
        /// </summary>
        public string DodanieKlienta()
        {
            string exmsg = "";
            string promo = Promocja.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string zapytanie = @"insert into [dbo].[Klient] ([Id_klienta], [Telefon_kontaktowy], [Adres], [Adres_email], [Promocja], [Aktywnosc], [CzyUsuniete])" +
                @"values (" + Id_klienta + ", '" + Telefon_kontaktowy + "' , '" + Adres + "', '" + Adres_email + "', " + promo + ", " + Aktywnosc + ",0)";
            FunkcjeSQL.WstawDaneSQL(zapytanie, ref exmsg);
            return exmsg;
        }

        /// <summary>
        /// metoda usuni�cia klienta z bazy
        /// </summary>
        /// <param name="identyfikator">numer identyfikacyjny klienta, kt�ry ma zosta� usuni�ty z bazy</param>
        /// <returns></returns>
        public static string UsunKlienta(int identyfikator)
        {
            string zapytanieCzyKlientIstnieje = @"SELECT count(*) FROM [dbo].[Klient] WHERE [Id_klienta] = " + identyfikator;
            string exmsgTest = "";
            string zwrotZapytanieCzyKlientIstnieje = FunkcjeSQL.PobierzDaneSQLPojedyncze(zapytanieCzyKlientIstnieje, ref exmsgTest);
            if (!string.IsNullOrWhiteSpace(exmsgTest)) // zapytanie testuj�ce, czy w bazie jest klient o danym ID zwr�ci�o b��d
                return exmsgTest;
            else // zapytanie nie zwr�ci�o b��du
            {
                int licznik;
                if (int.TryParse(zwrotZapytanieCzyKlientIstnieje, out licznik) == true) // uzyskan� warto�� da si� przekonwetowa� na inta
                {
                    if (licznik == 1) // zapytanie zwr�ci�o znalezienie w bazie klient�w rekordu o podanym ID
                    {
                        string exmsg = "", exmsg1 = "", exmsg2 = "";
                        // usuni�cie danych z tabeli Klienci
                        string zapytanie1 = @"UPDATE [dbo].[Klient] SET [CzyUsuniete] = 1 WHERE [Id_klienta] = " + identyfikator;
                        FunkcjeSQL.WstawDaneSQL(zapytanie1, ref exmsg1);
                        // sprawdzenie, czy klient by� klientem indywidualnym, czy firm�
                        string zapytanieTestoweCzyKlientFirma = @"SELECT count(*) FROM [dbo].[Klient_KlientFirma] WHERE [Id_klienta_K] = " + identyfikator;
                        string liczbaRekordow = FunkcjeSQL.PobierzDaneSQLPojedyncze(zapytanieTestoweCzyKlientFirma, ref exmsg);
                        // budowa zapytania aktualizuj�cego klienta_indywidualnego lub klienta_firm�
                        string zapytanie2 = "";
                        if (liczbaRekordow == "0") // czyli nie jest to klient-firma
                            zapytanie2 = @"UPDATE [dbo].[Klient_indywidualny] ";
                        else
                            zapytanie2 = @"UPDATE [dbo].[Klient_firmy] ";
                        zapytanie2 += @"SET[CzyUsuniete] = 1 WHERE[Id_klienta] = " + identyfikator;
                        // update klienta-indywidualnego lub klienta-firmy
                        FunkcjeSQL.WstawDaneSQL(zapytanie2, ref exmsg2);
                        // budowa informacji wyj�ciowej z funkcji
                        if (!string.IsNullOrWhiteSpace(exmsg1))
                            exmsg += "\n" + exmsg1;
                        if (!string.IsNullOrWhiteSpace(exmsg2))
                            exmsg += "\n" + exmsg2;
                        return exmsg;
                    }
                    else
                        return "Nie odnaleziono klienta o podanym ID";
                }
                else
                    return "Nie odnaleziono klienta o podanym ID";
            }

            
		}
		/// <summary>
		/// metoda wyszukania klienta w bazie
		/// </summary>
		public void WyszukajKlienta() {
			throw new System.Exception("Not implemented");
		}
		/// <summary>
		/// metoda edytowania klienta w bazie
		/// </summary>
		public void EdytujKlienta() {
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
            string zapytanie = @"select max([Id_klienta]) from [dbo].[Klient]";
            string exmsg = "";
            DataTable dt = FunkcjeSQL.PobierzDaneSQL(zapytanie, ref exmsg);
            string numerZBazy = "";
            foreach (DataRow item in dt.Rows)
            {
                numerZBazy = item[0].ToString();
            }
            if (!string.IsNullOrWhiteSpace(numerZBazy))
            {
                return int.Parse(numerZBazy);
            }
            else
                return 0;
        }

    }

}
