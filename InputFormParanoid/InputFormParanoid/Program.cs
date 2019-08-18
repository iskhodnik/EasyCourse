using System;

namespace InputFormParanoid
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskManager = new TaskManager();
            taskManager.CreateTask();
            taskManager.ShowTasks();

            Console.ReadKey();
        }
    }
}
