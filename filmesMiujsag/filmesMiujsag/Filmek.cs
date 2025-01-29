using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filmesMiujsag
{
    internal class Filmek
    {
        private int Id { get; set; }
        public int id { get {  return Id; } }
        private string Name { get; set; }
        public string name { get { return Name; } }
        private DateTime ReleaseDate { get; set; }
        public DateTime releaseDate { get { return ReleaseDate; } }
        private string Length { get; set; }
        public string length {  get { return Length; } }
        private string Director { get; set; }
        public string director {  get { return Director; } }
        private string MainCharacter { get; set; }
        public string mainCharacter {  get { return MainCharacter; } }
        private double ImdbRating{ get; set; }
        public double imdbRating {  get { return ImdbRating; } }
        private string Genre {  get; set; }
        public string genre { get { return Genre; } }

        public Filmek(int id, string name, DateTime releaseDate, string length, string director, string mainCharacter, double imdbRating, string genre)
        {
            Id = id;
            Name = name;
            ReleaseDate = releaseDate;
            Length = length;
            Director = director;
            MainCharacter = mainCharacter;
            ImdbRating = imdbRating;
            Genre = genre;
        }

        public Filmek(string name, DateTime releaseDate, string director, string mainCharacter, string genre)
        {
            Name = name;
            ReleaseDate = releaseDate;
            Director = director;
            MainCharacter = mainCharacter;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"{Id}. Film neve: {Name}; Megjelenés éve: {ReleaseDate.ToShortDateString()}; Játékidő: {Length} min; Rendező: {Director}; Főszereplő: {MainCharacter}; Imdb értékelés: {ImdbRating}; Műfaj: {Genre}";
        }
    }
}
