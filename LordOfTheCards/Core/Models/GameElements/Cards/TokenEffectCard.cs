using Core.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.GameElements.Cards
{
    public class TokenEffectCard : IstvanCard
    {
        public override void ApplyNegativeEffect(PlayerEntity entity)
        {
            Token? token = entity.Tokens.Find(x => x.Category == OwnType && x.Color == OwnColor && x.Rarity == OwnRarity);
            if (token != null)
            {
                entity.Tokens.Remove(token);
            }
        }

        public override void ApplyPositiveEffect(PlayerEntity entity)
        {
            entity.Tokens.Add(ProvideToken());
        }
    }
}