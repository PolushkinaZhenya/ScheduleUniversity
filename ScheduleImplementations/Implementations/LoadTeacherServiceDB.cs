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
    public class LoadTeacherServiceDB : ILoadTeacherService
    {
        private AbstractDbContext context;

        public LoadTeacherServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<LoadTeacherViewModel> GetList()
        {
            List<LoadTeacherViewModel> result = context.LoadTeachers.Select
                (rec => new LoadTeacherViewModel
                {
                    Id = rec.Id,
                    DisciplineTitle = rec.Discipline.Title,
                    TypeOfClassTitle = rec.TypeOfClass.Title,
                    TeacherSurname = rec.Teacher.Surname,
                    FlowTitle = rec.Flow.Title,

                    LoadTeacherPeriods = context.LoadTeacherPeriods
                    .Where(recLTP => recLTP.LoadTeacherId == rec.Id)
                    .Select(recLTP => new LoadTeacherPeriodViewModel
                    {
                        Id = recLTP.Id,
                        LoadTeacherId = recLTP.LoadTeacherId,
                        PeriodId = recLTP.PeriodId,
                        PeriodTitle = recLTP.Period.Title,
                        NumderOfHours = recLTP.NumderOfHours
                    }).ToList(),

                    LoadTeacherAuditoriums = context.LoadTeacherAuditoriums
                    .Where(recLTA => recLTA.LoadTeacherId == rec.Id)
                    .Select(recLTA => new LoadTeacherAuditoriumViewModel
                    {
                        Id = recLTA.Id,
                        LoadTeacherId = recLTA.LoadTeacherId,
                        AuditoriumId = recLTA.AuditoriumId,
                        AuditoriumTitle = recLTA.Auditorium.Number
                    }).ToList()

                }).ToList();

            return result;
        }

        public List<LoadTeacherViewModel> GetListByTypeAndStudyGroupAndPeriod(string Type, Guid StudyGroupId, Guid PeriodId)
        {
            Guid TypeId = context.TypeOfClasses.Where(rec => rec.AbbreviatedTitle == Type).Select(rec => rec.Id).FirstOrDefault();

            List<Guid> FlowIds = context.FlowStudyGroups.Where(rec => rec.StudyGroupId == StudyGroupId).Select(rec => rec.FlowId).ToList();
            
            List<LoadTeacherViewModel> resultType = context.LoadTeachers
            .Where(recLT => recLT.TypeOfClassId == TypeId)
            .Select(rec => new LoadTeacherViewModel
            {
                Id = rec.Id,
                DisciplineTitle = rec.Discipline.Title,
                TypeOfClassTitle = rec.TypeOfClass.Title,
                TeacherSurname = rec.Teacher.Surname,
                FlowId = rec.FlowId,
                FlowTitle = rec.Flow.Title,

                LoadTeacherPeriods = context.LoadTeacherPeriods
                    .Where(recLTP => recLTP.LoadTeacherId == rec.Id)
                    .Select(recLTP => new LoadTeacherPeriodViewModel
                    {
                        Id = recLTP.Id,
                        LoadTeacherId = recLTP.LoadTeacherId,
                        PeriodId = recLTP.PeriodId,
                        PeriodTitle = recLTP.Period.Title,
                        NumderOfHours = recLTP.NumderOfHours
                    }).ToList(),

                NumderOfHours = context.LoadTeacherPeriods
                    .Where(recLTP => (recLTP.PeriodId == PeriodId) && (recLTP.LoadTeacherId == rec.Id))
                    .Select(recLTP => recLTP.NumderOfHours
                    ).FirstOrDefault(),

                LoadTeacherAuditoriums = context.LoadTeacherAuditoriums
                    .Where(recLTA => recLTA.LoadTeacherId == rec.Id)
                    .Select(recLTA => new LoadTeacherAuditoriumViewModel
                    {
                        Id = recLTA.Id,
                        LoadTeacherId = recLTA.LoadTeacherId,
                        AuditoriumId = recLTA.AuditoriumId,
                        AuditoriumTitle = recLTA.Auditorium.Number
                    }).ToList()
            }).ToList();

            List<LoadTeacherViewModel> result = new List<LoadTeacherViewModel>();

            for (int i = 0; i < FlowIds.Count; i++)
            {
                List<LoadTeacherViewModel> resultLocal = resultType
                .Where(recLT => recLT.FlowId == FlowIds[i])
                .Select
                (rec => new LoadTeacherViewModel
                {
                    Id = rec.Id,
                    DisciplineTitle = rec.DisciplineTitle,
                    TypeOfClassTitle = rec.TypeOfClassTitle,
                    TeacherSurname = rec.TeacherSurname,
                    FlowTitle = rec.FlowTitle,

                    LoadTeacherPeriods = context.LoadTeacherPeriods
                    .Where(recLTP => recLTP.LoadTeacherId == rec.Id)
                    .Select(recLTP => new LoadTeacherPeriodViewModel
                    {
                        Id = recLTP.Id,
                        LoadTeacherId = recLTP.LoadTeacherId,
                        PeriodId = recLTP.PeriodId,
                        PeriodTitle = recLTP.Period.Title,
                        NumderOfHours = recLTP.NumderOfHours
                    }).ToList(),

                    NumderOfHours = context.LoadTeacherPeriods
                    .Where(recLTP => (recLTP.PeriodId == PeriodId) && (recLTP.LoadTeacherId == rec.Id))
                    .Select(recLTP => recLTP.NumderOfHours
                    ).FirstOrDefault(),

                    LoadTeacherAuditoriums = context.LoadTeacherAuditoriums
                    .Where(recLTA => recLTA.LoadTeacherId == rec.Id)
                    .Select(recLTA => new LoadTeacherAuditoriumViewModel
                    {
                        Id = recLTA.Id,
                        LoadTeacherId = recLTA.LoadTeacherId,
                        AuditoriumId = recLTA.AuditoriumId,
                        AuditoriumTitle = recLTA.Auditorium.Number
                    }).ToList()

                }).ToList();

                result = result.Concat(resultLocal).ToList();
            }
            return result;
        }

        public LoadTeacherViewModel GetElement(Guid id)
        {
            LoadTeacher element = context.LoadTeachers.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new LoadTeacherViewModel
                {
                    Id = element.Id,

                    DisciplineId = element.DisciplineId,
                    DisciplineTitle = context.Disciplines
                    .Where(rec => rec.Id == element.DisciplineId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    TypeOfClassId = element.TypeOfClassId,
                    TypeOfClassTitle = context.TypeOfClasses
                    .Where(rec => rec.Id == element.TypeOfClassId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    TeacherId = element.TeacherId,
                    TeacherSurname = context.Teachers
                    .Where(rec => rec.Id == element.TeacherId)
                    .Select(rec => rec.Surname).FirstOrDefault(),

                    FlowId = element.FlowId,
                    FlowTitle = context.Flows
                    .Where(rec => rec.Id == element.FlowId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    LoadTeacherPeriods = context.LoadTeacherPeriods
                    .Where(recLTP => recLTP.LoadTeacherId == element.Id)
                    .Select(recLTP => new LoadTeacherPeriodViewModel
                    {
                        Id = recLTP.Id,
                        LoadTeacherId = recLTP.LoadTeacherId,
                        PeriodId = recLTP.PeriodId,
                        PeriodTitle = recLTP.Period.Title,
                        NumderOfHours = recLTP.NumderOfHours
                    }).ToList(),

                    LoadTeacherAuditoriums = context.LoadTeacherAuditoriums
                    .Where(recLTA => recLTA.LoadTeacherId == element.Id)
                    .Select(recLTA => new LoadTeacherAuditoriumViewModel
                    {
                        Id = recLTA.Id,
                        LoadTeacherId = recLTA.LoadTeacherId,
                        AuditoriumId = recLTA.AuditoriumId,
                        AuditoriumTitle = recLTA.Auditorium.Number
                    }).ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(LoadTeacherBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    LoadTeacher element = context.LoadTeachers.FirstOrDefault(rec => rec.DisciplineId == model.DisciplineId
                    && rec.TypeOfClassId == model.TypeOfClassId && rec.TeacherId == model.TeacherId && rec.FlowId == model.FlowId);
                    if (element != null)
                    {
                        throw new Exception("Уже есть такая расчасовка");
                    }
                    element = new LoadTeacher
                    {
                        Id = Guid.NewGuid(),//???
                        DisciplineId = model.DisciplineId,
                        TypeOfClassId = model.TypeOfClassId,
                        TeacherId = model.TeacherId,
                        FlowId = model.FlowId
                    };
                    context.LoadTeachers.Add(element);
                    context.SaveChanges();

                    // убираем дубли 
                    var periods = model.LoadTeacherPeriods;
                    //.GroupBy(rec => rec.StudyGroupId)
                    //.Select(rec => new
                    //{
                    //    StudyGroupId = rec.Key
                    //});

                    // добавляем периоды 
                    foreach (var period in periods)
                    {
                        context.LoadTeacherPeriods.Add(new LoadTeacherPeriod
                        {
                            Id = Guid.NewGuid(),//???
                            LoadTeacherId = element.Id,
                            PeriodId = period.PeriodId,
                            NumderOfHours = period.NumderOfHours
                        });
                        context.SaveChanges();
                    }

                    // убираем дубли 
                    var auditoriums = model.LoadTeacherAuditoriums;
                    //.GroupBy(rec => rec.StudyGroupId)
                    //.Select(rec => new
                    //{
                    //    StudyGroupId = rec.Key
                    //});

                    // добавляем периоды 
                    foreach (var auditorium in auditoriums)
                    {
                        context.LoadTeacherAuditoriums.Add(new LoadTeacherAuditorium
                        {
                            Id = Guid.NewGuid(),//???
                            LoadTeacherId = element.Id,
                            AuditoriumId = auditorium.AuditoriumId
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


        public void UpdElement(LoadTeacherBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    LoadTeacher element = context.LoadTeachers.FirstOrDefault(rec => rec.Id != model.Id &&
                    rec.DisciplineId == model.DisciplineId && rec.TypeOfClassId == model.TypeOfClassId &&
                    rec.TeacherId == model.TeacherId && rec.FlowId == model.FlowId);
                    if (element != null)
                    {
                        throw new Exception("Уже есть такая расчасовка");
                    }
                    element = context.LoadTeachers.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.DisciplineId = model.DisciplineId;
                    element.TypeOfClassId = model.TypeOfClassId;
                    element.TeacherId = model.TeacherId;
                    element.FlowId = model.FlowId;
                    context.SaveChanges();

                    // обновляем существуюущие компоненты 
                    var periodIds = model.LoadTeacherPeriods.Select(rec => rec.PeriodId).Distinct();

                    var updatePeriods = context.LoadTeacherPeriods
                        .Where(rec => rec.LoadTeacherId == model.Id && periodIds.Contains(rec.PeriodId));

                    //foreach (var updateDepartment in updateDepartments)
                    //{
                    //    updateDepartment.Count = model.TeacherDepartments.FirstOrDefault(rec =>
                    //    rec.Id == updateDepartment.Id).Count;
                    //}

                    context.SaveChanges();
                    context.LoadTeacherPeriods.RemoveRange(context.LoadTeacherPeriods.Where(rec => rec.LoadTeacherId == model.Id && !periodIds.Contains(rec.PeriodId)));
                    context.SaveChanges();

                    // новые записи  
                    var periods = model.LoadTeacherPeriods;
                    //.Where(rec => rec.Id == new Guid(0, 0, 0, new byte[8])) //????
                    //.GroupBy(rec => rec.DepartmentId)
                    //.Select(rec => new
                    //{
                    //    DepartmentId = rec.Key
                    //});

                    foreach (var period in periods)
                    {
                        LoadTeacherPeriod elementLTP = context.LoadTeacherPeriods
                            .FirstOrDefault(rec => rec.LoadTeacherId == model.Id && rec.PeriodId == period.PeriodId);

                        if (elementLTP != null)
                        {
                            elementLTP.NumderOfHours = period.NumderOfHours;
                            //elementPC.Count += groupPart.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.LoadTeacherPeriods.Add(new LoadTeacherPeriod
                            {
                                Id = Guid.NewGuid(),//???
                                LoadTeacherId = model.Id,
                                PeriodId = period.PeriodId,
                                NumderOfHours = period.NumderOfHours
                            });
                            context.SaveChanges();
                        }
                    }


                    // обновляем существуюущие компоненты 
                    var auditoriumIds = model.LoadTeacherAuditoriums.Select(rec => rec.AuditoriumId).Distinct();

                    var updateAuditoriums = context.LoadTeacherAuditoriums
                        .Where(rec => rec.LoadTeacherId == model.Id && auditoriumIds.Contains(rec.AuditoriumId));

                    //foreach (var updateDepartment in updateDepartments)
                    //{
                    //    updateDepartment.Count = model.TeacherDepartments.FirstOrDefault(rec =>
                    //    rec.Id == updateDepartment.Id).Count;
                    //}

                    context.SaveChanges();
                    context.LoadTeacherAuditoriums.RemoveRange(context.LoadTeacherAuditoriums.Where(rec => rec.LoadTeacherId == model.Id && !auditoriumIds.Contains(rec.AuditoriumId)));
                    context.SaveChanges();

                    // новые записи  
                    var auditoriums = model.LoadTeacherAuditoriums;
                    //.Where(rec => rec.Id == new Guid(0, 0, 0, new byte[8])) //????
                    //.GroupBy(rec => rec.DepartmentId)
                    //.Select(rec => new
                    //{
                    //    DepartmentId = rec.Key
                    //});

                    foreach (var auditorium in auditoriums)
                    {
                        LoadTeacherAuditorium elementLTA = context.LoadTeacherAuditoriums
                            .FirstOrDefault(rec => rec.LoadTeacherId == model.Id && rec.AuditoriumId == auditorium.AuditoriumId);

                        if (elementLTA != null)
                        {
                            //elementPC.Count += groupPart.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.LoadTeacherAuditoriums.Add(new LoadTeacherAuditorium
                            {
                                Id = Guid.NewGuid(),//???
                                LoadTeacherId = model.Id,
                                AuditoriumId = auditorium.AuditoriumId
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
                    LoadTeacher element = context.LoadTeachers.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        // удаяем записи по периодам и аудиториям при удалении расчасовки
                        context.LoadTeacherPeriods.RemoveRange(context.LoadTeacherPeriods.Where(rec => rec.LoadTeacherId == id));
                        context.LoadTeacherAuditoriums.RemoveRange(context.LoadTeacherAuditoriums.Where(rec => rec.LoadTeacherId == id));
                        context.LoadTeachers.Remove(element);
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
