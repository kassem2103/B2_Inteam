using System;
using System.Data;
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
using Caliburn.Micro;
using System.ComponentModel;
using static WPFUI.Views.RechteckprofilView; // statische using damit Listen hier auftauchen
using static WPFUI.Views.KreisprofilView;    // statische using damit Listen hier auftauchen
using static WPFUI.Views.RohrprofilView;
using static WPFUI.Views.TprofilView;
using static WPFUI.Views.UprofilView;
using static WPFUI.Views.WinkelprofilView;
using static WPFUI.Views.ZprofilView;
using static WPFUI.Views.HprofilView;
using static WPFUI.Views.RechteckrohrprofilView;
using static WPFUI.Views.VierkantrohrprofilView;
using System.Configuration;
using System.Data.SQLite;
using Dapper;
using Z.Dapper.Plus;


namespace WPFUI.Views
{
    /// <summary>
    /// Interaktionslogik für MeineProfileView.xaml
    /// </summary>
    public partial class MeineProfileView : UserControl
    {
        public string Auswahl { get; set; } // Fürs Löschen
        public Source source = new Source();

        //Konstrultor
        public MeineProfileView()
        {
            InitializeComponent();
            LoadProfilList(); // Methode wird ausgeführt
                              // Quelle

            pfadSource.Text = Properties.Settings.Default.speicherpfad;

            


        }

        /// /////////////////////////////////////////////////////////////////////////////////
        // Data Access
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
       

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (profilArt.Text == "Rechteck")
                {
                    DeleteRechteck();
                }
                else if (profilArt.Text == "Kreis")
                {
                    DeleteKreis();
                }
                else if (profilArt.Text == "Rohr")
                {
                    DeleteRohr();
                }
                else if (profilArt.Text == "T-Profil")
                {
                    DeleteTprofil();
                }
                else if (profilArt.Text == "U-Profil")
                {
                    DeleteUprofil();
                }
                else if (profilArt.Text == "Winkel")
                {
                    DeleteWinkelprofil();
                }
                else if (profilArt.Text == "Z-Profil")
                {
                    DeleteZprofil();
                }
                else if (profilArt.Text == "H-Profil")
                {
                    DeleteHprofil();
                }
                else if (profilArt.Text == "Rechteckrohr")
                {
                    DeleteRechteckrohr();
                }
                else if (profilArt.Text == "Vierkant")
                {
                    DeleteVierkantrohr();
                }
            }
            catch
            {

            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadProfilList();
            ProfilArtÄnderung();
            Verwerfen_();
            source.SourcePath = pfadSource.Text;
            SaveSource(source);
            Properties.Settings.Default.speicherpfad = pfadSource.Text;
            Properties.Settings.Default.Save();
        }

        private void ProfilArtÄnderung() // für die Profilauswahl, damit die Liste je nach Profil sachen ausgiebt
        {
            try
            {


                if (profilArt.Text == "Rechteck")
                {
                    listProfilListBox.ItemsSource = repo;  // die listquelle wird die statische liste repo                                  
                    Uri resourceUri = new Uri("/WPFUI;component/Media/Rechteckprofil.PNG", UriKind.Relative);
                    bild.Source = new BitmapImage(resourceUri);
                }
                else if (profilArt.Text == "Kreis")
                {
                    Uri resourceUri = new Uri("/WPFUI;component/Media/Kreisprofil.PNG", UriKind.Relative);
                    bild.Source = new BitmapImage(resourceUri);
                    listProfilListBox.ItemsSource = krpo;
                }
                else if (profilArt.Text == "Rohr")
                {
                    Uri resourceUri = new Uri("/WPFUI;component/Media/Kreisrohrprofil.PNG", UriKind.Relative);
                    bild.Source = new BitmapImage(resourceUri);
                    listProfilListBox.ItemsSource = ropo;
                }
                else if (profilArt.Text == "T-Profil")
                {
                    Uri resourceUri = new Uri("/WPFUI;component/Media/T-Profil.PNG", UriKind.Relative);
                    bild.Source = new BitmapImage(resourceUri);
                    listProfilListBox.ItemsSource = tpro;
                }
                else if (profilArt.Text == "U-Profil")
                {
                    Uri resourceUri = new Uri("/WPFUI;component/Media/U-Profil.PNG", UriKind.Relative);
                    bild.Source = new BitmapImage(resourceUri);
                    listProfilListBox.ItemsSource = upro;
                }
                else if (profilArt.Text == "Winkel")
                {
                    Uri resourceUri = new Uri("/WPFUI;component/Media/Winkelprofil.PNG", UriKind.Relative);
                    bild.Source = new BitmapImage(resourceUri);
                    listProfilListBox.ItemsSource = wipo;
                }
                else if (profilArt.Text == "Z-Profil")
                {
                    Uri resourceUri = new Uri("/WPFUI;component/Media/ZProfil.PNG", UriKind.Relative);
                    bild.Source = new BitmapImage(resourceUri);
                    listProfilListBox.ItemsSource = zpro;
                }
                else if (profilArt.Text == "HProfil")
                {
                    Uri resourceUri = new Uri("/WPFUI;component/Media/H-Profil.PNG", UriKind.Relative);
                    bild.Source = new BitmapImage(resourceUri);
                    listProfilListBox.ItemsSource = hpro;
                }
                else if (profilArt.Text == "Rechteckrohr")
                {
                    Uri resourceUri = new Uri("/WPFUI;component/Media/Rechteckrohrprofil.PNG", UriKind.Relative);
                    bild.Source = new BitmapImage(resourceUri);
                    listProfilListBox.ItemsSource = rhpo;
                }
                else if (profilArt.Text == "Vierkant")
                {
                    Uri resourceUri = new Uri("/WPFUI;component/Media/VierKantRohrProfil.PNG", UriKind.Relative);
                    bild.Source = new BitmapImage(resourceUri);
                    listProfilListBox.ItemsSource = vipo;
                }
            }
            catch
            {

            }
        }
        private void Load_Click(object sender, RoutedEventArgs e)  // der Laden Button, der wird immer ausgeführt nachdem ein neues profil ausgewählt wurde
        {
            ProfilArtÄnderung();
        }

