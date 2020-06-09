-----------------------------------------------TEKNO EĞİTİM PROJESİ KODLAMA STANDARTLARI-------------------------------------------

*Projede Kullanılan Teknolojiler:

- ASP.NET CORE MVC ÇOK KATMANLI MİMARİ 

- ASP.NET CORE IDENTITY 

Bu projede kullanılan yöntem  Entity FrameWork Codefirst yöntemidir.

Oluşturulan proje uygulamasının verilerini saklamak ve yönetmek amacıyla Microsoft Azure Cloud kullanılacaktır.

ASP.NET CORE Kullanılma Sebebi:

ASP.NET Core, tüm ASP.NET altyapısının yeniden tasarlanarak, Web API ve MVC altyapıları ile birleştirilmesini sağlamıştır. 
Web uygulamaları için API’lar oluşturulması bu şekilde daha kolay hale gelmiştir. 
Microsoft bu platformu düzenli olarak geliştirmektedir. 
ASP.NET Core teknolojisi sayesinde modern uygulamaları daha az efor ve maliyet ile, daha kısa sürede oluşturabilmeye olanak sağlanmıştır. 

Asp.NET Core Identity

Asp.NET Core Identity; üyelerin, login(giriş), out(çıkış), yetkilendirme, token, şifre hatırlatma vs. tüm işlemleri hızlı bir şekilde gerçekleştirmemizi sağlayan ve bunların dışında önceki nesillere nazaran herhangi bir kısıtlaması olmaksızın uygulamalarımızı destekleyen çağdaş bir sistemdir.

*Neden Azure Cloud ?

-Azure'da bulunan ölçeklendirme özelliği sayesinde sunucuya yük veya plana göre elle veya otomatik olarak ölçeklendirme yapılabilmesi.

-Web sitesini yedekleyerek güvende kalmasının sağlanabilmesi.

- Etki alanının verimli kullanılabilmesi.

- Güvenliği güçlendirmek amacıyla SSL sertifikası .

-Uygulamanın host edilip, yayınlanması.
 

Projeyi çalıştırmak için;

Tarayıcınızdan .NetCore 3.1.3 Sdk dosyasını bilgisayarınıza kurun.
- Sql server data object alanından veri tabanı bağlantısını (ConnectionString) alın.
InıtialCatalog kısmının "ApplicationDb" olmasına dikkat edin.
- Bu bağlantıyı appsettings.json' daki DefaultConnection alanına yapıştırın ve aynı işlemi API Startup.cs ve Core projesi 
Startup.cs da bulunan veri tabanı bağlantı kısımlarına da yapın. 
Proje çalışacaktır.
