using System;

namespace Berechnungs_Tool
{
    class Program
    {
        static void ausgabe()
        {

        }
        static void Main(string[] args)
        {

            // Variablen deklarieren


            double aa;                  // breite der Seite a Breite

            double bb;                  // höhe der Seite b Höhe

            double cc;                  // länge der Seite c Länge

            double dd;                  // länge für Trapez

            double rr;                  // Radius des Kreises

            double rri;                 // Radius Innenkreis



            string eingabe;                // gewünschtes Profil

            double flächeninhalt;      // Flächeninhalt

            double volumen;            // Volumen

            double masse;


            double stahl = 7.85;                                                                    // Datenbank einbinden xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

            double aluminium = 2.71;                                                                // Datenbank einbinden xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

            int material;                // Auswahl des Materials

            double schwerpunktxs;

            double schwerpunktys;

            double Ixx;             // Flächenträgsheitsmoment x-Achse

            double Iyy;             // Flächenträgheitsmoment y-Achse

        sprungmarke:                                                                              // Sprungmarke
            
            
                                                                                                   // Eingabe initialisieren
            Console.WriteLine("Welches Profil möchten Sie berechnen ?");
            Console.WriteLine("Zur Auswahl stehen:");
            Console.WriteLine("Profil Rechteck: 1");
            Console.WriteLine("Profil Kreis:    2");
            Console.WriteLine("Profil Kreisring:3");
            Console.WriteLine("Profil GsDreieck:4");
            Console.WriteLine("Profil SymTrapez:5");
            Console.WriteLine("Geben Sie die entsprechende Zahl ein um fortzufahren");
            //eingabe = int.Parse(Console.ReadLine());
            eingabe = string.Format(Console.ReadLine());

            Console.Clear();


            if (eingabe == "1")                                           //abfrage für Rechteckprofil
            {

                Console.WriteLine("Eingabe der Breite");                 //Eingabe der Parameter
                aa = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Eingabe der Höhe");
                bb = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Eingabe der Länge");
                cc = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Material des Körpers");
                Console.WriteLine("0-Anderen Körper wählen, 1-Stahl, 2-Aluminium");

                material = int.Parse(Console.ReadLine());

                Console.Clear();

                flächeninhalt = aa * bb;                                // Berechnung 

                volumen = flächeninhalt * cc;

                schwerpunktxs = (aa / 2 * flächeninhalt) / flächeninhalt;

                schwerpunktys = (bb / 2 * flächeninhalt) / flächeninhalt;

                Ixx = (aa * Math.Pow(bb, 3)) / 12;

                Iyy = (bb * Math.Pow(aa, 3)) / 12;

                masse = volumen * stahl;   

                if (material == 1)                                      // Abfrage Material
                {
                                             

                    Console.Write("Breite (a):");
                    Console.WriteLine(aa);
                    Console.Write("Höhe (b):");
                    Console.WriteLine(bb);
                    Console.Write("Länge (c):");
                    Console.WriteLine(cc);
                    Console.Write("Der Flächeninhalt beträgt:");        // Ausgabe der Werte
                    Console.WriteLine(flächeninhalt);
                    Console.Write("Das Volumen beträgt:");
                    Console.WriteLine(volumen);
                    Console.Write("Die Masse beträgt:");
                    Console.WriteLine(masse);
                    Console.WriteLine("Koordinatenursprung: Ecke unten Links");
                    Console.Write("Der Schwerpunkt der x-Koordinate liegt bei:");
                    Console.WriteLine(schwerpunktxs);
                    Console.Write("Der Schwerpunkt der y-Koordinate liegt bei:");
                    Console.WriteLine(schwerpunktys);
                    Console.Write("Flächenträgheitsmoment Ixx=");
                    Console.WriteLine(Ixx);
                    Console.Write("Flächenträgheitsmoment Iyy=");
                    Console.Write(Iyy);

                    Console.ReadLine();

                }
                if (material == 0)                                      //zurück zur Profil Auwahl <- anderes verfahren finden!xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                {
                    goto sprungmarke;
                }
            }

