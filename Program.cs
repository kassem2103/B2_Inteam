using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rechteck
{
    class Program
    {
        static void Main(string[] args)
        {
            //string material;
            double b, h, c, t, Xs, Ys, volumen, dichte = 0;
            double fläche, Ixx, Iyy, material;


            // einheiten 

            string flächeneinheit = "mm²";
            string volumeneinheit = "mm³";
            string flächenträgheitsmomenteinheit = "mm^4";
            string Schwerpunkteinheit = "mm";
            string dichteeinheit = "g/mm³";
            string masseeinheit = "g";


            // material

            //string material;
            double aluminium, stahl, kupfer, titan;
            aluminium = 2.7;
            stahl = 7.58;
            kupfer = 8.96;
            titan = 4.506;


            //Console.ReadLine();
            do
            {
                // MATERIAL GEBEN UM DIE DICHTE ZU WÄHLEN
                      Console.WriteLine("Rechteckprofile");
                      Console.Write("Bitte Wählen Sie eine Material : ");
                      Console.WriteLine("1=aluminium ,2=stahl ,3=titan ,4=kupfer ");
                      material = int.Parse(Console.ReadLine());
                      if (material == 1)
                      {
                          dichte = aluminium;

                      }
                      else if (material == 2)
                      {
                          dichte = stahl;

                      }
                      else if (material == 3)
                      {
                          dichte = kupfer;


                      }
                      else if (material == 4)
                      {
                          dichte = titan;

                      }
                      else if (material ==0)
                      {
                      Console.WriteLine("ENDE");
                      }
                      else
                      {
                          Console.WriteLine("material unbekannt");
                      }
                //Console.WriteLine(" Rechteckprofile:");
                // DIE GROSSE GEBEN 

                Console.Write(" Bitte geben Sie die Breite in mm an: ");
                b = double.Parse(Console.ReadLine());

                Console.Write(" Bitte geben Sie die Höhe in mm an: ");
                h = double.Parse(Console.ReadLine());
                Console.Write(" Bitte geben sie die Tiefe in mm an: ");
                t = double.Parse(Console.ReadLine());


                // fromel konstante
                c = 12;
                //formeln
                fläche = b * h;
                volumen = b * h * t;
                Ixx = (b * h * h * h) / c;
                Iyy = (h * b * b * b) / c;
                Xs = b / 2;
                Ys = h / 2;

               // masse = volumen * dichte;

                // ERGEBNISSE 
                Console.WriteLine("Die fläche ist ={0}", fläche + flächeneinheit);
                Console.WriteLine(" Das Volumen ist =" + volumen + volumeneinheit);
                Console.WriteLine("Der Schwerpunkt in X-achse ist=" + Xs + Schwerpunkteinheit);
                Console.WriteLine("Der Schwerpunkt in Y-achse ist=" + Ys + Schwerpunkteinheit);
                Console.WriteLine("Ixx ist = " + Ixx + flächenträgheitsmomenteinheit);
                Console.WriteLine("Iyy ist = " + Iyy + flächenträgheitsmomenteinheit);
                Console.WriteLine("Die Masse ist =" + masse(volumen, dichte) + masseeinheit);
                Console.ReadLine();
            }
            while (material != 0);
        }
        static double masse(double volumen, double dichte)
        {
            double x;
            x = volumen * dichte;
            return x;
            
        }
    }
}
