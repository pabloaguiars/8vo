using System;
using System.Collections.Generic;

namespace template_method
{
	class Program
	{
		static void Main(string[] args)
		{
			const int playtime = 180;

			Player p1 = new Striker("Jugador1", 200, 12, 3);
			GetRank(p1, playtime);

			Player p2 = new Striker("Jugador2", 300, 10, 10); 
			GetRank(p2, playtime);

			Player p3 = new Goalkeeper("Portero1", 300, 5, 8); 
			GetRank(p3, playtime);

			Player p4 = new Goalkeeper("Portero2", 400, 11, 6);
			GetRank(p4, playtime);

			Console.ReadKey();

		}
		// To get the data and displayed
		private static void GetRank(Player player, int playtime)
		{
			Console.WriteLine("Player: " + player.Nombre + " | Rank: " + player.rankCalculate(playtime));
		}

		/// <summary>
		/// Abstract class Player
		/// </summary>
		public abstract class Player
		{
			public class PlayerRank
			{
				// Diferents ranks
				public static readonly PlayerRank LOUSY = new PlayerRank("LOUSY", InnerEnum.LOUSY, -999, 0);
				public static readonly PlayerRank BAD = new PlayerRank("BAD", InnerEnum.BAD, 0, 10);
				public static readonly PlayerRank NORMAL = new PlayerRank("NORMAL", InnerEnum.NORMAL, 10, 20);
				public static readonly PlayerRank CRACK  = new PlayerRank("CRACK", InnerEnum.CRACK, 20, 40);
				public static readonly PlayerRank GOD = new PlayerRank("GOD", InnerEnum.GOD, 40, 999);

				private static readonly IList<PlayerRank> valueList = new List<PlayerRank>();

				/// <summary>
				/// Add the ranks
				/// </summary>
				static PlayerRank()
				{
					valueList.Add(LOUSY);
					valueList.Add(BAD);
					valueList.Add(NORMAL);
					valueList.Add(CRACK);
					valueList.Add(GOD);
				}

				// RANKS ENUM
				public enum InnerEnum
				{
					LOUSY, BAD, NORMAL, CRACK, GOD
				}

				public readonly InnerEnum innerEnumValue;
				private readonly string nameValue;
				private readonly int ordinalValue;
				private static int nextOrdinal = 0;
				internal int valMin;
				internal int valMax;

				/// <summary>
				/// Constructor
				/// </summary>
				/// <param name="name"></param>
				/// <param name="innerEnum"></param>
				/// <param name="valMin"></param>
				/// <param name="valMax"></param>
				internal PlayerRank(string name, InnerEnum innerEnum, int valMin, int valMax)
				{
					this.valMin = valMin;
					this.valMax = valMax;

					nameValue = name;
					ordinalValue = nextOrdinal++;
					innerEnumValue = innerEnum;
				}

				/// <summary>
				/// Player is in range
				/// </summary>
				/// <param name="points"></param>
				/// <returns></returns>
				internal bool IsInRange(float points)
				{
					return points >= valMin && points < valMax;
				}

				/// <summary>
				/// Get ranks
				/// </summary>
				/// <returns></returns>
				public static IList<PlayerRank> Values()
				{
					return valueList;
				}
				
				/// <summary>
				/// Get ordinal
				/// </summary>
				/// <returns></returns>
				public int Ordinal()
				{
					return ordinalValue;
				}

				/// <summary>
				/// Get name
				/// </summary>
				/// <returns></returns>
				public override string ToString()
				{
					return nameValue;
				}

				/// <summary>
				/// Get player rank.
				/// </summary>
				/// <param name="name"></param>
				/// <returns></returns>
				public static PlayerRank ValueOf(string name)
				{
					foreach (PlayerRank enumInstance in PlayerRank.valueList)
					{
						if (enumInstance.nameValue == name)
						{
							return enumInstance;
						}
					}
					throw new System.ArgumentException(name);
				}
			}

			// Player attributes
			protected internal readonly string names;
			protected internal readonly int playtime;
			protected internal readonly int salary;
			private const int minutesMatch = 90;
			
			// Get info from the player
			public Player(string names, int playtime, int salary)
			{
				this.names = names;
				this.playtime = playtime;
				this.salary = salary;
			}

			// TEMPLATE METHOD
			public virtual PlayerRank rankCalculate(int totalTeamPlaytimeTemp)
			{
				if (lessThen20(totalTeamPlaytimeTemp))
				{
					return PlayerRank.LOUSY;
				}
				float points = calculateObjectives() - penaltySalary;
				return rankByPoints(points);
			}

			/// <summary>
			/// Get time
			/// </summary>
			/// <param name="totalTeamPlaytimeTemp"></param>
			/// <returns></returns>
			private bool lessThen20(int totalTeamPlaytimeTemp)
			{
				return playtime < totalTeamPlaytimeTemp * 0.2;
			}

			public abstract float calculateObjectives();

			public abstract float penaltySalary { get; }

			/// <summary>
			/// Get rank by points
			/// </summary>
			/// <param name="points"></param>
			/// <returns></returns>
			private PlayerRank rankByPoints(float points)
			{
				foreach (PlayerRank ranking in PlayerRank.Values())
				{
					if (ranking.IsInRange(points))
					{
						return ranking;
					}
				}
				throw new System.ArgumentException("Cant calculate points => " + points);
			}

			/// <summary>
			/// Get matches played
			/// </summary>
			protected internal virtual float matchesPlayed
			{
				get{return (float)this.playtime / minutesMatch;}
			}

			/// <summary>
			/// Get name
			/// </summary>
			public virtual string Nombre
			{
				get{return this.names; }
			}
		}

		/// <summary>
		/// Striker class
		/// </summary>
		public class Striker : Player
		{
			private readonly int matchGoals;
			public Striker(string name, int playtime, int salary, int matchGoals) : base(name, playtime, salary)
			{
				this.matchGoals = matchGoals;
			}

			public override float calculateObjectives()
			{
				return 30 * (matchGoals / base.matchesPlayed);
			}

			public override float penaltySalary
			{
				get
				{
					return (float)(salary * 0.1);
				}
			}
		}
		
		/// <summary>
		/// Goalkeeper class
		/// </summary>
		public class Goalkeeper : Player
		{

			private readonly int matchGoals;
			public Goalkeeper(string name, int playtime, int salary, int matchGoals) : base(name, playtime, salary)
			{
				this.matchGoals = matchGoals;
			}

			public override float calculateObjectives()
			{
				return 50 - (30 * matchGoalsEachMatch());
			}

			private float matchGoalsEachMatch()
			{
				return matchGoals / base.matchesPlayed;
			}

			public override float penaltySalary
			{
				get
				{
					return (float)(salary * 0.08);
				}
			}
		}
	}
}
