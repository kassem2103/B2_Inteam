using HelixToolkit.Wpf;
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
    public partial class KreisprofilView : UserControl
    {
        public List<MaterialModel> mat = new List<MaterialModel>();
        public static List<KreisProfil> krpo = new List<KreisProfil>();
        public KreisProfilCon krpoc = new KreisProfilCon();
        public KreisprofilView()
        {
            InitializeComponent();

            mat.Add(new MaterialModel { MaterialName = "Stahl", MaterialDichte = 7.85 });
            mat.Add(new MaterialModel { MaterialName = "Alu", MaterialDichte = 2.7 });
            mat.Add(new MaterialModel { MaterialName = "Kupfer", MaterialDichte = 8.96 });
            mat.Add(new MaterialModel { MaterialName = "AlCU", MaterialDichte = 2.8 });
            material.ItemsSource = mat;
            dateiFormat.Text = "CADPart";

        }



        public void Verwerfen()
        {
            teilNr.Text = "";
            länge.Text = "";
            durchmesser.Text = "";
            material.Text = "";
            volumen.Text = "";
            gewicht.Text = "";
            querschnitt.Text = "";
            ixx.Text = "";
            iyy.Text = "";

            //einheitHöhe.Text = "";
            spx.Text = " x:                    ";
            spy.Text = " y:                    ";
            spz.Text = " z:                    ";

        }
        public void Berechnen()
        {
            try
            {
                double a = double.Parse(durchmesser.Text);
                double l = double.Parse(länge.Text);

                if (a > 0 & l > 0) // Prüfen auf negative eingabe
                {

                    // objekt wird erstellt
                    var kreisProfil = new KreisProfil();


                    //Ausgabe für Querschnitt
                    try
                    {
                        double querschnittRechteck = kreisProfil.BerechnungQuerschnittsfläche(durchmesser.Text);
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
                        double volumenRechteck = kreisProfil.BerechnungVolumen(länge.Text);
                        string volumenAusgabe = volumenRechteck.ToString();
                        volumen.Text = volumenAusgabe;
                    }
                    catch
                    {

                    }


                    //Ausgabe für Gewicht
                    try
                    {


                        double gewichtRechteck = kreisProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);
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
                        double schwerpunktX = kreisProfil.BerechnungSchwerpunktX(durchmesser.Text);
                        string ausgabeSchwerpunktX = schwerpunktX.ToString();
                        spx.Text = " x: " + ausgabeSchwerpunktX + "                     ";

                        //Ausgabe für Y-Koordinate
                        double schwerpunktY = kreisProfil.BerechnungSchwerpunktY(durchmesser.Text);
                        string ausgabeSchwerpunktY = schwerpunktY.ToString();
                        spy.Text = " y: " + ausgabeSchwerpunktY + "                    ";

                        //Ausgabe für Z-Koordinate
                        double schwerpunktZ = kreisProfil.BerechnungSchwerpunktZ(länge.Text);
                        string ausgabeSchwerpunktZ = schwerpunktZ.ToString();
                        spz.Text = " z: " + ausgabeSchwerpunktZ + "                    ";

                        //Ausgabe Flächenträgheitsmomente
                        //
                        //Ausgabe Ixx
                        double trägheitsmomentIxx = kreisProfil.BerechnungFlächenträgheitsmomentIxx(durchmesser.Text);
                        string ausgabeIxx = trägheitsmomentIxx.ToString();
                        ixx.Text = ausgabeIxx;

                        //Ausgabe Iyy
                        double trägheitsmomentIyy = kreisProfil.BerechnungFlächenträgheitsmomentIyy(durchmesser.Text);
                        string ausgabeIyy = trägheitsmomentIyy.ToString();
                        iyy.Text = ausgabeIyy;
                    }
                    catch
                    {
                        MessageBox.Show("Bitte Material auswählen");
                    }
                }// End if Minus prüfung
                else
                {
                    MessageBox.Show("Nur Positive Zahlen zulässig");
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
                var kreisProfil = new KreisProfil();
                kreisProfil.ArtName = teilNr.Text;
                string teilNrAusgabe = teilNr.Text + " (" + durchmesser.Text + "x" + länge.Text + ")"; // Um später in der Liste den Namen + die abmaße auszugeben          rechteckProfil.ArtName = teilNr.Text;
                kreisProfil.ArtNameAusgabe = teilNrAusgabe;
                if (teilNr.Text != "")
                {
                    // für Querschnitt
                    try
                    {
                        double querschnittRechteck = kreisProfil.BerechnungQuerschnittsfläche(durchmesser.Text);

                    }
                    catch
                    {
                        MessageBox.Show("Bitte eingabe überprüfen");
                    }
                    //

                    //für Volumen
                    try
                    {
                        double volumenRechteck = kreisProfil.BerechnungVolumen(länge.Text);

                    }
                    catch
                    {

                    }


                    // für Gewicht
                    try
                    {


                        double gewichtRechteck = kreisProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);

                    }
                    catch
                    {
                        MessageBox.Show("Bitte Material auswählen");
                    }

                    try
                    {
                        // für Schwerpunkt
                        //
                        //für X-Koordinate
                        double schwerpunktX = kreisProfil.BerechnungSchwerpunktX(durchmesser.Text);


                        // für Y-Koordinate
                        double schwerpunktY = kreisProfil.BerechnungSchwerpunktY(durchmesser.Text);


                        // für Z-Koordinate
                        double schwerpunktZ = kreisProfil.BerechnungSchwerpunktZ(länge.Text);


                        // Flächenträgheitsmomente
                        //
                        // Ixx
                        double trägheitsmomentIxx = kreisProfil.BerechnungFlächenträgheitsmomentIxx(durchmesser.Text);


                        // Iyy
                        double trägheitsmomentIyy = kreisProfil.BerechnungFlächenträgheitsmomentIyy(durchmesser.Text);

                    }
                    catch
                    {

                    }


                    MeineProfileView.SaveKreis(kreisProfil);
                    Verwerfen();
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


        public void Erzeugen()
        {
            try
            {
                // Um zu überprüfen ob die Wandstärke realistisch angepasst wurde

                double l = double.Parse(länge.Text);
                double d = double.Parse(durchmesser.Text);
                double r = d / 2;
                string partname = teilNr.Text;


                if (d > 0 & l > 0) // prüft ob zahlen positiv sind
                {
                    if (länge.Text != "" & durchmesser.Text != "" & teilNr.Text != "")
                    {




                        // Finde Catia Prozess
                        if (krpoc.CATIALaeuft())
                        {
                            var bc = new BrushConverter();
                            teilNr.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                            durchmesser.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                            länge.Background = (Brush)bc.ConvertFrom("#FF8522BD");
                            try
                            {


                                // Öffne ein neues Part
                                krpoc.ErzeugePart(partname);


                                // Erstelle eine Skizze
                                krpoc.ErstelleLeereSkizze();

                                // Generiere ein Profil
                                krpoc.ErzeugeProfil(r);


                                // Extrudiere Balken
                                krpoc.ErzeugeBalken(l);

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
                        länge.Background = Brushes.Red;
                    }
                }// End of if von Positiv oder Negativ prüfung
                else
                {
                    MessageBox.Show("Nur Positive Werte zulässig");
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
                krpoc.Export(fileName, fPath, fType);
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
