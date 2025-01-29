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
            Console.WriteLine(filmekList[0]);

            
            UjFilm();
            FilmTorles();
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

        private static void UjFilm()
        {
            Console.WriteLine("Add meg az új film idit: ");
            int ujId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Add meg az új film címét: ");
            string ujCim = Console.ReadLine();
            Console.WriteLine("Add meg az új film kiadási évét: ");
            string ujDate = Console.ReadLine();
            Console.WriteLine("Add meg az új film hosszát: ");
            string ujFilmHossz = Console.ReadLine();
            Console.WriteLine("Add meg az új film direktorát: ");
            string ujFilmDir = Console.ReadLine();
            Console.WriteLine("Add meg az új film főszereplőjét: ");
            string ujFilmFoszerep = Console.ReadLine();
            Console.WriteLine("Add meg az új film értékelését: ");
            string ujFilmErtek = Console.ReadLine();
            Console.WriteLine("Add meg az új film mufaját: ");
            string ujFilmMufaj = Console.ReadLine();

            try
            {
                using (MySqlCommand commandInsert = new MySqlCommand($"insert into movies (id,name,release_date,length,director,main_character,imdb_rating,genre) values ( @id,@name,@release_date,@length,@director,@main_character,@imdb_rating,@genre)", connection))
                {
                    //Paraméterként adjuk meg az utasítás értékeit.
                    commandInsert.Parameters.AddWithValue("@id",ujId);
                    commandInsert.Parameters.AddWithValue("@name",ujCim);
                    commandInsert.Parameters.AddWithValue("@release_date",ujDate);
                    commandInsert.Parameters.AddWithValue("@length",ujFilmHossz);
                    commandInsert.Parameters.AddWithValue("@director",ujFilmDir);
                    commandInsert.Parameters.AddWithValue("@main_character",ujFilmFoszerep);
                    commandInsert.Parameters.AddWithValue("@imdb_rating",ujFilmErtek);
                    commandInsert.Parameters.AddWithValue("@genre",ujFilmMufaj);
                    //parancs végrehajtása:
                    commandInsert.ExecuteNonQuery();

                    Console.WriteLine("Sikeres INSERT!");

                    //Lista újratöltés...
                    KeremAzAdatokat("movies");
                    
                }
            }
            catch (MySqlException mySqlError)
            {
                Console.WriteLine("Sikertelen INSERT");
                Console.WriteLine(mySqlError);
            }
            catch (Exception error)
            {
                Console.WriteLine("Sikertelen INSERT");
                Console.WriteLine(error);
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
