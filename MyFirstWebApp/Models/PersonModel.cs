using MySqlConnector;
namespace MyFirstWebApp.Models
{
    public class PersonModel
    {
        private MySqlConnection con 
            = new MySqlConnection("Data Source=localhost;User ID=root;Database=dotnet2");

        public string Name { get; set; }
        public string Surname { get; set; }
        public void OpenConnection()
        {
            if(this.con.State == System.Data.ConnectionState.Closed)
            this.con.Open();
        }
        public void AddToDatabase()
        {
            string query = "INSERT INTO persons (name,surname) VALUES (@name,@surname)";
            MySqlParameter nameParam = new MySqlParameter("@name", MySqlDbType.Text);
            nameParam.Value = this.Name;

            MySqlParameter surnameParam = new MySqlParameter("@surname", MySqlDbType.Text);
            surnameParam.Value = this.Surname;

            var command = new MySqlCommand(query, this.con);
            command.Parameters.Add(nameParam);
            command.Parameters.Add(surnameParam);
            command.Prepare();
            command.ExecuteNonQuery();

            this.Name = null;
            this.Surname = null;
            this.con.Close();
        }

        public override string ToString()
        {
            return this.Name + " " + this.Surname;
        }

        public List<PersonModel> GetPersons()
        {
            this.OpenConnection();
            var command = new MySqlCommand("SELECT * FROM persons", this.con);
            var reader = command.ExecuteReader();
            List<PersonModel> people = new List<PersonModel>();
            while (reader.Read())
            {
                PersonModel person = new PersonModel();
                person.Name = reader.GetString(1);
                person.Surname = reader.GetString(2);
                people.Add(person);
            }
            this.con.Close();
            return people;
        }

    }
}
