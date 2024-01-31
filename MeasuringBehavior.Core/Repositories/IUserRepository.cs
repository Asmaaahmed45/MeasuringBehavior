using MeasuringBehavior.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringBehavior.Core.Repositories
{
    public interface IUserRepository
    {
        UserVM GetUser(int id);
    }
}
