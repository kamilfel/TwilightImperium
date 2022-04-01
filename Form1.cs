using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            this.ClientSize = FORMSIZE;
        }
        private System.Drawing.Size FORMSIZE = new System.Drawing.Size(1920, 1000);
        private int clicks = 0;
        Game game;
        Hex[] hexes;
        Player[] players;
        private string[] playerColors = { "Yellow", "Red", "Green", "Blue", "Purple", "Black" };
        List<string> playerQueue = new List<string>();


        private void InitializeGame()
        {
            game = new Game();

            players = new Player[game.playerNumber];
            for (int i = 0; i < 6; i++)
            {
                players[i] = new Player(i, playerColors[i]);
                playerQueue.Add(players[i].color);
            }

            hexes = new Hex[game.hexNumber];

            hexes[0] = new Hex(0, 0, 0, picBoard.Width, picBoard.Height);

            for (int i = 1; i < 7; i++) hexes[i] = new Hex(i, 1, i - 1, picBoard.Width, picBoard.Height);
            for (int i = 7; i < 19; i++) hexes[i] = new Hex(i, 2, i - 7, picBoard.Width, picBoard.Height);
            for (int i = 19; i < 37; i++) hexes[i] = new Hex(i, 3, i - 19, picBoard.Width, picBoard.Height);
            hexes[19].color = "Yellow";
            hexes[22].color = "Red";
            hexes[25].color = "Green";
            hexes[28].color = "Blue";
            hexes[31].color = "Purple";
            hexes[34].color = "Black";
            textBox1.Text = $"Tura gracza {playerQueue[0]}";
        }


        private void drawBoard()
        {
            Bitmap newBoard = new Bitmap(picBoard.Width, picBoard.Height);
            Pen p = new Pen(Color.Black);
        }

        private void picBoard_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(e.Graphics);
            Console.WriteLine(hexes[0].color);

        }

        private void picBoard_MouseClick(object sender, MouseEventArgs e)
        {
            int id = 0;
            float distance = 1000;
            foreach (Hex hex in hexes)
            {
                double newDistance = Math.Sqrt(Math.Pow(e.X - hex.center.X, 2) + Math.Pow(e.Y - hex.center.Y, 2));
                if (distance > newDistance)
                    {
                    distance = (float)newDistance;
                    id = hex.id;
                }
            }
            if (distance < picBoard.Width / 11)
            {
                clicks++;
                ChoseHex(id);

            }
            picBoard.Refresh();

        }

        private void ChoseHex(int id)
        {
            game.chosenHex = id;
            String[] text = new String[3];
            text[0] = $"Wybrano hex {hexes[id].coords.X}, {hexes[id].coords.Y}";
            if(hexes[id].color == "White")
            {
                text[1] = "Hex nie należy do nikogo";
            }
            else
            {
                text[1] = $"Hex należy do gracza {hexes[id].color}";
            }
            textBox2.Lines = text;
            button1.Visible = CanBeActivated(id);
        }
        private void DrawBoard(Graphics g)
        {
            foreach(Hex hex in hexes)
            {
                if (hex.color == "White") g.FillPolygon(Brushes.White, hex.points);
                else if (hex.color == "Yellow") g.FillPolygon(Brushes.Yellow, hex.points);
                else if (hex.color == "Red") g.FillPolygon(Brushes.Red, hex.points);
                else if (hex.color == "Green") g.FillPolygon(Brushes.Green, hex.points);
                else if (hex.color == "Blue") g.FillPolygon(Brushes.Blue, hex.points);
                else if (hex.color == "Purple") g.FillPolygon(Brushes.Purple, hex.points);
                else g.FillPolygon(Brushes.Black, hex.points);
                g.FillPolygon(Brushes.White, hex.points2);
                g.DrawPolygon(Pens.Black, hex.points);
            }

        }

        private bool CanBeActivated(int id)
        {
            float maximum_distance = (float)Math.Pow(picBoard.Width / 11.0d, 2) * 3;
            foreach(Hex hex in hexes)
            {
                float distance = 0;
                distance = (float)Math.Pow(hex.center.X - hexes[id].center.X, 2) + (float)Math.Pow(hex.center.Y - hexes[id].center.Y, 2);
                if(distance <= maximum_distance)
                {
                    if (hex.color == playerQueue[0]) return true;
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hexes[game.chosenHex].color = playerQueue[0];
            playerQueue.Add(playerQueue[0]);
            playerQueue.RemoveAt(0);
            textBox1.Text = $"Tura gracza {playerQueue[0]}";
            button1.Visible = false;
            picBoard.Refresh();
        }
    }
}
