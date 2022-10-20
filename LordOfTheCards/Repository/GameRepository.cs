using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Newtonsoft.Json;

namespace Repository
{
    public class GameRepository : IGameRepository
    {
        public void SaveIntoJson(IGameModel gameModel)
        {
            string jsonstring = JsonConvert.SerializeObject(gameModel);
            File.WriteAllText($"playerName.json", jsonstring);
        }

        public IGameModel LoadFromJson(string playerName)
        {
            return JsonConvert.DeserializeObject<IGameModel>(playerName);
        }

        public void StoreGameModel(IGameModel gameModel)
        {
            throw new NotImplementedException();
        }

        public IGameModel GetModel(string path)
        {
            throw new NotImplementedException();
        }

        public IGameModel GetLastState()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGameModel> GetAll()
        {
            throw new NotImplementedException();




        }
    }
}
/*
        public void StoreGameModel(IGameModel gameModel)
            { Serialize(gameModel); }

//

        private void Serialize<T>(T state)
            {
                try
                {
                    string content = JsonSerializer.Serialize(state);
                    string path = GenerateSaveFilName();
                    WriteFile(path, content);
                }
                catch (Exception exception) { WriteToLog(exception.Message); throw; }
            }

//

            private string GenerateSaveFilName()
            { DateTime now = DateTime.Now; return $"{gameSettings.SaveDirectory}GameState-{gameSettings.HeroName}-{now.Year}-{now.Month}-{now.Day}-{now.Minute}-{now.Second}.json"; }

//

            private DirectoryInfo dInfo;

//

            public IEnumerable<IGameModel> GetAll()
            {
                return dInfo.GetFiles("*.json").Where(x => x.Name.StartsWith("GameState"))
                      .Select(x => Deserialize<GameModel>($"{gameSettings.SaveDirectory}{x.Name}"))
                      .ToList();
            }

 */