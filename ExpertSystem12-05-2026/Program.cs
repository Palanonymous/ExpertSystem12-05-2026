using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    // Method untuk Pertanyaan
    static string Tanya(string pertanyaan)
    {
        Console.Write(pertanyaan);
        return Console.ReadLine().ToLower();
    }

    // Method untuk menghitung Certainty Factory
    static double HitungCF(double cfLama, double cfBaru)
    {
        return cfLama + cfBaru * (1 - cfLama);
    }

    // Method untuk menampilkan hasil/kesimpulan
    static void TampilHasil(string performa, double cf)
    {
        Console.WriteLine();
        Console.WriteLine("=== HASIL ===");
        Console.WriteLine("performa   : " + performa);
        Console.WriteLine("CF         : " + (cf * 100).ToString("F0") + "%");

        // Explanation Facility
        if (performa == "PRO")
        {
            Console.WriteLine("Alasan: Player sangat cepat dan survivability tinggi.");
        }
        if (performa == "Average")
        {
            Console.WriteLine("Alasan: Kemampuan player cukup seimbang.");
        }
        if (performa == "Noob")
        {
            Console.WriteLine("Alasan: Player masih sering gagal atau mati.");
        }
        else if (performa == "SKILL ISSUE")
        {
            Console.WriteLine("Alasan: Player Punya Skill Issue (Buruk dalam semua hal)");

        }
    }

    static void Main()
    {
        Console.WriteLine("=== Sistem Pakar Penilaian Performa Player ===");
        Console.WriteLine();

        string q1 = Tanya("Player clear tanpa mati? (y/n): ");
        string q2 = "";
        string q3 = "";

        // Decision Tree
        if (q1 == "y")
        {
            q2 = Tanya("Dungeon selesai kurang dari 10 menit? (y/n): ");

            if (q2 == "y")
            {
                q3 = Tanya("HP tersisa lebih dari 70%? (y/n): ");
            }
            if (q2 == "n")
            {
                q3 = Tanya("HP yang tersisa lebih dari 50%? (y/n):");
            }
        }
        if (q1 == "n")
        {
            q2 = Tanya("Player mati lebih dari 3 kali? (y/n): ");

            if (q2 == "y")
            {
                q3 = Tanya("Level karakter di bawah level 5? (y/n): ");
            }
            if (q2 == "n")
            {
                q3 = Tanya("Player menggunakan lebih dari 3 potion? (y/n): ");
            }
        }

        // Forward Chaining Hasil untuk Performa
        string performa = "";

        if (q1 == "y")
        {
            if (q2 == "y")
            {
                if (q3 == "y")
                {
                    performa = "PRO";
                }
                else
                {
                    performa = "Average";
                }
            }
            else
            {
                if (q3 == "y")
                {
                    performa = "Average";
                }
                else
                {
                    performa = "Noob";
                }
            }
        }
        else
        {
            if (q2 == "y")
            {
                if (q3 == "y")
                {
                    performa = "Average";

                }
                else
                {
                    performa = "Noob";
                }
            }
            if (q1 == "n")
            {
                if (q3 == "y")
                {
                    performa = "Noob";
                }
                else
                {
                    performa = "SKILL ISSUE";
                }
            }
            else
            {

            }
        }

        // Certainty Factor berdasarkan jawaban yang terisi
        double cf = 0;

        if (q1 == "y" || q1 == "n")
        {
            cf = HitungCF(cf, 0.4);
        }
        if (q2 == "y" || q2 == "n")
        {
            cf = HitungCF(cf, 0.6);
        }
        if (q3 == "y" || q3 == "n")
        {
            cf = HitungCF(cf, 0.8);
        }

        // TAMPIL HASIL
        TampilHasil(performa, cf);

        Console.ReadLine();
    }
}