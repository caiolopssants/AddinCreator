using System;
using System.Collections.Generic;
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
using System.IO;
using Microsoft.Win32;

namespace AddinCreator
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> document = new List<string>();
            try
            {
                if (command_CheckBox.IsChecked.GetValueOrDefault() && !application_CheckBox.IsChecked.GetValueOrDefault()) { document = CreatCommandAddinDoc(addin_Title_TextBox_Com.Text, addin_Description_TextBox_Com.Text, assembly_Path_TextBox_Com.Text, assembly_FullClassName_TextBox_Com.Text, Guid.Parse(clientID_GUID_TextBox_Com.Text), vendorID_TextBox_Com.Text, vendorID_Description_TextBox_Com.Text); }
                else
                {
                    if (!command_CheckBox.IsChecked.GetValueOrDefault() && application_CheckBox.IsChecked.GetValueOrDefault()) { document = CreatApplicationAddinDoc(addin_Title_TextBox_App.Text, assembly_Path_TextBox_App.Text, assembly_FullClassName_TextBox_App.Text, Guid.Parse(clientID_GUID_TextBox_App.Text), vendorID_TextBox_App.Text, vendorID_Description_TextBox_Com.Text); }
                    else
                    {
                        if (command_CheckBox.IsChecked.GetValueOrDefault() && application_CheckBox.IsChecked.GetValueOrDefault()) { document = CreatCommandApplicationAddinDoc(addin_Title_TextBox_Com.Text, addin_Description_TextBox_Com.Text, assembly_Path_TextBox_Com.Text, assembly_FullClassName_TextBox_Com.Text, Guid.Parse(clientID_GUID_TextBox_Com.Text), vendorID_TextBox_Com.Text, vendorID_Description_TextBox_Com.Text, addin_Title_TextBox_App.Text, assembly_Path_TextBox_App.Text, assembly_FullClassName_TextBox_App.Text, Guid.Parse(clientID_GUID_TextBox_App.Text), vendorID_TextBox_App.Text, vendorID_Description_TextBox_Com.Text); }
                        else
                        {
                            MessageBox.Show("Select any options: \n\n*Command; \n*Application.");
                            return;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, $"Creat addin document process error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                SaveFileDialog sFD = new SaveFileDialog() { Title = "Set path to addin document save", AddExtension = true, Filter = "Addin doc | *.addin" };
                if (sFD.ShowDialog() == true)
                {
                    File.WriteAllLines(sFD.FileName, document);
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, $"Save addin document process error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void GenerateGUID_CheckBox_Com_Checked(object sender, RoutedEventArgs e)
        {
            clientID_GUID_TextBox_Com.Text = Guid.NewGuid().ToString();
            clientID_GUID_TextBox_Com.IsEnabled = false;
        }

        private void GenerateGUID_CheckBox_Com_Unchecked(object sender, RoutedEventArgs e)
        {
            clientID_GUID_TextBox_Com.IsEnabled = true;
        }

        private void GenerateGUID_CheckBox_App_Checked(object sender, RoutedEventArgs e)
        {
            clientID_GUID_TextBox_App.Text = Guid.NewGuid().ToString();
            clientID_GUID_TextBox_App.IsEnabled = false;
        }

        private void GenerateGUID_CheckBox_App_Unchecked(object sender, RoutedEventArgs e)
        {
            clientID_GUID_TextBox_App.IsEnabled = true;
        }

        List<string> CreatCommandAddinDoc(string addinTitle, string addinDescription, string assemblyPath, string fullClassName, Guid clientID, string vendorID, string vendorDescription)
        {
            return new List<string>()
            {
                $@"<?xml version={"\""}1.0{"\""} encoding={"\""}utf-8{"\""}?>",
                $@"<RevitAddIns>",
                $@"  <AddIn Type={"\""}Command{"\""}>",
                $@"    <Text>{addinTitle}</Text>",
                $@"    <Description>{addinDescription}</Description>",
                $@"    <Assembly>{assemblyPath}</Assembly>",
                $@"    <FullClassName>{fullClassName}</FullClassName>",
                $@"    <ClientId>{clientID}</ClientId>",
                $@"    <VendorId>{vendorID}</VendorId>",//$@"    <VendorId>br.com.mha</VendorId>",
                $@"    <VendorDescription>{vendorDescription}</VendorDescription>",//$@"    <VendorDescription>MHA Engenharia LTDA</VendorDescription>",
                $@"  </AddIn>",
                $@"</RevitAddIns>",
            };
        }

        List<string> CreatApplicationAddinDoc(string addinTitle, string assemblyPath, string fullClassName, Guid clientID, string vendorID, string vendorDescription)
        {
            return new List<string>()
            {
                $@"<?xml version={"\""}1.0{"\""} encoding={"\""}utf-8{"\""}?>",
                $@"<RevitAddIns>",
                $@"  <AddIn Type={"\""}Application{"\""}>",
                $@"    <Name>App {addinTitle}</Name>",
                $@"    <Assembly>{assemblyPath}</Assembly>",
                $@"    <FullClassName>{fullClassName}</FullClassName>",
                $@"    <ClientId>{clientID}</ClientId>",
                $@"    <VendorId>{vendorID}</VendorId>",//$@"    <VendorId>br.com.mha</VendorId>",
                $@"    <VendorDescription>{vendorDescription}</VendorDescription>",//$@"    <VendorDescription>MHA Engenharia LTDA</VendorDescription>",
                $@"  </AddIn>",
                $@"</RevitAddIns>",
            };
        }

        List<string> CreatCommandApplicationAddinDoc(string addinTitle_Command, string addinDescription_Command, string assemblyPath_Command, string fullClassName_Command, Guid clientID_Command, string vendorID_Command, string vendorDescription_Command, string addinTitle_Application, string assemblyPath_Application, string fullClassName_Application, Guid clientID_Application, string vendorID_Application, string vendorDescription_Application)
        {
            return new List<string>()
            {
                   $@"<?xml version={"\""}1.0{"\""} encoding={"\""}utf-8{"\""}?>",
                $@"<RevitAddIns>",
                $@"  <AddIn Type={"\""}Command{"\""}>",
                $@"    <Text>{addinTitle_Command}</Text>",
                $@"    <Description>{addinDescription_Command}</Description>",
                $@"    <Assembly>{assemblyPath_Command}</Assembly>",
                $@"    <FullClassName>{fullClassName_Command}</FullClassName>",
                $@"    <ClientId>{clientID_Command}</ClientId>",
                $@"    <VendorId>{vendorID_Command}</VendorId>",//$@"    <VendorId>br.com.mha</VendorId>",
                $@"    <VendorDescription>{vendorDescription_Command}</VendorDescription>",//$@"    <VendorDescription>MHA Engenharia LTDA</VendorDescription>",
                $@"  </AddIn>",
                $@"  <AddIn Type={"\""}Application{"\""}>",
                $@"    <Name>{addinTitle_Application}</Name>",
                $@"    <Assembly>{assemblyPath_Application}</Assembly>",
                $@"    <FullClassName>{fullClassName_Application}</FullClassName>",
                $@"    <ClientId>{clientID_Application}</ClientId>",
                $@"    <VendorId>{vendorID_Application}</VendorId>",//$@"    <VendorId>br.com.mha</VendorId>",
                $@"    <VendorDescription>{vendorDescription_Application}</VendorDescription>",//$@"    <VendorDescription>MHA Engenharia LTDA</VendorDescription>",
                $@"  </AddIn>",
                $@"</RevitAddIns>",
            };
        }
    }
}
