using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Icon for Plant removal tool
    /// </summary>
    public class ShovelIcon : Icon
    {
        /// <summary>
        /// Constructor. uses icon base contructor to initialise object
        /// </summary>
        /// <param name="x">x coordinate of icon</param>
        /// <param name="y">y corrdinate of icon</param>
        public ShovelIcon(float x, float y) : base(x, y, EntityName.ShovelIcon)
        {
        }
        /// <summary>
        /// Implements the shovels onclick functionality.
        /// Sets the current tool to plant removal and subscribes to next mouse click
        /// </summary>
        public override void OnClick()
        {
            ITool tool = ToolManager.GetInstance().SetActiveTool(ToolType.PlantRemoval);
            InputManager.GetInstance().SubscribeToMouseClickEvent(OnMouseClicked);
            Selected = true;
        }
        /// <summary>
        /// Implements mouse click functionality. unsubcribes from mouse click and resets tool to entity selection 
        /// </summary>
        /// <param name="mouseButton">The splashkit mousebutton that was pressed</param>
        private void OnMouseClicked(MouseButton mouseButton)
        {
            Selected = false;
            InputManager.GetInstance().UnsubscribeToMouseClickEvent(OnMouseClicked);
            ToolManager.GetInstance().SetActiveTool(ToolType.EntitySelection);
        }
    }
}
