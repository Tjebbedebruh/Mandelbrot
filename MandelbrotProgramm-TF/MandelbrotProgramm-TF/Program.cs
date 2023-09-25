using System.Diagnostics;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Imaging;
using System.Numerics;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace MandelbrotProgramm_TF
{
    internal static class Program

    {
       static void Main()
        {   
            //deffineren scherm
            Form scherm = new Form();
            scherm.Text = "MandelbrotTF";
            scherm.ClientSize = new Size(1000, 800);
            Color BackColor = Color.FromArgb(27, 27, 27);
            scherm.BackColor = BackColor;
            Color BackColorTwo = Color.FromArgb(34, 34, 34);

            //Groote van de output bepalen
            int plaatjex = 600;
            int plaatjey = 600;

            TextBox zoomInvoer = new TextBox();
            scherm.Controls.Add(zoomInvoer);
            zoomInvoer.Location = new Point(100, 100);
            zoomInvoer.Size = new Size(100, 50);

            Label zoomTekst = new Label();
            scherm.Controls.Add(zoomTekst);
            zoomTekst.Location = new Point(0, 100);
            zoomTekst.Size = new Size(90, 20);
            zoomTekst.Text = " Zoomwaarde: ";
            zoomTekst.ForeColor = Color.White;
            zoomTekst.BackColor = BackColorTwo;

            TextBox xInvoer = new TextBox();
            scherm.Controls.Add(xInvoer);
            xInvoer.Location = new Point(100, 140);
            xInvoer.Size = new Size(100, 50);

            Label xInvoerTekst = new Label();
            scherm.Controls.Add(xInvoerTekst);
            xInvoerTekst.Location = new Point(0, 140);
            xInvoerTekst.Size = new Size(90, 20);
            xInvoerTekst.Text = " X invoer: ";
            xInvoerTekst.ForeColor = Color.White;
            xInvoerTekst.BackColor = BackColorTwo;

            TextBox yInvoer = new TextBox();
            scherm.Controls.Add(yInvoer);
            yInvoer.Location = new Point(100, 180);
            yInvoer.Size = new Size(100, 50);

            Label yInvoerTekst = new Label();
            scherm.Controls.Add(yInvoerTekst);
            yInvoerTekst.Location = new Point(0, 180);
            yInvoerTekst.Size = new Size(90, 20);
            yInvoerTekst.Text = " Y invoer: ";
            yInvoerTekst.ForeColor = Color.White;
            yInvoerTekst.BackColor = BackColorTwo;

            TextBox invoerMax = new TextBox();
            scherm.Controls.Add(invoerMax);
            invoerMax.Location = new Point(100, 220);
            invoerMax.Size = new Size(100, 50);

            Label invoerMaxTekst = new Label();
            scherm.Controls.Add(invoerMaxTekst);
            invoerMaxTekst.Location = new Point(0, 220);
            invoerMaxTekst.Size = new Size(90, 20);
            invoerMaxTekst.Text = " Max aantal: ";
            invoerMaxTekst.ForeColor = Color.White;
            invoerMaxTekst.BackColor = BackColorTwo;

            //standaar kleuren voor mandelbrotset
             Color[] generalColorPalette = new Color[] { };

            Color[] lastColorPalette = new Color[] { };

            //alle kleurpalleten
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

            Color[] whiteColorPalette = new Color[]
            {
                Color.FromArgb(0, 0, 0),
                Color.FromArgb(255, 255, 255),
                //Color.FromArgb(0,0,0),


            };

            //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

            //kleurkeuze menu maken
            Button kleurSchema = new Button();
            scherm.Controls.Add(kleurSchema);
            kleurSchema.Text = "Kleurschema";
            kleurSchema.Location = new Point(0, 260);
            kleurSchema.Size = new Size(200, 25);
            kleurSchema.ForeColor = Color.White;
            kleurSchema.BackColor = Color.Gray;
            kleurSchema.FlatStyle = FlatStyle.Flat;


            ContextMenuStrip kleurSchemaMenu = new ContextMenuStrip();
            ToolStripMenuItem blauwSchemaKnop = new ToolStripMenuItem("Blauw");
            ToolStripMenuItem roodSchemaKnop = new ToolStripMenuItem("Rood");
            ToolStripMenuItem groenSchemaKnop = new ToolStripMenuItem("Groen");
            ToolStripMenuItem zwartwitSchemaKnop = new ToolStripMenuItem("Zwart Wit");
            kleurSchemaMenu.Items.Add(blauwSchemaKnop);
            kleurSchemaMenu.Items.Add(roodSchemaKnop);
            kleurSchemaMenu.Items.Add(groenSchemaKnop);
            kleurSchemaMenu.Items.Add(zwartwitSchemaKnop);
            bool checkClick = false;

            //kleurkeuzemenu functies
            void kleurSchema_Click(object sender, EventArgs e)
            {
                kleurSchemaMenu.Show((Button)sender, new System.Drawing.Point(0, ((Button)sender).Height));
                
            }

            kleurSchema.Click += kleurSchema_Click;

            void blauwSchemaKnop_Click(object sender, EventArgs e)
            {
                generalColorPalette = blueishColorPalette;
                lastColorPalette = generalColorPalette;
                checkClick = true;
            }

            blauwSchemaKnop.Click += blauwSchemaKnop_Click;

            void roodSchemaKnop_Click(object sender, EventArgs e)
            {
                generalColorPalette = redishColorPalette;
                lastColorPalette = generalColorPalette;
                checkClick = true;
            }

            roodSchemaKnop.Click += roodSchemaKnop_Click;

            void groenSchemaKnop_Click(object sender, EventArgs e)
            {
                generalColorPalette = greenishColorPalette;
                lastColorPalette = generalColorPalette;
                checkClick = true;
            }

            groenSchemaKnop.Click += groenSchemaKnop_Click;

            void zwartwitSchemaKnop_Click(object sender, EventArgs e)
            {
                generalColorPalette = whiteColorPalette;
                lastColorPalette = generalColorPalette;
                checkClick = true;
            }

            zwartwitSchemaKnop.Click += zwartwitSchemaKnop_Click;
    

            //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=


            Button go = new Button();
            scherm.Controls.Add(go);
            go.Location = new Point(0, 300);
            go.Size = new Size(100, 30);
            go.BackColor = Color.Gray;
            go.Text = "Go!";
            go.ForeColor = Color.White;
            go.FlatStyle = FlatStyle.Flat;

            Button reset = new Button();
            scherm.Controls.Add(reset);
            reset.Location = new Point(100, 300);
            reset.Size = new Size(100, 30);
            reset.BackColor = Color.Gray;
            reset.Text = "Reset!";
            reset.ForeColor = Color.White;
            reset.FlatStyle = FlatStyle.Flat;

            Label mandelbrotVoorbeeld = new Label();
            mandelbrotVoorbeeld.Size = new Size(100, 100);
            mandelbrotVoorbeeld.Location = new Point(50, 350);
            Image mandelVoorbeeld = Image.FromFile("rszvoorbeeld1.png");
            mandelbrotVoorbeeld.Image = mandelVoorbeeld;
            scherm.Controls.Add(mandelbrotVoorbeeld);
            Color BackColorFour = Color.FromArgb(44, 44, 44);
            mandelbrotVoorbeeld.BackColor = BackColorFour;

            Label mandelbrotVoorbeeldTwee = new Label();
            scherm.Controls.Add(mandelbrotVoorbeeldTwee);
            mandelbrotVoorbeeldTwee.Size = new Size(100, 100);
            mandelbrotVoorbeeldTwee.Location = new Point(50, 460);
            Image mandelVoorbeeld2 = Image.FromFile("rszvoorbeeld2.png");
            mandelbrotVoorbeeldTwee.Image = mandelVoorbeeld2;
            mandelbrotVoorbeeldTwee.BackColor = BackColorFour;

            Label mandelbrotVoorbeeldDrie = new Label();
            scherm.Controls.Add(mandelbrotVoorbeeldDrie);
            mandelbrotVoorbeeldDrie.Size = new Size(100, 100);
            mandelbrotVoorbeeldDrie.Location = new Point(50, 570);
            Image mandelVoorbeeld3 = Image.FromFile("rszvoorbeeld3.png");
            mandelbrotVoorbeeldDrie.Image = mandelVoorbeeld3;
            mandelbrotVoorbeeldDrie.BackColor = BackColorFour;

            Label mandelbrotVoorbeeldVier = new Label();
            scherm.Controls.Add(mandelbrotVoorbeeldVier);
            mandelbrotVoorbeeldVier.Size = new Size(100, 100);
            mandelbrotVoorbeeldVier.Location = new Point(50, 680);
            Image mandelVoorbeeld4 = Image.FromFile("rszvoorbeeld4.png");
            mandelbrotVoorbeeldVier.Image = mandelVoorbeeld4;
            mandelbrotVoorbeeldVier.BackColor = BackColorFour;

            Label ColorFill = new Label();
            scherm.Controls.Add(ColorFill);
            ColorFill.Location = new Point(0, 0);
            ColorFill.Size = new Size(200, 1200);
            ColorFill.BackColor = BackColorTwo; 

            Label mandelbrotOutput = new Label();
            scherm.Controls.Add(mandelbrotOutput);
            mandelbrotOutput.Size = new Size(plaatjex, plaatjey);
            mandelbrotOutput.Location = new Point(300, 100);
            Color BackColorThree = Color.FromArgb(34, 34, 34);
            ColorFill.BackColor = BackColorThree;
            mandelbrotOutput.BackColor = BackColorThree;

       
            //variablenen voor mandelbrotset maken
            double scale = 1;
            double x = 0;
            double y = 0;
            int maxNum = 100;

            //variabelen voor inzoomen
            double hierX = 0;
            double hierY = 0;
            int deler = 1;

            //bitmap declareren
            Bitmap plaatje = new(plaatjex, plaatjey);

    
            //mandelbrotset tekenen
            void teken(double vensterX, double vensterY)
            {
                //voor elke pixel bereken of het in de mandelbrotsetzit en vervolgens inkleuren met de corresponderende kleur
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

                        //pixels inkleuren op basis van of ze wel of niet inde mandelbrotset zitten of niet
                        if (Mandelgetal >= maxNum)
                        {
                            plaatje.SetPixel(OutputX, OutputY, Color.Black);
                        }

                        else if (generalColorPalette.Length > 0)
                        {
                            plaatje.SetPixel(OutputX, OutputY, generalColorPalette[Mandelgetal % generalColorPalette.Length]);
                        }

                        //plaatje outputten
                        mandelbrotOutput.Image = plaatje;
                        mandelbrotOutput.Invalidate();


                    }

                }
            }

            void tekenVoorbeeldEen(object sender, EventArgs e)
            {
                //waardes aanpassen op basis van de preset
                scale = 0.001953125;
                double venX = -0.45900175759277345;
                double venY = -0.5803083244628907;
                hierX = -0.45900175759277345;
                hierY = -0.5803083244628907;
                maxNum = 100;
                deler = 512;
                if (checkClick == false)
                {
                    generalColorPalette = whiteColorPalette;
                }
                else
                {
                    generalColorPalette = lastColorPalette;
                }

                //locatie, zoom en maxNum waardes laten zien in de input velden
                zoomInvoer.Text = (scale).ToString();
                xInvoer.Text = (venX).ToString();
                yInvoer.Text = (venY).ToString();
                invoerMax.Text = (maxNum).ToString();

                //plaatje genereren
                teken(venX, venY);
            }
            mandelbrotVoorbeeld.Click += tekenVoorbeeldEen;

            void tekenVoorbeeldTwee(object sender, EventArgs e)
            {
                //waardes aanpassen op basis van de preset
                scale = 0.015625;
                double venX = -0.553223634375;
                double venY = -0.6338478281250001;
                hierX = -0.553223634375;
                hierY = -0.6338478281250001;
                maxNum = 100;
                deler = 64;
                if (checkClick == false)
                {
                    generalColorPalette = whiteColorPalette;
                }
                else
                {
                    generalColorPalette = lastColorPalette;
                }

                //locatie, zoom en maxNum waardes laten zien in de input velden
                zoomInvoer.Text = (scale).ToString();
                xInvoer.Text = (venX).ToString();
                yInvoer.Text = (venY).ToString();
                invoerMax.Text = (maxNum).ToString();

                //plaatje genereren
                teken(venX, venY);
            }
            mandelbrotVoorbeeldTwee.Click += tekenVoorbeeldTwee;

            void tekenVoorbeeldDrie(object sender, EventArgs e)
            {
                //waardes aanpassen op basis van de preset
                scale = 0.00048828125;
                double venX = 0.3580791014648437; 
                double venY = -0.6382358050781248;
                hierX = 0.3580791014648437;
                hierY = -0.6382358050781248;
                maxNum = 100;
                deler = 2048;
                if (checkClick == false)
                {
                    generalColorPalette = whiteColorPalette;
                }
                else
                {
                    generalColorPalette = lastColorPalette;
                }

                //locatie, zoom en maxNum waardes laten zien in de input velden
                zoomInvoer.Text = (scale).ToString();
                xInvoer.Text = (venX).ToString();
                yInvoer.Text = (venY).ToString();
                invoerMax.Text = (maxNum).ToString();
                
                //plaatje genereren
                teken(venX, venY);
            }
            mandelbrotVoorbeeldDrie.Click += tekenVoorbeeldDrie;

            void tekenVoorbeeldVier(object sender, EventArgs e)
            {
                //waardes aanpassen op basis van de preset
                scale = 0.001953125;
                double venX = -1.4467107931640626;
                double venY = 9.765527343749922E-05;
                hierX = -1.4467107931640626;
                hierY = 9.765527343749922E-05;
                maxNum = 100;
                deler = 512;
                if (checkClick == false)
                {
                    generalColorPalette = whiteColorPalette;
                }
                else
                {
                    generalColorPalette = lastColorPalette;
                }

                //locatie, zoom en maxNum waardes laten zien in de input velden
                zoomInvoer.Text = (scale).ToString();
                xInvoer.Text = (venX).ToString();
                yInvoer.Text = (venY).ToString();
                invoerMax.Text = (maxNum).ToString();

                //plaatje genereren
                teken(venX , venY );
            }
            mandelbrotVoorbeeldVier.Click += tekenVoorbeeldVier;

            //plaatje genereren op basis van de input textboxes
            void berekenLocatie(object sender, EventArgs e)
            {
                //wanneer geen geldige input wordt gegeven; error outputten
                try
                {
                    //input doorgeven en daar plaatje van genereren
                    scale = double.Parse(zoomInvoer.Text);
                    double venX = double.Parse(xInvoer.Text); 
                    double venY = double.Parse(yInvoer.Text);
                    maxNum = int.Parse(invoerMax.Text);

                    //color pallete selecteren
                    if (checkClick == false)
                    {
                        generalColorPalette = whiteColorPalette;
                    }
                    else
                    {
                        generalColorPalette = lastColorPalette;
                    }

                    //daadwerkelijk het plaatje genereren
                    teken(venX, venY);

                }
                catch
                {
                    MessageBox.Show("Voer eerst geldige waardes in.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }


            //op basis van linkermuisclick of rechtermuisclick, inzoomeen of uitzoomen
            void mouseClick(object sender, MouseEventArgs mouse)
            {

                //inzoomen
                if (mouse.Button == MouseButtons.Left)
                {
                    scale /= 2;
                }
                //uitzoomen
                else if (mouse.Button == MouseButtons.Right)
                {
                    scale *= 2;

                }

                //x en y locatie bepalen in het raster van de mandelbrotset op basis van waar iemand klikt
                hierX += (mouse.X - 300) * 0.0033333 / deler;
                hierY += (mouse.Y - 300) * 0.0033333 / deler;

                //deler keer 2 want je bent ook 2 keer zo diep ingezoomd
                deler *= 2;
                
                //locatie, zoom en maxNum waardes laten zien in de input velden
                zoomInvoer.Text = (scale).ToString();
                xInvoer.Text = (hierX).ToString();
                yInvoer.Text = (hierY).ToString();
                invoerMax.Text = (maxNum).ToString();
               
                //plaatje genereren
                teken(hierX, hierY);
            }

            void ResetAction(object sender, EventArgs e)
            {

                //plaatje zetten op standaar zoom en locatie
                scale = 1;
                x = 0;
                y = 0;
                maxNum = 100;
                if (checkClick == false)
                {
                    generalColorPalette = whiteColorPalette;
                }
                else
                {
                    generalColorPalette = lastColorPalette;
                } 
                
                //standaard plaatje tekenen
                teken(x, y);

                //tekstvakjes vullen met standaard waardes
                zoomInvoer.Text = "1";
                xInvoer.Text = "0";
                yInvoer.Text = "0";
                invoerMax.Text = "100";

                //zoomvariabelen resetten
                hierX = 0;
                hierY = 0;
                deler = 1;
            }

            //eventhandlers
            reset.Click += ResetAction;
            mandelbrotOutput.MouseClick += mouseClick;
            go.Click += berekenLocatie;

            //Run applicatie
            Application.Run(scherm);
        }
    }
}