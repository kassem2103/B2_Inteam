using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPFUI.Models;
namespace WPFUI.Views
{
    /// <summary>
    /// Interaktion logik für RechteckprofielView.xaml
    /// </summary>
    public partial class WinkelprofilView : UserControl
    {
        public static List<WinkelProfil> wipo = new List<WinkelProfil>();
        public List<MaterialModel> mat = new List<MaterialModel>();
        public WinkelProfilCon wipoc = new WinkelProfilCon();
        public WinkelprofilView()
        {
            InitializeComponent();

            mat.Add(new MaterialModel { MaterialName = "Stahl", MaterialDichte = 7.85 });
            mat.Add(new MaterialModel { MaterialName = "Alu", MaterialDichte = 2.7 });
            mat.Add(new MaterialModel { MaterialName = "Kupfer", MaterialDichte = 8.96 });
            mat.Add(new MaterialModel { MaterialName = "AlCU", MaterialDichte = 2.8 });
            material.ItemsSource = mat;
            dateiFormat.Text = "CADPart";

        }

        public void Berechnen()
        {
            try
            {


                // Um zu überprüfen ob die Wandstärke realistisch angepasst wurde
                double a = double.Parse(breite.Text);
                double b = double.Parse(höhe.Text);
                double c = double.Parse(wandstärke.Text);
                double l = double.Parse(länge.Text);

                if (a > c & b > c) // Prüft ob wandstärke hinkommt
                {
                    if (a > 0 & b > 0 & c > 0 & l > 0) // Prüft ob zahlen negativ sind
                    {
                        // objekt wird erstellt
                        var winkelProfil = new WinkelProfil();



                        //Ausgabe für Querschnitt
                        try
                        {
                            double querschnittWinkel = winkelProfil.BerechnungQuerschnittsfläche(breite.Text, höhe.Text, wandstärke.Text);
                            string querschnittausgabe = querschnittWinkel.ToString();
                            querschnitt.Text = querschnittausgabe;
                        }
                        catch
                        {
                            MessageBox.Show("Bitte Eingabe überprüfen");
                        }
                        //

                        //Ausgabe für Volumen
                        try
                        {
                            double volumenWinkel = winkelProfil.BerechnungVolumen(länge.Text);
                            string volumenAusgabe = volumenWinkel.ToString();
                            volumen.Text = volumenAusgabe;
                        }
                        catch
                        {

                        }


                        //Ausgabe für Gewicht
                        try
                        {


                            double gewichtWinkel = winkelProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);
                            string gewichtAusgabe = gewichtWinkel.ToString();
                            gewicht.Text = gewichtAusgabe;
                        }
                        catch
                        {
                            MessageBox.Show("Bitte Material auswählen");
                        }

                        try
                        {
                            //Ausgabe für Schwerpunkt
                            //
                            //Ausgabe für X-Koordinate
                            double schwerpunktX = winkelProfil.BerechnungSchwerpunktX(breite.Text, höhe.Text, wandstärke.Text);
                            string ausgabeSchwerpunktX = schwerpunktX.ToString();
                            spx.Text = " x: " + ausgabeSchwerpunktX + "                 ";

                            //Ausgabe für Y-Koordinate
                            double schwerpunktY = winkelProfil.BerechnungSchwerpunktY(breite.Text, höhe.Text, wandstärke.Text);
                            string ausgabeSchwerpunktY = schwerpunktY.ToString();
                            spy.Text = " y: " + ausgabeSchwerpunktY + "                 ";

                            //Ausgabe für Z-Koordinate
                            double schwerpunktZ = winkelProfil.BerechnungSchwerpunktZ(länge.Text);
                            string ausgabeSchwerpunktZ = schwerpunktZ.ToString();
                            spz.Text = " z: " + ausgabeSchwerpunktZ + "                 ";

                            //Ausgabe Flächenträgheitsmomente
                            //
                            //Ausgabe Ixx
                            double trägheitsmomentIxx = winkelProfil.BerechnungFlächenträgheitsmomentIxx(breite.Text, höhe.Text, wandstärke.Text);
                            string ausgabeIxx = trägheitsmomentIxx.ToString();
                            ixx.Text = ausgabeIxx;

                            //Ausgabe Iyy
                            double trägheitsmomentIyy = winkelProfil.BerechnungFlächenträgheitsmomentIyy(breite.Text, höhe.Text, wandstärke.Text);
                            string ausgabeIyy = trägheitsmomentIyy.ToString();
                            iyy.Text = ausgabeIyy;
                        }
                        catch
                        {

                        }
                    } // End of if von Negativ
                    else
                    {
                        MessageBox.Show("Nur positive Zahlen zulässig");
                    }
                } // End of If von Wandstärke
                else
                {
                    MessageBox.Show("Bitte Wandstärke anpassen");
                }
            }
            catch
            {
                MessageBox.Show("Eingabe überprüfen");
            }
        }

        public void Verwerfen()
        {
            teilNr.Text = "";
            länge.Text = "";
            breite.Text = "";
            höhe.Text = "";
            material.Text = "";
            volumen.Text = "";
            gewicht.Text = "";
            querschnitt.Text = "";
            ixx.Text = "";
            iyy.Text = "";

            spx.Text = " x:                    ";
            spy.Text = " y:                    ";
            spz.Text = " z:                    ";
            einheitVolumen.Text = "";
            einheitGewicht.Text = "";
            einheitQuerschnittfläche.Text = "";
            einheitMoment.Text = "";
        }


