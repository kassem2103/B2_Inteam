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



            int eingabe;                // gewünschtes Profil

            double flächeninhalt;      // Flächeninhalt

            double volumen;            // Volumen

            double masse;


            double stahl = 7.85;

            double aluminium = 2.71;

            int material;                // Auswahl des Materials

            double schwerpunktxs;

            double schwerpunktys;

            double Ixx;             // Flächenträgsheitsmoment x-Achse

            double Iyy;             // Flächenträgheitsmoment y-Achse

        sprungmarke:                                                                                   // Eingabe initialisieren
            Console.WriteLine("Welches Profil möchten Sie berechnen ?");
            Console.WriteLine("Zur Auswahl stehen:");
            Console.WriteLine("Profil Rechteck: 1");
            Console.WriteLine("Profil Kreis:    2");
            Console.WriteLine("Profil Kreisring:3");
            Console.WriteLine("Profil GsDreieck:4");
            Console.WriteLine("Profil SymTrapez:5");
            Console.WriteLine("Geben Sie die entsprechende Zahl ein um fortzufahren");
            eingabe = int.Parse(Console.ReadLine());
            Console.WriteLine(eingabe);


            if (eingabe == 1)                                           //abfrage für Rechteckprofil
            {

                Console.WriteLine("Eingabe der Breite");                 //Eingabe der Parameter
                aa = double.Parse(Console.ReadLine());

                Console.WriteLine("Eingabe der Höhe");
                bb = double.Parse(Console.ReadLine());

                Console.WriteLine("Eingabe der Länge");
                cc = double.Parse(Console.ReadLine());

                Console.WriteLine("Material des Körpers");
                Console.WriteLine("0-Anderen Körper wählen, 1-Stahl, 2-Aluminium");

                flächeninhalt = aa * bb;                                // Berechnung 

                volumen = flächeninhalt * cc;

                schwerpunktxs = (aa / 2 * flächeninhalt) / flächeninhalt;

                schwerpunktys = (bb / 2 * flächeninhalt) / flächeninhalt;

                Ixx = (aa * Math.Pow(bb, 3)) / 12;

                Iyy = (bb * Math.Pow(aa, 3)) / 12;



                material = int.Parse(Console.ReadLine());

                if (material == 1)                                      // Abfrage Material
                {
                    masse = volumen * stahl;                            // Berechnung


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


                }
                if (material == 0)                                      //zurück zur Profil Auwahl <- anderes verfahren finden!
                {
                    goto sprungmarke;
                }
            }

            if (eingabe == 2)                                           //abfrage für Kreisprofil
            {
                Console.WriteLine("Eingabe des Radius");
                rr = double.Parse(Console.ReadLine());
                Console.WriteLine("Eingabe der Länge");
                cc = double.Parse(Console.ReadLine());



                Console.WriteLine("Material des Körpers");
                Console.WriteLine("0-Anderen Körper wählen, 1-Stahl, 2-Aluminium");

                flächeninhalt = Math.Pow(rr, 2) * Math.PI;               //berechnungen Kreisprofil

                volumen = flächeninhalt * cc;

                material = int.Parse(Console.ReadLine());

                Ixx = (Math.PI / 4) * (Math.Pow(rr, 4));

                if (material == 1)                                      // Material Abfrage
                {
                    masse = volumen * stahl;

                    Console.Write("Der Flächeninhalt beträgt:");        // Ausgabe der Werte
                    Console.WriteLine(flächeninhalt);
                    Console.Write("Das Volumen beträgt:");
                    Console.WriteLine(volumen);
                    Console.Write("Die Masse beträgt:");
                    Console.WriteLine(masse);
                    Console.Write("Flächenträgheitsmoment Ixx=Iyy=");
                    Console.WriteLine(Ixx);
                }

                if (material == 0)                                         // zurück zur Profilauswahl <- anderes verfahren finden!
                {
                    goto sprungmarke;
                }



            }

            if (eingabe == 3)                                           //abfrage für Kreisring Profil
            {
                Console.WriteLine("Eingabe des Außen-Radius");
                rr = double.Parse(Console.ReadLine());
                Console.WriteLine("Eingabe des Innen-Radius");
                rri = double.Parse(Console.ReadLine());
                Console.WriteLine("Eingabe der Länge");
                cc = double.Parse(Console.ReadLine());



                Console.WriteLine("Material des Körpers");
                Console.WriteLine("0-Anderen Körper wählen, 1-Stahl, 2-Aluminium");

                flächeninhalt = Math.PI * (Math.Pow(rr, 2) - Math.Pow(rri, 2));               //berechnungen Kreisring profil

                volumen = flächeninhalt * cc;

                material = int.Parse(Console.ReadLine());

                Ixx = (Math.PI / 4) * (Math.Pow(rr, 4) - Math.Pow(rri, 4));

                if (material == 1)                                      // Material Abfrage
                {
                    masse = volumen * stahl;

                    Console.Write("Der Flächeninhalt beträgt:");        // Ausgabe der Werte
                    Console.WriteLine(flächeninhalt);
                    Console.Write("Das Volumen beträgt:");
                    Console.WriteLine(volumen);
                    Console.Write("Die Masse beträgt:");
                    Console.WriteLine(masse);
                    Console.Write("Flächenträgheitsmoment Ixx=Iyy=");
                    Console.WriteLine(Ixx);
                }

                if (material == 0)                                          //zurück zur Profilauswahl <- anderes verfahren finden!
                {
                    goto sprungmarke;
                }


            }

            if (eingabe == 4)                                           // Abfrage für Gleichschenkeliges Dreieck
            {
                Console.WriteLine("Eingabe der Breite");
                aa = double.Parse(Console.ReadLine());
                Console.WriteLine("Eingabe der Höhe");
                bb = double.Parse(Console.ReadLine());
                Console.WriteLine("Eingabe der Länge");
                cc = double.Parse(Console.ReadLine());

                Console.WriteLine("Material des Körpers");
                Console.WriteLine("0-Anderen Körper wählen, 1-Stahl, 2-Aluminium");

                flächeninhalt = (aa * bb) / 2;                          //berechnungen Gleichschenkeliges Dreieck

                volumen = flächeninhalt * cc;

                material = int.Parse(Console.ReadLine());



                if (material == 1)
                {
                    masse = volumen * stahl;

                    schwerpunktxs = (aa / 2);

                    schwerpunktys = (bb * (1 / 3));                                             // hier wird kein wert ausgegeben!!!!!

                    Ixx = (aa * Math.Pow(bb, 3)) / 36;

                    Iyy = (bb * Math.Pow(aa, 3)) / 48;




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


                }
                if (material == 0)                                                              // zurück zur Profilauswahl <- anderes verfahren finden!
                {
                    goto sprungmarke;
                }

            }


            if (eingabe == 5)                                           // Abfrage für Symmetrisches Trapez
            {
                Console.WriteLine("Eingabe der Breite unten (b1)");
                aa = double.Parse(Console.ReadLine());
                Console.WriteLine("Eingabe der Breite oben (b2)");
                bb = double.Parse(Console.ReadLine());
                Console.WriteLine("Eingabe der Höhe (h)");
                cc = double.Parse(Console.ReadLine());
                Console.WriteLine("Eingabe der Länge");
                dd = double.Parse(Console.ReadLine());

                Console.WriteLine("Material des Körpers");
                Console.WriteLine("0-Anderen Körper wählen, 1-Stahl, 2-Aluminium");

                flächeninhalt = (aa + bb) * (cc / 2);                          //berechnungen Symmetrisches Trapez

                volumen = flächeninhalt * dd;

                Ixx = (Math.Pow(cc, 3) * (Math.Pow(bb - aa, 2)) + 2 * aa * bb) / 36 * (aa + bb);

                Iyy = (cc / 48) * (aa + bb) * (Math.Pow(aa, 2) + (Math.Pow(bb, 2)));


                material = int.Parse(Console.ReadLine());


                if (material == 1)
                {
                    masse = volumen * stahl;

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
                }

                if (material == 0)                                                              // zurück zur Profilauswahl <- anderes verfahren finden!
                {
                    goto sprungmarke;
                }
            }
        }
    }
}
