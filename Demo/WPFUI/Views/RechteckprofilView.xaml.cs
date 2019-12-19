using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPFUI.Models;
namespace WPFUI.Views
{
    /// <summary>
    /// Interaktion logik für RechteckprofielView.xaml
    /// </summary>
    /// 
    //neuer ordner/datei
    public partial class RechteckprofilView : UserControl
    {
        public static List<RechteckProfil> repo = new List<RechteckProfil>();   // Erstellt Liste, mit Rechteckprofilen als Inhalt
        public List<MaterialModel> mat = new List<MaterialModel>();             // Erstellt Liste, mit Materialien als Inhalt
        public RechteckProfilCon repoc = new RechteckProfilCon();


        public RechteckprofilView()
        {
            InitializeComponent();
            //Materialien und deren dichte wird erstellt
            mat.Add(new MaterialModel { MaterialName = "Stahl", MaterialDichte = 7.85 });
            mat.Add(new MaterialModel { MaterialName = "Alu", MaterialDichte = 2.7 });
            mat.Add(new MaterialModel { MaterialName = "Kupfer", MaterialDichte = 8.96 });
            mat.Add(new MaterialModel { MaterialName = "AlCU", MaterialDichte = 2.8 });
            material.ItemsSource = mat;
            dateiFormat.Text = "CADPart";

        }


        /// ///////////// Methode zum Berechnen
        public void Berechnen()
        {
            try
            {

                double a = double.Parse(breite.Text);
                double b = double.Parse(höhe.Text);
                double l = double.Parse(länge.Text);
                if (a > 0 & b > 0 & l > 0) // Prüft ob die zahl negativ ist
                {

                    // objekt wird erstellt
                    var rechteckProfil = new RechteckProfil();
                    //Ausgabe für Querschnitt
                    try
                    {
                        double querschnittRechteck = rechteckProfil.BerechnungQuerschnittsfläche(breite.Text, höhe.Text);
                        string querschnittausgabe = querschnittRechteck.ToString();
                        querschnitt.Text = querschnittausgabe;
                    }
                    catch
                    {
                        MessageBox.Show("Bitte eingabe Überprüfen");
                    }
                    //

                    //Ausgabe für Volumen
                    try
                    {
                        double volumenRechteck = rechteckProfil.BerechnungVolumen(länge.Text);
                        string volumenAusgabe = volumenRechteck.ToString();
                        volumen.Text = volumenAusgabe;
                    }
                    catch
                    {

                    }


                    //Ausgabe für Gewicht
                    try
                    {


                        double gewichtRechteck = rechteckProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);
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
                        double schwerpunktX = rechteckProfil.BerechnungSchwerpunktX(breite.Text);
                        string ausgabeSchwerpunktX = schwerpunktX.ToString();
                        spx.Text = " x: " + ausgabeSchwerpunktX + "                   ";

                        //Ausgabe für Y-Koordinate
                        double schwerpunktY = rechteckProfil.BerechnungSchwerpunktY(höhe.Text);
                        string ausgabeSchwerpunktY = schwerpunktY.ToString();
                        spy.Text = " y: " + ausgabeSchwerpunktY + "                   ";

                        //Ausgabe für Z-Koordinate
                        double schwerpunktZ = rechteckProfil.BerechnungSchwerpunktZ(länge.Text);
                        string ausgabeSchwerpunktZ = schwerpunktZ.ToString();
                        spz.Text = " z: " + ausgabeSchwerpunktZ + "                   ";

                        //Ausgabe Flächenträgheitsmomente
                        //
                        //Ausgabe Ixx
                        double trägheitsmomentIxx = rechteckProfil.BerechnungFlächenträgheitsmomentIxx(breite.Text, höhe.Text);
                        string ausgabeIxx = trägheitsmomentIxx.ToString();
                        ixx.Text = ausgabeIxx + "            ";

                        //Ausgabe Iyy
                        double trägheitsmomentIyy = rechteckProfil.BerechnungFlächenträgheitsmomentIyy(breite.Text, höhe.Text);
                        string ausgabeIyy = trägheitsmomentIyy.ToString();
                        iyy.Text = ausgabeIyy + "            ";
                    }
                    catch
                    {

                    }
                }// End of if
                else
                {
                    MessageBox.Show("Nur positive Werte zulässig");
                }
            }
            catch
            {
                MessageBox.Show("Eingabe überprüfen");
            }
        }

