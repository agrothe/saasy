using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using SaaSy.Data.Context;
using SaaSy.Data.Repositories;
using SaaSy.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SaaSy.Domain.Services.Application
{
    public class UserService
    {
        private IServiceProvider Services { get; set; }
        public UserService(IServiceProvider services)
        {
            Services = services;
        }

        public async Task<int> AddUserClaimAsync(ApplicationUser user, string claimType, string claimValue)
        {
            using(var unit = new UnitOfWork(Services))
            {
                var repository = unit.GetRepository<IdentityUserClaim<long>>();
                repository.Insert(new IdentityUserClaim<long>
                {
                    ClaimType = claimType,
                    ClaimValue = claimValue,
                    UserId = user.Id
                });

                return await unit.SaveChangesAsync();
            }

        }
    }
}
