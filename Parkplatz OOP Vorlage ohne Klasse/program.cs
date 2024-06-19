using System;

namespace Parkplatz
{
    class Program
    {
        static int parkplatzanzahl = 10;
        static void Main(string[] args)
        {
            uint[] stunden = new uint[50] { 7212, 3498, 10000, 1598, 2042, 8326, 4828, 1004, 1697, 228, 1028, 2696, 1526, 687, 3085, 4660, 4084, 2865, 8423, 6485, 9552, 1591, 9734, 9379, 9526, 3263, 4433, 5648, 6603, 8052, 2858, 7470, 7502, 390, 8496, 1622, 257, 2286, 1007, 8000, 5752, 4891, 8143, 7408, 8562, 4728, 4631, 371, 9669, 100 };
            //Array anlegen
            CParkplatz[] LKW = new CParkplatz[parkplatzanzahl];
            //Array bzw. jeden Parkplatz im Array instanzieren
            for (int i = 0; i < parkplatzanzahl; i++)
            {
                LKW[i] = new CParkplatz((uint)i + 1);
                LKW[i].setBelegtstunden(stunden[i]);
            }

            while (true)
            {
                Console.Clear();
                Statusuebersicht(LKW);
                Parkplatzbelegung(LKW);
                Console.ReadKey();
            }
        }

        static void Statusuebersicht(CParkplatz[] LKW)
        {
            Console.WriteLine("Status des Parkplatzes");
            //Parkplatzstatus ausgeben
            for (int i = 0; i < parkplatzanzahl; i++)
            {
                AusgabeEinesParkplatzes(LKW[i]);
            }
        }

        static void Parkplatzbelegung(CParkplatz[] LKW)
        {
            int status = -1;
            int parkzeit = 0;
            int gewuenschterParkplatz = -1;
            gewuenschterParkplatz = Parkplatzauswahl(LKW);

            //Aktionsauswahl
            while ((status < 1 || status > 2) && gewuenschterParkplatz != -1)
            {
                Console.WriteLine("Möchten Sie einen Parkplatz belegen(1) oder reservieren(2)");
                status = Convert.ToInt32(Console.ReadLine());
                switch (status)
                {
                    case 1:
                        Console.WriteLine("Wie lange möchten Sie parken? (in h)");
                        parkzeit = Convert.ToInt32(Console.ReadLine());
                        if (parkzeit >= 1 && parkzeit <= 24)
                        {
                            LKW[gewuenschterParkplatz - 1].setStatus(1);
                            LKW[gewuenschterParkplatz - 1].addBelegtstunden((uint)parkzeit);
                            Console.WriteLine("Sie haben den Parkplatz " + LKW[gewuenschterParkplatz - 1].getParkplatznummer() + " fuer " + parkzeit + " Stunden beleget.");
                        }
                        else
                            Console.WriteLine("Sie dürfen nur zwischen 1 und 24h parken");
                        break;
                    case 2:
                        LKW[gewuenschterParkplatz - 1].setStatus(2);
                        Console.WriteLine("Sie haben den Parkplatz " + LKW[gewuenschterParkplatz - 1].getParkplatznummer() + " reserviert");
                        break;
                    default:
                        Console.WriteLine("Keine gueltige Auswahl\n");
                        break;
                }
            }
        }

        static int Parkplatzauswahl(CParkplatz[] LKW)
        {
            int gewuenschterParkplatz = -1;
            //Parkplatzauswahl
            do
            {
                Console.WriteLine("Welchen Parkplatz möchte Sie belegen/reservieren?");
                gewuenschterParkplatz = Convert.ToInt32(Console.ReadLine());

                if (gewuenschterParkplatz <= 0 || gewuenschterParkplatz > parkplatzanzahl)
                {
                    Console.WriteLine("Diesen Parkplatz gibt es nicht");
                    gewuenschterParkplatz = -1; //damit Eingabe wiederholt werden muss
                }
                else
                {
                    if (LKW[gewuenschterParkplatz - 1].getStatus() != 0)
                    {
                        Console.WriteLine("Parkplatz ist nicht frei");
                        gewuenschterParkplatz = -1; //damit Eingabe wiederholt werden muss
                    }
                }
            } while (gewuenschterParkplatz <= 0 && gewuenschterParkplatz > parkplatzanzahl);
            return gewuenschterParkplatz;
        }

        static void Testausgabe()
        {
            //Testausgaben für einen Testparkplatz
            CParkplatz MeinStellplatz = new CParkplatz(1, 2, 0);
            AusgabeEinesParkplatzes(MeinStellplatz);
            CParkplatz MeinStellplatz2 = new CParkplatz(2, 1, 10);
            AusgabeEinesParkplatzes(MeinStellplatz2);
            CParkplatz MeinStellplatz3 = new CParkplatz(3, 0, 333);
            AusgabeEinesParkplatzes(MeinStellplatz3);
            CParkplatz MeinStellplatz4 = new CParkplatz(4, 3, 5000);
            AusgabeEinesParkplatzes(MeinStellplatz4);
            Console.Write("Testausgabe Ende\n\n");
        }

        static void AusgabeEinesParkplatzes(CParkplatz dieser)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Parkplatz Nr:\t" + dieser.getParkplatznummer() + " ist \t");
            if (dieser.getStatus() == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("belegt \t\t");
            }

            else if (dieser.getStatus() == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("reserviert \t");
            }

            else if (dieser.getStatus() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("frei \t\t");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("fehlbelegt \t");
            }
            Console.Write("mit \t" + dieser.getBelegtstunden() + "\t Belegtstunden\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    class CParkplatz
    {
        //Eigenschaften eines Parkplatzes
        private readonly uint parkplatznummer;
        private uint belegtstunden;
        private uint status;
        //Konstruktor nur mit Nummer des Parkplatzes
        public CParkplatz(uint NummerdesParkplatzes)
        {
            parkplatznummer = NummerdesParkplatzes;
            status = 0;
            belegtstunden = 0;
        }
        //Überladener Konstruktor mit Nummer des Parkplatzes, Status- und Belegtstundeninitialisierung
        public CParkplatz(uint NummerdesParkplatzes, uint anfangsstatus, uint anfangsbelegtstunden)
        {
            parkplatznummer = NummerdesParkplatzes;
            status = anfangsstatus;
            belegtstunden = anfangsbelegtstunden;
        }

        //Getter und Setter-Methoden für Eigenschaften
        public uint getParkplatznummer()
        {
            return parkplatznummer;
        }

        public uint getStatus()
        {
            return status;
        }
        public uint getBelegtstunden()
        {
            return belegtstunden;
        }
        public uint setStatus(uint new_status)
        {
            status = new_status;
            return status;
        }
        public uint addBelegtstunden(uint added_hours)
        {
            belegtstunden += added_hours;
            return belegtstunden;
        }
        public uint setBelegtstunden(uint set_hours)
        {
            belegtstunden = set_hours;
            return belegtstunden;
        }
    }
}
