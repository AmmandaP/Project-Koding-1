using System;
using System.Collections.Generic;

class Program
{
    static List<(string Nama, string Penulis, bool Status)> daftarBuku = new List<(string, string, bool)>();

    static void Main()
    {
        int pilihan;

        do
        {
            TampilkanMenu();
            Console.Write("Pilihan: ");
            pilihan = Convert.ToInt32(Console.ReadLine());

            switch (pilihan)
            {
                case 1:
                    LihatDataBuku();
                    break;
                case 2:
                    TambahDataBuku();
                    break;
                case 3:
                    UbahStatusBuku();
                    break;
                case 4:
                    HapusDataBuku();
                    break;
                case 0:
                    Console.WriteLine("Program selesai.");
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }
        } while (pilihan != 0);
    }

    static void TampilkanMenu()
    {
        Console.WriteLine("\nPERPUSTAKAAN");
        Console.WriteLine("Menu");
        Console.WriteLine("1. Lihat Data Buku");
        Console.WriteLine("2. Tambah Data Buku");
        Console.WriteLine("3. Ubah Status Buku");
        Console.WriteLine("4. Hapus Data Buku");
        Console.WriteLine("0. Exit");
    }

    static void LihatDataBuku()
    {
        Console.WriteLine("\nLIHAT DATA BUKU");
        Console.WriteLine("TAMPILAN");
        Console.WriteLine("=================");

        for (int i = 0; i < daftarBuku.Count; i++)
        {
            var buku = daftarBuku[i];
            Console.WriteLine($"ID Buku: {i + 1}");
            Console.WriteLine($"Nama Buku: {buku.Nama}");
            Console.WriteLine($"Penulis: {buku.Penulis}");
            Console.WriteLine($"Status: {(buku.Status ? "Dipinjam" : "Tidak Dipinjam")}");
            Console.WriteLine("=================");
        }
    }

    static void TambahDataBuku()
    {
        Console.WriteLine("\nTAMBAH DATA BUKU");
        Console.Write("Masukkan Nama Buku: ");
        string nama = Console.ReadLine();
        Console.Write("Masukkan Penulis: ");
        string penulis = Console.ReadLine();

        TambahBuku(nama, penulis, false);

        Console.WriteLine("Data buku berhasil ditambahkan.");
    }

    static void UbahStatusBuku()
    {
        Console.WriteLine("\nUBAH STATUS BUKU");
        Console.Write("Masukkan ID Buku: ");
        int idBuku = Convert.ToInt32(Console.ReadLine());

        if (idBuku >= 1 && idBuku <= daftarBuku.Count)
        {
            var buku = daftarBuku[idBuku - 1];
            UbahStatusBuku(idBuku - 1, !buku.Status);
            Console.WriteLine("Status buku berhasil diubah.");
        }
        else
        {
            Console.WriteLine("ID Buku tidak valid.");
        }
    }

    static void HapusDataBuku()
    {
        Console.WriteLine("\nHAPUS DATA BUKU");
        Console.Write("Masukkan ID Buku: ");
        int idBuku = Convert.ToInt32(Console.ReadLine());

        if (idBuku >= 1 && idBuku <= daftarBuku.Count)
        {
            HapusBuku(idBuku - 1);
            Console.WriteLine("Data buku berhasil dihapus.");
        }
        else
        {
            Console.WriteLine("ID Buku tidak valid.");
        }
    }

    static void TambahBuku(string nama, string penulis, bool status)
    {
        daftarBuku.Add((nama, penulis, status));
    }

    static void UbahStatusBuku(int index, bool status)
    {
        var buku = daftarBuku[index];
        daftarBuku[index] = (buku.Nama, buku.Penulis, status);
    }

    static void HapusBuku(int index)
    {
        daftarBuku.RemoveAt(index);
    }
}
