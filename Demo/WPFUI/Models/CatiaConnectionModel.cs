using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using INFITF;
using MECMOD;
using PARTITF;


namespace WPFUI.Models
{
    public class CatiaConnectionModel
    {
        public INFITF.Application hsp_catiaApp;
        public MECMOD.PartDocument hsp_catiaPart;
        public MECMOD.Sketch hsp_catiaProfil;
        public INFITF.Viewer3D viewer3D;

        public bool CATIALaeuft()
        {
            try
            {
                object catiaObject = System.Runtime.InteropServices.Marshal.GetActiveObject(
                    "CATIA.Application");
                hsp_catiaApp = (INFITF.Application)catiaObject;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean ErzeugePart(string name)
        {
            string b = @"\";
            string partname = name;
            string pathname;
            pathname = "C:" + b + "Users" + b + "user" + b + "Desktop" + b + "test";
            INFITF.Documents catDocuments1 = hsp_catiaApp.Documents;
            hsp_catiaPart = catDocuments1.Add("Part") as MECMOD.PartDocument;

            hsp_catiaPart.Product.set_PartNumber(ref name);



            return true;
        }

        public void ErstelleLeereSkizze()
        {
            // geometrisches Set auswaehlen und umbenennen
            HybridBodies catHybridBodies1 = hsp_catiaPart.Part.HybridBodies;
            HybridBody catHybridBody1;
            try
            {
                catHybridBody1 = catHybridBodies1.Item("Geometrisches Set.1");
            }
            catch (Exception)
            {
                MessageBox.Show("Kein geometrisches Set gefunden! " + Environment.NewLine +
                    "Ein PART manuell erzeugen und ein darauf achten, dass 'Geometisches Set' aktiviert ist.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catHybridBody1.set_Name("Profile");
            // neue Skizze im ausgewaehlten geometrischen Set anlegen
            Sketches catSketches1 = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = hsp_catiaPart.Part.OriginElements;
            Reference catReference1 = (Reference)catOriginElements.PlaneYZ;
            hsp_catiaProfil = catSketches1.Add(catReference1);

            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        private void ErzeugeAchsensystem()
        {
            object[] arr = new object[] {0.0, 0.0, 0.0,
                                         0.0, 1.0, 0.0,
                                         0.0, 0.0, 1.0 };
            hsp_catiaProfil.SetAbsoluteAxisData(arr);
        }


        public void ErzeugeBalken(Double l)
        {
            // Hauptkoerper in Bearbeitung definieren
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;

            // Block(Balken) erzeugen
            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(hsp_catiaProfil, l);

            // Block umbenennen
            catPad1.set_Name("Balken");

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        public void Export(string fName, string fPath, string fType)
        {
            try
            {
                string fileName = fName;
                string filePath = fPath;
                string fileType = fType;
                string b = @"\";
                hsp_catiaApp.ActiveDocument.SaveAs(filePath + b + fileName + "." + fileType);
            }
            catch
            {

                MessageBox.Show("Erst Part erzeugen, oder gültigen Pfadnamen/Namen/Datentyp eingeben");
            }

        }

        //public Viewer3D Erzeuge3DView()
        //{
        //    SpecsAndGeomWindow specsAndGeomWindow = (SpecsAndGeomWindow)hsp_catiaApp.ActiveWindow;
        //    Viewer3D viewer3D = (Viewer3D)specsAndGeomWindow.ActiveViewer;
        //    return viewer3D;
        //}
        //public Camera3D Erzeuge3DCam()
        //{
        //    Camera3D camera3D;
        //    camera3D = (Camera3D)hsp_catiaApp.ActiveDocument.Cameras.Item(1);
        //    return camera3D;
        //}

    }

    // Für Rechteckprofil
    public class RechteckProfilCon : CatiaConnectionModel
    {
        public void ErzeugeProfil(Double b, Double h)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Rechteck");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Rechteck erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(-b / 2, h / 2);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(b / 2, h / 2);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(b / 2, -h / 2);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(-b / 2, -h / 2);

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(-b / 2, h / 2, b / 2, h / 2);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(b / 2, h / 2, b / 2, -h / 2);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(b / 2, -h / 2, -b / 2, -h / 2);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-b / 2, -h / 2, -b / 2, h / 2);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }
        public void UpdateProfil(Double b, Double h, Double l)
        {
            //ErstelleLeereSkizze();
            //ErzeugeProfil(b,h);
            //ErzeugeBalken(l);

        }

    }
    //
    // Für Kreisprofil
    public class KreisProfilCon : CatiaConnectionModel
    {
        public void ErzeugeProfil(Double r)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Kreis");

            // Kreis in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Kreis erzeugen

            // erst die Punkte
            //Point2D catPoint2D1 = catFactory2D1.CreatePoint(r/2, r/2);


            // dann die Linien
            Circle2D catLine2D1 = catFactory2D1.CreateCircle(r / 2, r / 2, r, 0, (Math.PI * 2));
            //catLine2D1.StartPoint = catPoint2D1;


            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }
    }
    //
    // Für Rohrprofil
    public class RohrProfilCon : CatiaConnectionModel
    {
        public void ErzeugeProfil(Double r, Double ir)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Kreisring");

            // Kreisring in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Kreisring erzeugen

            // erst die Punkte
            //Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, 0);
            //Point2D catPoint2D2 = catFactory2D1.CreatePoint((r-ir)/2, 0);


            // dann die Linien
            Circle2D catLine2D1 = catFactory2D1.CreateCircle(r / 2, r / 2, r, 0, (Math.PI * 2));
            //catLine2D1.StartPoint = catPoint2D1;
            Circle2D catLine2D2 = catFactory2D1.CreateCircle(r / 2, r / 2, ir, 0, (Math.PI * 2));
            //catLine2D2.StartPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }
    }
    //
    // Für Tprofil
    public class TprofilCon : CatiaConnectionModel
    {
        public void ErzeugeProfil(Double b, Double a, Double ws)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("T-Profil");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, 0);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(0, b - ws);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(-((a / 2) - (ws / 2)), b - ws);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(-((a / 2) - (ws / 2)), b);
            Point2D catPoint2D5 = catFactory2D1.CreatePoint(a / 2 + ws / 2, b);
            Point2D catPoint2D6 = catFactory2D1.CreatePoint(a / 2 + ws / 2, b - ws);
            Point2D catPoint2D7 = catFactory2D1.CreatePoint(ws, b - ws);
            Point2D catPoint2D8 = catFactory2D1.CreatePoint(ws, 0);

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(0, 0, 0, b - ws);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(0, b - ws, -((a / 2) - (ws / 2)), b - ws);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(-((a / 2) - (ws / 2)), -b - ws, -((a / 2) - (ws / 2)), b);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-((a / 2) - (ws / 2)), b, a / 2 + ws / 2, b);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D5;

            Line2D catLine2D5 = catFactory2D1.CreateLine(a / 2 + ws / 2, b, a / 2 + ws / 2, b - ws);
            catLine2D5.StartPoint = catPoint2D5;
            catLine2D5.EndPoint = catPoint2D6;

            Line2D catLine2D6 = catFactory2D1.CreateLine(a / 2 + ws / 2, b - ws, ws, b - ws);
            catLine2D6.StartPoint = catPoint2D6;
            catLine2D6.EndPoint = catPoint2D7;

            Line2D catLine2D7 = catFactory2D1.CreateLine(ws, b - ws, ws, 0);
            catLine2D7.StartPoint = catPoint2D7;
            catLine2D7.EndPoint = catPoint2D8;

            Line2D catLine2D8 = catFactory2D1.CreateLine(ws, 0, 0, 0);
            catLine2D8.StartPoint = catPoint2D8;
            catLine2D8.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();

        }
    }
    //
    // Für Uprofil
    public class UprofilCon : CatiaConnectionModel
    {
        public void ErzeugeProfil(Double b, Double h, Double ws)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("U-Profil");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, 0);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(0, h);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(ws, h);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(ws, ws);
            Point2D catPoint2D5 = catFactory2D1.CreatePoint(b - ws, ws);
            Point2D catPoint2D6 = catFactory2D1.CreatePoint(b - ws, b);
            Point2D catPoint2D7 = catFactory2D1.CreatePoint(b, h);
            Point2D catPoint2D8 = catFactory2D1.CreatePoint(b, 0);

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(0, 0, 0, h);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(0, h, ws, h);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(ws, h, ws, ws);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(ws, ws, b - ws, ws);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D5;