        ///////////////////////////////////////////////////////////////
        ///Für Alle
        ///
        private void ListProfilListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // je nachdem was man in der Liste anwählt wird was anderes geladen
        {
            try
            {
                //Die zuweisungen je nachdem was ausgewählt wurde
                if (profilArt.Text == "Rechteck")
                {
                    RechteckProfil values = (RechteckProfil)e.AddedItems[0];
                    länge.Text = values.Länge;
                    teilNr.Text = values.ArtName;
                    Auswahl = values.ArtName;
                    breite.Text = values.Breite;
                    höhe.Text = values.Höhe;
                    volumen.Text = values.Volumen;
                    gewicht.Text = values.Gewicht;
                    querschnitt.Text = values.Querschnittsfläche;
                    material.Text = values.Material;
                    spx.Text = " x: " + values.SchwerpunktX + "                 ";
                    spy.Text = " y: " + values.SchwerpunktY + "                 ";
                    spz.Text = " z: " + values.SchwerpunktZ + "                 ";
                    ixx.Text = " Ixx: " + values.FlächenträgheitsmomentIxx + "          ";
                    iyy.Text = " Iyy: " + values.FlächenträgheitsmomentIyy + "          ";
                    //

                }

                else if (profilArt.Text == "Kreis")
                {
                    KreisProfil values = (KreisProfil)e.AddedItems[0];
                    länge.Text = values.Länge;
                    teilNr.Text = values.ArtName;
                    Auswahl = values.ArtName;
                    durchmesser.Text = values.Durchmesser;
                    volumen.Text = values.Volumen;
                    gewicht.Text = values.Gewicht;
                    querschnitt.Text = values.Querschnittsfläche;
                    material.Text = values.Material + "          ";
                    spx.Text = " x: " + values.SchwerpunktX + "                ";
                    spy.Text = " y: " + values.SchwerpunktY + "                          ";
                    spz.Text = " z: " + values.SchwerpunktZ + "                  ";
                    ixx.Text = " Ixx: " + values.FlächenträgheitsmomentIxx + "               ";
                    iyy.Text = " Iyy: " + values.FlächenträgheitsmomentIyy + "                ";


                    // Ausgabe der Einheiten

                }
                else if (profilArt.Text == "Rohr")
                {
                    RohrProfil values = (RohrProfil)e.AddedItems[0];
                    länge.Text = values.Länge;
                    teilNr.Text = values.ArtName;
                    Auswahl = values.ArtName;
                    durchmesser.Text = values.Durchmesser;
                    wandstärke.Text = values.Wandstärke;
                    volumen.Text = values.Volumen;
                    gewicht.Text = values.Gewicht;
                    querschnitt.Text = values.Querschnittsfläche;
                    material.Text = values.Material + "          ";
                    spx.Text = " x: " + values.SchwerpunktX + "               ";
                    spy.Text = " y: " + values.SchwerpunktY + "                 ";
                    spz.Text = " z: " + values.SchwerpunktZ + "                ";
                    ixx.Text = " Ixx: " + values.FlächenträgheitsmomentIxx + "          ";
                    iyy.Text = " Iyy: " + values.FlächenträgheitsmomentIyy + "          ";


                    // Ausgabe der Einheiten

                }
                else if (profilArt.Text == "T-Profil")
                {
                    Tprofil values = (Tprofil)e.AddedItems[0];
                    länge.Text = values.Länge;
                    teilNr.Text = values.ArtName;
                    Auswahl = values.ArtName;
                    breite.Text = values.Breite;
                    länge.Text = values.Länge;
                    wandstärke.Text = values.Wandstärke;
                    volumen.Text = values.Volumen;
                    gewicht.Text = values.Gewicht;
                    querschnitt.Text = values.Querschnittsfläche;
                    material.Text = values.Material + "          ";
                    spx.Text = " x: " + values.SchwerpunktX + "                  ";
                    spy.Text = " y: " + values.SchwerpunktY + "                  ";
                    spz.Text = " z: " + values.SchwerpunktZ + "                  ";
                    ixx.Text = " Ixx: " + values.FlächenträgheitsmomentIxx + "               ";
                    iyy.Text = " Iyy: " + values.FlächenträgheitsmomentIyy + "               ";


                }
                else if (profilArt.Text == "U-Profil")
                {
                    Uprofil values = (Uprofil)e.AddedItems[0];
                    länge.Text = values.Länge;
                    teilNr.Text = values.ArtName;
                    Auswahl = values.ArtName;
                    breite.Text = values.Breite;
                    länge.Text = values.Länge;
                    wandstärke.Text = values.Wandstärke;
                    volumen.Text = values.Volumen;
                    gewicht.Text = values.Gewicht;
                    querschnitt.Text = values.Querschnittsfläche;
                    material.Text = values.Material + "          ";
                    spx.Text = " x: " + values.SchwerpunktX + "          ";
                    spy.Text = " y: " + values.SchwerpunktY + "          ";
                    spz.Text = " z: " + values.SchwerpunktZ + "          ";
                    ixx.Text = " Ixx: " + values.FlächenträgheitsmomentIxx + "          ";
                    iyy.Text = " Iyy: " + values.FlächenträgheitsmomentIyy + "          ";

                }
                else if (profilArt.Text == "Winkel")
                {
                    WinkelProfil values = (WinkelProfil)e.AddedItems[0];
                    länge.Text = values.Länge;
                    teilNr.Text = values.ArtName;
                    Auswahl = values.ArtName;
                    breite.Text = values.Breite;
                    länge.Text = values.Länge;
                    wandstärke.Text = values.Wandstärke;
                    volumen.Text = values.Volumen;
                    gewicht.Text = values.Gewicht;
                    querschnitt.Text = values.Querschnittsfläche;
                    material.Text = values.Material + "          ";
                    spx.Text = " x: " + values.SchwerpunktX + "          ";
                    spy.Text = " y: " + values.SchwerpunktY + "          ";
                    spz.Text = " z: " + values.SchwerpunktZ + "          ";
                    ixx.Text = " Ixx: " + values.FlächenträgheitsmomentIxx + "          ";
                    iyy.Text = " Iyy: " + values.FlächenträgheitsmomentIyy + "          ";

                }
                else if (profilArt.Text == "Z-Profil")
                {
                    ZProfil values = (ZProfil)e.AddedItems[0];
                    länge.Text = values.Länge;
                    teilNr.Text = values.ArtName;
                    Auswahl = values.ArtName;
                    breite.Text = values.Breite;
                    länge.Text = values.Länge;
                    wandstärke.Text = values.Wandstärke;
                    volumen.Text = values.Volumen;
                    gewicht.Text = values.Gewicht;
                    querschnitt.Text = values.Querschnittsfläche;
                    material.Text = values.Material + "          ";
                    spx.Text = " x: " + values.SchwerpunktX + "          ";
                    spy.Text = " y: " + values.SchwerpunktY + "          ";
                    spz.Text = " z: " + values.SchwerpunktZ + "          ";
                    ixx.Text = " Ixx: " + values.FlächenträgheitsmomentIxx + "          ";
                    iyy.Text = " Iyy: " + values.FlächenträgheitsmomentIyy + "          ";



                }
                else if (profilArt.Text == "H-Profil")
                {
                    HProfil values = (HProfil)e.AddedItems[0];
                    länge.Text = values.Länge;
                    teilNr.Text = values.ArtName;
                    Auswahl = values.ArtName;
                    breite.Text = values.Breite;
                    länge.Text = values.Länge;
                    höhe.Text = values.Höhe;
                    volumen.Text = values.Volumen;
                    gewicht.Text = values.Gewicht;
                    querschnitt.Text = values.Querschnittsfläche;
                    material.Text = values.Material + "          ";
                    spx.Text = " x: " + values.SchwerpunktX + "          ";
                    spy.Text = " y: " + values.SchwerpunktY + "          ";
                    spz.Text = " z: " + values.SchwerpunktZ + "          ";
                    ixx.Text = " Ixx: " + values.FlächenträgheitsmomentIxx + "          ";
                    iyy.Text = " Iyy: " + values.FlächenträgheitsmomentIyy + "          ";


                }
                else if (profilArt.Text == "Rechteckrohr")
                {
                    RechteckrohrProfil values = (RechteckrohrProfil)e.AddedItems[0];
                    länge.Text = values.Länge;
                    teilNr.Text = values.ArtName;
                    Auswahl = values.ArtName;
                    breite.Text = values.Breite;
                    höhe.Text = values.Höhe;
                    länge.Text = values.Länge;
                    wandstärke.Text = values.Wandstärke;
                    volumen.Text = values.Volumen;
                    gewicht.Text = values.Gewicht;
                    querschnitt.Text = values.Querschnittsfläche;
                    material.Text = values.Material + "          ";
                    spx.Text = " x: " + values.SchwerpunktX + "          ";
                    spy.Text = " y: " + values.SchwerpunktY + "          ";
                    spz.Text = " z: " + values.SchwerpunktZ + "          ";
                    ixx.Text = " Ixx: " + values.FlächenträgheitsmomentIxx + "          ";
                    iyy.Text = " Iyy: " + values.FlächenträgheitsmomentIyy + "          ";

                }
                else if (profilArt.Text == "Vierkant")
                {
                    VierkantrohrProfil values = (VierkantrohrProfil)e.AddedItems[0];
                    länge.Text = values.Länge;
                    teilNr.Text = values.ArtName;
                    Auswahl = values.ArtName;
                    breite.Text = values.Breite;
                    höhe.Text = values.Höhe;
                    länge.Text = values.Länge;
                    wandstärke.Text = values.Wandstärke;
                    volumen.Text = values.Volumen;
                    gewicht.Text = values.Gewicht;
                    querschnitt.Text = values.Querschnittsfläche;
                    material.Text = values.Material + "          ";
                    spx.Text = " x: " + values.SchwerpunktX + "          ";
                    spy.Text = " y: " + values.SchwerpunktY + "          ";
                    spz.Text = " z: " + values.SchwerpunktZ + "          ";
                    ixx.Text = " Ixx: " + values.FlächenträgheitsmomentIxx + "          ";
                    iyy.Text = " Iyy: " + values.FlächenträgheitsmomentIyy + "          ";

                }
            }
            catch
            {

            }
        }


