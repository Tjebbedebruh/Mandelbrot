namespace MandelbrotProgramm_TF
{
    internal static class Program
    {
       static void Main()
        {
            Form scherm = new Form();
            scherm.Text = "ElastiekC";
            scherm.ClientSize = new Size(1400, 800);

            //mandlebrot ouput screen
            Bitmap plaatje = new Bitmap(600, 600);
            Label mandlebrotOutput = new Label();
            scherm.Controls.Add(mandlebrotOutput);
            mandlebrotOutput.Size = new Size(plaatje.Width, plaatje.Height);
            mandlebrotOutput.Location = new Point(700, 100);
            mandlebrotOutput.BackColor = Color.LightGray;




            double a = 0;
            double b = 0;

            double Pythagoras()
            { 
                return Math.Sqrt(a * a + b * b);
            }

            void Vermenigvuldiging()
            {
                double tijdelijk = ((a * a) - (b * b));
                a = tijdelijk;
                b = 2 * a * b;
            }



            for (int x = 0; x < mandlebrotOutput.Width; x++)
            {
                for (int y = 0; y < mandlebrotOutput.Height; y++)
                {
                    plaatje.SetPixel(x,y, Color.Black);
                    //double a = ((double)(x - mandlebrotOutput.Width / 2) / (mandlebrotOutput.Width / 4));
                }
            }


            Application.Run(scherm);
        }
    }
}