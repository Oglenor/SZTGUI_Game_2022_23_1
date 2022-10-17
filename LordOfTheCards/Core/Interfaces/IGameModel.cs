using Core.Models.Characters;
using Core.Models.GameElements;
using Core.Models.GameElements.Cards;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGameModel
    {
        Dictionary<string, Map> Maps { get; set;}
        Player Player { get; set; }
        List<Enemy> EnemyList { get; set; }
        List<Card> AllCards { get; set; }
	}
}