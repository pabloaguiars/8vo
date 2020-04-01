using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer
{
	class Program
	{
		static void Main(string[] args)
		{
			SimpleSubject simpleSubject = new SimpleSubject();
			SimpleObserver simpleObserver1 = new SimpleObserver(simpleSubject);
			SimpleObserver simpleObserver2 = new SimpleObserver(simpleSubject);
			SimpleObserver simpleObserver3 = new SimpleObserver(simpleSubject);
			simpleSubject.Value = 80;
			Console.ReadKey();
		}
		public interface ISubject
		{
			void RegisterObserver(IObserver observer);
			void RemoveObserver(IObserver observer);
			void NotifyObservers();
		}
		public class SimpleSubject : ISubject
		{
			private IList<IObserver> Observers;
			private int value = 0;

			public SimpleSubject()
			{
				Observers = new List<IObserver>();
			}

			public virtual void RegisterObserver(IObserver observer)
			{
				Observers.Add(observer);
			}

			public virtual void RemoveObserver(IObserver observer)
			{
				int i = Observers.IndexOf(observer);
				if (i >= 0)
				{
					Observers.RemoveAt(i);
				}
			}

			public virtual void NotifyObservers()
			{
				foreach (IObserver observer in Observers)
				{
					observer.Update(value);
					observer.Display();
				}
			}

			public virtual int Value
			{
				set
				{
					this.value = value;
					NotifyObservers();
				}
			}
		}

		public interface IObserver
		{
			void Update(int value);
			void Display();
		}

		public class SimpleObserver : IObserver
		{
			private int value;
			private ISubject simpleSubject;

			public SimpleObserver(ISubject simpleSubject)
			{
				this.simpleSubject = simpleSubject;
				simpleSubject.RegisterObserver(this);
			}

			public virtual void Update(int value)
			{
				this.value = value;
			}

			public virtual void Display()
			{
				Console.WriteLine("Object: " + this.GetHashCode().ToString() + " Value: " + value.ToString());
			}
		}
	}
}
