using System;
using System.Linq;
using System.Collections.Generic;

namespace WebApplication3.Models
{
	public  class DepartmentRepository : EFRepository<Department>, IDepartmentRepository
	{
        public override IQueryable<Department> All()
        {
            return base.All().Where(p => p.isDeleted == false);
        }
        public Department Get單一筆部門資料(int ID)
        {
            return this.All().FirstOrDefault(p => p.DepartmentID ==ID);
        }
        public override void Delete(Department entity)
        {
            this.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;
            entity.isDeleted = true;
        }

    }

	public  interface IDepartmentRepository : IRepository<Department>
	{

	}
}