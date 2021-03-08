using ScheduleModel;
using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleImplementations.Implementations
{
    public class TeacherServiceDB : ITeacherService
    {
        private AbstractDbContext context;

        public TeacherServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<TeacherViewModel> GetList()
        {
            List<TeacherViewModel> result = context.Teachers.Select
                (rec => new TeacherViewModel
                {
                    Id = rec.Id,
                    Surname = rec.Surname,
                    Name = rec.Name,
                    Patronymic = rec.Patronymic,

                    TeacherDepartments = context.TeacherDepartments
                    .Where(recTD => recTD.TeacherId == rec.Id)
                    .Select(recTD => new TeacherDepartmentViewModel
                    {
                        Id = recTD.Id,
                        TeacherId = recTD.TeacherId,
                        DepartmentId = recTD.DepartmentId,
                        DepartmentTitle = recTD.Department.Title
                    }).ToList()

                }).ToList();

            return result;
        }

        public TeacherViewModel GetElement(Guid id)
        {
            Teacher element = context.Teachers.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new TeacherViewModel
                {
                    Id = element.Id,
                    Surname = element.Surname,
                    Name = element.Name,
                    Patronymic = element.Patronymic,

                    TeacherDepartments = context.TeacherDepartments
                    .Where(rec => rec.TeacherId == element.Id)
                    .Select(rec => new TeacherDepartmentViewModel
                    {
                        Id = rec.Id,
                        TeacherId = rec.TeacherId,
                        DepartmentId = rec.DepartmentId,
                        DepartmentTitle = rec.Department.Title
                    }).ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(TeacherBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Teacher element = context.Teachers.FirstOrDefault(rec =>rec.Surname == model.Surname && 
                    rec.Name == model.Name && rec.Patronymic == model.Patronymic);
                    if (element != null)
                    {
                        throw new Exception("Уже есть такой преподаватель");
                    }
                    element = new Teacher
                    {
                        Id = Guid.NewGuid(),//???
                        Surname = model.Surname,
                        Name = model.Name,
                        Patronymic = model.Patronymic
                    };
                    context.Teachers.Add(element);
                    context.SaveChanges();

                    // убираем дубли 
                    var departments = model.TeacherDepartments
                        .GroupBy(rec => rec.DepartmentId)
                        .Select(rec => new
                        {
                            DepartmentId = rec.Key
                        });

                    // добавляем кафедры  
                    foreach (var department in departments)
                    {
                        context.TeacherDepartments.Add(new TeacherDepartment
                        {
                            Id = Guid.NewGuid(),//???
                            TeacherId = element.Id,
                            DepartmentId = department.DepartmentId
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdElement(TeacherBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Teacher element = context.Teachers.FirstOrDefault(rec => rec.Id != model.Id && rec.Surname == model.Surname &&
                    rec.Name == model.Name && rec.Patronymic == model.Patronymic);
                    if (element != null)
                    {
                        throw new Exception("Уже есть такой преподаватель");
                    }
                    element = context.Teachers.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.Surname = model.Surname;
                    element.Name = model.Name;
                    element.Patronymic = model.Patronymic;
                    context.SaveChanges();

                    // обновляем существуюущие компоненты 
                    var departmentIds = model.TeacherDepartments.Select(rec => rec.DepartmentId).Distinct();

                    var updateDepartments = context.TeacherDepartments
                        .Where(rec =>rec.TeacherId == model.Id && departmentIds.Contains(rec.DepartmentId));

                    //foreach (var updateDepartment in updateDepartments)
                    //{
                    //    updateDepartment.Count = model.TeacherDepartments.FirstOrDefault(rec =>
                    //    rec.Id == updateDepartment.Id).Count;
                    //}

                    context.SaveChanges();
                    context.TeacherDepartments.RemoveRange(context.TeacherDepartments.Where(rec => rec.TeacherId == model.Id && !departmentIds.Contains(rec.DepartmentId)));
                    context.SaveChanges();

                    // новые записи  
                    var groupParts = model.TeacherDepartments
                    .Where(rec => rec.Id == new Guid(0, 0, 0, new byte[8])) //????
                    .GroupBy(rec => rec.DepartmentId)
                    .Select(rec => new
                    {
                        DepartmentId = rec.Key
                    });

                    foreach (var groupPart in groupParts)

                    {
                        TeacherDepartment elementPC = context.TeacherDepartments
                            .FirstOrDefault(rec => rec.TeacherId == model.Id && rec.DepartmentId == groupPart.DepartmentId);

                        if (elementPC != null)
                        {
                            //elementPC.Count += groupPart.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.TeacherDepartments.Add(new TeacherDepartment
                            {
                                Id = Guid.NewGuid(),//???
                                TeacherId = model.Id,
                                DepartmentId = groupPart.DepartmentId
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DelElement(Guid id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Teacher element = context.Teachers.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        // удаяем записи по кафедрам при удалении преподавателя 
                        context.TeacherDepartments.RemoveRange(context.TeacherDepartments.Where(rec =>rec.TeacherId == id));
                        context.Teachers.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
