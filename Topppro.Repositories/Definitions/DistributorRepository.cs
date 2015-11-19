﻿using System.Data.Entity;
using System.Linq;
using Topppro.Interfaces.Repositories;

namespace Topppro.Repositories.Definitions
{
    public class DistributorRepository : Repository<Topppro.Entities.Distributor>, IDistributorRepository
    {
        public override IQueryable<Topppro.Entities.Distributor> All()
        {
            return Context.Distributor
                        .Include(a => a.Country)
                        .Include(a => a.Culture);
        }

        public override IQueryable<Entities.Distributor> AllBy(
            System.Linq.Expressions.Expression<System.Func<Entities.Distributor, bool>> predicate)
        {
            return Context.Distributor
                        .Include(a => a.Country)
                        .Include(a => a.Culture)
                        .Where(predicate);
        }

        public override IQueryable<Entities.Distributor> Filter(int skip, int take)
        {
            return Context.Distributor
                        .Include(a => a.Country)
                        .Include(a => a.Culture)
                        .OrderBy(a => a.DistributorId)
                        .Skip(skip)
                        .Take(take);
        }

        public override IQueryable<Entities.Distributor> FilterBy(int skip, int take, System.Linq.Expressions.Expression<System.Func<Entities.Distributor, bool>> predicate)
        {
            return Context.Distributor
                        .Include(a => a.Country)
                        .Include(a => a.Culture)
                        .Where(predicate)
                        .OrderBy(a => a.DistributorId)
                        .Skip(skip)
                        .Take(take);
        }

        public override Entities.Distributor Get(int id)
        {
            return Context.Distributor
                        .Include(a => a.Country)
                        .Include(a => a.Culture)
                        .SingleOrDefault(a => a.DistributorId == id);
        }
    }
}