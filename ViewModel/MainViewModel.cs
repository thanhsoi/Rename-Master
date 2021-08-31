using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace RenameMaster
{
    class MainViewModel : BaseViewModel
    {
        public ObservableCollection<FileUnit> _FilesToRename = new ObservableCollection<FileUnit>();
        public ObservableCollection<FileUnit> FilesToRename { get => _FilesToRename; set { _FilesToRename = value; OnPropertyChanged(); } }


        public ICommand LoadedWindowCommand { get; set; }
        public ICommand AddByFolder { get; set; }
        public ICommand AddFiles { get; set; }
        public ICommand OKCmd { get; set; }
        public ICommand CancelCmd { get; set; }
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
            });
            AddFiles = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Title = "Select Files",
                    Multiselect = true,

                };
                if (openFileDialog.ShowDialog() == true)
                {
                    foreach (String file in openFileDialog.FileNames)
                    {
                        FilesToRename.Add(new FileUnit(file));
                    }
                }
            });
            AddByFolder = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo dir = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                    FileInfo[] fileInfos = dir.GetFiles();
                    foreach (FileInfo file in fileInfos)
                    {
                        FilesToRename.Add(new FileUnit(file));
                    }
                }
            });
            OKCmd = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
            });
            CancelCmd = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
            });
        }
    }
}
