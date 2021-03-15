using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace replyCode
{
    class LeggiFile
    {
        string strin = "data_scenarios_f_tokyo.in";
        private List<Edificio> edifici = new List<Edificio>();
        private List<Antenna> antenne = new List<Antenna>();
        private int numB; 
        private int numA;
        private int reward; 
        private int x; 
        private int y; 

        public void leggiFile(){
            int i;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:/Users/leona/source/repos/replyCode/replyCode/"+strin);
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
            System.Console.WriteLine("ci sono {0} edifici", numB);
            foreach(Edificio e in edifici){
                System.Console.WriteLine(e.getX()+ " " + e.getY());
            }
        }

        public void stampaAntenne(){
            System.Console.WriteLine("ci sono {0} antenne", numA);
            foreach(Antenna a in antenne){
            System.Console.WriteLine(a.getID()+" "+a.getDistMax()+" "+a.getV());
            }
        }

        public void scriviFile(List<Antenna> ants){
            TextWriter sw = new StreamWriter(@"C:/Users/leona/source/repos/replyCode/replyCode/");
            System.Console.WriteLine("Stampa finale antenne ");
            sw.Write(ants.Count());
            foreach (Antenna a in ants)
            {
                sw.Write(a.getID() + " " + a.getX() + " " + a.getY());
            }
            /*
            StreamWriter sw = File.CreateText(@"C:/Users/leona/source/repos/replyCode/replyCode/"+strout);
            sw.Write(ants.Count() + "\n");
            foreach(Antenna a in ants){
                sw.Write(a.getID()+ " " +a.getX()+ " " +a.getY() + "\n");
            }*/
        }
    }
}
