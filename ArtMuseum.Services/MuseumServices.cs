using ArtMuseum.Data;
using ArtMuseum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArtMuseum.Services
{
    public class MuseumServices
    {
        private readonly Guid _userId;

        public MuseumServices(Guid userId)
        {
            _userId = userId;
        }

        //Create
        public bool CreateMuseum(MuseumCreate model)
        {
            Museum newMuseum =
                new Museum()
                {
                    MuseumName = model.MuseumName,
                    LocationCity = model.LocationCity,
                    LocationCountry = model.LocationCountry,
                    CountryCode = model.CountryCode,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Museums.Add(newMuseum);
                return ctx.SaveChanges() == 1;
            }
        }

        //Read
        
        //GetAll
        public IEnumerable<MuseumListItem> GetMuseums()
        {
            using (var db = new ApplicationDbContext())
            {
                var query =
                    db
                        .Museums
                        .Select(
                            e =>
                                new MuseumListItem
                                {
                                    MuseumId = e.MuseumId,
                                    MuseumName = e.MuseumName,
                                    LocationCity = e.LocationCity,
                                    LocationCountry = e.LocationCountry,
                                    CountryCode = e.CountryCode

                                });
                return query.ToArray();
            }
        }

        //GetById
        public MuseumDetail GetMuseumById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity =
                    db
                        .Museums
                        .Single(e => e.MuseumId == id);
                return
                        new MuseumDetail
                        {
                            MuseumId = entity.MuseumId,
                            MuseumName = entity.MuseumName,
                            LocationCity = entity.LocationCity,
                            LocationCountry = entity.LocationCountry,
                            CountryCode = entity.CountryCode
                        };
            }
        }

        //GetByName
        public MuseumDetail GetMuseumByName(string name)
        {
            
            using (var db = new ApplicationDbContext())
            {
                if (name != null)
                {
                    var entity =
                    db
                        .Museums
                        .Single(e => e.MuseumName == name);
                    return
                            new MuseumDetail
                            {
                                MuseumId = entity.MuseumId,
                                MuseumName = entity.MuseumName,
                                LocationCity = entity.LocationCity,
                                LocationCountry = entity.LocationCountry,
                                CountryCode = entity.CountryCode
                            };
                }
                return null;
            }
        }

        //GET--Collection
        public IEnumerable<ArtworkListItem> GetArtworksAtMuseum(int museumId)
        {
            using (var db = new ApplicationDbContext())
            {
                var query =
                db.Artworks.Where(e => e.MuseumId == museumId).Select(e => new ArtworkListItem
                {
                    ArtworkId = e.ArtworkId,
                    NameOfPiece = e.NameOfPiece,
                    Artist = e.Artist,
                    MuseumId = e.MuseumId,
                    Medium = e.Medium,
                    Era = e.Era,
                    Types = e.Types,
                });
                return query.ToArray();
            }
        }

        //GET--Employees
        public IEnumerable<EmployeeListItem> GetEmployeesAtMuseum(int museumId)
        {
            using (var db = new ApplicationDbContext())
            {
                var query =
                db.Employees.Where(e => e.MuseumId == museumId).Select(e => new EmployeeListItem
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Position = e.Position,
                    MuseumId = e.MuseumId,
                });
                return query.ToArray();
            }
        }
        public bool UpdateMuseum(MuseumEdit model)
        {
            using(var db = new ApplicationDbContext())
            {
                var entity =
                    db
                        .Museums
                        .Single(e => e.MuseumId == model.MuseumId);

                entity.MuseumId = model.MuseumId;
                entity.MuseumName = model.MuseumName;
                entity.LocationCity = model.LocationCity;
                entity.LocationCountry = model.LocationCountry;
                entity.CountryCode = model.CountryCode;

                return db.SaveChanges() == 1;
            }
        }

        //Delete
        public bool DeleteMuseum(int museumId)
        {
            using(var db = new ApplicationDbContext())
            {
                var entity =
                    db
                        .Museums
                        .Single(e => e.MuseumId == museumId);

                db.Museums.Remove(entity);

                return db.SaveChanges() == 1;
            }
        }

    }
}