        public void Verwerfen_()
        {
            teilNr.Text = "";
            länge.Text = "";
            breite.Text = "";
            höhe.Text = "";
            material.Text = "";
            volumen.Text = "";
            gewicht.Text = "";
            querschnitt.Text = "";
            durchmesser.Text = "";
            wandstärke.Text = "";
            ixx.Text = "";
            iyy.Text = "";
            spx.Text = " x:                    ";
            spy.Text = " y:                    ";
            spz.Text = " z:                    ";

        }

        private void LoadProfilList()
        {

            repo = MeineProfileView.LoadRechteck();
            krpo = MeineProfileView.LoadKreis();
            ropo = MeineProfileView.LoadRohr();
            tpro = MeineProfileView.LoadTprofil();
            upro = MeineProfileView.LoadUprofil();
            wipo = MeineProfileView.LoadWinkelprofil();
            zpro = MeineProfileView.LoadZprofil();
            hpro = MeineProfileView.LoadHprofil();
            rhpo = MeineProfileView.LoadRechteckrohr();
            vipo = MeineProfileView.LoadVierkantrohr();


        }


        ///////////////////////////////////////////////////////////////
        ///Für Rechteckprofil
        ///
        public static List<RechteckProfil> LoadRechteck()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<RechteckProfil>("select * from RechteckProfil", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveRechteck(RechteckProfil rechteck)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {


                cnn.Execute("insert into RechteckProfil (ArtName, Länge, Breite, Höhe, Material, Volumen,  Gewicht, Querschnittsfläche, SchwerpunktX, SchwerpunktY, SchwerpunktZ, FlächenträgheitsmomentIxx, FlächenträgheitsmomentIyy, ArtNameAusgabe) values (@ArtName, @Länge, @Breite, @Höhe, @Material, @Volumen,  @Gewicht, @Querschnittsfläche, @SchwerpunktX, @SchwerpunktY, @SchwerpunktZ, @FlächenträgheitsmomentIxx, @FlächenträgheitsmomentIyy, @ArtNameAusgabe)", rechteck);
            }
        }

