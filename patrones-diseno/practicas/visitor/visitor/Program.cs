using System;

namespace visitor
{
	class Program
	{
		static void Main(string[] args)
		{
			MemberProductDiscount productM = new MemberProductDiscount
			{
				Price = 2500
			};

			NormalProductDiscount productN = new NormalProductDiscount
			{
				Price = 2500
			};

			Discount discount = new Discount();
			double newPriceMember = productM.Accept(discount);
			double newPriceNormal = productN.Accept(discount);

			Console.WriteLine("New price with normal discount is " + newPriceNormal);
			Console.WriteLine("New price with member discount is " + newPriceMember);

			Console.ReadKey();
		}
		public interface IVisitable
		{
			double Accept(IVisitor visitor);
		}

		public class MemberProductDiscount : IVisitable
		{
			private double price;

			public virtual double Accept(IVisitor visitor)
			{
				return visitor.Visit(this);
			}

			public virtual double Price
			{
				get { return price; }
				set { this.price = value; }
			}
		}

		public class NormalProductDiscount : IVisitable
		{
			private double price;

			public virtual double Accept(IVisitor visitor)
			{
				return visitor.Visit(this);
			}

			public virtual double Price
			{
				get { return price; }
				set { this.price = value; }
			}
		}

		public interface IVisitor
		{
			double Visit(NormalProductDiscount normal);
			double Visit(MemberProductDiscount member);
		}
		public class Discount : IVisitor
		{
			private readonly double normalDiscount = 300;
			private readonly double memberDiscount = 1200;

			public virtual double Visit(NormalProductDiscount normal)
			{
				return (normal.Price - normalDiscount);
			}

			public virtual double Visit(MemberProductDiscount member)
			{
				return (member.Price - memberDiscount);
			}
		}
	}
}
