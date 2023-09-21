namespace MandelbrotProgramm_TF
{
    internal static class Program
    {
       static void Main()
        {   

            //deffineren scherm
            Form scherm = new Form();
            scherm.Text = "MandelbrotTF";
            scherm.ClientSize = new Size(1400, 800);

            int plaatjex = 600;
            int plaatjey = 600;

            //mandlebrot ouput screen
            Bitmap plaatje = new Bitmap(plaatjex, plaatjey);
            Label mandlebrotOutput = new Label();
            scherm.Controls.Add(mandlebrotOutput);
            mandlebrotOutput.Size = new Size(plaatje.Width, plaatje.Height);
            mandlebrotOutput.Location = new Point(700, 100);
            mandlebrotOutput.Image = plaatje;
            mandlebrotOutput.BackColor = Color.LightGray;
            Button zoomButton = new Button();
            scherm.Controls.Add(zoomButton);
            zoomButton.Location = new Point(10, 10);
            zoomButton.Size = new Size(50, 20);
            zoomButton.BackColor = Color.LightGray;



            for (int OutputX = 0; OutputX < mandlebrotOutput.Width; OutputX++)
            {
                for (int OutputY = 0; OutputY < mandlebrotOutput.Height; OutputY++)
                {
                    //x en y locatie bepalen in het raster van de mandelbrotset IPV in het raster van pixel
                    double x = ((double)(OutputX - mandlebrotOutput.Width / 2) / (mandlebrotOutput.Width * 4));
                    double y = ((double)(OutputY - mandlebrotOutput.Height / 2) / (mandlebrotOutput.Height * 4));

                    //startwaardes van de formule
                    double a = 0;
                    double b = 0;
                    int maxNum = 100;

                    //Mandelgetal uitrekenen per pixel
                    int Mandelgetal = 0;
                    for (int i = 1; i <= maxNum; i++)
                    {
                        Mandelgetal++;
                        double temporary = (double)((a * a) - (b * b)) + x;
                        b = (double)(2 * a * b + y);
                        a = temporary;


                        double afstand = Math.Sqrt(a * a + b * b);

                        if (afstand > 2)
                        {
                            break;
                        }

                    }
                    //pixels kleuren op basis van het mandelgetal
                    if (Mandelgetal % 2 == 0 || Mandelgetal >= maxNum)
                    {
                        plaatje.SetPixel(OutputX, OutputY, Color.Black);
                    }
                    else
                    {
                        plaatje.SetPixel(OutputX, OutputY, Color.White);
                    }
                }
            }

            void mouseClick(object sender, MouseEventArgs mouse)
            {
                int zoomFactor = 2; // moet een knop voor gemaakt worden
                int hereX = mouse.X;
                int hereY = mouse.Y;
                int zoomWidth = plaatje.Width * zoomFactor;
                int zoomHeight = plaatje.Height * zoomFactor;
                int zoomX = hereX - (zoomWidth / 2);
                int zoomY = hereX - (zoomHeight / 2);

                Point zoomLocation = new Point(zoomX, zoomY);
                plaatje.Location = zoomLocation;
              
                mandlebrotOutput.Size = new Size(zoomWidth, zoomHeight);
                

            }

            mandlebrotOutput.MouseClick += mouseClick;



            Application.Run(scherm);
        }
    }
}