namespace Synergy.Domain.Enums
{
    public enum TaskOrderByField
    {
        None = 0,
        Number = 1,
        Name = 2,
        Tag = 3,
        DueDate = 4,
        StartDate = 5,
        CreatedBy = 6, //(only in case of Assigned by and to), 
        CreatedOn = 7,
        AssignedBy = 8,
        AssignedTo = 9,
        Priority = 10,
        Type = 11,
        Project = 12,
        Location = 13,
        Checklist = 14, //.Name, 
        Status = 15,
        CompletedOn = 16,
        CompletePct = 17
    }
}
