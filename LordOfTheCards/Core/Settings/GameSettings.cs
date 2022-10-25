using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Settings
{
    public class GameSettings : IGameSettings
    {
        private static GameSettings? instance = null;
        private GameSettings(){}
        public static GameSettings Instance { get => instance ??= new GameSettings(); }
        public string DefaultHeroName => "MightyHero";       
        public string SavesPath => Path.Combine(Environment.CurrentDirectory, @"Saves\");
        public string SavedStatesPrefix => "GameState";
        public string DefaultDateTimeFormat => "-yyyy-MM-dd-HH-mm-ss";
        public string FileExtSuffix => ".json";
        public string ResourcesPath => Path.Combine(Environment.CurrentDirectory, @"Resources\Images\");
        public string DefaultMapName => "Field of Sunshine";
        public double TileWidth => 32;
        public double TileHeight => 32;
    }
}