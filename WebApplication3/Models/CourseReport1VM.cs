using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class CourseReport1VM
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int TeacherCount { get; set; }
        public int StudentCount { get; set; }
        //可以打prop
        public double? AvgGrade { get; set; }
    }
}