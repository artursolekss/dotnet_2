using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace Demo11122021
{
    class Program
    {
        enum myEnum
        {
            Active,
            Cancelled,
            Done
        }

        static void Main(string[] args)
        {
            List<string> listAllStatesFromTheFile = new List<string>();

            string json = File.ReadAllText(@"C:\Users\Arturs Olekss\Documents\NET_lessons\NET_80\Files\fileJSONTest2.json");
            //Console.WriteLine(json);
            //List<Country> countryList;
            //countryList = JsonSerializer.Deserialize<List<Country>>(json);
            //foreach (var element in countryList)
            //    Console.WriteLine(element);

            JsonDocument jsonDocument = JsonDocument.Parse(json);
            JsonElement root = jsonDocument.RootElement;
            //Console.WriteLine(root);
            JsonElement.ArrayEnumerator arrEn = root.EnumerateArray();
            foreach (var elemn in arrEn)
            {
                try
                {
                    JsonElement.ArrayEnumerator states =
                         elemn.GetProperty("Federal States").EnumerateArray();
                    foreach (var state in states)
                        listAllStatesFromTheFile.Add(state.ToString());
                }
                catch (System.Collections.Generic.KeyNotFoundException exc)
                {
                    continue;//move to the next one
                }

            }
            foreach (var element in listAllStatesFromTheFile)
                Console.WriteLine(element);

        }

        static void Main2(string[] args)//called this method as Main2, just to skip executing it
        {
            string csvFile =
                File.ReadAllText(@"C:\Users\Arturs Olekss\Documents\NET_lessons\NET_80\Files\fileCSV.csv");

            List<Country> countryList = new List<Country>();
            string[] rows = csvFile.Split('\n');//split the string by lines
            string[] headerLine = rows[0].Split(";");//find the positions of the columns here
            Dictionary<string, int> columnMap = new Dictionary<string, int>();
            columnMap.Add(headerLine[0], 0);
            columnMap.Add(headerLine[1], 1);
            columnMap.Add(headerLine[2], 2);
            columnMap.Add(headerLine[3], 3);
            columnMap.Add(headerLine[4], 4);

            bool skipFirstLine = true;
            for (int i = 0; i < rows.Length; i++)
            {
                if (skipFirstLine && i == 0)
                    continue;//go to the next iteration

                string[] currentRow = rows[i].Split(';');//I get the row elements stored under the current array
                if (currentRow.Length < 5)//if the row has less elements, then we skip this line
                    continue;

                Country country = new Country();
                //country.Name = currentRow[1];
                //country.ID = Int32.Parse(currentRow[0]);
                //country.Capital = currentRow[2];
                //country.Currency = currentRow[3];
                //country.GDP = Double.Parse(currentRow[4]);
                country.Name = currentRow[columnMap["Name"]];//columnMap will return the index/position of the column
                country.ID = Int32.Parse(currentRow[columnMap["ID"]]);
                country.Capital = currentRow[columnMap["Capital"]];
                country.Currency = currentRow[columnMap["Currency"]];
                country.GDP = Double.Parse(currentRow[columnMap["GDP"]]);

                countryList.Add(country);

            }

            //foreach (var country in countryList)
            //    Console.WriteLine(country);


            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All);

            string json = JsonSerializer.Serialize(countryList, options);
            Console.WriteLine(json);
            File.WriteAllText(@"C:\Users\Arturs Olekss\Documents\NET_lessons\NET_80\Files\myConvertCsvToJson.json", json, System.Text.Encoding.UTF8);

        }
    }

    class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Currency { get; set; }
        public double GDP { get; set; }

        public override string ToString()
        {
            return "Name:" + this.Name + ",Capital City:" + this.Capital + ",Currency:" + this.Currency + ",GDP:" + this.GDP;
        }
    }
}
