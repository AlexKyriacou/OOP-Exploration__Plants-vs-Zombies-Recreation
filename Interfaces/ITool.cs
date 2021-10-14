using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Defines what a tool requires.
    /// Tools are what defines what the player is trying to achieve in the game and has the game entities interact in an appropiate way
    /// </summary>
    public interface ITool
    {
        public void ToolActivate();
        public void ToolDeactivate();
        public void ToolUpdate();
    }
}
