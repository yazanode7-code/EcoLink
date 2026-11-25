namespace EcoLink.Constants;

public static class AppRoles
{
    public const string Admin = "Admin";
    public const string BranchEmployee = "BranchEmployee";
    public const string Factory = "Factory";
    public const string Driver = "Driver";

    public static readonly string[] All = { Admin, BranchEmployee, Factory, Driver };
}