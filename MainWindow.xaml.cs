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
using Sudoku_Games.ViewModels;


namespace Sudoku_Games
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Board board = new Board();
        private const int cote = 9;
        //public Grid gameAreaGrid = new Grid();
        private static ViewModel_MainPage vmMainPage;
        //private ViewModel_GameArea vmGameArea;


        public MainWindow()
        {
            InitializeComponent();

            //board.GetCell(0, 0).setValue(0);
            
            //GameController = new GameController(this, board);
            //vmGameArea = new ViewModel_GameArea(GameArea);
            vmMainPage = new ViewModel_MainPage(this, this.GameArea);
            
            //GameArea.Children.Add(InsertSubGridIntoGrid(DrawGrid()));

            //gameAreaGrid.Children.
        }

        public static void setMP(ViewModel_MainPage viewModel_MainPage)
        {
            vmMainPage = viewModel_MainPage;
        }
        private void color_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel_MainPage.DisableTextboxes();
            vmMainPage.TurnOnColorMode();
            //vmMainPage.TurnOnColorMode();
        }

        private void undo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void finalValue_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.TurnOnVAlueMode();
            //vmMainPage.TurnOnVAlueMode();
        }

        private void mayValue_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.TurnOnPNMode();
            //vmMainPage.TurnOnPNMode();
        }

        private void selection_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.TurnOnSelectMode();
            //vmMainPage.TurnOnSelectMode();
        }
        private void redo_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void color0_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.ShareBackgroundColorToAllCell("c6ff1a");
        } 
        
        private void color1_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.ShareBackgroundColorToAllCell("ffff33");
        }

        private void color2_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.ShareBackgroundColorToAllCell("ff1a75");
        }

        private void color3_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.ShareBackgroundColorToAllCell("ff1a1a");
        }

        private void color4_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.ShareBackgroundColorToAllCell("cc6666");
        }

        private void color5_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.ShareBackgroundColorToAllCell("ff1aff");
        }

        private void color6_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.ShareBackgroundColorToAllCell("ff8c1a");
        }

        private void color7_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.ShareBackgroundColorToAllCell("ffb31a");
        }

        private void color8_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.ShareBackgroundColorToAllCell("ffffff");
        }

        private void newGame_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.LoadBoard(new Board());
            //MessageBox.Show("youpi");
        }
    }
}
