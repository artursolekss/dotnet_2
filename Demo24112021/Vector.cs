using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo24112021
{
    class Vector
    {

        private double[] elements;

        //Factory - takes the string 32 121 22 32 2 and returns the vector object
        public static Vector GetVectorFromString(string stringVector, char separator)
        {
            string[] stringElements = stringVector.Split(separator);
            Vector vector = new Vector(stringElements.Length);

            for (int i = 0; i < stringElements.Length; i++)
            {
                double element;
                if (!Double.TryParse(stringElements[i], out element))
                    throw new FormatException();
                else
                    vector[i] = element;
            }
            return vector;

        }

        public Vector(int size)
        {
            this.elements = new double[size];
        }

        public static Vector operator +(Vector vec1, Vector vec2)
        {
            ValidateVectorSizes(vec1, vec2);
            Vector result = new Vector(vec1.Length);
            for (int i = 0; i < result.Length; i++)
                result[i] = vec1[i] + vec2[i];
            return result;

        }

        public static Vector operator -(Vector vec1, Vector vec2)
        {
            ValidateVectorSizes(vec1, vec2);
            //Vector result = new Vector(vec1.Length);
            //for (int i = 0; i < result.Length; i++)
            //    result[i] = vec1[i] - vec2[i];
            //return result;
            return vec1 + (-1 * vec2);

        }

        public override string ToString()
        {
            return string.Join(" ",this.elements.Select(x => x));
        }

        public static Vector operator *(Vector vec, double c)
        {
            Vector result = new Vector(vec.Length);
            for (int i = 0; i < vec.Length; i++)
            {
                result[i] = vec[i] * c;
            }
            return result;
        }
        public static Vector operator *(double c, Vector vec)
        {
            return vec * c;
        }


        public static bool operator ==(Vector vec1, Vector vec2)
        {
            if (vec1.Length != vec2.Length)
                return false;

            for (int i = 0; i < vec1.Length; i++)
            {
                if (vec1[i] != vec2[i])
                    return false;
            }
            return true;
        }

        public static bool operator !=(Vector vec1, Vector vec2)
        {
            return !(vec1 == vec2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector))
                return false;
            else
                return this == (Vector)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static double operator *(Vector vec1, Vector vec2)
        {
            ValidateVectorSizes(vec1, vec2);
            double result = 0;
            for (int i = 0; i < vec1.Length; i++)
                result += vec1[i] * vec2[i];
            return result;

        }


        private static void ValidateVectorSizes(Vector vec1, Vector vec2)
        {
            if (vec1.Length != vec2.Length)
                throw new VectorSizeNotMatch();
        }

        public int Length { get { return this.elements.Length; } }

        public double this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.elements[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.elements[index] = value;

            }
        }
        private void ValidateIndex(int index)
        {
            if (index < 0)
                throw new IndexLessThanZeroException();
            else if (index > this.elements.Length - 1)
                throw new IndexGreaterThanSizeException();
        }

        //public void SetElement(double element, int index)
        //{
        //    this.elements[index] = element;
        //}

        //public double GetElement(int index)
        //{
        //    return this.elements[index];
        //}

    }

    public class VectorSizeNotMatch : Exception
    {
    }

    class IncorrectIndex : Exception
    {
    }

    class IndexLessThanZeroException : IncorrectIndex
    {
    }

    class IndexGreaterThanSizeException : IncorrectIndex
    {
    }
}
