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

            Color BackColor = Color.FromArgb(27, 27, 27);
            scherm.BackColor = BackColor;
            Color BackColorFour = Color.FromArgb(48, 48, 48);


            int plaatjex = 600;
            int plaatjey = 600;

            TextBox zoomInvoer = new TextBox();
            scherm.Controls.Add(zoomInvoer);
            zoomInvoer.Location = new Point(100, 60);
            zoomInvoer.Size = new Size(100, 50);

            Label zoomTekst = new Label();
            scherm.Controls.Add(zoomTekst);
            zoomTekst.Location = new Point(0, 60);
            zoomTekst.Size = new Size(90, 20);
            zoomTekst.Text = " Zoomwaarde: ";
            zoomTekst.ForeColor = Color.White;
            zoomTekst.BackColor = BackColorFour;


            TextBox xInvoer = new TextBox();
            scherm.Controls.Add(xInvoer);
            xInvoer.Location = new Point(100, 100);
            xInvoer.Size = new Size(100, 50);

            Label xInvoerTekst = new Label();
            scherm.Controls.Add(xInvoerTekst);
            xInvoerTekst.Location = new Point(0, 100);
            xInvoerTekst.Size = new Size(90, 20);
            xInvoerTekst.Text = " X invoer: ";
            xInvoerTekst.ForeColor = Color.White;
            xInvoerTekst.BackColor = BackColorFour;

            TextBox yInvoer = new TextBox();
            scherm.Controls.Add(yInvoer);
            yInvoer.Location = new Point(100, 140);
            yInvoer.Size = new Size(100, 50);


            Label yInvoerTekst = new Label();
            scherm.Controls.Add(yInvoerTekst);
            yInvoerTekst.Location = new Point(0, 140);
            yInvoerTekst.Size = new Size(90, 20);
            yInvoerTekst.Text = " Y invoer: ";
            yInvoerTekst.ForeColor = Color.White;
            yInvoerTekst.BackColor = BackColorFour;

            Button go = new Button();
            scherm.Controls.Add(go);
            go.Location = new Point(0, 180);
            go.Size = new Size(100, 30);
            go.BackColor = Color.LightGray;
            go.Text = "Go!";
            go.ForeColor = Color.White;
            go.BackColor = Color.SlateGray;

            Button reset = new Button();
            scherm.Controls.Add(reset);
            reset.Location = new Point(100, 180);
            reset.Size = new Size(100, 30);
            reset.BackColor = Color.LightGray;
            reset.Text = "Reset!";
            reset.ForeColor = Color.White;
            reset.BackColor = Color.SlateGray;

            Label ColorFillThree = new Label();
            scherm.Controls.Add(ColorFillThree);
            ColorFillThree.Location = new Point(0, 0);
            ColorFillThree.Size = new Size(200, 1200);

            ColorFillThree.BackColor = BackColorFour;

            Label ColorFillTwo = new Label();
            scherm.Controls.Add(ColorFillTwo);
            ColorFillTwo.Location = new Point(0, 0);
            ColorFillTwo.Size = new Size(400, 1200);
            Color BackColorThree = Color.FromArgb(41, 41, 41);
            ColorFillTwo.BackColor = BackColorThree;

            Label ColorFill = new Label();
            scherm.Controls.Add(ColorFill);
            ColorFill.Location = new Point(0, 0);
            ColorFill.Size = new Size(600, 1200);
            Color BackColorTwo = Color.FromArgb(34, 34, 34);
            ColorFill.BackColor = BackColorTwo;

            Label mandlebrotOutput = new Label();
            scherm.Controls.Add(mandlebrotOutput);
            mandlebrotOutput.Size = new Size(plaatjex, plaatjey);
            mandlebrotOutput.Location = new Point(700, 100);
            mandlebrotOutput.BackColor = Color.LightGray;

            void Mandelbrot (object sender , EventArgs e)
            {
                double scale = double.Parse(zoomInvoer.Text);
                //double scale = 1;
                double vensterX = double.Parse(xInvoer.Text) / 300; // dit moet in tiendes dus als je 1 wilt moet het 0.1 zijn
                double vensterY = double.Parse(yInvoer.Text) / 300;

                Bitmap plaatje = new Bitmap(plaatjex, plaatjey);
                mandlebrotOutput.Image = plaatje;

                //begin aan muisklik dingen
                void mouseClick(object sender, MouseEventArgs mouse)
                {
                    double scale = 1;
                    int hereX = mouse.X;
                    int hereY = mouse.Y;
                    double vensterX = mouse.X / 300;
                    double vensterY = mouse.Y / 300;

                    if (mouse.Button == MouseButtons.Left)
                    {
                        scale = scale - 0.1; ;
                    }

                    else if (mouse.Button == MouseButtons.Right)
                    {
                        scale = scale + 0.1;
                    }

                }

                mandlebrotOutput.MouseClick += mouseClick;





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
          
            go.Click += Mandelbrot;

            Application.Run(scherm);
        }
    }
}