
----------------------------------------------------- ADMİN-ÜYE İŞLEMLERİ----------------------------------------------------------
Projede Kullanılan Teknolojiler:
-ASP.NET CORE- MVC  
-IDENTİTY API
-MICROSOFT AZURE CLOUD 
ASP.NET CORE MVC olmakla birlikle kullanılan MVC türü, Entity Frame Work Codefirst yöntemidir.
Oluşturulan siten uygulamasının verilerini saklamak ve yönetmek amacıyla Microsoft Azure Cloud kullanılacaktır.
Azure Cloud Kullanılma Sebebi:
-Azure'da bulunan ölçeklendirme özelliği sayesinde sunucuya yük veya plana göre elle veya otomatik olarak ölçeklendirme yapılabilmesi.
-Web sitesini yedekleyerek güvende kalmasının sağlanabilmesi.
- Etki alanının verimli kullanılabilmesi.
- Güvenliği güçlendirmek amacıyla SSL sertifikası .
-Uygulamanın host edilip, yayınlanması.
ASP.NET CORE Kullanılma Sebebi:
ASP.NET Core, tüm ASP.NET altyapısının yeniden tasarlanarak, Web API ve MVC altyapıları ile birleştirilmesini sağlamıştır. 
Web uygulamaları için API’lar oluşturulması bu şekilde daha kolay hale gelmiştir. Microsoft bu platformu düzenli olarak geliştirmektedir. ASP.NET Core teknolojisi sayesinde modern uygulamaları daha az efor ve maliyet ile, daha kısa sürede oluşturabilmeye olanak sağlanmıştır. 
Asp.NET Core Identity
Asp.NET Core Identity; üyelerin, login(giriş), out(çıkış), yetkilendirme, token, şifre hatırlatma vs. tüm işlemleri hızlı bir şekilde gerçekleştirmemizi sağlayan ve bunların dışında önceki nesillere nazaran herhangi bir kısıtlaması olmaksızın uygulamalarımızı destekleyen çağdaş bir sistemidir.

ASP.NET CORE UYGULAMASI OLUŞTURMA
1-) Visual Studio'yu açın.
2-) Başlangıç penceresinde yeni bir proje oluştur'u seçin.
3-) Yeni proje oluştur penceresinde, arama kutusuna ASP.NET girin veya yazın. Ardından, Dil listesinden C#'yi seçin ve ardından Platform listesinden Windows'u seçin.
Dil ve platform filtrelerini uyguladıktan sonra, ASP.NET Çekirdek Web Uygulaması şablonunu seçin ve sonra İleri'yiseçin.

* ASP.NET Çekirdek Web Uygulaması şablonu görmüyorsanız, yeni bir proje oluştur penceresinden yükleyebilirsiniz. Aradığınızı bulamıyor musunuz? iletisinde, daha fazla araç ve özellik yükle bağlantısını seçin.
 
UYGULAMAYA GEREKLİ KÜTÜPHANELERİN EKLENMESİ İSKELETİN OLUŞTURULMASI
Projede kullanılan kütüphaneler:
Microsoft.AspNetCore.Identity.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SQLServer
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools
Microsoft.AspNetCore.Identity.UI
Bu kütüphaneleri indirmek için izlenecek yol:
Visual Studio > Tools > NuGet Package Manager > Package Manager Settings
Nuget paketlerini ekledikten sonra veritabanı bağlantımız için appsettings.json dosyamıza database connection string’i eklenir.
Sonrasında DbContext’i oluşturulur. Identity ile gelen hazır tablo yapılarını kullanabilmek için DbContext’i, IdentityDbContext sınıfı ile türetilir.
Startup.cs içindeki ConfigureServices metodunun içine aşağıdaki kod bloğu eklenir.
Aynı class içindeki Configure metoduna eklenir.
CodeFirst mantığıyla veritabanını oluşturmakiçin Microsoft PowerShell açılır .
Projenin olduğu dosya dizini kopyalanıp PowerShell'e yapştırılır.
Dotnet tooları indirilir.
Kod ile veritabanı arasındaki metod akışı bilgisini tutan ve köprü görevini gören Migration oluşturulur.
Sonrasında işlem başarı ile oluştuktan sonra veritabanı oluşur.
İskelet Bu şekildedir.
Identity ile gelen veritabanında aktif olarak developer'ın kullanıp müdahele edebileceği iki tablo vardır; 
-AspNetUsers
-AspNetRoles

