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
        private int anzReihen; // Anzahl Reihen
        private int ganzOben; // alles auf dem Spielfeld beginnt hier - unter dem Menu
        // alle möglichen Felder (Positionen für labels), in einem 1-dim Array
        private Point[] gridPositionen;

        //Zufallsalgorithmus
        List<int> numbers;


        //Verschiebelogik
        private int indexLeeresFeld;    //index des leeren Feldes
        private int anzMoves;   // mitzählen

        // Fürs Menu Anzahl Reihen
        private ToolStripMenuItem lastSelectedMenuItem ;


        public Form1()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            gridwidth = 60;
            rand = 2;
            anzReihen = 4;
            mnu4Reihen.Checked = true;
            lastSelectedMenuItem = mnu4Reihen;
            ganzOben = mnuMain.Height;
            createZufallsListe();
            anzMoves = 0;
        }

        private void restart()
        {            
            ganzOben = mnuMain.Height;
            createZufallsListe();
            anzMoves = 0;

            adjustFormsize();
            berechneGridPositionen();
            deleteAllChips();
            createChips();
            indexLeeresFeld = gridPositionen.Length - 1;

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
            int anzChips = anzReihen * anzReihen - 1;
            numbers = new List<int>(anzChips);
            // Liste mit den möglichen Nummern
            for (int i = 1; i <= numbers.Capacity; i++)
            {
                numbers.Add(i);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            restart();          
        }

        /// <summary>
        /// bei einem Neustart müssen zunächst alle Chips entfernt werden
        /// </summary>
        private void deleteAllChips()
        {
            // Wenn man in der Schleife chips aus Controls entfernt, kommt 
            // foreach aus dem Tritt, daher eine neue Liste mit den zu entfernenden
            // und diese dann aus Controls entfernen
            List<Control> toRemove = new List<Control>();
            foreach(Control c in this.Controls)
            {
                if (c.Tag == "chip")
                    toRemove.Add(c);
            }
            foreach (Control c in toRemove)
                this.Controls.Remove(c);
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
                //lb.Text = (nr + 1).ToString();
                lb.AutoSize = false;
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Tag = "chip";

                lb.MouseClick += new MouseEventHandler(control_MouseClick);
                this.Controls.Add(lb);
            }
        }

        //Anpassung der Größe der Form, damit Clientsize passt, wir beginnen "zu klein"
        private void adjustFormsize()
        {
            int zielWidth =  anzReihen * gridwidth;
            int zielHeight = zielWidth +ganzOben;
            this.Width = zielWidth;
            this.Height = zielHeight;
            while (ClientSize.Width < zielWidth)
                Width++;
            while (ClientSize.Height < zielHeight)
                Height++;
        }
            // Berechnen der anzReihen*anzReihen Positionen für die Labels und speichern im globalen Array gridPositionen
        private void berechneGridPositionen()
        {
            gridPositionen = new Point[anzReihen * anzReihen];
            // VAriante 1
            for (int zei = 0; zei < anzReihen; zei++)
                for (int spa = 0; spa < anzReihen; spa++)
                {
                    int aktIndex = spa + zei * anzReihen;
                    gridPositionen[aktIndex].X = spa * gridwidth + rand;
                    gridPositionen[aktIndex].Y = zei * gridwidth + rand+ganzOben;
                }
            //Variante 2
            // spa=index%anzReihen
            // zei=index/anzReihen
            // damit genügt eine Schleife über gridPositionen
            for (int aktIndex = 0; aktIndex < gridPositionen.Length; aktIndex++)
            {
                int spa = aktIndex % anzReihen;
                int zei = aktIndex / anzReihen;
                gridPositionen[aktIndex].X = spa * gridwidth + rand;
                gridPositionen[aktIndex].Y = zei * gridwidth + rand+ganzOben;
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
            fNr = zeile * anzReihen + spalte;
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
            Point startP = new Point(0, ganzOben), endP = new Point(0, ClientSize.Height);
            for (int x = gridwidth; x < ClientSize.Width; x += gridwidth)
            {
                startP.X = x;
                endP.X = x;
                g.DrawLine(Pens.Blue, startP, endP);
            }
            startP.X = 0;
            endP.X = ClientSize.Width;
            for (int y = gridwidth+ganzOben; y < ClientSize.Height; y += gridwidth)
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
            int[] zielIndizes = new int[4];
            zielIndizes[0] = ausgangsFeld - anzReihen;
            zielIndizes[1] = ausgangsFeld - 1;
            zielIndizes[2] = ausgangsFeld + anzReihen;
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
            }

        }

        private void endeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restart();
        }

        private void menuAnzReihen_Click(object sender, EventArgs e)
        {
            lastSelectedMenuItem.Checked = false;
            ToolStripMenuItem selectedItem = (ToolStripMenuItem)sender;
            int selectedNumber = Convert.ToInt32(selectedItem.Text);
            anzReihen = selectedNumber;
            selectedItem.Checked = true;
            lastSelectedMenuItem = selectedItem;
            

        }


    }
}
