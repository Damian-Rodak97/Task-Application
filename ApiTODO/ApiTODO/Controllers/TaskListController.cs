﻿using System.Linq;
using ApiTODO.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiTODO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskListRepository repository;
        private readonly UserManager<User> userManager;
        public TaskListController(ITaskListRepository repository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("AddTaskList")]
        public IActionResult AddTaskList(TaskListViewModel taskViewModel)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            TaskList taskList = new TaskList
            {
                Name = taskViewModel.Name,
                UserId = userId
            };
            repository.SaveTaskList(taskList);
            return Ok();
        }

        [HttpGet]
        [Route("TaskList")]
        public IActionResult GetTaskList()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var listTask = repository.TaskLists
                .Where(t => t.User.Id == userId);
            return Ok(listTask);
        }

        [HttpDelete]
        [Route("DeleteTaskList/{taskListId}")]
        public IActionResult DeleteTaskList([FromRoute]int taskListId)
        {
            var taskList = repository.TaskLists.FirstOrDefault(x => x.Id == taskListId);
            repository.DeleteTaskList(taskList);
            return Ok();
        }

        [HttpPut]
        [Route("EditTaskList")]
        public IActionResult EditTaskList(TaskList taskView)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            TaskList taskList = new TaskList
            {
                Id = taskView.Id,
                Name = taskView.Name,
                UserId = userId
            };
            repository.SaveTaskList(taskList);
            return Ok();
        }
    }
}
