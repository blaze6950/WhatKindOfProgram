using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace WhatKindOfProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Registry registry;
        public MainWindow()
        {
            InitializeComponent();
            RegistryKey root = Registry.ClassesRoot
            //Path.
        }

        private void ExtensionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var extension = ExtensionTextBox.Text;
            if (extension.Contains("."))
            {
                extension.Remove(extension.IndexOf("."), 1);
            }

        }
    }
}
