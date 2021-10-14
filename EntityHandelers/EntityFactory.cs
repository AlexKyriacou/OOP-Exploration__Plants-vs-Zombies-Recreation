using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Controls all entity creation in the game. When an entity is created, it is added to the Repositories list so that it can be updates in the game loop.
    /// </summary>
    public class EntityFactory
    {
        /// <summary>
        /// Spawns the various icons in the game and adds result to repository list
        /// </summary>
        /// <typeparam name="T">Generic Icon Type</typeparam>
        /// <param name="x">x coordinate of Icon</param>
        /// <param name="y">y coordinate of Icon</param>
        /// <returns>Returns created Icon</returns>
        public static T SpawnIcon<T>(float x, float y) where T: Icon
        {
            T s = (T)Activator.CreateInstance(typeof(T), new object[] { x, y });
            EntityUpdater.GetInstance().RegisterEntity(s);
            return s;
        }
        /// <summary>
        /// Spawns the various plants in the game and adds result to repository list
        /// </summary>
        /// <typeparam name="T">Generic Plant Type</typeparam>
        /// <param name="x">x coordinate of Plant</param>
        /// <param name="y">y coordinate of Plant</param>
        /// <returns>Returns created Plant</returns>
        public static T SpawnPlant<T>(float x, float y) where T : Plant
        {
            T s = (T)Activator.CreateInstance(typeof(T), new object[] { x, y });
            EntityUpdater.GetInstance().RegisterDynamicEntity(s);
            return s;
        }
        /// <summary>
        /// Spawns the various bullets in the game and adds result to the repository list
        /// </summary>
        /// <typeparam name="T">Generic Bullet Type</typeparam>
        /// <param name="x">x coordinate of Bullet</param>
        /// <param name="y">y coordinate of Bullet</param>
        /// <param name="firespeed">Firespeed of Bullet</param>
        /// <returns>Returns created Bullet</returns>
        public static T SpawnBullet<T>(float x, float y, float firespeed) where T : Bullet
        {
            T s = (T)Activator.CreateInstance(typeof(T), new object[] { x, y, firespeed });
            EntityUpdater.GetInstance().RegisterDynamicEntity(s);
            return s;
        }
        /// <summary>
        /// Creates a cell object that is returned
        /// </summary>
        /// <param name="x">X Coordinate of Entity</param>
        /// <param name="y">Y Coordinate of Entity</param>
        /// <returns>returns the cell that is created</returns>
        public static Cell SpawnCell(float x, float y)
        {
            Cell c = new Cell(x, y);
            EntityUpdater.GetInstance().RegisterEntity(c);
            return c;
        }
        /// <summary>
        /// Creates a various zombies that is then registered to the Repostitory List
        /// </summary>
        /// <param name="y">y coordinate of zombie</param>
        /// <returns>returns new zombie object</returns>
        public static T SpawnZombie<T>(float y) where T : Zombie
        {
            T s = (T)Activator.CreateInstance(typeof(T), new object[] { y });
            EntityUpdater.GetInstance().RegisterDynamicEntity(s);
            return s;
        }
        /// <summary>
        /// Creates the Lawnmower objects in the game
        /// </summary>
        /// <param name="y">y coordinate of lawnmower</param>
        /// <returns>returns new Lawnmower object</returns>
        public static Lawnmower SpawnLawnmower(float y)
        {
            Lawnmower l = new Lawnmower(y);
            EntityUpdater.GetInstance().RegisterDynamicEntity(l);
            return l;
        }
        /// <summary>
        /// Creates a new falling sun object in the game and registers its existance to the repository list
        /// </summary>
        /// <param name="x">x coordinate of Sun</param>
        /// <param name="y">y coordinate of Sun</param>
        /// <returns>returns new Sun Object</returns>
        public static Sun SpawnSun(float x, float y)
        {
            Sun s = new Sun(x, y);
            EntityUpdater.GetInstance().RegisterDynamicEntity(s);
            return s;
        }
    }
}
