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
        private string Name { get; set; }
        private DateTime ReleaseDate { get; set; }
        private string Length { get; set; }
        private string Director { get; set; }
        private string MainCharacter { get; set; }
        private double ImdbRating{ get; set; }
        private string Genre {  get; set; }

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
