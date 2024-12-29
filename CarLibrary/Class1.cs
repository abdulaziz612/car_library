using System;
using System.Collections.Generic;
using System.IO;

namespace ArabaGalerisiKutuphane
{
    public abstract class TemelAraba
    {
        protected string Marka { get; set; }
        protected string Model { get; set; }
        protected int Yil { get; set; }
        protected string YakitTipi { get; set; }

        public TemelAraba(string marka, string model, int yil, string yakitTipi)
        {
            Marka = marka;
            Model = model;
            Yil = yil;
            YakitTipi = yakitTipi;
        }

        public abstract void BilgiYazdir();
        public abstract string ToCsv();
        public abstract void FromCsv(string[] values);
    }

    public class Sedan : TemelAraba
    {
        public int BagajHacmi { get; set; }

        public Sedan(string marka, string model, int yil, int bagajHacmi, string yakitTipi)
            : base(marka, model, yil, yakitTipi)
        {
            BagajHacmi = bagajHacmi;
        }

        public override void BilgiYazdir()
        {
            Console.WriteLine($"Sedan Araba: {Marka} {Model} ({Yil}), Yakit Tipi: {YakitTipi}, Bagaj Hacmi: {BagajHacmi} litre");
        }

        public override string ToCsv()
        {
            return $"Sedan,{Marka},{Model},{Yil},{YakitTipi},{BagajHacmi}";
        }


        public override void FromCsv(string[] values)
        {
            // Check if there are enough values in the array to avoid out-of-range
            if (values.Length < 6)
            {
                Console.WriteLine($"Invalid CSV line for Sedan: {string.Join(",", values)}");
                return; // Skip this line, don't try to process invalid data
            }
            Marka = values[1];
            Model = values[2];
            Yil = int.Parse(values[3]);
            YakitTipi = values[4];
            BagajHacmi = int.Parse(values[5]);
        }
    }

    public class SUV : TemelAraba
    {
        public bool DortCeker { get; set; }
        public int BagajHacmi { get; set; }

        public SUV(string marka, string model, int yil, bool dortCeker, int bagajHacmi, string yakitTipi)
            : base(marka, model, yil, yakitTipi)
        {
            DortCeker = dortCeker;
            BagajHacmi = bagajHacmi;
        }

        public override void BilgiYazdir()
        {
            Console.WriteLine($"SUV Araba: {Marka} {Model} ({Yil}), 4x4: {(DortCeker ? "Evet" : "Hayır")}, Yakit Tipi: {YakitTipi}, Bagaj Hacmi: {BagajHacmi} litre");
        }

        public override string ToCsv()
        {
            return $"SUV,{Marka},{Model},{Yil},{YakitTipi},{(DortCeker ? "Evet" : "Hayır")},{BagajHacmi}";
        }

        public override void FromCsv(string[] values)
        {
            // Check if there are enough values in the array to avoid out-of-range
            if (values.Length < 7)
            {
                Console.WriteLine($"Invalid CSV line for SUV: {string.Join(",", values)}");
                return; // Skip this line, don't try to process invalid data
            }

            Marka = values[1];
            Model = values[2];
            Yil = int.Parse(values[3]);
            YakitTipi = values[4];
            DortCeker = values[5].ToLower() == "evet";

            if (values.Length > 6)
            {
                int.TryParse(values[6], out int bagaj);
                BagajHacmi = bagaj;
            }
        }
    }

    public class ArabaStogu
    {
        private List<TemelAraba> arabalar;

        public ArabaStogu()
        {
            arabalar = new List<TemelAraba>();
        }

        public void ArabaEkle(TemelAraba araba)
        {
            arabalar.Add(araba);
        }

        public void ArabaSil(int index)
        {
            if (index >= 0 && index < arabalar.Count)
            {
                arabalar.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Geçersiz indeks. Lütfen doğru bir indeks girin.");
            }
        }

        public void StoguYazdir()
        {
            Console.WriteLine("Stoktaki Arabalar:");
            for (int i = 0; i < arabalar.Count; i++)
            {
                Console.WriteLine($"[{i}] ");
                arabalar[i].BilgiYazdir();
            }
        }

        public int ArabaSayisi()
        {
            return arabalar.Count;
        }

        public void CsvKaydet(string dosyaAdi)
        {
            using (StreamWriter sw = new StreamWriter(dosyaAdi))
            {
                foreach (var araba in arabalar)
                {
                    sw.WriteLine(araba.ToCsv());
                }
            }
        }

        public void CsvOku(string dosyaAdi)
        {
            if (!File.Exists(dosyaAdi)) return;

            using (StreamReader sr = new StreamReader(dosyaAdi))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line)) continue; // Skip empty lines
                    string[] values = line.Split(',');
                    if (values.Length == 0) continue; //Skip lines with no values

                    if (values[0] == "Sedan")
                    {
                        Sedan sedan = new Sedan("", "", 0, 0, ""); //Create a dummy sedan to use FromCsv
                        sedan.FromCsv(values);
                        ArabaEkle(sedan);
                    }
                    else if (values[0] == "SUV")
                    {
                        SUV suv = new SUV("", "", 0, false, 0, "");//Create a dummy SUV to use FromCsv
                        suv.FromCsv(values);
                        ArabaEkle(suv);
                    }
                }
            }
        }
    }
}