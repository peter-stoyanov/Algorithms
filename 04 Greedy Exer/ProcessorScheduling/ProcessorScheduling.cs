using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorScheduling
{
    class ProcessorScheduling
    {
        public class Task : IComparable<Task>
        {
            public Task(int id, int value, int deadline)
            {
                this.Id = id;
                this.Value = value;
                this.Deadline = deadline;
            }

            public int Id { get; set; }

            public int Value { get; set; }

            public int Deadline { get; set; }

            public int CompareTo(Task other)
            {
                return other.Value.CompareTo(this.Value);
            }
        }

        static void Main(string[] args)
        {
            int taskCount = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);

            int id = 1;

            List<Task> tasks = new List<Task>();

            int maxDeadline = 1;

            for (int i = 0; i < taskCount; i++)
            {
                int[] taskParams =
                    Console.ReadLine()
                        .Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                var task = new Task(id, taskParams[0], taskParams[1]);

                if (maxDeadline < taskParams[1])
                {
                    maxDeadline = taskParams[1];
                }

                tasks.Add(task);

                id++;
            }

            tasks.Sort();

            List<int> optimalSchedule = new List<int>();

            int totalValue = 0;

            var selectedTasks = tasks.Take(maxDeadline).OrderBy(t => t.Deadline).ToList();

            int step = 1;
            while (step <= maxDeadline)
            {
                var currentTask = selectedTasks[0];

                if (currentTask.Deadline >= step)
                {
                    optimalSchedule.Add(currentTask.Id);
                    totalValue += currentTask.Value;
                }

                selectedTasks.RemoveAt(0);

                step++;
            }

            Console.WriteLine("Optimal schedule: {0}", string.Join(" -> ", optimalSchedule));
            Console.WriteLine("Total value: {0}", totalValue);
        }
    }
}
