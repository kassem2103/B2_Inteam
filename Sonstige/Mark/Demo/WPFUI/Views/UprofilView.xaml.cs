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
    public partial class UprofilView : UserControl
    {
        public List<MaterialModel> mat = new List<MaterialModel>();
        public UprofilView()
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
                MessageBox.Show("Bitte etwas eingeben");
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
                MessageBox.Show("Bitte etwas eingeben");
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
                spx.Text = " x: " + ausgabeSchwerpunktX + "            ";

                //Ausgabe für Y-Koordinate
                double schwerpunktY = rechteckProfil.BerechnungSchwerpunktY(höhe.Text);
                string ausgabeSchwerpunktY = schwerpunktY.ToString();
                spy.Text = " y: " + ausgabeSchwerpunktY + "            ";

                //Ausgabe für Z-Koordinate
                double schwerpunktZ = rechteckProfil.BerechnungSchwerpunktZ(länge.Text);
                string ausgabeSchwerpunktZ = schwerpunktZ.ToString();
                spz.Text = " z: " + ausgabeSchwerpunktZ + "            ";

                //Ausgabe Flächenträgheitsmomente
                //
                //Ausgabe Ixx
                double trägheitsmomentIxx = rechteckProfil.BerechnungFlächenträgheitsmomentIxx(breite.Text, höhe.Text);
                string ausgabeIxx = trägheitsmomentIxx.ToString();
                ixx.Text = ausgabeIxx;

                //Ausgabe Iyy
                double trägheitsmomentIyy = rechteckProfil.BerechnungFlächenträgheitsmomentIyy(breite.Text, höhe.Text);
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
                    einheitGewicht.Text = "mg";
                    einheitQuerschnittfläche.Text = "mm^2";
                    einheitMoment.Text = "N*mm";
                    break;

                case "cm":
                    einheitVolumen.Text = "cm^3";
                    einheitGewicht.Text = "g";
                    einheitQuerschnittfläche.Text = "cm^2";
                    einheitMoment.Text = "N*cm";
                    break;

                case "m":
                    einheitVolumen.Text = "m^3";
                    einheitGewicht.Text = "kg";
                    einheitQuerschnittfläche.Text = "m^2";
                    einheitMoment.Text = "N*m";
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
            //einheitBreite.Text = "";
            //einheitHöhe.Text = "";
            spx.Text = " x:                    ";
            spy.Text = " y:                    ";
            spz.Text = " z:                    ";
            einheitVolumen.Text = "";
            einheitGewicht.Text = "";
            einheitQuerschnittfläche.Text = "";
            einheitMoment.Text = "";
        }

    }
}
