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
       

    }
}
