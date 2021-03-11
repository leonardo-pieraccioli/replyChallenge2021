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

        public Antenna(int id, int distMax, int v)
        {
            this.id = id;
            this.distMax = distMax;
            this.v = v;
        }

        public int CompareTo(Antenna other)
        {
            return this.v.CompareTo(other.v);
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
    }
}
