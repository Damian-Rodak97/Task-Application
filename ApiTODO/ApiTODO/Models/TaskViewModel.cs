﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTODO.Models
{
    public class TaskViewModel
    {
        public IEnumerable<Task> Tasks { get; set; }
    }
}
