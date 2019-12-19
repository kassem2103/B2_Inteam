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
    public partial class TprofilView : UserControl
    {
        public List<MaterialModel> mat = new List<MaterialModel>();
        public static List<Tprofil> tpro = new List<Tprofil>();
        public TprofilCon tproc = new TprofilCon();
        public TprofilView()
        {
            InitializeComponent();

            mat.Add(new MaterialModel { MaterialName = "Stahl", MaterialDichte = 7.85 });
            mat.Add(new MaterialModel { MaterialName = "Alu", MaterialDichte = 2.7 });
            mat.Add(new MaterialModel { MaterialName = "Kupfer", MaterialDichte = 8.96 });
            mat.Add(new MaterialModel { MaterialName = "AlCU", MaterialDichte = 2.8 });
            material.ItemsSource = mat;
            dateiFormat.Text = "CADPart";

        }

        public void Verwerfen_()
        {
            // hier wird der inhalt einfach mit nichts ersetzt
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

            //für die Ausgabe der Kooridaten notwerndige zuweisung wird hier noch eingetragen
            spx.Text = " x:                    ";
            spy.Text = " y:                    ";
            spz.Text = " z:                    ";
            einheitVolumen.Text = "";
            einheitGewicht.Text = "";
            einheitQuerschnittfläche.Text = "";
            einheitMoment.Text = "";
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

                if (a > c & b > c) // prüft wandstärken verhältnis
                {
                    if (a > 0 & b > 0 & c > 0 & l > 0) // prüft ob zahlen positiv sind
                    {
                        // objekt wird erstellt
                        var tProfil = new Tprofil();



                        //Ausgabe für Querschnitt
                        try
                        {
                            double querschnittRechteck = tProfil.BerechnungQuerschnittsfläche(breite.Text, höhe.Text, wandstärke.Text);
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
                            double volumenRechteck = tProfil.BerechnungVolumen(länge.Text);
                            string volumenAusgabe = volumenRechteck.ToString();
                            volumen.Text = volumenAusgabe;
                        }
                        catch
                        {

                        }


                        //Ausgabe für Gewicht
                        try
                        {


                            double gewichtRechteck = tProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);
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
                            double schwerpunktX = tProfil.BerechnungSchwerpunktX(breite.Text);
                            string ausgabeSchwerpunktX = schwerpunktX.ToString();
                            spx.Text = " x: " + ausgabeSchwerpunktX + "                ";

                            //Ausgabe für Y-Koordinate
                            double schwerpunktY = tProfil.BerechnungSchwerpunktY(höhe.Text, breite.Text, wandstärke.Text);
                            string ausgabeSchwerpunktY = schwerpunktY.ToString();
                            spy.Text = " y: " + ausgabeSchwerpunktY + "                   ";

                            //Ausgabe für Z-Koordinate
                            double schwerpunktZ = tProfil.BerechnungSchwerpunktZ(länge.Text);
                            string ausgabeSchwerpunktZ = schwerpunktZ.ToString();
                            spz.Text = " z: " + ausgabeSchwerpunktZ + "                  ";

                            //Ausgabe Flächenträgheitsmomente
                            //
                            //Ausgabe Ixx
                            double trägheitsmomentIxx = tProfil.BerechnungFlächenträgheitsmomentIxx(breite.Text, höhe.Text, wandstärke.Text);
                            string ausgabeIxx = trägheitsmomentIxx.ToString();
                            ixx.Text = ausgabeIxx;

                            //Ausgabe Iyy
                            double trägheitsmomentIyy = tProfil.BerechnungFlächenträgheitsmomentIyy();
                            string ausgabeIyy = trägheitsmomentIyy.ToString();
                            iyy.Text = ausgabeIyy;
                        }
                        catch
                        {

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


        public void Speichern()
        {


            try
            {
                
                // objekt wird erstellt
                var tProfil = new Tprofil();
                tProfil.ArtName = teilNr.Text;
                string teilNrAusgabe = teilNr.Text + " (" + breite.Text + "x" + höhe.Text + "x" + länge.Text + ")"; // Um später in der Liste den Namen + die abmaße auszugeben          rechteckProfil.ArtName = teilNr.Text;
                tProfil.ArtNameAusgabe = teilNrAusgabe;
                if (teilNr.Text != "")
                {

                    // für Querschnitt
                    try
                    {
                        double querschnittRechteck = tProfil.BerechnungQuerschnittsfläche(breite.Text, höhe.Text, wandstärke.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Bitte eingabe überprüfen");
                    }
                    //

                    // für Volumen
                    try
                    {
                        double volumenRechteck = tProfil.BerechnungVolumen(länge.Text);

                    }
                    catch
                    {
                        MessageBox.Show("Bitte etwas eingeben");
                    }


                    //für Gewicht
                    try
                    {


                        double gewichtRechteck = tProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);

                    }
                    catch
                    {
                        MessageBox.Show("Bitte Material auswählen");
                    }

                    try
                    {
                        // für Schwerpunkt
                        //
                        //Ausgabe für X-Koordinate
                        double schwerpunktX = tProfil.BerechnungSchwerpunktX(breite.Text);


                        // für Y-Koordinate
                        double schwerpunktY = tProfil.BerechnungSchwerpunktY(höhe.Text, breite.Text, wandstärke.Text);


                        // für Z-Koordinate
                        double schwerpunktZ = tProfil.BerechnungSchwerpunktZ(länge.Text);


                        // Flächenträgheitsmomente
                        //
                        // Ixx
                        double trägheitsmomentIxx = tProfil.BerechnungFlächenträgheitsmomentIxx(breite.Text, höhe.Text, wandstärke.Text);


                        // Iyy
                        double trägheitsmomentIyy = tProfil.BerechnungFlächenträgheitsmomentIyy();

                    }
                    catch
                    {
                        MessageBox.Show("Bitte Material auswählen");
                    }

                    //
                    // hier wird bereits in die Datenbank gespeichert da die Methode in  MeineProfileView ausgeführt wird
                    MeineProfileView.SaveTprofil(tProfil);
                    Verwerfen_(); // zum schluss noch verwerfen damit der user nicht bewusst mehrfach

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
                double ws = double.Parse(wandstärke.Text);
                string partname = teilNr.Text;

                if (a > c & b > c) // prüft wandstärken verhältnis
                {
                    if (a > 0 & b > 0 & c > 0 & l > 0) // prüft ob zahlen positiv sind
                    {
                        if (höhe.Text != "" & breite.Text != "" & länge.Text != "" & wandstärke.Text != "" & teilNr.Text != "")
                        {




                            // Finde Catia Prozess
                            if (tproc.CATIALaeuft())
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
                                    tproc.ErzeugePart(partname);


                                    // Erstelle eine Skizze
                                    tproc.ErstelleLeereSkizze();

                                    // Generiere ein Profil
                                    tproc.ErzeugeProfil(b, a, ws);


                                    // Extrudiere Balken
                                    tproc.ErzeugeBalken(l);

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
        //
        public void CatiaSpeichern()
        {
            try
            {
                string fileName = teilNr.Text;
                string fPath = Properties.Settings.Default.speicherpfad;
                string fType = dateiFormat.Text;
                tproc.Export(fileName, fPath, fType);
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
