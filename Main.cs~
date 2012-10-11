using System;

namespace proje1
{
	class Otel
	{
		
		public string otel_isimleri;
		public int kontenjan;
	
		public Otel() {}
		public void bilgi_al()
		{
			Console.WriteLine("Otel adını giriniz:");
			otel_isimleri=Console.ReadLine();
			Console.WriteLine("Kontenjanı giriniz:");
			kontenjan=Convert.ToInt32(Console.ReadLine ());
		}	
		
	}	
		
	class MainClass
	{		
		public static void Main (string[] args)
		{
			otel_bilgisi_alma();
			
		}
		static void otel_bilgisi_alma()
		{
			Console.WriteLine("Otel sayisini giriniz:");
			int sayi=Convert.ToInt32(Console.ReadLine());
			
			Otel[] bir_otel=new Otel[sayi];
			for(int i=0; i<sayi; i++)
			{   
				bir_otel[i]=new Otel();
				bir_otel[i].bilgi_al();
			}
		}
	}
}
