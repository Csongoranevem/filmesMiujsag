using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace filmesMiujsag
{
    internal class Program
    {
        static List<Mozik> moziLista = new List<Mozik>();
        private static string server = "localhost";
        private static string database = "filmeses_miujsag";
        private static string user = "root";
        private static string password = "";
        private static List<Filmek> filmekList = new List<Filmek>();

        private static string connectionString = $"Server={server};Database={database};User ID={user};Password={password};";
        public static MySqlConnection connection = new MySqlConnection(connectionString);


        static void Main(string[] args)
        {

            KapcsolodasAdatbazishoz();
            KeremAzAdatokat("movies");
            FileBeolvas();
            Console.WriteLine(filmekList[30]);

            Console.ReadKey();




            void KapcsolodasAdatbazishoz()
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Kapcsolat sikeresen megnyitva.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hiba a kapcsolat megnyitásakor: " + ex.Message);
                }
            }


        }

        private static void FileBeolvas()
        {
            string[] adatTomb = File.ReadAllLines("fajl.txt");
            for (int i = 0; i < adatTomb.Length; i++)
            {
                string nev = adatTomb[i].Split(';')[0];
                string cim = adatTomb[i].Split(';')[1];
                string varos = adatTomb[i].Split(';')[2];
                int feroHely = Convert.ToInt32(adatTomb[i].Split(';')[3]);
                string nyitvaTart = adatTomb[i].Split(';')[4];

                Mozik mozi = new Mozik(nev, cim, varos, feroHely, nyitvaTart);
                moziLista.Add(mozi);
            }
            Console.WriteLine(moziLista[0]);
            Console.ReadLine();
        }

        private static void KeremAzAdatokat(string tableName)
        {
            using (MySqlCommand command = new MySqlCommand($"select * from {tableName}", connection))
            {
                filmekList.Clear();
                using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        Filmek filmBeilleszt = new Filmek(Convert.ToInt32(mySqlDataReader[0]),
                                                         Convert.ToString(mySqlDataReader[1]),
                                                         Convert.ToDateTime(mySqlDataReader[2]),
                                                         Convert.ToString(mySqlDataReader[3]),
                                                         Convert.ToString(mySqlDataReader[4]),
                                                         Convert.ToString(mySqlDataReader[5]),
                                                         Convert.ToDouble(mySqlDataReader[6]),
                                                         Convert.ToString(mySqlDataReader[7]));


                        filmekList.Add(filmBeilleszt);

                    }
                }
            }
        }
    }
}
