using App.Shared.Authorisation.Responsibilities;

namespace App.Shared.Authorisation
{
    public class RoleAuthorisationDecorator
    {
        public RoleAuthorisationDecorator(params Roles[] roleTypes)
        {
            RoleTypes = roleTypes;
        }

        public Roles[] RoleTypes { get; set; }
    }
}
