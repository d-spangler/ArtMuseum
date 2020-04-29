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

        private readonly Guid _userId;

        public ArtworkService(Guid userId)
        {
            _userId = userId;
        }

        //CREATE
        public bool CreateArtwork(ArtworkCreate model)
        {
            var newArtwork =
                new Artwork()
                {
                    NameOfPiece = model.NameOfPiece,
                    Artist = model.Artist,
                    Description = model.Description,
                    MuseumName = model.MuseumName,
                    //Availability = model.Availability,
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
                            MuseumName = entity.MuseumName,
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
                var query =
                    ctx
                        .Artworks
                        .Where(e => e.Artist == artists).Select(e=>
                
                
                        new ArtworkListItem
                        {
                            Artist = e.Artist,
                            NameOfPiece = e.NameOfPiece,
                            ArtworkId =e.ArtworkId,
                        });
                return query.ToArray();
            }
        }

        

        //GET BY MEDIUM
        public IEnumerable<ArtworkDetail> GetArtworkByMedium(string mediums)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Artworks
                        .Where(e => e.Medium == mediums).Select(e=>
               
                        new ArtworkDetail
                        {
                            Medium = e.Medium,
                            NameOfPiece = e.NameOfPiece,
                        });
                return query.ToArray();
            }
        }

        //GET BY TYPE
        public IEnumerable<ArtworkDetail> GetArtworkByTypes(Enum type)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Artworks
                        .Where(e => e.Types.Equals(type)).Select(e =>

                        new ArtworkDetail
                        {
                            Types = e.Types,
                            NameOfPiece = e.NameOfPiece,
                        });
                return query.ToArray();
            }
        }
        //GET BY ERA
        public IEnumerable<ArtworkDetail> GetArtworkByEra(Enum eras)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Artworks
                        .Where(e => e.Types.Equals(eras)).Select(e=>
                
                        new ArtworkDetail
                        {
                            Era = e.Era,
                            NameOfPiece = e.NameOfPiece,
                        });
                return query.ToArray();
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
                entity.MuseumName = model.MuseumName;
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
