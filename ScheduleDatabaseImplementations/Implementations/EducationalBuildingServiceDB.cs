using ScheduleModel;
using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleImplementations.Implementations
{
    public class EducationalBuildingServiceDB : IEducationalBuildingService
    {
        private ScheduleDbContext context;

        public EducationalBuildingServiceDB(ScheduleDbContext context)
        {
            this.context = context;
        }

        public List<EducationalBuildingViewModel> GetList()
        {
            List<EducationalBuildingViewModel> result = context.EducationalBuildings.Select
                (rec => new EducationalBuildingViewModel
                {
                    Id = rec.Id,
                    Number = rec.Number
                }).OrderBy(reco => reco.Number)
                .ToList();

            return result;
        }

        public EducationalBuildingViewModel GetElement(Guid id)
        {
            EducationalBuilding element = context.EducationalBuildings.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new EducationalBuildingViewModel
                {
                    Id = element.Id,
                    Number = element.Number
                };
            }

            throw new Exception("Элемент не найден");
        }

        public EducationalBuildingViewModel GetElementByNumder(string Number)
        {
            EducationalBuilding element = context.EducationalBuildings.FirstOrDefault(rec => rec.Number == Number);

            if (element != null)
            {
                return new EducationalBuildingViewModel
                {
                    Id = element.Id,
                    Number = element.Number
                };
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(EducationalBuildingBindingModel model)
        {
            EducationalBuilding element = context.EducationalBuildings.FirstOrDefault(rec => rec.Number == model.Number);

            if (element != null)
            {
                throw new Exception("Уже есть корпус с таким номером");
            }

            context.EducationalBuildings.Add(new EducationalBuilding
            {
                Id = Guid.NewGuid(),
                Number = model.Number
            });

            context.SaveChanges();
        }

        public void UpdElement(EducationalBuildingBindingModel model)
        {
            EducationalBuilding element = context.EducationalBuildings.FirstOrDefault
            (rec => rec.Number == model.Number && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть корпус с таким номером");
            }

            element = context.EducationalBuildings.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.Number = model.Number;
            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            EducationalBuilding element = context.EducationalBuildings.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.EducationalBuildings.Remove(element);
                context.SaveChanges();
            }

            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
