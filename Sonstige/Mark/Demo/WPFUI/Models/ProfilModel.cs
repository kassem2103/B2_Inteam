using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.Models
{
   public class ProfilModel
    {

        // Eigenschaften die Vererbar sind
        public string ArtName { get; set; }    // der Einmalige Name bzw Primärschlüssel jedes Profiles 
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
            return double.Parse(Volumen);
        }
        // Berechnet das Gewicht
        public double BerechnungGewicht(MaterialModel material)
        {
            // Objekt wird übergeben
            MaterialModel materialModel = material;
            Material = materialModel.MaterialName;
            // Material wird einer dichte zugeordenet
            //if (materialModel.MaterialName == "Stahl")
            //{
            //    dichte = materialModel.MaterialDichte;
            //}
            //else if (materialModel.MaterialName == "Alu")
            //{
            //    dichte = materialModel.MaterialDichte;
            //}
            //else if (materialModel.MaterialName == "Kupfer")
            //{
            //    dichte = materialModel.MaterialDichte;
            //}
            //else if (materialModel.MaterialName == "AlCu")
            //{
            //    dichte = materialModel.MaterialDichte;
            //}
            Gewicht = (materialModel.MaterialDichte * (double.Parse(Volumen)/1000000)).ToString(); //wegen umrechnung mm in cm
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
            return double.Parse(Querschnittsfläche);                 // Gibt Querschnittsfläche als double zurück
        }
        public double BerechnungSchwerpunktX(string breite)
        {
            SchwerpunktX = (double.Parse(breite)/2).ToString();
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
            double b = double.Parse(breite)/10; //um das in cm^4 anzugeben
            double h = double.Parse(höhe)/10;
            FlächenträgheitsmomentIxx = (((Math.Pow(h,3)*b)/12)).ToString();
            FlächenträgheitsmomentIxx = (Math.Round(double.Parse(FlächenträgheitsmomentIxx), 3)).ToString();
            return double.Parse(FlächenträgheitsmomentIxx);
        }

        public double BerechnungFlächenträgheitsmomentIyy(string breite, string höhe)
        {
            double b = double.Parse(breite)/10;
            double h = double.Parse(höhe)/10;
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
            Querschnittsfläche = (Math.PI * Math.Pow((double.Parse(durchmesser) / 2), 2)).ToString();          // PI * R^2
            return double.Parse(Querschnittsfläche);                 // Gibt Querschnittsfläche als double zurück
        }                                              // Und Querschnitt kriegt ein Wert

        public double BerechnungSchwerpunktX(string durchmesser)
        {
            SchwerpunktX = (double.Parse(durchmesser) / 2).ToString();
            return double.Parse(SchwerpunktX);
        }
        public double BerechnungSchwerpunktY(string durchmesser)
        {
            SchwerpunktY = (double.Parse(durchmesser) / 2).ToString();
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

        // Ende der KreisProfilKlasse
    }


      public  class RohrProfil : ProfilModel
      {
        public string AußenDurchmesser { get; set; }
        public string Wandstärke { get; set; }



        public double BerechnungQuerschnittsfläche()
        {
            Querschnittsfläche = ((Math.PI * Math.Pow((double.Parse(AußenDurchmesser) / 2), 2)) - (Math.PI * Math.Pow(((double.Parse(AußenDurchmesser) / 2) - double.Parse(Wandstärke)), 2))).ToString(); // Ganze Fläche Minus Das was in der Mitte des Rohres fehlt
            return double.Parse(Querschnittsfläche);                 // 
        }
        public double BerechnungSchwerpunktX(string länge)
        {
            SchwerpunktX = "0" ;

            return double.Parse(SchwerpunktX);
        }
        public double BerechnungSchwerpunktY(string länge)
        {
            SchwerpunktY = "0" ;

            return double.Parse(SchwerpunktY);
        }
        public double BerechnungSchwerpunktZ(string länge)
        {
            SchwerpunktZ = (double.Parse(länge) / 2).ToString();

            return double.Parse (SchwerpunktZ);
        }

        public double BerechnungFlächenträgheitsmomentIxx()
        {
            FlächenträgheitsmomentIxx = ((Math.PI / 4) * (Math.Pow(double.Parse(AußenDurchmesser), 4) - Math.Pow(double.Parse(AußenDurchmesser) - 2 * double.Parse(Wandstärke), 4))).ToString();

            return double.Parse (FlächenträgheitsmomentIxx);
        }

        public double BerechnungFlächenträgheitsmomentIyy()
        {
            FlächenträgheitsmomentIyy = ((Math.PI / 4) * (Math.Pow(double.Parse(AußenDurchmesser), 4) - Math.Pow(double.Parse(AußenDurchmesser) - 2 * double.Parse(Wandstärke), 4))).ToString();

            return double.Parse (FlächenträgheitsmomentIyy);
        }
    }
    class Tprofil : ProfilModel
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

            SchwerpunktY = ((double.Parse(höhe) - double.Parse(wandstärke)) / 2) * ((double.Parse(höhe) - double.Parse(wandstärke)) * double.Parse(wandstärke)) + ((double.Parse(höhe) + (double.Parse(wandstärke) / 2)) * (double.Parse(breite) * double.Parse(wandstärke))).ToString();

            return double.Parse(SchwerpunktY);
        }
        public double BerechnungSchwerpunktZ(string länge)
        {
            SchwerpunktZ = (double.Parse(länge) / 2).ToString();

            return double.Parse(SchwerpunktZ);
        }

        public double BerechnungFlächenträgheitsmomentIxx(string breite, string höhe, string wandstärke)
        {
            Breite = breite;

            Höhe = höhe;

            Wandstärke = wandstärke;

            FlächenträgheitsmomentIxx = ((double.Parse(wandstärke) * Math.Pow(double.Parse(breite) / 2, 3) + (double.Parse(höhe) - double.Parse(wandstärke)) * Math.Pow(double.Parse(wandstärke), 3)) / 12).ToString();

            return double.Parse(FlächenträgheitsmomentIxx);
        }
    }

    class Uprofil : ProfilModel
    {
        public string Breite { get; set; }

        public string Höhe { get; set; }

        public string Wandstärke { get; set; }

        public double BerechnungQuerschnittsfläche(string breite, string höhe, string wandstärke)
        {
            Breite = breite;

            Höhe = höhe;

            Wandstärke = wandstärke;

            Querschnittsfläche = (2 * (double.Parse(höhe) * double.Parse(wandstärke))) + ((double.Parse(breite) - (2 * double.Parse(wandstärke))) * double.Parse(wandstärke)).ToString();

            return double.Parse(Querschnittsfläche);
        }
        public double BerechnungSchwerpunktX(string breite, string höhe, string wandstärke)
        {
            Breite = breite;

            Höhe = höhe;

            Wandstärke = wandstärke;

            SchwerpunktX = ((double.Parse(wandstärke) / 2) * (double.Parse(wandstärke) * double.Parse(höhe))) + ((double.Parse(breite) / 2) * ((double.Parse(breite) - (2 * double.Parse(wandstärke))) * double.Parse(wandstärke))) + ((double.Parse(breite) - (double.Parse(wandstärke) / 2)) * (double.Parse(wandstärke) * double.Parse(höhe))) / (double.Parse(wandstärke) * double.Parse(höhe)) + ((double.Parse(breite) - (2 * double.Parse(wandstärke))) * double.Parse(wandstärke)) + (double.Parse(wandstärke) * double.Parse(höhe)).ToString();

            return double.Parse(SchwerpunktX);
        }
        public double BerechnungSchwerpunktY(string breite, string höhe, string wandstärke)
        {
            Breite = breite;

            Höhe = höhe;

            Wandstärke = wandstärke;

            SchwerpunktY = ((double.Parse(höhe) / 2) * (double.Parse(wandstärke) * double.Parse(höhe))) + ((double.Parse(wandstärke) / 2) * (double.Parse(breite) - (double.Parse(wandstärke) * 2)) * double.Parse(wandstärke)) + ((double.Parse(höhe) / 2) * (double.Parse(wandstärke) * double.Parse(höhe))) / (double.Parse(wandstärke) * double.Parse(höhe)) + ((double.Parse(breite) - (double.Parse(wandstärke) * 2)) * double.Parse(wandstärke)) + (double.Parse(wandstärke) * double.Parse(höhe)).ToString();

            return double.Parse(SchwerpunktY);
        }
        public double BerechnungSchwerpunktZ(string länge)
        {
            SchwerpunktZ = (double.Parse(länge) / 2).ToString();

            return double.Parse(SchwerpunktZ);
        }

        public double BerechnungFlächenträgheitsmomentIyy()
        {
            FlächenträgheitsmomentIyy = ((1 / 12) * (double.Parse(Höhe) * Math.Pow(double.Parse(Breite), 3) - (double.Parse(Höhe) - double.Parse(Wandstärke)) * Math.Pow(double.Parse(Breite) - (2 * double.Parse(Wandstärke)), 3))).ToString();

            return double.Parse(FlächenträgheitsmomentIyy);
        }
    }
}
