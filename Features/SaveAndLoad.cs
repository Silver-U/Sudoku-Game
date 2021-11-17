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

        public void SaveGame(Board grid)
        {
            string filename = "";
            String directory = "GamesState" + filename;
            Cell[,] cells = grid.getGrid();
            try
            {
                if(File.Exists(directory))
                {
                    File.Delete(directory);
                }

                using (StreamWriter saveFile = File.CreateText(directory))
                {
                    string ligneToWrite = "";

                    for(int i = 0; i < cote; i++)
                    {
                        for (int j = 0; j < cote; j++)
                        {
                            ligneToWrite += cells[i, j].getValue() + " ";
                            saveFile.WriteLine(ligneToWrite);
                        }

                        ligneToWrite = "";
                    }

                    saveFile.WriteLine("#Color");

                    for (int i = 0; i < cote; i++)
                    {
                        for (int j = 0; j < cote; j++)
                        {
                            ligneToWrite += cells[i, j].getColorValue() + " ";
                            saveFile.WriteLine(ligneToWrite);
                        }

                        ligneToWrite = "";
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public Board LoadGame(string fileName)
        {
            String directory = "GamesState" + fileName;
            Board grid = new Board();
            string[] lines = File.ReadAllLines(directory);
            IList<string> valuesCells = new List<string>();
            IList<string> colorsCells = new List<string>();
            string[] ligneCells;
            string[] ligneColors;
            bool dontSkip = true;

            foreach (string line in lines)
            {
                if (line == "#Color")
                    dontSkip = false;

                if(dontSkip)
                {
                    valuesCells.Add(line);
                }
                else
                {
                    colorsCells.Add(line);
                }
            }

            for(int i = 0; i < cote; i++)
            {
                ligneCells = valuesCells[i].Split();
                ligneColors = colorsCells[i].Split();

                for (int j = 0; j < cote; j++)
                {
                    grid.SeTCell(i, j, new Cell(int.Parse(ligneCells[j]), ligneColors[j]));
                }
            }

            return grid;

        }
    }
}
