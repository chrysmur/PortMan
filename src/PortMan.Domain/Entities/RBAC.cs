namespace PortMan.Domain;

public class AccessRoles
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class AccessGroups
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid TenantId { get; set; }
}

public class UserAccessGroups
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid AccessGroupId { get; set; }
}

public class AccessGroupRoles
{
    public Guid Id { get; set; }
    public Guid AccessGroupId { get; set; }
    public Guid RoleId { get; set; }
}

