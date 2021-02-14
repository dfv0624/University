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
using University.BL.Models;
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
        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseDTO courseDTO) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            
            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Insert(course);
                return Ok();
            }
            catch (Exception ex) { return InternalServerError(ex);         }

            
            
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(CourseDTO courseDTO, int id) {
           
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (courseDTO.CourseID != id)
                return BadRequest();

            var course= await courseService.GetById(id);
            if (course == null)
                return NotFound();


            try
            {
                course = mapper.Map<Course>(courseDTO);
                course = await courseService.Update(course);
                return Ok(course);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await courseService.GetById(id);

            if (flag == null)
                return NotFound();

            try
            {
                if (!await courseService.DeleteCheckOnEntity(id))
                    await courseService.Delete(id);
                else
                    throw new Exception("Foreign Keys");
                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

           
        }
        }

}
