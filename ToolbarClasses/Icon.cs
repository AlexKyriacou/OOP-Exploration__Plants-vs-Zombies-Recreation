using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Icons are the clickable entites within the toolbar that select a plant to be placed on the map. 
    /// </summary>
    public abstract class Icon : Entity, IClickable
    {
        /// <summary>
        /// Boolean of if the given icon is selected or not
        /// </summary>
        public bool Selected { get; set; }
        /// <summary>
        /// Constructor. Initialises the icon object
        /// </summary>
        /// <param name="x">x coordinate of icon</param>
        /// <param name="y">y coordinate of icon</param>
        /// <param name="bitmapName">bitmap name of icon</param>
        public Icon(float x, float y, EntityName bitmapName) : base(x, y, bitmapName) {    }
        /// <summary>
        /// Renders the Icon to the screen
        /// </summary>
        public override void Draw()
        {
            if (Selected)
            {
                SplashKit.DrawBitmap(EntityName.ToString(), X, Y - 15);
            }
            else
            {
                SplashKit.DrawBitmap(EntityName.ToString(), X, Y);
            }
        }
        /// <summary>
        /// Implements the icons click functionality
        /// </summary>
        public abstract void OnClick();
        /// <summary>
        /// Boolean retuning if a point is found on an icon
        /// </summary>
        /// <param name="x">x coordinate of desired point</param>
        /// <param name="y">y coordinate of desired point</param>
        /// <returns>retruns boolean of if the point is found on the icon</returns>
        public bool IsAt(float x, float y) => (y <= (Y + SplashKit.BitmapNamed(this.EntityName.ToString()).Height) && y >= Y && x <= (X + SplashKit.BitmapNamed(this.EntityName.ToString()).Width) && x >= X);
    }
}
