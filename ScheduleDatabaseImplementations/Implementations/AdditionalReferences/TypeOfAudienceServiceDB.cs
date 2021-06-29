﻿using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class TypeOfAudienceServiceDB : IAdditionalReference<TypeOfAudienceBindingModel, TypeOfAudienceViewModel>
    {
        private readonly ScheduleDbContext context;

        public TypeOfAudienceServiceDB(ScheduleDbContext context)
        {
            this.context = context;
        }

        public List<TypeOfAudienceViewModel> GetList()
        {
            List<TypeOfAudienceViewModel> result = context.TypeOfAudiences.Select
                (rec => new TypeOfAudienceViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title
                })
                .OrderBy(reco => reco.Title)
                .ToList();

            return result;
        }

        public TypeOfAudienceViewModel GetElement(Guid id)
        {
            TypeOfAudience element = context.TypeOfAudiences.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new TypeOfAudienceViewModel
                {
                    Id = element.Id,
                    Title = element.Title
                };
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(TypeOfAudienceBindingModel model)
        {
            TypeOfAudience element = context.TypeOfAudiences.FirstOrDefault
            (rec => rec.Title == model.Title);

            if (element != null)
            {
                throw new Exception("Уже есть такой тип аудитории");
            }

            context.TypeOfAudiences.Add(new TypeOfAudience
            {
                Id = Guid.NewGuid(),
                Title = model.Title
            });

            context.SaveChanges();
        }

        public void UpdElement(TypeOfAudienceBindingModel model)
        {
            TypeOfAudience element = context.TypeOfAudiences.FirstOrDefault
            (rec => rec.Title == model.Title && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть такой тип аудитории");
            }

            element = context.TypeOfAudiences.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.Title = model.Title;
            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            TypeOfAudience element = context.TypeOfAudiences.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.TypeOfAudiences.Remove(element);
                context.SaveChanges();
            }

            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}