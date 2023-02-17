using IdentityService.BusinessLogic.DTOs;
using IdentityService.DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.BusinessLogic.SeedData
{
    public class SeedRolesData
    {
        private readonly RoleManager<Role> _roleManager;

        /// <summary>
        /// Initializes a new instance of <see cref="SeedRolesData"/>
        /// </summary>
        /// <param name="roleManager">The roleManager</param>
        public SeedRolesData(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        /// <summary>
        /// Function add seed data of genres
        /// </summary>
        public void SeedData()
        {
            try
            {
                if (_roleManager.Roles == null)
                {
                   foreach(var role in RoleTypes.RolesTypes)
                   {
                        _roleManager.CreateAsync(new Role(role));
                   }
                }
            }
            catch(NotSupportedException ex)
            {
                throw ex;
            }
        }
    }
}
