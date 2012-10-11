using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace proje1
{

    class Otel
    {

        public string otel_isimleri;
        public int kontenjan;

        public Otel() { }
        public void bilgi_al()
        {
            Console.WriteLine("Otel adını giriniz:");
            otel_isimleri = Console.ReadLine();
            Console.WriteLine("Kontenjanı giriniz:");
            kontenjan = Convert.ToInt32(Console.ReadLine());
        }

    }

    class Konuk
    {
        public string ad, soyad, dil;
		public Konuk() {}
        public void yazdır()
        {
            Console.WriteLine("Adı:" + ad + "\tSoyadı:" + soyad + "\tDili:" + dil);
        }
    }

    class Islem
    {
        public int konuk_say;

        public string[,] isim_matrisi;
        public string[] dil_dizisi;



        public Islem(int konuk_sayısı, string[,] matris_isim, string[] dizi_dil)
        { konuk_say = konuk_sayısı; isim_matrisi = matris_isim; dil_dizisi = dizi_dil; }

        public void nesne_dizi_olusturma()
        {
            Konuk[] konuklar = new Konuk[konuk_say];
            Random random_sayi1 = new Random((int)DateTime.Now.Ticks);
            Random random_sayi2 = new Random((int)DateTime.Now.Ticks);
            Random random_sayi3 = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < konuk_say; i++)
            {

                konuklar[i] = new Konuk();

                int a = random_sayi1.Next(20);
                int b = random_sayi2.Next(20);
                int c = random_sayi3.Next(6);

                konuklar[i].ad = isim_matrisi[0, a];
                konuklar[i].soyad = isim_matrisi[1, b];
                konuklar[i].dil = dil_dizisi[c];
            }
        }
    }


	

	
		
	class MainClass
	{		
		public static void Main (string[] args)
		{
			string[,] ad_soyad={{"ibrahim","vladimir","emre","johnny","mona","sherlock","bruce","michael","padme","mace","christopher","frodo","omer","obiwan","anakin","john","morgan","david","lee","christian"},
                {"uzum","dost","lenin","vitamin","jin","oztekin","cakir","depp","yong","skywalker","kenobi","wayne","windu","baggins","amidala","corleone","holmes","connor","lisa","freeman"}};
            string[] yabanci_dil = { "TR", "ENG", "GER", "FRE", "JAP", "CHN", "RUS" };

			otel_bilgisi_alma();
			Islem bir_islem=new Islem(konuk_sayisi_alma(),ad_soyad,yabanci_dil);
			
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
		static int konuk_sayisi_alma()
		{
			Console.Write("Konuk sayısını giriniz:");
			int konuk_say=Convert.ToInt32(Console.ReadLine());
			return konuk_say;
		}
	}

}

