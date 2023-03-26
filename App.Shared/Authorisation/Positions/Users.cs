using System.ComponentModel;

namespace App.Shared.Authorisation.Positions
{
    public enum Users : byte
    {
        [Description("Internal")] Internal = 0,
        [Description("External")] External = 1,
    }
}
