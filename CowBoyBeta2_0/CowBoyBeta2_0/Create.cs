namespace CowBoyBeta2_0
{
    public class Create
    {
        public static PictureBox pictureBox(string name, Size size, Point loc, Image image)
        {
            PictureBox pic = new PictureBox
            {
                Name = name,
                Size = size,
                Location = loc,
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Form1.ActiveForm.Controls.Add(pic);
            return pic;
        }
        public static ProgressBar progressBar(string name, Size size, Point loc, int max)
        {
            ProgressBar progBar = new ProgressBar
            {
                Name = name,
                Size = size,
                Location = loc,
                Maximum = max
            };
            Form1.ActiveForm.Controls.Add(progBar);
            return progBar;
        }
    }
}
