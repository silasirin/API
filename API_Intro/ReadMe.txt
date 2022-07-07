1- Blank solution actik.

2- ASP .NET web application secilip Web Api secildi ve proje olusturduk.

3- Controllers klasorune sag tiklanip controller > Web Api secilir.

4- Olusturulan method'un httpget olmasi gerekiyor ki calistirdigimizda yazilan yaziyi gorebilelim. Veya methodun ismi Get ile baslamali (GetSampleValues gibi)

5- Link uzantisi su sekilde yazilmali: https://localhost:44302/api/home (/api/controllerin adi)

6- Postman indirildi. (Disable SSL verification'a tiklanmali, Get secilip link yazilir, linke tiklanir.)

7- Models icerisinde Product Class'i olusturuldu.

8- Controllers klasoru icinde Products isminde API Controller olusturuldu. (Bir standart olarak; API Controller'lar cogul olusturulur.Simdilik tekil olusturduk.)
**Postman'de calisabilmesi icin projenin calistiriliyor olmasi gerekli!

9- HttpResponseMessage donus tipiyle bir method tanimlandi.

10- HttpStatusCode > Go to Definition tiklandiginda tum mesajlara ulasilir.

11- Category adinda bir class acildi ve Web API Controller'i olusturuldu.




