using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// In charge of rendering all entities within the game.
    /// In the Model-View-Controller Pattern this classes acts as the view portion.
    /// </summary>
    public class EntityRenderer
    {
        public EntityRenderer()  {   }
        /// <summary>
        /// Renders all game entities. Each entity is responsible for its own rendering functionality
        /// </summary>
        public void Render()
        {
            foreach (Entity e in EntityRepository.GetInstance()._entities)
            {
                e.Draw();
            }
            foreach (KeyValuePair<EntityName, List<DynamicEntity>> key in EntityRepository.GetInstance()._dynamicEntityLayers)
            {
                foreach (DynamicEntity e in key.Value)
                {
                    e.Draw();
                }
            }
        }
    }
}