            else if (eingabe == "2")                                           //abfrage für Kreisprofil
            {
                Console.WriteLine("Eingabe des Radius");
                rr = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Eingabe der Länge");
                cc = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Material des Körpers");
                Console.WriteLine("0-Anderen Körper wählen, 1-Stahl, 2-Aluminium");

                material = int.Parse(Console.ReadLine());

                Console.Clear();

                flächeninhalt = Math.Pow(rr, 2) * Math.PI;               //berechnungen Kreisprofil

                volumen = flächeninhalt * cc;

                masse = volumen * stahl;

                Ixx = (Math.PI / 4) * (Math.Pow(rr, 4));

                if (material == 1)                                      // Material Abfrage
                {
                  
                    Console.Write("Radius (r):");
                    Console.WriteLine(rr);
                    Console.Write("Länge:");
                    Console.WriteLine(cc);
                    Console.Write("Der Flächeninhalt beträgt:");        // Ausgabe der Werte
                    Console.WriteLine(flächeninhalt);
                    Console.Write("Das Volumen beträgt:");
                    Console.WriteLine(volumen);
                    Console.Write("Die Masse beträgt:");
                    Console.WriteLine(masse);
                    Console.Write("Flächenträgheitsmoment: Ixx=Iyy=");
                    Console.WriteLine(Ixx);

                    Console.ReadLine();
                }

                if (material == 0)                                         // zurück zur Profilauswahl <- anderes verfahren finden!xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                {
                    goto sprungmarke;
                }
            }

