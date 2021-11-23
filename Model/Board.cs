using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Games.Model
{
    public class Board
    {
        private const int cote = 9;
        private Cell[,] grid;

        public Board()
        {
            this.grid = InitialiseEmptyGrid();
        }

        public Board(Cell[,] cells)
        {
            grid = cells;
        }

        private Cell[,] InitialiseEmptyGrid()
        {
            Cell[,] cells = new Cell[cote, cote];
            for(int i = 0; i < cote; i++)
            {
                for (int j = 0; j < cote; j++)
                {
                    cells[i, j] = new Cell();
                }
            }

            return cells;
        }

        public Cell[,] getGrid()
        {
            return grid;
        }

        public void setGrid(Cell[,] cells)
        {
            grid = cells;
        }

        public Cell GetCell(int ligne, int colone)
        {
            return grid[ligne, colone];
        }

        public void SeTCell(int ligne, int colone, Cell cell)
        {
            grid[ligne, colone] = cell;
        }

        public int geTCellValue(int ligne, int colone)
        { 
           return  grid[ligne, colone].getValue();
        }

        public void SeTCellValue(int ligne, int colone, int value)
        {
            grid[ligne, colone].setValue(value);
        }

        public Cell[] GetRow(int row)
        {
            return Enumerable.Range(0, cote).Select(x => grid[row, x]).ToArray();
        }

        public Cell[] GetCol(int col)
        {
            return Enumerable.Range(0, cote).Select(x => grid[x, col]).ToArray();
        }

        public Cell[] GetSubGrid(int row, int col)
        {
            int rowSubGrid = row / 3;
            int colSubGrid = col / 3;

            IList<Cell> subGrid = new List<Cell>();

            for(int i = rowSubGrid * 3; i < (rowSubGrid + 1) * 3; i++)
            {
                for (int j = colSubGrid * 3; j < (colSubGrid + 1) * 3; j++)
                {
                    subGrid.Add(GetCell(i, j));
                }
            }

            return subGrid.ToArray();
        }

        public bool CheckIfCellValide(int row, int col)
        {
            Cell cellToCheck = GetCell(row, col);

            bool subgrid = CheckDoublonCellInArrayCell(GetSubGrid(row, col), cellToCheck);
            bool _row = CheckDoublonCellInArrayCell(GetRow(row), cellToCheck);
            bool _col = CheckDoublonCellInArrayCell(GetCol(col), cellToCheck);

            if (cellToCheck.getValue() != 0)
                return !_row && !_col && !subgrid;

            return true;
            //return !CheckDoublonCellInArrayCell(GetRow(row), cellToCheck) && !CheckDoublonCellInArrayCell(GetCol(col), cellToCheck) && !CheckDoublonCellInArrayCell(GetSubGrid(row, col), cellToCheck);

        }

        public bool CheckDoublonCellInArrayCell(Cell[] arrayCell, Cell cell)
        {
            int i = 0;

            foreach(Cell cellOfArray in arrayCell)
            {
                if(cell.Equals(cellOfArray))
                    i++;
            }

            if (i > 1)
                return true;

            return false;

            //for (int i = 0; i < cote; i++)
            //{
            //    if (i == positionOfTarget)
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        if (arrayCell[i].Equals(cell))
            //            return true;
            //    }
            //}

            //return false;
        }
    }
}