Diğer var olan tablolar bu iki tablodaki değişime göre şekillenmektedir.
AspNetUsers Tablosu
Kullanıcılarla ilgili genel geçer bilgileri tutan tablodur.
1. Her bir kullanıcıyı temsil edecek olan Primary Key Id değeri. Dikkat edilirse nvarchar olarak ayarlanmıştır. Bu ayarlama güvenlik sebebi ile yapılmıştır.
2. Kullanıcı adını tutan kolondur. Dikkat edilirse “UserName” kolonunun hemen altında “NormalizedUserName” kolonuda mevcuttur.Milyonluk/milyarlık verilerde(Big Data) arama sorguları gerçekleştirilirken hız kazanmak için oluşturulmuş kolondur. Big datanın söz konusu olduğu durumlarda bir arama sorgusu “UserName” üzerinde değil “NormalizedUserName” kolonu üzerinde gerçekleştirilir. Çünkü “Normalized…” ile başlayan kolonlar indekslenmiştir. Dolayısıyla sorgularda daha hızlı çalışan bir altyapıya sahiptirler. “Normalized…” kolonlarının bir diğer özelliği tek bir formatta veri tutmasıdır. Örneğin; “UserName” kolonunda bulunan “gedik” değeri aynen “NormalizedUserName” kolonuna “GEDİK” olarak büyük harflerle kopyalanacaktır. Büyük harflerle girilmesinin sebebi tek bir fortmat olmasının getirisi olan daha hızlı eşleştirme yapılabilir olmasıyla birlikte daha hızlı indexlenebilir olmasıdır. Bir kolonun “Normalized…” versiyonu varsa eğer o kolonun kendisi indexlenmemektedir. Dolayısıyla asıl hızlı sorgulamalar Entity Framework tarafından Identity’e özel “Normalized…” kolonlarına odaklanılarak gerçekleştirilir. Bir önceki Identity sürümünde tüm indexlemeler direkt olarak ilgili kolon üzerinde gerçekleştiriliyordu. Dolayısıyla “Normalized…” ile başlayan kolonlar söz konusu değildi. Bunun getirisinin yanında birçokolası hataların yaşanması maliyeti oldukça yükseltiyordu.
3. Kullanıcının e-posta bilgisini tutan alandır. 2. numaralı kolonda olduğu gibi bu kolonunda aynı amaca hizmet eden indexlenmiş değeri olan “NormalizedEmail” kolonu mevcuttur.
4. Kullanıcıdan alınan tüm passwordler Hash algoritmasıyla şifrelenerek tutulmaktadır.
5. Kullanıcı ilk oluşturulduğunda(create) buraya bir build değeri atanır. Sonraki her güncelleme üzerine bu değer güncellenecektir. Dolayısıyla bizlerde bu kullanıcı üzerinde bir değişiklik olduğuna dair bilgi edinmiş olacağız. Bir nevi Data Concurrency sağlayabilmek için oluşturulmuştur.
6. İlgili veri üzerinde Data Concurrency sağlayabilmek için oluşturulmuştur.
7. Kullanıcının kaydı neticesinde aktivasyon yapılanmasının iki adımlı olup olmadığına dair kayıt tutar. Bu kolon genellikle 3. party üyelik sistemleriyle birlikte kullanılır. Örneğin; kullanıcı Facebook üzerinden giriş yaptığında ekstradan telefon ile onay gerektiriyorsa işte “TwoFactorEnabled” kolonu true/1 olarak işaretlenecektir.
8. Kullanıcı girişlerine dair yapılan hataları ve engel durumunu tutan kolonlardır. “LockoutEnd” kolonu kaç kez yanlış girildiğine dair, “LockoutEnabled” kolonu kullanıcının aktifliğine dair ve “AccessFailedCount” kolonu ise kaç başarısız giriş yapılmaya çalışıldığına dair bilgi tutmaktadır. Identity mimarisi bu yapıları otomatik işleyecektir. Dolayısıyla tarafımızca custom bir kod geliştirmemize lüzum görülmemektedir.
AspNetRoles Tablosu
 
