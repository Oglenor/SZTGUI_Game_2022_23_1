using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Enums
{
    public enum Colors
    {
        Blue, Green, Grey, Red, Yellow
    }

    public enum Rarities
    {
        Stone = 1, Bronze = 2, Golden = 4
    }

    public enum Categories
    {
        Divine = 1, Necromancy = 2, Alchemy = 4
    }

    public enum Resolution
    {
        PlayerWin, Tie, PlayerLoss
    }

    public enum CheckWinner
    {
        PlayerWin, Undecided, PlayerLoss
    }
}