        public void Speichern()
        {
            try
            {
                // objekt wird erstellt
                var winkelProfil = new WinkelProfil();
                winkelProfil.ArtName = teilNr.Text;
                string teilNrAusgabe = teilNr.Text + " (" + breite.Text + "x" + höhe.Text + "x" + länge.Text + ")"; // Um später in der Liste den Namen + die abmaße auszugeben          rechteckProfil.ArtName = teilNr.Text;
                winkelProfil.ArtNameAusgabe = teilNrAusgabe;

                if (teilNr.Text != "")
                {


                    // für Querschnitt
                    try
                    {
                        double querschnittWinkel = winkelProfil.BerechnungQuerschnittsfläche(breite.Text, höhe.Text, wandstärke.Text);

                    }
                    catch
                    {
                        MessageBox.Show("Bitte Eingabe überprüfen");
                    }
                    //

                    // für Volumen
                    try
                    {
                        double volumenWinkel = winkelProfil.BerechnungVolumen(länge.Text);

                    }
                    catch
                    {

                    }

                    // für Gewicht
                    try
                    {


                        double gewichtWinkel = winkelProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);

                    }
                    catch
                    {
                        MessageBox.Show("Bitte Material auswählen");
                    }

                    try
                    {
                        // für Schwerpunkt
                        //
                        // für X-Koordinate
                        double schwerpunktX = winkelProfil.BerechnungSchwerpunktX(breite.Text, höhe.Text, wandstärke.Text);


                        // für Y-Koordinate
                        double schwerpunktY = winkelProfil.BerechnungSchwerpunktY(breite.Text, höhe.Text, wandstärke.Text);


                        // für Z-Koordinate
                        double schwerpunktZ = winkelProfil.BerechnungSchwerpunktZ(länge.Text);


                        // Flächenträgheitsmomente
                        //
                        // Ixx
                        double trägheitsmomentIxx = winkelProfil.BerechnungFlächenträgheitsmomentIxx(breite.Text, höhe.Text, wandstärke.Text);


                        // Iyy
                        double trägheitsmomentIyy = winkelProfil.BerechnungFlächenträgheitsmomentIyy(breite.Text, höhe.Text, wandstärke.Text);

                    }
                    catch
                    {

                    }

                    MeineProfileView.SaveWinkelprofil(winkelProfil);
                    Verwerfen();
                }
                else
                {
                    MessageBox.Show("Name wird zum Speichern benötigt");
                }
            }
            catch
            {

            }

        }

        public void Erzeugen()
        {

            try
            {
                // Um zu überprüfen ob die Wandstärke realistisch angepasst wurde
                double a = double.Parse(breite.Text);
                double b = double.Parse(höhe.Text);
                double c = double.Parse(wandstärke.Text);
                double l = double.Parse(länge.Text);
                double h = double.Parse(breite.Text);
                double ws = double.Parse(wandstärke.Text);
                string partname = teilNr.Text;

                if (a > c & b > c) // Prüft ob wandstärke hinkommt
                {
                    if (a > 0 & b > 0 & c > 0 & l > 0) // Prüft ob zahlen negativ sind
                    {

                        if (höhe.Text != "" & breite.Text != "" & länge.Text != "" & wandstärke.Text != "" & teilNr.Text != "")
                        {



                            // Finde Catia Prozess
                            if (wipoc.CATIALaeuft())
                            {
                                var bc = new BrushConverter();
                                teilNr.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                                höhe.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                                breite.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                                wandstärke.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                                länge.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                                try
                                {


                                    // Öffne ein neues Part
                                    wipoc.ErzeugePart(partname);


                                    // Erstelle eine Skizze
                                    wipoc.ErstelleLeereSkizze();

                                    // Generiere ein Profil
                                    wipoc.ErzeugeProfil(b, h, ws);


                                    // Extrudiere Balken
                                    wipoc.ErzeugeBalken(l);

                                }
                                catch
                                {
                                    MessageBox.Show("Name bereits vergeben, bitte anderen Namen wählen");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Laufende Catia Application nicht gefunden");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bitte die Felder ausfüllen");
                            teilNr.Background = Brushes.Red;
                            höhe.Background = Brushes.Red;
                            breite.Background = Brushes.Red;
                            länge.Background = Brushes.Red;
                        }
                    } // End of if von Negativ
                    else
                    {
                        MessageBox.Show("Nur positive Zahlen zulässig");
                    }
                } // End of If von Wandstärke
                else
                {
                    MessageBox.Show("Bitte Wandstärke anpassen");
                }
            }
            catch
            {
                MessageBox.Show("Eingabe überprüfen");
            }
        }
        public void CatiaSpeichern()
        {
            try
            {
                string fileName = teilNr.Text;
                string fPath = Properties.Settings.Default.speicherpfad;
                string fType = dateiFormat.Text;
                wipoc.Export(fileName, fPath, fType);
            }
            catch
            {
                MessageBox.Show("Bitte SpeicherPfad anpassen!");
            }
        }



        private void Berechnen_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            Berechnen();

        }

        private void Verwerfen_Click(object sender, System.Windows.RoutedEventArgs e)   //Leert die Textboxen 
        {
            Verwerfen();
        }

        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            Speichern();

        }



        private void Erzeugen_Click(object sender, RoutedEventArgs e)
        {
            Erzeugen();
        }

        private void saveCatia_Click(object sender, RoutedEventArgs e)
        {
            CatiaSpeichern();
        }
    }
}