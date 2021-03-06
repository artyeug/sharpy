using System;
using System.Collections.Generic;

namespace LW07T1
{
    public class Array<T> : DataStructure<T>
    {
        public Array() : base() {}
        public Array(int capacity) : base(capacity) {}
        public Array(T obj, int length) : base(obj, length) {}
        public Array(List<T> list) : base(list) {}

        public override void Display()
        {
            Console.Write("Array: ");
            base.Display();
        }

        public static void Clear(
            Array<T> array, int index, int length
        )
        {
            if (array == null)
                throw new ArgumentNullException();

            int listSize = array.list.Count;
            int clBound = index + length; // i.e. clearing bound (upper)

            if (
                index < 0 || length < 0 ||
                index > listSize || clBound > listSize
            ) throw new IndexOutOfRangeException();
            else
                for (int i = index; i < clBound; ++i)
                    array.list[i] = default(T);
        }

        public static void Copy(Array<T> src, Array<T> dest, int length)
        {
            if (src == null || dest == null)
                throw new ArgumentNullException();
            else
            if (length < 0)
                throw new ArgumentOutOfRangeException();
            else
            if (length > src.Length || length > dest.Length)
                throw new ArgumentException();

            for (int i = 0; i < length; ++i)
                dest[i] = src[i];
        }

        public static void Copy(
            Array<T> src, int srcIndex, Array<T> dest, int destIndex,
            int length
        )
        {
            if (src == null || dest == null)
                throw new ArgumentNullException();
            else
            if (srcIndex < 0 || destIndex < 0 || length < 0)
                throw new ArgumentOutOfRangeException();

            int srcLen = src.Length;
            int destLen = dest.Length;
            int cpBound = srcIndex + length; // i.e. copying bound (upper)

            if (cpBound > srcLen || cpBound > destLen)
                throw new ArgumentException();

            for (int i = srcIndex, j = destIndex; i < cpBound; ++i, ++j)
                dest[j] = src[i];
        }

        public void CopyTo(Array<T> destination, int index)
        {
            if (destination == null)
                throw new ArgumentNullException();
            else
            if (index < 0)
                throw new ArgumentOutOfRangeException();

            int srcLen = this.Length;
            int cpBound = srcLen + index; // i.e. copying bound (upper)

            if (cpBound > destination.Length)
                throw new ArgumentException();

            for (int i = 0, j = index; i < srcLen; ++i, ++j)
                destination[j] = this[i];
        }

        public static T Find(
            Array<T> array, Predicate<T> match
        )
        {
            if (array == null || match == null)
                throw new ArgumentNullException();
            else
                return array.list.Find(match);
        }

        public static Array<T> FindAll(
            Array<T> array, Predicate<T> match
        )
        {
            if (array == null || match == null)
                throw new ArgumentNullException();

            var result = new Array<T>(
                array.list.FindAll(match)
            );
            return result;
        }

        public static void Sort(Array<T> array)
        {
            array.list.Sort();
        }
    } // public class Array<T> : DataStructure<T>
} // namespace LW07T1
