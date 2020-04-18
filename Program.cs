using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hm9
{
	class Program
	{
		static void Main(string[] args)
		{
			Menu startMenu = new Menu();
		}
	}
	public class Menu
	{
		private List<Card> CardCollection = new List<Card>();
		private List<User> UserCollection = new List<User>();
		public Menu()
		{

			while (true)
			{
				int selector;
				Console.WriteLine("------------------------------------------------------------\n" +
					"1. Создать карточку \n" +
					"2. Изменить карточку\n" +
					"3. Сменить статус карточки\n" +
					"4. Сменить исполнителя карточки\n" +
					"5. Показать все карточки исполнителя\n" +
					"6. Показать все карточки по статусу\n" +
					"------------------------------------------------------------\n");
				selector = Convert.ToInt32(Console.ReadLine());
				switch (selector)
				{
					case 1:
						{
							Card card = new Card();
							Console.WriteLine("Введите название карточки: ");
							card.Title = Console.ReadLine();
							Console.WriteLine("Введите имя исполнителя: ");
							User user = new User();
							user.Name = Console.ReadLine();
							card.Executer = user.Name;
							Console.WriteLine("Введите информацию: ");
							card.Data = Console.ReadLine();
							card.Status = Board.ToDo;
							UserCollection.Add(user);
							CardCollection.Add(card);
							break;
						}

					case 2:
						{
							Console.WriteLine("Введите название карточки, которую хотите изменить: ");
							string ttl = Console.ReadLine();
							foreach (var c in CardCollection)
							{
								if (c.Title == ttl)
								{
									Console.WriteLine("Измените текст");
									c.Data = Console.ReadLine();
								}
								else
								{
									Console.WriteLine("Такой карточки не существует");
								}
							}
							break;
						}
					case 3:
						{
							Console.WriteLine("Введите название карточки статус которой, хотите изменить: ");
							string ttl = Console.ReadLine();
							Card.ChangeBoard(ttl, CardCollection);
							break;
						}
					case 4:
						{
							Console.WriteLine("Введите название карточки исполнителя которой, хотите изменить: ");
							string ttl = Console.ReadLine();
							Card.ChangeExecuter(ttl, CardCollection, UserCollection);
							break;
						}
					case 5:
						Console.WriteLine("Введите имя исполнителя, чтобы вывести его карточки");
						string name = Console.ReadLine();
						Card.ShowCards(CardCollection, name);
						break;
					case 6:
						Console.WriteLine("Выберите статус: \n" +
						"0-ToDO\n" +
						"1-OnTeacher\n" +
						"2-OnStudent\n" +
						"3-Done\n");
						int st = Convert.ToInt32(Console.ReadLine());
						Card.ShowStatus(CardCollection, (Board)st);
						break;
				}
			}

		}
		public void CreateCard()
		{ }


	}
	public class Card
	{
		public string Title { get; set; }
		public string Executer { get; set; }
		public string Data { get; set; }
		public Board Status { get; set; }
		public static void ChangeBoard(string ttl, List<Card> CrdCllctn)
		{
			foreach (var c in CrdCllctn)
			{
				if (c.Title == ttl)
				{
					Console.WriteLine("Выберите новый статус: \n" +
						"0-ToDO\n" +
						"1-OnTeacher\n" +
						"2-OnStudent\n" +
						"3-Done\n");
					c.Status = (Board)Convert.ToInt32(Console.ReadLine());
				}
				else
				{
					Console.WriteLine("Такой карточки не существует");
				}
			}
		}
		public static void ChangeExecuter(string ttl, List<Card> CrdCllctn, List<User> usr)
		{
			foreach (var c in CrdCllctn)
			{
				if (c.Title == ttl)
				{
					Console.WriteLine("Введите имя нового исполнителя: ");
					string Exe = Console.ReadLine();
					foreach (var n in usr)
					{
						if (n.Name == Exe)
						{
							c.Executer = n.Name;
						}
						else
						{
							User user = new User();
							user.Name = Exe;
							usr.Add(user);
						}
					}
				}
				else
				{
					Console.WriteLine("Такой карточки не существует");
				}
			}

		}
		public static void ShowCards(List<Card> cards, string nm)
		{
			Console.WriteLine("|     Title     |     Executer     |     Data     |     Status     |");
			foreach (var c in cards)
			{
				if (c.Executer == nm)
				{
					Console.WriteLine($"|     {c.Title}     |     {c.Executer}     |     {c.Data}     |     {c.Status}     |");
				}
			}
		}
		public static void ShowStatus(List<Card> cards, Board st)
		{
			Console.WriteLine("|     Title     |     Executer     |     Data     |     Status     |");
			foreach (var c in cards)
			{
				if (c.Status == st)
				{
					Console.WriteLine($"|     {c.Title}     |     {c.Executer}     |     {c.Data}     |     {c.Status}     |");
				}
			}
		}

	}
	public class User
	{
		public string Name { get; set; }

	}

	public enum Board
	{
		ToDo,
		OnTeacher,
		OnStudent,
		Done
	}
}
