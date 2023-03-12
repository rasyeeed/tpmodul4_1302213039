using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mod4_1302213039
{
    internal class program
    {
        public enum dataKota
        {
            Batununggal,
            Kujangsari,
            Mengger,
            Wates,
            Cijaura,
            Jatisari,
            Margasari,
            Sekejati,
            Kebonwaru,
            Maleer,
            Samoja
        };
        public class getKodePos
        {
            public static int kode(dataKota kota)
            {
                int[] kodepos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273 };
                return kodepos[(int)kota];
            }
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("----------------------------");
            dataKota dkota = dataKota.Batununggal;
            int kode = getKodePos.kode(dkota);
            Console.WriteLine("Kelurahan: " + dkota + "\nkodepos: " + kode);
        }
    }
}