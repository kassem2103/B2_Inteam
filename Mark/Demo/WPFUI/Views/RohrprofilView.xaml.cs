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
        public static List<RohrProfil> repo = new List<RohrProfil>();
        public List<MaterialModel> mat = new List<MaterialModel>();
        public RohrprofilView()
        {
            InitializeComponent();

            mat.Add(new MaterialModel { MaterialName = "Stahl", MaterialDichte = 7.85 });
            mat.Add(new MaterialModel { MaterialName = "Alu", MaterialDichte = 2.7 });
            mat.Add(new MaterialModel { MaterialName = "Kupfer", MaterialDichte = 8.96 });
            mat.Add(new MaterialModel { MaterialName = "AlCU", MaterialDichte = 2.8 });
            material.ItemsSource = mat;


        }


        private void Berechnen_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // objekt wird erstellt
            var rohrProfil = new RohrProfil();
            //Ausgabe für Querschnitt
            try
            {
                double querschnittRohr = rohrProfil.BerechnungQuerschnittsfläche(breite.Text, höhe.Text);
                string querschnittausgabe = querschnittRohr.ToString();
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
                double volumenRohr = rohrProfil.BerechnungVolumen(länge.Text);
                string volumenAusgabe = volumenRohr.ToString();
                volumen.Text = volumenAusgabe;
            }
            catch
            {
                MessageBox.Show("Bitte etwas eingeben");
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
                

                //Ausgabe für Y-Koordinate
                double schwerpunktY = rohrProfil.BerechnungSchwerpunktY(länge.Text);
                string ausgabeSchwerpunktY = schwerpunktY.ToString();
                spz.Text = " z: " + ausgabeSchwerpunktY + "            ";

                //Ausgabe für Z-Koordinate
                double schwerpunktZ = rohrProfil.BerechnungSchwerpunktZ(länge.Text);
                string ausgabeSchwerpunktZ = schwerpunktZ.ToString();
                spz.Text = " z: " + ausgabeSchwerpunktZ + "            ";

                //Ausgabe Flächenträgheitsmomente
                //
                //Ausgabe Ixx
                double trägheitsmomentIxx = rohrProfil.BerechnungFlächenträgheitsmomentIxx(breite.Text, höhe.Text);
                string ausgabeIxx = trägheitsmomentIxx.ToString();
                ixx.Text = ausgabeIxx;

                //Ausgabe Iyy
                double trägheitsmomentIyy = rohrProfil.BerechnungFlächenträgheitsmomentIyy(breite.Text, höhe.Text);
                string ausgabeIyy = trägheitsmomentIyy.ToString();
                iyy.Text = ausgabeIyy;
            }
            catch
            {
                MessageBox.Show("Bitte Material auswählen");
            }

            //EinheitenAusgabe und einheitenRechnung
            switch (einheitLänge.Text)
            {
                case "mm":
                    einheitVolumen.Text = "mm^3";
                    einheitGewicht.Text = "kg";
                    einheitQuerschnittfläche.Text = "mm^2";
                    einheitMoment.Text = "cm^4";
                    break;

                default:
                    break;
            }


        }


        private void Verwerfen_Click(object sender, System.Windows.RoutedEventArgs e)   //Leert die Textboxen 
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
            einheitLänge.Text = "";
            einheitBreite.Text = "";
            einheitHöhe.Text = "";
            spx.Text = " x:                    ";
            spy.Text = " y:                    ";
            spz.Text = " z:                    ";
            einheitVolumen.Text = "";
            einheitGewicht.Text = "";
            einheitQuerschnittfläche.Text = "";
            einheitMoment.Text = "";
        }


        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            // objekt wird erstellt
            var rohrProfil = new RechteckProfil();
            string teilNrAusgabe = teilNr.Text + " " + breite.Text + "x" + höhe.Text + "x" + länge.Text;
            rohrProfil.ArtName = teilNr.Text;
            rohrProfil.ArtNameAusgabe = teilNrAusgabe;

            //Ausgabe für Querschnitt
            try
            {
                double querschnittRohr = rohrProfil.BerechnungQuerschnittsfläche(breite.Text, höhe.Text);
                string querschnittausgabe = querschnittRohr.ToString();
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
                double volumenRohr = rohrProfil.BerechnungVolumen(länge.Text);
                string volumenAusgabe = volumenRohr.ToString();
                volumen.Text = volumenAusgabe;
            }
            catch
            {
                MessageBox.Show("Bitte etwas eingeben");
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
                double schwerpunktX = rohrProfil.BerechnungSchwerpunktX(breite.Text);
                string ausgabeSchwerpunktX = schwerpunktX.ToString();
                spx.Text = " x: " + ausgabeSchwerpunktX + "            ";

                //Ausgabe für Y-Koordinate
                double schwerpunktY = rohrProfil.BerechnungSchwerpunktY(höhe.Text);
                string ausgabeSchwerpunktY = schwerpunktY.ToString();
                spy.Text = " y: " + ausgabeSchwerpunktY + "            ";

                //Ausgabe für Z-Koordinate
                double schwerpunktZ = rohrProfil.BerechnungSchwerpunktZ(länge.Text);
                string ausgabeSchwerpunktZ = schwerpunktZ.ToString();
                spz.Text = " z: " + ausgabeSchwerpunktZ + "            ";

                //Ausgabe Flächenträgheitsmomente
                //
                //Ausgabe Ixx
                double trägheitsmomentIxx = rohrProfil.BerechnungFlächenträgheitsmomentIxx(breite.Text, höhe.Text);
                string ausgabeIxx = trägheitsmomentIxx.ToString();
                ixx.Text = ausgabeIxx;

                //Ausgabe Iyy
                double trägheitsmomentIyy = rohrProfil.BerechnungFlächenträgheitsmomentIyy(breite.Text, höhe.Text);
                string ausgabeIyy = trägheitsmomentIyy.ToString();
                iyy.Text = ausgabeIyy;
            }
            catch
            {
                MessageBox.Show("Bitte Material auswählen");
            }

            //EinheitenAusgabe und einheitenRechnung
            switch (einheitLänge.Text)
            {
                case "mm":
                    einheitVolumen.Text = "mm^3";
                    einheitGewicht.Text = "kg";
                    einheitQuerschnittfläche.Text = "mm^2";
                    einheitMoment.Text = "cm^4";
                    break;

                default:
                    break;
            }
            //
            MeineProfileView.SaveRohr(rohrProfil);
            //repo.Add(rechteckProfil);
        }

    }
}
