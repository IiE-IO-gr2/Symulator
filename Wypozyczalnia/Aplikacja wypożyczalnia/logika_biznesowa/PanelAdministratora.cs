using System;
using System.Data;
namespace logika_biznesowa {
	public class PanelAdministratora {
		/// <summary>
		/// login admina, aby zalogowa� si� do systemu
		/// </summary>
		public string Login;
		/// <summary>
		/// has�o admina, aby zalogowa� si� do systemu
		/// </summary>
		private string haslo;

        /// <summary>
        /// metoda zalogowania si� do systemu
        /// </summary>
        public static bool ZalogujSie(string l, string h, ref string exmsg)
        {
            if (string.IsNullOrWhiteSpace(h))
                return false;
            string zapytanie = "Select haslo from [dbo].[Panel_administratora] where Login='" + l + "'";
            DataTable dt = FunkcjePomicnicze.PobierzDaneSQL(zapytanie, ref exmsg);
            if (!string.IsNullOrWhiteSpace(exmsg))
                return false;
            string hasloZBazy = "";
            foreach (DataRow item in dt.Rows)
            {
                hasloZBazy = item[0].ToString();
            }
            if (h == hasloZBazy)
                return true;
            else
                return false;
        }

        private Klient klient;
		private Rezerwacja rezerwacja;
		private Samoch�d samoch�d;
		private Rozliczenie rozliczenie;

	}

}
