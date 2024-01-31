using MeasuringBehavior.Core.Models.Domain;
using MeasuringBehavior.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringBehavior.EF.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public UserVM GetUser(int id)
        {
            var userVM = (from user in _context.Users
                          join Gov in _context.Governorates
                          on user.GovernorateId equals Gov.Id
                          join Vill in _context.Village
                          on user.VillageId equals Vill.Id
                          join Reg in _context.Region
                          on user.RegionId equals Reg.Id
                          where user.Id== id
                          select new UserVM 
                          { 
                              Id=user.Id,
                              Name=user.Name,
                              Email=user.Email,
                              SSN=user.SSN,
                              Governorate=Gov.Name,
                              Village=Vill.Name,
                              Region=Reg.Name
                          }).FirstOrDefault();
            return userVM;
        }
    }
}
