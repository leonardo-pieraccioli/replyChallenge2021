using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace replyCode
{
    class Edificio : IComparable<Edificio>
    {
        public const int MAX_EDIFICI = 350000;
        public const int MAX_PESO_LATENZA = 100;
        public const int MAX_PESO_CONNESSIONE = 100;

        private int x;
        private int y;
        private int pesoLatenza;
        private int pesoConnessione;
        private Antenna a;

        public Edificio() { }
        public Edificio(int x, int y, int pesoLatenza, int pesoConnessione)
        {
            this.x = x;
            this.y = y;
            this.pesoLatenza = pesoLatenza;
            this.pesoConnessione = pesoConnessione;
            this.a = null;
        }

        public int CompareTo(Edificio other)
        {
            return other.pesoConnessione.CompareTo(this.pesoConnessione);
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        public int getPesoLatenza()
        {
            return this.pesoLatenza;
        }

        public int getPesoConnessione()
        {
            return this.pesoConnessione;
        }

        public Antenna getAntenna()
        {
            return this.a;
        }

        public void setAntenna(Antenna a)
        {
            this.a = a;
        }
    }
}
