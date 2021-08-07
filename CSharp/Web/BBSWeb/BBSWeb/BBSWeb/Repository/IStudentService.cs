using BBSWeb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSWeb.Repository
{
    public interface IStudentService 
    {
        IQueryable<Student> GetAll();
    }
}
