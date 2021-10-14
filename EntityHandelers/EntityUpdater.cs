using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Incharge of updating all entities within the game. Follows singleton pattern
    /// </summary>
    public class EntityUpdater
    {
        /// <summary>
        /// Singleton Instnace of EntityUpdater
        /// </summary>
        private static EntityUpdater _instance;
        /// <summary>
        /// List of entities that need to be added to repository on next game loop
        /// </summary>
        private List<Entity> _entitiesToBeAdded;
        /// <summary>
        /// List of entities that need to be added to repository on next game loop
        /// </summary>
        private List<DynamicEntity> _dynamicEntitiesToBeAdded;
        /// <summary>
        /// List of entities that need to be removed from repository on next game loop
        /// </summary>
        private List<DynamicEntity> _dynamicEntitiesToBeRemoved;
        /// <summary>
        /// Constructor. Initialises Entity Updater and queue lists
        /// </summary>
        private EntityUpdater() 
        {
            _entitiesToBeAdded = new List<Entity>();
            _dynamicEntitiesToBeAdded = new List<DynamicEntity>();
            _dynamicEntitiesToBeRemoved = new List<DynamicEntity>();
        }
        /// <summary>
        /// Creates singleton insance of EntityUpdater
        /// </summary>
        public static void CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new EntityUpdater();
            }
        }
        public static EntityUpdater GetInstance() => _instance;
        /// <summary>
        /// Updates all entities in the game.
        /// Including flagging and removing dead entities
        /// </summary>
        public void Update()
        {
            foreach (KeyValuePair<EntityName, List<DynamicEntity>> KVP in EntityRepository.GetInstance()._dynamicEntityLayers)
            {
                foreach (DynamicEntity e in KVP.Value)
                {
                    if (e.IsDead())
                    {
                        _dynamicEntitiesToBeRemoved.Add(e);
                    }
                    e.Update();
                }
            }
            foreach (Entity e in _entitiesToBeAdded)
            {
                EntityRepository.GetInstance()._entities.Add(e);
            }
            foreach (DynamicEntity e in _dynamicEntitiesToBeAdded)
            {
                EntityRepository.GetInstance()._dynamicEntityLayers[e.EntityName].Add(e);
            }
            foreach (DynamicEntity e in _dynamicEntitiesToBeRemoved)
            {
                EntityRepository.GetInstance()._dynamicEntityLayers[e.EntityName].Remove(e);
            }
            _entitiesToBeAdded.Clear();
            _dynamicEntitiesToBeAdded.Clear();
            _dynamicEntitiesToBeRemoved.Clear();
            TimeKeeper.GetInstance().Increment();
        }
        /// <summary>
        /// Adds newly created entity to its list
        /// </summary>
        /// <param name="e"> entity that has been created</param>
        public void RegisterEntity(Entity e) => _entitiesToBeAdded.Add(e);
        /// <summary>
        /// Adds newly created dynamic entity to its list
        /// </summary>
        /// <param name="e">dynamic entity that has been created</param>
        public void RegisterDynamicEntity(DynamicEntity e) => _dynamicEntitiesToBeAdded.Add(e);
    }

}
