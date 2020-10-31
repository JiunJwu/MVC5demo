using System;
using System.Linq;
using System.Collections.Generic;

namespace WebApplication3.Models
{
	public  class CourseRepository : EFRepository<Course>, ICourseRepository
	{

	}

	public  interface ICourseRepository : IRepository<Course>
	{

	}
}