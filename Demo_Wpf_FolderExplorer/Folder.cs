using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Wpf_FolderExplorer
{
    public class Folder
    {
        private DirectoryInfo _folder;
        private ObservableCollection<Folder> _subFolders;
        private ObservableCollection<FileInfo> _files;

        public Folder()
        {
            FullPath = @"C:\users\velisj\pictures";
        }

        public string Name
        {
            get
            {
                return _folder.Name;
            }
        }

        public string FullPath
        {
            get
            {
                return _folder.FullName;
            }

            set
            {
                if (Directory.Exists(value))
                {
                    _folder = new DirectoryInfo(value);
                }
                else
                {
                    throw new ArgumentException("must exist", "fullPath");
                }
            }
        }

        public ObservableCollection<FileInfo> Files
        {
            get
            {
                if (_files == null)
                {
                    _files = new ObservableCollection<FileInfo>();
                    FileInfo[] fi = _folder.GetFiles();
                    for (int i = 0; i < fi.Length; i++)
                    {
                        _files.Add(fi[i]);
                    }
                }

                return _files;
            }
        }

        public ObservableCollection<Folder> SubFolders
        {
            get
            {
                if (_subFolders == null)
                {
                    _subFolders = new ObservableCollection<Folder>();

                    DirectoryInfo[] di = _folder.GetDirectories();

                    for (int i = 0; i < di.Length; i++)
                    {
                        Folder newFolder = new Folder();
                        newFolder.FullPath = di[i].FullName;
                        _subFolders.Add(newFolder);
                    }
                }

                return _subFolders;
            }
        }
    }
}
