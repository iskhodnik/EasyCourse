using System;

namespace ArrayList
{
    public class MyArrayList<T>
    {
        private T[] arrayList;
        public int Count { private set; get; }
        private const int DEFAULT_SIZE = 10;

        public MyArrayList()
        {
            arrayList = new T[DEFAULT_SIZE];
        }

        public MyArrayList(T[] arrayList)
        {
            this.arrayList = arrayList;
        }

        public void Add(T element)
        {
            TryResize(Count + 1);
            arrayList[Count] = element;
            Count++;
        }

        private void TryResize(int minSize)
        {
            if (minSize > arrayList.Length)
            {
                var obj = arrayList;
                int newSize = arrayList.Length + (arrayList.Length / 2);

                if (newSize < minSize)
                {
                    newSize = minSize;
                }

                Array.Resize(ref obj, newSize);
                arrayList = obj;
            }
        }


        public void Remove(int id)
        {
            var newList = arrayList;

            for (int i = id; i < Count; i++)
            {
                arrayList[i] = arrayList[i + 1];
            }
            Count--;
        }

        public void Remove(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (arrayList[i].Equals(element))
                {
                    Remove(i);
                    i--;
                }
            }
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (arrayList[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public T Get(int id)
        {
            return arrayList[id];
        }

        public int[] Get(T element)
        {
            var indexes = new int[0];

            for (int i = 0; i < Count; i++)
            {
                if (arrayList[i].Equals(element))
                {
                    Array.Resize<int>(ref indexes, indexes.Length + 1);
                    indexes[indexes.Length - 1] = i;
                }
            }

            return indexes;
        }


        public void ForEach(Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            for (int i = 0; i < Count; i++)
            {
                action(arrayList[i]);
            }
        }
    }
}
