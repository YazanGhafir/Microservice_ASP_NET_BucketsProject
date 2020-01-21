using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Model
{
    public class BucketTuple
    {
        public Bucket b1;
        public Bucket b2;
        public ArrayList BL = new ArrayList();

        public BucketTuple(Bucket b1, Bucket b2)
        {
            this.b1 = b1;
            this.b2 = b2;
        }

        public void findPermutation()
        {
            int a = b1.val; int A = b1.cap; int b = b2.val; int B = b2.cap;

            BucketTuple btTmp1 = new BucketTuple(new Bucket(b1.cap,0), b2);
            BucketTuple btTmp2 = new BucketTuple(b1, new Bucket(b2.cap, 0));
            BucketTuple btTmp3; BucketTuple btTmp4; BucketTuple btTmp5; BucketTuple btTmp6;

            if ((a + b - B) >= 0) btTmp3 = new BucketTuple(new Bucket(b1.cap, (a + b - B)), new Bucket(b2.cap, B));
            else btTmp3 = new BucketTuple(new Bucket(b1.cap, 0), new Bucket(b2.cap, (b + a)));


            if ((b + a - A) >= 0) btTmp4 = new BucketTuple(new Bucket(b1.cap, (A)), new Bucket(b2.cap, (b + a - A)));
            else btTmp4 = new BucketTuple(new Bucket(b1.cap, (a + b)), new Bucket(b2.cap, 0));

            if (a == 0) btTmp5 = new BucketTuple(new Bucket(A ,A), new Bucket(B, b));
            else btTmp5 = new BucketTuple(new Bucket(A,A), new Bucket(B,B));

            if (b == 0) btTmp6 = new BucketTuple(new Bucket(A ,a), new Bucket(B, B));
            else btTmp6 = new BucketTuple(new Bucket(A, A), new Bucket(B, B));

            if (BucketRunner.addToParents(btTmp1)) BL.Add(btTmp1);
            if (BucketRunner.addToParents(btTmp2)) BL.Add(btTmp2);
            if (BucketRunner.addToParents(btTmp3)) BL.Add(btTmp3);
            if (BucketRunner.addToParents(btTmp4)) BL.Add(btTmp4);
            if (BucketRunner.addToParents(btTmp5)) BL.Add(btTmp5);
            if (BucketRunner.addToParents(btTmp6)) BL.Add(btTmp6);
        }

        public override bool Equals(object obj)
        {
            BucketTuple bt2 = (BucketTuple)obj;
            return bt2.b1.Equals(this.b1) && bt2.b2.Equals(this.b2);
        }

        public void printChilds()
        {
            foreach (BucketTuple btChild in BL)
                Console.Write("   {0}", btChild.ToString());
            Console.WriteLine();
        }

        public string getChilds()
        {
            string s = "";
            foreach (BucketTuple btChild in BL)
                s += btChild.ToString();
            return s;
        }

        public override string ToString()
        {
            return "[" + this.b1.val + "," + this.b2.val  + "]";
        }

        public string unit_test()
        {
            //BucketTuple bt = new BucketTuple(new Bucket(8, 5), new Bucket(6, 3));
            BucketTuple bt = new BucketTuple(b1,b2);
            bt.findPermutation();
            return bt.getChilds();

        }

       


    }
}
