﻿using eGradebook.Models.UserModels;
using eGradebook.Models.UserModels.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.ConvertToAndFromDTO
{
    public class StudentConverter
    {
        public static StudentDTO StudentToStudentDTO(Student student)
        {
            StudentDTO studentDTO = new StudentDTO();

            studentDTO.Id = student.Id;
            studentDTO.FirstName = student.FirstName;
            studentDTO.LastName = student.LastName;
            studentDTO.UserName = student.UserName;
            studentDTO.Email = student.Email;
            studentDTO.Parent = ParentConverter.ParentToParentDTO(student.Parent);
            studentDTO.SchoolClass = SchoolClassConverter.SchoolClassToSchoolClassDTO(student.SchoolClass);

            return studentDTO;
        }

        public static StudentDTO StudentToStudentDTOBasic(Student student)
        {
            StudentDTO studentDTO = new StudentDTO();

            studentDTO.Id = student.Id;
            studentDTO.FirstName = student.FirstName;
            studentDTO.LastName = student.LastName;
            studentDTO.UserName = student.UserName;
            studentDTO.Email = student.Email;

            return studentDTO;
        }

        public static void UpdateStudentWithStudentDTO(Student student, StudentDTO studentDTO)
        {
            student.FirstName = studentDTO.FirstName;
            student.LastName = studentDTO.LastName;
            student.UserName = studentDTO.UserName;
            student.Email = studentDTO.Email;

        }

        public static Student StudentDTOToStudent(StudentDTO studentDTO)
        {
            Student student = new Student();

            student.Id = studentDTO.Id;
            student.FirstName = studentDTO.FirstName;
            student.LastName = studentDTO.LastName;
            student.UserName = studentDTO.UserName;
            student.Email = studentDTO.Email;
            student.Parent = ParentConverter.ParentDTOToParent(studentDTO.Parent);
            student.SchoolClass = SchoolClassConverter.SchoolClassDTOToSchoolClass(studentDTO.SchoolClass);

            return student;
        }
    }
}