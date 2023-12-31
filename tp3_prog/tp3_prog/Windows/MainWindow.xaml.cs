﻿using System;
using System.Windows;

namespace tp3_prog
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Coded by Olivier Vallée

            InitializeComponent();

            // Link the methods to the buttons
            ButtonLoad.Click += ButtonLoad_Click;
            ButtonNew.Click += ButtonNew_Click;
            ButtonSave.Click += ButtonSave_Click;
            ButtonQuit.Click += ButtonQuit_Click;
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {

            Window newGameWindow = new PartyCreationWindow();
            newGameWindow.Show();

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            // Will need to get 
            // Every characters data in the the party
            // The map they're on

            throw new NotImplementedException();
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadSave();
        }

        private void LoadSave()
        {
            // Will need to create the heroes and put them in the party
            // and place them all in the map

            throw new NotImplementedException();
        }

        private void ButtonQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
