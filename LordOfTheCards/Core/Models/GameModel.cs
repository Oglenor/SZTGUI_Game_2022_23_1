﻿using Core.Interfaces;
using Core.Models.Characters;
using Core.Models.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class GameModel : IGameModel
    {
        public Dictionary<string, Map> Maps { get; set; }
        public Player Player { get; set; }
        public List<Enemy> EnemyList { get; set; }
        public List<Card> AllCards { get; set; }
    }
}
