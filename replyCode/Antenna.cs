using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace replyCode
{
    class Antenna : IComparable<Antenna>
    {
        private int id;
        private int x;
        private int y;
        private int distMax;
        private int v;
        private Edificio e;

        public Antenna(int id, int distMax, int v)
        {
            this.id = id;
            this.distMax = distMax;
            this.v = v;
            this.e = null;
        }

        public int CompareTo(Antenna other)
        {
            return this.v.CompareTo(other.v);
        }

        public void setEdificio(Edificio e)
        {
            this.e = e;
        }

        public Edificio getEdificio()
        {
            return this.e;
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        public int getID()
        {
            return this.id;
        }

        public int getDistMax()
        {
            return this.distMax;
        }

        public int getV()
        {
            return this.v;
        }

        public int raggiunge(Edificio e)
        {
            int dist = calcolaDistanza(e, this);
            if (dist <= this.distMax)
                return 1;
            else
                return 0;
        }
    }
}
