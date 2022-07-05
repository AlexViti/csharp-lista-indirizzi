using ListaIndirizzi;


StreamReader reader = new StreamReader("../../../addresses.csv");

List<Address> addresses = new List<Address>();

string header = reader.ReadLine();

while (!reader.EndOfStream)
{
    string line = reader.ReadLine();
    string[] values = line.Split(',');
    if (values.Length == header.Split(",").Length)
    {
        addresses.Add(new Address(values[0].Trim(), values[1].Trim(), values[2].Trim(), values[3].Trim(), values[4].Trim(), int.Parse(values[5])));
    }
}

reader.Close();

int[] cellsWidth = new int[header.Split(",").Length];
foreach (Address address in addresses)
{
    for (int i = 0; i < cellsWidth.Length; i++)
    {
        if (cellsWidth[i] < address.GetType().GetProperty(header.Split(",")[i]).GetValue(address).ToString().Length)
        {
            cellsWidth[i] = address.GetType().GetProperty(header.Split(",")[i]).GetValue(address).ToString().Length;
        }
    }
}
foreach (Address address in addresses)
{
    for (int i = 0; i < cellsWidth.Length; i++)
    {
        Console.Write(address.GetType().GetProperty(header.Split(",")[i]).GetValue(address).ToString().PadRight(cellsWidth[i]));
        if (i < cellsWidth.Length - 1)
        {
            Console.Write("\t");
        }
    }
    Console.WriteLine();
}