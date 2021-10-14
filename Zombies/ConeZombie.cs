using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// More difficult zombie enemy with more health
    /// </summary>
    public class ConeZombie : Zombie
    {
        /// <summary>
        /// Constructor. Initialises a Cone Zombie Entity
        /// </summary>
        /// <param name="y">Y Coordinate of Zombie</param>
        public ConeZombie(float y) : base(y, EntityName.ConeZombie)
        {
            Health = 640;
            MovementSpeed = 0.1F;
            Damage = 1;
            Points = 10;
            _bitmapHitCoolDown = 0;
            _speedCooldown = 0;
        }
        /// <summary>
        /// Draws the zombie object to the screen
        /// </summary>
        public override void Draw()
        {
            if (Health > 270)
            {
                if (_bitmapHitCoolDown != 0)
                {
                    SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.ToString() + "Hit"), X, Y);
                    _bitmapHitCoolDown--;
                }
                else if (_speedCooldown != 0)
                {
                    SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.ToString() + "Slowed"), X, Y);
                }
                else
                {
                    SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.ToString()), X, Y);
                }
            }
            else
            {
                if (_bitmapHitCoolDown != 0)
                {
                    SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.StandardZombie.ToString() + "Hit"), X, Y);
                    _bitmapHitCoolDown--;
                }
                else if (_speedCooldown != 0)
                {
                    SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.StandardZombie.ToString() + "Slowed"), X, Y);
                }
                else
                {
                    SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.StandardZombie.ToString()), X, Y);
                }
            }
        }
        /// <summary>
        /// Updates Zombie collision
        /// </summary>
        public override void Update()
        {
            X -= this.MovementSpeed * this.MovementDebuff;
            if (_speedCooldown == 0)
            {
                MovementDebuff = 1;
            }
            else
            {
                _speedCooldown--;
            }
        }
    }
}
