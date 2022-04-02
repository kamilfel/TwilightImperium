using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Player
    {
        public int id;
        public string name;
        public string color;
        public int startHex;
        public List<int> unitsId = new List<int>();
        public Player(int new_id, string new_name, int hex)
        {
            id = new_id;
            name = new_name;
            color = new_name;
            startHex = hex;
        }
    }
}
