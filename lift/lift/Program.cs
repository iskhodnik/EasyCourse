using System;
using System.Threading;

namespace lift
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите режим работы: Стек(1) или Очередь(2)");
            var mode = ParseValueToShort(InputValue());

            Console.WriteLine("Введите самый нижний этаж:");
            var lowestFloor = ParseValueToShort(InputValue());
            Console.WriteLine("Введите самый верхний этаж:");
            var highestFloor = ParseValueToShort(InputValue());

            var lift = new Lift(new short[] { lowestFloor, highestFloor }, 1, mode == 1 ? Lift.Mode.stack : Lift.Mode.queue);

            while(true)
            {
                Console.WriteLine($"Введите тот этаж ({lowestFloor} - {highestFloor}) куда надо:");
                while (true)
                {
                    var value = InputValue();
                    if (value.Equals("go"))
                    {
                        break;
                    }
                    lift.floorCall(ParseValueToShort(value));
                    lift.ShowCalledFloors();
                }

                Thread.Sleep(1000);
                lift.ArrivedOnFloor();
                Thread.Sleep(1000);
                lift.ArrivedOnFloor();

                lift.ShowCalledFloors();
            }
        }

        static private string InputValue()
        {
            var param = Console.ReadLine();

            if (param.Equals(string.Empty))
            {
                InputValue();
            }

            return param;
        }

        static private short ParseValueToShort(string value)
        {
            short convertedValue;
            try
            {
                convertedValue = short.Parse(value);
                return convertedValue;
            }
            catch (SystemException)
            {
                Console.WriteLine($"Введите значение повторно.");
                var newValue = InputValue();
                return ParseValueToShort(newValue);
            }
        }
    }
}
