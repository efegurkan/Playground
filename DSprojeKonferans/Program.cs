using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace proje1
{

    class Otel
    {

        public string otel_isim;
        public int kontenjan, kalan;
        public double yuzde;
        public ArrayList kalanlar = new ArrayList();

        public Otel() { kalan = 0; yuzde = 0; }
        public void bilgi_al()
        {
            Console.WriteLine("Otel adını giriniz:");
            otel_isim = Console.ReadLine();
            Console.WriteLine("Kontenjanı giriniz:");
            kontenjan = Convert.ToInt32(Console.ReadLine());
        }

    }

    class Konuk
    {
        public string ad, soyad, dil;
        public Konuk() { }
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

        public Konuk[] konuk_dizi_olusturma()
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
            return konuklar;
        }
    }






    class MainClass
    {
        public static void Main(string[] args)
        {
            string[,] ad_soyad ={{"ibrahim","vladimir","emre","johnny","mona","sherlock","bruce","michael","padme","mace","christopher","frodo","omer","obiwan","anakin","john","morgan","david","lee","christian"},
                {"uzum","dost","lenin","vitamin","jin","oztekin","cakir","depp","yong","skywalker","kenobi","wayne","windu","baggins","amidala","corleone","holmes","connor","lisa","freeman"}};
            string[] yabanci_dil = { "TR", "ENG", "GER", "FRE", "JAP", "CHN", "RUS" };


            Console.WriteLine("Otel sayisini giriniz:");
            int otelsayi = Convert.ToInt32(Console.ReadLine());

            Otel[] otelList = otel_bilgisi_alma(otelsayi);

            int konuk_say = konuk_sayisi_alma();
            Islem bir_islem = new Islem(konuk_say, ad_soyad, yabanci_dil);

            otel_yerleştirme(otelList, bir_islem.konuk_dizi_olusturma(), konuk_say, otelsayi);
        }
        static void otel_yerleştirme(Otel[] bir_otel, Konuk[] konuklist, int konuksayisi, int otelSayi)
        {
            int toplamKontenjan = 0, dolasimSayaci = 0, ilkdeger = konuksayisi;
            double bolunecekOran, yerlesecek;

            for (int i = 0; i < otelSayi; ++i)
            {
                toplamKontenjan += bir_otel[i].kontenjan;
            }
            bolunecekOran = (double)toplamKontenjan / konuksayisi;

            for (int i = 0; i < otelSayi; ++i)
            {
                yerlesecek = Math.Round((double)bir_otel[i].kontenjan / bolunecekOran);
                for (int j = dolasimSayaci; j < yerlesecek; ++j)
                {
                    bir_otel[i].kalanlar.Add(konuklist[j]);
                    ++bir_otel[i].kalan;
                    ++dolasimSayaci;
                    --konuksayisi;
                }
                bir_otel[i].yuzde = (double)bir_otel[i].kalan / (double)bir_otel[i].kontenjan;
            }
            if (konuksayisi > 0)
            {
                int min = 100, index = 0;
                while (konuksayisi != 0)
                {
                    for (int j = 0; j < otelSayi; ++j)
                    {
                        if (bir_otel[j].yuzde < min && bir_otel[j].kontenjan - bir_otel[j].kalan != 0)
                            index = j;
                        else if (bir_otel[j].yuzde == min && (bir_otel[j].kontenjan - bir_otel[j].kalan) < (bir_otel[index].kontenjan - bir_otel[index].kalan))
                        {
                            index = j;
                        }
                        bir_otel[index].kalanlar.Add(konuklist[ilkdeger - konuksayisi]);
                        ++bir_otel[index].kalan;
                        --konuksayisi;
                        ++dolasimSayaci;
                        bir_otel[index].yuzde = (double)bir_otel[index].kalan / (double)bir_otel[index].kontenjan;
                    }

                }
            }
        }

        static void dilKontrol(Konuk[] konukList)
        {
            int[] kontrol = {0,0,0,0,0,0,0};
            string[] arama = { "TR", "ENG", "GER", "FRE", "JAP", "CHN", "RUS" };
            ArrayList tek = new ArrayList();
            Konuk yazdir = new Konuk();

            for(int i=0; i<konukList.Length; i++)//Konuk tek kalma için listesi kontrol edilir
            {
                
                switch(konukList[i].dil){
                    case "TR":
                        kontrol[0]++;
                        break;
                    case "ENG":
                        kontrol[1]++;
                        break;
                    case "GER":
                        kontrol[2]++;
                        break;
                    case "FRE":
                        kontrol[3]++;
                        break;
                    case "JAP":
                        kontrol[4]++;
                        break;
                    case "CHN":
                        kontrol[5]++;
                        break;
                    case "RUS":
                        kontrol[6]++;
                        break;
            }
                foreach (int j in kontrol)
                {
                    if ( kontrol[j] == 1 )
                    {
                        for (int k = 0; k < konukList.Length; k++)
                        {
                            if (arama[j].Equals(konukList[k].dil) == true)//yalnız kalacakları belirle
                                tek.Add(konukList[k]);
                        }
                    }
                }
            }
            if (tek.Count != 0)
            {
                Console.WriteLine("Aşağıda listelenen kişiler aynı dilde tek katılımcı olduğundan mecburen yalnız kalacaklardır!");
                for (int i = 0; i < tek.Count; i++)
                {
                    yazdir = (Konuk)tek[i];
                    yazdir.yazdır();
                }
                Console.WriteLine("Devam etmek için bir tuşa basın.");
                Console.ReadKey();
            }
            //return tek;

        }

        static Otel[] otel_bilgisi_alma(int sayi)
        {


            Otel[] bir_otel = new Otel[sayi];
            for (int i = 0; i < sayi; i++)
            {
                bir_otel[i] = new Otel();
                bir_otel[i].bilgi_al();
            }
            return bir_otel;
        }
        static int konuk_sayisi_alma()
        {
            Console.Write("Konuk sayısını giriniz:");
            int konuk_say = Convert.ToInt32(Console.ReadLine());
            return konuk_say;
        }
    }

}

