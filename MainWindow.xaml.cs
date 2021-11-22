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
        private Board board = new Board();
        private const int cote = 9;
        public Grid gameAreaGrid = new Grid();


        public MainWindow()
        {
            board.GetCell(0, 0).setValue(0);
            
            GameController = new GameController(this, board);
            
            //GameArea.Children.Add(InsertSubGridIntoGrid(DrawGrid()));
            InitializeComponent();

            //gameAreaGrid.Children.
        }
        private Grid DrawGrid()
        {
            Grid grid = new Grid();
            grid.ShowGridLines = true;
            for (int i = 0; i < cote; i++)
            {
                grid.ColumnDefinitions.Add(colDefGrid());
            }

            for (int i = 0; i < cote; i++)
            {
                grid.RowDefinitions.Add(rowDefGrid());
            }
            return grid;
        }

        public ColumnDefinition colDefGrid()
        {
            var colDef = new ColumnDefinition();
            colDef.Width = new GridLength(100);
            return colDef;
        }

        public RowDefinition rowDefGrid()
        {
            var rowDef = new RowDefinition();
            rowDef.Height = new GridLength(100);
            return rowDef;
        }

        public Grid DrawSubGrid()
        {
            Grid subGrid = new Grid();
            subGrid.ShowGridLines = true;
            for (int i = 0; i < 3; i++)
            {
                subGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < 3; i++)
            {
                subGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            subGrid.Background = new SolidColorBrush(Colors.Blue);
            //window.Content = subGrid;

            //subGrid.Opacity = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var cellText = CellContent();
                    Grid.SetColumn(cellText, j);
                    Grid.SetRow(cellText, i);
                    subGrid.Children.Add(cellText);
                }
            }

            return subGrid;
        }

        public Grid InsertSubGridIntoGrid(Grid grid)
        {
            grid = DrawGrid();
            grid.ShowGridLines = true;
            for (int i = 0; i < cote; i++)
            {
                for (int j = 0; j < cote; j++)
                {
                    Grid subGrid = DrawSubGrid();
                    subGrid.ShowGridLines = true;
                    Grid.SetColumn(subGrid, j);
                    Grid.SetRow(subGrid, i);
                    grid.Children.Add(subGrid);
                }
            }

            return grid;
        }

        //public Grid FinallGrid(Board board, Grid grid)
        //{
        //    TextBlock cellContent = new TextBlock();
        //    cellContent.Text = "1";
        //    cellContent.FontSize = 15;

        //    int i = 0;
        //    foreach(UIElement uIElement1 in grid.Children)
        //    {
        //        Grid cell = uIElement1 as Grid;
        //        foreach(UIElement uIElement2 in uIElement1.Chil                   )
        //    }


        //    //Grid.
        //    for(int i = 0; i < cote; i ++)
        //    {
        //        for (int j = 0; j < cote; j++)
        //        {
        //            //Grid.GetColumn()
        //            //Grid.SetRow(Grid.SetRow(cellContent, 1), i);

        //        }
        //    }
        //    return grid;
        //}

        public TextBlock CellContent()
        {
            TextBlock cellContent = new TextBlock();
            cellContent.Text = "";
            cellContent.FontSize = 15;
            //cellContent.TextAlignment = TextAlignment.Center;
            cellContent.HorizontalAlignment = HorizontalAlignment.Center;
            cellContent.VerticalAlignment = VerticalAlignment.Center;
            return cellContent;
            //cellContent.bing
        }

        //public Grid CreateGrid

    }
}
