using System;
using WebAPI.Business.Infrastructure;
using Library.Core.BaseModel;
using Library.Core.Source;
using WebAPI.Model;

namespace WebAPI.Business
{
    public class CommonServices: ICommonServices
    {
        public CommonServices()
        {

        }

        public ProfileInfo SetValueGroupFieldProfileInfo<TEntity>(TEntity entity)
        {
            var profileInfo = new ProfileInfo();

            #region overtime
            if (entity?.GetType().Name == "OvertimeModel")
            {
                var overtime = entity as OvertimeModel;
                profileInfo.CodeEmp = overtime?.CodeEmp;
                profileInfo.ProfileName = overtime?.ProfileName;
                profileInfo.ImagePath = overtime?.ImagePath;
                profileInfo.JobTitleName = overtime?.JobTitleName;
                profileInfo.PositionName = overtime?.PositionName;
            }
            #endregion

            profileInfo.ImagePath = $"Images/{profileInfo.ImagePath}";
            return profileInfo;
        }

        public DataTimeInfo SetValueGroupFieldTimeInfo<TEntity>(TEntity entity)
        {
            var dataTimeInfo = new DataTimeInfo();

            #region Overtime
            if (entity?.GetType().Name == "OvertimeModel")
            {
                var overtime = entity as OvertimeModel;
                dataTimeInfo.WorkDate = overtime?.WorkDate?.ToString("dd/MM/yyyy");
                dataTimeInfo.TimeShift = !string.IsNullOrEmpty(overtime?.TimeShift) ? $"({overtime?.TimeShift})" : string.Empty;
                dataTimeInfo.ShiftName = overtime?.ShiftName;
            }
            #endregion

            return dataTimeInfo;
        }

        public DurationInfo SetValueGroupFieldDurationType<TEntity>(TEntity entity)
        {
            var durationInfo = new DurationInfo();

            #region Overtime
            if (entity?.GetType().Name == "OvertimeModel")
            {
                var overtime = entity as OvertimeModel;
                durationInfo.DurationName = $"{overtime?.DurationTypeName} ({overtime?.OvertimeTypeName})";
                durationInfo.RegisterHours = $"{overtime?.RegisterHours?.ToString()} giờ";
                durationInfo.TimeInfo = $"({overtime?.TimeFrom?.ToString("HH:mm")} - {overtime?.TimeTo?.ToString("HH:mm")})";
            }
            #endregion

            return durationInfo;
        }

        public StatusInfo SetValueGroupFieldStatusInfo<TEntity>(TEntity entity, out string? dataNote)
        {
            var statusInfo = new StatusInfo();
            dataNote = string.Empty;
            var listUserApproved = new List<LevelApproveInfo>();

            #region Overtime
            if (entity?.GetType().Name == "OvertimeModel")
            {
                var overtime = entity as OvertimeModel;
                statusInfo.Status = overtime?.Status;
                statusInfo.StatusName = overtime?.StatusName;

                if (overtime?.Status == Status.E_SUBMIT.ToString() || overtime?.Status == Status.E_SUBMIT_TEMP.ToString())
                {
                    dataNote = overtime?.OvertimeReason;
                    if (overtime?.Status == Status.E_SUBMIT.ToString())
                    {
                        statusInfo.UserApproveName = overtime?.UserApproveName1;
                        statusInfo.ImagePath = $"Images/{overtime?.ImagePathUserApprove1}";
                    }
                }

                if (overtime?.Status == Status.E_APPROVED1.ToString())
                {
                    dataNote = overtime?.OvertimeReason;
                    statusInfo.UserApproveName = overtime?.UserApproveName2;
                    statusInfo.ImagePath = $"Images/{overtime?.ImagePathUserApprove2}";
                }

                if (overtime?.Status == Status.E_APPROVED2.ToString())
                {
                    dataNote = overtime?.OvertimeReason;
                    statusInfo.UserApproveName = overtime?.UserApproveName3;
                    statusInfo.ImagePath = $"Images/{overtime?.ImagePathUserApprove3}";
                }

                if (overtime?.Status == Status.E_APPROVED3.ToString())
                {
                    dataNote = overtime?.OvertimeReason;
                    statusInfo.UserApproveName = overtime?.UserApproveName4;
                    statusInfo.ImagePath = $"Images/{overtime?.ImagePathUserApprove4}";
                }

                if (overtime?.Status == Status.E_APPROVED.ToString())
                {
                    dataNote = overtime?.UserCommentApprove4;
                    statusInfo.UserApproveName = overtime?.UserApproveName4;
                    statusInfo.ImagePath = $"Images/{overtime?.ImagePathUserApprove4}";
                }

                if (overtime?.Status == Status.E_CANCELLED.ToString())
                {
                    dataNote = overtime?.UserCommentCancelled;
                    statusInfo.UserApproveName = overtime?.UserCommentCancelled;
                    statusInfo.ImagePath = $"Images/{overtime?.ImagePathUserCancelled}";
                }

                if (overtime?.Status == Status.E_REJECTED.ToString())
                {
                    dataNote = overtime?.UserCommentRejected;
                    statusInfo.UserApproveName = overtime?.UserCommentRejected;
                    statusInfo.ImagePath = $"Images/{overtime?.ImagePathUserRejected}";
                }

                #region ListApprove
                listUserApproved.Add(new LevelApproveInfo()
                {
                    UserApproveName = overtime?.UserApproveName1,
                    ImagePathUserApprove = $"Images/{overtime?.ImagePathUserApprove1}",
                });
                listUserApproved.Add(new LevelApproveInfo()
                {
                    UserApproveName = overtime?.UserApproveName2,
                    ImagePathUserApprove = $"Images/{overtime?.ImagePathUserApprove2}",
                });
                listUserApproved.Add(new LevelApproveInfo()
                {
                    UserApproveName = overtime?.UserApproveName3,
                    ImagePathUserApprove = $"Images/{overtime?.ImagePathUserApprove3}",
                });
                listUserApproved.Add(new LevelApproveInfo()
                {
                    UserApproveName = overtime?.UserApproveName4,
                    ImagePathUserApprove = $"Images/{overtime?.ImagePathUserApprove4}",
                });
                #endregion
            }
            #endregion

            statusInfo.ListLevelApprove = listUserApproved;
            return statusInfo;
        }
    }
}

