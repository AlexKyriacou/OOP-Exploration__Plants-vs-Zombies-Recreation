using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Abstract Zombie Class that serves as a base for all Zombie 
    /// </summary>
    public abstract class Zombie : DynamicEntity
    {
        protected int _bitmapHitCoolDown;
        protected int _speedCooldown;
        protected ulong _timeAtLastAttack;
        /// <summary>
        /// Constructor. Initialises the Health of the zombie so that it will not be immediately found dead
        /// </summary>
        /// <param name="y">Y Coordinate of Entitiy</param>
        /// <param name="bitmapName">Bitmap of the relevant zombie entitiy</param>
        public Zombie(float y, EntityName bitmapName) : base(SplashKit.CurrentWindowWidth()+50, y, bitmapName) 
        { 
            Health = 1;
            MovementDebuff = 1;
            _timeAtLastAttack = TimeKeeper.GetInstance().Ticks;
        }
        /// <summary>
        /// Health of Zombie
        /// </summary>
        public int Health { get; protected set; }
        public float MovementSpeed { get; protected set; }
        public float MovementDebuff { get; protected set; }
        public int Damage { get; protected set; }
        public int Points { get; protected set; }

        /// <summary>
        /// Checks if Zombie is alive
        /// </summary>
        /// <returns>returns boolean depending on plants health</returns>
        public override bool IsDead()
        {
            if(X < -100)
            {
                PlayerData.GetInstance().GameOver = true;
            }
            return Health <= 0 || X < -100;
        }
        /// <summary>
        /// Boolean dependand on if the zombie has met the attack criteria and is ready to attack again
        /// </summary>
        /// <returns>returns 1 if zombie is ready to attack and 0 if not</returns>
        public bool ReadyToAttack()
        {
           if(TimeKeeper.GetInstance().Ticks - _timeAtLastAttack > 300)
           {
                _timeAtLastAttack = TimeKeeper.GetInstance().Ticks;
                return true;
           }
            return false;
        }
        /// <summary>
        /// Implements collision between zombies and other entities
        /// </summary>
        /// <param name="collidedWith">Entity that zombie collided with</param>
        public override void OnCollision(DynamicEntity collidedWith)
        {
            EntityName[] _plants = new EntityName[4] { EntityName.StandardShooter, EntityName.SnowShooter,EntityName.Wallnut,EntityName.Sunflower };
            if (_plants.Contains(collidedWith.EntityName))
            {
                this.MovementDebuff = 0;
            }
            else if (collidedWith.TryCast<StandardBullet>(out StandardBullet standardB))
            {
                this.Health -= standardB.Damage;
                _bitmapHitCoolDown = 15;
            }
            else if (collidedWith.TryCast<SnowBullet>(out SnowBullet snowB))
            {
                this.MovementDebuff = 0.6F;
                _speedCooldown = 1500;
                this.Health -= snowB.Damage;
                _bitmapHitCoolDown = 15;
            }
            else if (collidedWith.TryCast<Lawnmower>(out Lawnmower lm))
            {
                this.Health = 0;
            }
            if (Health <= 0)
            {
                PlayerData.GetInstance().Points += this.Points;
            }
        }
    }
}
