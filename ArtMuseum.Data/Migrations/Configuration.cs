namespace ArtMuseum.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ArtMuseum.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<ArtMuseum.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ArtMuseum.Data.ApplicationDbContext";
        }

        protected override void Seed(ArtMuseum.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Museums.AddOrUpdate(x => x.MuseumId,
                new Museum() { MuseumId = 1, MuseumName = "Vatican Museum", LocationCity = "Vatican City", LocationCountry = "Vatican City", CountryCode = 379 },
                new Museum() { MuseumId = 2, MuseumName = "Smithsonian American Art Museum", LocationCity = "Washington, D.C.", LocationCountry = "United States", CountryCode = 1 },
                new Museum() { MuseumId = 3, MuseumName = "Louvre", LocationCity = "Paris", LocationCountry = "France", CountryCode = 33 },
                new Museum() { MuseumId = 4, MuseumName = "The Uffizi", LocationCity = "Florence", LocationCountry = "Italy", CountryCode = 39 },
                new Museum() { MuseumId = 5, MuseumName = "The Vatican", LocationCity = "Vatican City", LocationCountry = "Vatican City", CountryCode = 379 },
                new Museum() { MuseumId = 6, MuseumName = "St. Peter's Basilica", LocationCity = "Vatican City", LocationCountry = "Vatican City", CountryCode = 379 },
                new Museum() { MuseumId = 7, MuseumName = "Peabody Essex Museum", LocationCity = "Salem, Massachusetts", LocationCountry = "United States", CountryCode = 1 },
                new Museum() { MuseumId = 8, MuseumName = "Gallery of the Academy of Florence", LocationCity = "Florence", LocationCountry = "Italy", CountryCode = 39 }
                );

            context.Artworks.AddOrUpdate(x => x.ArtworkId,
                new Artwork() { ArtworkId = 1, NameOfPiece = "An Angel Playing The Lute", Artist = "Melozzo Da Foli", Description = "Solemn, monumental figures, strongly foreshortened. Testifies skill in the use of perspective.", MuseumId = 1, Availability = false, Medium = "pigment on plaster", Types = Types.FrescoPainting, Era = Era.Renaissance},
                new Artwork() { ArtworkId = 2, NameOfPiece = "The Grand Canyon of the Yellowstone", Artist = "Thomas Moran", Description = "Landscape. Vibrant. Naturalist's eye for detail. Enormous work (255.1x427.8 cm).", MuseumId = 2, Availability = false, Medium = "oil on canvas", Types = Types.Painting, Era = Era.Realism},
                new Artwork() { ArtworkId = 3, NameOfPiece = "Laocoon and His Sons", Artist = "Unknown", Description = "Expressive figures appear to be in motion and have a sense of agony. Possibly a copy of a bronze original.", MuseumId = 1, Availability = false, Medium = "marble", Types = Types.Sculpture, Era = Era.Hellenistic},
                new Artwork() { ArtworkId = 4, NameOfPiece = "The Winged Victory of Samothrace", Artist = "Unknown", Description = "Goddess Nike meant to be viewed from the front left side, right side is less detailed as a result. Highly theatrical presentation reinforces reality of the scene.", MuseumId = 3, Availability = false, Medium = "marble", Types = Types.Sculpture, Era = Era.Hellenistic},
                new Artwork() { ArtworkId = 5, NameOfPiece = "Death of the Virgin", Artist = "Caravaggio", Description = "Photographic naturalism, nearly life-sized figures guide the viewer's eye, excellent use of light and shadow.", MuseumId = 3, Availability = false, Medium = "oil on canvas", Types = Types.Painting, Era = Era.Baroque},
                new Artwork() { ArtworkId = 6, NameOfPiece = "The Birth of Venus", Artist = "Sandro Botticelli", Description = "Venus is slightly to the right of center and is isolated against the background so no other figures overlap.", MuseumId = 4, Availability = false, Medium = "tempera on canvas", Types = Types.Painting, Era = Era.Renaissance},
                new Artwork() { ArtworkId = 7, NameOfPiece = "The Creation of Adam", Artist = "Michelangelo", Description = "Iconic image of outstretched hands, divine energy versus human lassitude, symbolism versus empty speculation.", MuseumId = 5, Availability = false, Medium = "pigment on plaster", Types = Types.FrescoPainting, Era = Era.Renaissance},
                new Artwork() { ArtworkId = 8, NameOfPiece = "The Raft of the Medusa", Artist = "Theodore Gericault", Description = "Illustrates the hope of rescue. Stands as a synthetic view of human life abandoned of its fate.", MuseumId = 3, Availability = false, Medium = "oil on canvas", Types = Types.Painting, Era = Era.Romantic},
                new Artwork() { ArtworkId = 9, NameOfPiece = "Pieta", Artist = "Michelangelo", Description = "Pyramidal, out of proportion, relationships are natural, and Mary is youthful.", MuseumId = 6, Availability = false, Medium = "marble", Types = Types.Sculpture, Era = Era.Renaissance},
                new Artwork() { ArtworkId = 10, NameOfPiece = "The Thinker", Artist = "Auguste Rodin", Description = "Shown in deep thought. Represents philosophy. Many castings made in a range of sizes.", MuseumId = 7, Availability = false, Medium = "marble", Types = Types.Sculpture, Era = Era.Impressionism},
                new Artwork() { ArtworkId = 11, NameOfPiece = "Venus de Milo", Artist = "Unknown", Description = "Mysterious goddess. No name, no attributes. Blend of tradition and innovation. Mutilated, missing arms.", MuseumId = 3, Availability = false, Medium = "marble", Types = Types.Sculpture, Era = Era.Hellenistic},
                new Artwork() { ArtworkId = 12, NameOfPiece = "David", Artist = "Michelangelo", Description = "Exaggerated right hand. Eyes are flawed: left gazes forward, right is fixed on a distant spot. 17 feet tall.", MuseumId = 8, Availability = false, Medium = "marble", Types = Types.Sculpture, Era = Era.Renaissance}
                );

            context.Employees.AddOrUpdate(x => x.Id,
                new Employee() { Id = "A1234", FirstName = "Sydney", LastName = "Vespa", Position = "Artist", MuseumId =  1 },
                new Employee() { Id = "B2345", FirstName = "Michael", LastName = "Jolley", Position = "Curator", MuseumId = 2 },
                new Employee() { Id = "C3456", FirstName = "Dylan", LastName = "Spangler", Position = "Clerk", MuseumId = 3 },
                new Employee() { Id = "D4567", FirstName = "Pacita", LastName = "Abad", Position = "Artist", MuseumId = 4 },
                new Employee() { Id = "E5678", FirstName = "Norman", LastName = "Adams", Position = "Curator", MuseumId = 5 },
                new Employee() { Id = "F6789", FirstName = "Gaston", LastName = "Lachaise", Position = "Guard", MuseumId = 6 },
                new Employee() { Id = "G7890", FirstName = "Anne", LastName = "Gaskell", Position = "Clerk", MuseumId = 7 },
                new Employee() { Id = "H8910", FirstName = "Katsuhiro", LastName = "Yamaguchi", Position = "Guard", MuseumId = 8 }
                );
        }
    }
}
