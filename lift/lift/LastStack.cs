using System.Collections.Generic;

namespace lift
{
    class LastStack<T> : Stack<T>
    {
        public T Last { get; private set; }
        public new void Push(T item)
        {
            Last = item;
            base.Push(item);
        }
    }
}