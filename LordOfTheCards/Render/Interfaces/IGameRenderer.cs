using Core.Interfaces;
using Core.Models.GameElements;
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
        Drawing Display(IEnumerable<StaticGameItem> collection);
    }
}
