using Ly.Entity;
using System;
using System.Threading.Tasks;

namespace Ly.IBusiness
{
    public interface IBase_SchoolBusiness
    {
        Task<Base_School> GetSchool(int id);
    }
}
