using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaIndirizzi
{
    internal class Address
    {
        // Name,Surname,Street,City,Province,ZIP
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int ZIP { get; set; }

        public Address(string name, string surname, string street, string city, string province, int zip)
        {
            Name = name;
            Surname = surname;
            Street = street;
            City = city;
            Province = province;
            ZIP = zip;
        }

        public string PaddedZIP()
        {
            return ZIP.ToString().PadLeft(5, '0');
        }

        public void Print()
        {
            Console.WriteLine("{0} {1} {2} {3} {4} {5}", Name, Surname, Street, City, Province, PaddedZIP());
        }

        public static void Print(string[] header, List<Address> addresses)
        {
            int[] cellsWidth = new int[header.Length];
            foreach (Address address in addresses)
            {
                for (int i = 0; i < cellsWidth.Length; i++)
                {
                    int width = address.GetType().GetProperty(header[i]).GetValue(address).ToString().Length;

                    if (cellsWidth[i] < width)
                        cellsWidth[i] = width;
                }
                int index = addresses.IndexOf(address);
                if (cellsWidth[index] < header[index].Length)
                    cellsWidth[index] = header[index].Length;
            }
            
            for (int i = 0; i < cellsWidth.Length; i++)
            {
                Console.Write(header[i].PadRight(cellsWidth[i]));
                if (i < cellsWidth.Length - 1)
                    Console.Write("\t");
            }

            string separator = "\n";
            for (int i = 0; i < cellsWidth.Length; i++)
                separator += "-" + new string('-', cellsWidth[i]) + "-\t";

            Console.WriteLine(separator);

            foreach (Address address in addresses)
            {
                for (int i = 0; i < cellsWidth.Length; i++)
                {
                    Console.Write(address.GetType().GetProperty(header[i]).GetValue(address).ToString().PadRight(cellsWidth[i]));

                    if (i < cellsWidth.Length - 1)
                        Console.Write("\t");
                }
                Console.WriteLine();
            }
        }
    }
}
