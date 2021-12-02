using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo01122021
{
    class Program
    {
        static void Main(string[] args)
        {
            //SmartPhone sp = new SmartPhone();
            //if (sp is IComputer)
            //{
            //}

            //LinkedList<SmartPhone> list = new LinkedList<SmartPhone>();
            //LinkedListNode<SmartPhone> node = list.AddLast(sp);
            //list.AddLast(sp);
            //SmartPhone sp2 = new SmartPhone();
            //list.AddAfter(node, sp2);//add the element sp2 to the list after sp node
            //list.AddBefore(node, sp2);
            //list.AddLast(node);
            //Array.ForEach(list.ToArray(), x => Console.WriteLine(x));//lambda expression to print the elements of the array
            MyLinkedList<string> myList = new MyLinkedList<string>();
            myList.AddLast("HereIsMyText");
            myList.AddLast("text2");
            myList.AddLast("Name");
            myList.AddLast("HotApplePie");
            myList.AddLast("Text6");
            //foreach (var element in myList)
            //    Console.WriteLine(element);

            //Console.WriteLine(myList.GetElementByIndex(3));

            //myList.RemoveLast();
            //myList.RemoveLast();
            myList.AddAt(2, "HelloHereIam");
            myList.AddAt(4, "HelloHereIamAgain");
            foreach (var element in myList)
                Console.WriteLine(element);

        }
    }

    public class MyLinkedList<T> : System.Collections.IEnumerable
    {
        private Node<T> firstElement = null;
        private Node<T> lastElement = null;
        private int size = 0;

        public T GetLastElement()
        {
            return this.lastElement.Current;
        }

        public void PrintElements()
        {
            foreach (var element in this)
                Console.WriteLine(element);
        }

        public void AddLast(T element)
        {
            this.size++;
            if (this.firstElement == null)
            {
                this.firstElement = new Node<T>(element);
                this.lastElement = this.firstElement;
            }
            else
            {
                Node<T> elementNode = new Node<T>(this.lastElement, element);
                this.lastElement.Next = elementNode;
                this.lastElement = elementNode;
            }

        }

        public void AddAt(int index, T element)
        {
            if (index > this.size)
                return;//normally we throw the exception

            this.size++;
            if (this.size == 0)
            {
                Node<T> elementNode = new Node<T>(element);
                this.firstElement = elementNode;
                this.lastElement = elementNode;
            }
            else
            {
                Node<T> nodeIndex = this.GetNodeByIndex(index);
                //Shift elements right
                Node<T> elementNode = new Node<T>(nodeIndex.Previous, element);
                elementNode.Next = nodeIndex;
                if (nodeIndex.Previous != null)//previos can be null, if we talk about the first element 
                    nodeIndex.Previous.Next = elementNode;
                nodeIndex.Previous = elementNode;
            }

        }

        public void RemoveLast()
        {
            this.lastElement = this.lastElement.Previous;
            this.lastElement.Next = null;
            this.size--;
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            Node<T> element = this.firstElement;
            while (element != null)
            {
                yield return element.Current;
                element = element.Next;
            }
            yield break;
        }

        private Node<T> GetNodeByIndex(int index)
        {
            int i = 0;
            Node<T> element = this.firstElement;
            while (i < index)
            {
                i++;
                if (element.HasNext == false)
                    throw new ElementNotExist();
                element = element.Next;
            }
            return element;
        }

        public T GetElementByIndex(int index)
        {
            return this.GetNodeByIndex(index).Current;
        }

        public int GetSize()
        {
            return this.size;
        }

        public Node<T> GetLast()
        {
            if (this.firstElement == null)
                throw new ElementNotExist();
            else
            {
                Node<T> currentElement = this.firstElement;
                while (currentElement.Next != null)
                {
                    currentElement = currentElement.Next;
                }
                return currentElement;
            }
        }

    }

    public class ElementNotExist : Exception
    {
    }

    class Node<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
    }

    public class Node<T>
    {
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
        public T Current { get; private set; }
        public bool HasNext
        {
            get { return this.Next == null ? false : true; }
        }

        public Node(Node<T> previous, T current)
        {
            this.Previous = previous;
            this.Current = current;
        }
        public Node(T current)
        {
            this.Current = current;
        }

    }


    class SmartPhone : IComputer
    {

    }

    class PC : IComputer
    {

    }

    interface IComputer
    {

        //void PowerOn();
    }

}
