using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle15
{
    public partial class Puzzle : Form
    {
        List<Button> tiles = new List<Button>();
        List<Label> labels = new List<Label>();     //for the future
        Random rand = new Random();

        public Puzzle()
        {
            this.BackColor = Color.DarkBlue;
            InitializeComponent();
            InitializePuzzle();
            ShuffleTiles();
        }

        private void InitializePuzzle()
        {
            int tileCounter = 1;
            Button tile = null;

            for(int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    tile = new Button();
                    
                    tile.BackColor = Color.SteelBlue;
                    tile.Width = 80;
                    tile.Height = 80;
                    tile.Top = 20 + j * 90;
                    tile.Left = 20 + i * 90;

                    tile.Click += Tile_Click;

                    if (tileCounter == 16)
                    {
                        tile.Text = string.Empty;
                        tile.Name = "TileEmpty";
                    }
                    else
                    {
                        tile.Text = tileCounter.ToString();
                    }

                    this.Controls.Add(tile);
                    tiles.Add(tile);

                    tileCounter++;
                }
            }
           
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            Button tile = (Button)sender;
            SwapTiles(tile);
            AddLabels();
        }

        private void SwapTiles(Button tile)
        {
            Button tileEmpty = (Button)this.Controls["TileEmpty"];
            
            Point tileOldLocation = tile.Location;
            tile.Location = tileEmpty.Location;
            tileEmpty.Location = tileOldLocation;
        }

        private void ShuffleTiles()
        {
            for(int i = 0; i < 100; i++)
            {
                SwapTiles(tiles[rand.Next(0, 15)]);
            }
        }

        private void AddLabels()
        {
            Button tileEmpty = (Button)this.Controls["TileEmpty"];
            var labelWidth = 120;
            var labelHeight = 120;

            Label horLabel = new Label();
            horLabel.Location = tileEmpty.Location;
            horLabel.Width = labelWidth;
            horLabel.Height = 20;
            horLabel.Text = "teeeeeeeeeeeeeeeeeeeeeeeeeeeest";
            this.Controls.Add(horLabel);

            Label leftHorLabel = new Label();
            leftHorLabel.Left = tileEmpty.Left - 30;
            leftHorLabel.Top = tileEmpty.Top;
            leftHorLabel.Width = labelWidth;
            leftHorLabel.Height = 20;
            leftHorLabel.Text = "teeeeeeeeeeeeeeeeeeeest";
            this.Controls.Add(leftHorLabel);

            Label verLabel = new Label();
            verLabel.Location = tileEmpty.Location;
            verLabel.Width = 10;
            verLabel.Height = labelHeight;
            verLabel.Text = "teeeeeeeeeeeeeeeeeeeeeeeeest";
            this.Controls.Add(verLabel);

            Label topVerLabel = new Label();
            topVerLabel.Location = tileEmpty.Location;
            topVerLabel.Top = tileEmpty.Top - 30;
            topVerLabel.Width = 10;
            topVerLabel.Height = labelHeight;
            topVerLabel.Text = "teeeeeeeeeeeeeeeeeeeest";
            this.Controls.Add(topVerLabel);
        }

        private void CheckLabelIntersection()
        {
            //if(label.bounds.intersectswith(!tileEmpty) {give tag}
            //moš vajadzēs taimeri lai checkotu collisionu
            TagGiver();
        }

        private void TagGiver()
        {

        }

    }
}
