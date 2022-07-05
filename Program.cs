using ListaIndirizzi;


StreamReader reader = new StreamReader("../../../addresses.csv");

List<Address> addresses = new List<Address>();

string header = reader.ReadLine();

while (!reader.EndOfStream)
{
    string line = reader.ReadLine();
    string[] values = line.Split(',');
    string name = values[0];
    string surname = values[1];
    string street = values[2];
    string city = values[3];
    string province = values[4];
    string zipString = values[5];
    int zip = int.Parse(zipString);
    addresses.Add(new Address(name, surname, street, city, province, zip));
}

reader.Close();

foreach (Address address in addresses)
{
    address.Print();
}