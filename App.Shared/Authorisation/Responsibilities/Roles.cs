using System.ComponentModel;

namespace App.Shared.Authorisation.Responsibilities
{
    public enum Roles : byte
    {
        [Description("Administrator")] Administrator = 0,
        [Description("User")] User = 1,
    }
}
