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
using Sudoku_Games.Model;


namespace Sudoku_Games
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameController GameController;
        private Board grid = new Board();
        private const int cote = 9;
        private Grid gameAreaGrid = new Grid();
        public MainWindow()
        {
            InitializeComponent();
            GameController = new GameController(this, grid);
            DrawGrid(grid);
        }

        public void DrawGrid(Board grid)
        {
            for(int i = 0; i < cote; i++)
            {
                gameAreaGrid.ColumnDefinitions.Add(new ColumnDefinition()); 
            }

            for (int i = 0; i < cote; i++)
            {
                gameAreaGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        public void DrawSubGrid()

        //public Grid CreateGrid

    }
}
