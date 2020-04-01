using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memento
{
    class Program
    {
        static void Main(string[] args)
        {
            CareTaker caretaker = new CareTaker();
            User p = new User();
            Console.WriteLine("Changing name to Pedro");
            p.Name = "Pedro";
            Console.WriteLine("Changing name to Juan");
            p.Name = "Juan";

            caretaker.addMemento(p.saveToMemento());

            Console.WriteLine("Changing name to Carlos"); 
            p.Name = "Carlos";

            caretaker.addMemento(p.saveToMemento());

            Console.WriteLine("Changing name to Octavio"); 
            p.Name = "Octavio";

            Memento m1 = caretaker.getMemento(0);
            Memento m2 = caretaker.getMemento(1);

            Console.WriteLine(m1.SavedState);
            Console.WriteLine(m2.SavedState);

            Console.ReadKey();

        }
        public class Memento
        {
            private string state;
            public Memento(string state)
            {
                this.state = state;
            }

            public virtual string SavedState
            {
                get { return state; }
            }
        }
        public class User
        {
            private string name;
            public virtual Memento saveToMemento()
            {
                Console.WriteLine("Saving memento");
                return new Memento(name);
            }
            public virtual void restoreFromMemento(Memento m)
            {
                name = m.SavedState;
            }
            public virtual string Name
            {
                get { return name; }
                set { this.name = value; }
            }
        }
        public class CareTaker
        {
            private List<Memento> states = new List<Memento>();
            public virtual void addMemento(Memento m)
            {
                states.Add(m);
            }
            public virtual Memento getMemento(int index)
            {
                return states[index];
            }
        }
    }
}
