# personal-contact-record
Proje 3 mikro servisten olusmaktadir.
Kullanıcı, rehbere ilgili endpointlerden kişi ekler. 
Eklenen kişiye detay bilgileri ekleyebilir,silebilir,getirebilir.
Kullanıcı isteği lokasyona ait bilgileri görmek için istek gönderir, istek dbye kayit edilir, aynı zamanda kuyruğa yazılır.
Kuyruğa yazılan istek worker servis tarafından tüketilir, gerekli işlemleri yapar ve dbde kayıtlı olan raporun statüsünü hazırlanıyordan, tamamlandıya çeker. 

1-Person.Api
 Bu servis, iletişim bilgilerini ve kişi yönetimini sağlar. Aşağıda özetlenen temel özelliklere sahiptir;
 Tüm servislerde başarılı yanıtı 200 dönmektedir. İstenirse spesifik responselara çevirilebilir.

-İletişim Bilgisi

Ekleme: POST /api/ContactInformation
İstek Gövdesi: ContactInformationCreateDto
Getirme: GET /api/ContactInformation

Silme: DELETE /api/ContactInformation
Parametre: id (uuid)

-Kişiler
Kişi Ekleme: POST /api/Persons/AddPerson

İstek Gövdesi: PersonCreateDto
Kişi Getirme: GET /api/Persons/GetPerson

Kişi ve İletişim Bilgisi Getirme: GET /api/Persons/GetPersonWithContactInfo

Kişi Silme: DELETE /api/Persons/DeletePerson
Parametre: personId (uuid)

Veri Modelleri
İletişim Bilgisi Oluşturma
{
  "personID": "uuid",
  "phone": "string",
  "location": "string",
  "email": "string"
}
Kişi Oluşturma
{
  "firstName": "string",
  "lastName": "string",
  "company": "string"
}


2-Report.Api
Bu servis, rapor taleplerini yönetir. Kullanıcıdan gelen requesti, önce dbye sonrasında kuyruda gönderir. İlgili özelliklere sahip temel özelliklere sahiptir:

Rapor Talebi Oluşturma: POST /api/Report/ReportRequest
İstek Gövdesi: ReportRequestDto
Rapor Durumunu Getirme: GET /api/Report/GetReportStatus
Raporları Getirme: GET /api/Report/GetReports
Veri Modelleri
Rapor Talep Veri Transfer Objesi
{
  "location": "string"
}

3-PrepareReport.Api
Bu servis, rapor taleplerine göre istenilen raporları hazırlar. Kuyruğa yazılan talebi tüketir, gerekli işlemleri yapar. Kuyruk sürekli dinleme modunda çalışır.


Teknolojiler ve Framework'ler:
Backend Framework: .NET Core
Veritabanı: PostgreSQL
Message Broker: RabbitMQ


Veritabanı Şeması:
Raporlar Tablosu: Reports
Rapor Detayları Tablosu: ReportDetails
Kişiler Tablosu: Persons
İletişim Bilgileri Tablosu: ContactInformation

DB Migrationa PrepareReport.Api den ulaşılabilir.