using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.GameElements
{
    public class Token
    {
        private Colors color;
        private Categories category;

        public Colors Color
        {
            get { return color; }
            set { color = value; }
        }
        public Categories Category
        {
            get { return category; }
            set { category = value; }
        }

        public Token(Colors color, Categories category)
        {
            this.color = color;
            this.category = category;
        }
    }
}
