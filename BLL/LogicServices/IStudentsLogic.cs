﻿using BOL.DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogicServices
{
    public interface IStudentsLogic
    {
        List<Students> GetStudentsListLogic();
        string SaveStudentRecordLogic(Students FormData);
    }
}
