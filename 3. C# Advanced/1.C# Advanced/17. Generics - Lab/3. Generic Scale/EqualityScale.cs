using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericScale
{
    public class EqualityScale<T> 
    {
        
        public EqualityScale(T left, T right) 
        {
            this.Left = left;
            this.Right = right;
        }

        public T Left { get; private set; }
        public T Right { get; private set; }

        public bool AreEqual()
        {
            return Left.Equals(Right);
        }
    }
}
