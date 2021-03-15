using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace replyCode
{
    class Program {
        public const int MIN_DIM = 10;
        public const int MAX_DIM = 6000;
        public const int MAX_RICOMPENSA = 200000000;
        public const int MAX_TENTATIVI = 100;
        //EDIFICI
        public const int MAX_EDIFICI = 350000;
        public const int MAX_PESO_LATENZA = 100;
        public const int MAX_PESO_CONNESSIONE = 100;
        //ANTENNE     
        public const int MAX_ANTENNE = 60000;
        public const int MAX_DISTANZA = 6000;
        public const int MAX_VEL_CONNESSIONE = 10000;

        public static List<Edificio> edifici = new List<Edificio>();
        public static List<Antenna> antenne = new List<Antenna>();
        public static List<Edificio> edificiScoperti;
        public static int reward;
        public static int righe, colonne;
        public static int[,] mappa;

        static string strout = "uscita_a.txt";

        static void Main(string[] args)
        {
            LeggiFile lettoreFile = new LeggiFile();
            lettoreFile.leggiFile();
            mappa = new int[colonne, righe];
            for (int hi = 0; hi < colonne; hi++)
                for (int j = 0; j < righe; j++)
                    mappa[hi, j] = 0;
            if (edifici.Count() < antenne.Count())
                antenne.RemoveRange(edifici.Count(), antenne.Count() - edifici.Count());
            
            Program.posizionaAntenne();
            //FileStream stream = new FileStream("C:\\Users\\leona\\source\\repos\\replyCode\\replyCode\\uscita.txt", FileMode.OpenOrCreate);
            using (TextWriter sw = new StreamWriter("C:\\Users\\leona\\source\\repos\\replyCode\\replyCode\\uscita_f.txt"))
            {

                sw.WriteLine(antenne.Count());
                foreach (Antenna a in antenne)
                {
                    sw.WriteLine(a.getID() + " " + a.getX() + " " + a.getY());
                }
            }
        }

        public static void posizionaAntenne()
        {
            //posiziona antenne su edifici ordinati in base alla velocità 
            for(int i=0; i<Math.Min(edifici.Count(), antenne.Count()); i++)
            {
                edifici[i].setAntenna(antenne[i]);
                antenne[i].setX(edifici[i].getX());
                antenne[i].setY(edifici[i].getY());
                antenne[i].setEdificio(edifici[i]);
            }

            if (edifici.Count() == antenne.Count())
                return;
            //lista di edifici senza antenna
            if (edifici.Count() > antenne.Count())
            {
                edificiScoperti = new List<Edificio>(edifici.GetRange(antenne.Count(), edifici.Count() - antenne.Count()));
                System.Console.WriteLine("Stampa edifici scoperti");
            }
            int distanzaMin = MAX_DISTANZA + 1;
            Edificio eVicino = new Edificio();
            int d;
            int newX;
            int newY;
            //verifica di possibile avvicinamento di alcune antenne in cui si usa nTentativi 
            foreach (Antenna a in antenne)
            {
                //trovare edificio scoperto più vicino escluso quello assegnato

                foreach (Edificio e in edificiScoperti)
                {
                    distanzaMin = MAX_DISTANZA + 1;
                    if ((d = calcolaDistanza(e, a)) < distanzaMin) {  
                        distanzaMin = d;
                        eVicino = e;
                    }
                }

                //avvicinamento
                if((d = calcolaDistanzaE(a.getEdificio(), eVicino)) < a.getDistMax() * 2)
                {
                    Edificio e = a.getEdificio();
                    //migliorare con quadrato migliore
                    newX = Math.Min(eVicino.getX(), e.getX()) + Math.Abs(eVicino.getX() - e.getX());
                    newY = Math.Min(eVicino.getY(), e.getY()) + Math.Abs(eVicino.getY() - e.getY());
                   
                    if (mappa[newX, newY] == 0)
                    {
                        a.setX(newX);
                        a.setY(newY);
                        mappa[newX, newY] = 1;
                    }
                    
                }
            }

            System.Console.WriteLine("Stampa finale antenne");
            foreach (Antenna a in antenne)
            {
                System.Console.WriteLine(a.getID() + " " + a.getX() + " " + a.getY());
            }

        }

        public int calcolaScore(Edificio e, Antenna a) {return e.getPesoConnessione() * a.getV() - e.getPesoLatenza() * calcolaDistanza(e, a);}
        public static int calcolaDistanza(Edificio e, Antenna a){return (Math.Abs(e.getX() - a.getX() + Math.Abs(e.getY() - a.getY())));}
        public static int calcolaDistanzaE(Edificio e1, Edificio e2){return (Math.Abs(e1.getX() - e2.getX() + Math.Abs(e1.getY() - e2.getY())));}

        public bool edificiAssegnati()
        {
            foreach (Edificio e in edifici)
            {
                if (e.getAntenna() == null)
                    return false;
            }
            return true;
        }

    }
}
