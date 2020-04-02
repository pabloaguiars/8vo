using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strategy
{
	class Program
	{
		public class People
		{
			private string name;
			private string lastname;
			public virtual string Name
			{
				get { return name; }
				set { this.name = value; }
			}

			public virtual string LastName
			{
				get { return lastname; }
				set { this.lastname = value; }
			}
		}
		public class Book
		{
			private string title;
			private string status;

			public virtual string Status
			{
				get { return status; }
				set { this.status = value; }
			}

			public virtual string Title
			{
				get { return title; }
				set { this.title = value; }
			}
		}

		public class Student : People
		{
			private double grade;

			public virtual double Grade
			{
				get { return grade; }
				set { this.grade = value; }
			}
		}

		public class Teacher : People
		{
			private string folder;

			public virtual string Folder
			{
				get { return folder; }
				set { this.folder = value; }
			}
		}

		public class Member : People
		{
			private double fee;

			public virtual double Fee
			{
				get { return fee; }
				set { this.fee = value; }
			}
		}

		public class Library
		{
			private static List<Book> books;

			public Library()
			{
				books = new List<Book>();
			}

			public void AddBook(Book book)
			{
				books.Add(book);
			}

			public List<Book> GetBooks()
			{
				return books;
			}
		}
		public interface IBookStrategy
		{
			Book FindBook(string title);
		}

		public class NewGoodRegularStrategy : IBookStrategy
		{
			public virtual Book FindBook(string title)
			{
				return new Book
				{
					Title = title,
					Status = "New"
				};
			}
		}

		public class GoodNewRegularStrategy : IBookStrategy
		{
			public virtual Book FindBook(string title)
			{
				return new Book
				{
					Title = title,
					Status = "Good"
				};
			}
		}

		public class RegularGoodNewStrategy : IBookStrategy
		{
			public virtual Book FindBook(string title)
			{
				return new Book
				{
					Title = title,
					Status = "Regular"
				};
			}
		}
		public class BookFinder
		{
			public virtual Book FindBook(People people, string title)
			{
				IBookStrategy strategy = null;
				if (people is Member)
				{
					strategy = new NewGoodRegularStrategy();
				}
				else if (people is Teacher)
				{
					strategy = new GoodNewRegularStrategy();
				}
				else if (people is Student)
				{
					strategy = new RegularGoodNewStrategy();
				}
				return strategy.FindBook(title);
			}
		}

		static void Main(string[] args)
		{
			Member member = new Member();
			Teacher teacher = new Teacher();
			Student student = new Student();

			Book bookM = (new BookFinder()).FindBook(member, "Book title");
			Console.WriteLine("Book " + "<" + bookM.Title + ">" + "\nCondition: <" + bookM.Status + ">\nFor: <Member>");
			Console.Write("\n");

			Book bookT = (new BookFinder()).FindBook(member, "Book title");
			Console.WriteLine("Book " + "<" + bookT.Title + ">" + "\nCondition: <" + bookT.Status + ">\nFor: <Teacher>");
			Console.Write("\n");

			Book bookS = (new BookFinder()).FindBook(member, "Book title");
			Console.WriteLine("Book " + "<" + bookS.Title + ">" + "\nCondition: <" + bookS.Status + ">\nFor: <Student>");
			Console.Write("\n");

			Console.ReadKey();
		}
	}
}
