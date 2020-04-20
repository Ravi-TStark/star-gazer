using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Star_Gazer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ApplicationInitialize = _applicationInitialize;
        }
        public static new App Current
        {
            get { return Application.Current as App; }
        }
        internal delegate void ApplicationInitializeDelegate(LoadingSplash splashWindow);
        internal ApplicationInitializeDelegate ApplicationInitialize;
        MainWindow mainWindow = null;
        private void _applicationInitialize(LoadingSplash splashWindow)
        {
            // fake workload, but with progress updates.
            Thread.Sleep(5000);
            splashWindow.SetProgress(0.2);
            // Create the main window, but on the UI thread.
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate ()
            {
                mainWindow = new MainWindow();
                mainWindow.Activate();
            }));
            
        }
    }
}
