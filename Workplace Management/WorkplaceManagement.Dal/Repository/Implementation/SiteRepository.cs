﻿using System.Collections.Generic;
using System.Linq;
using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Context;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Dal.Repository.Implementation
{
    public class SiteRepository : RepositoryBase<Site>, ISiteRepository
    {
        public SiteRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public IEnumerable<Site> GetAllSites(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(s => s.Name)
                .ToList();
        }
    }
}
