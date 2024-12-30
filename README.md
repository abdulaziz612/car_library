Araba Galerisi Yönetim Sistemi Projesi

Projenin Amacı

Bu proje, bir araba galerisi için temel bir yönetim sistemi geliştirmeyi hedeflemektedir. Sistem, kullanıcıların araba ekleyip çıkarmasına, mevcut araba stoklarını görüntülemesine ve bu verileri bir CSV dosyasında saklamasına olanak tanır.

Kullanılan Teknolojiler ve Yapılar

Programlama Dili: C#

Dosya İşlemleri: Araba verileri bir CSV dosyasında saklanır ve okunur.

Nesneye Dayalı Programlama (OOP): TemelAraba, Sedan ve SUV gibi sınıflar kullanılarak araba türleri temsil edilmiştir.

Proje Modülleri

1. Ana Program (“Program.cs”)

Ana program, kullanıcıdan giriş alarak belirli işlevleri gerçekleştiren bir konsol uygulamasıdır. Uygulamanın sunduğu işlevler:

Araba Ekleme: Kullanıcı, araba bilgilerini girerek stoklara yeni araba ekleyebilir.

Araba Silme: Kullanıcı, mevcut stoktan bir arabayı kaldırabilir.

Stok Görüntüleme: Tüm mevcut arabalar listelenebilir.

Çıkış: Programdan çıkarken stok bilgileri bir CSV dosyasına kaydedilir.

2. Kütüphane Modülü (“class1.cs”)

Bu modül, araba ve stok işlemleri için gerekli olan sınıfları ve yöntemleri içerir.

Temel Sınıflar:

TemelAraba (Abstract Class)

Alanlar:

Marka, Model, Yıl, Yakıt Tipi

Metotlar:

BilgiYazdir(): Arabanın bilgilerini ekrana yazdırır.

ToCsv(): Araba bilgilerini CSV formatına dönüştürür.

FromCsv(): CSV formatındaki bilgileri okuyarak araba nesnesini oluşturur.

Sedan (Derived Class)

Ek Özellikler:

Bagaj Hacmi

Sedan türü araçların bilgilerini ve özelliklerini temsil eder.

SUV (Derived Class)

Ek Özellikler:

4x4 Özelliği (DortCeker)

Bagaj Hacmi

SUV türü araçların bilgilerini ve özelliklerini temsil eder.

Stok Yönetimi:

ArabaStogu:

Alanlar:

Araba listesi (List)

Metotlar:

ArabaEkle(TemelAraba araba): Yeni araba ekler.

ArabaSil(int index): Belirtilen indekse göre araba siler.

StoguYazdir(): Tüm arabaların bilgilerini ekrana yazdırır.

CsvKaydet(string dosyaAdi): Stok verilerini CSV dosyasına kaydeder.

CsvOku(string dosyaAdi): CSV dosyasını okuyarak stok verilerini yükler.

İşleyiş

Araba Ekleme

Kullanıcı araba türünü (Sedan veya SUV) seçer.

Kullanıcı, araba bilgilerini (marka, model, yıl, yakıt tipi, bagaj hacmi gibi) girer.

SUV türü için ek olarak 4x4 özelliği bilgisi alınır.

Girilen bilgiler doğrulanır ve uygun formatta kaydedilir.

Araba Silme

Mevcut stoklar ekranda listelenir.

Kullanıcı, silmek istediği arabanın indeksini girer.

Belirtilen araba stoktan kaldırılır.

Stok Görüntüleme

Tüm mevcut arabalar liste halinde ekrana yazdırılır.

Veri Saklama

CSV Dosyası:

Program başlatıldığında CsvOku() metodu çalıştırılarak arabalar yüklenir.

Program kapatıldığında CsvKaydet() metodu ile arabalar dosyaya kaydedilir.

Kullanım Alanları

Bu proje, araba galerisi işletmelerinin stok yönetiminde kolaylık sağlamak için geliştirilmiştir. Yeni özellikler eklenerek daha kapsamlı bir hale getirilebilir.

