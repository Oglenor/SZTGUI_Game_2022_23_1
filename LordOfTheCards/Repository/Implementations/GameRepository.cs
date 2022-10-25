using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Core.Models.GameElements;
using Core.Settings;
using Repository.Interfaces;

namespace Repository
{
    public class GameRepository : IGameRepository
    {
        private IGameSettings gameSettings;
        private DirectoryInfo directoryInfo;

        public GameRepository()
        {
            gameSettings = GameSettings.Instance;
            directoryInfo = new DirectoryInfo(gameSettings.SavesPath);
        }

        public IGameModel GetLastState()
        {
            string fileName = directoryInfo
                .GetFiles()
                .Where(x => x.Name.StartsWith(gameSettings.SavedStatesPrefix))
                .OrderByDescending(f => f.LastWriteTime)
                .First().Name;
            
            return Deserialize<GameModel>(Path.Combine(gameSettings.SavesPath, fileName));
        }

        public IGameModel GetModel(string fileName)
        {
            return Deserialize<GameModel>(Path.Combine(gameSettings.SavesPath, fileName));
        }

        public IEnumerable<IGameModel> GetAll()
        {
            return directoryInfo
                .GetFiles(gameSettings.FileExtSuffix)
                .Where(x => x.Name.StartsWith(gameSettings.SavedStatesPrefix))
                .Select(x => Deserialize<GameModel>(Path.Combine(gameSettings.SavesPath, x.Name)))
                .ToList();
        }

        private T Deserialize<T>(string path)
        {
            T? result = JsonSerializer.Deserialize<T>(ReadFromFile(path));
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        private string ReadFromFile(string path)
        {
            return File.ReadAllText(path);
        }

        public void StoreGameModel(IGameModel gameModel)
        {
            SaveToFile(Serialize(gameModel));
        }

        private void SaveToFile(string jsonString)
        {
            File.WriteAllText(Path.Combine(gameSettings.SavesPath, GetFileName()), jsonString);
        }

        private string Serialize<T>(T model)
        {
            return JsonSerializer.Serialize(model);
        }

        private string GetFileName()
        {
            return $"{gameSettings.SavedStatesPrefix}{DateTime.Now.ToString(gameSettings.DefaultDateTimeFormat)}{gameSettings.FileExtSuffix}";
        }
    }
}