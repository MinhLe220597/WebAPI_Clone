using System;
using Library.Core.BaseModel;

namespace WebAPI.Model
{
    public class OvertimeModel: GroupColumnModel
    {
        //Overtime
        public string? CodeEmp { get; set; }
        public string? ProfileName { get; set; }
        public string? ImagePath { get; set; }
        public string? PositionName { get; set; }
        public string? JobTitleName { get; set; }
        public DateTime? WorkDate { get; set; }
        public DateTime? TimeFrom { get; set; }
        public DateTime? TimeTo { get; set; }
        public string? DurationTypeName { get; set; }
        public string? OvertimeTypeName { get; set; }
        public string? ShiftName { get; set; }
        public string? TimeShift { get; set; }
        public double? RegisterHours { get; set; }
        public string? Status { get; set; }
        public string? StatusName { get; set; }
        public string? OvertimeReason { get; set; }

        //level approve
        public string? UserApproveName1 { get; set; }
        public string? ImagePathUserApprove1 { get; set; }
        public string? UserCommentApprove1 { get; set; }

        public string? UserApproveName2 { get; set; }
        public string? ImagePathUserApprove2 { get; set; }
        public string? UserCommentApprove2 { get; set; }

        public string? UserApproveName3 { get; set; }
        public string? ImagePathUserApprove3 { get; set; }
        public string? UserCommentApprove3 { get; set; }

        public string? UserApproveName4 { get; set; }
        public string? ImagePathUserApprove4 { get; set; }
        public string? UserCommentApprove4 { get; set; }

        public string? UserCancelledName { get; set; }
        public string? ImagePathUserCancelled { get; set; }
        public string? UserCommentCancelled { get; set; }

        public string? UserRejectedName { get; set; }
        public string? ImagePathUserRejected { get; set; }
        public string? UserCommentRejected { get; set; }

    }

    public class OvertimeSearchModel: RequestGrid
    {
        public string? Code { get; set; }
        public string? CategoryName { get; set; }
    }
}