        public void DeleteRechteck()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string auswahl = Auswahl;
                cnn.Execute("DELETE FROM RechteckProfil where ArtName ='" + auswahl + "'");


            }
        }





        ///////////////////////////////////////////////////////////////
        ///Für Kreisprofil
        ///
        public static List<KreisProfil> LoadKreis()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<KreisProfil>("select * from KreisProfil", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveKreis(KreisProfil kreis)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into KreisProfil (ArtName, ArtNameAusgabe, Material, Länge, Querschnittsfläche, Volumen, Gewicht, SchwerpunktX, SchwerpunktY, SchwerpunktZ, FlächenträgheitsmomentIxx, FlächenträgheitsmomentIyy, Durchmesser ) values (@ArtName, @ArtNameAusgabe, @Material, @Länge, @Querschnittsfläche, @Volumen, @Gewicht, @SchwerpunktX, @SchwerpunktY, @SchwerpunktZ, @FlächenträgheitsmomentIxx, @FlächenträgheitsmomentIyy, @Durchmesser )", kreis);
            }
        }

        public void DeleteKreis()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string auswahl = Auswahl;
                cnn.Execute("DELETE FROM KreisProfil where ArtName ='" + auswahl + "'");


            }
        }

        ///
        /// 
        /// 
        /// 

        ///////////////////////////////////////////////////////////////
        ///Für Rohrprofil
        ///

        public static List<RohrProfil> LoadRohr()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<RohrProfil>("select * from RohrProfil", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveRohr(RohrProfil rohr)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {


                cnn.Execute("insert into RohrProfil  (ArtName, ArtNameAusgabe, Material, Länge, Querschnittsfläche, Volumen, Gewicht, SchwerpunktX, SchwerpunktY, SchwerpunktZ, FlächenträgheitsmomentIxx, FlächenträgheitsmomentIyy, Durchmesser, Wandstärke ) values (@ArtName, @ArtNameAusgabe, @Material, @Länge, @Querschnittsfläche, @Volumen, @Gewicht, @SchwerpunktX, @SchwerpunktY, @SchwerpunktZ, @FlächenträgheitsmomentIxx, @FlächenträgheitsmomentIyy, @Durchmesser, @Wandstärke )", rohr);
            }
        }

        public void DeleteRohr()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string auswahl = Auswahl;
                cnn.Execute("DELETE FROM RohrProfil where ArtName ='" + auswahl + "'");


            }
        }
        ///
        /// 
        /// 
        /// 
        ///////////////////////////////////////////////////////////////
        ///Für Tprofil
        ///

        public static List<Tprofil> LoadTprofil()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Tprofil>("select * from Tprofil", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveTprofil(Tprofil tprofil)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {


                cnn.Execute("insert into Tprofil  (ArtName, ArtNameAusgabe, Material, Länge, Querschnittsfläche, Volumen, Gewicht, SchwerpunktX, SchwerpunktY, SchwerpunktZ, FlächenträgheitsmomentIxx, FlächenträgheitsmomentIyy, Breite, Höhe, Wandstärke ) values (@ArtName, @ArtNameAusgabe, @Material, @Länge, @Querschnittsfläche, @Volumen, @Gewicht, @SchwerpunktX, @SchwerpunktY, @SchwerpunktZ, @FlächenträgheitsmomentIxx, @FlächenträgheitsmomentIyy, @Breite, @Höhe, @Wandstärke )", tprofil);
            }
        }

        public void DeleteTprofil()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string auswahl = Auswahl;
                cnn.Execute("DELETE FROM Tprofil where ArtName ='" + auswahl + "'");


            }
        }
        ///
        /// 
        /// 
        /// 

        ///////////////////////////////////////////////////////////////
        ///Für Uprofil
        ///
        public static List<Uprofil> LoadUprofil()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Uprofil>("select * from Uprofil", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveUprofil(Uprofil uprofil)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {


                cnn.Execute("insert into Uprofil  (ArtName, ArtNameAusgabe, Material, Länge, Querschnittsfläche, Volumen, Gewicht, SchwerpunktX, SchwerpunktY, SchwerpunktZ, FlächenträgheitsmomentIxx, FlächenträgheitsmomentIyy, Breite, Höhe ) values (@ArtName, @ArtNameAusgabe, @Material, @Länge, @Querschnittsfläche, @Volumen, @Gewicht, @SchwerpunktX, @SchwerpunktY, @SchwerpunktZ, @FlächenträgheitsmomentIxx, @FlächenträgheitsmomentIyy, @Breite, @Höhe )", uprofil);
            }
        }

        public void DeleteUprofil()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string auswahl = Auswahl;
                cnn.Execute("DELETE FROM Uprofil where ArtName ='" + auswahl + "'");


            }
        }

        ///
        /// 
        /// 
        /// 

        ///////////////////////////////////////////////////////////////
        ///Für Winkelprofil
        ///
        public static List<WinkelProfil> LoadWinkelprofil()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WinkelProfil>("select * from WinkelProfil", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveWinkelprofil(WinkelProfil winkelprofil)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {


                cnn.Execute("insert into WinkelProfil  (ArtName, ArtNameAusgabe, Material, Länge, Querschnittsfläche, Volumen, Gewicht, SchwerpunktX, SchwerpunktY, SchwerpunktZ, FlächenträgheitsmomentIxx, FlächenträgheitsmomentIyy, Breite, Höhe, Wandstärke ) values (@ArtName, @ArtNameAusgabe, @Material, @Länge, @Querschnittsfläche, @Volumen, @Gewicht, @SchwerpunktX, @SchwerpunktY, @SchwerpunktZ, @FlächenträgheitsmomentIxx, @FlächenträgheitsmomentIyy, @Breite, @Höhe, @Wandstärke )", winkelprofil);
            }
        }

        public void DeleteWinkelprofil()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string auswahl = Auswahl;
                cnn.Execute("DELETE FROM WinkelProfil where ArtName ='" + auswahl + "'");


            }
        }

        ///
        /// 
        /// 
        /// 
        ///////////////////////////////////////////////////////////////
        ///Für Zprofil
        ///

        public static List<ZProfil> LoadZprofil()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ZProfil>("select * from ZProfil", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveZprofil(ZProfil zprofil)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {


                cnn.Execute("insert into ZProfil  (ArtName, ArtNameAusgabe, Material, Länge, Querschnittsfläche, Volumen, Gewicht, SchwerpunktX, SchwerpunktY, SchwerpunktZ, FlächenträgheitsmomentIxx, FlächenträgheitsmomentIyy, Breite, Höhe, Wandstärke ) values (@ArtName, @ArtNameAusgabe, @Material, @Länge, @Querschnittsfläche, @Volumen, @Gewicht, @SchwerpunktX, @SchwerpunktY, @SchwerpunktZ, @FlächenträgheitsmomentIxx, @FlächenträgheitsmomentIyy, @Breite, @Höhe, @Wandstärke )", zprofil);
            }
        }

        public void DeleteZprofil()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string auswahl = Auswahl;
                cnn.Execute("DELETE FROM ZProfil where ArtName ='" + auswahl + "'");


            }
        }

        ///
        /// 
        /// 
        /// 
        ///////////////////////////////////////////////////////////////
        ///Für Hprofil
        ///
        public static List<HProfil> LoadHprofil()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HProfil>("select * from HProfil", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveHprofil(HProfil hprofil)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {


                cnn.Execute("insert into HProfil  (ArtName, ArtNameAusgabe, Material, Länge, Querschnittsfläche, Volumen, Gewicht, SchwerpunktX, SchwerpunktY, SchwerpunktZ, FlächenträgheitsmomentIxx, FlächenträgheitsmomentIyy, Breite, Höhe ) values (@ArtName, @ArtNameAusgabe, @Material, @Länge, @Querschnittsfläche, @Volumen, @Gewicht, @SchwerpunktX, @SchwerpunktY, @SchwerpunktZ, @FlächenträgheitsmomentIxx, @FlächenträgheitsmomentIyy, @Breite, @Höhe )", hprofil);
            }
        }

        public void DeleteHprofil()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string auswahl = Auswahl;
                cnn.Execute("DELETE FROM HProfil where ArtName ='" + auswahl + "'");


            }
        }
        ///
        /// 
        /// 
        /// 
        ///////////////////////////////////////////////////////////////
        ///Für Rechhteckrohrprofil
        ///

        public static List<RechteckrohrProfil> LoadRechteckrohr()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<RechteckrohrProfil>("select * from RechteckrohrProfil", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveRechteckrohr(RechteckrohrProfil rechteckrohr)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {


                cnn.Execute("insert into RechteckrohrProfil (ArtName, Länge, Breite, Höhe, Material, Volumen,  Gewicht, Querschnittsfläche, SchwerpunktX, SchwerpunktY, SchwerpunktZ, FlächenträgheitsmomentIxx, FlächenträgheitsmomentIyy, ArtNameAusgabe, Wandstärke) values (@ArtName, @Länge, @Breite, @Höhe, @Material, @Volumen,  @Gewicht, @Querschnittsfläche, @SchwerpunktX, @SchwerpunktY, @SchwerpunktZ, @FlächenträgheitsmomentIxx, @FlächenträgheitsmomentIyy, @ArtNameAusgabe, @Wandstärke)", rechteckrohr);
            }
        }

        public void DeleteRechteckrohr()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string auswahl = Auswahl;
                cnn.Execute("DELETE FROM RechteckrohrProfil where ArtName ='" + auswahl + "'");


            }
        }
        ///
        /// 
        /// 
        /// 
        ///////////////////////////////////////////////////////////////
        ///Für Vierkantrohrprofil
        ///
        public static List<VierkantrohrProfil> LoadVierkantrohr()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<VierkantrohrProfil>("select * from VierkantrohrProfil", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveVierkantrohr(VierkantrohrProfil vierkantrohr)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {


                cnn.Execute("insert into VierkantrohrProfil (ArtName, Länge, Breite, Höhe, Material, Volumen,  Gewicht, Querschnittsfläche, SchwerpunktX, SchwerpunktY, SchwerpunktZ, FlächenträgheitsmomentIxx, FlächenträgheitsmomentIyy, ArtNameAusgabe, Wandstärke) values (@ArtName, @Länge, @Breite, @Höhe, @Material, @Volumen,  @Gewicht, @Querschnittsfläche, @SchwerpunktX, @SchwerpunktY, @SchwerpunktZ, @FlächenträgheitsmomentIxx, @FlächenträgheitsmomentIyy, @ArtNameAusgabe, @Wandstärke)", vierkantrohr);
            }
        }

        public void DeleteVierkantrohr()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string auswahl = Auswahl;
                cnn.Execute("DELETE FROM VierkantrohrProfil where ArtName ='" + auswahl + "'");


            }
        }
        //
        //public async Task<> LoadSource()
        //{
        //    string outputsql = "SELECT SourcePath FROM Source ";
        //    using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        //    {
        //        var output = cnn.Query(outputsql).FirstOrDefault();
               
        //        return output;
        //    }
        //}

        public static void SaveSource(Source source)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {


                cnn.Execute("insert into Source (SourcePath) values (@SourcePath)",  source);
            }
        }




        //

        // Für Catia 
        private void loadincatia_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // Für Rechteck
                if (profilArt.Text == "Rechteck")
                {


                    RechteckProfilCon repoc = new RechteckProfilCon();
                    string partname = teilNr.Text;
                    double b = double.Parse(breite.Text);
                    double h = double.Parse(höhe.Text);
                    double l = double.Parse(länge.Text);

                    // Finde Catia Prozess
                    if (repoc.CATIALaeuft())
                    {
                        try
                        {


                            // Öffne ein neues Part
                            repoc.ErzeugePart(partname);


                            // Erstelle eine Skizze
                            repoc.ErstelleLeereSkizze();

                            // Generiere ein Profil
                            repoc.ErzeugeProfil(b, h);


                            // Extrudiere Balken
                            repoc.ErzeugeBalken(l);

                        }
                        catch
                        {
                            MessageBox.Show("Name bereits vergeben, bitte anderen Namen wählen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Laufende Catia Application nicht gefunden");
                    }

                }
                //
                //
                else if (profilArt.Text == "Kreis")
                {

                    KreisProfilCon krpoc = new KreisProfilCon();
                    string partname = teilNr.Text;
                    double d = double.Parse(durchmesser.Text);
                    double l = double.Parse(länge.Text);

                    // Finde Catia Prozess
                    if (krpoc.CATIALaeuft())
                    {
                        try
                        {


                            // Öffne ein neues Part
                            krpoc.ErzeugePart(partname);


                            // Erstelle eine Skizze
                            krpoc.ErstelleLeereSkizze();

                            // Generiere ein Profil
                            krpoc.ErzeugeProfil(d);


                            // Extrudiere Balken
                            krpoc.ErzeugeBalken(l);

                        }
                        catch
                        {
                            MessageBox.Show("Name bereits vergeben, bitte anderen Namen wählen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Laufende Catia Application nicht gefunden");
                    }
                }
                //
                //
                else if (profilArt.Text == "Rohr")
                {

                    RohrProfilCon ropoc = new RohrProfilCon();
                    string partname = teilNr.Text;
                    double d = double.Parse(durchmesser.Text);
                    double ws = double.Parse(wandstärke.Text);
                    double l = double.Parse(länge.Text);
                    double r = d / 2;
                    double ir = r - ws;

                    // Finde Catia Prozess
                    if (ropoc.CATIALaeuft())
                    {
                        try
                        {


                            // Öffne ein neues Part
                            ropoc.ErzeugePart(partname);


                            // Erstelle eine Skizze
                            ropoc.ErstelleLeereSkizze();

                            // Generiere ein Profil
                            ropoc.ErzeugeProfil(r, ir);


                            // Extrudiere Balken
                            ropoc.ErzeugeBalken(l);

                        }
                        catch
                        {
                            MessageBox.Show("Name bereits vergeben, bitte anderen Namen wählen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Laufende Catia Application nicht gefunden");
                    }
                }
                //
                //
                else if (profilArt.Text == "T-Profil")
                {
                    TprofilCon tproc = new TprofilCon();
                    double a = double.Parse(breite.Text);
                    double b = double.Parse(höhe.Text);
                    double c = double.Parse(wandstärke.Text);
                    double l = double.Parse(länge.Text);
                    double ws = double.Parse(wandstärke.Text);
                    string partname = teilNr.Text;

                    // Finde Catia Prozess
                    if (tproc.CATIALaeuft())
                    {
                        try
                        {


                            // Öffne ein neues Part
                            tproc.ErzeugePart(partname);


                            // Erstelle eine Skizze
                            tproc.ErstelleLeereSkizze();

                            // Generiere ein Profil
                            tproc.ErzeugeProfil(b, a, ws);


                            // Extrudiere Balken
                            tproc.ErzeugeBalken(l);

                        }
                        catch
                        {
                            MessageBox.Show("Name bereits vergeben, bitte anderen Namen wählen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Laufende Catia Application nicht gefunden");
                    }

                }
                //
                //
                else if (profilArt.Text == "U-Profil")
                {

                    UprofilCon uproc = new UprofilCon();
                    double a = double.Parse(breite.Text);
                    double b = double.Parse(höhe.Text);
                    double c = double.Parse(wandstärke.Text);
                    double l = double.Parse(länge.Text);

                    double h = double.Parse(höhe.Text);
                    double ws = double.Parse(wandstärke.Text);
                    string partname = teilNr.Text;

                    // Finde Catia Prozess
                    if (uproc.CATIALaeuft())
                    {
                        try
                        {


                            // Öffne ein neues Part
                            uproc.ErzeugePart(partname);


                            // Erstelle eine Skizze
                            uproc.ErstelleLeereSkizze();

                            // Generiere ein Profil
                            uproc.ErzeugeProfil(b, h, ws);


                            // Extrudiere Balken
                            uproc.ErzeugeBalken(l);

                        }
                        catch
                        {
                            MessageBox.Show("Name bereits vergeben, bitte anderen Namen wählen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Laufende Catia Application nicht gefunden");
                    }

                }
                //
                //
                else if (profilArt.Text == "Winkel")
                {
                    WinkelProfilCon wiproc = new WinkelProfilCon();
                    double a = double.Parse(breite.Text);
                    double b = double.Parse(höhe.Text);
                    double c = double.Parse(wandstärke.Text);
                    double l = double.Parse(länge.Text);
                    double h = double.Parse(breite.Text);
                    double ws = double.Parse(wandstärke.Text);
                    string partname = teilNr.Text;

                    // Finde Catia Prozess
                    if (wiproc.CATIALaeuft())
                    {
                        try
                        {


                            // Öffne ein neues Part
                            wiproc.ErzeugePart(partname);


                            // Erstelle eine Skizze
                            wiproc.ErstelleLeereSkizze();

                            // Generiere ein Profil
                            wiproc.ErzeugeProfil(b, h, ws);


                            // Extrudiere Balken
                            wiproc.ErzeugeBalken(l);

                        }
                        catch
                        {
                            MessageBox.Show("Name bereits vergeben, bitte anderen Namen wählen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Laufende Catia Application nicht gefunden");
                    }

                }
                //
                //
                else if (profilArt.Text == "Z-Profil")
                {
                    ZProfilCon zproc = new ZProfilCon();
                    double a = double.Parse(breite.Text);
                    double b = double.Parse(höhe.Text);
                    double c = double.Parse(wandstärke.Text);
                    double l = double.Parse(länge.Text);
                    double ws = double.Parse(wandstärke.Text);
                    string partname = teilNr.Text;

                    // Finde Catia Prozess
                    if (zproc.CATIALaeuft())
                    {
                        try
                        {


                            // Öffne ein neues Part
                            zproc.ErzeugePart(partname);


                            // Erstelle eine Skizze
                            zproc.ErstelleLeereSkizze();

                            // Generiere ein Profil
                            zproc.ErzeugeProfil(b, a, ws);


                            // Extrudiere Balken
                            zproc.ErzeugeBalken(l);

                        }
                        catch
                        {
                            MessageBox.Show("Name bereits vergeben, bitte anderen Namen wählen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Laufende Catia Application nicht gefunden");
                    }


                }
                //
                //
                else if (profilArt.Text == "Rechteckrohr")
                {
                    RechteckrohrProfilCon reporc = new RechteckrohrProfilCon();
                    double h = double.Parse(höhe.Text);
                    double b = double.Parse(breite.Text);
                    double l = double.Parse(länge.Text);
                    double ws = double.Parse(wandstärke.Text);
                    double hi = h - (ws * 2);
                    double bi = b - (ws * 2);
                    double a = double.Parse(breite.Text);
                    double c = double.Parse(wandstärke.Text);
                    string partname = teilNr.Text;

                    // Finde Catia Prozess
                    if (reporc.CATIALaeuft())
                    {
                        try
                        {
                            // Öffne ein neues Part
                            reporc.ErzeugePart(partname);


                            // Erstelle eine Skizze
                            reporc.ErstelleLeereSkizze();

                            // Generiere ein Profil
                            reporc.ErzeugeProfil(b, h, bi, hi);


                            // Extrudiere Balken
                            reporc.ErzeugeBalken(l);

                        }
                        catch
                        {
                            MessageBox.Show("Name bereits vergeben, bitte anderen Namen wählen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Laufende Catia Application nicht gefunden");
                    }


                }
                //
                //
                else if (profilArt.Text == "Vierkant")
                {
                    VierkantrohrProfilCon vipoc = new VierkantrohrProfilCon();
                    double h = double.Parse(höhe.Text);
                    double b = double.Parse(breite.Text);
                    double l = double.Parse(länge.Text);
                    double ws = double.Parse(wandstärke.Text);
                    double hi = h - (ws * 2);
                    double bi = b - (ws * 2);
                    double a = double.Parse(breite.Text);
                    double c = double.Parse(wandstärke.Text);
                    string partname = teilNr.Text;

                    // Finde Catia Prozess
                    if (vipoc.CATIALaeuft())
                    {
                        try
                        {
                            // Öffne ein neues Part
                            vipoc.ErzeugePart(partname);


                            // Erstelle eine Skizze
                            vipoc.ErstelleLeereSkizze();

                            // Generiere ein Profil
                            vipoc.ErzeugeProfil(b, h, bi, hi);


                            // Extrudiere Balken
                            vipoc.ErzeugeBalken(l);

                        }
                        catch
                        {
                            MessageBox.Show("Name bereits vergeben, bitte anderen Namen wählen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Laufende Catia Application nicht gefunden");
                    }

                }
            }
            catch
            {

            }




        }
    }
}
