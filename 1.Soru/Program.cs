/*
 Kullanıcıdan bir dizi tam sayı alın ve bu sayıları sıralayın. Ardından, kullanıcıdan bir sayı
alın ve bu sayının dizide olup olmadığını ikili arama algoritması ile kontrol edin. Sonucu
ekrana yazdırın. 
*/


using System;

public class ArraySorting
{
    public static void Main()
    {
        // Giriş: Kullanıcıdan dizinin uzunluğunu al
        Console.WriteLine("Lütfen int tipindeki dizinin uzunluğunu giriniz: ");
        int arrayLength = Convert.ToInt32(Console.ReadLine()); // Kullanıcıdan dizi uzunluğunu al
        int[] numbersArray = new int[arrayLength]; // Belirtilen uzunlukta bir dizi oluştur

        // Giriş: Kullanıcıdan dizinin elemanlarını al
        Console.WriteLine("Dizinin elemanlarını giriniz: ");
        for (int index = 0; index < arrayLength; index++)
        {
            // Kullanıcıdan her bir elemanı al
            Console.Write($"Dizinin {index + 1}. elemanını giriniz: ");
            numbersArray[index] = Convert.ToInt32(Console.ReadLine()); // Elemanı diziye ekle
        }

        // Çıkış: Diziyi sıralamak için metodu çağır
        Console.WriteLine("Diziniz sıralanıyor...");
        SortArrayAscending(numbersArray); // Artan sıralama metodu çağrılıyor

        // Çıkış: Sıralanmış diziyi ekrana yazdır
        Console.WriteLine("Sıralanmış dizi: ");
        for (int j = 0; j < arrayLength; j++)
        {
            Console.Write(numbersArray[j] + " "); // Her bir elemanı yazdır
        }
        Console.WriteLine(); // Yeni satır ekle

        // Giriş: Kullanıcıdan aranacak değeri al
        Console.Write("Aranan elemanı giriniz: ");
        int searchValue = Convert.ToInt32(Console.ReadLine()); // Kullanıcıdan aramak istediği değeri al

        // Kontrol: BinarySearch metodunu çağır
        BinarySearch(numbersArray, searchValue); // Dizi içinde arama yapılıyor
    }

    // Matematik adımları: Artan sıralama metodu
    static void SortArrayAscending(int[] array) // Parametre olarak dizi alır
    {
        int temp; // Geçici değişken tanımla
        // Kontrol: Dizinin elemanlarını karşılaştırarak sıralama yap
        for (int j = 0; j < array.Length; j++)
        {
            for (int k = j + 1; k < array.Length; k++)
            {
                // Eğer ikinci eleman daha küçükse yer değiştir
                if (array[k] < array[j]) // Küçükten büyüğe sıralama
                {
                    temp = array[k]; // Geçici değişkene atama
                    array[k] = array[j]; // Yer değiştir
                    array[j] = temp; // Yer değiştir
                }
            }
        }
    }

    // Kontrol: Binary Search metodu
    static void BinarySearch(int[] array, int searchValue) // Aranacak değer parametre olarak alınır
    {
        int low = 0; // Alt sınır
        int high = array.Length - 1; // Üst sınır

        // Tekrar: Sıralı dizi içinde arama yapılır
        while (low <= high) // Alt sınır üst sınırdan küçük veya eşit olduğu sürece devam et
        {
            int mid = (low + high) / 2; // Ortada bir eleman seç

            // Kontrol: Ortadaki eleman aranılan değerle eşitse
            if (array[mid] == searchValue) // Eğer bulunduysa
            {
                Console.WriteLine("Aranan eleman bulundu"); // Bulundu mesajı
                return; // Bulunduğunda döngüyü sonlandır
            }
            // Kontrol: Ortadaki eleman aranılan değerden büyükse
            else if (array[mid] > searchValue)
            {
                high = mid - 1; // Üst sınırı güncelle
            }
            else
            {
                low = mid + 1; // Alt sınırı güncelle
            }
        }

        // Çıkış: Aranılan değer dizide yoksa mesaj ver
        Console.WriteLine("Aranan değer dizide bulunmadı"); // Bulunmadı mesajı
    }
}
