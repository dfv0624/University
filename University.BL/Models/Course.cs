using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University.BL.Models;

namespace University.BL.Models
{
  
        [Table("Course", Schema = "dbo")]
        public class Course
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int CourseID { get; set; }
            public string Title { get; set; }
            public int Credits { get; set; }

        public virtual ICollection<CourseInstructor> CourseInstructor { get; set; }
        //public virtual ICollection<>


    }


}
