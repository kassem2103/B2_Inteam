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
    public partial class VierkantrohrprofilView : UserControl
    {
        public List<MaterialModel> mat = new List<MaterialModel>();
        public static List<VierkantrohrProfil> vipo = new List<VierkantrohrProfil>();   // Erstellt Liste, mit ... als Inhalt
        public VierkantrohrProfilCon vipoc = new VierkantrohrProfilCon();
        public VierkantrohrprofilView()
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
                double a = double.Parse(breite.Text);
                double b = double.Parse(höhe.Text);
                double c = double.Parse(wandstärke.Text);
                double l = double.Parse(länge.Text);

                if ((a / 2) > c & (b / 2) > c)// Prüft Wandstärke
                {
                    if (a > 0 & b > 0 & c > 0 & l > 0) // prüft ob zahlen positiv sind
                    {
                        // objekt wird erstellt
                        var vierkantrohrProfil = new VierkantrohrProfil();



                        //Ausgabe für Querschnitt
                        try
                        {
                            double querschnittRechteck = vierkantrohrProfil.BerechnungQuerschnittsfläche(breite.Text, höhe.Text, wandstärke.Text);
                            string querschnittausgabe = querschnittRechteck.ToString();
                            querschnitt.Text = querschnittausgabe;
                        }
                        catch
                        {
                            MessageBox.Show("Bitte etwas eingeben");
                        }
                        //

                        //Ausgabe für Volumen
                        try
                        {
                            double volumenRechteck = vierkantrohrProfil.BerechnungVolumen(länge.Text);
                            string volumenAusgabe = volumenRechteck.ToString();
                            volumen.Text = volumenAusgabe;
                        }
                        catch
                        {
                            MessageBox.Show("Bitte etwas eingeben");
                        }


                        //Ausgabe für Gewicht
                        try
                        {


                            double gewichtRechteck = vierkantrohrProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);
                            string gewichtAusgabe = gewichtRechteck.ToString();
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
                            double schwerpunktX = vierkantrohrProfil.BerechnungSchwerpunktX(breite.Text);
                            string ausgabeSchwerpunktX = schwerpunktX.ToString();
                            spx.Text = " x: " + ausgabeSchwerpunktX + "                 ";

                            //Ausgabe für Y-Koordinate
                            double schwerpunktY = vierkantrohrProfil.BerechnungSchwerpunktY(höhe.Text);
                            string ausgabeSchwerpunktY = schwerpunktY.ToString();
                            spy.Text = " y: " + ausgabeSchwerpunktY + "                ";

                            //Ausgabe für Z-Koordinate
                            double schwerpunktZ = vierkantrohrProfil.BerechnungSchwerpunktZ(länge.Text);
                            string ausgabeSchwerpunktZ = schwerpunktZ.ToString();
                            spz.Text = " z: " + ausgabeSchwerpunktZ + "                ";

                            //Ausgabe Flächenträgheitsmomente
                            //
                            //Ausgabe Ixx
                            double trägheitsmomentIxx = vierkantrohrProfil.BerechnungFlächenträgheitsmomentIxx(breite.Text, höhe.Text);
                            string ausgabeIxx = trägheitsmomentIxx.ToString();
                            ixx.Text = ausgabeIxx;

                            //Ausgabe Iyy
                            double trägheitsmomentIyy = vierkantrohrProfil.BerechnungFlächenträgheitsmomentIyy(breite.Text, höhe.Text);
                            string ausgabeIyy = trägheitsmomentIyy.ToString();
                            iyy.Text = ausgabeIyy;
                        }
                        catch
                        {
                            MessageBox.Show("Bitte Material auswählen");
                        }
                    }// End of if von zahlen prüfung
                    else
                    {
                        MessageBox.Show("Nur positive Werte zulässig");
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
            ///
        }

        public void Speichern()
        {
            // objekt wird erstellt
            var vierkantrohrProfil = new VierkantrohrProfil();
            vierkantrohrProfil.ArtName = teilNr.Text;
            string teilNrAusgabe = teilNr.Text + " (" + breite.Text + "x" + höhe.Text + "x" + länge.Text + ")"; // Um später in der Liste den Namen + die abmaße auszugeben          rechteckProfil.ArtName = teilNr.Text;
            vierkantrohrProfil.ArtNameAusgabe = teilNrAusgabe;

            if (teilNr.Text != "")
            {

                //Ausgabe für Querschnitt
                try
                {
                    double querschnittRechteck = vierkantrohrProfil.BerechnungQuerschnittsfläche(breite.Text, höhe.Text, wandstärke.Text);
                    string querschnittausgabe = querschnittRechteck.ToString();
                    querschnitt.Text = querschnittausgabe;
                }
                catch
                {
                    MessageBox.Show("Bitte etwas eingeben");
                }
                //

                //Ausgabe für Volumen
                try
                {
                    double volumenRechteck = vierkantrohrProfil.BerechnungVolumen(länge.Text);
                    string volumenAusgabe = volumenRechteck.ToString();
                    volumen.Text = volumenAusgabe;
                }
                catch
                {
                    MessageBox.Show("Bitte etwas eingeben");
                }


                //Ausgabe für Gewicht
                try
                {


                    double gewichtRechteck = vierkantrohrProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);
                    string gewichtAusgabe = gewichtRechteck.ToString();
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
                    double schwerpunktX = vierkantrohrProfil.BerechnungSchwerpunktX(breite.Text);
                    string ausgabeSchwerpunktX = schwerpunktX.ToString();
                    spx.Text = " x: " + ausgabeSchwerpunktX + "            ";

                    //Ausgabe für Y-Koordinate
                    double schwerpunktY = vierkantrohrProfil.BerechnungSchwerpunktY(höhe.Text);
                    string ausgabeSchwerpunktY = schwerpunktY.ToString();
                    spy.Text = " y: " + ausgabeSchwerpunktY + "            ";

                    //Ausgabe für Z-Koordinate
                    double schwerpunktZ = vierkantrohrProfil.BerechnungSchwerpunktZ(länge.Text);
                    string ausgabeSchwerpunktZ = schwerpunktZ.ToString();
                    spz.Text = " z: " + ausgabeSchwerpunktZ + "            ";

                    //Ausgabe Flächenträgheitsmomente
                    //
                    //Ausgabe Ixx
                    double trägheitsmomentIxx = vierkantrohrProfil.BerechnungFlächenträgheitsmomentIxx(breite.Text, höhe.Text);
                    string ausgabeIxx = trägheitsmomentIxx.ToString();
                    ixx.Text = ausgabeIxx;

                    //Ausgabe Iyy
                    double trägheitsmomentIyy = vierkantrohrProfil.BerechnungFlächenträgheitsmomentIyy(breite.Text, höhe.Text);
                    string ausgabeIyy = trägheitsmomentIyy.ToString();
                    iyy.Text = ausgabeIyy;
                }
                catch
                {
                    MessageBox.Show("Bitte Material auswählen");
                }

                // hier wird bereits in die Datenbank gespeichert da die Methode in  MeineProfileView ausgeführt wird
                MeineProfileView.SaveVierkantrohr(vierkantrohrProfil);
                Verwerfen(); // zum schluss noch verwerfen damit der user nicht bewusst mehrfach
            }
            else
            {
                MessageBox.Show("Name wird zum Speichern benötigt");
            }
        }



        public void Verwerfen()
        {
            teilNr.Text = "";
            länge.Text = "";
            breite.Text = "";
            höhe.Text = "";
            wandstärke.Text = "";
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

        public void Erzeugen()
        {

            try
            {
                double h = double.Parse(höhe.Text);
                double b = double.Parse(breite.Text);
                double l = double.Parse(länge.Text);
                double ws = double.Parse(wandstärke.Text);
                double hi = h - (ws * 2);
                double bi = b - (ws * 2);
                double a = double.Parse(breite.Text);
                double c = double.Parse(wandstärke.Text);
                string partname = teilNr.Text;
                // Um zu überprüfen ob die Wandstärke realistisch angepasst wurde


                if ((a / 2) > c & (b / 2) > c)// Prüft Wandstärke
                {
                    if (a > 0 & b > 0 & c > 0 & l > 0) // prüft ob zahlen positiv sind
                    {
                        if (höhe.Text != "" & breite.Text != "" & länge.Text != "" & wandstärke.Text != "" & teilNr.Text != "")
                        {




                            // Finde Catia Prozess
                            if (vipoc.CATIALaeuft())
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
                                    vipoc.ErzeugePart(partname);


                                    // Erstelle eine Skizze
                                    vipoc.ErstelleLeereSkizze();

                                    // Generiere ein Profil
                                    vipoc.ErzeugeProfil(b, h, bi, hi);


                                    // Extrudiere Balken
                                    vipoc.ErzeugeBalken(l);

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
                    }// End of if von Positiv oder Negativ prüfung
                    else
                    {
                        MessageBox.Show("Nur Positive Werte zulässig");
                    }
                }// End of if von Wandstärken prüfung
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
                vipoc.Export(fileName, fPath, fType);
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
