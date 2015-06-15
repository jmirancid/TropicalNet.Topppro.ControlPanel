﻿using System.Data.Entity;
using System.Linq;
using Topppro.Interfaces.Repositories;

namespace Topppro.Repositories.Definitions
{
    public class AttributeRepository : Repository<Topppro.Entities.Attribute>, IAttributeRepository
    {
        public override IQueryable<Topppro.Entities.Attribute> All()
        {
            return Context.Attribute
                        .Include(a => a.Product)
                        .Include(a => a.Culture);
        }

        public override IQueryable<Entities.Attribute> AllBy(
            System.Linq.Expressions.Expression<System.Func<Entities.Attribute, bool>> predicate)
        {
            return Context.Attribute
                        .Include(a => a.Product)
                        .Include(a => a.Culture)
                        .Where(predicate);
        }

        public override IQueryable<Entities.Attribute> Filter(int skip, int take)
        {
            return Context.Attribute
                        .Include(a => a.Product)
                        .Include(a => a.Culture)
                        .OrderBy(a => a.AttributeId)
                        .Skip(skip)
                        .Take(take);
        }

        public override IQueryable<Entities.Attribute> FilterBy(int skip, int take, System.Linq.Expressions.Expression<System.Func<Entities.Attribute, bool>> predicate)
        {
            return Context.Attribute
                        .Include(a => a.Product)
                        .Include(a => a.Culture)
                        .Where(predicate)
                        .OrderBy(a => a.AttributeId)
                        .Skip(skip)
                        .Take(take);
        }

        public override Entities.Attribute Get(int id)
        {
            return Context.Attribute
                        .Include(a => a.Product)
                        .Include(a => a.Culture)
                        .SingleOrDefault(a => a.AttributeId == id);
        }
    }
}