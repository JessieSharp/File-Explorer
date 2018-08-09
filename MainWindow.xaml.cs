using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
using File_Explorer.Controls;

namespace File_Explorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<FileLayoutIcon> ShownFiles = new List<FileLayoutIcon>();
        public List<string> PathsList = new List<string>();
        private readonly System.Windows.Media.Color _selectColor =
            (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#e1e9ec");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            GenerateView("C:/", true);
            //foreach (var directory in directories)
            //{
            //    var fileLayout = new FileLayoutIcon(directory.Name, "folder");
            //    fileLayout.MouseDown += (o, i) =>
            //    {
            //        ImageThumb.Source = null;
            //        TextBlockName.Text = fileLayout.TextBlockFileName.Text;
            //        TextBlockCaption.Text = "Folder";
            //        TextBlockCreated.Text = directory.CreationTime.ToString();
            //        TextBlockModified.Text = directory.LastWriteTime.ToString();
            //        TextBlockFiles.Text = Directory.GetFiles(directory.FullName, "*", SearchOption.AllDirectories).Length.ToString();
            //        TextBlockSize.Text = ConvertBytesToMegabytes(GetDirectorySize(directory.FullName)).ToString("F") + " MB";
            //    };
            //    WrapPanelFiles.Children.Add(fileLayout);
            //}


            //foreach (var file in files)
            //{
            //    var fileLayout = new FileLayoutIcon(file.Name, file.Extension);
            //    fileLayout.MouseDown += (o, i) =>
            //    {
            //        if (file.Extension == ".jpg" || file.Extension == ".png" || file.Extension == ".bmp")
            //        {
            //            ImageThumb.Source = new BitmapImage(new Uri(file.FullName));
            //        }
            //        else
            //        {
            //            ImageThumb.Source = null;
            //        }
            //        TextBlockName.Text = fileLayout.TextBlockFileName.Text;
            //        TextBlockCaption.Text = MimeMapping.GetMimeMapping(file.Name);
            //        TextBlockCreated.Text = file.CreationTime.ToString();
            //        TextBlockModified.Text = file.LastWriteTime.ToString();
            //        TextBlockFiles.Text = "1";
            //        TextBlockSize.Text = ConvertBytesToMegabytes(file.Length).ToString("F") + " MB";
            //    };
            //    WrapPanelFiles.Children.Add(fileLayout);
            //}   
        }

        public void GenerateView(string path, bool skipPath)
        {
            if (skipPath)
            {
                PathsList.Add(path);
            }
            
            WrapPanelFiles.Children.Clear();
            ShownFiles = FindFilesAndDirectories(path);
            foreach (var file in ShownFiles)
            {
                WrapPanelFiles.Children.Add(file);
            }
        }

        public List<FileLayoutIcon> FindFilesAndDirectories(string path)
        {
            var d = new DirectoryInfo(path);
            var directories = d.GetDirectories();
            var files = d.GetFiles();
            var foundFiles = directories.Select(directory => new FileLayoutIcon(directory.Name, "folder", directory.FullName)).ToList();
            foundFiles.AddRange(files.Select(file => new FileLayoutIcon(file.Name, file.Extension, file.FullName)));
            foreach (var file in foundFiles)
            {
                file.MouseDoubleClick += File_MouseDoubleClick;
            }
            return foundFiles;
        }

        private void File_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var send = sender as FileLayoutIcon;
            var toOpen = ShownFiles.Find(x => Equals(x, send));
            GenerateView(toOpen.FullPath, true);
        }

        private void WrapPanelFiles_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            //foreach (FileLayoutIcon item in WrapPanelFiles.Children)
            //{
            //    item.BorderFile.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 0, 0, 0)); 
            //}
        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonMaximize_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void ButtonMinimize_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void GridTitle_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonBack_OnClick(object sender, RoutedEventArgs e)
        {
            if (PathsList.Count > 2)
            {
                GenerateView(PathsList.ElementAt(PathsList.Count - 2), false);
                PathsList.RemoveAt(PathsList.Count - 1);
            }
        }
    }
}
