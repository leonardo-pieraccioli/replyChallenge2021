using System;
using System.Collections.Generic;
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

        static void Main(string[] args)
        {
            LeggiFile lettoreFile = new LeggiFile();
            lettoreFile.leggiFile();

            lettoreFile.stampaEdifici();
            lettoreFile.stampaAntenne();

            if (edifici.Count() < antenne.Count())
                antenne.RemoveRange(edifici.Count(), antenne.Count() - edifici.Count());
            
            Program.posizionaAntenne();

            lettoreFile.scriviFile(antenne);
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

            //lista di edifici senza antenna
            if (edifici.Count() > antenne.Count())
            {
                edificiScoperti = new List<Edificio>(edifici.GetRange(antenne.Count(), edifici.Count() - antenne.Count()));
            }

            //verifica di possibile avvicinamento di alcune antenne in cui si usa nTentativi 
            foreach(Antenna a in antenne)
            {
                //trovare edificio scoperto più vicino escluso quello assegnato
                int distanzaMin = MAX_DISTANZA + 1;
                Edificio eVicino = new Edificio() ;
                int d;
                foreach (Edificio e in edificiScoperti)
                {
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
                    a.setX(Math.Min(eVicino.getX(), e.getX()) + Math.Abs(eVicino.getX() - e.getX()));
                    a.setY(Math.Min(eVicino.getY(), e.getY()) + Math.Abs(eVicino.getY() - e.getY()));
                }
            } 
 
        }

        public int calcolaScore(Edificio e, Antenna a)
        {
            //attenzione ai nomi dei getters 
            return e.getPesoConnessione() * a.getV() - e.getPesoLatenza() * calcolaDistanza(e, a);
        }
        public static int calcolaDistanza(Edificio e, Antenna a)
        {
            return (Math.Abs(e.getX() - a.getX() + Math.Abs(e.getY() - a.getY())));
        }
        public static int calcolaDistanzaE(Edificio e1, Edificio e2)
        {
            return (Math.Abs(e1.getX() - e2.getX() + Math.Abs(e1.getY() - e2.getY())));
        }

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
