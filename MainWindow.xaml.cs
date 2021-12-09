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
using Sudoku_Games.Features;
using Sudoku_Games.ViewModels;


namespace Sudoku_Games
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int cote = 9;
        //public Grid gameAreaGrid = new Grid();
        private static ViewModel_MainPage vmMainPage;
        //private ViewModel_GameArea vmGameArea;
        private CommandInvoker invoker;


        public MainWindow()
        {
            InitializeComponent();
            //board.GetCell(0, 0).setValue(0);
            invoker = CommandInvoker.Instance;
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
            //invoker.Undo();
            //invoker.Redo();
            //var grid = Board.Instance().getGrid();
            //Memento.Instance().SaveMemento();
            //Board.Instance().setGrid(Memento.Instance().LoadMemento());
            invoker.Undo();
            vmMainPage.DrawBoard();
            //invoker.Nothing();
        }

        private void redo_Click(object sender, RoutedEventArgs e)
        {
            invoker.Redo();
            vmMainPage.DrawBoard();
            //invoker.Redo();
            //vmMainPage.DrawBoard();


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

        private void color0_Click(object sender, RoutedEventArgs e)
        {
            if(vmMainPage.getSelectMode())
            {
                vmMainPage.ColorSelectedCell("c6ff1a");
            }
            else
            {
                vmMainPage.ShareBackgroundColorToAllCell("c6ff1a");
            }
        } 
        
        private void color1_Click(object sender, RoutedEventArgs e)
        {
            if (vmMainPage.getSelectMode())
            {
                vmMainPage.ColorSelectedCell("ffff33");
            }
            else
            {
                vmMainPage.ShareBackgroundColorToAllCell("ffff33");
            }
        }

        private void color2_Click(object sender, RoutedEventArgs e)
        {
            if (vmMainPage.getSelectMode())
            {
                vmMainPage.ColorSelectedCell("ff1a75");
            }
            else
            {
                vmMainPage.ShareBackgroundColorToAllCell("ff1a75");
            }
        }

        private void color3_Click(object sender, RoutedEventArgs e)
        {
            if (vmMainPage.getSelectMode())
            {
                vmMainPage.ColorSelectedCell("ff1a1a");
            }
            else
            {
                vmMainPage.ShareBackgroundColorToAllCell("ff1a1a");
            }
        }

        private void color4_Click(object sender, RoutedEventArgs e)
        {
            if (vmMainPage.getSelectMode())
            {
                vmMainPage.ColorSelectedCell("cc6666");
            }
            else
            {
                vmMainPage.ShareBackgroundColorToAllCell("cc6666");
            }
        }

        private void color5_Click(object sender, RoutedEventArgs e)
        {
            if (vmMainPage.getSelectMode())
            {
                vmMainPage.ColorSelectedCell("ff1aff");
            }
            else
            {
                vmMainPage.ShareBackgroundColorToAllCell("ff1aff");
            }
        }

        private void color6_Click(object sender, RoutedEventArgs e)
        {
            if (vmMainPage.getSelectMode())
            {
                vmMainPage.ColorSelectedCell("ff8c1a");
            }
            else
            {
                vmMainPage.ShareBackgroundColorToAllCell("ff8c1a");
            }
        }

        private void color7_Click(object sender, RoutedEventArgs e)
        {
            if (vmMainPage.getSelectMode())
            {
                vmMainPage.ColorSelectedCell("ffb31a");
            }
            else
            {
                vmMainPage.ShareBackgroundColorToAllCell("ffb31a");
            }
        }

        private void color8_Click(object sender, RoutedEventArgs e)
        {
            if (vmMainPage.getSelectMode())
            {
                vmMainPage.ColorSelectedCell("ffffff");
            }
            else
            {
                vmMainPage.ShareBackgroundColorToAllCell("ffffff");

            }
        }

        private void newGame_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.NewGame();
            //MessageBox.Show("youpi");
        }

        private void saveGame_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.SaveBoard();
        }

        private void loadGame_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.LoadBoard();
        }

        private void selectionForPN_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.TurnOnSelectModeForPN();
        }

        private void chpnd_Click(object sender, RoutedEventArgs e)
        {
            vmMainPage.ChangeDisplaypn();
        }
    }
}
