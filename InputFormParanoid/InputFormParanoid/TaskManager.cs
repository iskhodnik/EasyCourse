using System;
using System.Collections.Generic;

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
                try
                {
                    switch (value.Key)
                    {
                        case Task.TaskFields.name:
                            task.SetName(value.Value);
                            break;

                        case Task.TaskFields.startDate:
                            task.SetStartDate(ConvertToDateTime(value.Value));
                            break;

                        case Task.TaskFields.endDate:
                            break;

                        case Task.TaskFields.estimate:
                            break;

                        case Task.TaskFields.description:
                            break;
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private DateTime ConvertToDateTime(string value)
        {
            DateTime convertedDate;
            try
            {
                convertedDate = Convert.ToDateTime(value);
                //Console.WriteLine("'{0}' converts to {1} {2} time.",
                //                  value, convertedDate,
                //                  convertedDate.Kind.ToString());
                return convertedDate;
            }
            catch (FormatException)
            {
                Console.WriteLine($"'{value}' не верный формат даты.");
                var newValue = ImputTaskValue();
                ConvertToDateTime(newValue);
            }

            throw new ArgumentNullException();
        }


        public void CreateTask()
        {
            ImputTaskValues();

            ParseTaskValues();
        }

    }
}
