using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourTravel.Models;

namespace TourTravel.Repository
{
    public interface iAccount_Repository
    {
        Login_DTO AuthenticationUser(Login_Model MyModel);
    }
}