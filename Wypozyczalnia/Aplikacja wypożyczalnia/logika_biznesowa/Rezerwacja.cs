using System;
namespace logika_biznesowa {
	public class Rezerwacja {
		/// <summary>
		/// numer id rezerwacji
		/// </summary>
		public int ID_rezerwacji;
		/// <summary>
		/// data, na jak� klient planuje wypo�yczy� samoch�d
		/// </summary>
		public DateTime Data_planowanego_wypozyczenia;
		/// <summary>
		/// data, kiedy klient planuje odda� samoch�d
		/// </summary>
		public DateTime Data_planowanego_zwrotu;

        public Rezerwacja()
        {
            ID_rezerwacji = 0;
            Data_planowanego_wypozyczenia = new DateTime(1,1,1);
            Data_planowanego_zwrotu = new DateTime(1, 1, 1);
        }

        /// <summary>
        /// konstruktor Rezerwacja
        /// </summary>
        public Rezerwacja(int id, DateTime dpw, DateTime dpz)
        {
            ID_rezerwacji = id;
            Data_planowanego_wypozyczenia = dpw;
            Data_planowanego_zwrotu = dpz;
        }
		/// <summary>
		/// metoda, kt�ra pokazuje rezerwacj�
		/// </summary>
		public void PokazRezerwacje() {
			throw new System.Exception("Not implemented");
		}
		/// <summary>
		/// metoda, kt�ra edytuje rezerwacj�
		/// </summary>
		public void EdytujRezerwacje() {
			throw new System.Exception("Not implemented");
		}
		/// <summary>
		/// metoda, kt�ra dodaje rezerwacj�
		/// </summary>
		public string DodajRezerwacje()
        {
            string exmsg = "";
            string zapytanie = @"insert into [dbo].[Rezerwacja] ([ID_rezerwacji], [Data_planowanego_wypozyczenia], [Data_planowanego_zwrotu])" +
                @"values (" + ID_rezerwacji + ", " + Data_planowanego_wypozyczenia + " , " + Data_planowanego_zwrotu + " )";
            FunkcjeSQL.WstawDaneSQL(zapytanie, ref exmsg);
            return exmsg;
        }
		/// <summary>
		/// metoda, kt�ra usuwa rezerwacj�
		/// </summary>
		public static string UsunRezerwacje(int identyfikator)
        {
            string zapytanieCzyRezerwacjaIstnieje = @"SELECT count(*) FROM [dbo].[Rezerwacja] WHERE [ID_rezerwacji] = " + identyfikator;
            string exmsgTest = "";
            string zwrotZapytanieCzyRezerwacjaIstnieje = FunkcjeSQL.PobierzDaneSQLPojedyncze(zapytanieCzyRezerwacjaIstnieje, ref exmsgTest);
            if (!string.IsNullOrWhiteSpace(exmsgTest)) // zapytanie testuj�ce, czy w bazie jest rezerwacja o danym ID zwr�ci�o b��d
                return exmsgTest;
            else // zapytanie nie zwr�ci�o b��du
            {
                int licznik;
                if (int.TryParse(zwrotZapytanieCzyRezerwacjaIstnieje, out licznik) == true) // uzyskan� warto�� da si� przekonwetowa� na inta
                {
                    if (licznik == 1) // zapytanie zwr�ci�o znalezienie w bazie rezerwacji rekordu o podanym ID
                    {
                        string exmsg = "", exmsg1 = "", exmsg2 = "";
                        // usuni�cie danych z tabeli Rezerwacja
                        string zapytanie1 = @"UPDATE [dbo].[Rezerwacja] SET [CzyUsuniete] = 1 WHERE [ID_rezerwacji] = " + identyfikator;
                        FunkcjeSQL.WstawDaneSQL(zapytanie1, ref exmsg1);
                        // budowa informacji wyj�ciowej z funkcji
                        if (!string.IsNullOrWhiteSpace(exmsg1))
                            exmsg += "\n" + exmsg1;
                        if (!string.IsNullOrWhiteSpace(exmsg2))
                            exmsg += "\n" + exmsg2;
                        return exmsg;
                    }
                    else
                        return "Nie odnaleziono rezerwacji o podanym ID";
                }
                else
                    return "Nie odnaleziono rezerwacji o podanym ID";
            }
		}
		/// <summary>
		/// metoda, kt�ra wyszukuje rezerwacj�
		/// </summary>
		public void WyszukajRezerwacje() {
			throw new System.Exception("Not implemented");
		}

		private Samoch�d samoch�d;
		private Klient klient;
		private Panel_administratora panel_administratora;

		private Wypo�yczenie wypo�yczenie;
		private Lista_rezerwacji lista_rezerwacji;

        public static int MaksymalnyNumerIdentyfikatoraWBazie()
        {
            string zapytanie = @"select max([ID_rezerwacji]) from [dbo].[Rezerwacja]";
            string exmsg = "";
            string numerZBazy = FunkcjeSQL.PobierzDaneSQLPojedyncze(zapytanie, ref exmsg);
            if (!string.IsNullOrWhiteSpace(numerZBazy))
                return int.Parse(numerZBazy);
            else
                return 0;
        }
	}

}
