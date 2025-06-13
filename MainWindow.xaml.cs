﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TutorHelper.DataAccess;

namespace TutorHelper;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //var db = new DBDataAccess("THDataBase");
        //db.TestConnection();
    }

    private void CloseApp_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}