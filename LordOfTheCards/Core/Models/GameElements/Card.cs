using Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.GameElements
{
    internal class Card
    {
        private int id;
        private Token token;
		private Colors color;
		private Rarities rarity;
		private Categories category;

        //event, path
        public int ID
        {
            get { return id; }
        }
        public Token Token
        {
            get { return token; }
        }
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

        public Card(int id, string color, string rarity, string category)
        {
            this.id = id;
            this.token = new Token((Colors)Enum.Parse(typeof(Colors), color), (Rarities)Enum.Parse(typeof(Rarities), rarity), (Categories)Enum.Parse(typeof(Categories), color));
            this.color = (Colors)Enum.Parse(typeof(Colors), color);
            this.rarity = (Rarities)Enum.Parse(typeof(Rarities), rarity);
            this.category = (Categories)Enum.Parse(typeof(Categories), color);
        }
    }
}
