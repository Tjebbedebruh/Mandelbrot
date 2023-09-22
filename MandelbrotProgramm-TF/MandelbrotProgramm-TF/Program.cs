using System.Diagnostics;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Imaging;
using System.Numerics;
using System.Drawing.Drawing2D;

namespace MandelbrotProgramm_TF
{
    internal static class Program

        // de knoppen werken nog niet naar rechts maar dat gaat gefixt worden, ik moet nog even uitvogelen hoe ik kleurschema kan assignen aan het goeie kleurschema kleurtje. 






    {
       static void Main()
        {   
            //deffineren scherm
            Form scherm = new Form();
            scherm.Text = "MandelbrotTF";
            scherm.ClientSize = new Size(1400, 800);
            scherm.BackColor = Color.Blue;

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
            zoomTekst.Font = new Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point);


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
            xInvoerTekst.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point);

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
            yInvoerTekst.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point);

            TextBox invoerMax = new TextBox();
            scherm.Controls.Add(invoerMax);
            invoerMax.Location = new Point(100, 180);
            invoerMax.Size = new Size(100, 50);


            Label invoerMaxTekst = new Label();
            scherm.Controls.Add(invoerMaxTekst);
            invoerMaxTekst.Location = new Point(0, 180);
            invoerMaxTekst.Size = new Size(90, 20);
            invoerMaxTekst.Text = " Max aantal: ";
            invoerMaxTekst.ForeColor = Color.White;
            invoerMaxTekst.BackColor = BackColorFour;
            invoerMaxTekst.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point);

            //standaar kleuren voor mandelbrotset
            Color rgbColor;
            Color[] blueishColorPalette = new Color[]
            {
                Color.FromArgb(1,31,71),
                Color.FromArgb(3,4,94),
                Color.FromArgb(0,74,133),
                Color.FromArgb(0,97,158),
                Color.FromArgb(2,62,138),
                Color.FromArgb(0,125,179),
                Color.FromArgb(0,119,182),
                Color.FromArgb(0,150,199),
                Color.FromArgb(0,180,216),
                Color.FromArgb(72,202,228),
                Color.FromArgb(144,224,239),
                Color.FromArgb(173, 232, 244),
                Color.FromArgb(202, 240, 248),
                Color.FromArgb(188,226,240),
                Color.FromArgb(218,236,248),
            };

            Color[] redishColorPalette = new Color[]
            {
                Color.FromArgb(3,7,30),
                Color.FromArgb(55,6,23),
                Color.FromArgb(106,4,15),
                Color.FromArgb(157,2,8),
                Color.FromArgb(208,0,0),
                Color.FromArgb(220,47,2),
                Color.FromArgb(232,93,4),
                Color.FromArgb(244,140,6),
                Color.FromArgb(250,163,7),
                Color.FromArgb(255,186,8),

            };

            Color[] greenishColorPalette = new Color[]
            {
                Color.FromArgb(0,75,35),
                Color.FromArgb(0,100,0),
                Color.FromArgb(0,107,0),
                Color.FromArgb(0,114,0),
                Color.FromArgb(0,128,0),
                Color.FromArgb(56,176,0),
                Color.FromArgb(112,224,0),
                Color.FromArgb(158,240,26),
                Color.FromArgb(204,255,51),
                Color.FromArgb(215,252,101),

            };

            //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

            int kleurSchemaKeuze;

            Button kleurSchema = new Button();
            scherm.Controls.Add(kleurSchema);
            kleurSchema.Text = "Kleurschema";
            kleurSchema.Location = new Point(100, 220);
            kleurSchema.Size = new Size(100, 25);
            kleurSchema.ForeColor = Color.White;
            kleurSchema.BackColor = Color.SlateGray;



            ContextMenuStrip kleurSchemaMenu = new ContextMenuStrip();
            ToolStripMenuItem blauwSchemaKnop = new ToolStripMenuItem("Blauw");
            ToolStripMenuItem roodSchemaKnop = new ToolStripMenuItem("Rood");
            ToolStripMenuItem groenSchemaKnop = new ToolStripMenuItem("Groen");
            kleurSchemaMenu.Items.Add(blauwSchemaKnop);
            kleurSchemaMenu.Items.Add(roodSchemaKnop);
            kleurSchemaMenu.Items.Add(groenSchemaKnop);


            void kleurSchema_Click(object sender, EventArgs e)
            {
                kleurSchemaMenu.Show((Button)sender, new System.Drawing.Point(0, ((Button)sender).Height));
            }

            kleurSchema.Click += kleurSchema_Click;

            void blauwSchemaKnop_Click(object sender, EventArgs e)
            {

                Color[] kleurSchemaKeuze = new Color[blueishColorPalette.Length];
                Array.Copy(blueishColorPalette, kleurSchemaKeuze, blueishColorPalette.Length);
            }

            void roodSchemaKnop_Click(object sender, EventArgs e)
            {

                Color[] kleurSchemaKeuze = new Color[redishColorPalette.Length];
                Array.Copy(redishColorPalette, kleurSchemaKeuze, redishColorPalette.Length);
            }

            void groenSchemaKnop_Click(object sender, EventArgs e)
            {
                Color[] kleurSchemaKeuze = new Color[greenishColorPalette.Length];
                Array.Copy(greenishColorPalette, kleurSchemaKeuze, greenishColorPalette.Length);
            }





            Label kleurSchemaTekst = new Label();
            scherm.Controls.Add(kleurSchemaTekst);
            kleurSchemaTekst.Location = new Point(0, 220);
            kleurSchemaTekst.Size = new Size(90, 20);
            kleurSchemaTekst.Text = " Kleurschema: ";
            kleurSchemaTekst.ForeColor = Color.White;
            kleurSchemaTekst.BackColor = BackColorFour;
            kleurSchemaTekst.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point);

            //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=


            Button go = new Button();
            scherm.Controls.Add(go);
            go.Location = new Point(0, 260);
            go.Size = new Size(100, 30);
            go.BackColor = Color.LightGray;
            go.Text = "Go!";
            go.ForeColor = Color.White;
            go.BackColor = Color.SlateGray;

            Button reset = new Button();
            scherm.Controls.Add(reset);
            reset.Location = new Point(100, 260);
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

            Label mandelbrotOutput = new Label();
            scherm.Controls.Add(mandelbrotOutput);
            mandelbrotOutput.Size = new Size(plaatjex, plaatjey);
            mandelbrotOutput.Location = new Point(700, 100);
            mandelbrotOutput.BackColor = Color.LightGray;
            
            //variablenen voor mandelbrotset maken
            double scale = 1;
            double x = 0;
            double y = 0;
            int maxNum = 100;

            //variabelen voor inzoomen
            double hierX = 0;
            double hierY = 0;
            int deler = 1;

            Bitmap plaatje = new Bitmap(plaatjex, plaatjey);

         



            void teken(double vensterX, double vensterY)
            {
                for (int OutputX = 0; OutputX < mandelbrotOutput.Width; OutputX++)
                {
                    for (int OutputY = 0; OutputY < mandelbrotOutput.Height; OutputY++)
                    {
                        //x en y locatie bepalen in het raster van de mandelbrotset IPV in het raster van pixel
                        x = ((double)(OutputX - mandelbrotOutput.Width / 2) / (0.25 * mandelbrotOutput.Width / scale) + vensterX);
                        y = ((double)(OutputY - mandelbrotOutput.Height / 2) / (0.25 * mandelbrotOutput.Height / scale) + vensterY);

                      

                        //startwaardes van de formule
                        double a = 0;
                        double b = 0;
                        //int maxNum = 100;

                    

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


                        /*
                        if (Mandelgetal % 2 == 0 || Mandelgetal >= maxNum)
                        {

                            plaatje.SetPixel(OutputX, OutputY, Color.Black);
                        }
                        else
                        {
                            plaatje.SetPixel(OutputX, OutputY, Color.White);
                        }
                        */

                        if (Mandelgetal >= maxNum)
                        {
                            plaatje.SetPixel(OutputX, OutputY, Color.Black);
                        }

                        else
                        {
                            plaatje.SetPixel(OutputX, OutputY, kleurSchemaKeuze[Mandelgetal % kleurSchemaKeuze.Length]);
                        }


                        mandelbrotOutput.Image = plaatje;
                        mandelbrotOutput.Invalidate();


                    }

                }
            }



            void berekenLocatie(object sender, EventArgs e)
            {
                scale = double.Parse(zoomInvoer.Text);
                //double scale = 1;
                double venX = double.Parse(xInvoer.Text) / 300; // dit moet in tiendes dus als je 1 wilt moet het 0.1 zijn
                double venY = double.Parse(yInvoer.Text) / 300;
                teken(venX, venY);
            }

            


            
            
            void mouseClick(object sender, MouseEventArgs mouse)
            {

                //inzoomen
                if (mouse.Button == MouseButtons.Left)
                {
                    scale = scale / 2;

                }
                //uitzoomen
                else if (mouse.Button == MouseButtons.Right)
                {
                    scale = scale * 2;

                }
                //x en y locatie bepalen in het raster van de mandelbrotset op basis van waar iemand klikt
            
                

                hierX += (mouse.X - 300) * 0.0033333 / deler;
                hierY += (mouse.Y - 300) * 0.0033333 / deler;

                deler *= 2;

                Debug.WriteLine(mouse.X);
                Debug.WriteLine(mouse.Y);
                Debug.WriteLine(hierX);
                Debug.WriteLine(hierY);

                teken(hierX, hierY);
                //x = ((mouse.X) - mandelbrotOutput.Width / 2) / (0.25 * mandelbrotOutput.Width / scale);
                //y = ((mouse.Y) - mandelbrotOutput.Height / 2) / (0.25 * mandelbrotOutput.Height / scale);

                //teken(x, y);



            }

            void ResetAction(object sender, EventArgs e)
            {

                //plaatje zetten op standaar zoom en locatie
                scale = 1;
                x = 0;
                y = 0;
                maxNum = 100;
                teken(x, y);

                //tekstvakjes leegmaken
                zoomInvoer.Text = string.Empty;
                xInvoer.Text = string.Empty;
                yInvoer.Text = string.Empty;
                invoerMax.Text = string.Empty;

                //zoomvariabelen resetten
                hierX = 0;
                hierY = 0;
                deler = 1;
            }

            //eventhandlers
            reset.Click += ResetAction;
            mandelbrotOutput.MouseClick += mouseClick;
            go.Click += berekenLocatie;

            Application.Run(scherm);
        }
    }
}