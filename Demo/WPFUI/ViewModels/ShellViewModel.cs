using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFUI.Models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Automation;
using System.Windows.Controls.Primitives;
using System.Windows.Ink;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;

using System.Windows.Shell;




namespace WPFUI.ViewModels
{


    public class ShellViewModel : Conductor<object>
    {

        // Konstruktor
        public ShellViewModel()
        {

        }

        // öffnet das Rechteckprofil Window
        public void LoadRechteckprofil()
        {
            ActivateItem(new RechteckprofilViewModel());
        }

        // öffnet das Kreisprofil Window
        public void LoadKreisprofil()
        {
            ActivateItem(new KreisprofilViewModel());
        }

        // öffnet das Rohrprofil Window
        public void LoadRohrprofil()
        {
            ActivateItem(new RohrprofilViewModel());
        }

        //öffnet dad TProfil window
        public void LoadTprofil()
        {
            ActivateItem(new TprofilViewModel());
        }

        // öffnet das Uprofil Window
        public void LoadUprofil()
        {
            ActivateItem(new UprofilViewModel());
        }

        public void LoadZprofil()
        {
            ActivateItem(new ZprofilViewModel());
        }
        public void LoadVierkantrohrprofil()
        {
            ActivateItem(new VierkantrohrprofilViewModel());
        }
        public void LoadWinkelprofil()
        {
            ActivateItem(new WinkelprofilViewModel());
        }
        public void LoadRechteckrohrprofil()
        {
            ActivateItem(new RechteckrohrprofilViewModel());
        }
        public void LoadMeineProfile()
        {
            ActivateItem(new MeineProfileViewModel());
        }
    }
}