        public void Speichern()
        {
            try
            {
                var rechteckProfil = new RechteckProfil();// objekt wird erstellt
                rechteckProfil.ArtName = teilNr.Text;
                string teilNrAusgabe = teilNr.Text + " (" + breite.Text + "x" + höhe.Text + "x" + länge.Text + ")"; // Um später in der Liste den Namen + die abmaße auszugeben          rechteckProfil.ArtName = teilNr.Text;
                rechteckProfil.ArtNameAusgabe = teilNrAusgabe;
                if (teilNr.Text != "")
                {

                    // für Querschnitt
                    try
                    {
                        // die berechnung wird in ProfilModel ausgeführt, breite und höhe werden übergeben
                        double querschnittRechteck = rechteckProfil.BerechnungQuerschnittsfläche(breite.Text, höhe.Text);

                    }
                    catch
                    {
                        MessageBox.Show("Bitte eingabe überprüfen"); // Falls der user nichts und oder ein buchstaben eingiebt
                    }
                    //

                    // für Volumen
                    try
                    {
                        double volumenRechteck = rechteckProfil.BerechnungVolumen(länge.Text);

                    }
                    catch
                    {
                        // muss nichts ausgegeben werden da schon bei querschnitt etwas ausgegen wird
                    }


                    // für Gewicht
                    try
                    {

                        double gewichtRechteck = rechteckProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);

                    }
                    catch
                    {
                        MessageBox.Show("Bitte Material auswählen");
                    }

                    try
                    {
                        //für Schwerpunkt
                        //
                        // für X-Koordinate
                        double schwerpunktX = rechteckProfil.BerechnungSchwerpunktX(breite.Text);


                        // für Y-Koordinate
                        double schwerpunktY = rechteckProfil.BerechnungSchwerpunktY(höhe.Text);


                        // für Z-Koordinate
                        double schwerpunktZ = rechteckProfil.BerechnungSchwerpunktZ(länge.Text);


                        // Flächenträgheitsmomente
                        //
                        // Ixx
                        double trägheitsmomentIxx = rechteckProfil.BerechnungFlächenträgheitsmomentIxx(breite.Text, höhe.Text);


                        // Iyy
                        double trägheitsmomentIyy = rechteckProfil.BerechnungFlächenträgheitsmomentIyy(breite.Text, höhe.Text);

                    }
                    catch
                    {
                        MessageBox.Show("Bitte Material auswählen");
                    }


                    //
                    // hier wird bereits in die Datenbank gespeichert da die Methode in  MeineProfileView ausgeführt wird
                    MeineProfileView.SaveRechteck(rechteckProfil);
                    Verwerfen_(); // zum schluss noch verwerfen damit der user nicht bewusst mehrfach
                }
                else
                {
                    MessageBox.Show("Bitte Namen vergeben");
                }
            }
            catch
            {

            }
        }

        //Methode zum Verwerfen
        public void Verwerfen_()
        {
            // hier wird der inhalt einfach mit nichts ersetzt
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
            //für die Ausgabe der Kooridaten notwerndige zuweisung wird hier noch eingetragen
            spx.Text = " x:                         ";
            spy.Text = " y:                         ";
            spz.Text = " z:                         ";
            einheitVolumen.Text = "";
            einheitGewicht.Text = "";
            einheitQuerschnittfläche.Text = "";
            einheitMoment.Text = "";
        }

        // Ab hier alle methoden mit Catia

        public void Erzeugen()
        {
            try
            {

                double a = double.Parse(breite.Text);
                double b = double.Parse(höhe.Text);
                double l = double.Parse(länge.Text);
                double h = double.Parse(höhe.Text);

                string partname = teilNr.Text;
                if (a > 0 & b > 0 & l > 0) // Prüft ob die zahl negativ ist
                {
                    if (höhe.Text != "" & breite.Text != "" & länge.Text != "" & teilNr.Text != "")
                    {



                        // Finde Catia Prozess
                        if (repoc.CATIALaeuft())
                        {
                            var bc = new BrushConverter();
                            teilNr.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                            höhe.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                            breite.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                            länge.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                            try
                            {


                                // Öffne ein neues Part
                                repoc.ErzeugePart(partname);


                                // Erstelle eine Skizze
                                repoc.ErstelleLeereSkizze();

                                // Generiere ein Profil
                                repoc.ErzeugeProfil(b, h);


                                // Extrudiere Balken
                                repoc.ErzeugeBalken(l);

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
                }// End of if
                else
                {
                    MessageBox.Show("Nur positive Werte zulässig");
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
                repoc.Export(fileName, fPath, fType);
            }

            catch
            {
                MessageBox.Show("Bitte SpeicherPfad anpassen!");
            }
        }




        //Knopf zum Berechnen
        private void Berechnen_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Berechnen();

        }
        // Methode um den inhalt der Textboxen zu leeren


        // Der Button zum Verwerfen, hier wird nur die Methode ausgeführt
        private void Verwerfen_Click(object sender, System.Windows.RoutedEventArgs e)   //Leert die Textboxen 
        {
            Verwerfen_();
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
