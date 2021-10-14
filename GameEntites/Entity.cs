using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Entity is the base class of all object in the game
    /// They have both an x and y coordinate and a bitmap refrence so they they can be drawn to the screen,
    /// Drawing functionality will be implemented by child classes
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Enum of Bitmap file name for respective object
        /// </summary>
        public EntityName EntityName { get; }
        /// <summary>
        /// X Coordinate of Entity
        /// </summary>
        public float X { get; protected set; }
        /// <summary>
        /// Y Coordinate of Entity
        /// </summary>
        public float Y { get; protected set; }
        /// <summary>
        /// Constructor. Initialises X, Y and BitMap information
        /// </summary>
        /// <param name="x">X Coordinate of Entity</param>
        /// <param name="y">Y Coordinate of Entity</param>
        /// <param name="bitmapName">Enum of Bitmap file name for respective object</param>
        public Entity(float x, float y, EntityName bitmapName)
        {
            X = x;
            Y = y;
            EntityName = bitmapName;
        }
        /// <summary>
        /// Draws respective Entity to the screen
        /// </summary>
        public abstract void Draw();
        /// <summary>
        /// Generic function attempting to cast the object as a more specialised entity class.
        /// </summary>
        /// <typeparam name="T">Entity class to be casted to</typeparam>
        /// <param name="result">if casting is successful result can be used by calling function</param>
        /// <returns>returns boolean on if casting is successful</returns>
        public bool TryCast<T>(out T result) where T: Entity 
        {
            result = this as T;
            return result != null;
        }
    }
}
