﻿using System.Collections.Generic;

namespace lift
{
    class LastQueue<T> : Queue<T>
    {
        public T Last { get; private set; }
        public new void Enqueue(T item)
        {
            Last = item;
            base.Enqueue(item);
        }
    }
}
