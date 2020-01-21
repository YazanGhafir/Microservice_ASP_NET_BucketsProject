using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Model
{
    public class Bucket
    {
        public int cap;
        public int val;

        public Bucket(int cap, int val)
        {
            this.cap = cap;
            this.val = val;
        }

        public Bucket(int b)
        {
            this.cap = b;
            this.val = b;
        }


        public override bool Equals(object obj)
        {
            Bucket b2 = (Bucket)obj; 
            return b2.cap == this.cap && b2.val == this.val;
        }

      
    }
}
