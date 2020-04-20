using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
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
                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                {
                    button_Copy1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
                else
                {
                    Click();
                }
            }
        }

        private void label2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                try
                {
                    Process.Start(label2.Content.ToString());
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Window parentWindow = Window.GetWindow(this);
                parentWindow.Visibility = Visibility.Hidden;
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
                    parentWindow.Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    try
                    {
                        Process.Start("explorer.exe",apppath);
                        Window parentWindow = Window.GetWindow(this);
                        parentWindow.Visibility = Visibility.Hidden;
                    }
                    catch (Exception exp)
                    { 
                    }
                }
            }
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            //runas
            if (File.Exists(apppath))
            {
                try
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = apppath;
                    proc.StartInfo.UseShellExecute = true;
                    proc.StartInfo.Verb = "runas";
                    proc.Start();
                    Window parentWindow = Window.GetWindow(this);
                    parentWindow.Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    try
                    {
                        Process proc = new Process();
                        proc.StartInfo.FileName = "explorer.exe";
                        proc.StartInfo.Arguments = apppath;
                        proc.StartInfo.UseShellExecute = true;
                        proc.StartInfo.Verb = "runas";
                        proc.Start();
                        Window parentWindow = Window.GetWindow(this);
                        parentWindow.Visibility = Visibility.Hidden;
                    }
                    catch (Exception exp)
                    {
                    }
                }
            }
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "explorer.exe";
                proc.StartInfo.Arguments = label2.Content.ToString();
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
                Window parentWindow = Window.GetWindow(this);
                parentWindow.Visibility = Visibility.Hidden;
            }
            catch (Exception exp)
            {

            }
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            //this.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(40,141,141,141));
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            //this.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 141, 141, 141));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Path = @"C:\Windows\System32\cmd.exe";
                Process proc = new Process();
                if (Keyboard.IsKeyDown(Key.LeftCtrl)|| Keyboard.IsKeyDown(Key.RightCtrl))
                {
                    proc.StartInfo.Verb = "runas";
                    MessageBox.Show("I am Here");
                }
                proc.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                proc.StartInfo.WorkingDirectory = Directory.GetParent(GetShortcutTarget(apppath)).FullName;
                proc.StartInfo.Arguments = "/c " + Path;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
                Window parentWindow = Window.GetWindow(this);
                parentWindow.Visibility = Visibility.Hidden;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                button.IsEnabled = false;
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
