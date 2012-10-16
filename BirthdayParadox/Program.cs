using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BirTakvim
{
    public int[][] kalendar;
    public int ç_say;
}


namespace Proje2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int secim;
            int[][] takvim = new int[12][];//Birthday paradoxta kullanılacak takvim
            takvim[0] = new int[31];
            takvim[1] = new int[28];
            takvim[2] = new int[31];
            takvim[3] = new int[30];
            takvim[4] = new int[31];
            takvim[5] = new int[30];
            takvim[6] = new int[31];
            takvim[7] = new int[31];
            takvim[8] = new int[30];
            takvim[9] = new int[31];
            takvim[10] = new int[30];
            takvim[11] = new int[31];
            takvim_sıfırla(takvim);

            int[][] takvim2 = new int[12][];//d seçeneğindeki problem için kullanılacak takvim
            takvim2[0] = new int[31];
            takvim2[1] = new int[28];
            takvim2[2] = new int[31];
            takvim2[3] = new int[30];
            takvim2[4] = new int[31];
            takvim2[5] = new int[30];
            takvim2[6] = new int[31];
            takvim2[7] = new int[31];
            takvim2[8] = new int[30];
            takvim2[9] = new int[31];
            takvim2[10] = new int[30];
            takvim2[11] = new int[31];
            takvim_sıfırla(takvim2);

            int[][] takvim3 = new int[12][];//d seçeneğindeki problem için kullanılacak takvim
            takvim3[0] = new int[31];
            takvim3[1] = new int[28];
            takvim3[2] = new int[31];
            takvim3[3] = new int[30];
            takvim3[4] = new int[31];
            takvim3[5] = new int[30];
            takvim3[6] = new int[31];
            takvim3[7] = new int[31];
            takvim3[8] = new int[30];
            takvim3[9] = new int[31];
            takvim3[10] = new int[30];
            takvim3[11] = new int[31];
            takvim_sıfırla(takvim3);

            int[][] takvim4 = new int[12][];//d seçeneğindeki problem için kullanılacak takvim
            takvim4[0] = new int[31];
            takvim4[1] = new int[28];
            takvim4[2] = new int[31];
            takvim4[3] = new int[30];
            takvim4[4] = new int[31];
            takvim4[5] = new int[30];
            takvim4[6] = new int[31];
            takvim4[7] = new int[31];
            takvim4[8] = new int[30];
            takvim4[9] = new int[31];
            takvim4[10] = new int[30];
            takvim4[11] = new int[31];
            takvim_sıfırla(takvim4);

            secim = menu();

            while (secim > 0 && secim < 4)
            {
                switch (secim)
                {
                    case 1: coklu_dogum_gunu(takvim);
                        break;

                    case 2: n_degerleri_icin_uretim(takvim);
                        break;

                    case 3: ozel_coklu_dogumGunu_uretme(takvim2, takvim3, takvim4);
                        break;

                }
                secim = menu();
            }


            Console.ReadKey();
        }

        static int menu()
        {
            int a;
            Console.WriteLine("\n");
            Console.WriteLine("1. Kullanıcıdan alınacak n sayısı icin doğum günü üretme");
            Console.WriteLine("2. n=5,10,50,100 ve 500 değerleri için deney sonuçları");
            Console.WriteLine("3. 93,94 ve 95 doğumlular için doğum günü çakışması bulma");
            Console.WriteLine("4. Çıkış");
            a = Convert.ToInt32(Console.ReadLine());
            return a;
        }

        static void takvim_sıfırla(int[][] t)
        {
            for (int i = 0; i < t.Length; i++)//t vektörünün elemanları 0'a atanır
            {
                for (int j = 0; j < t[i].Length; j++)
                {
                    t[i][j] = 0;
                }
            }
        }

        static int[] dogum_gunu_uret(Random a)//Birey için doğum günü ve ayı üretir
        {
            int[] dizi = new int[2];
            int rastgele_dogum_gunu = a.Next(0, 31);
            dizi[0] = rastgele_dogum_gunu;
            int rastgele_dogum_ayi = a.Next(0, 12);
            dizi[1] = rastgele_dogum_ayi;
            return dizi;
        }

        static int gun_degistir(Random d)//Doğum tarihindeki günü değiştirir
        {
            int c = d.Next(0, 31);
            return c;
        }

        static void coklu_dogum_gunu(int[][] calendar)//Kullanıcıdan allınacak n birey sayısı için rastgele doğum günleri üretir
        {
            Console.WriteLine("Doğum günü sayısını giriniz:");//Birey sayısı inputu
            int sayi = Convert.ToInt32(Console.ReadLine());
            int[] array;

            //Random tipinden x ve y değişkenlerinin üretilmesi
            Random x = new Random();
            Random y = new Random();


            for (int i = 0; i < sayi; i++)
            {
                array = dogum_gunu_uret(x);

                if (array[1] == 1)//Ayın şubat olması durumunda gün 27'den büyükse değişiklik yapılır
                {

                    while (array[0] > 27)
                    {
                        array[0] = gun_degistir(y);

                    }
                }
                if (array[1] == 3 || array[1] == 5 || array[1] == 8 || array[1] == 10)//Ay 30 gün cekiyor ise
                {

                    while (array[0] > 29)
                    {

                        array[0] = gun_degistir(y);

                    }
                }

                calendar[array[1]][array[0]] += 1;//takvimin seçilen gün ve aya denk gelen kısmının değeri 1 artırılır


            }

            takvimYaz(calendar);
            Console.WriteLine("\nÇakışma sayısı:" + cakışma_say_bul(calendar));

        }

        static void takvimYaz(int[][] calender)//Takvimi düzenli bir şekilde yazdırır
        {
            string[] ay_listesi = { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };
            Console.WriteLine("\n---------------------------------------------------------------------------------\n");
            for (int i = 0; i < 12; i++)
            {
                Console.Write(ay_listesi[i] + ": ");
                for (int j = 0; j < calender[i].Length; j++)
                {
                    Console.Write(calender[i][j] + " ");
                }
                Console.WriteLine();
            }

        }

        static void ozel_coklu_dogumGunu_uretme(int[][] calendar2, int[][] calendar3, int[][] calendar4)//D seçeneğindeki problem için kullanılan metotturqqqqqqqqqqqq
        {
            int number = 120;
            int[] array2;
            int cakışma93;
            int cakışma94;
            int cakışma95;
            int[][] takvim_93 = calendar2;
            int[][] takvim_94 = calendar3;
            int[][] takvim_95 = calendar4;
            int k = 0;
            double çakışma_toplamı1 = 0;
            double çakışma_toplamı2 = 0;
            double çakışma_toplamı3 = 0;
            string karar = "e";

            Random r = new Random();

            while (k < 10 && (karar.Equals("e") || (karar.Equals("E"))))
            {


                for (int i = 0; i < number; i++)
                {
                    array2 = gun_ay_yil_uret(r);

                    if (array2[1] == 1)//Ay şubat ise gün 27'den büyük olması durumunda değişikliğe uğrar
                    {

                        while (array2[0] > 27)
                        {
                            array2[0] = gun_degistir(r);

                        }
                    }
                    if (array2[1] == 3 || array2[1] == 5 || array2[1] == 8 || array2[1] == 10)//Ay 30 gün cekiyor ise
                    {

                        while (array2[0] > 29)
                        {

                            array2[0] = gun_degistir(r);

                        }
                    }

                    if (array2[2] == 0)//Yıl değeri 0 ise 1993'e denk gelir ve 93 takviminde artırma işlemi yapılır
                    {
                        takvim_93[array2[1]][array2[0]] += 1;
                    }
                    else
                    {
                        if (array2[2] == 1)//Yıl değeri 1 ise 1994'e denk gelir ve 94 takviminde artırma işlemi yapılır
                        {
                            takvim_94[array2[1]][array2[0]] += 1;
                        }
                        else //Yıl değeri 2 ise 1995'e denk gelir ve 95 takviminde artırma işlemi yapılır
                        {

                            takvim_95[array2[1]][array2[0]] += 1;
                        }
                    }

                }

                cakışma93 = cakışma_say_bul(takvim_93);
                takvimYaz(takvim_93);
                Console.WriteLine("\n 1993 yılının çakışma sayısı:" + cakışma93);

                cakışma94 = cakışma_say_bul(takvim_94);
                takvimYaz(takvim_94);
                Console.WriteLine("\n 1994 yılının çakışma sayısı:" + cakışma94);

                cakışma95 = cakışma_say_bul(takvim_95);
                takvimYaz(takvim_95);
                Console.WriteLine("\n 1995 yılının çakışma sayısı:" + cakışma95);

                k += 1;
                if (k != 10)
                {
                    Console.WriteLine("\n" + (k + 1) + " no'lu deneyin sonucunu gormek için e yada E:");
                    karar = Console.ReadLine();
                }

                çakışma_toplamı1 += cakışma93;
                çakışma_toplamı2 += cakışma94;
                çakışma_toplamı3 += cakışma95;

                takvim_sıfırla(takvim_93);
                takvim_sıfırla(takvim_94);
                takvim_sıfırla(takvim_95);


            }
            Console.WriteLine("\n 1993 10 deney sonucunda yılının çakışma oranı %" + ((çakışma_toplamı1 * 100) / 120));
            Console.WriteLine("\n 1994 10 deney sonucunda yılının çakışma oranı %" + ((çakışma_toplamı2 * 100) / 120));
            Console.WriteLine("\n 1995 10 deney sonucunda yılının çakışma oranı %" + ((çakışma_toplamı3 * 100) / 120));

        }

        static int[] gun_ay_yil_uret(Random e)//dogum_gunu_uret metoduna ek olarak doğum yılı üretir
        {
            int[] dizi2 = new int[3];
            int d_gunu = e.Next(0, 31);
            dizi2[0] = d_gunu;
            int d_ayi = e.Next(0, 12);
            dizi2[1] = d_ayi;
            int d_yili = e.Next(0, 3);
            dizi2[2] = d_yili;
            return dizi2;
        }

        static int cakışma_say_bul(int[][] a)
        {
            int cakisma_toplami = 0;

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (a[i][j] > 1)
                    {
                        cakisma_toplami += (a[i][j] - 1);
                    }
                }

            }

            return cakisma_toplami;
        }

        static void n_degerleri_icin_uretim(int[][] ajanda)
        {
            int[] n = { 5, 10, 50, 100, 500 };
            int[] array;


            BirTakvim[] takvimler = new BirTakvim[50];

            for (int t = 0; t < takvimler.Length; t++)
            {
                takvimler[t] = new BirTakvim();
            }

            Random x = new Random();
            Random y = new Random();

            for (int k = 0; k < n.Length; k++)
            {
                for (int h = 0; h < 10; h++)
                {
                    int l = 0;

                    for (int i = 0; i < n[k]; i++)
                    {
                        array = dogum_gunu_uret(x);

                        if (array[1] == 1)//Ayın şubat olması durumunda gün 27'den büyükse değişiklik yapılır
                        {

                            while (array[0] > 27)
                            {
                                array[0] = gun_degistir(y);

                            }
                        }
                        if (array[1] == 3 || array[1] == 5 || array[1] == 8 || array[1] == 10)//Ay 30 gün cekiyor ise
                        {

                            while (array[0] > 29)
                            {

                                array[0] = gun_degistir(y);

                            }
                        }

                        ajanda[array[1]][array[0]] += 1;//takvimin seçilen gün ve aya denk gelen kısmının değeri 1 artırılır


                    }
                    takvimler[l].kalendar = ajanda;
                    takvimler[l].ç_say = cakışma_say_bul(ajanda);
                    takvim_sıfırla(ajanda);
                    l += 1;

                }



            }

            Console.WriteLine("Deney sonuçları için 1\nÇakışma tabloları için 2:");
            int seçenek = Convert.ToInt32(Console.ReadLine());

            switch (seçenek)
            {
                case 1:
                    Console.WriteLine("5  kişilik deney sonucu için e'ye basınız:");
                    string karar = Console.ReadLine();

                    if (karar.Equals("e"))
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            takvimYaz(takvimler[i].kalendar);
                        }
                    }

                    Console.WriteLine("10 kişilik deney sonucu için e'ye basınız:");
                    karar = Console.ReadLine();

                    if (karar.Equals("e"))
                    {
                        for (int i = 10; i < 20; i++)
                        {
                            takvimYaz(takvimler[i].kalendar);
                        }
                    }

                    Console.WriteLine("50 kişilik deney sonucu için e'ye basınız:");
                    karar = Console.ReadLine();

                    if (karar.Equals("e"))
                    {
                        for (int i = 20; i < 30; i++)
                        {
                            takvimYaz(takvimler[i].kalendar);
                        }
                    }

                    Console.WriteLine("100 kişilik deney sonucu için e'ye basınız:");
                    karar = Console.ReadLine();

                    if (karar.Equals("e"))
                    {
                        for (int i = 30; i < 40; i++)
                        {
                            takvimYaz(takvimler[i].kalendar);
                        }
                    }
                    Console.WriteLine("500 kişilik deney sonucu için e'ye basınız:");
                    karar = Console.ReadLine();

                    if (karar.Equals("e"))
                    {
                        for (int i = 40; i < 50; i++)
                        {
                            takvimYaz(takvimler[i].kalendar);
                        }
                    }
                    break;


                case 2: for (int i = 0; i < 5; i++)
                    {

                        for (int j = 0; j < 10; j++)
                        {

                            int u = 0;
                            Console.WriteLine(takvimler[u].ç_say);
                            u += 1;
                        }
                        Console.WriteLine("\n");
                    }
                    break;


            }
        }

    }

}
