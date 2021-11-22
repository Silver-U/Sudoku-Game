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

namespace Sudoku_Games.View
{
    /// <summary>
    /// Interaction logic for GridView.xaml
    /// </summary>
    public partial class GridView : UserControl
    {
        private const int cote = 9;
        public CellOfGrid[,] cellsofGrid = new CellOfGrid[cote, cote];
        public Board board;
        IList<TextBox> selectedTextBox = new List<TextBox>();
        public GridView()
        {
            InitializeComponent();
            board = new Board();
            BindingGridCells();
            BindingGridCellsToBoard();
        }

        private void BindingGridCells()
        {
            cellsofGrid[0, 0] = cell00;
            cellsofGrid[0, 1] = cell01;
            cellsofGrid[0, 2] = cell02;
            cellsofGrid[0, 3] = cell03;
            cellsofGrid[0, 4] = cell04;
            cellsofGrid[0, 5] = cell05;
            cellsofGrid[0, 6] = cell06;
            cellsofGrid[0, 7] = cell07;
            cellsofGrid[0, 8] = cell08;

            cellsofGrid[1, 0] = cell10;
            cellsofGrid[1, 1] = cell11;
            cellsofGrid[1, 2] = cell12;
            cellsofGrid[1, 3] = cell13;
            cellsofGrid[1, 4] = cell14;
            cellsofGrid[1, 5] = cell15;
            cellsofGrid[1, 6] = cell16;
            cellsofGrid[1, 7] = cell17;
            cellsofGrid[1, 8] = cell18;

            cellsofGrid[2, 0] = cell20;
            cellsofGrid[2, 1] = cell21;
            cellsofGrid[2, 2] = cell22;
            cellsofGrid[2, 3] = cell23;
            cellsofGrid[2, 4] = cell24;
            cellsofGrid[2, 5] = cell25;
            cellsofGrid[2, 6] = cell26;
            cellsofGrid[2, 7] = cell27;
            cellsofGrid[2, 8] = cell28;

            cellsofGrid[3, 0] = cell30;
            cellsofGrid[3, 1] = cell31;
            cellsofGrid[3, 2] = cell32;
            cellsofGrid[3, 3] = cell33;
            cellsofGrid[3, 4] = cell34;
            cellsofGrid[3, 5] = cell35;
            cellsofGrid[3, 6] = cell36;
            cellsofGrid[3, 7] = cell37;
            cellsofGrid[3, 8] = cell38;

            cellsofGrid[4, 0] = cell40;
            cellsofGrid[4, 1] = cell41;
            cellsofGrid[4, 2] = cell42;
            cellsofGrid[4, 3] = cell43;
            cellsofGrid[4, 4] = cell44;
            cellsofGrid[4, 5] = cell45;
            cellsofGrid[4, 6] = cell46;
            cellsofGrid[4, 7] = cell47;
            cellsofGrid[4, 8] = cell48;

            cellsofGrid[5, 0] = cell50;
            cellsofGrid[5, 1] = cell51;
            cellsofGrid[5, 2] = cell52;
            cellsofGrid[5, 3] = cell53;
            cellsofGrid[5, 4] = cell54;
            cellsofGrid[5, 5] = cell55;
            cellsofGrid[5, 6] = cell56;
            cellsofGrid[5, 7] = cell57;
            cellsofGrid[5, 8] = cell58;

            cellsofGrid[6, 0] = cell60;
            cellsofGrid[6, 1] = cell61;
            cellsofGrid[6, 2] = cell62;
            cellsofGrid[6, 3] = cell63;
            cellsofGrid[6, 4] = cell64;
            cellsofGrid[6, 5] = cell65;
            cellsofGrid[6, 6] = cell66;
            cellsofGrid[6, 7] = cell67;
            cellsofGrid[6, 8] = cell68;

            cellsofGrid[7, 0] = cell70;
            cellsofGrid[7, 1] = cell71;
            cellsofGrid[7, 2] = cell72;
            cellsofGrid[7, 3] = cell73;
            cellsofGrid[7, 4] = cell74;
            cellsofGrid[7, 5] = cell75;
            cellsofGrid[7, 6] = cell76;
            cellsofGrid[7, 7] = cell77;
            cellsofGrid[7, 8] = cell78;

            cellsofGrid[8, 0] = cell80;
            cellsofGrid[8, 1] = cell81;
            cellsofGrid[8, 2] = cell82;
            cellsofGrid[8, 3] = cell83;
            cellsofGrid[8, 4] = cell84;
            cellsofGrid[8, 5] = cell85;
            cellsofGrid[8, 6] = cell86;
            cellsofGrid[8, 7] = cell87;
            cellsofGrid[8, 8] = cell88;
        }

        private void BindingGridCellsToBoard()
        {
            for(int i  = 0; i < cote; i++)
            {
                for (int j = 0; j < cote; j++)
                {
                    board.SeTCell(i, j, cellsofGrid[i, j].GetCell());
                }
            }           
        }

        private void cell00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("board[0,1]" + board.geTCellValue(0, 1));
        }

        private void cell00_MouseEnter(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("board[0,1]" + board.geTCellValue(0, 1));
        }

        private void cell00_KeyUp(object sender, KeyEventArgs e)
        {
            //if(!board.CheckIfCellValide(0, 0))
            //{
            //    //MessageBox.Show("board[0,1]" + board.geTCellValue(0, 1));
            //    cell00.Background = Brushes.BlueViolet;
            //}

            ////MessageBox.Show("board[0,1]" + board.geTCellValue(0, 1));



            //TextBox cell = (TextBox)(e.Source as UIElement);
            //string test = cell.Name.ToString();
            ////int row = int.Parse(tempCellTextbox.Name[-1]);
            //int row = (int)(test[-2] - '0');
            //int col = (int)(test[-1] - '0');
            //int row = ce;
            //int col = Grid.GetColumn(cell);
            if (e.Key != Key.NumPad0)
            {
                cell00.CellValue.Text = e.Key.ToString().Last().ToString();
                if (!board.CheckIfCellValide(0, 0))
                {
                    //MessageBox.Show("board[0,1]" + board.geTCellValue(0, 1));
                    cell00.Background = Brushes.BlueViolet;
                    //MessageBox.Show(e.Source.ToString());
                    ////MessageBox.Show("board[0,1]" + board.geTCellValue(0, 1));
                }
                else
                {
                    cell00.Background = Brushes.DarkBlue;
                }
            }
        }

        private void cell00_KeyDown(object sender, KeyEventArgs e)
        {           
            if(e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
            {
                var value = ValueForSelectMode(e);
                foreach(TextBox textBox in selectedTextBox)
                {
                    textBox.Text = value;
                }

                selectedTextBox = new List<TextBox>();
            }
        }

        private string ValueForSelectMode(KeyEventArgs keyEventArgs)
        {
            return keyEventArgs.Key.ToString();
        }



        private void cell00_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            selectedTextBox.Add(e.Source as TextBox);
        }
    }
}
