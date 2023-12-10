namespace CowBoyBeta2_0
{
    public class Bullet : GameComponent, IUpdate
    {
        public PictureBox pictureBox { get; set; }
        public int Speed { get; set; }
        public int Damage { get; set; }
        public Bullet(PictureBox pictureBox, int speed, int damage)
        {
            this.pictureBox = pictureBox;
            Speed = speed;
            Damage = damage;
            pictureBox.BringToFront();

        }

        public void Update()
        {
            pictureBox.Left += Speed;
        }
        public bool IsInTheSreen(int width)
        {
            if (pictureBox.Left < -pictureBox.Size.Width || pictureBox.Left > width)
                return false;
            return true;
        }
    }
}
