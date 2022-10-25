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
        private IGameModel gameModel;
        public GameRepository()
        {
            gameSettings = GameSettings.Instance;
        }

        public IGameModel GetLastState()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(gameSettings.SavesPath);            
            return Deserialize<GameModel>(Path.Combine(gameSettings.SavesPath, directoryInfo
                .GetFiles()
                .Where(x => x.Name.StartsWith(gameSettings.SavedStatesPrefix))
                .OrderByDescending(f => f.LastWriteTime)
                .First()
                .Name));
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

        public IGameModel GetModel(string path)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<IGameModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}