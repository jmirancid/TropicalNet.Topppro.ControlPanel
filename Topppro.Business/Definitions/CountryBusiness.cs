﻿using System.Collections.Generic;
using Topppro.Interfaces.Business;
using Topppro.Interfaces.Repositories;
using xFNet.Business;

namespace Topppro.Business.Definitions
{
    public class CountryBusiness : 
        Business<Topppro.Entities.Country, ICountryRepository>, ICountryBusiness
    {
        public CountryBusiness() { }

        public CountryBusiness(ICountryRepository repository) :
            base(repository)
        {

        }

        public IEnumerable<Topppro.Entities.Country> AllHavingDistributors(string cultureCode)
        {
            return base.Repository.AllHavingDistributors(cultureCode);
        }
    }
}
