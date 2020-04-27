using ArtMuseum.Data;
using ArtMuseum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum.Services
{
    public class ArtworkService
    {
        //CREATE
        public bool CreateArtwork(ArtworkCreate model)
        {
            Artwork newArtwork =
                new Artwork()
                {
                    NameOfPiece = model.NameOfPiece,
                    Artist = model.Artist,
                    Description = model.Description,
                    LocationOfArtwork = model.LocationOfArtwork,
                    Availability = model.Availability,
                    Medium = model.Medium,
                    Types = model.Types,
                    Era = model.Era,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artworks.Add(newArtwork);
                return ctx.SaveChanges() == 1;
            }
        }
        //READ

        //GET ALL
        public IEnumerable<ArtworkListItem> GetArtwork()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var queary =
                    ctx
                        .Artworks
                        .Select(
                            e =>
                                new ArtworkListItem
                                {
                                    ArtworkId = e.ArtworkId,
                                    NameOfPiece = e.NameOfPiece,
                                    Artist = e.Artist,

                                });
                return queary.ToArray();
            }
        }

        //GET BY ID
        public ArtworkDetail GetArtworkById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artworks
                        .Single(e => e.ArtworkId == id);
                return
                        new ArtworkDetail
                        {
                            ArtworkId = entity.ArtworkId,
                            NameOfPiece = entity.NameOfPiece,
                        };
            }
        }

        //GET BY NAME OF PIECE
        public ArtworkDetail GetArtworkByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artworks
                        .Single(e => e.NameOfPiece == name);
                return
                        new ArtworkDetail
                        {
                            NameOfPiece = entity.NameOfPiece,
                            Artist = entity.Artist,
                            LocationOfArtwork = entity.LocationOfArtwork,
                            Medium = entity.Medium,
                            Era = entity.Era,
                            Types = entity.Types,
                        };
            }
        }

        //GET BY ARTIST
        public IEnumerable<ArtworkListItem> GetArtworkByArtist(string artists)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artworks
                        .Where(e => e.Artist == artists).Select(e=>
                
                
                        new ArtworkListItem
                        {
                            Artist = e.Artist,
                            NameOfPiece = e.NameOfPiece,
                            ArtworkId =e.ArtworkId,
                        });
                return entity.ToArray();
            }
        }

        

        //GET BY MEDIUM
        public ArtworkDetail GetArtworkByMedium(string mediums)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artworks
                        .Single(e => e.Medium == mediums);
                return
                        new ArtworkDetail
                        {
                            Medium = entity.Medium,
                            NameOfPiece = entity.NameOfPiece,
                        };
            }
        }

        //GET BY TYPE
        public ArtworkDetail GetArtworkByTypes(Enum type)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artworks
                        .Single(e => e.Types.Equals(type));
                return
                        new ArtworkDetail
                        {
                            Types = entity.Types,
                            NameOfPiece = entity.NameOfPiece,
                        };
            }
        }
        //GET BY ERA
        public ArtworkDetail GetArtworkByEra(Enum Eras)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artworks
                        .Single(e => e.Types.Equals(Eras));
                return
                        new ArtworkDetail
                        {
                            Era = entity.Era,
                            NameOfPiece = entity.NameOfPiece,
                        };
            }
        }
        //UPDATE
        public bool UpdateArtwork(ArtworkEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artworks
                        .Single(e => e.ArtworkId == model.ArtworkId);

                entity.ArtworkId = model.ArtworkId;
                entity.NameOfPiece = model.NameOfPiece;
                entity.LocationOfArtwork = model.LocationOfArtwork;
                entity.Medium = model.Medium;
                entity.Types = model.Types;
                entity.Era = model.Era;
                entity.Availability = model.Availability;
                entity.Artist = model.Artist;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteArtwork(int artworkId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artworks
                        .Single(e => e.ArtworkId == artworkId);

                ctx.Artworks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
