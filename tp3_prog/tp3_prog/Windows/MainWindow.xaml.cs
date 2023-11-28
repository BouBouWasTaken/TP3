using System;
using System.Collections.Generic;
using System.Windows;
using tp3_prog.Classes.Characters;

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

            //Window newGameWindow = new PartyCreationWindow();
            //newGameWindow.Show();


            // Inventory Window now takes a merchant
            List<Hero> heroes = new List<Hero>();

            Hero Bob = new()
            {
                Name = "Bob"
            };

            Hero Judith = new()
            {
                Name = "Judith"
            };

            heroes.Add(Bob);
            heroes.Add(Judith);
            Party party = new(heroes);

            Classe Rogue = new()
            {
                Name = "Rogue",
            };

            Classe Soldier = new()
            {
                Name = "Soldier",
            };

            Equipment Sword = new()
            {
                Name = "Sword of Kaine",
                CurrentOwner = Bob,
                Amount = 1,
                Slot = EquipmentSlot.Sword,
                Description = "The greatest sword of all.",
                Price = 999,
            };

            Equipment Shield = new()
            {
                Name = "Shield of Magnus",
                CurrentOwner = Judith,
                Amount = 1,
                Slot = EquipmentSlot.Shield,
                Description = "The smallest shield of all.",
                Price = 1,
            };



            Sword.AddClass(Rogue);
            Shield.AddClass(Soldier);

            party.Inventory.Add(Sword);
            party.Inventory.Add(Shield);

            Window newGameWindow = new InventoryWindow(party);
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
            Close();
        }
    }
}
