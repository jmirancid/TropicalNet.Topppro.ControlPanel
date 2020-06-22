﻿using System.Data.Entity;
using System.Linq;
using Topppro.Entities;
using Topppro.Interfaces.Repositories;

namespace Topppro.Repositories.Definitions
{
    public class PackageRepository : 
        Repository<Topppro.Entities.Package>, IPackageRepository
    {
        public PackageRepository() { }

        public PackageRepository(ToppproEntities context) :
            base(context)
        {

        }

        public override IQueryable<Package> All()
        {
            return Context.Package
                        .Include(p => p.ParentProduct)
                        .Include(p => p.ChildProduct);
        }

        public override IQueryable<Topppro.Entities.Package> AllBy(System.Linq.Expressions.Expression<System.Func<Topppro.Entities.Package, bool>> predicate)
        {
            return Context.Package
                        .Include(p => p.ParentProduct)
                        .Include(p => p.ChildProduct)
                        .Where(predicate);
        }

        public override Package Get(object id)
        {
            return Context.Package
                        .Include(p => p.ParentProduct)
                        .Include(p => p.ChildProduct)
                        .SingleOrDefault(p => p.PackageId.Equals(id));
        }
    }
}
