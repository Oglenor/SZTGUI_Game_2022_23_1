using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGameSettings
    {
        string DefaultHeroName { get; }
        string SavesPath { get; }
        string ResourcesPath { get; }
        string DefaultMapName { get; }
        double TileWidth { get; }
        double TileHeight { get; }
    }
}
