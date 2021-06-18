﻿using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Data.Repositories.IRepository;
using System.Linq;

namespace FTask.Data.Repositories
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        private FTaskContext context;
        public TaskRepository(FTaskContext context) : base(context)
        {
            this.context = context;
        }
        public Task GetTaskByTaskId(int id)
        {
            return FindByCondition(x => x.TaskId == id).FirstOrDefault();
        }

        public PagedList<Task> GetTasks(TaskParameters taskParameters)
        {
            return PagedList<Task>
                .ToPagedList(FindAll(), taskParameters.PageNumber, taskParameters.PageSize);
        }
    }
}