/*
 Kullanıcıdan pozitif tam sayılar alarak, bu sayıların ortalamasını ve medyanını hesaplayan
bir program yazın. Kullanıcı 0 girene kadar sayıları almaya devam etsin. 0 girildiğinde
ortalamayı ve medyanı gösterin. */ 

using System;
using System.Collections.Generic;

public class Soru2
{
    public static void Main()
    {
        // Giriş: Kullanıcıdan pozitif tam sayılar alacağız.
        Console.WriteLine("Ortalama ve medyan hesaplayan programa hoş geldiniz.");
        Console.WriteLine("Lütfen pozitif tam sayı giriniz. Girilen sayı 0 ise, girilen sayıların ortalaması ve medyanı hesaplanacaktır.");

        List<int> numbers = new List<int>(); // Sayıları saklamak için bir liste oluşturuyoruz.
        int number; // Kullanıcının girdiği sayıyı tutacak değişken.

        do
        {
            // Kullanıcıdan pozitif tam sayı girmesini istiyoruz.
            Console.Write("Pozitif tam sayı giriniz (çıkmak için 0 girin): ");
            number = Convert.ToInt32(Console.ReadLine()); // Kullanıcının girdiği değeri alıyoruz.

            // Kontrol: Girilen sayı pozitifse listeye ekle.
            if (number > 0)
            {
                numbers.Add(number); // Pozitif tam sayıyı listeye ekle.
            }
            // Kontrol: Girilen sayı negatifse uyarı ver.
            else if (number < 0)
            {
                Console.WriteLine("Lütfen yalnızca pozitif tam sayılar giriniz."); // Hatalı giriş için mesaj.
            }
        } while (number != 0); // Kullanıcı 0 girmedikçe döngüyü devam ettir.

        // Çıkış: Kullanıcı 0 girdiğinde, sonuçları hesapla ve göster.
        if (numbers.Count > 0) // Eğer liste boş değilse.
        {
            // Matematik: Ortalama hesaplama.
            Console.WriteLine("Girdiğiniz sayıların ortalaması: " + Ortalama(numbers));
            // Matematik: Medyan hesaplama.
            Console.WriteLine("Girdiğiniz sayıların medyanı: " + Medyan(numbers));
        }
        else
        {
            Console.WriteLine("Hiçbir pozitif tam sayı girmediniz."); // Eğer kullanıcı hiç sayı girmediyse mesaj.
        }
    }

    // Matematik: Ortalamayı hesaplayan metod.
    public static double Ortalama(List<int> numbers)
    {
        double toplam = 0; // Toplamı tutacak değişken.

        // Kontrol: Listedeki her bir sayı için toplamı hesapla.
        for (int i = 0; i < numbers.Count; i++)
        {
            toplam += numbers[i]; // Sayıları topluyoruz.
        }

        // Çıkış: Toplamı sayı adedine bölerek ortalamayı hesaplıyoruz.
        return (toplam / numbers.Count);
    }

    // Matematik: Medyanı hesaplayan metod.
    public static double Medyan(List<int> numbers)
    {
        // Kendi sıralama algoritmamızı uygulayalım 
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            for (int j = 0; j < numbers.Count - 1 - i; j++)
            {
                // Kontrol: Eğer soldaki eleman sağdaki elemandan büyükse yer değiştir.
                if (numbers[j] > numbers[j + 1])
                {
                    // Yer değiştir.
                    int temp = numbers[j]; // Geçici değişkene atama.
                    numbers[j] = numbers[j + 1]; // Sağdaki elemanı sola atama.
                    numbers[j + 1] = temp; // Soldaki elemanı sağa atama.
                }
            }
        }

        // Matematik: Medyan hesaplama.
        if (numbers.Count % 2 == 0) // Eğer eleman sayısı çiftse.
        {
            int midIndex1 = numbers.Count / 2; // Ortadaki eleman index'i.
            int midIndex2 = midIndex1 - 1; // Bir önceki eleman index'i.
            return (numbers[midIndex1] + numbers[midIndex2]) / 2.0; // İki ortalama elemanı toplayıp ikiye böl.
        }
        else // Eğer eleman sayısı tekse.
        {
            int midIndex = numbers.Count / 2; // Ortadaki eleman index'i.
            return numbers[midIndex]; // Ortadaki elemanı döndür.
        }
    }
}
