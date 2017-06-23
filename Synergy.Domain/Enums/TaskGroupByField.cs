namespace Synergy.Domain.Enums
{
    public enum TaskGroupByField
    {
        None = 0,
        Tag = 1,
        DueDate = 2,
        StartDate = 3,
        CreatedBy = 4,// (only in case of Assigned by and to), 
        CreatedOn = 5,
        AssignedBy = 6,
        AssignedTo = 7,
        Priority = 8,
        TypeId = 9,
        Project = 10,
        Location = 11,
        Checklist = 12, //.Name, 
        Status = 13,
        CompletedOn = 14
    }
}
