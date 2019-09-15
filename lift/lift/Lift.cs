using System;
using System.Linq;

namespace lift
{
    public class Lift
    {
        public enum Mode
        {
            queue,
            stack
        }

        private short[] numberOfStoreys;
        private short currentFloor;
        private LastQueue<short> queueCalledFloors;
        private LastStack<short> stackCalledFloors;
        private readonly Mode mode;

        public Lift(short[] numberOfStoreys, short currentFloor, Mode mode)
        {
            this.numberOfStoreys = numberOfStoreys;
            this.currentFloor = currentFloor;
            this.mode = mode;

            switch (mode)
            {
                case Mode.queue:
                    queueCalledFloors = new LastQueue<short>();
                    break;
                case Mode.stack:
                    stackCalledFloors = new LastStack<short>();
                    break;
            }
        }

        public void floorCall(short floor)
        {
            switch (mode)
            {
                case Mode.queue:
                    if (floor >= numberOfStoreys[0] && floor <= numberOfStoreys[1])
                    {
                        if (queueCalledFloors.Count == 0)
                        {
                            queueCalledFloors.Enqueue(floor);
                        }
                        else
                        {
                            if (queueCalledFloors.Last != floor)
                            {
                                queueCalledFloors.Enqueue(floor);
                            }
                        }
                    }
                    break;

                case Mode.stack:
                    if (floor >= numberOfStoreys[0] && floor <= numberOfStoreys[1])
                    {
                        if (stackCalledFloors.Count == 0)
                        {
                            stackCalledFloors.Push(floor);
                        }
                        else
                        {
                            if (stackCalledFloors.Last != floor)
                            {
                                stackCalledFloors.Push(floor);
                            }
                        }
                    }
                    break;
            }
        }

        internal void ArrivedOnFloor()
        {

            Console.Write($"Вы прибыли на этаж: ");

            switch (mode)
            {
                case Mode.queue:
                    if (queueCalledFloors.Count != 0)
                    {
                        Console.Write(queueCalledFloors.Dequeue());
                    }
                    break;

                case Mode.stack:
                    if (stackCalledFloors.Count != 0)
                    {
                        Console.Write(stackCalledFloors.Pop());
                    }
                    break;
            }

            Console.WriteLine();
        }

        public void ShowCalledFloors()
        {
            Console.Write("Очередь этажей: ");
            switch (mode)
            {
                case Mode.queue:
                    foreach (var i in queueCalledFloors.ToList())
                    {
                        Console.Write($"{i} ");
                    }
                    break;

                case Mode.stack:
                    foreach (var i in stackCalledFloors.ToList())
                    {
                        Console.Write($"{i} ");
                    }
                    break;
            }
            Console.WriteLine();
        }
    }
}
