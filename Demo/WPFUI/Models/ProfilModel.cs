using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFITF;
using MECMOD;
using PARTITF;



namespace WPFUI.Models
{
    public class ProfilModel
    {

        // Eigenschaften die Vererbar sind
        public string ArtName { get; set; }    // der Einmalige Name
        public string ArtNameAusgabe { get; set; }
        public string Material { get; set; }
        public string Preis { get; set; }
        public string Länge { get; set; }
        public string Querschnittsfläche { set; get; }
        public string Volumen { set; get; }
        public string Gewicht { set; get; }
        public string SchwerpunktX { set; get; }
        public string SchwerpunktY { set; get; }
        public string SchwerpunktZ { set; get; }
        public string FlächenträgheitsmomentIxx { get; set; }
        public string FlächenträgheitsmomentIyy { get; set; }




        // Methoden die Vererbar sind 
        public double BerechnungVolumen(string länge)
        {
            Länge = länge;
            Volumen = (double.Parse(Querschnittsfläche) * double.Parse(Länge)).ToString();
            Volumen = (Math.Round(double.Parse(Volumen), 3)).ToString();
            return double.Parse(Volumen);
        }
        // Berechnet das Gewicht
        public double BerechnungGewicht(MaterialModel material)
        {
            // Objekt wird übergeben
            MaterialModel materialModel = material;
            Material = materialModel.MaterialName;

            Gewicht = (materialModel.MaterialDichte * (double.Parse(Volumen) / 1000000)).ToString(); //wegen umrechnung mm in cm
            Gewicht = (Math.Round(double.Parse(Gewicht), 3)).ToString();
            return double.Parse(Gewicht);
        }
    }
    public class RechteckProfil : ProfilModel           // Rechteckprofil Erbt die Eigenschaften und Methoden von Profil
    {
        // Klassenspeziefische Eigenschaften 
        public string Höhe { get; set; }
        public string Breite { get; set; }

        // Klassenspeziefische Methoden
        // Berechnungen 
        public double BerechnungQuerschnittsfläche(string breite, string höhe)
        {
            Breite = breite;
            Höhe = höhe;
            Querschnittsfläche = (double.Parse(Breite) * double.Parse(Höhe)).ToString();
            Querschnittsfläche = (Math.Round(double.Parse(Querschnittsfläche), 3)).ToString();
            return double.Parse(Querschnittsfläche);                 // Gibt Querschnittsfläche als double zurück
        }
        public double BerechnungSchwerpunktX(string breite)
        {
            SchwerpunktX = (double.Parse(breite) / 2).ToString();
            return double.Parse(SchwerpunktX);
        }
        public double BerechnungSchwerpunktY(string höhe)
        {
            SchwerpunktY = (double.Parse(höhe) / 2).ToString();
            return double.Parse(SchwerpunktY);
        }
        public double BerechnungSchwerpunktZ(string länge)
        {
            SchwerpunktZ = (double.Parse(länge) / 2).ToString();
            return double.Parse(SchwerpunktZ);
        }

