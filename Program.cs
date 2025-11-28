using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Proje_1_Console_Telefon_Rehberi_Uygulaması
{
	public class Program
	{
		public static void Menu()
		{
			Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz");
			Console.WriteLine("******************");
			Console.WriteLine(""
				+ "1- Yeni Numara Kaydet \n"
				+ "2- Numara Sil \n"
				+ "3- Numara Güncelle \n"
				+ "4- Rehberi Listele \n"
				+ "5- Rehberde Arama Yap");
			Console.WriteLine("******************");
		}
		static void Main(string[] args)
		{				
			Rehber rehber = new Rehber();
			bool devam = true;

			while (devam)
			{
				Menu(); // Açılışta kullanıcını menuyu görüntüler
				int input;
				//Kullanıcı menu ekranında yanlış giriş yaptığı sürece menu tekrarlanır
				while ((!int.TryParse(Console.ReadLine(), out input)) || input < 0 || input > 5)
				{ 
					Menu();
				}
				switch (input)
				{
					case 1:
						rehber.AddNo();
						break;

					case 2:
						rehber.DeleteNo();
						break;

					case 3:
						rehber.UpdateNo();
						break;

					case 4:
						rehber.List();
						break;

					case 5:
						rehber.Search();
						break;

					default:
						Console.WriteLine("Hatalı seçim yaptınız!");
						break;
				}
				Console.WriteLine("\nDevam etmek için Enter'e basın...");
				Console.ReadKey();
				Console.Clear();
			}
		}
	}

	public class Rehber
	{
		private Dictionary<string, string> numara_listesi = new Dictionary<string, string>();

		public void AddNo()
		{
			Console.WriteLine("\n--- Yeni Numara Kaydet ---");
			Console.Write("Ad: ");
			string ad = Console.ReadLine() ?? "";
			Console.Write("Numara: ");
			string numara = Console.ReadLine() ?? "";

			if (numara_listesi.ContainsKey(ad))
			{
				Console.WriteLine("Bu ad zaten kayıtlı!");
			}
			else
			{
				numara_listesi.Add(ad, numara);
				Console.WriteLine("Numara başarıyla kaydedildi!");
			}
		}

		public void DeleteNo()
		{
			Console.WriteLine("\n--- Numara Sil ---");
			Console.Write("Silinecek adı girin: ");
			string ad = Console.ReadLine() ?? "";

			if (numara_listesi.ContainsKey(ad))
			{
				numara_listesi.Remove(ad);
				Console.WriteLine("Numara başarıyla silindi!");
			}
			else
			{
				Console.WriteLine("Bu ad rehberde bulunamadı!");
			}
		}

		public void UpdateNo()
		{
			Console.WriteLine("\n--- Numara Güncelle ---");
			Console.Write("Güncellenecek adı girin: ");
			string ad = Console.ReadLine() ?? "";

			if (numara_listesi.ContainsKey(ad))
			{
				Console.Write("Yeni numara: ");
				string yeni_numara = Console.ReadLine() ?? "";
				numara_listesi[ad] = yeni_numara;
				Console.WriteLine("Numara başarıyla güncellendi!");
			}
			else
			{
				Console.WriteLine("Bu ad rehberde bulunamadı!");
			}
		}

		public void List()
		{
			Console.WriteLine("\n--- Rehberi Listele ---");
			if (numara_listesi.Count == 0)
			{
				Console.WriteLine("Rehber boş!");
			}
			else
			{
				foreach (var entry in numara_listesi)
				{
					Console.WriteLine($"{entry.Key}: {entry.Value}");
				}
			}
		}

		public void Search()
		{
			Console.WriteLine("\n--- Rehberde Arama Yap ---");
			Console.Write("Aranacak adı girin: ");
			string ad = Console.ReadLine() ?? "";

			if (numara_listesi.ContainsKey(ad))
			{
				Console.WriteLine($"Ad: {ad}");
				Console.WriteLine($"Numara: {numara_listesi[ad]}");
			}
			else
			{
				Console.WriteLine("Bu ad rehberde bulunamadı!");
			}
		}
	}
}