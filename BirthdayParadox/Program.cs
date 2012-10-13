


using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayParadox
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[][] takvim = new int[12][];
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

            for (int i = 0; i < takvim.Length; i++)
            {
                for (int j = 0; j < takvim[i].Length; j++)
                {
                    takvim[i][j] = 0;
                }
            }

            coklu_dogum_gunu(takvim);
            takvimYaz(takvim);
            Console.ReadKey();
        }

        //static void tekrar_metodu(int n)
        //{
        //    for(int i
        //}


        static int[] dogum_gunu_uret(Random a)
        {
            int[] dizi = new int[2];
            int rastgele_dogum_gunu = a.Next(0, 31);
            dizi[0] = rastgele_dogum_gunu;
            int rastgele_dogum_ayi = a.Next(0, 12);
            dizi[1] = rastgele_dogum_ayi;
            return dizi;
        }
        static void coklu_dogum_gunu(int[][] calendar)
        {
            Console.WriteLine("Doğum günü sayısını giriniz:");
            int sayi = Convert.ToInt32(Console.ReadLine());
            int[] array;
            int toplam_cakısma_say = 0;

            Console.WriteLine("Her işlem sonucunu görmek istiyor musunuz(E/h):");
            string secim = Console.ReadLine();

            Random x = new Random();
            for (int k = 0; k < 10; k++)
            {
                for (int i = 0; i < sayi; i++)
                {
                    array = dogum_gunu_uret(x);
                    if (array[1] == 1)
                    {

                        while (array[0] > 27)
                        {
                            array = dogum_gunu_uret(x);

                        }
                    }
                    if (array[1] == 3 || array[1] == 5 || array[1] == 8 || array[1] == 10)
                    {

                        while (array[0] > 29)
                        {

                            array = dogum_gunu_uret(x);

                        }
                    }


                    ++calendar[array[1]][array[0]];

                    if (secim.Equals("E") == true || secim.Equals("e") == true)
                    { takvimYaz(calendar); Console.WriteLine(); }
                }

            }
            for (int i = 0; i < calendar.Length; i++)
            {
                for (int j = 0; j < calendar[i].Length; j++)
                {
                    if (calendar[i][j] > 1)
                        toplam_cakısma_say += calendar[i][j] - 1;
                }

            }
            Console.WriteLine("Cakisma sayisi:" + toplam_cakısma_say);

        }




        static void takvimYaz(int[][] calender)
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < calender[i].Length; j++)
                {
                    Console.Write(calender[i][j]);
                }
                Console.WriteLine();
            }

        }
    }
}


