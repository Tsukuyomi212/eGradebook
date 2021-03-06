﻿using eGradebook.Models.UserModels;
using eGradebook.Models.UserModels.UserDTOs;
using eGradebook.Repositories;
using eGradebook.Services.ConvertToAndFromDTO;
using eGradebook.Services.Users_IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.Users_Services
{
    public class ParentService : IParentService
    {
        private IUnitOfWork db;

        public ParentService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<ParentBasicDTO> Get()
        {
            var parents = db.ParentsRepository.Get();
            if (parents == null)
            {
                return null;
            }
            var parentDTOs = new List<ParentBasicDTO>();
            foreach (Parent parent in parents)
            {
                parentDTOs.Add(ParentConverter.ParentToParentBasicDTO(parent));
            }
            return parentDTOs;
        }


        public ParentDTO GetByID(string id)
        {
            Parent parent = db.ParentsRepository.GetByID(id);
            if (parent == null)
            {
                return null;
            }
            return ParentConverter.ParentToParentDTO(parent);
        }


        public ParentUpdateDTO Update(string id, ParentUpdateDTO parentDTO)
        {
            Parent parent = db.ParentsRepository.GetByID(id);
            if (parent == null)
            {
                return null;
            }
            ParentConverter.UpdateParentWithParentDTO(parent, parentDTO);
            db.ParentsRepository.Update(parent);
            db.Save();
            return ParentConverter.ParentToParentUpdateDTO(parent);
        }


        public void Delete(string id)
        {
            Parent parent = db.ParentsRepository.GetByID(id);
            var children = db.StudentsRepository.Get().Where(x => x.Parent.Id == id);
            if (children != null)
            {
                throw new Exception("Cannot delete parent - user, because he/she has one or more students attached. One option is to update student's parent info - there has to be a parent or a legal guardian named.");

            }
         
            db.ParentsRepository.Delete(parent);
            db.Save();
        }
    }
}