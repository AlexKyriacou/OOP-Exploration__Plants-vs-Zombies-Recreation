using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Dynamic entities are entities that move or require their fields to be updated in someway
    /// </summary>
    public abstract class DynamicEntity : Entity
    {
        /// <summary>
        /// Constructor. Initialises the DynamicEntities bitmap and x/y position
        /// </summary>
        /// <param name="x">X Coordinate of Entity</param>
        /// <param name="y">Y Coordinate of Entity</param>
        /// <param name="bitmapName">Enum of Bitmap file name for respective object</param>
        public DynamicEntity(float x, float y, EntityName bitmapName) : base(x, y, bitmapName)
        {
        }
        /// <summary>
        /// Updates the dynamic entity. To be implemented by child classes
        /// </summary>
        public abstract void Update();
        /// <summary>
        /// Defines the behaviour of the entity when it is collided with other entitys. will be implemented in child classes
        /// </summary>
        /// <param name="collidedWith">The Dynamic Entity that has collided with this entity</param>
        public abstract void OnCollision(DynamicEntity collidedWith);
        /// <summary>
        /// Checks if the entity is dead. If not then it will be removed on the next game loop
        /// </summary>
        /// <returns>Returns bool of the entities dead status 0 if alive 1 if dead</returns>
        public abstract bool IsDead();
    }
}
