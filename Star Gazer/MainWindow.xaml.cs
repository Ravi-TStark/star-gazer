using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

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
        public List<string> itms = new List<string>();
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
        public static ImageSource GetIcon(string fileName)
        {
            try
            {
                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileName);
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(icon.Handle, new Int32Rect(0, 0, icon.Width, icon.Height), BitmapSizeOptions.FromEmptyOptions());
            }
            catch(Exception ex)
            {
                return null;
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
                listBox.Items.Clear();
                itms.Clear();
                /*string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
                using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
                {
                    foreach (string skName in rk.GetSubKeyNames())
                    {
                        using (RegistryKey sk = rk.OpenSubKey(skName))
                        {
                            var displayName = sk.GetValue("DisplayName");
                            var path = sk.GetValue("DisplayIcon");
                                SearchListItem item;
                            if (displayName != null)
                            {
                                if (displayName.ToString().ToLower().Contains(textBox.Text.ToLower()))
                                {
                                    item = new SearchListItem();
                                    item.Width = listBox.Width - 35;
                                    item.label.Content = displayName.ToString();
                                    item.label2.Visibility = Visibility.Hidden;
                                    if (path != null)
                                    {
                                        item.label2.Visibility = Visibility.Visible;
                                        item.label2.Content = Directory.GetParent(path.ToString().Replace("\"",""));
                                        item.apppath = path.ToString();
                                        if(item.apppath.EndsWith(",0"))
                                        {
                                            item.apppath = path.ToString().Replace(",0", "");
                                        }
                                    }
                                    if (System.IO.Path.GetExtension(item.apppath) == ".exe")
                                    {
                                        item.image.Source = GetIcon(item.apppath);
                                        listBox.Items.Add(item);
                                        itms.Add(item.apppath);
                                    }
                                }
                            }
                        }
                    }

                }
                //
                string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
                using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
                {
                    foreach (string skName in rk.GetSubKeyNames())
                    {
                        using (RegistryKey sk = rk.OpenSubKey(skName))
                        {
                            var displayName = sk.GetValue("");
                            var path = sk.GetValue("Path");
                            SearchListItem item;
                            if (displayName != null)
                            {
                                if (displayName.ToString().ToLower().Contains(textBox.Text.ToLower()))
                                {
                                    item = new SearchListItem();
                                    item.Width = listBox.Width - 35;
                                    item.label.Content = GetAppName(displayName.ToString().Replace("\"", ""));
                                    item.label2.Visibility = Visibility.Hidden;
                                    if (path != null)
                                    {
                                        item.label2.Visibility = Visibility.Visible;
                                        item.label2.Content = path.ToString();
                                        item.apppath = displayName.ToString().Replace("\"", "");
                                    }
                                    else
                                    {
                                        item.label2.Visibility = Visibility.Visible;
                                        item.label2.Content = Directory.GetParent(displayName.ToString().Replace("\"", ""));
                                        item.apppath = displayName.ToString().Replace("\"", "");
                                    }
                                    item.image.Source = GetIcon(item.apppath);
                                    if (!itms.Contains(item.apppath) && File.Exists(item.apppath))
                                    {
                                        //itms.Add(item.apppath);
                                        //listBox.Items.Add(item);
                                    }
                                }
                            }
                        }
                    }
                }*/
                //
                foreach (string fil in Directory.EnumerateFiles("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\", "*.lnk", SearchOption.AllDirectories))
                {
                    var item = new SearchListItem();
                    item.Width = listBox.Width - 35;
                    item.label.Content = System.IO.Path.GetFileNameWithoutExtension(fil);
                    item.label2.Visibility = Visibility.Visible;
                    item.apppath = fil;
                    item.label2.Content = Directory.GetParent(item.apppath);
                    item.image.Source = GetIcon(item.apppath);
                    if (item.label.Content.ToString().ToLower().Contains(textBox.Text.ToLower()) || System.IO.Path.GetFileNameWithoutExtension(item.apppath).ToLower().Contains(textBox.Text.ToLower()))
                    {
                        listBox.Items.Add(item);
                    }
                }
                //
                if (listBox.Items.Count == 0)
                {
                    SearchListItem item;
                    item = new SearchListItem();
                    item.Width = listBox.Width - 35;
                    item.label.Content = "No match found";
                    item.label2.Visibility = Visibility.Hidden;
                    listBox.Items.Add(item);

                }
                listBox.Visibility = Visibility.Visible;
                //
            }
        }

        private void sGazer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            sGazer.MaxHeight = SystemParameters.WorkArea.Height;
            sGazer.MaxWidth = SystemParameters.WorkArea.Width;
        }
        
        private void listBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchListItem tmp = (SearchListItem)listBox.SelectedItem;
                tmp.Click();
            }
        }

        public string GetAppName(string path)
        {
            if (File.Exists(path))
            {
                FileVersionInfo inf = FileVersionInfo.GetVersionInfo(path);
                return inf.ProductName;
            }
            return "";
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                SearchListItem tmp = (SearchListItem)listBox.Items[0];
                if(tmp.label.Content.ToString() != "No match found")
                {
                    tmp.Click();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    this.Close();
                }
            }
        }
        private string GetShortcutTarget(string file)
        {
            try
            {
                if (System.IO.Path.GetExtension(file).ToLower() != ".lnk")
                {
                    throw new Exception("Supplied file must be a .LNK file");
                }

                FileStream fileStream = File.Open(file, FileMode.Open, FileAccess.Read);
                using (System.IO.BinaryReader fileReader = new BinaryReader(fileStream))
                {
                    fileStream.Seek(0x14, SeekOrigin.Begin);     // Seek to flags
                    uint flags = fileReader.ReadUInt32();        // Read flags
                    if ((flags & 1) == 1)
                    {                      // Bit 1 set means we have to
                                           // skip the shell item ID list
                        fileStream.Seek(0x4c, SeekOrigin.Begin); // Seek to the end of the header
                        uint offset = fileReader.ReadUInt16();   // Read the length of the Shell item ID list
                        fileStream.Seek(offset, SeekOrigin.Current); // Seek past it (to the file locator info)
                    }

                    long fileInfoStartsAt = fileStream.Position; // Store the offset where the file info
                                                                 // structure begins
                    uint totalStructLength = fileReader.ReadUInt32(); // read the length of the whole struct
                    fileStream.Seek(0xc, SeekOrigin.Current); // seek to offset to base pathname
                    uint fileOffset = fileReader.ReadUInt32(); // read offset to base pathname
                                                               // the offset is from the beginning of the file info struct (fileInfoStartsAt)
                    fileStream.Seek((fileInfoStartsAt + fileOffset), SeekOrigin.Begin); // Seek to beginning of
                                                                                        // base pathname (target)
                    long pathLength = (totalStructLength + fileInfoStartsAt) - fileStream.Position - 2; // read
                                                                                                        // the base pathname. I don't need the 2 terminating nulls.
                    char[] linkTarget = fileReader.ReadChars((int)pathLength); // should be unicode safe
                    var link = new string(linkTarget);

                    int begin = link.IndexOf("\0\0");
                    if (begin > -1)
                    {
                        int end = link.IndexOf("\\\\", begin + 2) + 2;
                        end = link.IndexOf('\0', end) + 1;

                        string firstPart = link.Substring(0, begin);
                        string secondPart = link.Substring(end);

                        return firstPart + secondPart;
                    }
                    else
                    {
                        return link;
                    }
                }
            }
            catch
            {
                return "";
            }
        }
    }
}