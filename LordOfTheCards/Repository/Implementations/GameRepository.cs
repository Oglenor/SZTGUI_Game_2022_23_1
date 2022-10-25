using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Core.Models.GameElements;
using Core.Settings;
using Newtonsoft.Json;
using Repository.Interfaces;

namespace Repository
{
    public class GameRepository : IGameRepository
    {
        public void StoreGameModel(IGameModel gameModel)
        {
            string content = JsonConvert.SerializeObject(gameModel);
            DateTime now = DateTime.Now;
            string path = Path.Combine("Saves", $"GameState-{gameModel.Player.PlayerName}-{now.Year}-{now.Month}-{now.Day}-{now.Minute}-{now.Second}.json");
            File.WriteAllText(path, content);
        }
        public IGameModel GetModel(string path)
        {

            return JsonConvert.DeserializeObject<GameModel>(File.ReadAllText(path));
        }

        public IGameModel GetLastState()
        {
            string path = Directory.GetFiles("Saves").Where(x => x.StartsWith("GameState")).Last();
            return JsonConvert.DeserializeObject<GameModel>(File.ReadAllText(path));
        }

        public IEnumerable<IGameModel> GetAll()
        {
            return Directory.GetFiles("Saves").Where(x => x.StartsWith("GameState")).Select(x => JsonConvert.DeserializeObject<GameModel>(File.ReadAllText(x)));
        }

        public List<Card> GetAllCards()
        {  //ID,COLOR,RARITY,CATEGORY,FILENAME

            string jsonPath = Path.Combine("AllCards", "AllCardsData.json");
            string content = File.ReadAllText(jsonPath);

           return JsonConvert.DeserializeObject<List<Card>>(content);
        }
    }
}