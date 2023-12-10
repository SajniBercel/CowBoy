namespace CowBoyBeta2_0
{
    public class Weapon
    {
        public PictureBox pictureBox { get; set; }
        public int Magazine { get; set; }
        public int realoadSpeed { get; set; }
        public int FireRate { get; set; }
        public int BulettSpeed { get; set; }
        public int WeaponDamage { get; set; }

        public Weapon(PictureBox pictureBox, int realoadSpeed, int fireRate , int bulettSpeed)
        {
            this.pictureBox = pictureBox;

            this.realoadSpeed = realoadSpeed;
            FireRate = fireRate;
            BulettSpeed = bulettSpeed;

            WeaponDamage = 1;
        }
        public Bullet Shoot()
        {
            Bullet bullet = new Bullet(Create.pictureBox("Bullet",new Size(10,10),new Point(0,0), Properties.Resources.Bullet), BulettSpeed, WeaponDamage);
            bullet.pictureBox.Location = pictureBox.Location;
            return bullet;
        }
    }
}
