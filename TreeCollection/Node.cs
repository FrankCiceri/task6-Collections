using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TreeCollection
{
    internal class Node<T> where T: IComparable<T>
    {

        public Node(T element) { 
            this.element = element;
            leftElement = null;
            rightElement = null;        
        
        }

        public T element { get; set; }
        public Node<T> leftElement { get; set; }
        public Node<T> rightElement { get; set; }
        public bool isWatched { get; set; }

        public int CompareTo(T? other)
        {
            return element.CompareTo(other);
         }

        
      
    }
}
