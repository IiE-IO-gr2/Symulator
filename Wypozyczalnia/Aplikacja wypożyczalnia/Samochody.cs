﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacja_wypożyczalnia
{
    public partial class Samochody : Form
    {
        public Samochody()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Przycisk przekierowuje do opcji dodania samochodu do bazy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void DodajSamochód_Click(object sender, EventArgs e)
        {
            this.Hide();
            DodajSamochód ds = new DodajSamochód();
            ds.Show();
        }
        /// <summary>
        /// Przycisk przekierowuje do opcji edycji samochodu w bazie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void EdytujSamochód_Click(object sender, EventArgs e)
        {
            this.Hide();
            EdytujSamochód es = new EdytujSamochód();
            es.Show();
        }
        /// <summary>
        /// Przycisk przekierowuje do opcji usuwaniua samochodu z bazy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void UsuńSamochód_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsuńSamochód us = new UsuńSamochód();
            us.Show();
        }
        /// <summary>
        /// Przycisk przekierowuje do opcji wyszukania samochodu w bazie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WyszukajSamochód_Click(object sender, EventArgs e)
        {
            this.Hide();
            WyszukajSamochód ws = new WyszukajSamochód();
            ws.Show();
        }
        /// <summary>
        /// Przycisk przekierowuje do Menu główne po zalogowaniu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuGłówne_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu_po_zalogowaniu mn = new Menu_po_zalogowaniu();
            mn.Show();
        }

        /// <summary>
        /// Przycisk przekierowuje do listy samochodów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListaSamochodow_Click(object sender, EventArgs e)
        {
            this.Hide();
            PokazSamochody ws = new PokazSamochody();
            ws.Show();
        }
        /// <summary>
        /// Przycisk przekierowuje do opcji naprawy samochodu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SamochodNaprawa ws = new SamochodNaprawa();
            ws.Show();
        }

        private void Samochody_Load(object sender, EventArgs e)
        {

        }
    }
}
