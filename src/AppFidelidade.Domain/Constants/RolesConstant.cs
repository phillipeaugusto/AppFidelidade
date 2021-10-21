namespace AppFidelidade.Core.Constants
{
    public static class RolesConstant
    {
        public const string RoleAdministrator = "adm";
        public const string RoleUser = "user";
        public const string RoleAdmUser = RoleAdministrator + "," + RoleUser;
    }
}