using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace replyCode
{
    class LeggiFile
    {
        private List<Edificio> edifici = new List<Edificio>();
        private List<Antenna> antenne = new List<Antenna>();
        private int numB; 
        private int numA;
        private int reward; 
        private int x; 
        private int y; 


        public void leggiFile(){
            int i;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\francesca\Source\Repos\leonardo-pieraccioli\replyCode\replyCode\source.txt");
            string riga; 
            string[] valori; 
            riga= file.ReadLine(); 
            valori=riga.Split(' ');
            x=Int32.Parse(valori[0]);
            y=Int32.Parse(valori[1]);
            riga= file.ReadLine();
            valori=riga.Split(' ');
            numB=Int32.Parse(valori[0]);
            numA= Int32.Parse(valori[1]);
            reward=Int32.Parse(valori[2]);
            
            for(i=0;i<numB; i++){
                riga=file.ReadLine();
                valori=riga.Split(' ');
                edifici.Add(new Edificio(Int32.Parse(valori[0]),Int32.Parse(valori[1]), Int32.Parse(valori[2]), Int32.Parse(valori[3])));
            }
            for(i=0;i<numA; i++){
                riga=file.ReadLine();
                valori=riga.Split(' ');
                antenne.Add(new Antenna(i, Int32.Parse(valori[0]),Int32.Parse(valori[1])));
            }
            file.Close();
            edifici.Sort();
            antenne.Sort();
            Program.edifici=edifici;
            Program.antenne=antenne;
            Program.reward=reward;
            Program.righe=y;
            Program.colonne=x;

        }
        
        public void stampaEdifici(){
            System.Console.WriteLine("ci sono {0} edifici\n", numB);
            foreach(Edificio e in edifici){
                System.Console.WriteLine(e.getX()+' '+e.getY()+' '+e.getPesoLatenza()+' '+e.getPesoConnessione());
            }
        }

        public void stampaAntenne(){
            System.Console.WriteLine("ci sono {0} antenne\n", numA);
            foreach(Antenna a in antenne){
            System.Console.WriteLine(a.getID()+' '+a.getDistMax()+' '+a.getV());
            }
        }
    }
}
