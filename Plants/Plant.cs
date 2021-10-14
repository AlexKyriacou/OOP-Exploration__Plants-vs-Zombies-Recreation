using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Defines the base plant class that all other child classes will be derived from
    /// </summary>
    public abstract class Plant:DynamicEntity
    {
        /// <summary>
        /// boolean dependant on if the plant has been manually requested to be removed from the game. this is done with the shovel tool.
        /// </summary>
        private bool _removedRequested;
        protected int _bitmapHitCoolDown;
        /// <summary>
        /// Health of plant
        /// </summary>
        public int Health { get; protected set; }
        /// <summary>
        /// Price of plant
        /// </summary>
        public Plant(float x, float y, EntityName bitmapName):base(x, y, bitmapName) { Health = 1; _removedRequested = false;  }
        /// <summary>
        /// Checks if plant is alive
        /// </summary>
        /// <returns>returns boolean depending on plants health</returns>
        public override bool IsDead()
        {
            if(Health <= 0)
            {
                Cell c = EntityRepository.GetInstance().CellAt(X,Y);
                c.Occupied = false;
            }
            return Health <= 0 || _removedRequested;
        }
        /// <summary>
        /// if plant is selected with a shovel then it sets remove requested property to true and will be deleted at the next game loop
        /// </summary>
        public void Kill() => _removedRequested = true;
    }
}
