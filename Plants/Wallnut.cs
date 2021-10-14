using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// A tank like plant that deals no damage but takes many hits
    /// </summary>
    public class Wallnut : Plant
    {
        /// <summary>
        /// Constructor. Initialises the snow shooter objects fields
        /// </summary>
        /// <param name="x">X Coordinate of Plant</param>
        /// <param name="y">Y Coordinate of Plant</param>
        public Wallnut(float x, float y) : base(x, y, EntityName.Wallnut)
        {
            Health = 50;
            _bitmapHitCoolDown = 0;
        }
        /// <summary>
        /// Draws Plant Object to screen. if the plant has been recently hit a secondary bitmap will be drawn
        /// </summary>
        public override void Draw()
        {
            if (_bitmapHitCoolDown != 0)
            {
                SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.ToString() + "Hit"), X, Y);
                _bitmapHitCoolDown--;
            }
            else
            {
                SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.ToString()), X, Y);
            }
        }
        /// <summary>
        /// Implements the collision methods of the plant object
        /// </summary>
        /// <param name="collidedWith">passed the dynamic entity that has collided with the plant object</param>
        public override void OnCollision(DynamicEntity collidedWith)
        {
            if (collidedWith.TryCast<Zombie>(out Zombie z))
            {
                if (z.ReadyToAttack())
                {
                    this.Health -= z.Damage;
                    _bitmapHitCoolDown = 15;
                }
            }
        }
        /// <summary>
        /// This plant does not require updating
        /// </summary>
        public override void Update() {   }
    }
}
