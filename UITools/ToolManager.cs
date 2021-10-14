using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Toolmanager controls what tool is active at a given time.
    /// </summary>
    public class ToolManager
    {
        /// <summary>
        /// List of the games tools and their type
        /// </summary>
        private Dictionary<ToolType, ITool> _tools;
        /// <summary>
        /// current active tool
        /// </summary>
        private ITool _currentTool;
        /// <summary>
        /// Singleton insatnce of tool manager
        /// </summary>
        private static ToolManager _instance;
        /// <summary>
        /// Gets the singleton instance of the tool manager.
        /// </summary>
        /// <returns>retuns singleton insatance of the tool manager</returns>
        public static ToolManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ToolManager();
            }
            return _instance;
        }
        /// <summary>
        /// Constructor. Initialises the game tools
        /// </summary>
        private ToolManager()
        {
            _tools = new Dictionary<ToolType, ITool>();
            _tools.Add(ToolType.PlantPlacement, new TPlantPlacement());
            _tools.Add(ToolType.EntitySelection, new TEntitySelection());
            _tools.Add(ToolType.PlantRemoval, new TPlantRemoval());
        }
        /// <summary>
        /// updates the current tool
        /// </summary>
        public void Update() => _currentTool.ToolUpdate();
        /// <summary>
        /// Sets a new active tool
        /// </summary>
        /// <param name="toolType">enum of tool to be made active</param>
        /// <returns>returns the set tool</returns>
        public ITool SetActiveTool(ToolType toolType)
        {
            ITool newTool = _tools[toolType];
            if (newTool != _currentTool)
            {
                if(_currentTool != null)
                {
                    _currentTool.ToolDeactivate();

                }
                newTool.ToolActivate();
                _currentTool = newTool;
            }
            return _currentTool;
        }
    }
}
