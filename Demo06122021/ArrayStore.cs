using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Activity.Datastore
{
    public class ArrayStore<T> : AbstractArrayStore<T>
    {

        public override int Add(T argToAdd)
        {

            if (this.Count >= Capacity)
                this.IncreaceCapacity();

            else if (!typeof(T).IsValueType && argToAdd == null)
            {

                throw new ArgumentNullException("arg", "Input value cannot be null");
            }

            else
                this[Count++] = argToAdd;
            return Count;

        }

        public override int Insert(T argToInsert, int indexToInsert)
        {
            if (this.Count >= Capacity)
                this.IncreaceCapacity();

            if (!typeof(T).IsValueType && argToInsert == null)
            {

                throw new ArgumentNullException("Input value cannot be null");
            }
            else if (indexToInsert < 0 || indexToInsert >= Capacity)
            {

                throw new ArgumentOutOfRangeException("Argument is out of range ");

            }

            else
            {
                // 1 4 2 5 3; insert 5 at 2 => 1 4 5 2 5 3
                for (int i = this.Capacity - 1; i > indexToInsert; i--)
                    this[i] = this[i - 1];
                this[indexToInsert] = argToInsert;
                this.Count++;
                return indexToInsert;
            }

        }

        public override void Remove(T argToRemove) //not valid due to current state of the object
        {
            for (int i = 0; i < this.Count; i++)
            {
                //Check if the argument at the current index is equal to the input argument
                if (this[i].Equals(argToRemove))
                {
                    this.RemoveAt(i);
                    return;
                }
                else if (!typeof(T).IsValueType && argToRemove == null)
                {
                    throw new ArgumentNullException("Input value cannot be null");
                }

            }
            throw new InvalidOperationException();
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
                this.Count--;
                for (int i = removeObjectIndex; i < this.Count; i++)
                    this[i] = this[i + 1];
            }

        }

    }
}
