using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Settings
{
   public class GameSettings
    {
        public string HeroName { get; set; }
        public string SaveDirectory { get; set; }
        public GameSettings(string heroName,string saveDirectory)
        {
            this.HeroName = heroName;
            this.SaveDirectory = Directory.GetCurrentDirectory()  ;
        }
    }
}
