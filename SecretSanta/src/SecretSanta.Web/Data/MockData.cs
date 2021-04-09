﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Data
{
    public static class MockData
    {
        public static List<UserViewModel> Users = new List<UserViewModel>
        {
            new UserViewModel {FirstName = "Tyler", LastName = "Jones", GroupName = "Super Duper Cool Group", Id = 0},
            new UserViewModel {FirstName = "Mia", LastName = "Hunt", GroupName = "Super Duper Cool Group", Id = 1}
        };

        public static List<GroupViewModel> Groups = new List<GroupViewModel>
        {
            new GroupViewModel {GroupName = Users[0].GroupName, Users=new List<UserViewModel>{Users[0], Users[1]} }
        };
    }
}