Uygulamada kullanıcılara özgü tanımlanan rolleri tutan tablodur. Şöyle tabloyu incelersek rollerin adını tutacak olan “Name” kolonu ve bu değerleri indexleyip big data durumlarında performans kazandıracak indexlenmiş “NormalizedName” kolonu mevcuttur. Ayriyetten veri tutarlılığı için de “ConcurrencyStamp” kolonu mevcuttur.
Üye olma ve admin yetkilendirme işlemleri Cookie tabanlı bir mekanizma ile gerçekleştirilmektedir.
Identity ile ilgili tüm ayarların gerçekleştiği yer startup.cs dosyasının ConfigureServices metodudur.
Identitynin defaulttaki şifre mekanizmalarını kullanmayıp custom olarak oluşan şifre mekanzimaları burada gerçekleşir.
Asıl iş IPasswordValidator<AppUser>  classlara ınterface olarak geçtiğimizde bu interfacenin içerisine metod gelecek bu metod ValidateAsync Metodu olacak bu sayede custom mekanizmalar yapabiliyoruz. içerisinde yararlı bilgilerde geliyor parametre olarak user manager user password gibi Hatta identity devre dışıda bırakabiliyoruz fazla değişikliklerde yapabiliyoruz.
API de iki tane kullancı doğrulama mekanizması var: 
-RequireUniqueEmail, username'in, veritabanında tek olup olmadığı kontrolü yapar.
-AllowedUserNameCharacters, kullanılmasını istediğimiz kaarakterlerin belirlenmesinde olanak sağlar.
Identity de kullancı aranırken username ile aranıyor. O yüzden kullancı isminin iki tane olmasına müsade edilmez.
Emailin, kullanıcı adının tek olması startup.cs  burada sağlanır.
 

USER MANAGER 
Kullanıcıyla ilgili tüm işlemlerin gerçekleştirildiği sınıftır. İçerisinde birçok metod barındırıyor.
User manager'ın sadece get özelliği var dependence ınjection sayesinde set edilecek.
USER VİEW MANAGER
 Sql'de var olan bilgilerin hepsi kullanıcıya gösterilmez. İstenmediğinden dolayıda sqlde'ki tabloda olan verileri koda dökmeye gerek yoktur. Bunun için biz AppUser ile kullanıcıya gösterilecek alan arasında köprü kuracak view modeller oluşturulur.
Kısaca custom bir sınıf olur bu da entity ile kullanıcı arasında köprü görevi görür.
Layoutlarda bulunan asp actionlar href gibi bir taghelperdır. View Import tarafından geliyor.

------------------------------------ SİTE PROJESİ ÇALIŞTIRMA İŞLEMLERİ ---------------------------------
Projeyi çalıştırmak için;
Tarayıcınızdan .NetCore 3.1.3 Sdk dosyasını bilgisayarınıza kurun
- Sql server data object alanından veri tabanı bağlantısını (ConnectionString) alın.
InıtialCatalog kısmının "ApplicationDb" olmasına dikkat edin.
- Bu bağlantıyı appsettings.json' daki DefaultConnection alanına yapıştırın ve aynı işlemi API Startup.cs ve Core projesi Startup.cs da bulunan veri tabanı bağlantı kısımlarına da yapın. Proje çalışacaktır.

İyi Çalışmalar
