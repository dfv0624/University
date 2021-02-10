using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace UniversityAPI.Controllers
{
    
   public class CoursesController : ApiController
    {
        private IMapper mapper;
        private readonly CourseService courseService = new CourseService(new CourseRepository(UniversityContext.Create()));

        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll() 
        {
           var Courses = await courseService.GetAll();
            var coursesDTO = Courses.Select(x => mapper.Map<CourseDTO>(x));

                return Ok(coursesDTO);
        
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var Course = await courseService.GetById(id);
            if (Course == null)
                return NotFound();
            var courseDTO = mapper.Map<CourseDTO>(Course);

            return Ok(courseDTO);

        }
    }
}
