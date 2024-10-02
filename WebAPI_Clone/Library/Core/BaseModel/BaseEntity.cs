using System;
namespace Library.Core.BaseModel
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public string? UserCreate { get; set; }
        public DateTime? DateCreate { get; set; }
        public string? UserUpdate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public bool? IsDelete { get; set; }
    }

    public class BaseHandleProcessModel
    {
        public List<Guid>? RecordIds { get; set; }
    }

    public class GroupColumnModel : BaseEntity
    {
        public ProfileInfo? ProfileInfo { get; set; }
        public DataTimeInfo? DataTimeInfo { get; set; }
        public DurationInfo? DurationInfo { get; set; }
        public string? DataNote { get; set; }
        public StatusInfo? StatusInfo { get; set; }
    }

    public class ProfileInfo
    {
        public string? CodeEmp { get; set; }
        public string? ProfileName { get; set; }
        public string? ImagePath { get; set; }
        public string? PositionName { get; set; }
        public string? JobTitleName { get; set; }
    }

    public class DataTimeInfo
    {
        public string? WorkDate { get; set; }
        public string? ShiftName { get; set; }
        public string? TimeShift { get; set; }
    }

    public class DurationInfo
    {
        public string? DurationName { get; set; }
        public string? RegisterHours { get; set; }
        public string? TimeInfo { get; set; }

    }

    public class StatusInfo
    {
        public string? Status { get; set; }
        public string? StatusName { get; set; }
        public string? UserApproveName { get; set; }
        public string? ImagePath { get; set; }
        public List<LevelApproveInfo>? ListLevelApprove { get; set; }
    }

    public class LevelApproveInfo
    {
        public string? UserApproveName { get; set; }
        public string? ImagePathUserApprove { get; set; }
    }

    public class RequestGrid
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }

    public class ResponseModel
    {
        public string Message { get; set; } = string.Empty;
    }
}

