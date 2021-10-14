using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Mixture of both the Repository and Singleton pattern
    /// Entity repository acts as a central storage for all current entities within the game, ensuring that only one copy of each entitiy exists and all entites are updated/rendered only once per game loop.
    /// Can be accessed by other classes where needed.
    /// Within a model-view-controller pattern this class acts as the model database
    /// </summary>
    public class EntityRepository
    {
        /// <summary>
        /// Singleton Instance of Repository
        /// </summary>
        private static EntityRepository _instance;
        /// <summary>
        /// List of entites active in the game
        /// </summary>
        public List<Entity> _entities;
        /// <summary>
        /// List of Dynamic entities within the game, The order of the dictionary is the order that entities are rendered
        /// </summary>
        public Dictionary<EntityName, List<DynamicEntity>> _dynamicEntityLayers;
        /// <summary>
        /// Game grid that the game takes place on
        /// </summary>
        private Grid _grid;
        /// <summary>
        /// Creates/intialises Singleton instance
        /// </summary>
        public static void CreateInstance()
        {
            _instance = new EntityRepository();
        }
        /// <summary>
        /// Allows the entities of the game to access the Repository instance in order to use its functionality
        /// This means that there will be only 1 global Repository created in the game
        /// </summary>
        /// <returns> Returns the instance of the singleton global repository object</returns>
        public static EntityRepository GetInstance()
        {
            return _instance;
        }
        /// <summary>
        /// Constructor. Initialises the repositories list of Entities
        /// </summary>
        private EntityRepository()
        {
            _entities = new List<Entity>();
            _dynamicEntityLayers = new Dictionary<EntityName, List<DynamicEntity>>();
            _grid = new Grid();
            foreach(EntityName b in Enum.GetValues(typeof(EntityName)).Cast<EntityName>())
            {
                if (((int)b) >= 0) //Negative Bitmaps Refer to Entities not Dynamic Entities so we can ignore them
                {
                    _dynamicEntityLayers.Add(b, new List<DynamicEntity>());
                }
            }
        }
        /// <summary>
        /// Generic Method that finds any entites located at a specific point and returns them to the caller
        /// </summary>
        /// <typeparam name="T">Generic entity type</typeparam>
        /// <param name="x">x coordinate to be searched</param>
        /// <param name="y">y coordinate to be searched</param>
        /// <returns>returns a list of object found at the point</returns>
        public List<T> GetEntityAt<T>(float x, float y)where T: Entity
        {
            List<T> _returnList = new List<T>();
            foreach (KeyValuePair<EntityName, List<DynamicEntity>> KVP in EntityRepository.GetInstance()._dynamicEntityLayers)
            {
                foreach (DynamicEntity e in KVP.Value)
                {
                    if((y <= (e.Y + SplashKit.BitmapNamed(e.EntityName.ToString()).Height) && y >= e.Y && x <= (e.X + SplashKit.BitmapNamed(e.EntityName.ToString()).Width) && x >= e.X))
                    {
                        _returnList.Add(e as T);
                    }
                }
            }
            foreach (Entity e in EntityRepository.GetInstance()._entities)
            {
                if ((y <= (e.Y + SplashKit.BitmapNamed(e.EntityName.ToString()).Height) && y >= e.Y && x <= (e.X + SplashKit.BitmapNamed(e.EntityName.ToString()).Width) && x >= e.X))
                {
                    _returnList.Add(e as T);
                }
            }
            _returnList.RemoveAll(item => item == null);//returns all items made null due to casting
            return _returnList;
        }
        /// <summary>
        /// Wrapper method for Grid's CellAt function
        /// </summary>
        /// <param name="x">x coordinate of query</param>
        /// <param name="y">y corrdinate of query</param>
        /// <returns>returns any found cells at location</returns>
        public Cell CellAt(float x, float y) => _grid.CellAt(x, y);
        /// <summary>
        /// Wrapper method for Grid's RowAt function
        /// </summary>
        /// <param name="y">Grid Row in question (Min 0 - Max 3)</param>
        /// <returns>retuns y coordinate of the Grid row provided</returns>
        public float RowAt(int y) => _grid.RowAt(y);
        /// <summary>
        /// Wrapper method for Grid's GetCell function
        /// </summary>
        /// <param name="r">row desired</param>
        /// <param name="c">column desired</param>
        /// <returns>returns given cell</returns>
        public Cell GetCell(int r,int c) => _grid.GetCell(r,c);

    }
}
