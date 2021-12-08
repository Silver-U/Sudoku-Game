using Sudoku_Games.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Games.Features
{
    public class SaveAndLoad
    {
        private const int cote = 9;
        static string  directory = "save1.txt";
        public static void SaveGame(Board board)
        {       
            try
            {
                if(File.Exists(directory))
                {
                    File.Delete(directory);
                }
                //(StreamWriter saveFile = File.CreateText(directory) new StreamWriter(directory)
                using (StreamWriter saveFile = File.CreateText(directory))
                {
                    IList<string> boardString = BoardToString(board);

                    foreach (string s in boardString)
                    {
                        saveFile.WriteLine(s);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static IList<string> BoardToString(Board board)
        {
            IList<string> boardString = new List<string>();
            foreach(Cell cell in board.getGrid())
            {
                boardString.Add(CelltoString(cell));
            }

            return boardString;
        }

        private static string CelltoString(Cell cell)
        {
            return cell.getValue().ToString() + "#" + cell.getColorValue() + "#" + cell.PnToString() + "#" + cell.getEditable().ToString();
        }
        public static void LoadGame()
        {
            Board board = Board.Instance();
            string[] lines = File.ReadAllLines(directory);

            board.setGrid(StringsToCells(lines));
        }

        private static Cell[,] StringsToCells(string[] s)
        {
            Cell[,] cells = Board.InitialiseEmptyGrid();

            for (int i = 0; i < cote; i++)
            {
                for (int j = 0; j < cote; j++)
                {
                    cells[i, j] = StringToCell(s[(cote * i) + j]);
                }
            }

            return cells;
        }

        private static Cell StringToCell(string s)
        {
            var cellElements = s.Split('#');
            int value = int.Parse(cellElements[0]);
            string color = cellElements[1];
            bool editable = bool.Parse(cellElements[3]);

            return new Cell(value, color, StringToHashset(cellElements[2]), editable);
            
        }

        private static HashSet<int> StringToHashset(string s)
        {
            if (s.Equals(" "))
                return null;
            HashSet<int> temphs = new HashSet<int>();
            foreach (char c in s)
            {
                temphs.Add(int.Parse(c.ToString()));
            }
            return temphs;
        }
    }
}