        public double BerechnungFlächenträgheitsmomentIxx(string breite, string höhe)
        {
            double b = double.Parse(breite) / 10; //um das in cm^4 anzugeben
            double h = double.Parse(höhe) / 10;
            FlächenträgheitsmomentIxx = (((Math.Pow(h, 3) * b) / 12)).ToString();
            FlächenträgheitsmomentIxx = (Math.Round(double.Parse(FlächenträgheitsmomentIxx), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIxx);
        }

        public double BerechnungFlächenträgheitsmomentIyy(string breite, string höhe)
        {
            double b = double.Parse(breite) / 10;
            double h = double.Parse(höhe) / 10;
            FlächenträgheitsmomentIyy = (((Math.Pow(b, 3) * h) / 12)).ToString();
            FlächenträgheitsmomentIyy = (Math.Round(double.Parse(FlächenträgheitsmomentIyy), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIyy);
        }

    }
    public class KreisProfil : ProfilModel
    {
        // Anfang der Kreisprofil Klasse
        // Klassenspeziefische Eigenschaften 
        public string Durchmesser { get; set; }
        // Methoden der Klasse Kreisprofil

        public double BerechnungQuerschnittsfläche(string durchmesser)            //Methode um Querschnittsfläche zu berechnen
        {
            Durchmesser = durchmesser;
            Querschnittsfläche = (Math.PI * Math.Pow((double.Parse(Durchmesser) / 2), 2)).ToString();          // PI * R^2
            Querschnittsfläche = (Math.Round(double.Parse(Querschnittsfläche), 3)).ToString();
            return double.Parse(Querschnittsfläche);                 // Gibt Querschnittsfläche als double zurück
        }                                              // Und Querschnitt kriegt ein Wert

        public double BerechnungSchwerpunktX(string durchmesser)
        {
            SchwerpunktX = "0";
            return double.Parse(SchwerpunktX);
        }
        public double BerechnungSchwerpunktY(string durchmesser)
        {
            SchwerpunktY = "0";
            return double.Parse(SchwerpunktY);
        }
        public double BerechnungSchwerpunktZ(string länge)
        {

            SchwerpunktZ = (double.Parse(länge) / 2).ToString();
            return double.Parse(SchwerpunktZ);
        }

        public double BerechnungFlächenträgheitsmomentIxx(string durchmesser)
        {
            double d = double.Parse(durchmesser) / 10;
            FlächenträgheitsmomentIxx = (((Math.Pow(((d) / 20), 4) * Math.PI) / 4)).ToString();
            FlächenträgheitsmomentIxx = (Math.Round(double.Parse(FlächenträgheitsmomentIxx), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIxx);
        }

        public double BerechnungFlächenträgheitsmomentIyy(string durchmesser)
        {
            double d = double.Parse(durchmesser) / 10;
            FlächenträgheitsmomentIyy = (((Math.Pow(((d) / 20), 4) * Math.PI) / 4)).ToString();
            FlächenträgheitsmomentIyy = (Math.Round(double.Parse(FlächenträgheitsmomentIyy), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIyy);
        }

        // Ende der KreisProfilKlasse
    }


    public class RohrProfil : ProfilModel
    {
        public string Durchmesser { get; set; }
        public string Wandstärke { get; set; }



        public double BerechnungQuerschnittsfläche(string wandstärke, string außendurchmesser)
        {
            Durchmesser = außendurchmesser;
            Wandstärke = wandstärke;
            Querschnittsfläche = ((Math.PI * Math.Pow((double.Parse(Durchmesser) / 2), 2)) - (Math.PI * Math.Pow(((double.Parse(Durchmesser) / 2) - double.Parse(Wandstärke)), 2))).ToString(); // Ganze Fläche Minus Das was in der Mitte des Rohres fehlt
            Querschnittsfläche = (Math.Round(double.Parse(Querschnittsfläche), 3)).ToString();
            return double.Parse(Querschnittsfläche);                 // 
        }
        public double BerechnungSchwerpunktX()
        {
            SchwerpunktX = "0";

            return double.Parse(SchwerpunktX);
        }
        public double BerechnungSchwerpunktY()
        {
            SchwerpunktY = "0";

            return double.Parse(SchwerpunktY);
        }
        public double BerechnungSchwerpunktZ(string länge)
        {
            SchwerpunktZ = (double.Parse(länge) / 2).ToString();

            return double.Parse(SchwerpunktZ);
        }

        public double BerechnungFlächenträgheitsmomentIxx(string außendurchmesser, string wandstärke)
        {
            double d = double.Parse(außendurchmesser) / 10;
            double w = double.Parse(wandstärke) / 10;
            FlächenträgheitsmomentIxx = ((Math.PI / 4) * (Math.Pow(d, 4) - Math.Pow(d - 2 * w, 4))).ToString();

            FlächenträgheitsmomentIxx = (Math.Round(double.Parse(FlächenträgheitsmomentIxx), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIxx);
        }

        public double BerechnungFlächenträgheitsmomentIyy(string außendurchmesser, string wandstärke)
        {
            double d = double.Parse(außendurchmesser) / 10;
            double w = double.Parse(wandstärke) / 10;
            FlächenträgheitsmomentIyy = ((Math.PI / 4) * (Math.Pow(d, 4) - Math.Pow(d - 2 * w, 4))).ToString();

            FlächenträgheitsmomentIyy = (Math.Round(double.Parse(FlächenträgheitsmomentIyy), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIyy);
        }
    }
    public class Tprofil : ProfilModel
    {
        public string Breite { get; set; }

        public string Höhe { get; set; }

        public string Wandstärke { get; set; }

        public double BerechnungQuerschnittsfläche(string breite, string höhe, string wandstärke)
        {
            Breite = breite;

            Höhe = höhe;

            Wandstärke = wandstärke;

            Querschnittsfläche = ((double.Parse(breite) * double.Parse(wandstärke)) + (double.Parse(wandstärke) * (double.Parse(höhe) - double.Parse(wandstärke)))).ToString();
            Querschnittsfläche = (Math.Round(double.Parse(Querschnittsfläche), 3)).ToString();

            return double.Parse(Querschnittsfläche);
        }

        public double BerechnungSchwerpunktX(string breite)
        {
            SchwerpunktX = (double.Parse(breite) / 2).ToString();

            return double.Parse(SchwerpunktX);
        }
        public double BerechnungSchwerpunktY(string höhe, string breite, string wandstärke)
        {
            Breite = breite;
            Höhe = höhe;
            Wandstärke = wandstärke;
            double h = double.Parse(höhe);
            double b = double.Parse(breite);
            double w = double.Parse(wandstärke);
            double hi = h - w;
            double a1 = w * hi;
            double a2 = b * w;

            double temp =((a1*(hi/2))+(a2*(h-(w/2))) )/(a1+a2);

            SchwerpunktY = temp.ToString();
            SchwerpunktY = (Math.Round(double.Parse(FlächenträgheitsmomentIxx), 3)).ToString();
            return double.Parse(SchwerpunktY);
        }
        public double BerechnungSchwerpunktZ(string länge)
        {
            SchwerpunktZ = (double.Parse(länge) / 2).ToString();
            SchwerpunktZ = (Math.Round(double.Parse(FlächenträgheitsmomentIxx), 3)).ToString();
            return double.Parse(SchwerpunktZ);
        }

        public double BerechnungFlächenträgheitsmomentIxx(string breite, string höhe, string wandstärke)
        {

            double b = double.Parse(breite) / 10;
            double h = double.Parse(höhe) / 10;
            double w = double.Parse(wandstärke) / 10;

            FlächenträgheitsmomentIxx = ((w * Math.Pow(b / 2, 3) + (h - w) * Math.Pow(w, 3)) / 12).ToString();

            FlächenträgheitsmomentIxx = (Math.Round(double.Parse(FlächenträgheitsmomentIxx), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIxx);
        }
        public double BerechnungFlächenträgheitsmomentIyy()
        {


            FlächenträgheitsmomentIyy = "0";

            return double.Parse(FlächenträgheitsmomentIyy);
        }
    }

    public class Uprofil : ProfilModel
    {
        public string Breite { get; set; }

        public string Höhe { get; set; }

        public string Wandstärke { get; set; }

        public double BerechnungQuerschnittsfläche(string breite, string höhe, string wandstärke)
        {
            Breite = breite;

            Höhe = höhe;

            Wandstärke = wandstärke;

            Querschnittsfläche = ((double.Parse(breite) * double.Parse(höhe)) - ((double.Parse(breite) - (2 * double.Parse(wandstärke))) * (double.Parse(höhe) - double.Parse(wandstärke)))).ToString();
            Querschnittsfläche = (Math.Round(double.Parse(Querschnittsfläche), 3)).ToString();

            return double.Parse(Querschnittsfläche);
        }
        public double BerechnungSchwerpunktX(string breite, string höhe, string wandstärke)
        {
            Breite = breite;

            Höhe = höhe;

            Wandstärke = wandstärke;

            SchwerpunktX = (double.Parse(Breite) / 2).ToString();
            //((double.Parse(wandstärke) / 2) * (double.Parse(wandstärke) * double.Parse(höhe))) + ((double.Parse(breite) / 2) * ((double.Parse(breite) - (2 * double.Parse(wandstärke))) * double.Parse(wandstärke))) + ((double.Parse(breite) - (double.Parse(wandstärke) / 2)) * (double.Parse(wandstärke) * double.Parse(höhe))) / (double.Parse(wandstärke) * double.Parse(höhe)) + ((double.Parse(breite) - (2 * double.Parse(wandstärke))) * double.Parse(wandstärke)) + (double.Parse(wandstärke) * double.Parse(höhe)).ToString();

            return double.Parse(SchwerpunktX);
        }
        public double BerechnungSchwerpunktY(string breite, string höhe, string wandstärke)
        {
            Breite = breite;
            double b = double.Parse(breite);
            Höhe = höhe;
            double h = double.Parse(höhe);
            Wandstärke = wandstärke;
            double s = double.Parse(wandstärke);
            SchwerpunktY = (((((h / 2) * h * s) * 2) + ((s / 2) * ((b - (2 * s)) * s))) / ((h * s) + ((b - (2 * s)) * s) + (h * s))).ToString();

            return double.Parse(SchwerpunktY);
        }
        public double BerechnungSchwerpunktZ(string länge)
        {
            SchwerpunktZ = (double.Parse(länge) / 2).ToString();

            return double.Parse(SchwerpunktZ);
        }

        public double BerechnungFlächenträgheitsmomentIyy(string breite, string höhe, string wandstärke)
        {
            double a;
            double b = double.Parse(breite) / 10;
            double h = double.Parse(höhe) / 10;
            double w = double.Parse(wandstärke) / 10;
            a = (1 / 12);
            //FlächenträgheitsmomentIyy = (h * Math.Pow(h, 3) - (h - w) * (b - Math.Pow((2 * w), 3) * (a))).ToString();
            //FlächenträgheitsmomentIyy = (double.Parse(höhe) * Math.Pow(double.Parse(höhe), 3) - (double.Parse(höhe) - double.Parse(wandstärke)) * (double.Parse(breite) - Math.Pow((2 * double.Parse(wandstärke)), 3) * (a))).ToString();
            FlächenträgheitsmomentIyy = (((h * Math.Pow(b, 3) - (h - w) * (b - Math.Pow((2 * w), 3))) * a)).ToString();
            FlächenträgheitsmomentIyy = (h * Math.Pow(b, 3) - (h - w) * Math.Pow((b - (2 * w)), 3) * a).ToString();
            FlächenträgheitsmomentIyy = (Math.Round(double.Parse(FlächenträgheitsmomentIyy), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIyy);
            return double.Parse(FlächenträgheitsmomentIyy);
        }
        public double BerechnungFlächenträgheitsmomentIxx()
        {
            FlächenträgheitsmomentIxx = "0";

            return double.Parse(FlächenträgheitsmomentIxx);
        }
    }

    public class HProfil : ProfilModel
    {
        public string Höhe { get; set; }
        public string Breite { get; set; }
        public string InnenBreite { get; set; }
        public string InnenHöhe { get; set; }

        public double BerechnungQuerschnittsfläche(string höhe, string breite, string innenHöhe, string innenBreite)
        {
            Höhe = höhe;
            Breite = breite;
            InnenBreite = innenBreite;
            InnenHöhe = innenHöhe;

            Querschnittsfläche = ((double.Parse(Breite) * double.Parse(Höhe)) - 2 * (double.Parse(InnenBreite) * double.Parse(InnenHöhe))).ToString();
            Querschnittsfläche = (Math.Round(double.Parse(Querschnittsfläche), 3)).ToString();
            return double.Parse(Querschnittsfläche);
        }

        public double BerechnungSchwerpunktX()
        {
            SchwerpunktX = (double.Parse(Breite)) + (double.Parse(InnenBreite) / 2).ToString();
            return double.Parse(SchwerpunktX);
        }
        public double BerechnungSchwerpunktY()
        {
            SchwerpunktY = (double.Parse(Höhe) / 2).ToString();
            return double.Parse(SchwerpunktY);
        }
        public double BerechnungSchwerpunktZ(string länge)
        {

            SchwerpunktZ = (double.Parse(länge) / 2).ToString();
            return double.Parse(SchwerpunktZ);
        }


        public double BerechnungFlächenträgheitsmomentIxx()
        {
            double B = (double.Parse(Breite) / 10); //um das in cm^4 anzugeben
            double H = (double.Parse(Höhe) / 10);
            double a = (double.Parse(InnenBreite) / 10);
            double h = (double.Parse(InnenHöhe) / 10);
            FlächenträgheitsmomentIxx = (((Math.Pow(H, 3) * (B - a)) / 12) + a * (Math.Pow(h, 3))).ToString();
            FlächenträgheitsmomentIxx = (Math.Round(double.Parse(FlächenträgheitsmomentIxx), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIxx);
        }

        public double BerechnungFlächenträgheitsmomentIyy(string breite, string höhe)
        {
            double B = double.Parse(Breite) / 10; //um das in cm^4 anzugeben
            double H = double.Parse(Höhe) / 10;
            double a = double.Parse(InnenBreite) / 10;
            double h = double.Parse(InnenHöhe) / 10;
            FlächenträgheitsmomentIyy = (((Math.Pow(B - a, 3) * h) + h * (Math.Pow(a, 3))) / 12).ToString();
            FlächenträgheitsmomentIyy = (Math.Round(double.Parse(FlächenträgheitsmomentIyy), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIyy);
        }
    }


    public class WinkelProfil : ProfilModel           // Winkelprofil Erbt die Eigenschaften und Methoden von Profil
    {
        // Klassenspeziefische Eigenschaften 
        public string Höhe { get; set; }
        public string Breite { get; set; }
        public string Wandstärke { get; set; }
        // Klassenspeziefische Methoden
        // Berechnungen 
        public double BerechnungQuerschnittsfläche(string breite, string höhe, string wandsträrke)
        {
            Breite = breite;
            Höhe = höhe;
            Wandstärke = wandsträrke;
            Querschnittsfläche = (double.Parse(Breite) * double.Parse(Wandstärke) + (double.Parse(Höhe) - double.Parse(Wandstärke)) * double.Parse(Wandstärke)).ToString();
            Querschnittsfläche = (Math.Round(double.Parse(Querschnittsfläche), 3)).ToString();
            return double.Parse(Querschnittsfläche);                 // Gibt Querschnittsfläche als double zurück
        }
        public double BerechnungSchwerpunktX(string breite, string höhe, string wandsträrke)
        {
            Breite = breite;
            Höhe = höhe;
            Wandstärke = wandsträrke;
            //SchwerpunktX = (double.Parse(breite) / 2).ToString();
            SchwerpunktX = ((((double.Parse(Breite) / 2) * double.Parse(Breite) * double.Parse(Wandstärke)) + ((double.Parse(Wandstärke) / 2) * double.Parse(Höhe) * double.Parse(Wandstärke))) / (double.Parse(Breite) * double.Parse(Wandstärke) + double.Parse(Höhe) * double.Parse(Wandstärke))).ToString();
            return double.Parse(SchwerpunktX);
        }
        public double BerechnungSchwerpunktY(string breite, string höhe, string wandsträrke)
        {
            Breite = breite;
            Höhe = höhe;
            Wandstärke = wandsträrke;
            //SchwerpunktY = (double.Parse(höhe) / 2).ToString();
            SchwerpunktY = ((((double.Parse(Wandstärke) / 2) * double.Parse(Breite) * double.Parse(Wandstärke)) + (((double.Parse(Wandstärke) + double.Parse(Höhe) / 2)) * double.Parse(Höhe) * double.Parse(Wandstärke))) / (double.Parse(Breite) * double.Parse(Wandstärke) + double.Parse(Höhe) * double.Parse(Wandstärke))).ToString();

            return double.Parse(SchwerpunktY);
        }
        public double BerechnungSchwerpunktZ(string länge)
        {
            SchwerpunktZ = (double.Parse(länge) / 2).ToString();
            return double.Parse(SchwerpunktZ);
        }

        public double BerechnungFlächenträgheitsmomentIxx(string breite, string höhe, string wandstärke)
        {
            double b = double.Parse(breite) / 10; //um das in cm^4 anzugeben
            double h = double.Parse(höhe) / 10;
            double w = double.Parse(wandstärke) / 10;
            FlächenträgheitsmomentIxx = (((Math.Pow(h, 3) * b) / 12) + ((Math.Pow(((w / 2) - double.Parse(SchwerpunktX)), 2))) * h * w + ((Math.Pow(h, 3) * b) / 12) + ((Math.Pow(((b / 2) - double.Parse(SchwerpunktX)), 2))) * b * w).ToString();
            FlächenträgheitsmomentIxx = (Math.Round(double.Parse(FlächenträgheitsmomentIxx), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIxx);
        }

        public double BerechnungFlächenträgheitsmomentIyy(string breite, string höhe, string wandstärke)
        {
            double b = double.Parse(breite) / 10;
            double h = double.Parse(höhe) / 10;
            double w = double.Parse(wandstärke) / 10;
            FlächenträgheitsmomentIyy = (((Math.Pow(b, 3) * h) / 12) + ((Math.Pow((((h / 2) + w) - double.Parse(SchwerpunktY)), 2))) * h * (w) + ((Math.Pow(b, 3) * h) / 12) + ((Math.Pow(((b / 2) - double.Parse(SchwerpunktY)), 2))) * b * w).ToString();
            FlächenträgheitsmomentIyy = (Math.Round(double.Parse(FlächenträgheitsmomentIyy), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIyy);
        }

    }




    public class ZProfil : ProfilModel
    {
        public string Höhe { get; set; }
        public string Breite { get; set; }
        public string Wandstärke { get; set; }

        public double BerechnungQuerschnittsfläche(string höhe, string breite, string wandstärke)
        {
            Höhe = höhe;
            Breite = breite;
            Wandstärke = wandstärke;
            double a = double.Parse(höhe);
            double b = double.Parse(breite);
            double c = double.Parse(wandstärke);

            //Querschnittsfläche = ((((double.Parse(Breite) * 2) - double.Parse(Wandstärke)) * double.Parse(Höhe)) - (2 *((double.Parse(Breite) - double.Parse(Wandstärke))) * ((double.Parse(Höhe) - double.Parse(Wandstärke))))).ToString();
            Querschnittsfläche = ((double.Parse(Höhe) * (double.Parse(Breite) - double.Parse(Wandstärke) + double.Parse(Breite))) - (((double.Parse(Höhe) - double.Parse(Wandstärke)) * (double.Parse(Breite) - double.Parse(Wandstärke))) * 2)).ToString();
            Querschnittsfläche = (Math.Round(double.Parse(Querschnittsfläche), 3)).ToString();
            return double.Parse(Querschnittsfläche);
        }

        public double BerechnungSchwerpunktX()
        {


            SchwerpunktX = (double.Parse(Breite) - (double.Parse(Wandstärke) / 2)).ToString();
            return double.Parse(SchwerpunktX);
        }
        public double BerechnungSchwerpunktY()
        {


            SchwerpunktY = (double.Parse(Höhe) / 2).ToString();
            return double.Parse(SchwerpunktY);
        }
        public double BerechnungSchwerpunktZ(string länge)
        {



            SchwerpunktZ = (double.Parse(länge) / 2).ToString();
            return double.Parse(SchwerpunktZ);
        }


        public double BerechnungFlächenträgheitsmomentIxx()
        {
            double b = (double.Parse(Höhe) / 10); //um das in cm^4 anzugeben
            double s = (double.Parse(Wandstärke) / 10);
            double a = (double.Parse(Breite) / 10);


            FlächenträgheitsmomentIxx = (((Math.Pow(s, 3) * (a)) / 6) + s * (Math.Pow((b - s), 3) / 12)).ToString();

            FlächenträgheitsmomentIxx = (Math.Round(double.Parse(FlächenträgheitsmomentIxx), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIxx);
        }

        public double BerechnungFlächenträgheitsmomentIyy()

        {

            double b = (double.Parse(Höhe) / 10); //um das in cm^4 anzugeben
            double s = (double.Parse(Wandstärke) / 10);
            double a = (double.Parse(Breite) / 10);

            FlächenträgheitsmomentIyy = (((Math.Pow(a, 3) * (s)) / 6) + (b - s) * (Math.Pow((s), 3) / 12)).ToString();

            FlächenträgheitsmomentIyy = (Math.Round(double.Parse(FlächenträgheitsmomentIyy), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIyy);
        }
    }

    public class RechteckrohrProfil : ProfilModel           // Winkelprofil Erbt die Eigenschaften und Methoden von Profil
    {
        public string Höhe { get; set; }
        public string Breite { get; set; }
        public string Wandstärke { get; set; }
        // Klassenspeziefische Methoden
        // Berechnungen 
        public double BerechnungQuerschnittsfläche(string breite, string höhe, string wandstärke)
        {
            Breite = breite;
            Höhe = höhe;
            Wandstärke = wandstärke;
            Querschnittsfläche = ((double.Parse(Breite) * double.Parse(Höhe)) - ((double.Parse(Breite) - (double.Parse(Wandstärke) * 2)) * (double.Parse(Höhe) - (double.Parse(Wandstärke) * 2)))).ToString();
            Querschnittsfläche = (Math.Round(double.Parse(Querschnittsfläche), 3)).ToString();
            return double.Parse(Querschnittsfläche);                 // Gibt Querschnittsfläche als double zurück
        }
        public double BerechnungSchwerpunktX(string breite)
        {
            //SchwerpunktX = ((double.Parse(breite)*double.Parse(Wandstärke) / 2).ToString();
            SchwerpunktX = (double.Parse(breite) / 2).ToString();
            return double.Parse(SchwerpunktX);
        }
        public double BerechnungSchwerpunktY(string höhe)
        {
            //SchwerpunktY = (((double.Parse(höhe)-double.Parse(Wandstärke))*double.Parse(Wandstärke)) / 2).ToString();
            SchwerpunktY = (double.Parse(höhe) / 2).ToString();
            return double.Parse(SchwerpunktY);
        }
        public double BerechnungSchwerpunktZ(string länge)
        {
            SchwerpunktZ = (double.Parse(länge) / 2).ToString();
            return double.Parse(SchwerpunktZ);
        }

        public double BerechnungFlächenträgheitsmomentIxx(string breite, string höhe)
        {
            double b = double.Parse(breite) / 10; //um das in cm^4 anzugeben
            double h = double.Parse(höhe) / 10;
            FlächenträgheitsmomentIxx = (((Math.Pow(h, 3) * b) / 12)).ToString();
            FlächenträgheitsmomentIxx = (Math.Round(double.Parse(FlächenträgheitsmomentIxx), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIxx);
        }

        public double BerechnungFlächenträgheitsmomentIyy(string breite, string höhe)
        {
            double b = double.Parse(breite) / 10;
            double h = double.Parse(höhe) / 10;
            FlächenträgheitsmomentIyy = (((Math.Pow(b, 3) * h) / 12)).ToString();
            FlächenträgheitsmomentIyy = (Math.Round(double.Parse(FlächenträgheitsmomentIyy), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIyy);
        }        // Klassenspeziefische Eigenschaften 

    }

    public class VierkantrohrProfil : ProfilModel           // Winkelprofil Erbt die Eigenschaften und Methoden von Profil
    {
        public string Höhe { get; set; }
        public string Breite { get; set; }
        public string Wandstärke { get; set; }
        // Klassenspeziefische Methoden
        // Berechnungen 
        public double BerechnungQuerschnittsfläche(string breite, string höhe, string wandstärke)
        {
            Breite = breite;
            Höhe = höhe;
            Wandstärke = wandstärke;
            Querschnittsfläche = ((double.Parse(Breite) * double.Parse(Höhe)) - ((double.Parse(Breite) - (double.Parse(Wandstärke) * 2)) * (double.Parse(Höhe) - (double.Parse(Wandstärke) * 2)))).ToString();
            Querschnittsfläche = (Math.Round(double.Parse(Querschnittsfläche), 3)).ToString();
            return double.Parse(Querschnittsfläche);                 // Gibt Querschnittsfläche als double zurück
        }
        public double BerechnungSchwerpunktX(string breite)
        {
            //SchwerpunktX = ((double.Parse(breite)*double.Parse(Wandstärke) / 2).ToString();
            SchwerpunktX = (double.Parse(breite) / 2).ToString();
            return double.Parse(SchwerpunktX);
        }
        public double BerechnungSchwerpunktY(string höhe)
        {
            //SchwerpunktY = (((double.Parse(höhe)-double.Parse(Wandstärke))*double.Parse(Wandstärke)) / 2).ToString();
            SchwerpunktY = (double.Parse(höhe) / 2).ToString();
            return double.Parse(SchwerpunktY);
        }
        public double BerechnungSchwerpunktZ(string länge)
        {
            SchwerpunktZ = (double.Parse(länge) / 2).ToString();
            return double.Parse(SchwerpunktZ);
        }

        public double BerechnungFlächenträgheitsmomentIxx(string breite, string höhe)
        {
            double b = double.Parse(breite) / 10; //um das in cm^4 anzugeben
            double h = double.Parse(höhe) / 10;
            FlächenträgheitsmomentIxx = (((Math.Pow(h, 3) * b) / 12)).ToString();
            FlächenträgheitsmomentIxx = (Math.Round(double.Parse(FlächenträgheitsmomentIxx), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIxx);
        }

        public double BerechnungFlächenträgheitsmomentIyy(string breite, string höhe)
        {
            double b = double.Parse(breite) / 10;
            double h = double.Parse(höhe) / 10;
            FlächenträgheitsmomentIyy = (((Math.Pow(b, 3) * h) / 12)).ToString();
            FlächenträgheitsmomentIyy = (Math.Round(double.Parse(FlächenträgheitsmomentIyy), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIyy);
        }        // Klassenspeziefische Eigenschaften 
    }


}