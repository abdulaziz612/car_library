using System;
using System.IO;
using ArabaGalerisiKutuphane;

namespace ArabaGalerisiUygulama
{
    class Program
    {
        static void Main(string[] args)
        {
            // Yeni araba stoğu oluştur ve CSV'den yükle
            ArabaStogu stok = new ArabaStogu();
            stok.CsvOku("arabalar.csv");

            string secim;

            do
            {
                Console.Clear();
                Console.WriteLine("Araba Galerisi Yönetim Sistemi");
                Console.WriteLine("1. Araba Ekle");
                Console.WriteLine("2. Araba Sil");
                Console.WriteLine("3. Stoktaki Arabaları Görüntüle");
                Console.WriteLine("4. Çıkış");
                Console.Write("Seçiminizi yapın: ");
                secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        ArabaEkle(stok);
                        break;
                    case "2":
                        ArabaSil(stok);
                        break;
                    case "3":
                        stok.StoguYazdir();
                        Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Çıkış yapılıyor...");
                        stok.CsvKaydet("arabalar.csv");
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }
            } while (secim != "4");
        }

        static void ArabaEkle(ArabaStogu stok)
        {
            Console.Clear();
            Console.WriteLine("Araba Ekleme");
            Console.Write("Marka: ");
            string marka = Console.ReadLine();

            Console.Write("Model: ");
            string model = Console.ReadLine();

            int yil;
            while (true)
            {
                Console.Write("Yıl (1990-2024): ");
                string yilInput = Console.ReadLine();

                if (int.TryParse(yilInput, out yil) && yil >= 1990 && yil <= 2024)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş! Lütfen geçerli bir yıl giriniz (1990-2024).");
                }
            }

            Console.WriteLine("Yakıt Tipi: ");
            Console.WriteLine("1. Benzin");
            Console.WriteLine("2. Dizel");
            Console.Write("Seçim: ");
            string yakitSecim = Console.ReadLine();

            string yakitTipi;
            if (yakitSecim == "1")
            {
                yakitTipi = "Benzin";
            }
            else if (yakitSecim == "2")
            {
                yakitTipi = "Dizel";
            }
            else
            {
                Console.WriteLine("Geçersiz seçim! Ana menüye dönülüyor...");
                return;
            }

            Console.WriteLine("Araba Tipi: ");
            Console.WriteLine("1. Sedan");
            Console.WriteLine("2. SUV");
            Console.Write("Seçim: ");
            string tipSecim = Console.ReadLine();

            // Consume the newline character if SUV is selected
            if (tipSecim == "2")
            {
                Console.ReadLine(); // Consume the newline character
            }

            if (tipSecim == "1")
            {
                int bagajHacmi;
                while (true)
                {
                    Console.Write("Bagaj Hacmi (litre) [30-80]: ");
                    string bagajInput = Console.ReadLine();

                    if (int.TryParse(bagajInput, out bagajHacmi) && bagajHacmi >= 30 && bagajHacmi <= 80)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Hatalı giriş! Lütfen 30 ile 80 arasında bir değer giriniz.");
                    }
                }
                stok.ArabaEkle(new Sedan(marka, model, yil, bagajHacmi, yakitTipi));
            }
            else if (tipSecim == "2")
            {
                int bagajHacmi;
                while (true)
                {
                    Console.Write("Bagaj Hacmi (litre) [30-80]: ");
                    string bagajInput = Console.ReadLine();

                    if (int.TryParse(bagajInput, out bagajHacmi) && bagajHacmi >= 30 && bagajHacmi <= 80)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Hatalı giriş! Lütfen 30 ile 80 arasında bir değer giriniz.");
                    }
                }

                Console.Write("4x4 mü? (Evet/Hayır): ");
                bool dortCeker = Console.ReadLine().ToLower() == "evet";

                Console.WriteLine($"SUV arabaların bagaj hacmi de kontrol edilmiştir. {bagajHacmi} litre.");
                stok.ArabaEkle(new SUV(marka, model, yil, dortCeker, bagajHacmi, yakitTipi));
            }
            else
            {
                Console.WriteLine("Geçersiz seçim! Ana menüye dönülüyor...");
                return;
            }

            Console.WriteLine("Araba başarıyla eklendi. Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void ArabaSil(ArabaStogu stok)
        {
            Console.Clear();
            Console.WriteLine("Araba Silme");
            stok.StoguYazdir();

            if (stok.ArabaSayisi() > 0)
            {
                Console.Write("Silmek istediğiniz arabanın indeksini girin: ");
                int indeks = int.Parse(Console.ReadLine());
                stok.ArabaSil(indeks);
                Console.WriteLine("Araba başarıyla silindi. Devam etmek için bir tuşa basın...");
            }
            else
            {
                Console.WriteLine("Silinecek araba bulunmamaktadır.");
            }

            Console.ReadKey();
        }
    }
}