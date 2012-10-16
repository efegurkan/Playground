using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proje1
{

    class Otel
    {
        public int kontenjan, kalan;
        public int[] kontrol = { 0, 0, 0, 0, 0, 0, 0 };
        public double yuzde;
        public string otel_isim;
        public ArrayList kalanlar = new ArrayList();

        public Otel() { kalan = 0; yuzde = 0; }

        public void bilgi_al(int i)
        {
            Console.WriteLine((i+1)+". otelin adını giriniz:");
            otel_isim = Console.ReadLine();
            Console.WriteLine("\n"+otel_isim+" Oteli'nin kontenjanını giriniz:");
            kontenjan = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
        }
    }

    class Konuk
    {
        public int kaldigiIndex;
        public string ad, soyad, dil;
        public Konuk() { }
        public void yazdır()
        {
            Console.WriteLine(String.Format("Adı:{0,-15}Soyadı:{1,-15}Dili:{2,-10}",ad,soyad,dil));
        }
    }

    class Islem
    {
        public int konuk_say;
        public string[,] isim_matrisi;
        public string[] dil_dizisi;

        public Islem(int konuk_sayısı, string[,] matris_isim, string[] dizi_dil)//Constructor
        { konuk_say = konuk_sayısı; isim_matrisi = matris_isim; dil_dizisi = dizi_dil; }

        public Konuk[] konuk_dizi_olusturma()
        {
            Konuk[] konuklar = new Konuk[konuk_say];
            Random random_sayi1 = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < konuk_say; i++)
            {
                konuklar[i] = new Konuk();

                int a = random_sayi1.Next(20);
                int b = random_sayi1.Next(20);
                int c = random_sayi1.Next(7);

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

            Console.WriteLine("\tKonferans Otel Yerleştirme");

            hakkinda();
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\tKonferans Otel Yerleştirme");
            Console.WriteLine("");

            Console.WriteLine("Otel sayısını giriniz:");
            int otelsayi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Otel[] otelList = otel_bilgisi_alma(otelsayi);

            int konuk_say = konuk_sayisi_alma(otelList);
            Islem bir_islem = new Islem(konuk_say, ad_soyad, yabanci_dil);
            
            Konuk[] konukList=bir_islem.konuk_dizi_olusturma();
            otel_yerleştirme(otelList, konukList , konuk_say, otelsayi);
            ArrayList tek = new ArrayList();
            
            tek = dilKontrol(konukList);
            transferEt(otelList, konukList, tek);

            otelBazındaKonukListe(otelList);
            Console.ReadKey();
        }

        static void hakkinda()
        {
            Console.WriteLine("Yazarlar: \n Efe Gürkan Yalaman - efeyalaman@gmail.com "+
                "\n İbrahim Üzüm - ibrahimuzum92@yahoo.com.tr \n Burak Emre Dost - burakemredost@gmail.com"+
                "\n Doğukan Sever - dogukansever@hotmail.com.tr\n");
            Console.WriteLine("Lisans bilgileri:\n GNU GPL v2.1");
        }

        //static int menu()
        //{
        //    Console.WriteLine("");
        //    int secim = Convert.ToInt32(Console.ReadLine());
        //    return secim;

        //}
        static void otel_yerleştirme(Otel[] bir_otel, Konuk[] konuklist, int konuksayisi, int otelSayi)
        {
            int toplamKontenjan = 0, dolasimSayaci = 0, ilkdeger = konuksayisi, gecici = 0;
            double bolunecekOran, yerlesecek;

            toplamKontenjan = kontenjanAl(bir_otel);
            bolunecekOran = (double)toplamKontenjan / konuksayisi;

            for (int i = 0; i < otelSayi; ++i)
            {
                yerlesecek = Math.Round((double)bir_otel[i].kontenjan / bolunecekOran);
                for (int j = dolasimSayaci; j < yerlesecek + gecici; ++j)
                {
                    bir_otel[i].kalanlar.Add(konuklist[j]);
                    konuklist[j].kaldigiIndex = i;
                    ++bir_otel[i].kontrol[anadilIndex(konuklist[j].dil)];
                    ++bir_otel[i].kalan;
                    ++dolasimSayaci;
                    --konuksayisi;
                }
                gecici = dolasimSayaci;
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
                        if (konuksayisi == 0)
                            break;
                    }
                }
            }
        }

        static int anadilIndex(string dil)
        {
            int donus = -1;
            switch (dil)
            {
                case "TR":
                    donus = 0;
                    break;
                case "ENG":
                    donus = 1;
                    break;
                case "GER":
                    donus = 2;
                    break;
                case "FRE":
                    donus = 3;
                    break;
                case "JAP":
                    donus = 4;
                    break;
                case "CHN":
                    donus = 5;
                    break;
                case "RUS":
                    donus = 6;
                    break;
            }
            return donus;
        }

        static void otelBazındaKonukListe(Otel[] otelList)
        {
            Konuk yazdir = new Konuk();
            for (int i = 0; i < otelList.Length; i++)
            {
                Console.WriteLine(otelList[i].otel_isim + " Oteli Konuk Listesi:\n");
                for (int j = 0; j < otelList[i].kalanlar.Count; j++)
                {
                    yazdir = (Konuk)otelList[i].kalanlar[j];
                    yazdir.yazdır();
                }
                Console.WriteLine();
            }
        }

        static ArrayList transferListesiAl(Otel[] otelList, ArrayList tek)
        {
            Konuk konuk = new Konuk();
            ArrayList transferList = new ArrayList();
            for (int i = 0; i < otelList.Length; i++)//otelleri dolaş
            {
                for (int j = 0; j < 7; j++ )//otelde anadil kontrol listesini dolaş
                {
                    if (otelList[i].kontrol[j] == 1)//yalnız kalan var mı?
                    {
                        for (int k = 0; k < otelList[i].kalanlar.Count; k++)//varsa otelde kalanları dolaş
                        {
                            konuk = (Konuk)otelList[i].kalanlar[k];
                            if (j == anadilIndex(konuk.dil) && tek.Contains(konuk) == false)//j ile belirlenen yalnız kalan dil tutuyorsa ve yalnız kalmak zorunda değilse
                            {
                                transferList.Add(otelList[i].kalanlar[k]);//transfer listesine ekle
                            }
                        }
                    }
                }
            }
            return transferList;//transfer listesini döndür
        }

        static ArrayList dilKontrol(Konuk[] konukList)
        {
            int[] kontrol = { 0, 0, 0, 0, 0, 0, 0 };
            string[] arama = { "TR", "ENG", "GER", "FRE", "JAP", "CHN", "RUS" };
            ArrayList tek = new ArrayList();
            Konuk yazdir = new Konuk();

            for (int i = 0; i < konukList.Length; i++)//Konuk tek kalma için listesi kontrol edilir
            {
                ++kontrol[anadilIndex(konukList[i].dil)];
            }
            for (int j = 0; j < 7;j++ )
            {
                if (kontrol[j] == 1)
                {
                    for (int k = 0; k < konukList.Length; k++)
                    {
                        if (arama[j].Equals(konukList[k].dil) == true)//yalnız kalacakları belirle
                            tek.Add(konukList[k]);
                    }
                }
            }
            

            if (tek.Count != 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Aşağıda listelenen kişiler aynı dilde tek katılımcı olduğundan mecburen yalnız kalacaklardır!");
                Console.ResetColor();
                for (int i = 0; i < tek.Count; i++)
                {
                    yazdir = (Konuk)tek[i];
                    yazdir.yazdır();
                }
                Console.WriteLine("\nDevam etmek için bir tuşa basın.");
                Console.ReadKey();
            }
            Console.Clear();
            return tek;
        }

        static int kontenjanAl(Otel[] otelList)
        {
            int toplamKont = 0;

            for (int i = 0; i < otelList.Length; i++)
                toplamKont += otelList[i].kontenjan;

            return toplamKont;
        }

        static void transferEt(Otel[] otelList, Konuk[] konukList, ArrayList tek)
        {
            ArrayList transfer = new ArrayList();
            Konuk konukNesne = new Konuk();
            Konuk konukKarsilastirma = new Konuk();
            int toplamKont = kontenjanAl(otelList);
            transfer = transferListesiAl(otelList, tek);

            if (konukList.Length != toplamKont)
            {
                for (int i=0; i < transfer.Count; i++ )
                {
                    konukNesne = (Konuk)transfer[i];
                    for (int j = 0; j + 1 < transfer.Count; j++)
                    {
                        konukKarsilastirma = (Konuk)transfer[j + 1];
                        if (konukKarsilastirma.Equals(konukNesne) == true && otelList[konukNesne.kaldigiIndex].kontenjan - otelList[konukNesne.kaldigiIndex].kalan != 0)
                        {
                            otelList[konukNesne.kaldigiIndex].kalanlar.Add(konukKarsilastirma);
                            ++otelList[konukNesne.kaldigiIndex].kontrol[anadilIndex(konukKarsilastirma.dil)];
                            otelList[konukKarsilastirma.kaldigiIndex].kalanlar.Remove(konukKarsilastirma);
                            --otelList[konukKarsilastirma.kaldigiIndex].kontrol[anadilIndex(konukKarsilastirma.dil)];
                            konukKarsilastirma.kaldigiIndex = konukNesne.kaldigiIndex;
                            transfer.Remove(konukNesne);
                            transfer.Remove(konukKarsilastirma);
                            break;
                        }
                        else if (otelList[konukKarsilastirma.kaldigiIndex].kontenjan - otelList[konukKarsilastirma.kaldigiIndex].kalan != 0)
                        {
                            otelList[konukKarsilastirma.kaldigiIndex].kalanlar.Add(konukNesne);
                            ++otelList[konukKarsilastirma.kaldigiIndex].kontrol[anadilIndex(konukNesne.dil)];
                            otelList[konukNesne.kaldigiIndex].kalanlar.Remove(konukNesne);
                            --otelList[konukNesne.kaldigiIndex].kontrol[anadilIndex(konukNesne.dil)];
                            konukNesne.kaldigiIndex = konukKarsilastirma.kaldigiIndex;
                            transfer.Remove(konukNesne);
                            transfer.Remove(konukKarsilastirma);
                            break;
                        }
                    }
                }
            }
        }

        static Otel[] otel_bilgisi_alma(int sayi)
        {
            Otel[] bir_otel = new Otel[sayi];
            for (int i = 0; i < sayi; i++)
            {
                bir_otel[i] = new Otel();
                bir_otel[i].bilgi_al(i);
            }
            return bir_otel;
        }

        static int konuk_sayisi_alma(Otel[] otelList)
        {
            int kontenjan = kontenjanAl(otelList);
            int konuk_say = 0;
            bool flag = true;
            do
            {
                Console.Write("Konuk sayısını giriniz:");
                konuk_say = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (konuk_say > kontenjan)
                {
                    flag = false;
                    Console.WriteLine("Konuk sayısı kontenjandan fazla! Konuk sayısını tekrar girin.");
                }
                else
                    flag = true;
            } while (!flag);
            return konuk_say;
        }
    }

}

