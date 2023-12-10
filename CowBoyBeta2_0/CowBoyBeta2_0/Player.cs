namespace CowBoyBeta2_0
{
    public class Player : GameComponent, IUpdate, IHitable
    {
        public PictureBox pictureBox { get; set; }
        private ProgressBar Hpbar { get; set; }
        public Weapon weapon { get; set; }

        private Point WeaponOffSet;

        //move
        public bool MoveUp = false;
        public bool MoveDown = false;
        public int MoveLength { get; set; }

        public int MaxHP { get; set; }
        public int HP { get; set; }


        public Player(int playerID, PictureBox _pictureBox, int moveLength, int hp)
        {
            PlayerID = playerID;
            pictureBox = _pictureBox;
            MoveLength = moveLength;
            MaxHP = hp;
            HP = hp;

            Hpbar = Create.progressBar("Player1HpBar",new Size(50,10),new Point(0,0),MaxHP);
            Hpbar.Value = HP;
        }
        public void Update() 
        {
            Move();
            MoveHpBar();
            weapon.pictureBox.Location = GetWeaponOffSetPoint();
        }
        public void Move()
        {
            if (MoveUp)
                pictureBox.Top -= MoveLength;
            if(MoveDown)
                pictureBox.Top += MoveLength;
        }
        private void MoveHpBar()
        {
            Point newPos = new Point(pictureBox.Location.X, pictureBox.Location.Y-30);
            Hpbar.Location = newPos;
        }
        public void SetWeaponOffSet(Point point)
        {
            WeaponOffSet = point;
        }
        public Point GetWeaponOffSetPoint()
        {
            return new Point(pictureBox.Location.X + WeaponOffSet.X, pictureBox.Location.Y + WeaponOffSet.Y);
        }
        public void SetWeapon(Weapon weapon)
        { 
            this.weapon = weapon;
        }

        public void Hit(GameComponent Sender)
        {
            if (Sender.PlayerID != PlayerID)
            {
                if (Sender is Bullet)
                {
                    HP -= ((Bullet)Sender).Damage;
                    Hpbar.Value = HP;
                }
            }
            return;
        }
    }
}