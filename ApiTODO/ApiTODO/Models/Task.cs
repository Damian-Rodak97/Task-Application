﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTODO.Models
{
    public class Task
    {
        public TaskList TaskList { get; set; }
        public int TaskListId { get; set; }
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
