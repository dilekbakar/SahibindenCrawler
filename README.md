# SahibindenCrawler
Örnek Vaka: Crawling Uygulaması
Öncelikle proje için gerekli olan paketler :
HtmlAgilityPack: HTML analizi için kullanılır.
Newtonsoft.Json: JSON işlemleri için kullanılır.

sahibinden.com web sitesinin anasayfa vitrininden ilanları okumak için GetIlanlarFromVitrin() metodu kullanılmaktadır. Ardından, her ilanın detay sayfasına girerek fiyatını almak için GetFiyatlarForIlanlar() metodu kullanılmaktadır.

İlanları ve fiyatları console ekranında göstermek için Main() metodunda bu veriler dolaşılıp ve Console.WriteLine() ile yazdırılmaktadır. Ortalama fiyatı hesaplamak için ilanlar.Average() yöntemi kullanılmaktadır.

İlanları bir JSON dosyasına kaydetmek için SaveIlanlarToFile() metodunu kullanılmaktadır.

İlan sınıfı, her bir ilanın özelliklerini (ilan ismi, detay URL'si, fiyat) temsil etmek için kullanılır.

IP banlamalarına karşı sorunu çözecek bir algoritma geliştirmek için aşağıda belirttiğim öneriler dikkate alınabilir:
- İstekler aralıklı bir şekilde yapılmalı: Web sitesine ardışık istekler yapmak yerine rastgele zaman aralıklarında istekler yaparak doğal bir kullanım taklit edilebilir.
- Proxy kullanılmalı: Proxy sunucuları aracılığıyla istekler dağıtılarak IP adresi gizlenebilir.
- CAPTCHA çözme hizmetleri: Bazı web siteleri CAPTCHA doğrulaması yaparak botları engellemeye çalışır. Bu durumda CAPTCHA çözme hizmetleri kullanarak otomatik olarak CAPTCHA'yı geçebilirsiniz.
- Web sitesinin robots.txt dosyası kontrol edilebilir: Web sitesinin robots.txt dosyasında kazıma işlemlerine izin verilip verilmediği kontrol edilmelidir. Eğer izin verilmiyorsa, web sitesine etik gereği kazıma işlemlerinden kaçınılmlıdır.

Bu örnekler başlangıç noktası olarak yardımcı olabilir. Ancak, Sahibinden.com gibi bir web sitesinden veri kazımanın etik kurallarına uygun olması ve web sitesinin kullanım koşullarını ihlal etmemesi önemlidir. Sahibinden.com gibi bir web sitesinden veri kazımak için önceden izin alınmalı veya web sitesinin API hizmetlerini kullanılması daha doğru bir yaklaşım olabilir.
