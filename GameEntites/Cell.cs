using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Cells are simply the discrete coordinate grass map that is seen during gameplay
    /// </summary>
    public class Cell : Entity
    {
        /// <summary>
        /// Bool defining if the current cell is being used by a plant object
        /// </summary>
        public bool Occupied { get; set; }
        /// <summary>
        /// Constructor. Defines the cells x y position
        /// </summary>
        /// <param name="x">X Coordinate of Cell</param>
        /// <param name="y">Y Coordinate of Cell</param>
        public Cell(float x, float y) : base(x, y, EntityName.Grass) => Occupied = false;
        /// <summary>
        /// Draws the cell to the screen with a small black outline
        /// </summary>
        public override void Draw()
        {
            SplashKit.FillRectangle(Color.Black, SplashKit.RectangleFrom(X - 2, Y - 2, 104, 104));
            SplashKit.DrawBitmap(EntityName.ToString(), X, Y);
        }
    }
}
