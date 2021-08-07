using BBSWeb.Entity;
using BBSWeb.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSWeb.Repository
{
    public class StudentService : BaseService<Student>, IStudentService
    {

        public StudentService(AppDbContext _context) : base(_context) { } //先去父类注册
        public IQueryable<Student> GetAll()
        {
            return this.GetInfo();
        }
    }
}
