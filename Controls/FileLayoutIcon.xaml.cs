using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace File_Explorer.Controls
{
    /// <summary>
    ///     Interaction logic for FileLayout.xaml
    /// </summary>
    public partial class FileLayoutIcon : UserControl
    {
        public string FullPath;

        public FileLayoutIcon(string fileName, string extension, string fullPath)
        {
            InitializeComponent();
            TextBlockFileName.Text = fileName;
            FullPath = fullPath;
            switch (extension)
            {
                case ".ini":
                {
                    IconFile.Kind = PackIconKind.FileXml;
                    break;
                }
                case ".xml":
                {
                    IconFile.Kind = PackIconKind.FileXml;
                    break;
                }
                case ".dll":
                {
                    IconFile.Kind = PackIconKind.File;
                    break;
                }
                case ".pdf":
                {
                    IconFile.Kind = PackIconKind.FilePdf;
                    break;
                }
                case ".mp3":
                {
                    IconFile.Kind = PackIconKind.FileMusic;
                    break;
                }
                case ".wav":
                {
                    IconFile.Kind = PackIconKind.FileMusic;
                    break;
                }
                case ".mp4":
                {
                    IconFile.Kind = PackIconKind.FileVideo;
                    break;
                }
                case ".avi":
                {
                    IconFile.Kind = PackIconKind.FileVideo;
                    break;
                }
                case ".txt":
                {
                    IconFile.Kind = PackIconKind.FileDocument;
                    break;
                }
                case ".zip":
                {
                    IconFile.Kind = PackIconKind.ZipBox;
                    break;
                }
                case ".rar":
                {
                    IconFile.Kind = PackIconKind.ZipBox;
                    break;
                }
                case "folder":
                {
                    IconFile.Kind = PackIconKind.Folder;
                    break;
                }
                default:
                {
                    IconFile.Kind = PackIconKind.FileQuestion;
                    break;
                }
            }
        }
    }
}