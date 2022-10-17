using Core.Interfaces;
using Core.Models.Characters;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.GameElements.Cards
{
    public class DeckEffectCard : IstvanCard
    {
        public override void ApplyNegativeEffect(PlayerEntity entity)
        {          
            entity.istvanCards.Remove(entity.istvanCards
                .Where(x => x.OwnType == OwnType)
                .OrderByDescending(x => x.OwnRarity)
                .First());
        }

        //Ez ad egy erős kártyát például.
        public override void ApplyPositiveEffect(PlayerEntity entity)
        {
            IstvanCard card = new TokenEffectCard();
            card.OwnColor = OwnColor;
            card.OwnType = OwnType;
            card.OwnRarity = Rarities.Golden;
            entity.istvanCards.Add(card);
        }
    }
}
