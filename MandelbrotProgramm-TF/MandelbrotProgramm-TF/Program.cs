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


            for (int OutputX = 0; OutputX < mandlebrotOutput.Width; OutputX++)
            {
                for (int OutputY = 0; OutputY < mandlebrotOutput.Height; OutputY++)
                {
                    double x = ((double)(OutputX - mandlebrotOutput.Width / 2) / (mandlebrotOutput.Width / 4));
                    double y = ((double)(OutputY - mandlebrotOutput.Height / 2) / (mandlebrotOutput.Height / 4));

                    double a = 0;
                    double b = 0;
                    int maxNum = 100;


                    int counter = 0;                   
                    for (int i = 1; i <= maxNum; i++)
                    {
                        counter++;
                        double temporary = (double)((a * a) - (b * b)) + x;
                        b = (double)(2 * a * b + y);
                        a = temporary;
                        

                        double afstand = Math.Sqrt(a * a + b * b);

                        if (afstand > 2) 
                        {                     
                            break;
                        }
                        
                    }
                    if (counter % 2 == 0 || counter >= maxNum)
                    {
                        plaatje.SetPixel(OutputX, OutputY, Color.Black);
                    }
                    else
                    {
                        plaatje.SetPixel(OutputX, OutputY, Color.White);
                    }
                }
            }


            Application.Run(scherm);
        }
    }
}