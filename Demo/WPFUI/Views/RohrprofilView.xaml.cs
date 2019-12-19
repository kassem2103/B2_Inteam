using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFUI.Models;

namespace WPFUI.Views
{
    /// <summary>
    /// Interaction logic for SecondChildView.xaml
    /// </summary>
    public partial class RohrprofilView : UserControl
    {
        public List<MaterialModel> mat = new List<MaterialModel>();
        public static List<RohrProfil> ropo = new List<RohrProfil>();
        public RohrProfilCon ropoc = new RohrProfilCon();
        public RohrprofilView()
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
                double a = double.Parse(durchmesser.Text);
                double b = double.Parse(wandstärke.Text);
                double l = double.Parse(länge.Text);

                if (b < (a / 2))  // Das if füe die überprüfung der Wandstärkenverhältnisse
                {
                    if (a > 0 & b > 0 & l > 0) // Das if um zu gucken ob was negatives eingegeben wurde
                    {


                        // objekt wird erstellt
                        var rohrProfil = new RohrProfil();

                        //Ausgabe für Querschnitt
                        try
                        {
                            double querschnittRechteck = rohrProfil.BerechnungQuerschnittsfläche(wandstärke.Text, durchmesser.Text);
                            string querschnittausgabe = querschnittRechteck.ToString();
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
                            double volumenRohr = rohrProfil.BerechnungVolumen(länge.Text);
                            string volumenAusgabe = volumenRohr.ToString();
                            volumen.Text = volumenAusgabe;
                        }
                        catch
                        {

                        }

                        //Ausgabe für Gewicht
                        try
                        {


                            double gewichtRohr = rohrProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);
                            string gewichtAusgabe = gewichtRohr.ToString();
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
                            double schwerpunktX = rohrProfil.BerechnungSchwerpunktX();
                            string ausgabeSchwerpunktX = schwerpunktX.ToString();
                            spx.Text = " x: " + ausgabeSchwerpunktX + "            ";

                            //Ausgabe für Y-Koordinate
                            double schwerpunktY = rohrProfil.BerechnungSchwerpunktY();
                            string ausgabeSchwerpunktY = schwerpunktY.ToString();
                            spy.Text = " y: " + ausgabeSchwerpunktY + "            ";

                            //Ausgabe für Z-Koordinate
                            double schwerpunktZ = rohrProfil.BerechnungSchwerpunktZ(länge.Text);
                            string ausgabeSchwerpunktZ = schwerpunktZ.ToString();
                            spz.Text = " z: " + ausgabeSchwerpunktZ + "            ";

                            //Ausgabe Flächenträgheitsmomente
                            //
                            //Ausgabe Ixx
                            double trägheitsmomentIxx = rohrProfil.BerechnungFlächenträgheitsmomentIxx(durchmesser.Text, wandstärke.Text);
                            string ausgabeIxx = trägheitsmomentIxx.ToString();
                            ixx.Text = ausgabeIxx;

                            //Ausgabe Iyy
                            double trägheitsmomentIyy = rohrProfil.BerechnungFlächenträgheitsmomentIyy(durchmesser.Text, wandstärke.Text);
                            string ausgabeIyy = trägheitsmomentIyy.ToString();
                            iyy.Text = ausgabeIyy;
                        }
                        catch
                        {
                            MessageBox.Show("Bitte Material auswählen");
                        }
                    }// End Minus if
                    else
                    {
                        MessageBox.Show("Nur Positive Zahlen zulässig");
                    }
                }
                else// End Wandstärken if
                {
                    MessageBox.Show("Bitte die Wandstärke anpassen");
                }
            }

            catch
            {
                MessageBox.Show("Eingabe überprüfen");
            }
        }
        public void Verwerfen_()
        {
            // hier wird der inhalt einfach mit nichts ersetzt
            teilNr.Text = "";
            länge.Text = "";
            durchmesser.Text = "";
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
        public void Speichern()
        {
            try
            {


                // objekt wird erstellt
                var rohrProfil = new RohrProfil();

                rohrProfil.ArtName = teilNr.Text;
                string teilNrAusgabe = teilNr.Text + " (" + durchmesser.Text + "x" + wandstärke.Text + "x" + länge.Text + ")"; // Um später in der Liste den Namen + die abmaße auszugeben          rechteckProfil.ArtName = teilNr.Text;
                rohrProfil.ArtNameAusgabe = teilNrAusgabe;

                if (teilNr.Text != "")
                {


                    //Querschnitt
                    try
                    {
                        double querschnittRechteck = rohrProfil.BerechnungQuerschnittsfläche(wandstärke.Text, durchmesser.Text);

                    }
                    catch
                    {
                        MessageBox.Show("Bitte eingabe überprüfen");
                    }
                    //

                    // für Volumen
                    try
                    {
                        double volumenRohr = rohrProfil.BerechnungVolumen(länge.Text);

                    }
                    catch
                    {
                        MessageBox.Show("Bitte Länge eingeben");
                    }


                    // für Gewicht
                    try
                    {


                        double gewichtRohr = rohrProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);

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
                        double schwerpunktX = rohrProfil.BerechnungSchwerpunktX();


                        // für Y-Koordinate
                        double schwerpunktY = rohrProfil.BerechnungSchwerpunktY();


                        // für Z-Koordinate
                        double schwerpunktZ = rohrProfil.BerechnungSchwerpunktZ(länge.Text);


                        // Flächenträgheitsmomente
                        //
                        // Ixx
                        double trägheitsmomentIxx = rohrProfil.BerechnungFlächenträgheitsmomentIxx(durchmesser.Text, wandstärke.Text);
                        string ausgabeIxx = trägheitsmomentIxx.ToString();
                        ixx.Text = ausgabeIxx;

                        //Ausgabe Iyy
                        double trägheitsmomentIyy = rohrProfil.BerechnungFlächenträgheitsmomentIyy(durchmesser.Text, wandstärke.Text);
                        string ausgabeIyy = trägheitsmomentIyy.ToString();
                        iyy.Text = ausgabeIyy;
                    }
                    catch
                    {

                    }
                    // hier wird bereits in die Datenbank gespeichert da die Methode in  MeineProfileView ausgeführt wird
                    MeineProfileView.SaveRohr(rohrProfil);
                    Verwerfen_(); // zum schluss noch verwerfen damit der user nicht bewusst mehrfach
                }
                else
                {
                    MessageBox.Show("Name zum Speichern benötigt");
                }
            }
            catch
            {

            }
        }


        // Ab hier alle methoden mit Catia

        public void Erzeugen()
        {

            try
            {
                // Um zu überprüfen ob die Wandstärke realistisch angepasst wurde
                double a = double.Parse(durchmesser.Text);
                double b = double.Parse(wandstärke.Text);
                double l = double.Parse(länge.Text);
     
                string partname = teilNr.Text;
                double d = double.Parse(durchmesser.Text);
                double r = d / 2;
                double ws = double.Parse(wandstärke.Text);
                double ir = r - ws;


                if (b < (a / 2))  // Das if füe die überprüfung der Wandstärkenverhältnisse
                {
                    if (a > 0 & b > 0 & l > 0) // Das if um zu gucken ob was negatives eingegeben wurde
                    {
                        if (durchmesser.Text != ""  & länge.Text != "" & wandstärke.Text != "" & teilNr.Text != "")
                        {


                            // Finde Catia Prozess
                            if (ropoc.CATIALaeuft())
                            {
                                var bc = new BrushConverter();
                                teilNr.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                                durchmesser.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                                wandstärke.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                                länge.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                                try
                                {


                                    // Öffne ein neues Part
                                    ropoc.ErzeugePart(partname);


                                    // Erstelle eine Skizze
                                    ropoc.ErstelleLeereSkizze();

                                    // Generiere ein Profil
                                    ropoc.ErzeugeProfil(r, ir);


                                    // Extrudiere Balken
                                    ropoc.ErzeugeBalken(l);

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
                            durchmesser.Background = Brushes.Red;
                            wandstärke.Background = Brushes.Red;
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
                ropoc.Export(fileName, fPath, fType);
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
