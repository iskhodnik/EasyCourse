using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericAggregatorClass
{
    public class GenericNumericClass<T>
    {
        private List<T> listObjects;

        public GenericNumericClass(List<T> listObjects)
        {
            if (TypeCheck(listObjects))
            {
                this.listObjects = listObjects ?? throw new NullReferenceException();
            }
        }

        public T Min()
        {
            return listObjects.Min();
        }

        public T Max()
        {
            return listObjects.Max();
        }

        private bool TypeCheck(List<T> listObjects)
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                default:
                    throw new ArgumentException($"{typeof(T)} - Неподдерживаемый тип данных");
            }
        }

        public double Average()
        {
            return listObjects.Select(s => double.Parse(s.ToString())).Average();
        }
    }
}