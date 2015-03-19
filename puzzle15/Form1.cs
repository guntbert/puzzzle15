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
     * +) Platzaufteilung, Geometrie: adjustFormsize, 
     *          berechneGridPositionen, feldnummer
     * 
     * +) Chips erzeugen: createChips
     * 
     * +) Verschiebelogik: control_mouseclick, + (createChips)
     * 
     * +) Zufallsalgorithmus: createZufallsListe, 
     *      nextNumber + (createChips)
     * 
     * +) Rasterlinien: Form_paint
     * 
     * +) Spielzüge mitzählen
     * 
     * +) "Gelöst" erkennen
     * 
     * +) Ideen für Bewertung der Spielsituation sammeln
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

        //Zufallsalgorithmus
        List<int> numbers;


        //Verschiebelogik
        private int indexLeeresFeld;    //index des leeren Feldes
        private int anzMoves;   // mitzählen


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
            createZufallsListe();
            anzMoves = 0;
        }

        private int nextNumber()
        {
            //für Nummern auf chips
            // ein zufälliges element der Liste wählen
            int index2Use = rnd.Next(numbers.Count);
            // dessen Wert speichern
            int selectedNumber = numbers[index2Use];
            // dieses Element aus der Liste entfernen
            numbers.RemoveAt(index2Use);
            return selectedNumber;
        }

        private void createZufallsListe()
        {
            //vorbereitung für zufällige Nummernvergabe
            // nummern auf den Chips sollen "gezogen" werden
            int anzChips = gridcount * gridcount - 1;
            numbers = new List<int>(anzChips);
            // Liste mit den möglichen Nummern
            for (int i = 1; i <= numbers.Capacity; i++)
            {
                numbers.Add(i);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adjustFormsize();
            berechneGridPositionen();

            createChips();
            indexLeeresFeld = gridPositionen.Length - 1;

            
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
                int selectedNumber = nextNumber();
                lb.Text = selectedNumber.ToString();
                // zunächst direkt nummeriren
                lb.Text = (nr + 1).ToString();
                lb.AutoSize = false;
                lb.TextAlign = ContentAlignment.MiddleCenter;

                lb.MouseClick += new MouseEventHandler(control_MouseClick);
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

        /// <summary>
       /// liefert aus den Koordinaten (z.B. der Loc)
       /// die Nummer des Feldes
       /// </summary>
       /// <param name="p">Location, zu der die Feldnummer ermittelt werden soll</param>
       /// <returns>Nummer des Feldes in dem p liegt</returns>
       /// <remarks>Nummern beginnen bei 0, zeilenweise</remarks>
        private int feldNummer(Point p)
        {
            int zeile, spalte;
            int fNr;
            zeile = p.Y / gridwidth;
            spalte = p.X / gridwidth;
            fNr = zeile * gridcount + spalte;
            return fNr;
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {        //zeichnet nur das rot/blaue grid

            drawRaster( e.Graphics);
            this.Text = anzMoves.ToString();
        }

        /// <summary>
        /// zieht einen Raster im Abstand <c>gridwith</c> über das graphics
        /// </summary>
        /// <param name="g">graphics-Context</param>
        /// <remarks>verwendet die Form-variable <c>gridwidth</c></remarks>
        private void drawRaster(Graphics g)
        {
            Point startP = new Point(0, 0), endP = new Point(0, ClientSize.Height);
            for (int x = gridwidth; x < ClientSize.Width; x += gridwidth)
            {
                startP.X = x;
                endP.X = x;
                g.DrawLine(Pens.Blue, startP, endP);
            }
            startP.X = 0;
            endP.X = ClientSize.Width;
            for (int y = gridwidth; y < ClientSize.Height; y += gridwidth)
            {
                startP.Y = y;
                endP.Y = y;
                g.DrawLine(Pens.Red, startP, endP);
            }
        }

	// Implementierung der Verschiebelogik
        void control_MouseClick(object sender, MouseEventArgs e)
        { 
            Control currentChip = sender as Control;

            // Verschiebelogik
            int ausgangsFeld;  // In welchem Feld ist der aktive Chip?
            bool allowMove; //darf das aktuelle Control überhaupt bewegt werden?

            ausgangsFeld = feldNummer(currentChip.Location);

            // array mit jenen indizes, die vom aktuellen feld aus erreicht werden können
            int[] zielIndizes = new int[]{0,0,0,0};
            zielIndizes[0] = ausgangsFeld - gridcount;
            if ((ausgangsFeld%gridcount !=0))
                zielIndizes[1] = ausgangsFeld - 1;
            zielIndizes[2] = ausgangsFeld + gridcount;
            if ((ausgangsFeld%gridcount !=3))
                zielIndizes[3] = ausgangsFeld + 1;

            //Control darf nur bewegt werden, wenn der Index des freien Feldes im obigen Array auftaucht
            allowMove = false;
            for (int i = 0; i < 4; i++)
            {
                if (indexLeeresFeld == zielIndizes[i])
                {
                    allowMove = true;
                    break;
                }
            }
            if (allowMove)
            {
                currentChip.Location = gridPositionen[indexLeeresFeld];
                indexLeeresFeld = ausgangsFeld;
                anzMoves++;
                if (isSolved())
                    MessageBox.Show("TaTAA!");
            }

        }

        private bool isSolved()
        {
            bool victory = true;
            // Schleife über alle chips
            foreach (Label chip in Controls)
            {
                Point l = chip.Location;
                int feldNr = feldNummer(l)+1;
                   if (chip.Text != feldNr.ToString())
                    {
                        victory = false;
                        break;
                    }
             }
            return victory;
        }
    }
}
