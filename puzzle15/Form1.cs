using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puzzle15
{
    /* Ablauf
     * 
     * 1) Platzaufteilung, Geometrie: adjustFormsize, berechneGridPositionen
     * 
     * 2) Chips erzeugen
     * 
     * 3) Zufallsalgorithmus
     * 
     * 4) Verschiebelogik
     * 
     * 5) Rasterlinien
     * 
     * */
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        // Platzaufteilung
        private int gridwidth; // Breite einer Reihe (Chips sind um 2*rand kleiner)
        private int rand;   // Rand um jedes Label
        private int gridcount; // Anzahl Reihen

        // alle möglichen Felder (Positionen für labels), in einem 1-dim Array
        private Point[] gridPositionen;

        public Form1()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            gridwidth = 60;
            rand = 2;
            gridcount = 4;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adjustFormsize();
            berechneGridPositionen();

            createChips();

            
        }

        private void createChips()
        {
            int anzChips = gridPositionen.Length - 1;
            // Erzeugen, positionieren der Labels ("Chips")
            for (int nr = 0; nr < anzChips; nr++)
            {
                Label lb = new Label();
                lb.Width = gridwidth - 2 * rand;
                lb.Height = gridwidth - 2 * rand;
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.Left = gridPositionen[nr].X;
                lb.Top = gridPositionen[nr].Y;
                lb.Font = new Font(FontFamily.GenericSansSerif, 14);
                //int selectedNumber = nextNumber();
                //lb.Text = selectedNumber.ToString();
                // zunächst direkt nummeriren
                lb.Text = (nr + 1).ToString();
                lb.AutoSize = false;
                lb.TextAlign = ContentAlignment.MiddleCenter;

                //lb.MouseClick += new MouseEventHandler(control_MouseClick);
                this.Controls.Add(lb);
            }
        }

        //Anpassung der Größe der Form, damit Clientsize passt, wir beginnen "zu klein"
        private void adjustFormsize()
        {
            int ziel = gridcount * gridwidth;
            this.Height = ziel;
            this.Width = ziel;
            while (ClientSize.Width < ziel)
                Width++;
            while (ClientSize.Height < ziel)
                Height++;
        }
            // Berechnen der gridcount*gridcount Positionen für die Labels und speichern im globalen Array gridPositionen
        private void berechneGridPositionen()
        {
            gridPositionen = new Point[gridcount * gridcount];
            // VAriante 1
            for (int zei = 0; zei < gridcount; zei++)
                for (int spa = 0; spa < gridcount; spa++)
                {
                    int aktIndex = spa + zei * gridcount;
                    gridPositionen[aktIndex].X = spa * gridwidth + rand;
                    gridPositionen[aktIndex].Y = zei * gridwidth + rand;
                }
            //Variante 2
            // spa=index%gridcount
            // zei=index/gridcount
            // damit genügt eine Schleife über gridPositionen
            for (int aktIndex = 0; aktIndex < gridPositionen.Length; aktIndex++)
            {
                int spa = aktIndex % gridcount;
                int zei = aktIndex / gridcount;
                gridPositionen[aktIndex].X = spa * gridwidth + rand;
                gridPositionen[aktIndex].Y = zei * gridwidth + rand;
            }
        }


    }
}
