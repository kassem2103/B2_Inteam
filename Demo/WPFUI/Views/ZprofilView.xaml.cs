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
    public partial class ZprofilView : UserControl
    {
        public static List<ZProfil> zpro = new List<ZProfil>();
        public List<MaterialModel> mat = new List<MaterialModel>();
        public ZProfilCon zproc = new ZProfilCon(); 
        public ZprofilView()
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

                if ((a / 2) > c & b > c) // Prüft ob Wandstärke hinkommt
                {
                    if (a > 0 & b > 0 & c > 0 & l > 0) // prüft ob zahlen positiv sind
                    {
                        // objekt wird erstellt
                        var zProfil = new ZProfil();



                        ////Ausgabe für Querschnitt
                        try
                        {
                            double querschnittRechteck = zProfil.BerechnungQuerschnittsfläche(breite.Text, höhe.Text, wandstärke.Text);
                            string querschnittausgabe = querschnittRechteck.ToString();
                            querschnitt.Text = querschnittausgabe;
                        }
                        catch
                        {
                            MessageBox.Show("Bitte eingabe überprüfen");
                        }


                        //Ausgabe für Volumen
                        try
                        {
                            double volumenRechteck = zProfil.BerechnungVolumen(länge.Text);
                            string volumenAusgabe = volumenRechteck.ToString();
                            volumen.Text = volumenAusgabe;
                        }
                        catch
                        {

                        }


                        //Ausgabe für Gewicht
                        try
                        {


                            double gewichtRechteck = zProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);
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
                            double schwerpunktX = zProfil.BerechnungSchwerpunktX();
                            string ausgabeSchwerpunktX = schwerpunktX.ToString();
                            spx.Text = " x: " + ausgabeSchwerpunktX + "                ";

                            //Ausgabe für Y-Koordinate
                            double schwerpunktY = zProfil.BerechnungSchwerpunktY();
                            string ausgabeSchwerpunktY = schwerpunktY.ToString();
                            spy.Text = " y: " + ausgabeSchwerpunktY + "                ";

                            //Ausgabe für Z-Koordinate
                            double schwerpunktZ = zProfil.BerechnungSchwerpunktZ(länge.Text);
                            string ausgabeSchwerpunktZ = schwerpunktZ.ToString();
                            spz.Text = " z: " + ausgabeSchwerpunktZ + "                ";

                            //Ausgabe Flächenträgheitsmomente
                            //
                            //Ausgabe Ixx
                            double trägheitsmomentIxx = zProfil.BerechnungFlächenträgheitsmomentIxx();
                            string ausgabeIxx = trägheitsmomentIxx.ToString();
                            ixx.Text = ausgabeIxx;

                            //Ausgabe Iyy
                            double trägheitsmomentIyy = zProfil.BerechnungFlächenträgheitsmomentIyy();
                            string ausgabeIyy = trägheitsmomentIyy.ToString();
                            iyy.Text = ausgabeIyy;
                        }
                        catch
                        {

                        }
                    }//End of if von Überprüfung ob positiv
                    else
                    {
                        MessageBox.Show("Nur positive Werte zulässig");
                    }

                }// End of if von Wandstärken prüfung
                else
                {
                    MessageBox.Show("Bitte Wandstärke anpassen ");
                }
            }
            catch
            {

            }

        }

        public void Speichern()
        {
            // objekt wird erstellt
            var zProfil = new ZProfil();
            zProfil.ArtName = teilNr.Text;
            string teilNrAusgabe = teilNr.Text + " (" + breite.Text + "x" + höhe.Text + "x" + länge.Text + ")"; // Um später in der Liste den Namen + die abmaße auszugeben          rechteckProfil.ArtName = teilNr.Text;
            zProfil.ArtNameAusgabe = teilNrAusgabe;


            if (teilNr.Text != "")
            {
                //// für Querschnitt
                try
                {
                    double querschnittRechteck = zProfil.BerechnungQuerschnittsfläche(breite.Text, höhe.Text, wandstärke.Text);

                }
                catch
                {
                    MessageBox.Show("Bitte eingabe überprüfen");
                }


                // für Volumen
                try
                {
                    double volumenRechteck = zProfil.BerechnungVolumen(länge.Text);

                }
                catch
                {

                }


                // für Gewicht
                try
                {


                    double gewichtRechteck = zProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);

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
                    double schwerpunktX = zProfil.BerechnungSchwerpunktX();


                    // für Y-Koordinate
                    double schwerpunktY = zProfil.BerechnungSchwerpunktY();


                    // für Z-Koordinate
                    double schwerpunktZ = zProfil.BerechnungSchwerpunktZ(länge.Text);


                    // Flächenträgheitsmomente
                    //
                    // Ixx
                    double trägheitsmomentIxx = zProfil.BerechnungFlächenträgheitsmomentIxx();


                    // Iyy
                    double trägheitsmomentIyy = zProfil.BerechnungFlächenträgheitsmomentIyy();

                }
                catch
                {

                }


                MeineProfileView.SaveZprofil(zProfil);
            }
            else
            {
                MessageBox.Show("Name zum Speichern benötigt");
                Verwerfen();
            }
        }

        public void Erzeugen()
        {
            try
            {
                // Um zu überprüfen ob die Wandstärke realistisch angepasst wurde
                double a = double.Parse(breite.Text);
                double b = double.Parse(höhe.Text);
                double c = double.Parse(wandstärke.Text); // Zum überprüfen
                double l = double.Parse(länge.Text);
                double ws = double.Parse(wandstärke.Text);  // zum Rechnen
                string partname = teilNr.Text;

                if ((a / 2) > c & b > c) // Prüft ob Wandstärke hinkommt
                {
                    if (a > 0 & b > 0 & c > 0 & l > 0) // prüft ob zahlen positiv sind
                    {
                        if (höhe.Text != "" & breite.Text != "" & länge.Text != "" & wandstärke.Text != "" & teilNr.Text != "")
                        {


                            // Finde Catia Prozess
                            if (zproc.CATIALaeuft())
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
                                    zproc.ErzeugePart(partname);


                                    // Erstelle eine Skizze
                                    zproc.ErstelleLeereSkizze();

                                    // Generiere ein Profil
                                    zproc.ErzeugeProfil(b, a, ws);


                                    // Extrudiere Balken
                                    zproc.ErzeugeBalken(l);

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

        private void Berechnen_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            Berechnen();


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
        //
        public void CatiaSpeichern()
        {
            try
            {
                string fileName = teilNr.Text;
                string fPath = Properties.Settings.Default.speicherpfad;
                string fType = dateiFormat.Text;
                zproc.Export(fileName, fPath, fType);
            }
            catch
            {
                MessageBox.Show("Bitte SpeicherPfad anpassen!");
            }
        }
        //
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
