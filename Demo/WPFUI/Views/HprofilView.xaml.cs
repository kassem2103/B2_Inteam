using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WPFUI.Models;
namespace WPFUI.Views
{
    /// <summary>
    /// Interaktion logik für RechteckprofielView.xaml
    /// </summary>
    public partial class HprofilView : UserControl
    {
        public List<MaterialModel> mat = new List<MaterialModel>();
        public static List<HProfil> hpro = new List<HProfil>();   // Erstellt Liste, mit Rechteckprofilen als Inhalt
        public HprofilView()
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
            var hProfil = new HProfil();



            //Ausgabe für Querschnitt
            try
            {
                double querschnittRechteck = hProfil.BerechnungQuerschnittsfläche(höheH.Text, breite.Text, höheh.Text, innenbreite.Text);
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
                double volumenRechteck = hProfil.BerechnungVolumen(länge.Text);
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


                double gewichtRechteck = hProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);
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
                double schwerpunktX = hProfil.BerechnungSchwerpunktX();
                string ausgabeSchwerpunktX = schwerpunktX.ToString();
                spx.Text = " x: " + ausgabeSchwerpunktX + "            ";

                //Ausgabe für Y-Koordinate
                double schwerpunktY = hProfil.BerechnungSchwerpunktY();
                string ausgabeSchwerpunktY = schwerpunktY.ToString();
                spy.Text = " y: " + ausgabeSchwerpunktY + "            ";

                //Ausgabe für Z-Koordinate
                double schwerpunktZ = hProfil.BerechnungSchwerpunktZ(länge.Text);
                string ausgabeSchwerpunktZ = schwerpunktZ.ToString();
                spz.Text = " z: " + ausgabeSchwerpunktZ + "            ";

                //Ausgabe Flächenträgheitsmomente
                //
                //Ausgabe Ixx
                double trägheitsmomentIxx = hProfil.BerechnungFlächenträgheitsmomentIxx();
                string ausgabeIxx = trägheitsmomentIxx.ToString();
                ixx.Text = ausgabeIxx;

                //Ausgabe Iyy
                double trägheitsmomentIyy = hProfil.BerechnungFlächenträgheitsmomentIyy(breite.Text, höheH.Text);
                string ausgabeIyy = trägheitsmomentIyy.ToString();
                iyy.Text = ausgabeIyy;
            }
            catch
            {
                
            }

            //EinheitenAusgabe und einheitenRechnung



        }

        public void  _verwerfen()
        {
            teilNr.Text = "";
            länge.Text = "";
            breite.Text = "";
            höheh.Text = "";
            höheH.Text = "";
            innenbreite.Text = "";
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


        private void Verwerfen_Click(object sender, System.Windows.RoutedEventArgs e)   //Leert die Textboxen 
        {
            _verwerfen();
        }

        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            // objekt wird erstellt
            var hProfil = new HProfil();
            hProfil.ArtName = teilNr.Text;
            string teilNrAusgabe = teilNr.Text + " (" + breite.Text + "x" + höheH.Text + "x" + länge.Text + ")"; // Um später in der Liste den Namen + die abmaße auszugeben          rechteckProfil.ArtName = teilNr.Text;
            hProfil.ArtNameAusgabe = teilNrAusgabe;

            //Ausgabe für Querschnitt
            try
            {
                double querschnittRechteck = hProfil.BerechnungQuerschnittsfläche(höheH.Text, breite.Text, höheh.Text, innenbreite.Text);
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
                double volumenRechteck = hProfil.BerechnungVolumen(länge.Text);
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


                double gewichtRechteck = hProfil.BerechnungGewicht((MaterialModel)material.SelectedItem);
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
                double schwerpunktX = hProfil.BerechnungSchwerpunktX();
                string ausgabeSchwerpunktX = schwerpunktX.ToString();
                spx.Text = " x: " + ausgabeSchwerpunktX + "            ";

                //Ausgabe für Y-Koordinate
                double schwerpunktY = hProfil.BerechnungSchwerpunktY();
                string ausgabeSchwerpunktY = schwerpunktY.ToString();
                spy.Text = " y: " + ausgabeSchwerpunktY + "            ";

                //Ausgabe für Z-Koordinate
                double schwerpunktZ = hProfil.BerechnungSchwerpunktZ(länge.Text);
                string ausgabeSchwerpunktZ = schwerpunktZ.ToString();
                spz.Text = " z: " + ausgabeSchwerpunktZ + "            ";

                //Ausgabe Flächenträgheitsmomente
                //
                //Ausgabe Ixx
                double trägheitsmomentIxx = hProfil.BerechnungFlächenträgheitsmomentIxx();
                string ausgabeIxx = trägheitsmomentIxx.ToString();
                ixx.Text = ausgabeIxx;

                //Ausgabe Iyy
                double trägheitsmomentIyy = hProfil.BerechnungFlächenträgheitsmomentIyy(breite.Text, höheH.Text);
                string ausgabeIyy = trägheitsmomentIyy.ToString();
                iyy.Text = ausgabeIyy;
            }
            catch
            {

            }

            //EinheitenAusgabe und einheitenRechnung

            MeineProfileView.SaveHprofil(hProfil);
            _verwerfen();

        }
    }
}