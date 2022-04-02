using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Unit
    {
        public int id;
        public string playerName;
        public int move;
        public int shots;
        public int power;
        public int hexId;
        public string name;
        public Unit(int new_id,  string player, int shipMove, int shipShots, int shipPower, int hex, string shipName)

        {
            id = new_id;
            playerName = player;
            move = shipMove;
            shots = shipShots;
            power = shipPower;
            hexId = hex;
            name = shipName;
        }
    }
}
