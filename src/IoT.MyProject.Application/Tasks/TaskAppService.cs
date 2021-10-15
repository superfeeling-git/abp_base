using Abp.Application.Services;
using Abp.Domain.Repositories;
using IoT.MyProject.Tasks.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.MyProject.Tasks
{
    public class TaskAppService: AsyncCrudAppService<Task,TaskDto>
    {
        private readonly IRepository<Task> _taskRepository;
        
        public TaskAppService(IRepository<Task> taskRepository)
            :base(taskRepository)
        {
            this._taskRepository = taskRepository;
        }

        public void Test()
        {

        }
    }
}
