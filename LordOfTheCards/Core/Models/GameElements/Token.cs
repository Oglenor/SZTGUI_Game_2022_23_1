using Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.GameElements
{
    internal class Token
    {
        private Colors color;
        private Rarities rarity;
        private Categories category;

        public Colors Color
        {
            get { return color; }
        }
        public Rarities Rarity
        {
            get { return rarity; }
        }
        public Categories Category
        {
            get { return category; }
        }

        public Token(Colors color, Rarities rarity, Categories category)
        {
            this.color = color;
            this.rarity = rarity;
            this.category = category;
        }

        public Token(string color, string rarity, string category)
        {
            this.color = (Colors)Enum.Parse(typeof(Colors), color);
            this.rarity = (Rarities)Enum.Parse(typeof(Rarities), rarity);
            this.category = (Categories)Enum.Parse(typeof(Categories), category);
        }
    }
}
