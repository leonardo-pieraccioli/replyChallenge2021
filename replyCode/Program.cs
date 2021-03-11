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
        public static int reward;
        public static int righe, colonne;

        static void Main(string[] args)
        {
            LeggiFile lettoreFile = new LeggiFile();
            lettoreFile.leggiFile();

            if (edifici.Count() < antenne.Count())
                antenne.RemoveRange(edifici.Count(), antenne.Count() - edifici.Count());
            
            posizionaAntenne();
            LeggiFile.componiOutput(Edifici, antenne);
        }

        public void posizionaAntenne()
        {
            int nTentativi = 0;

            //posiziona antenne su edifici ordinati in base alla velocità 
            for(int i=0; i<Math.Min(edifici.Count(), edifici.Count()); i++)
            {
                edifici[i].setAntenna(antenne[i]);    
            }

            //terminazione quando tutti gli edifici sono coperti e nTentativi è maggiore di MAX_TENTATIVI
            while (nTentativi <= MAX_TENTATIVI && !edificiAssegnati())
            {
                //verifica di possibile avvicinamento di alcune antenne in cui si usa nTentativi 
                foreach(Antenna a in antenne)
                {
                    //trovare edificio più vicino escluso quello assegnato

                    //avvicinamento

                }
                //calcola soluzione, aggiorna migliore 
            }

        }

        public int calcolaScore(Edificio e, Antenna a)
        {
            //attenzione ai nomi dei getters 
            return e.getPesoConnessione() * a.getV() - e.getPesoLatenza() * calcolaDistanza(e, a);
        }
        public static int calcolaDistanza(Edificio e, Antenna a)
        {
            return (Math.Abs(e.getX() - a.getX() + Math.Abs(e.getY() - a.getY()));
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
