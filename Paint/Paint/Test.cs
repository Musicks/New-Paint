using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class Test
    {
        [TestCase]
        public void square()
        {
            Hashtable hash = new Hashtable();
            square sqr = new square();
            hash.Add("i", 3);
            Assert.AreEqual(3, sqr.examHash("i", hash));
        }

        [TestCase]
        public void rectangle()
        {
            Hashtable hash = new Hashtable();
            rectangle circ = new rectangle();
            hash.Add("i", 3);
            Assert.AreEqual(3, circ.examHash("i", hash));
        }

        [TestCase]
        public void circle()
        {
            Hashtable hash = new Hashtable();
            circle circ = new circle();
            hash.Add("i", 3);
            Assert.AreEqual(3, circ.examHash("i", hash));
        }
    }
}
