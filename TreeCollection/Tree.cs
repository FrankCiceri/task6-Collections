using System.Collections;

namespace TreeCollection
{
    public class Tree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node<T> _initialNode;
        private readonly bool _rigthToLeft;
        private Stack<Node<T>> _stack = new Stack<Node<T>>();
        public Tree(bool isReversed = false) 
        {
            _rigthToLeft = isReversed;

        }

        public void Add(T newElement)
        {
            Node<T> newNode = new(newElement);

            if (_initialNode == null) { 
                _initialNode = newNode;
                return;            
            }

            Node<T> currentNode = _initialNode;
            while (true)
            {
                if (currentNode.CompareTo(newElement) > 0)
                {

                    if (currentNode.leftElement == null)
                    {

                        currentNode.leftElement = newNode;
                        return;

                    }
                    else
                    {

                        currentNode = currentNode.leftElement;

                    }

                }
                else if(currentNode.CompareTo(newElement) < 0) {

                    if (currentNode.rightElement == null)
                    {

                        currentNode.rightElement = newNode;
                        return;

                    }
                    else
                    {

                        currentNode = currentNode.rightElement;

                    }


                }else                {

                    throw new Exception("Element already added on the tree");
                
                }

            }


        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_rigthToLeft)
            {
                return RightToLeft(_initialNode);
            }

            return LeftToRight(_initialNode);
        }


        //public IEnumerator<T> LeftToRight() //non-recursive
        //{

        //    if (_initialNode != null)
        //    {
        //        Stack<Node<T>> stack = new Stack<Node<T>>();
        //        Node<T> currentNode = _initialNode;

        //        while (stack.Count > 0 || currentNode != null)
        //        {
        //            if (currentNode != null)
        //            {
        //                stack.Push(currentNode);
        //                currentNode = currentNode.leftElement;
        //            }
        //            else
        //            {
        //                currentNode = stack.Pop();
        //                yield return currentNode.element;
        //                currentNode = currentNode.rightElement;
        //            }
        //        }
        //    }

        //}


        private IEnumerator<T> LeftToRight(Node<T> currentNode)
        {

            if (currentNode == null)
            {
                yield break;
            }

            IEnumerator<T> leftEnumerator = LeftToRight(currentNode.leftElement);
            while (leftEnumerator.MoveNext())
            {
                yield return leftEnumerator.Current;
            }

            yield return currentNode.element;

            IEnumerator<T> rightEnumerator = LeftToRight(currentNode.rightElement);
            while (rightEnumerator.MoveNext())
            {
                yield return rightEnumerator.Current;
            }


        }

        //public IEnumerator<T> RightToLeft()//non-recursive
        //{

        //    if (_initialNode != null)
        //    {
        //        Stack<Node<T>> stack = new Stack<Node<T>>();
        //        Node<T> currentNode = _initialNode;

        //        while (stack.Count > 0 || currentNode != null)
        //        {
        //            if (currentNode != null)
        //            {
        //                stack.Push(currentNode);
        //                currentNode = currentNode.rightElement;
        //            }
        //            else
        //            {
        //                currentNode = stack.Pop();
        //                yield return currentNode.element;
        //                currentNode = currentNode.leftElement;
        //            }
        //        }
        //    }

        //}

        private IEnumerator<T> RightToLeft(Node<T> currentNode)
        {

            if (currentNode == null)
            {
                yield break;
            }
            IEnumerator<T> rightEnumerator = RightToLeft(currentNode.rightElement);
            while (rightEnumerator.MoveNext())
            {
                yield return rightEnumerator.Current;
            }
            
            yield return currentNode.element;

            IEnumerator<T> leftEnumerator = RightToLeft(currentNode.leftElement);
            while (leftEnumerator.MoveNext())
            {
               
                yield return leftEnumerator.Current;
            }

        }




        IEnumerator IEnumerable.GetEnumerator()
        {

            return GetEnumerator();
        }
    }
}