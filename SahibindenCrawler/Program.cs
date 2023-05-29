using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace SahibindenCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            // Anasayfa vitrininden ilanları oku
            List<Ilan> ilanlar = GetIlanlarFromVitrin();

            // İlan detaylarına girerek fiyatları oku
            GetFiyatlarForIlanlar(ilanlar);

            // İlan isimleri ve fiyatları console ekranında göster
            Console.WriteLine("İlanlar:");
            foreach (var ilan in ilanlar)
            {
                Console.WriteLine($"İlan İsmi: {ilan.IlanIsmi}");
                Console.WriteLine($"Fiyat: {ilan.Fiyat}");
                Console.WriteLine();
            }

            // Tüm fiyatların ortalamasını hesapla ve console ekranında göster
            double ortalamaFiyat = ilanlar.Average(ilan => ilan.Fiyat);
            Console.WriteLine($"Ortalama Fiyat: {ortalamaFiyat:C}");

            //İlan isimleri ve fiyatları bir txt dosyasına kaydet
            SaveIlanlarToFile(ilanlar);
        }

        static List<Ilan> GetIlanlarFromVitrin()
        {
            var ilanlar = new List<Ilan>();

            using (var client = new WebClient())
            {
                string html = client.DownloadString("https://www.sahibinden.com/");
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                var ilanElements = doc.DocumentNode.SelectNodes("//div[contains(@class, 'classifiedList')]/ul/li");

                foreach (var ilanElement in ilanElements)
                {
                    var ilanBaslikElement = ilanElement.SelectSingleNode(".//h5/a");
                    var detayURL = ilanBaslikElement.Attributes["href"].Value;
                    var ilanIsmi = ilanBaslikElement.InnerText;

                    ilanlar.Add(new Ilan { IlanIsmi = ilanIsmi, DetayURL = detayURL });
                }
            }

            return ilanlar;
        }

        static void GetFiyatlarForIlanlar(List<Ilan> ilanlar)
        {
            using (var client = new WebClient())
            {
                foreach (var ilan in ilanlar)
                {
                    string html = client.DownloadString(ilan.DetayURL);
                    var doc = new HtmlDocument();
                    doc.LoadHtml(html);

                    var fiyatElement = doc.DocumentNode.SelectSingleNode("//span[@class='classifiedInfoValue priceText']");
                    var fiyat = fiyatElement.InnerText;

                    ilan.Fiyat = ParseFiyat(fiyat);
                }
            }
        }

        static double ParseFiyat(string fiyat)
        {
            double parsedFiyat = 0;

            try
            {
                fiyat = fiyat.Replace("TL", "").Replace(".", "").Trim();
                parsedFiyat = double.Parse(fiyat);
            }
            catch (Exception)
            {
                // Fiyatın dönüştürülmesi sırasında bir hata oluştuysa varsayılan değer olarak 0 kullanılır.
            }

            return parsedFiyat;
        }

        static void SaveIlanlarToFile(List<Ilan> ilanlar)
        {
            var ilanlarJson = JsonConvert.SerializeObject(ilanlar, Formatting.Indented);
            File.WriteAllText("ilanlar.txt", ilanlarJson);
        }
    }

    
}
