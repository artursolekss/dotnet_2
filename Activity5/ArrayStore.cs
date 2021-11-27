using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Activity.CardGame
{
    public class ArrayStore<T> : AbstractArrayStore<T>
    {
        public ArrayStore()
        {
        }

        public ArrayStore(int arraySize) : base(arraySize)
        {


        }

        public int Length { get { return this.Capacity; } }

        public override int Add(T argToAdd)

        {


            if (Count >= Capacity)

                return NOT_IN_STRUCTURE;


            if (argToAdd == null)
                throw new ArgumentNullException();

            else

                this[Count++] = argToAdd;
            return this.Count;

        }

        public override int Insert(T argToInsert, int indexToInsert)
        {
            if (this.IsFull())
                return NOT_IN_STRUCTURE;

            if (argToInsert == null)
            {
                throw new ArgumentNullException();
            }

            //if(Count >= Capacity)
            //    throw new IndexOutOfRangeException();


            if (indexToInsert < 0 || indexToInsert >= Capacity)
                throw new ArgumentOutOfRangeException();


            for (int i = this.Count; i > indexToInsert; i--)
            {
                this[i] = this[i - 1];
                this[indexToInsert] = argToInsert;

            }
            return this.Count++;


        }

        public override void Remove(T argToRemove)
        {


            if (argToRemove == null)
                throw new ArgumentNullException();


            if (IndexOf(argToRemove) == NOT_IN_STRUCTURE)
                throw new InvalidOperationException();

            else
                for (int i = 0; i < this.Count; i++)
                {

                    if (IndexOf(argToRemove).Equals(this[i]))


                        this.RemoveAt(i);

                }


            //for (int i = 0; i < this.Count - 1; i++)
            //    this[i] = this[i + 1]; // shift
        }






        public override void RemoveAt(int removeObjectIndex)
        {

            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Impossible to remove.");
            }

            if (removeObjectIndex < 0 || removeObjectIndex > Capacity)
            {
                throw new ArgumentOutOfRangeException();
            }

            else
            {
                for (int i = 0; i < this.Count - 1; i++)
                    this[i] = this[i + 1]; //shift
                this.Count--;
            }





        }


    }
}