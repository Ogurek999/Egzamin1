using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Desktopowa
{
    public class Form1 : Form
    {
        private TextBox txtImie;
        private ComboBox cmbRodzaj;
        private NumericUpDown numMiesiace;
        private CheckBox chkSauna;
        private CheckBox chkTrener;
        private Button btnOblicz;
        private Button btnWyczysc;
        private Label lblWynik;
        private Label lblPodsumowanie;

        public Form1()
        {
            UstawOkno();
            DodajNaglowek();
            DodajPola();
            DodajPrzyciski();
            DodajWynik();
            UstawWartosciPoczatkowe();
        }

        private void UstawOkno()
        {
            Text = "CLUB+ | Kalkulator karnetu | TEST_01";
            ClientSize = new Size(620, 660);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.FromArgb(243, 247, 250);
            Font = new Font("Segoe UI", 10F);
        }

        private void DodajNaglowek()
        {
            Panel naglowek = new Panel();
            naglowek.Location = new Point(0, 0);
            naglowek.Size = new Size(620, 85);
            naglowek.BackColor = Color.FromArgb(24, 49, 75);

            Label tytul = new Label();
            tytul.Text = "CLUB+";
            tytul.ForeColor = Color.White;
            tytul.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            tytul.AutoSize = true;
            tytul.Location = new Point(25, 10);
            naglowek.Controls.Add(tytul);

            Label podtytul = new Label();
            podtytul.Text = "Kalkulator karnetu  |  TEST_01";
            podtytul.ForeColor = Color.FromArgb(210, 225, 235);
            podtytul.Font = new Font("Segoe UI", 10F);
            podtytul.AutoSize = true;
            podtytul.Location = new Point(28, 55);
            naglowek.Controls.Add(podtytul);

            Controls.Add(naglowek);
        }

        private void DodajPola()
        {
            Label tytulSekcji = new Label();
            tytulSekcji.Text = "Oblicz cenę karnetu";
            tytulSekcji.ForeColor = Color.FromArgb(24, 49, 75);
            tytulSekcji.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            tytulSekcji.AutoSize = true;
            tytulSekcji.Location = new Point(30, 105);
            Controls.Add(tytulSekcji);

            Label etykietaImie = new Label();
            etykietaImie.Text = "Imię i nazwisko";
            etykietaImie.ForeColor = Color.FromArgb(24, 49, 75);
            etykietaImie.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            etykietaImie.AutoSize = true;
            etykietaImie.Location = new Point(30, 148);
            Controls.Add(etykietaImie);

            txtImie = new TextBox();
            txtImie.Name = "txtImie";
            txtImie.Location = new Point(30, 172);
            txtImie.Size = new Size(540, 30);
            txtImie.Font = new Font("Segoe UI", 11F);
            txtImie.TabIndex = 0;
            Controls.Add(txtImie);

            Label etykietaRodzaj = new Label();
            etykietaRodzaj.Text = "Rodzaj karnetu";
            etykietaRodzaj.ForeColor = Color.FromArgb(24, 49, 75);
            etykietaRodzaj.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            etykietaRodzaj.AutoSize = true;
            etykietaRodzaj.Location = new Point(30, 220);
            Controls.Add(etykietaRodzaj);

            cmbRodzaj = new ComboBox();
            cmbRodzaj.Name = "cmbRodzaj";
            cmbRodzaj.Location = new Point(30, 244);
            cmbRodzaj.Size = new Size(260, 30);
            cmbRodzaj.Font = new Font("Segoe UI", 11F);
            cmbRodzaj.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRodzaj.Items.Add("Standard");
            cmbRodzaj.Items.Add("Student");
            cmbRodzaj.Items.Add("Premium");
            cmbRodzaj.TabIndex = 1;
            Controls.Add(cmbRodzaj);

            Label etykietaMiesiace = new Label();
            etykietaMiesiace.Text = "Liczba miesięcy";
            etykietaMiesiace.ForeColor = Color.FromArgb(24, 49, 75);
            etykietaMiesiace.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            etykietaMiesiace.AutoSize = true;
            etykietaMiesiace.Location = new Point(330, 220);
            Controls.Add(etykietaMiesiace);

            numMiesiace = new NumericUpDown();
            numMiesiace.Name = "numMiesiace";
            numMiesiace.Location = new Point(330, 244);
            numMiesiace.Size = new Size(120, 30);
            numMiesiace.Font = new Font("Segoe UI", 11F);
            numMiesiace.Minimum = 0;
            numMiesiace.Maximum = 99;
            numMiesiace.Value = 1;
            numMiesiace.TabIndex = 2;
            Controls.Add(numMiesiace);

            Label etykietaDodatki = new Label();
            etykietaDodatki.Text = "Dodatkowe usługi";
            etykietaDodatki.ForeColor = Color.FromArgb(24, 49, 75);
            etykietaDodatki.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            etykietaDodatki.AutoSize = true;
            etykietaDodatki.Location = new Point(30, 292);
            Controls.Add(etykietaDodatki);

            chkSauna = new CheckBox();
            chkSauna.Name = "chkSauna";
            chkSauna.Text = "Sauna (+25 zł / mies.)";
            chkSauna.ForeColor = Color.FromArgb(35, 45, 55);
            chkSauna.Font = new Font("Segoe UI", 10.5F);
            chkSauna.AutoSize = true;
            chkSauna.Location = new Point(30, 318);
            chkSauna.TabIndex = 3;
            Controls.Add(chkSauna);

            chkTrener = new CheckBox();
            chkTrener.Name = "chkTrener";
            chkTrener.Text = "Trener personalny (+40 zł)";
            chkTrener.ForeColor = Color.FromArgb(35, 45, 55);
            chkTrener.Font = new Font("Segoe UI", 10.5F);
            chkTrener.AutoSize = true;
            chkTrener.Location = new Point(30, 350);
            chkTrener.TabIndex = 4;
            Controls.Add(chkTrener);
        }

        private void DodajPrzyciski()
        {
            btnOblicz = new Button();
            btnOblicz.Name = "btnOblicz";
            btnOblicz.Text = "Oblicz";
            btnOblicz.Location = new Point(30, 397);
            btnOblicz.Size = new Size(160, 48);
            btnOblicz.BackColor = Color.FromArgb(15, 120, 145);
            btnOblicz.ForeColor = Color.White;
            btnOblicz.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOblicz.FlatStyle = FlatStyle.Flat;
            btnOblicz.FlatAppearance.BorderSize = 0;
            btnOblicz.Cursor = Cursors.Hand;
            btnOblicz.TabIndex = 5;
            btnOblicz.Click += new EventHandler(btnOblicz_Click);
            Controls.Add(btnOblicz);

            btnWyczysc = new Button();
            btnWyczysc.Name = "btnWyczysc";
            btnWyczysc.Text = "Wyczyść";
            btnWyczysc.Location = new Point(205, 397);
            btnWyczysc.Size = new Size(160, 48);
            btnWyczysc.BackColor = Color.White;
            btnWyczysc.ForeColor = Color.FromArgb(24, 49, 75);
            btnWyczysc.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnWyczysc.FlatStyle = FlatStyle.Flat;
            btnWyczysc.FlatAppearance.BorderColor = Color.FromArgb(24, 49, 75);
            btnWyczysc.FlatAppearance.BorderSize = 1;
            btnWyczysc.Cursor = Cursors.Hand;
            btnWyczysc.TabIndex = 6;
            btnWyczysc.Click += new EventHandler(btnWyczysc_Click);
            Controls.Add(btnWyczysc);
        }

        private void DodajWynik()
        {
            Panel panelWyniku = new Panel();
            panelWyniku.Location = new Point(30, 465);
            panelWyniku.Size = new Size(540, 160);
            panelWyniku.BackColor = Color.White;
            panelWyniku.BorderStyle = BorderStyle.FixedSingle;

            lblWynik = new Label();
            lblWynik.Name = "lblWynik";
            lblWynik.Location = new Point(15, 18);
            lblWynik.Size = new Size(505, 70);
            lblWynik.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblWynik.ForeColor = Color.FromArgb(24, 49, 75);
            lblWynik.TextAlign = ContentAlignment.MiddleLeft;
            lblWynik.Text = "Uzupełnij dane i wybierz Oblicz.";
            panelWyniku.Controls.Add(lblWynik);

            lblPodsumowanie = new Label();
            lblPodsumowanie.Name = "lblPodsumowanie";
            lblPodsumowanie.Location = new Point(15, 98);
            lblPodsumowanie.Size = new Size(505, 40);
            lblPodsumowanie.Font = new Font("Segoe UI", 10F);
            lblPodsumowanie.ForeColor = Color.FromArgb(85, 100, 115);
            lblPodsumowanie.TextAlign = ContentAlignment.MiddleLeft;
            lblPodsumowanie.Text = "";
            panelWyniku.Controls.Add(lblPodsumowanie);

            Controls.Add(panelWyniku);
        }

        private void UstawWartosciPoczatkowe()
        {
            txtImie.Text = "";
            cmbRodzaj.SelectedIndex = 0;
            numMiesiace.Value = 1;
            chkSauna.Checked = false;
            chkTrener.Checked = false;

            lblWynik.ForeColor = Color.FromArgb(24, 49, 75);
            lblWynik.Text = "Uzupełnij dane i wybierz Oblicz.";
            lblPodsumowanie.Text = "";
        }

        private void btnOblicz_Click(object sender, EventArgs e)
        {
            string imie = txtImie.Text.Trim();

            if (imie == "")
            {
                PokazBlad("Podaj imię i nazwisko.");
                return;
            }

            int miesiace = (int)numMiesiace.Value;

            if (miesiace < 1 || miesiace > 12)
            {
                PokazBlad("Liczba miesięcy musi być liczbą całkowitą od 1 do 12.");
                return;
            }

            string rodzaj = cmbRodzaj.SelectedItem.ToString();
            bool sauna = chkSauna.Checked;
            bool trener = chkTrener.Checked;

            decimal oplata = ObliczOplate(rodzaj, miesiace, sauna, trener);

            lblWynik.ForeColor = Color.FromArgb(15, 120, 145);
            lblWynik.Text = "Do zapłaty: " + oplata.ToString("0.00", CultureInfo.GetCultureInfo("pl-PL")) + " zł";

            string podsumowanie = imie + " · " + rodzaj + " · " + miesiace + " mies.";

            if (sauna)
            {
                podsumowanie = podsumowanie + " · sauna";
            }

            if (trener)
            {
                podsumowanie = podsumowanie + " · trener";
            }

            lblPodsumowanie.Text = podsumowanie;
        }

        // Osobna metoda oblicza cenę karnetu według zasad z arkusza.
        private decimal ObliczOplate(string rodzaj, int miesiace, bool sauna, bool trener)
        {
            decimal cenaZaMiesiac = 0m;

            if (rodzaj == "Standard")
            {
                cenaZaMiesiac = 80m;
            }
            else if (rodzaj == "Student")
            {
                cenaZaMiesiac = 60m;
            }
            else if (rodzaj == "Premium")
            {
                cenaZaMiesiac = 120m;
            }

            if (sauna)
            {
                cenaZaMiesiac = cenaZaMiesiac + 25m;
            }

            decimal suma = cenaZaMiesiac * miesiace;

            if (miesiace >= 6)
            {
                suma = suma * 0.9m;
            }

            if (trener)
            {
                suma = suma + 40m;
            }

            return suma;
        }

        private void btnWyczysc_Click(object sender, EventArgs e)
        {
            UstawWartosciPoczatkowe();
            txtImie.Focus();
        }

        private void PokazBlad(string komunikat)
        {
            lblWynik.ForeColor = Color.FromArgb(190, 40, 40);
            lblWynik.Text = komunikat;
            lblPodsumowanie.Text = "";
        }
    }
}
