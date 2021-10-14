using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Entity selection tool. When active will activate onClick method of any iclickable objects under curson when window is clicked.
    /// </summary>
    public class TEntitySelection : ITool
    {
        /// <summary>
        /// Activates tool. subscribes to mouse click event so at next click any entities under click are activated.
        /// </summary>
        public void ToolActivate() => InputManager.GetInstance().SubscribeToMouseClickEvent(OnMouseClicked);
        /// <summary>
        /// Deactivates tool. Unsubscibes tool to mouse click event
        /// </summary>
        public void ToolDeactivate() => InputManager.GetInstance().UnsubscribeToMouseClickEvent(OnMouseClicked);
        /// <summary>
        /// The entity selection tool has no need to update
        /// </summary>
        public void ToolUpdate() {  }
        /// <summary>
        /// Clicks any clickable entities under mouse after a click.
        /// </summary>
        /// <param name="mouseButton">Splashkit mousebutton enum</param>
        private void OnMouseClicked(MouseButton mouseButton)
        {
            List<Entity> _entitesAt = EntityRepository.GetInstance().GetEntityAt<Entity>(SplashKit.MouseX(), SplashKit.MouseY());
            foreach(Entity e in _entitesAt)
            {
                if (e as IClickable != null)
                {
                    IClickable dclick = e as IClickable;
                    dclick.OnClick();
                }
            }
        }
    }
}