            Line2D catLine2D5 = catFactory2D1.CreateLine(b - ws, ws, b - ws, b);
            catLine2D5.StartPoint = catPoint2D5;
            catLine2D5.EndPoint = catPoint2D6;

            Line2D catLine2D6 = catFactory2D1.CreateLine(b - ws, b, b, h);
            catLine2D6.StartPoint = catPoint2D6;
            catLine2D6.EndPoint = catPoint2D7;

            Line2D catLine2D7 = catFactory2D1.CreateLine(b, h, b, 0);
            catLine2D7.StartPoint = catPoint2D7;
            catLine2D7.EndPoint = catPoint2D8;

            Line2D catLine2D8 = catFactory2D1.CreateLine(b, 0, 0, 0);
            catLine2D8.StartPoint = catPoint2D8;
            catLine2D8.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();

        }
    }
    //
    // Für Winkelprofil
    public class WinkelProfilCon : CatiaConnectionModel
    {
        public void ErzeugeProfil(Double b, Double h, Double ws)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("U-Profil");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, 0);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(0, h);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(ws, h);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(ws, ws);
            Point2D catPoint2D5 = catFactory2D1.CreatePoint(b, ws);
            Point2D catPoint2D6 = catFactory2D1.CreatePoint(b, 0);


            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(0, 0, 0, h);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(0, h, ws, h);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(ws, h, ws, ws);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(ws, ws, b, ws);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D5;

            Line2D catLine2D5 = catFactory2D1.CreateLine(b, ws, b, 0);
            catLine2D5.StartPoint = catPoint2D5;
            catLine2D5.EndPoint = catPoint2D6;

            Line2D catLine2D6 = catFactory2D1.CreateLine(b, 0, 0, 0);
            catLine2D6.StartPoint = catPoint2D6;
            catLine2D6.EndPoint = catPoint2D1;


            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();

        }
    }
    //
    //Für Z Profil
    public class ZProfilCon : CatiaConnectionModel
    {
        public void ErzeugeProfil(Double b, Double a, Double ws)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Z-Profil");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, b - ws);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(0, b);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(a, b);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(a, ws);
            Point2D catPoint2D5 = catFactory2D1.CreatePoint((2 * a) - ws, ws);
            Point2D catPoint2D6 = catFactory2D1.CreatePoint((2 * a) - ws, 0);
            Point2D catPoint2D7 = catFactory2D1.CreatePoint(a - ws, 0);
            Point2D catPoint2D8 = catFactory2D1.CreatePoint(a - ws, b - ws);

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(0, b - ws, 0, b);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(0, b, a, b);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(a, b, a, ws);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(a, ws, (2 * a) - ws, ws);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D5;

            Line2D catLine2D5 = catFactory2D1.CreateLine((2 * a) - ws, ws, (2 * a) - ws, 0);
            catLine2D5.StartPoint = catPoint2D5;
            catLine2D5.EndPoint = catPoint2D6;

            Line2D catLine2D6 = catFactory2D1.CreateLine((2 * a) - ws, 0, a - ws, 0);
            catLine2D6.StartPoint = catPoint2D6;
            catLine2D6.EndPoint = catPoint2D7;

            Line2D catLine2D7 = catFactory2D1.CreateLine(a - ws, 0, a - ws, b - ws);
            catLine2D7.StartPoint = catPoint2D7;
            catLine2D7.EndPoint = catPoint2D8;

            Line2D catLine2D8 = catFactory2D1.CreateLine(a - ws, b - ws, 0, b - ws);
            catLine2D8.StartPoint = catPoint2D8;
            catLine2D8.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();

        }
    }
    //
    // Für Rechteckrohrprofil
    public class RechteckrohrProfilCon : CatiaConnectionModel
    {
        public void ErzeugeProfil(Double b, Double h, Double bi, Double hi)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Rechteckrohr");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Rechteck erzeugen

            // erst die Punkte

            //Für Außen
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(-b / 2, h / 2);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(b / 2, h / 2);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(b / 2, -h / 2);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(-b / 2, -h / 2);
            //

            //Für Innen
            Point2D catPoint2D5 = catFactory2D1.CreatePoint(-bi / 2, hi / 2);
            Point2D catPoint2D6 = catFactory2D1.CreatePoint(bi / 2, hi / 2);
            Point2D catPoint2D7 = catFactory2D1.CreatePoint(bi / 2, -hi / 2);
            Point2D catPoint2D8 = catFactory2D1.CreatePoint(-bi / 2, -hi / 2);
            //

            // dann die Linien
            // Für Außen
            Line2D catLine2D1 = catFactory2D1.CreateLine(-b / 2, h / 2, b / 2, h / 2);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(b / 2, h / 2, b / 2, -h / 2);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(b / 2, -h / 2, -b / 2, -h / 2);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-b / 2, -h / 2, -b / 2, h / 2);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D1;
            //

            //Für Innen
            Line2D catLine2D5 = catFactory2D1.CreateLine(-bi / 2, hi / 2, bi / 2, hi / 2);
            catLine2D5.StartPoint = catPoint2D5;
            catLine2D5.EndPoint = catPoint2D6;

            Line2D catLine2D6 = catFactory2D1.CreateLine(bi / 2, hi / 2, bi / 2, -hi / 2);
            catLine2D6.StartPoint = catPoint2D6;
            catLine2D6.EndPoint = catPoint2D7;

            Line2D catLine2D7 = catFactory2D1.CreateLine(bi / 2, -hi / 2, -bi / 2, -hi / 2);
            catLine2D7.StartPoint = catPoint2D7;
            catLine2D7.EndPoint = catPoint2D8;

            Line2D catLine2D8 = catFactory2D1.CreateLine(-bi / 2, -hi / 2, -bi / 2, hi / 2);
            catLine2D8.StartPoint = catPoint2D8;
            catLine2D8.EndPoint = catPoint2D5;
            //


            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }
    }
    //
    /// Für Vierkantrohr
    /// 
    public class VierkantrohrProfilCon : CatiaConnectionModel
    {
        public void ErzeugeProfil(Double b, Double h, Double bi, Double hi)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Rechteckrohr");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Rechteck erzeugen

            // erst die Punkte

            //Für Außen
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(-b / 2, h / 2);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(b / 2, h / 2);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(b / 2, -h / 2);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(-b / 2, -h / 2);
            //

            //Für Innen
            Point2D catPoint2D5 = catFactory2D1.CreatePoint(-bi / 2, hi / 2);
            Point2D catPoint2D6 = catFactory2D1.CreatePoint(bi / 2, hi / 2);
            Point2D catPoint2D7 = catFactory2D1.CreatePoint(bi / 2, -hi / 2);
            Point2D catPoint2D8 = catFactory2D1.CreatePoint(-bi / 2, -hi / 2);
            //

            // dann die Linien
            // Für Außen
            Line2D catLine2D1 = catFactory2D1.CreateLine(-b / 2, h / 2, b / 2, h / 2);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(b / 2, h / 2, b / 2, -h / 2);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(b / 2, -h / 2, -b / 2, -h / 2);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-b / 2, -h / 2, -b / 2, h / 2);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D1;
            //

            //Für Innen
            Line2D catLine2D5 = catFactory2D1.CreateLine(-bi / 2, hi / 2, bi / 2, hi / 2);
            catLine2D5.StartPoint = catPoint2D5;
            catLine2D5.EndPoint = catPoint2D6;

            Line2D catLine2D6 = catFactory2D1.CreateLine(bi / 2, hi / 2, bi / 2, -hi / 2);
            catLine2D6.StartPoint = catPoint2D6;
            catLine2D6.EndPoint = catPoint2D7;

            Line2D catLine2D7 = catFactory2D1.CreateLine(bi / 2, -hi / 2, -bi / 2, -hi / 2);
            catLine2D7.StartPoint = catPoint2D7;
            catLine2D7.EndPoint = catPoint2D8;

            Line2D catLine2D8 = catFactory2D1.CreateLine(-bi / 2, -hi / 2, -bi / 2, hi / 2);
            catLine2D8.StartPoint = catPoint2D8;
            catLine2D8.EndPoint = catPoint2D5;
            //


            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }
    }
    public class Source
    {
        public string SourcePath { get; set; }

    }
}
