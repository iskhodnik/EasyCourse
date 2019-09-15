using System;

namespace ArrayList
{
    public class MyArrayList<T>
    {
        public T[] arrayList { private set; get; }

        public MyArrayList()
        {
            arrayList = new T[0];
        }

        public MyArrayList(T[] arrayList)
        {
            this.arrayList = arrayList;
        }

        public void Add(T element)
        {
            var obj = arrayList;
            Array.Resize(ref obj, arrayList.Length + 1);
            obj[obj.Length - 1] = element;
            arrayList = obj;
        }

        public void Remove(int id)
        {
            var newList = new T[arrayList.Length - 1];
            for (int i = 0; i < id; i++)
            {
                newList[i] = arrayList[i];
            }
            for (int i = id; i < newList.Length; i++)
            {
                newList[i] = arrayList[i + 1];
            }
            arrayList = newList;

        }

        public void Remove(T element)
        {
            for (int i = 0; i < arrayList.Length; i++)
            {
                if (arrayList[i].ToString().Equals(element.ToString()))
                {
                    Remove(i);
                    i--;
                }
            }
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < arrayList.Length; i++)
            {
                if (arrayList[i].ToString().Equals(element.ToString()))
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

            for (int i = 0; i < arrayList.Length; i++)
            {
                if (arrayList[i].ToString().Equals(element.ToString()))
                {
                    Array.Resize<int>(ref indexes, indexes.Length + 1);
                    indexes[indexes.Length - 1] = i;
                }
            }

            return indexes;
        }
    }
}