            else if (eingabe == "3")                                           //abfrage für Kreisring Profil
            {
                Console.WriteLine("Eingabe des Außen-Radius");
                rr = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Eingabe des Innen-Radius");
                rri = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Eingabe der Länge");
                cc = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Material des Körpers");
                Console.WriteLine("0-Anderen Körper wählen, 1-Stahl, 2-Aluminium");
                material = int.Parse(Console.ReadLine());

                Console.Clear();

                flächeninhalt = Math.PI * (Math.Pow(rr, 2) - Math.Pow(rri, 2));               //berechnungen Kreisring profil

                volumen = flächeninhalt * cc;

                Ixx = (Math.PI / 4) * (Math.Pow(rr, 4) - Math.Pow(rri, 4));

                masse = volumen * stahl;

                if (material == 1)                                      // Material Abfrage
                {
                    
                    Console.Write("Außen-Radius (R):");
                    Console.WriteLine(rr);
                    Console.Write("Innen-Radius (r):");
                    Console.WriteLine(rri);
                    Console.Write("Länge:");
                    Console.WriteLine(cc);
                    Console.Write("Der Flächeninhalt beträgt:");        // Ausgabe der Werte
                    Console.WriteLine(flächeninhalt);              
                    Console.Write("Das Volumen beträgt:");
                    Console.WriteLine(volumen);
                    Console.Write("Die Masse beträgt:");
                    Console.WriteLine(masse);
                    Console.Write("Flächenträgheitsmoment Ixx=Iyy=");               // Ausgabe in cm^4 von anderen einheiten xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    Console.WriteLine(Ixx);
                    Console.ReadLine();

                }

                if (material == 0)                                          //zurück zur Profilauswahl <- anderes verfahren finden! xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                {
                    goto sprungmarke;
                }
            }

            else if (eingabe == "4")                                           // Abfrage für Gleichschenkeliges Dreieck
            {
                Console.WriteLine("Eingabe der Breite");
                aa = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Eingabe der Höhe");
                bb = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Eingabe der Länge");
                cc = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Material des Körpers");
                Console.WriteLine("0-Anderen Körper wählen, 1-Stahl, 2-Aluminium");
                material = int.Parse(Console.ReadLine());



                flächeninhalt = (aa * bb) / 2;                          //berechnungen Gleichschenkeliges Dreieck

                volumen = flächeninhalt * cc;

                masse = volumen * stahl;

                schwerpunktxs = (aa / 2);

                schwerpunktys = (bb * 0.333);                                             //Hier ausgabe nur mit 0.333 nicht mit 1/3 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

                Ixx = (aa * Math.Pow(bb, 3)) / 36;

                Iyy = (bb * Math.Pow(aa, 3)) / 48;



                if (material == 1)
                {
                   
                    Console.Write("Breite (a):");
                    Console.WriteLine(aa);
                    Console.Write("Höhe (h):");
                    Console.WriteLine(bb);
                    Console.Write("Länge (c):");
                    Console.WriteLine(cc);
                    Console.Write("Der Flächeninhalt beträgt:");                                // Ausgabe der Werte
                    Console.WriteLine(flächeninhalt);
                    Console.Write("Das Volumen beträgt:");
                    Console.WriteLine(volumen);
                    Console.Write("Die Masse beträgt:");
                    Console.WriteLine(masse);
                    Console.WriteLine("Koordinatenursprung: Ecke unten Links");
                    Console.Write("Der Schwerpunkt der x-Koordinate liegt bei:");
                    Console.WriteLine(schwerpunktxs);
                    Console.Write("Der Schwerpunkt der y-Koordinate liegt bei:");
                    Console.WriteLine(schwerpunktys);
                    Console.Write("Flächenträgheitsmoment Ixx=");
                    Console.WriteLine(Ixx);
                    Console.Write("Flächenträgheitsmoment Iyy=");
                    Console.WriteLine(Iyy);
                    Console.ReadLine();

                }
                if (material == 0)                                                              // zurück zur Profilauswahl <- anderes verfahren finden!xxxxxxxxxxxxxxxxxxxxxxxxxxxx
                {
                    goto sprungmarke;
                }

            }


            else if (eingabe == "5")                                           // Abfrage für Symmetrisches Trapez
            {
                Console.WriteLine("Eingabe der Breite unten (b1)");
                aa = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Eingabe der Breite oben (b2)");
                bb = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Eingabe der Höhe (h)");
                cc = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Eingabe der Länge");
                dd = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Material des Körpers");
                Console.WriteLine("0-Anderen Körper wählen, 1-Stahl, 2-Aluminium");
                material = int.Parse(Console.ReadLine());

                Console.Clear();

                flächeninhalt = (aa + bb) * (cc / 2);                          //berechnungen Symmetrisches Trapez

                volumen = flächeninhalt * dd;

                Ixx = (Math.Pow(cc, 3) * (Math.Pow(bb - aa, 2)) + 2 * aa * bb) / 36 * (aa + bb);

                Iyy = (cc / 48) * (aa + bb) * (Math.Pow(aa, 2) + (Math.Pow(bb, 2)));

                masse = volumen * stahl;

                if (material == 1)
                {
                    
                    Console.Write("Breite unten (b1):");
                    Console.WriteLine(aa);
                    Console.Write("Breite oben (b2):");
                    Console.WriteLine(bb);
                    Console.Write("Höhe (h):");
                    Console.WriteLine(cc);
                    Console.Write("Länge:");
                    Console.WriteLine(dd);
                    Console.Write("Der Flächeninhalt beträgt:");                                // Ausgabe der Werte
                    Console.WriteLine(flächeninhalt);
                    Console.Write("Das Volumen beträgt:");
                    Console.WriteLine(volumen);
                    Console.Write("Die Masse beträgt:");
                    Console.WriteLine(masse);
                    Console.Write("Flächenträgheitsmoment Ixx=");
                    Console.WriteLine(Ixx);
                    Console.Write("Flächenträgheitsmoment Iyy=");
                    Console.WriteLine(Iyy);
                    Console.ReadLine();
                }

                if (material == 0)                                                              // zurück zur Profilauswahl <- anderes verfahren finden!xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                {
                    goto sprungmarke;
                }
            }
            else
            {
                Console.WriteLine("falsche eingabe");
                Console.ReadKey();
                Console.Clear();
                goto sprungmarke;
            }
        }
    }
}
