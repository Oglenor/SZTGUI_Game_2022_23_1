using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Core.Settings;
using Repository.Interfaces;

namespace Repository
{
    public class GameRepository : IGameRepository
    {
        public void StoreGameModel(IGameModel gameModel)
        {
            string content = JsonSerializer.Serialize(gameModel);
            DateTime now = DateTime.Now;
            string path = Path.Combine("Saves",$"GameState-{gameModel.Player.PlayerName}-{now.Year}-{now.Month}-{now.Day}-{now.Minute}-{now.Second}.json");
            File.WriteAllText(path, content);
        }
        public IGameModel GetModel(string path)
        {
            return JsonSerializer.Deserialize<GameModel>(path);
        }

        public IGameModel GetLastState()
        {
            string path= Directory.GetFiles("Saves").Where(x => x.StartsWith("GameState")).Last();
            return JsonSerializer.Deserialize<GameModel>(path);
        }

        public IEnumerable<IGameModel> GetAll()
        {
            return Directory.GetFiles("Saves").Where(x => x.StartsWith("GameState")).Select(x=> JsonSerializer.Deserialize<GameModel>(x));
        }
    }
}