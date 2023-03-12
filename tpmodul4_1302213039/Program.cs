using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static mod4_1302213039.program.doormachine;

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
            doormachine Pintu = new doormachine();
            Pintu.trigeraktif(Trigger.pintu_kunci);
            Pintu.trigeraktif(Trigger.pintu_buka);
            Pintu.trigeraktif(Trigger.pintu_kunci);
            Pintu.trigeraktif(Trigger.pintu_kunci);
            Pintu.trigeraktif(Trigger.pintu_buka);
            Pintu.trigeraktif(Trigger.pintu_buka);

            Console.WriteLine("\n----------------------------");
            dataKota dkota = dataKota.Batununggal;
            int kode = getKodePos.kode(dkota);
            Console.WriteLine("Kelurahan: " + dkota + "\nkodepos: " + kode);
        }

        public enum pintu
        {
            terkunci,
            terbuka
        }
        public enum Trigger
        {
            pintu_buka,
            pintu_kunci
        }


        public class doormachine
        {
            public pintu current = pintu.terkunci;
            public class Transisi
            {
                public pintu stateawal;
                public pintu stateakhir;
                public Trigger trigger;
                public Transisi(pintu stateawal, pintu stateakhir, Trigger trigger)
                {
                    this.stateawal = stateawal;
                    this.stateakhir = stateakhir;
                    this.trigger = trigger;
                }
            }

            Transisi[] trans ={
                new Transisi(pintu.terkunci, pintu.terbuka, Trigger.pintu_buka),
                new Transisi(pintu.terbuka, pintu.terkunci, Trigger.pintu_kunci),
                new Transisi(pintu.terbuka, pintu.terbuka, Trigger.pintu_buka),
                new Transisi(pintu.terkunci, pintu.terkunci, Trigger.pintu_kunci)
            };

            private pintu getstateberikutnya(pintu stateawal, Trigger trigger)
            {
                pintu stateakhir = stateawal;
                for (int i = 0; i < trans.Length; i++)
                {
                    Transisi perubahan = trans[i];
                    if (stateawal == perubahan.stateawal && trigger == perubahan.trigger)
                    {
                        stateakhir = perubahan.stateakhir;
                    }
                }
                return stateakhir;

            }
            public void trigeraktif(Trigger trigger)
            {
                current = getstateberikutnya(current, trigger);
                Console.WriteLine("Pintu sekarang " + current);
                if (current == pintu.terkunci)
                {
                    Console.Write("Pintu terkunci");
                }
                else if (current == pintu.terbuka)
                {
                    Console.Write("Pintu tidak terkunci");
                }
            }
        }
    }
}