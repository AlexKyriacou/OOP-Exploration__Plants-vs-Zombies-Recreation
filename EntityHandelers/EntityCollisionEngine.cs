using System;
using System.Collections.Generic;

namespace FinalProject
{
    /// <summary>
    /// In Charge of detecting all collision within the game and delegating collision functionality to those classes.
    /// </summary>
    public class EntityCollisionEngine
    {
        /// <summary>
        /// Entitiy Collision Matrix defines what entities can collide with eachother. Similar to the collision matrix seen in the unity engine
        /// </summary>
        private Dictionary<EntityName, List<EntityName>> _entityCollisionMatrix;
        /// <summary>
        /// Initialises which entities can collide together. If a new entity is created it needs to be added here
        /// </summary>
        public EntityCollisionEngine()
        {
            _entityCollisionMatrix = new Dictionary<EntityName, List<EntityName>>();
            _entityCollisionMatrix.Add(EntityName.Sun, new List<EntityName>() {});
            _entityCollisionMatrix.Add(EntityName.StandardBullet, new List<EntityName>() { EntityName.StandardZombie, EntityName.ConeZombie });   
            _entityCollisionMatrix.Add(EntityName.Lawnmower, new List<EntityName>() { EntityName.StandardZombie, EntityName.ConeZombie });
            _entityCollisionMatrix.Add(EntityName.SnowBullet, new List<EntityName>() { EntityName.StandardZombie, EntityName.ConeZombie });
            _entityCollisionMatrix.Add(EntityName.Wallnut, new List<EntityName>() { EntityName.StandardZombie, EntityName.ConeZombie });
            _entityCollisionMatrix.Add(EntityName.StandardShooter, new List<EntityName>() { EntityName.StandardZombie, EntityName.ConeZombie });
            _entityCollisionMatrix.Add(EntityName.SnowShooter, new List<EntityName>() { EntityName.StandardZombie, EntityName.ConeZombie });
            _entityCollisionMatrix.Add(EntityName.Sunflower, new List<EntityName>() { EntityName.StandardZombie, EntityName.ConeZombie });
            _entityCollisionMatrix.Add(EntityName.StandardZombie, new List<EntityName>() { });
            _entityCollisionMatrix.Add(EntityName.ConeZombie, new List<EntityName>() { });
        }
        /// <summary>
        /// Detects Collision Between Entities that coexist on the CollisionMatrix and delegates further collision functionality to the respective objects
        /// </summary>
        public void Collide()
        {
            //Gets Each Dynamic Bitmap in the game
            foreach(KeyValuePair<EntityName, List<DynamicEntity>> KVP in EntityRepository.GetInstance()._dynamicEntityLayers)
            {
                //Gets Each Dynamic Entity currently active one catagory at a time
                foreach (DynamicEntity CurrentE in KVP.Value)
                {
                    // Gets the types of entities that the current entitiy can collide with
                    foreach (EntityName b in _entityCollisionMatrix[CurrentE.EntityName])
                    {
                        //Gets the active entities of the collidable types
                        foreach(DynamicEntity CollisionE in EntityRepository.GetInstance()._dynamicEntityLayers[b])
                        {
                            //Checks if both entities are +- 2 pixles from eachother and sets off collision if true
                          if (CollisionE.X <= CurrentE.X + 2 && CollisionE.X >= CurrentE.X - 2 && CollisionE.Y <= CurrentE.Y + 2 && CollisionE.Y >= CurrentE.Y - 2)
                          {
                              CurrentE.OnCollision(CollisionE);
                              CollisionE.OnCollision(CurrentE);

                          }
                        }
                    }
                }
            }
        }
    }
}
