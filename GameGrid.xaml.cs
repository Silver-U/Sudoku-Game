using Sudoku_Games.Model;
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

namespace Sudoku_Games
{
    /// <summary>
    /// Interaction logic for GameGrid.xaml
    /// </summary>
    public partial class GameGrid : UserControl
    {
        private const int cote = 9;
        private Window window;
        Grid grid = new Grid();
        public GameGrid()
        {
            window = new MainWindow();
            window.Title = "Test GRid";

            InsertSubGridIntoGrid(grid);
            window.Content = grid;
            window.Show();
            InitializeComponent();
            
            
        }

        private Grid DrawGrid()
        {
            Grid grid = new Grid();
            for (int i = 0; i < cote; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < cote; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            return grid;
        }

        public Grid DrawSubGrid()
        {
            Grid subGrid = new Grid();
            for (int i = 0; i < 3; i++)
            {
                subGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < 3; i++)
            {
                subGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            return subGrid;
        }

        public void InsertSubGridIntoGrid(Grid grid)
        {
            grid = DrawGrid();
            for (int i = 0; i < cote; i++)
            {
                for (int j = 0; j < cote; j++)
                {
                    Grid subGrid = DrawSubGrid();
                    Grid.SetColumn(subGrid, j);
                    Grid.SetRow(subGrid, i);
                }
            }
        }
    }
}
