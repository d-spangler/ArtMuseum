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
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Museums.Add(newMuseum);
                return ctx.SaveChanges() == 1;
            }
        }

        //Read
        
        //GetAll
        public IEnumerable<MuseumListItem> GetMuseums()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var queary =
                    ctx
                        .Museums
                        .Select(
                            e =>
                                new MuseumListItem
                                {
                                    MuseumId = e.MuseumId,
                                    MuseumName = e.MuseumName,

                                });
                return queary.ToArray();
            }
        }

        //GetById
        public MuseumDetail GetMuseumById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Museums
                        .Single(e => e.MuseumId == id);
                return
                        new MuseumDetail
                        {
                            MuseumId = entity.MuseumId,
                            MuseumName = entity.MuseumName,
                        };
            }
        }

        //GetByName
        public MuseumDetail GetMuseumByName(string name)
        {
            
            using (var ctx = new ApplicationDbContext())
            {
                if (name != null)
                {
                    var entity =
                    ctx
                        .Museums
                        .Single(e => e.MuseumName == name);
                    return
                            new MuseumDetail
                            {
                                MuseumId = entity.MuseumId,
                                MuseumName = entity.MuseumName,
                            };
                }
                return null;
            }
        }
        
        //Update
        public bool UpdateMuseum(MuseumEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Museums
                        .Single(e => e.MuseumId == model.MuseumId);

                entity.MuseumId = model.MuseumId;
                entity.MuseumName = model.MuseumName;
                entity.LocationCity = model.LocationCity;
                entity.LocationCountry = model.LocationCountry;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete
        public bool DeleteMuseum(int museumId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Museums
                        .Single(e => e.MuseumId == museumId);

                ctx.Museums.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
