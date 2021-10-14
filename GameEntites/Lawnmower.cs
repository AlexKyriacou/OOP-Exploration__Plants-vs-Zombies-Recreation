using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Lawnmowers are the single use entities at the edge of the map that on a zombie collision activate and kill all zombies in a given row
    /// </summary>
    public class Lawnmower : DynamicEntity
    {
        /// <summary>
        /// Boolean dictating if the lawnmower is activated, if so it will start moving during the update loop
        /// </summary>
        private bool _activated;
        /// <summary>
        /// per game tick speed of lawnmower
        /// </summary>
        private float _speed;
        /// <summary>
        /// Constructor. Initialises the lawnmowers activation status and speed
        /// </summary>
        /// <param name="y">y coordinate of lawnmower</param>
        public Lawnmower(float y) : base(-55, y, EntityName.Lawnmower)
        {
            _activated = false;
            _speed = 1;
        }
        /// <summary>
        /// Renders the lawnmower to the screen.
        /// </summary>
        public override void Draw() => SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.ToString()), X, Y);
        /// <summary>
        /// Returns boolean dependant on if the lawnmover is dead and needs to be removed on the next game loop.
        /// The lawnmover is declared dead if it is off the right hand side of the window bounds.
        /// </summary>
        /// <returns>returns boolean dependant on if the lawnmower is dead (1 if dead, 0 if alive)</returns>
        public override bool IsDead() => (this.X > SplashKit.CurrentWindowWidth()+50);
        /// <summary>
        /// Implements the lawnmowers collision functionality. if collided with a zombie then it activates and starts moving.
        /// </summary>
        /// <param name="collidedWith">Dynamic entity that the lawnmower has collided with</param>
        public override void OnCollision(DynamicEntity collidedWith)
        {
            if (collidedWith.TryCast<Zombie>(out Zombie z))
            {
                _activated = true;
            }
        }
        /// <summary>
        /// If lawnmower is activated this will update its x location
        /// </summary>
        public override void Update()
        {
            if (_activated)
            {
                X += _speed;
            }
        }
    }
}
