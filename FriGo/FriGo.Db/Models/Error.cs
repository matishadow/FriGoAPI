﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriGo.Db.Models.Social;

namespace FriGo.Db.Models
{
    public class Error 
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
