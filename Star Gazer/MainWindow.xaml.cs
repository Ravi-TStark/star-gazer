using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnPreviewKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
        }
        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                label.Visibility = Visibility.Hidden;
                textBox.Focus();
            }
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(textBox.Text.Trim() == "")
            {
                label.Visibility = Visibility.Visible;
            }
        }

        private void sGazer_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Escape)
            {
                Close();
            }
            if(label.Visibility == Visibility.Visible)
            {
                label.Visibility = Visibility.Hidden;
                textBox.Focus();
            }
            if(listBox.Visibility == Visibility.Visible && (e.Key == Key.Down || e.Key==Key.Up) && (listBox.IsKeyboardFocused == false) && (textBox.IsFocused))
            {
                listBox.Focus();
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textBox.Text == "")
            {
                listBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                listBox.Visibility = Visibility.Visible;
                listBox.Items.Clear();
                if(listBox.Items.Count == 0)
                {
                    var item = new SearchListItem();
                    item.Width = listBox.Width-15;
                    item.Height = 64;
                    listBox.Items.Add(item);
                    item = new SearchListItem();
                    item.Width = listBox.Width - 15;
                    item.Height = 64;
                    listBox.Items.Add(item);
                }
            }
        }

        private void sGazer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            sGazer.MaxHeight = SystemParameters.WorkArea.Height;
            sGazer.MaxWidth = SystemParameters.WorkArea.Width;
        }
    }
}
