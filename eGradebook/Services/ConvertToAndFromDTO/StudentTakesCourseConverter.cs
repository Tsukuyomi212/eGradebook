﻿using eGradebook.Models;
using eGradebook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.ConvertToAndFromDTO
{
    public class StudentTakesCourseConverter
    {
        public static StudentTakesCourseDTO StudentTakesCourseToStudentTakesCourseDTO(StudentTakesCourse stc)
        {
            StudentTakesCourseDTO stcDTO = new StudentTakesCourseDTO();

            stcDTO.Id = stc.Id;
            stcDTO.Student = StudentConverter.StudentToStudentDTO(stc.Student);
            stcDTO.Course = TeacherTeachesCourseConverter.TeacherTeachescourseToTeacherTeachesCourseDTO(stc.Course);
            //stcDTO.StudentsMarksFromCourse = stc.StudentsMarksFromCourse;

            return stcDTO;
        }

        public static void UpdateStudentTakesCourseWithStudentTakesCourseDTO(StudentTakesCourse stc, StudentTakesCourseDTO stcDTO)
        {
            stc.Student = StudentConverter.StudentDTOToStudent(stcDTO.Student);
            stc.Course = TeacherTeachesCourseConverter.TeacherTeachesCourseDTOtoTeacherTeachesCourse(stcDTO.Course);
            //stc.StudentsMarksFromCourse = stcDTO.StudentsMarksFromCourse;
        }

        public static StudentTakesCourse StudentTakesCourseDTOToStudentTakesCourse(StudentTakesCourseDTO stcDTO)
        {
            StudentTakesCourse stc = new StudentTakesCourse();

            stc.Id = stcDTO.Id;
            stc.Student = StudentConverter.StudentDTOToStudent(stcDTO.Student);
            stc.Course = TeacherTeachesCourseConverter.TeacherTeachesCourseDTOtoTeacherTeachesCourse(stcDTO.Course);
            //stc.StudentsMarksFromCourse = stcDTO.StudentsMarksFromCourse;

            return stc;
        }
    }
}