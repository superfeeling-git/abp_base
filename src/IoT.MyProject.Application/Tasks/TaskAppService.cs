using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using IoT.MyProject.Tasks.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.MyProject.Tasks
{
    public class TaskAppService: AsyncCrudAppService<Task,TaskListDto>
    {
        private readonly IRepository<Task> _taskRepository;

        public TaskAppService(IRepository<Task> taskRepository)
            :base(taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<List<TaskListDto>> QueryTask()
        {
            var list = await  _taskRepository.GetAllListAsync();
            return ObjectMapper.Map<List<TaskListDto>>(list);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task CreateTask()
        {
             await _taskRepository.InsertAsync(new Task { Title = "测试", Description = "说明" });
        }
    }
}
