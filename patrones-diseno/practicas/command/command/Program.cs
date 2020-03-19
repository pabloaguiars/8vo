using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace command
{
    class Program
    {
        static void Main(string[] args)
        {
            Task copySecurity = new Backup();
            Task antivirus = new Antivirus();

            ICommand StartBackUp = new StartBackUpCommand(copySecurity);
            ICommand StopBackUp = new StopBackUpCommand(copySecurity);

            ICommand StartAntivirusCommand = new StartAntivirusCommand(antivirus);
            ICommand StopAntivirusCommand = new StopAntivirusCommand(antivirus);

            IInvoker TaskPlanner = new TaskPlanner();

            TaskPlanner.SetCommand(StartBackUp);
            TaskPlanner.Invoke();
            TaskPlanner.SetCommand(StopBackUp);
            TaskPlanner.Invoke();
            Console.WriteLine("\n");
            TaskPlanner.SetCommand(StartAntivirusCommand);
            TaskPlanner.Invoke();
            TaskPlanner.SetCommand(StopAntivirusCommand);
            TaskPlanner.Invoke();

            Console.ReadKey();
        }

        public interface ICommand
        {
            void Execute();
        }

        public interface IInvoker
        {
            void SetCommand(ICommand command);
            void Invoke();
        }

        public class TaskPlanner : IInvoker
        {
            ICommand command;
            public void SetCommand(ICommand command)
            {
                this.command = command;
            }
            public void Invoke()
            {
                command.Execute();
            }
        }

        public abstract class Task
        {
            protected bool working;
            protected int frecuency;
            protected string executedAt;
            public bool Working
            {
                get { return working; }
            }

            public void Stop()
            {
                this.working = false;
            }
            public abstract int Work();
        }

        public class Backup : Task
        {
            public override int Work()
            {
                this.working = true;
                return 0;
            }
        }

        public class Antivirus : Task
        {
            public override int Work()
            {
                this.working = true;
                return 0;
            }
        }
        public class System
        {
            public void Action()
            {
                Console.WriteLine("\nReparing System");
            }
        }

        public class StartBackUpCommand : ICommand
        {
            private Task task;
            public StartBackUpCommand(Task task)
            {
                this.task = task;
            }
            public void Execute()
            {
                Console.WriteLine(string.Format("\nBackup: Starting"));
                global::System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                global::System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                global::System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                global::System.Threading.Thread.Sleep(1000);
                Console.WriteLine(string.Format("\nBackup: Started"));
            }
        }
        public class StopBackUpCommand : ICommand
        {
            private Task task;
            public StopBackUpCommand(Task task)
            {
                this.task = task;
            }

            public void Execute()
            {
                task.Stop();
                Console.WriteLine(string.Format("\nBackup: Stopping"));
                Console.WriteLine(string.Format("\nBackup: Stopped"));
            }
        }

        public class StartAntivirusCommand : ICommand
        {
            private Task task;
            public StartAntivirusCommand(Task task)
            {
                this.task = task;
            }
            public void Execute()
            {
                Console.WriteLine(string.Format("\nAntivirus: Starting"));
                global::System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                global::System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                global::System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                global::System.Threading.Thread.Sleep(1000);
                Console.WriteLine(string.Format("\nAntivirus: Started"));
            }
        }
        public class StopAntivirusCommand : ICommand
        {
            private Task task;
            public StopAntivirusCommand(Task task)
            {
                this.task = task;
            }
            public void Execute()
            {
                task.Stop();
                Console.WriteLine("\nAntivirus: Stopping.");
                Console.WriteLine("\nAntivirus: Stopped.");
            }
        }
    }
}
