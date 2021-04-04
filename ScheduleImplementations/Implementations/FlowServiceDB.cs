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
    public class FlowServiceDB : IFlowService
    {
        private AbstractDbContext context;

        public FlowServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<FlowViewModel> GetList()
        {
            List<FlowViewModel> result = context.Flows.Select
                (rec => new FlowViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title,

                    FlowStudyGroups = context.FlowStudyGroups
                    .Where(recFS => recFS.FlowId == rec.Id)
                    .Select(recFS => new FlowStudyGroupViewModel
                    {
                        Id = recFS.Id,
                        FlowId = recFS.FlowId,
                        StudyGroupId = recFS.StudyGroupId,
                        StudyGroupTitle = recFS.StudyGroup.Title,
                        Subgroup = recFS.Subgroup
                    }).ToList()

                }).ToList();

            return result;
        }

        public FlowViewModel GetElement(Guid id)
        {
            Flow element = context.Flows.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new FlowViewModel
                {
                    Id = element.Id,
                    Title = element.Title,

                    FlowStudyGroups = context.FlowStudyGroups
                    .Where(rec => rec.FlowId == element.Id)
                    .Select(rec => new FlowStudyGroupViewModel
                    {
                        Id = rec.Id,
                        FlowId = rec.FlowId,
                        StudyGroupId = rec.StudyGroupId,
                        StudyGroupTitle = rec.StudyGroup.Title,
                        Subgroup = rec.Subgroup
                    }).ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(FlowBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Flow element = context.Flows.FirstOrDefault(rec => rec.Title == model.Title);
                    if (element != null)
                    {
                        throw new Exception("Уже есть такой поток");
                    }
                    element = new Flow
                    {
                        Id = Guid.NewGuid(),//???
                        Title = model.Title
                    };
                    context.Flows.Add(element);
                    context.SaveChanges();

                    // убираем дубли 
                    var studygroups = model.FlowStudyGroups;
                        //.GroupBy(rec => rec.StudyGroupId)
                        //.Select(rec => new
                        //{
                        //    StudyGroupId = rec.Key,
                        //    Subgroup = rec.
                        //});

                    // добавляем группы 
                    foreach (var studygroup in studygroups)
                    {
                        context.FlowStudyGroups.Add(new FlowStudyGroup
                        {
                            Id = Guid.NewGuid(),//???
                            FlowId = element.Id,
                            StudyGroupId = studygroup.StudyGroupId,
                            Subgroup = studygroup.Subgroup
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


        public void UpdElement(FlowBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Flow element = context.Flows.FirstOrDefault(rec => rec.Id != model.Id && rec.Title == model.Title);
                    if (element != null)
                    {
                        throw new Exception("Уже есть такой поток");
                    }
                    element = context.Flows.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.Title = model.Title;
                    context.SaveChanges();

                    // обновляем существуюущие компоненты 
                    var studygroupIds = model.FlowStudyGroups.Select(rec => rec.StudyGroupId).Distinct();

                    var updateStudygroups = context.FlowStudyGroups
                        .Where(rec => rec.FlowId == model.Id && studygroupIds.Contains(rec.StudyGroupId));

                    //foreach (var updateDepartment in updateDepartments)
                    //{
                    //    updateDepartment.Count = model.TeacherDepartments.FirstOrDefault(rec =>
                    //    rec.Id == updateDepartment.Id).Count;
                    //}

                    context.SaveChanges();
                    context.FlowStudyGroups.RemoveRange(context.FlowStudyGroups.Where(rec => rec.FlowId == model.Id && !studygroupIds.Contains(rec.StudyGroupId)));
                    context.SaveChanges();

                    // новые записи  
                    var studygroups = model.FlowStudyGroups;
                    //.Where(rec => rec.Id == new Guid(0, 0, 0, new byte[8])) //????
                    //.GroupBy(rec => rec.StudyGroupId)
                    //.Select(rec => new
                    //{
                    //    StudyGroupId = rec.Key,
                    //    Subgroup = rec.FirstOrDefault()
                    //});

                    foreach (var studygroup in studygroups)
                    {
                        FlowStudyGroup elementFS = context.FlowStudyGroups
                            .FirstOrDefault(rec => rec.FlowId == model.Id && rec.StudyGroupId == studygroup.StudyGroupId);

                        if (elementFS != null)
                        {
                            elementFS.Subgroup = studygroup.Subgroup;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.FlowStudyGroups.Add(new FlowStudyGroup
                            {
                                Id = Guid.NewGuid(),//???
                                FlowId = model.Id,
                                StudyGroupId = studygroup.StudyGroupId,
                                Subgroup = studygroup.Subgroup
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
                    Flow element = context.Flows.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        // удаяем записи по групам при удалении потока
                        context.FlowStudyGroups.RemoveRange(context.FlowStudyGroups.Where(rec => rec.FlowId == id));
                        context.Flows.Remove(element);
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
