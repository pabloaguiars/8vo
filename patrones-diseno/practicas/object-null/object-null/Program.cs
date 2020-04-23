using System;

namespace object_null
{
    class Program
    {

        static void Main(string[] args)
        {
            // query for student
            AbstractStudent Student1 = StudentInfo.getStudents("Pablo");
            AbstractStudent Student2 = StudentInfo.getStudents("Jorge");
            AbstractStudent Student3 = StudentInfo.getStudents("Alfredo");
            AbstractStudent Student4 = StudentInfo.getStudents("Pedro");
            AbstractStudent Student5 = StudentInfo.getStudents("Alfonso");

            // show results
            Console.Write("Looking in db.");
            Console.Write(".\n");
            Console.WriteLine("\n=> " + Student1.Name + "\n");
            Console.WriteLine("=> " + Student2.Name + "\n");
            Console.WriteLine("=> " + Student3.Name + "\n");
            Console.WriteLine("=> " + Student4.Name + "\n");
            Console.WriteLine("=> " + Student5.Name);
            Console.ReadKey();
        }
        
        /// <summary>
        /// Abstarct class Student
        /// </summary>
        internal abstract class AbstractStudent
        {
            protected internal string name;
            public abstract bool Null { get; }
            public abstract string Name { get; }
        }

        /// <summary>
        /// Class Student
        /// </summary>
        internal class Student : AbstractStudent
        {
            public Student(String name)
            {
                this.name = name;
            }
            public override string Name
            {
                get { return name; }
            }
            public override bool Null
            {
                get { return false; }
            }
        }

        /// <summary>
        /// Null object for student
        /// </summary>
        internal class NullStudent : AbstractStudent
        {
            public override string Name
            {
                get { return "No student found"; }
            }
            public override bool Null
            {
                get { return true; }
            }
        }

        /// <summary>
        /// Student information class.
        /// </summary>
        internal class StudentInfo 
        {
            public static readonly string[] names = new string[] { "Pablo", "Carlos", "Pedro", "Alfonso"};
            public static AbstractStudent getStudents(string name)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    //find and return student
                    if (names[i].Equals(name, StringComparison.OrdinalIgnoreCase)) 
                    {
                        return new Student(name);
                    }
                }
                // no student, return null
                return new NullStudent();
            }
        }
    }
}
