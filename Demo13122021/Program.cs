using System.Xml;
using Demo11122021;
using MySqlConnector;
namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Country> listCountries = new List<Country>();
                string xmlDocument = File.ReadAllText(@"C:\Users\Arturs Olekss\Documents\NET_lessons\NET_80\Files\file.xml");
                XmlDocument xmlDataDocument = new XmlDocument();
                xmlDataDocument.LoadXml(xmlDocument);
                XmlNodeList countryListNodes = xmlDataDocument.GetElementsByTagName("Country");
                foreach (XmlElement countryNode in countryListNodes)
                {
                    Country country = new Country();
                    country.ID = Int32.Parse(countryNode.GetAttribute("ID"));
                    foreach (XmlElement countryElement in countryNode)
                    {
                        string elementText = countryElement.InnerText;
                        switch (countryElement.Name)
                        {
                            case "Name":
                                country.Name = elementText;
                                break;
                            case "GDP":
                                country.GDP = Double.Parse(elementText);
                                break;
                            case "CapitalCity":
                                country.Capital = elementText;
                                break;
                            case "Currency":
                                country.Currency = elementText;
                                break;
                        }
                    }
                    listCountries.Add(country);
                }

                Migrate(listCountries);
                //Console.WriteLine("Please provide the ID of the country:");
                //int id = Int32.Parse(Console.ReadLine());
                //var countryResultEn = listCountries.Where(x => x.ID == id).ToList<Country>()[0];
                //Console.WriteLine(countryResultEn);

                //foreach (var country in listCountries)
                //    Console.WriteLine(country);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        static void Migrate(List<Country> countries)
        {
            MySqlConnection con = new MySqlConnection("Data Source=localhost;User ID=root;Database=dotnet2");
            con.Open();
            foreach (Country country in countries)
            {
     
                string query = "INSERT INTO countries (`Name`, `Capital`, `Currency`, `GDP`, `External_ID`) " +
                    "VALUES (@name,@capital,@currency,@gdp,@external_id)";
                MySqlParameter nameParam = new MySqlParameter("@name", MySqlDbType.VarChar);
                MySqlParameter capital = new MySqlParameter("@capital", MySqlDbType.VarChar);
                MySqlParameter currency = new MySqlParameter("@currency", MySqlDbType.VarChar);
                MySqlParameter gdp = new MySqlParameter("@gdp", MySqlDbType.Double);
                MySqlParameter extId = new MySqlParameter("@external_id", MySqlDbType.Int32);
                extId.Value = country.Name;
                var command = new MySqlCommand(query, con);
                command.Parameters.Add(nameParam);

                command.Parameters.Add(capital);
                command.Parameters[1].Value = country.Capital;

                command.Parameters.Add(currency);
                command.Parameters[2].Value = country.Currency;

                command.Parameters.Add(gdp);
                command.Parameters[3].Value = country.GDP;

                command.Parameters.Add(extId);
                command.Parameters[4].Value = country.ID;

                command.Prepare();
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

            }
            con.Close();
        }
    }
}
