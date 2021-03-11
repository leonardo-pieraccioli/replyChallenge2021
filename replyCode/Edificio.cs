using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace replyCode
{
    class Edificio : IComparable<Edificio>
    {
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
            return this.pesoConnessione.CompareTo(other.pesoConnessione);
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
