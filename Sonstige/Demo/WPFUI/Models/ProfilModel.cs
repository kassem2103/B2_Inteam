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
        public string Material { get; set; }
        public string Preis { get; set; }
        public double Länge { get; set; }
        public double Querschnittsfläche { set; get; }
        public double Volumen { set; get; }
        public double Gewicht { set; get; }
        public double SchwerpunktX { set; get; }
        public double SchwerpunktY { set; get; }
        public double SchwerpunktZ { set; get; }
        public double FlächenträgheitsmomentIxx { get; set; }
        public double FlächenträgheitsmomentIyy { get; set; }

        private double dichte;

        

        // Methoden die Vererbar sind 
        public double BerechnungVolumen(string länge)
        {
            Länge = double.Parse(länge);
            Volumen = Querschnittsfläche * Länge;
            return Volumen;
        }
        // Berechnet das Gewicht
        public double BerechnungGewicht(MaterialModel material)
        {
            // Objekt wird übergeben
            MaterialModel materialModel = material;
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
            Gewicht = materialModel.MaterialDichte * Volumen;
            return Gewicht;
        }
    }
    class RechteckProfil : ProfilModel           // Rechteckprofil Erbt die Eigenschaften und Methoden von Profil
    {
        // Klassenspeziefische Eigenschaften 
        public double Höhe { get; set; }
        public double Breite { get; set; }

        // Klassenspeziefische Methoden
        // Berechnungen 
        public double BerechnungQuerschnittsfläche(string breite, string höhe)
        {
            Breite = double.Parse(breite);
            Höhe = double.Parse(höhe);
            Querschnittsfläche = Breite * Höhe;
            return Querschnittsfläche;                 // Gibt Querschnittsfläche als double zurück
        }
        public double BerechnungSchwerpunktX(string breite)
        {
            SchwerpunktX = double.Parse(breite)/2;
            return SchwerpunktX;
        }
        public double BerechnungSchwerpunktY(string höhe)
        {
            SchwerpunktY = double.Parse(höhe) / 2;
            return SchwerpunktY;
        }
        public double BerechnungSchwerpunktZ(string länge)
        {
            SchwerpunktZ = double.Parse(länge) / 2;
            return SchwerpunktZ;
        }

        public double BerechnungFlächenträgheitsmomentIxx(string breite, string höhe)
        {
            double b = double.Parse(breite);
            double h = double.Parse(höhe);
            FlächenträgheitsmomentIxx = ((Math.Pow(h,3)*b)/12);
            FlächenträgheitsmomentIxx = Math.Round(FlächenträgheitsmomentIxx, 3);
            return FlächenträgheitsmomentIxx;
        }

        public double BerechnungFlächenträgheitsmomentIyy(string breite, string höhe)
        {
            double b = double.Parse(breite);
            double h = double.Parse(höhe);
            FlächenträgheitsmomentIyy = ((Math.Pow(b, 3) * h) / 12);
            FlächenträgheitsmomentIyy = Math.Round(FlächenträgheitsmomentIyy, 3);
            return FlächenträgheitsmomentIyy;
        }

    }
    class KreisProfil : ProfilModel
    {
        // Anfang der Kreisprofil Klasse
        // Klassenspeziefische Eigenschaften 
        public double Durchmesser { get; set; }
        // Methoden der Klasse Kreisprofil

        public double BerechnungQuerschnittsfläche()            //Methode um Querschnittsfläche zu berechnen
        {
            Querschnittsfläche = Math.PI * Math.Pow((Durchmesser / 2), 2);          // PI * R^2
            return Querschnittsfläche;                 // Gibt Querschnittsfläche als double zurück
        }                                              // Und Querschnitt kriegt ein Wert

        public void BerechnungSchwerpunkt()
        {

        }

        public double BerechnungFlächenträgheitsmomentIxx()
        {


            return FlächenträgheitsmomentIxx;
        }

        // Ende der KreisProfilKlasse
    }


    class RohrProfil : ProfilModel
    {
        public double AußenDurchmesser { get; set; }
        public double Wandstärke { get; set; }


        public double BerechnungQuerschnittsfläche()
        {
            Querschnittsfläche = (Math.PI * Math.Pow((AußenDurchmesser / 2), 2)) - (Math.PI * Math.Pow(((AußenDurchmesser / 2) - Wandstärke), 2)); // Ganze Fläche Minus Das was in der Mitte des Rohres fehlt
            return Querschnittsfläche;                 // 
        }
    }
}
