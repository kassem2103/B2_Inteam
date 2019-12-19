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
using static WPFUI.Views.RechteckprofilView;
using static WPFUI.Views.KreisprofilView;
using static WPFUI.Views.RohrprofilView;
using System.Configuration;
using System.Data.SQLite;
using Dapper;

namespace WPFUI.Views
{
    /// <summary>
    /// Interaktionslogik für MeineProfileView.xaml
    /// </summary>
    public partial class MeineProfileView : UserControl
    {
        //private RechteckprofilView rechteckprofilView;

        public MeineProfileView()
        {
            InitializeComponent();
            LoadProfilList();



            //listProfilListBox.ItemsSource = krpo;
            //listProfilListBox.ItemsSource = repo;


        }



        private void LoadProfilList()
        {

            repo = MeineProfileView.LoadRechteck();
            krpo = MeineProfileView.LoadKreis();
            ropo = MeineProfileView.LoadRohr();


        }

        private void ProfilArtÄnderung()
        {

            if (profilArt.Text == "Rechteck")
            {
                listProfilListBox.ItemsSource = repo;
            }
            else if (profilArt.Text == "Kreis")
            {
                listProfilListBox.ItemsSource = krpo;
            }
            else if (profilArt.Text == "Rohr")
            {
                listProfilListBox.ItemsSource = ropo;
            }
        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            ProfilArtÄnderung();
        }

        private void ListProfilListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {


                if (profilArt.Text == "Rechteck")
                {
                    RechteckProfil values = (RechteckProfil)e.AddedItems[0];
                    länge.Text = values.Länge;
                    teilNr.Text = values.ArtName;
                    breite.Text = values.Breite;
                    höhe.Text = values.Höhe;
                    volumen.Text = values.Volumen;
                    gewicht.Text = values.Gewicht;
                    querschnitt.Text = values.Querschnittsfläche;
                    material.Text = values.Material;
                    spx.Text = values.SchwerpunktX;
                    spy.Text = values.SchwerpunktY;
                    spz.Text = values.SchwerpunktZ;
                    ixx.Text = values.FlächenträgheitsmomentIxx;
                    iyy.Text = values.FlächenträgheitsmomentIyy;
                }

                else if (profilArt.Text == "Kreis")
                {
                    KreisProfil values = (KreisProfil)e.AddedItems[0];
                    länge.Text = values.Länge;
                    teilNr.Text = values.ArtName;
                    breite.Text = values.Durchmesser;
                    volumen.Text = values.Volumen;
                    gewicht.Text = values.Gewicht;
                    querschnitt.Text = values.Querschnittsfläche;
                    material.Text = values.Material;
                    spx.Text = values.SchwerpunktX;
                    spy.Text = values.SchwerpunktY;
                    spz.Text = values.SchwerpunktZ;
                    ixx.Text = values.FlächenträgheitsmomentIxx;
                    iyy.Text = values.FlächenträgheitsmomentIyy;
                }

                else if (profilArt.Text == "Rohr")
                {
                    KreisProfil values = (KreisProfil)e.AddedItems[0];
                    länge.Text = values.Länge;
                    teilNr.Text = values.ArtName;
                    breite.Text = values.Durchmesser;
                    volumen.Text = values.Volumen;
                    gewicht.Text = values.Gewicht;
                    querschnitt.Text = values.Querschnittsfläche;
                    material.Text = values.Material;
                    spx.Text = values.SchwerpunktX;
                    spy.Text = values.SchwerpunktY;
                    spz.Text = values.SchwerpunktZ;
                    ixx.Text = values.FlächenträgheitsmomentIxx;
                    iyy.Text = values.FlächenträgheitsmomentIyy;
                }
            }
            catch
            {
               
            }
        }
        //private funktion schreiben 
        //object
        //using var context 



        // Data Access

        public static List<RechteckProfil> LoadRechteck()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<RechteckProfil>("select * from Profil", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveRechteck(RechteckProfil rechteck)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Profil (ArtName, Länge, Breite, Höhe, Material, Volumen,  Gewicht, Querschnittsfläche, SchwerpunktX, SchwerpunktY, SchwerpunktZ, FlächenträgheitsmomentIxx, FlächenträgheitsmomentIyy, ArtNameAusgabe) values (@ArtName, @Länge, @Breite, @Höhe, @Material, @Volumen,  @Gewicht, @Querschnittsfläche, @SchwerpunktX, @SchwerpunktY, @SchwerpunktZ, @FlächenträgheitsmomentIxx, @FlächenträgheitsmomentIyy, @ArtNameAusgabe)", rechteck);
            }
        }

        public static void DeleteRechteck()
        {
            //using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            //{
            //    cnn.Execute("delete from Profil (ID)");
            //}
        }





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
                cnn.Execute("insert into KreisProfil (ArtName) values (@ArtName)", kreis);
            }
        }



        public static List<KreisProfil> LoadRohr()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<RohrProfil>("select * from RohrProfil", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveKreis(RohrProfil rohr)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into RohrProfil (ArtName) values (@ArtName)", rohr);
            }
        }








        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteRechteck( );
        }
    }
}
