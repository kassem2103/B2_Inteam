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
    public partial class UprofilView : UserControl
    {
        public List<MaterialModel> mat = new List<MaterialModel>();
        public static List<Uprofil> upro = new List<Uprofil>();   // Erstellt Liste, mit Rechteckprofilen als Inhalt
        public UprofilCon uproc = new UprofilCon();
        public UprofilView()
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

                if ((a / 2) > c & b > c) // Prüft wandstärke
                {
                    if (a > 0 & b > 0 & c > 0 & l > 0) // Prüft ob die Zahlen positiv sind
                    {

                        // objekt wird erstellt
                        var uProfil = new Uprofil();


                        //Ausgabe für Querschnitt
                        try
                        {
                            double querschnittRechteck = uProfil.BerechnungQuerschnittsfläche(breite.Text, höhe.Text, wandstärke.Text);
                            string querschnittausgabe = querschnittRechteck.ToString();
                            querschnitt.Text = querschnittausgabe;
                        }
                        catch
                        {
                            MessageBox.Show("Bitte eingabe überprüfen");
                        }
                        //

                        //Ausgabe für Volumen
                        try
                        {
                            double volumenRechteck = uProfil.BerechnungVolumen(länge.Text);
                            string volumenAusgabe = volumenRechteck.ToString();
                            volumen.Text = volumenAusgabe;
                        }
                        catch
                        {

                        }


                        //Ausgabe für Gewicht
                        try
                        {


                            double gewichtRechteck = uProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);
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
                            double schwerpunktX = uProfil.BerechnungSchwerpunktX(breite.Text, höhe.Text, wandstärke.Text);
                            string ausgabeSchwerpunktX = schwerpunktX.ToString();
                            spx.Text = " x: " + ausgabeSchwerpunktX + "                     ";

                            //Ausgabe für Y-Koordinate
                            double schwerpunktY = uProfil.BerechnungSchwerpunktY(breite.Text, höhe.Text, wandstärke.Text);
                            string ausgabeSchwerpunktY = schwerpunktY.ToString();
                            spy.Text = " y: " + ausgabeSchwerpunktY + "                     ";

                            //Ausgabe für Z-Koordinate
                            double schwerpunktZ = uProfil.BerechnungSchwerpunktZ(länge.Text);
                            string ausgabeSchwerpunktZ = schwerpunktZ.ToString();
                            spz.Text = " z: " + ausgabeSchwerpunktZ + "                    ";

                            //Ausgabe Flächenträgheitsmomente
                            //
                            //Ausgabe Ixx
                            double trägheitsmomentIxx = uProfil.BerechnungFlächenträgheitsmomentIxx();
                            string ausgabeIxx = trägheitsmomentIxx.ToString();
                            ixx.Text = ausgabeIxx;

                            //Ausgabe Iyy
                            double trägheitsmomentIyy = uProfil.BerechnungFlächenträgheitsmomentIyy(breite.Text, höhe.Text, wandstärke.Text);
                            string ausgabeIyy = trägheitsmomentIyy.ToString();
                            iyy.Text = ausgabeIyy;
                        }
                        catch
                        {

                        }
                    }// end of if von Negativ
                    else
                    {
                        MessageBox.Show("Nur positive Werte zulässig");
                    }

                }// end of if von Wandstärke
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
            wandstärke.Text = "";
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
                var uProfil = new Uprofil();
                uProfil.ArtName = teilNr.Text;
                string teilNrAusgabe = teilNr.Text + " (" + breite.Text + "x" + höhe.Text + "x" + länge.Text + ")"; // Um später in der Liste den Namen + die abmaße auszugeben          rechteckProfil.ArtName = teilNr.Text;
                uProfil.ArtNameAusgabe = teilNrAusgabe;

                if (teilNr.Text != "")
                {


                    // Querschnitt
                    try
                    {
                        double querschnittRechteck = uProfil.BerechnungQuerschnittsfläche(breite.Text, höhe.Text, wandstärke.Text);

                    }
                    catch
                    {
                        MessageBox.Show("Bitte eingabe überprüfen");
                    }
                    //

                    //für Volumen
                    try
                    {
                        double volumenRechteck = uProfil.BerechnungVolumen(länge.Text);

                    }
                    catch
                    {
                        MessageBox.Show("Bitte etwas eingeben");
                    }


                    // für Gewicht
                    try
                    {


                        double gewichtRechteck = uProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);

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
                        double schwerpunktX = uProfil.BerechnungSchwerpunktX(breite.Text, höhe.Text, wandstärke.Text);


                        // für Y-Koordinate
                        double schwerpunktY = uProfil.BerechnungSchwerpunktY(breite.Text, höhe.Text, wandstärke.Text);


                        // für Z-Koordinate
                        double schwerpunktZ = uProfil.BerechnungSchwerpunktZ(länge.Text);


                        // Flächenträgheitsmomente
                        //
                        // Ixx
                        double trägheitsmomentIxx = uProfil.BerechnungFlächenträgheitsmomentIxx();


                        // Iyy
                        double trägheitsmomentIyy = uProfil.BerechnungFlächenträgheitsmomentIyy(breite.Text, höhe.Text, wandstärke.Text);

                    }
                    catch
                    {
                        MessageBox.Show("Bitte Material auswählen");
                    }


                    MeineProfileView.SaveUprofil(uProfil);
                }
                else
                {
                    MessageBox.Show("Name wird zum Speichern benötigt");
                    Verwerfen();
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

                double h = double.Parse(höhe.Text);
                double ws = double.Parse(wandstärke.Text);
                string partname = teilNr.Text;

                if ((a / 2) > c & b > c) // Prüft wandstärke
                {
                    if (a > 0 & b > 0 & c > 0 & l > 0) // Prüft ob die Zahlen positiv sind
                    {
                        // Prüft ob Textboxen leer sind
                        if (höhe.Text != "" & breite.Text != "" & länge.Text != "" & wandstärke.Text != "" & teilNr.Text != "")
                        {



                            // Finde Catia Prozess
                            if (uproc.CATIALaeuft())
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
                                    uproc.ErzeugePart(partname);


                                    // Erstelle eine Skizze
                                    uproc.ErstelleLeereSkizze();

                                    // Generiere ein Profil
                                    uproc.ErzeugeProfil(b, h, ws);


                                    // Extrudiere Balken
                                    uproc.ErzeugeBalken(l);

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
                            // Macht die Textboxen dann rot
                            MessageBox.Show("Bitte die Felder ausfüllen");
                            teilNr.Background = Brushes.Red;
                            höhe.Background = Brushes.Red;
                            breite.Background = Brushes.Red;
                            länge.Background = Brushes.Red;
                        }
                    }// end of if von Negativ
                    else
                    {
                        MessageBox.Show("Nur positive Werte zulässig");
                    }

                }// end of if von Wandstärke
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
        //
        public void CatiaSpeichern()
        {
            try
            {
                string fileName = teilNr.Text;
                string fPath = Properties.Settings.Default.speicherpfad;
                string fType = dateiFormat.Text;
                uproc.Export(fileName, fPath, fType);
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

        private void saveCatia_Click(object sender, RoutedEventArgs e)
        {
            CatiaSpeichern();
        }

        private void Erzeugen_Click(object sender, RoutedEventArgs e)
        {
            Erzeugen();
        }
    }
}
