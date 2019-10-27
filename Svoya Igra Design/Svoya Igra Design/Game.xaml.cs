﻿using System;
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
using System.Windows.Shapes;
using SvoyaIgra;

namespace Svoya_Igra_Design
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private Config _configuration;
        public Game(Config Configuration)
        {
            InitializeComponent();
            _configuration = Configuration;
            StartGame();
        }
        public void StartGame();
        {
            
        }
    }
}
