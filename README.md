# 🍽️ WebAPI Restoran Yönetim Sistemi

![.NET](https://img.shields.io/badge/.NET%2010.0-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)
![Microsoft SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=white)
![SignalR](https://img.shields.io/badge/SignalR-005C9E?style=flat-square&logo=signalr&logoColor=white)
![OpenAI](https://img.shields.io/badge/OpenAI-412991?style=flat-square&logo=openai&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-512BD4?style=flat-square&logo=nuget&logoColor=white)
![AutoMapper](https://img.shields.io/badge/AutoMapper-8A2BE2?style=flat-square&logo=nuget&logoColor=white)
![FluentValidation](https://img.shields.io/badge/FluentValidation-42A5F5?style=flat-square&logo=nuget&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=flat-square&logo=swagger&logoColor=black)
![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=flat-square&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=flat-square&logo=css3&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=flat-square&logo=javascript&logoColor=black)

## 📖 Proje Hakkında

Proje, İstemci (Web UI) ve Sunucu (Web API) olmak üzere iki ana katmandan oluşuyor ve RESTful yapısına uygun çalışıyor. Temel veritabanı işlemlerinin (CRUD) yanı sıra, projeye SignalR ile anlık iletişim ve OpenAI API kullanarak yapay zeka özellikleri de ekledim. OpenAI'ı; müşterinin yazmış olduğu mesaja karşılık cevap üretimi, yemek tarifi önerisi ve SignalR ile entegreli anlık mesajlaşma sistemlerinde kullandım.

## 🚀 Kullanılan Teknolojiler ve Kütüphaneler

### ⚙️ Web API Katmanı
Veritabanı kayıtları, veri alışverişi ve sistemin arka plandaki tüm işlemlerinin yapıldığı sunucu kısmıdır;

* **Entity Framework Core:** Veritabanı işlemlerini Code-First yaklaşımıyla, SQL yazmadan doğrudan C# nesneleri üzerinden güvenli bir şekilde yönetmek için ORM aracı olarak tercih ettim.
* **AutoMapper:** Veritabanı Entity'lerim ile dışarıya açtığım DTO'lar (Data Transfer Object) arasındaki dönüştürme (mapping) işlemlerini otomatize ederek kod tekrarının önüne geçtim.
* **FluentValidation:** Model sınıflarını Data Annotations ile kirletmeden, DTO'ların doğrulama (validation) işlemlerini temiz ve ayrı bir yapıda kurguladım.
* **Swashbuckle(Swagger):** Geliştirdiğim Web API endpointleri test edebilmek amacıyla projeye entegre ettim.
* **Repository & Unit of Work Pattern:** Veritabanı erişim katmanını soyutlamak (Generic Repository) ve tüm veritabanı işlemlerini tek bir işlem havuzunda (transaction) güvenle yönetmek için bu tasarım desenlerini uyguladım.

### 🎨 Web UI Katmanı
Kullanıcıların ve yöneticilerin sistemi kullandığı sayfalar;

* **IHttpClientFactory:** Web UI katmanının, Web API projemle ve OpenAI gibi dış servislerle haberleşmesini sağlayan HTTP isteklerini optimize etmek için kullandım.
* **SignalR:** Yöneticinin, projedeki yapay zeka (OpenAI) ile anlık olarak mesajlaşabilmek için sisteme ekledim.
* **OpenAI API:** Müşterilerin yazdığı mesajlara cevap üretmek, yemek tarifi önermek ve SignalR ile birlikte anlık mesajlaşma sistemini çalıştırmak için kullandım.
---

## 📂 Dosya ve Mimari Yapısı

Projeyi, **Separation of Concerns (Sorumlulukların Ayrılığı)** prensibine sıkı sıkıya bağlı kalarak **n-tier (çok katmanlı)** bir yapıda tasarladım ve iki ana bağımsız projeye böldüm:

### 1- `RestaurantProject.WebAPILayer` (Sunucu / Backend)
Tüm iş mantığını, doğrulama süreçlerini ve veritabanı işlemlerini yürüttüğüm API katmanıdır.
* **`Context/`**: Veritabanı bağlantı (`ApiContext`) ayarlarını yapılandırdığım klasör.
* **`Entities/`**: Veritabanı tablolarının C# nesnesi olarak karşılıkları.
* **`DTOs/`**: İstemci ile sunucu arasında veri taşımak için oluşturduğum hafifletilmiş nesneler.
* **`Controllers/`**: Gelen HTTP isteklerini karşılayıp yanıt döndüğüm API uç noktaları.
* **`Repositories/` ve `UnitOfWorks/`**: Veritabanı işlemlerini soyutlayarak yönettiğim katman.
* **`FluentValidation/`**: DTO nesneleri için yazdığım özel kural ve validasyon sınıfları.
* **`AutoMapper/`**: Entity ve DTO eşleştirme profillerini tuttuğum klasör.
* **`Migrations/`**: Code-First yaklaşımıyla oluşturduğum veritabanı yansımaları.

### 2- `RestaurantProject.WebUILayer` (İstemci / Frontend)
Son kullanıcının ve yöneticilerin etkileşime girdiği web arayüzünü bu katmanda MVC mimarisiyle kodladım.
* **`Models/` ve `DTOs/`**: UI tarafında kullandığım karşılama nesneleri.
* **`ViewComponents/`**: Kod tekrarını önlemek ve temiz proje yapısı için sayfa içerisinde tekrar kullanılabilir, kendi iş mantığı olan UI parçacıkları.
* **`Areas/`**: Yönetici (Admin) paneline ait modülleri, ana projeden bağımsız bir şekilde izole ettiğim klasör.
* **`ChatHub` / `SignalR`**: Sistemdeki anlık mesajlaşma ve bildirimleri yönettiğim sınıflar.

# 🏠 Anasayfa

<img width="1920" height="1709" alt="Image" src="https://github.com/user-attachments/assets/bd40f892-a61e-4e0c-83af-fc3d7bc4c9e9" />
<img width="1920" height="2261" alt="Image" src="https://github.com/user-attachments/assets/7c06aa8b-181c-4688-b90d-c286437ad0fb" />
<img width="1920" height="2110" alt="Image" src="https://github.com/user-attachments/assets/4ca0493c-2a08-41f1-b411-73aa55886071" />
<img width="1920" height="2847" alt="Image" src="https://github.com/user-attachments/assets/ee5844a6-4553-4d54-a829-e2ed253ba777" />

# 🛠️ Admin Paneli

<img width="1900" height="938" alt="Image" src="https://github.com/user-attachments/assets/e53e6e10-fc79-4c31-985a-4a14525d8e10" />
<img width="1896" height="939" alt="Image" src="https://github.com/user-attachments/assets/a787f32b-bb1e-469d-a3ea-67ed5c1a2cc4" />
<img width="1914" height="937" alt="Image" src="https://github.com/user-attachments/assets/37e122d2-9946-4f3f-b1df-dbba06835f7d" />
<img width="1905" height="939" alt="Image" src="https://github.com/user-attachments/assets/1a244a1c-6956-48ff-bddb-b41a9487f4ab" />
<img width="1912" height="940" alt="Image" src="https://github.com/user-attachments/assets/9545c817-796d-491a-84d3-36ff916ea0fa" />
<img width="1915" height="942" alt="Image" src="https://github.com/user-attachments/assets/7a2238eb-91d5-4850-a9b0-4185e5326ed3" />
<img width="1899" height="938" alt="Image" src="https://github.com/user-attachments/assets/638abe5a-d10c-4881-bace-5a674c718a1c" />
<img width="1917" height="939" alt="Image" src="https://github.com/user-attachments/assets/474f94a5-a45b-4666-849e-f0b9f2ef677a" />
<img width="1914" height="940" alt="Image" src="https://github.com/user-attachments/assets/de3ae013-6bee-4b03-8f47-a34ccfd5d9f0" />
<img width="1899" height="937" alt="Image" src="https://github.com/user-attachments/assets/65c22fee-9605-4371-8260-19dfe3671453" />
<img width="1915" height="937" alt="Image" src="https://github.com/user-attachments/assets/79663bdd-a169-407b-8ba1-d39a52e772ae" />

# 📑 Swagger'da API Endpointleri

<img width="1901" height="935" alt="Image" src="https://github.com/user-attachments/assets/e2f920c6-ba4c-4907-9108-3ba1f34f7540" />
