using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Model
{
    public class BucketRunner
    {
        public static ArrayList parents = new ArrayList();
        BucketTuple rootBuckitTuple;
        int target;

        public BucketRunner(int b1, int b2, int target)
        {
            this.rootBuckitTuple = new BucketTuple(new Bucket(b1), new Bucket(b2));
            this.target = target;
            parents.Add(rootBuckitTuple);
            new BucketTuple(new Bucket(0), new Bucket(0));
        }

        public static bool addToParents(BucketTuple bt)
        {
            if (parents.Contains(bt)) return false;
            else parents.Add(bt); return true;
        }

        //wrapper
        public string run() { 
            if(rootBuckitTuple != null)
                run(rootBuckitTuple);
            
            string stmp = "";
            foreach (BucketTuple bt in parents)
                stmp += bt.ToString();
            return stmp;
        }

        //recursive algorithm over tree of buckets
        public void run(BucketTuple btTmp)
        {
            if (!detectTarget()) {
                btTmp.findPermutation();
                if (btTmp.BL.Count > 0) {
                    foreach (BucketTuple btChild in btTmp.BL) {
                        run(btChild);
                    }
                }
            }
        }

        public bool detectTarget()
        {
            foreach (BucketTuple bt in parents)
                if (bt.b1.val.Equals(target) || bt.b2.val.Equals(target))
                    return true;
            return false;
        }


    }
}
