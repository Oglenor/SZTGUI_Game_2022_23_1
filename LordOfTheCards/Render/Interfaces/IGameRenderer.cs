using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Render.Interfaces
{
    public interface IGameRenderer
    {
        IGameSettings GameSettings { get; set; }
        IGameModel GameModel { get; set; }
        Drawing GetDrawing();
    }
}
