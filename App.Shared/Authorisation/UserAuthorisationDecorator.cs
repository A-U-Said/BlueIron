using App.Shared.Authorisation.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Shared.Authorisation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class UserAuthorisationDecorator : Attribute
    {
        public UserAuthorisationDecorator(params Users[] userTypes)
        {
            UserTypes = userTypes;
        }

        public Users[] UserTypes { get; set; }
    }
}
