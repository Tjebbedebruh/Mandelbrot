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
            mandlebrotOutput.Image = plaatje;
            mandlebrotOutput.BackColor = Color.LightGray;

            




            
/*
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
*/


            for (int x = 0; x < mandlebrotOutput.Width; x++)
            {
                for (int y = 0; y < mandlebrotOutput.Height; y++)
                {
                    
                    double a = ((double)(x - mandlebrotOutput.Width / 2) / (mandlebrotOutput.Width / 4));
                    double b = ((double)(y - mandlebrotOutput.Height / 2) / (mandlebrotOutput.Height /4));

                    double z = 0;
                    double c = 0;


                    
                    for (int i = 1; i <= 100; i++)
                    {
                        a = (double)((a * a) - (b * b)) + x;
                        b = (double)(2 * a * b + y);
                        z = z + a + b;
                        if (Math.Sqrt(a * a + b * b) > 2) 
                        {
                            plaatje.SetPixel(x, y, Color.Black);                      
                            break;
                        }

                    }
                }
            }


            Application.Run(scherm);
        }
    }
}