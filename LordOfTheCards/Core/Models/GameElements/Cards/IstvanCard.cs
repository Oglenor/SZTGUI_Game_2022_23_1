using Core.Models.Characters;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.GameElements.Cards
{
    public abstract class IstvanCard
    {
        public Categories StrongerType { get; }
        public Categories WeakerType { get; }
        public Categories OwnType { get; set; }
        public Rarities OwnRarity { get; set; }
        public Colors OwnColor { get; set; }
        

        public Token ProvideToken()
        {
            return new Token(OwnColor, OwnRarity, OwnType);
        }

        public abstract void ApplyNegativeEffect(PlayerEntity entity);
        public abstract void ApplyPositiveEffect(PlayerEntity entity);
    }
}
