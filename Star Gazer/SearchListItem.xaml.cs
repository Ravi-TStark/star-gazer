using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace Star_Gazer
{
    /// <summary>
    /// Interaction logic for SearchListItem.xaml
    /// </summary>
    public partial class SearchListItem : UserControl
    {
        public string apppath;
        public bool isApp = false;

        public SearchListItem()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                if (!isApp)
                {
                    if (File.Exists(apppath))
                    {
                        try
                        {
                            Process.Start(apppath);
                            Window parentWindow = Window.GetWindow(this);
                            parentWindow.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {

                }
            }
        }

        private void label2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                try
                {
                    //Process.Start(label2.Content.ToString());
                }
                catch(Exception ex)
                {
                    
                }
                Window parentWindow = Window.GetWindow(this); 
                parentWindow.Close();
            }
        }

        public void Click()
        {
            if (File.Exists(apppath))
            {
                try
                {
                    Process.Start(apppath);
                    Window parentWindow = Window.GetWindow(this);
                    parentWindow.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
