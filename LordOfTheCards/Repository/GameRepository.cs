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
    public class GameRepository
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
    }
}
