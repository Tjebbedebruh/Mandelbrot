using System.Drawing.Text;

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
            /*Bitmap plaatje = new Bitmap(plaatjex, plaatjey);
            Label mandlebrotOutput = new Label();
            scherm.Controls.Add(mandlebrotOutput);
            mandlebrotOutput.Size = new Size(plaatje.Width, plaatje.Height);
            mandlebrotOutput.Location = new Point(700, 100);
            mandlebrotOutput.Image = plaatje;
            mandlebrotOutput.BackColor = Color.LightGray; */

            TextBox zoomInvoer = new TextBox();
            scherm.Controls.Add(zoomInvoer);
            zoomInvoer.Location = new Point(120, 60);
            zoomInvoer.Size = new Size(90, 50);

            Label zoomTekst = new Label();
            scherm.Controls.Add(zoomTekst);
            zoomTekst.Location = new Point(10, 60);
            zoomTekst.Size = new Size(90, 20);
            zoomTekst.Text = "Zoomwaarde: ";

            TextBox xInvoer = new TextBox();
            scherm.Controls.Add(xInvoer);
            xInvoer.Location = new Point(120, 100);
            xInvoer.Size = new Size(90, 50);

            Label xInvoerTekst = new Label();
            scherm.Controls.Add(xInvoerTekst);
            xInvoerTekst.Location = new Point(10, 100);
            xInvoerTekst.Size = new Size(90, 50);
            xInvoerTekst.Text = "X invoer: ";

            TextBox yInvoer = new TextBox();
            scherm.Controls.Add(yInvoer);
            yInvoer.Location = new Point(120, 140);
            yInvoer.Size = new Size(90, 50);

            Label yInvoerTekst = new Label();
            scherm.Controls.Add(yInvoerTekst);
            yInvoerTekst.Location = new Point(10, 140);
            yInvoerTekst.Size = new Size(90, 50);
            yInvoerTekst.Text = "Y invoer: ";

            Button go = new Button();
            scherm.Controls.Add(go);
            go.Location = new Point(10, 190);
            go.Size = new Size(90, 20);
            go.BackColor = Color.LightGray;
            go.Text = "Go!";

            Button reset = new Button();
            scherm.Controls.Add(reset);
            reset.Location = new Point(110, 190);
            reset.Size = new Size(90, 20);
            reset.BackColor = Color.LightGray;
            reset.Text = "Reset!";



            void Mandelbrot (object sender , EventArgs e)
            {
                double scale = double.Parse(zoomInvoer.Text);
                //double scale = 1;
                double vensterX = double.Parse(xInvoer.Text) / 300; // dit moet in tiendes dus als je 1 wilt moet het 0.1 zijn
                double vensterY = double.Parse(yInvoer.Text) / 300;




                Bitmap plaatje = new Bitmap(plaatjex, plaatjey);
                Label mandlebrotOutput = new Label();
                scherm.Controls.Add(mandlebrotOutput);
                mandlebrotOutput.Size = new Size(plaatje.Width, plaatje.Height);
                mandlebrotOutput.Location = new Point(700, 100);
                mandlebrotOutput.Image = plaatje;
                mandlebrotOutput.BackColor = Color.LightGray;







                for (int OutputX = 0; OutputX < mandlebrotOutput.Width; OutputX++)
                {
                    for (int OutputY = 0; OutputY < mandlebrotOutput.Height; OutputY++)
                    {
                        //x en y locatie bepalen in het raster van de mandelbrotset IPV in het raster van pixel
                        double x = ((double)(OutputX - mandlebrotOutput.Width / 2) / (0.25 * mandlebrotOutput.Width / scale) + vensterX);
                        double y = ((double)(OutputY - mandlebrotOutput.Height / 2) / (0.25 * mandlebrotOutput.Height / scale) + vensterY);

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

                void ResetAction(object sender, EventArgs e)
                {
                    zoomInvoer.Text = string.Empty;
                    xInvoer.Text = string.Empty;
                    yInvoer.Text = string.Empty;
                    // er moet hier nog iets van een plaatje reset komen
                    

                }

                reset.Click += ResetAction;


            }
            /*
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
               // plaatje.Location = zoomLocation;
              
                mandlebrotOutput.Size = new Size(zoomWidth, zoomHeight);


            }
            */
            // mandlebrotOutput.MouseClick += mouseClick;
            //go.Click += calculateButtons;






            go.Click += Mandelbrot;







            Application.Run(scherm);
        }
    }
}