using ListaIndirizzi;

string[] fileLines = File.ReadAllLines("../../../addresses.csv");

List<Address> addresses = new List<Address>();

string[] header = fileLines[0].Split(',');

for (int i = 1; i < fileLines.Length; i++)
{
    string[] values = fileLines[i].Split(',');
    
    try
    {
        if (values.Length == header.Length)
            addresses.Add(new Address(values[0].Trim(), values[1].Trim(), values[2].Trim(), values[3].Trim(), values[4].Trim(), int.Parse(values[5])));
        else
            throw new Exception($"Invalid line ({i}): {fileLines[i]}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine();

Address.Print(header, addresses);
