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

Address.Print(header.Split(","), addresses);
