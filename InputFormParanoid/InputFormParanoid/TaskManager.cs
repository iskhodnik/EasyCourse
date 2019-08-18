using System;
using System.Collections.Generic;
using System.Linq;

namespace InputFormParanoid
{
    class TaskManager
    {
        private Dictionary<string, Task> tasks;
        private Dictionary<Task.TaskFields, string> newTaskValues;

        public TaskManager()
        {
            tasks = new Dictionary<string, Task>();
            newTaskValues = new Dictionary<Task.TaskFields, string>();
        }

        private void ImputTaskValues()
        {
            Console.WriteLine("Введите параметры задачи.");

            foreach (var parametr in Enum.GetValues(typeof(Task.TaskFields)))
            {
                Console.WriteLine($"{parametr.ToString()}: ");
                var value = ImputTaskValue();
                newTaskValues.Add((Task.TaskFields)parametr, value);
                Console.WriteLine();
            }
        }

        private string ImputTaskValue()
        {
            var param = Console.ReadLine();

            if (param.Equals(string.Empty))
            {
                ImputTaskValue();
            }

            return param;
        }


        public void ParseTaskValues()
        {
            Task task = new Task();

            foreach (var value in newTaskValues)
            {
                switch (value.Key)
                {
                    case Task.TaskFields.name:
                        task.SetName(value.Value);
                        break;

                    case Task.TaskFields.startDate:
                        task.SetStartDate(ParseValueToDateTime(Task.TaskFields.startDate.ToString(), value.Value));
                        break;

                    case Task.TaskFields.endDate:
                        task.SetEndDate(ParseValueToDateTime(Task.TaskFields.endDate.ToString(), value.Value));
                        break;

                    case Task.TaskFields.estimate:
                        task.SetEstimate(ParseValueToInt(Task.TaskFields.estimate.ToString(), value.Value));
                        break;

                    case Task.TaskFields.description:
                        task.SetDescription(value.Value);
                        break;
                }
            }

            tasks.Add(task.GetName(), task);
        }

        private DateTime ParseValueToDateTime(string key, string value)
        {
            DateTime convertedValue;
            try
            {
                convertedValue = DateTime.Parse(value);
                return convertedValue;
            }
            catch (FormatException)
            {
                Console.WriteLine($"У поля '{key}' введён неневерный формат даты.");
                Console.WriteLine($"Введите '{key}' повторно:");
                var newValue = ImputTaskValue();
                return ParseValueToDateTime(key, newValue);
            }
        }

        private int ParseValueToInt(string key, string value)
        {
            int convertedValue;
            try
            {
                convertedValue = int.Parse(value);

                if (convertedValue <= 0)
                {
                    throw new LessZeroException(key);
                }

                return convertedValue;
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Введите '{key}' повторно:");
                var newValue = ImputTaskValue();
                return ParseValueToInt(key, newValue);
            }
        }

        public void CreateTask()
        {
            ImputTaskValues();
            ParseTaskValues();
        }

        public void ShowTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Созданных задач нет!");
                return;
            }

            var random = new Random();

            foreach (var task in tasks)
            {
                var fields = task.Value.GetAllField();

                var randNumbers = Enumerable.Range(0, fields.Count).OrderBy(t => random.Next()).ToArray();

                foreach (var number in randNumbers)
                {
                    Console.WriteLine($"{((Task.TaskFields)number).ToString()} - {fields[(Task.TaskFields)number]}");
                }
            }
        }
    }
}
