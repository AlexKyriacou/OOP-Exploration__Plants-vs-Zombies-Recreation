using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Grid contains the grass grid that plants are placed on. it is simply a grid of 4x9 cells however allows plants to be placed at discrete coordinates.
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// 2D array of cells that make up the grid
        /// </summary>
        private Cell[,] _grid;
        /// <summary>
        /// Constructor. Initialises the cells to be used in the grid
        /// </summary>
        public Grid()
        {
            _grid = new Cell[4, 9];
            int _x = 24;
            int _y = 2;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _grid[i, j] = EntityFactory.SpawnCell(_x, _y);
                    _x += 102;
                }
                _x = 24;
                _y += 102;
            }
        }
        /// <summary>
        /// Checks what cell is at a continuous point and returns relevant cell
        /// </summary>
        /// <param name="x">X Coordinate of Entity</param>
        /// <param name="y">Y Coordinate of Entity</param>
        /// <returns>Returns the cell located at the provided x and y coordinate</returns>
        public Cell CellAt(float x, float y)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (y <= (_grid[i, j].Y + SplashKit.BitmapNamed(EntityName.Grass.ToString()).Height) && y >= _grid[i, j].Y && x <= (_grid[i, j].X + SplashKit.BitmapNamed(EntityName.Grass.ToString()).Width) && x >= _grid[i, j].X)
                    {
                        return _grid[i, j];
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// returns the float location of a given integer grid row
        /// </summary>
        /// <param name="y">the row of the grid that is desired</param>
        /// <returns>returns the y coordinate of the provided row</returns>
        public float RowAt(int y)
        {
            if (y <= _grid.GetLength(1))
            {
                return _grid[y, 0].Y;
            }
            return _grid[0, 0].Y;
        }
        /// <summary>
        /// Takes 2 integer values and returns the cell at that row and column
        /// </summary>
        /// <param name="i">row of desired cell</param>
        /// <param name="j">column of desired cell</param>
        /// <returns>returns cell found at given row and column</returns>
        public Cell GetCell(int i, int j)
        {
            if (i < 4 && j < 9)
            {
                return _grid[i, j];
            }
            return null;
        }
    }
}
