using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string admin = "serkan";
            string password = "123";
            string[] urunler = new string[15] { "Su", "Kola", "Fanta", "Çay", "Kahve", "Ayran", "Soda", "Limonata", "Bira", "Limonlu Soda", null, null, null, null, null };
            double[] fiyatlar = new double[15] { 2.5, 7.5, 7.5, 3, 12, 4, 5, 8, 28, 7, 0, 0, 0, 0, 0 };
            while (true)
            {
                
                Console.WriteLine("\t\t\t\t\tYönetici Girişi --> 1\n\t\t\t\t\tMüşteri Girişi --> 2");
                
            a:
                int secim = Convert.ToInt32(Console.ReadLine());
                if (secim == 1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine((i + 1) + ".Hakkınız");
                        Console.WriteLine("Username: ");
                        string kadi = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Password: ");
                        string sifre = Convert.ToString(Console.ReadLine());
                        if (kadi == admin && sifre == password)
                        {
                            Console.WriteLine("Yönetici Girişi Başarılı");
                            break;
                        }
                        else if (i == 2)
                        {
                            Console.WriteLine("Hakkınız Bitti");
                            Thread.Sleep(3000);
                            i = -1;
                            continue;
                        }
                    }
                    UrunleriListele(urunler, fiyatlar);
                    Console.WriteLine(" ");

                    Console.WriteLine("Ürün Ekleme -->  1\nÜrün Güncelleme --> 2\nÜrün Silme --> 3");
                    int islem = Convert.ToInt32(Console.ReadLine());
                    if (islem == 1)
                    {
                        Console.WriteLine("Yeni Ürün Adı:");
                        string urun = Console.ReadLine();
                        Console.WriteLine("Yeni Ürün Fiyatı:");
                        double fiyat = Convert.ToDouble(Console.ReadLine());
                        for (int k = 0; k < urunler.Length; k++)
                        {
                            if (fiyatlar[k] == 0)
                            {
                                urunler[k] = urun;
                                fiyatlar[k] = fiyat;
                                Console.WriteLine("Ekleme Başarılı");
                                break;
                            }

                        }

                    }
                    else if (islem == 2)
                    {
                        for (int i = 0; i < urunler.Length; i++)
                        {
                            if (fiyatlar[i] > 0)
                            {
                                Console.WriteLine(i + "-" + urunler[i] + ":" + fiyatlar[i]);
                            }

                        }
                        Console.WriteLine("Güncelenecek index:");
                        int index = Convert.ToInt32(Console.ReadLine());

                        if (fiyatlar[index] > 0)
                        {
                            Console.WriteLine("Yeni Ürün Adı:");
                            string urun = Console.ReadLine();
                            Console.WriteLine("Yeni Ürün Fiyatı:");
                            double fiyat = Convert.ToDouble(Console.ReadLine());


                            urunler[index] = urun;
                            fiyatlar[index] = fiyat;
                            Console.WriteLine("Güncelleme Başarılı");
                        }
                        else
                        {
                            Console.WriteLine("Hatalı Tuşlama");
                        }
                    }
                    else if (islem == 3)
                    {
                        for (int i = 0; i < urunler.Length; i++)
                        {
                            if (fiyatlar[i] > 0)
                            {
                                Console.WriteLine(i + "-" + urunler[i] + ":" + fiyatlar[i]);
                            }

                        }
                        Console.WriteLine("Silinecek index:");
                        int index = Convert.ToInt32(Console.ReadLine());

                        if (fiyatlar[index] > 0)
                        {
                            Array.Clear(urunler, index, 1);
                            Array.Clear(fiyatlar, index, 1);
                            Console.WriteLine("Silme Başarılı");
                        }
                        else
                        {
                            Console.WriteLine("Hatalı Tuşlama");
                        }
                    }
                    else if (islem == 4)
                    {
                        for (int i = 0; i < urunler.Length; i++)
                        {
                            if (fiyatlar[i] > 0)
                            {
                                Console.WriteLine(i + "-" + urunler[i] + ":" + fiyatlar[i]);
                            }

                        }
                    }
                }
                else if (secim == 2)
                {
                    UrunleriListele(urunler, fiyatlar);
                    Console.WriteLine("\nSatın almak istediğiniz ürünü girin: ");
                    int urunSec = Convert.ToInt32(Console.ReadLine());
                    bool paraYeterli = false;
                    double paraUstu = 0;
                    if (urunSec < urunler.Length && urunSec > 0) //if(urunler.Contains(urunadi))
                    {
                        while (!paraYeterli) //(parayeterli==false)
                        {
                            Console.WriteLine("Para Yukleyin: ");
                            double paraGir = Convert.ToDouble(Console.ReadLine());
                            paraUstu = paraGir - fiyatlar[urunSec - 1];
                            if (paraUstu < 0)
                            {
                                Console.WriteLine("Paranız Yetersiz, En Az " + Math.Abs(paraUstu) + " Para Ekleyin");
                            }
                            else
                            {
                                paraYeterli = !paraYeterli; //=true;
                            }
                        }
                        Console.WriteLine("Paranızın üstü: " + paraUstu);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Olmayan Ürün");
                    }

                }
                else
                {
                    Console.WriteLine("Hatalı İşlem");
                }
            }
            Console.ReadLine();
        }
        static void UrunleriListele(string[] urunler, double[] fiyatlar)
        {
            for (int i = 0; i < urunler.Count(); i++)
            {
                Console.WriteLine((i + 1) + ") " + urunler[i] + " Fiyatı: " + fiyatlar[i]);
            }

        }
    }
}
