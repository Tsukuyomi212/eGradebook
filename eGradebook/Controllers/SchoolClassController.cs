﻿using eGradebook.Models;
using eGradebook.Models.DTOs;
using eGradebook.Services.IServices;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace eGradebook.Controllers
{
    [RoutePrefix("api/schoolclass")]
    public class SchoolClassController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ISchoolClassService schoolClassService;
        public SchoolClassController(ISchoolClassService schoolClassService)
        {
            this.schoolClassService = schoolClassService;
        }

        //get
        [Route("")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Admin requesting list of all school classes");
            var schoolClasses = schoolClassService.Get();
            if (schoolClasses == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(schoolClasses);
        }

        //getbyid
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            logger.Info("Admin requesting a school class' details");

            var schoolClass = schoolClassService.GetById(id);
            if (schoolClass == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(schoolClass);
        }

        //put
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(int id, SchoolClassCreateAndUpdateDTO schoolClassDTO)
        {
            logger.Info("Admin updating a school class' details");

            if (!ModelState.IsValid)
            {
                logger.Error("Update failed due to invalid input");
                return BadRequest(ModelState);
            }

            SchoolClassBasicDTO schoolClass = schoolClassService.Update(id, schoolClassDTO);
            if (schoolClass == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(schoolClass);
        }

        //post
        [Route("")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Post(SchoolClassCreateAndUpdateDTO schoolClassDTO)
        {
            logger.Info("Admin creating a new school class");
            if (!ModelState.IsValid)
            {
                logger.Error("Update failed due to invalid input");
                return BadRequest(ModelState);
            }
            SchoolClassCreateAndUpdateDTO schoolClass = schoolClassService.Create(schoolClassDTO);
            return Ok(schoolClass);
        }
        /*
        //delete
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            logger.Info("Admin deleting a school class");
            SchoolClassDTO schoolClass = schoolClassService.GetById(id);
            if (schoolClass == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            schoolClassService.Delete(schoolClass.Id);
            return Ok();
        }
        */

        [Route("{schoolClassId}/schoolYear/{schoolYearId}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutSchoolClassSchoolYear(int schoolClassId, int schoolYearId)
        {
            logger.Info("Admin updating School Class's School Year");

            if (!ModelState.IsValid)
            {
                logger.Error("Update failed due to invalid input");
                return BadRequest();
            }

            schoolClassService.UpdateSchoolClassWithSchoolYear(schoolClassId, schoolYearId);

            return Ok();
        }
        
    }
}
