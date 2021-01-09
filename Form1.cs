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
        List<Label> labels = new List<Label>();     
        Random rand = new Random();
        private Timer mainTimer = null;

        public Puzzle()
        {
            this.BackColor = Color.DarkBlue;
            InitializeComponent();
            InitializePuzzle();
            ShuffleTiles();
            InitializeMainTimer();
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
            if ((string)tile.Tag == "CanSwap")
            {
                Button tileEmpty = (Button)this.Controls["TileEmpty"];

                Point tileOldLocation = tile.Location;
                tile.Location = tileEmpty.Location;
                tileEmpty.Location = tileOldLocation;
            }
            else
            {
                return;
            }
            
        }

        private void ShuffleTiles()
        {
            for(int i = 0; i < 100; i++)
            {
                SwapTiles(tiles[rand.Next(0, 15)]);
            }
            AddLabels();
        }

        private void AddLabels()
        {
            Button tileEmpty = (Button)this.Controls["TileEmpty"];
            var labelWidth = 120;
            var labelHeight = 120;
            Label label = new Label();

            Label horLabel = new Label();
            horLabel.Location = tileEmpty.Location;
            horLabel.Width = labelWidth;
            horLabel.Height = 20;
            horLabel.Text = null;
            

            Label leftHorLabel = new Label();
            leftHorLabel.Left = tileEmpty.Left - 30;
            leftHorLabel.Top = tileEmpty.Top;
            leftHorLabel.Width = labelWidth;
            leftHorLabel.Height = 20;
            leftHorLabel.Text = null;
            

            Label verLabel = new Label();
            verLabel.Location = tileEmpty.Location;
            verLabel.Width = 10;
            verLabel.Height = labelHeight;
            verLabel.Text = null;
            

            Label topVerLabel = new Label();
            topVerLabel.Location = tileEmpty.Location;
            topVerLabel.Top = tileEmpty.Top - 30;
            topVerLabel.Width = 10;
            topVerLabel.Height = labelHeight;
            topVerLabel.Text = null;


            this.Controls.Add(horLabel);
            labels.Add(horLabel);
            this.Controls.Add(leftHorLabel);
            labels.Add(leftHorLabel);
            this.Controls.Add(verLabel);
            labels.Add(verLabel);


        }

        private void InitializeMainTimer()
        {
            mainTimer = new Timer();
            mainTimer.Interval = 10;
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            
            CheckLabelIntersection();
            
        }

        private void CheckLabelIntersection()
        {
            foreach (var label in labels)
            {
                foreach (var tile in tiles)
                {
                    if (label.Bounds.IntersectsWith(tile.Bounds))
                    {
                        tile.Tag = "CanSwap";
                    }
                    else
                    {
                        //label.Dispose();
                        //tile.Tag = null; doesn't work
                    }
                }
            }
            
        }


        //doesn't work also
        private void RemoveTags()
        {
            foreach (var label in labels)
            {
                foreach (var tile in tiles)
                {
                    if (!label.Bounds.IntersectsWith(tile.Bounds))
                    {
                        Controls.Remove(label);
                        label.Dispose();
                        tile.Tag = null;
                    }
                }
            }
        }

     

    }
}
