namespace CowBoyBeta2_0
{
    public partial class Form1 : Form, IUpdate
    {
        public Size WindowSize {  get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        Player player1;
        Player player2;

        List<List<GameComponent>> GameComponents = new List<List<GameComponent>>();

        private void Form1_Load(object sender, EventArgs e)
        {
            // "Render mod" \\
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // turn off ReSize \\
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            
            // remove buttons
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public void Setup()
        {
            this.Size = WindowSize;
            int HalfHeigth = Width / 2;

            // Create Player 1 \\
            player1 = new Player(1,
                 Create.pictureBox("PictureBox_player1", new Size(30, 30), new Point(0, 0), Properties.Resources.cowboy),
                3, 10);

            // give (create) waepon
            player1.SetWeapon(new Weapon(
                Create.pictureBox("Revolver1", new Size(30, 30), new Point(0, 0), Properties.Resources.Revorver),
                3000, 1000, 5)
                );

            // Create Player 2 \\
            player2 = new Player(2,
                 Create.pictureBox("PictureBox_player1", new Size(30, 30), new Point(0, 0), Properties.Resources.cowboy),
                3, 10);

            // give (create) waepon
            player2.SetWeapon(new Weapon(
                Create.pictureBox("Revolver2", new Size(30, 30), new Point(0, 0), Properties.Resources.Revorver),
                3000, 1000, -5));

            // place to the correct pos \\
            player1.pictureBox.Location = GetPlayerStartPos(player1, "left");
            player2.pictureBox.Location = GetPlayerStartPos(player2, "rigth");

            // Create the GameComponents List That holds all of the game objects \\
            List<GameComponent> temp = new List<GameComponent>
            {
                player1,
                player2
            };

            // index 0: Players 
            GameComponents.Add(temp);
            // index 1: Bullets
            GameComponents.Add(new List<GameComponent>());

            MainGameTimer.Enabled = true;
        }
        private void MainGame_Update(object sender, EventArgs e)
        {
            // MOVEMENT UPDATE \\
            for (int i = 0; i < GameComponents.Count; i++)
            {
                for (int j = 0; j < GameComponents[i].Count; j++)
                {
                    if (GameComponents[i][j] is IUpdate)
                        (GameComponents[i][j] as IUpdate).Update();
                }
            }


            // A bulleteket pörgeti az öreg \\
            for (int i = 0; i < GameComponents[1].Count; i++)
            {
                // distruct
                Bullet bullet = ((Bullet)GameComponents[1][i]);
                if (!bullet.IsInTheSreen(Width))
                {
                    Controls.Remove(((Bullet)GameComponents[1][i]).pictureBox);
                    GameComponents[1].RemoveAt(i);

                }

                // hit
                for (int j = 0; j < GameComponents[0].Count; j++)
                {
                    if (((Player)GameComponents[0][j]).pictureBox.Bounds.IntersectsWith(bullet.pictureBox.Bounds))
                    {
                        ((Player)GameComponents[0][j]).Hit(bullet);

                        Controls.Remove(((Bullet)GameComponents[1][i]).pictureBox);
                        GameComponents[1].RemoveAt(i);

                        WinCheck();
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // left Player (player 1) \\
            if (e.KeyCode == Keys.W)
            {
                player1.MoveUp = true;
            }
            else if (e.KeyCode == Keys.S)
            {
                player1.MoveDown = true;
            }
            else if (e.KeyCode == Keys.D)
            {
                GameComponents[1].Add(player1.weapon.Shoot());
            }

            // right Player (player 2) \\
            if (e.KeyCode == Keys.Up)
            {
                player2.MoveUp = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                player2.MoveDown = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                GameComponents[1].Add(player2.weapon.Shoot());
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //left player (player 1) \\
            if (e.KeyCode == Keys.W)
            {
                player1.MoveUp = false;
            }
            else if (e.KeyCode == Keys.S)
            {
                player1.MoveDown = false;
            }

            //rigth player (player 1) \\
            if (e.KeyCode == Keys.Up)
            {
                player2.MoveUp = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                player2.MoveDown = false;
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            //this.Size = WindowSize;
        }
        private Point GetPlayerStartPos(Player player, string side)
        {
            if (side.ToLower() == "left")
            {
                player.SetWeaponOffSet(new Point(30, 5));
                return new Point(50 - player.pictureBox.Width, Height / 2 - player.pictureBox.Height);
            }
            else if (side.ToLower() == "rigth")
            {
                player.SetWeaponOffSet(new Point(-30, 5));
                return new Point(Width - 50 - player.pictureBox.Width, Height / 2 - player.pictureBox.Height);
            }
            return new Point(0, 0);
        }
        private void WinCheck()
        {
            for (int i = 0; i < GameComponents[0].Count; i++)
            {
                if (((Player)GameComponents[0][i]).HP <= 0)
                {
                    MessageBox.Show("A(z)" + ((Player)GameComponents[0][i]).PlayerID + " számú Player");
                    Setup();
                }
            }
        }
    }
}