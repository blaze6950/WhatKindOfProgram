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
        static RegistryKey classesRoot;
        static RegistryKey extensionRoot;
        static string currentIcon;
        static string currentProgramm;

        public string CurrentIcon
        {
            get => currentIcon;
            set
            {
                currentIcon = value;
                //Event...
            }
        }
        public string CurrentProgramm
        {
            get => currentProgramm;
            set
            {
                currentProgramm = value;
                ResultTextBox.Text = currentProgramm;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            classesRoot = Registry.ClassesRoot;
            extensionRoot = classesRoot;
        }

        private void ExtensionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Find(ExtensionTextBox.Text);
        }

        private void Find(string text)
        {
            if (!text.Contains("."))
            {
                StringBuilder newText = new StringBuilder(text.Length + 1);
                newText.Append(".");
                newText.Append(text);
                text = newText.ToString();
            }
            var currentExtension = extensionRoot.OpenSubKey(text);
            if (currentExtension != null)
            {
                string defaultValueCurrentExtension = (string)currentExtension.GetValue(currentExtension.GetValueNames()[0]);
                var currentExtensionDefaultValue = extensionRoot.OpenSubKey(defaultValueCurrentExtension);

                GetProgramm(currentExtensionDefaultValue.OpenSubKey("shell"));

                GetIcon(currentExtensionDefaultValue.OpenSubKey("DefaultIcon"));
            }
            else
            {
                //MessageBox.Show("No matches found...");
            }
        }

        private void GetProgramm(RegistryKey registryKey)
        {
            string action = (string)registryKey.GetValue(registryKey.GetValueNames()?[0]);
            var currentProgrammKey = registryKey.OpenSubKey(action).OpenSubKey("command");
            CurrentProgramm = (string)currentProgrammKey.GetValue(currentProgrammKey.GetValueNames()[0]);
        }

        private void GetIcon(RegistryKey registryKey)
        {
            
        }
    }
}
