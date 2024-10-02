using System;
using WebAPI.Business.Infrastructure;
using Library.Core.Source;
using WebAPI.DataContext;
using WebAPI.Model;

namespace WebAPI.Business
{
    public class OvertimeServices: IOvertimeServices
    {
        private LearningDBContext _context;
        private ICommonServices _commonServices;

        public OvertimeServices(LearningDBContext context, ICommonServices commonServices)
        {
            _context = context;
            _commonServices = commonServices;
        }

        public List<OvertimeModel> InitOvertimeData()
        {
            var listOvertime = new List<OvertimeModel>();
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 4),
                TimeFrom = new DateTime(2023, 4, 4, 17, 30, 0),
                TimeTo = new DateTime(2023, 4, 4, 19, 30, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 2,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 5),
                TimeFrom = new DateTime(2023, 4, 5, 19, 30, 0),
                TimeTo = new DateTime(2023, 4, 5, 21, 30, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 2,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 6),
                TimeFrom = new DateTime(2023, 4, 6, 17, 30, 0),
                TimeTo = new DateTime(2023, 4, 6, 20, 0, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 2.5,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 7),
                TimeFrom = new DateTime(2023, 4, 7, 17, 30, 0),
                TimeTo = new DateTime(2023, 4, 7, 21, 30, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 4,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 8),
                TimeFrom = new DateTime(2023, 4, 8, 9, 0, 0),
                TimeTo = new DateTime(2023, 4, 8, 12, 00, 0),
                DurationTypeName = "Không giới hạn",
                OvertimeTypeName = "Tăng ca cuối tuần 2.0",
                ShiftName = string.Empty,
                TimeShift = string.Empty,
                RegisterHours = 3,
                Status = Status.E_SUBMIT.ToString(),
                StatusName = "Chờ duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 9),
                TimeFrom = new DateTime(2023, 4, 9, 9, 0, 0),
                TimeTo = new DateTime(2023, 4, 9, 12, 00, 0),
                DurationTypeName = "Không giới hạn",
                OvertimeTypeName = "Tăng ca cuối tuần 2.0",
                ShiftName = string.Empty,
                TimeShift = string.Empty,
                RegisterHours = 3,
                Status = Status.E_SUBMIT_TEMP.ToString(),
                StatusName = "Lưu tạm",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 11),
                TimeFrom = new DateTime(2023, 4, 4, 17, 30, 0),
                TimeTo = new DateTime(2023, 4, 4, 19, 30, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 2,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 12),
                TimeFrom = new DateTime(2023, 4, 5, 19, 30, 0),
                TimeTo = new DateTime(2023, 4, 5, 21, 30, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 2,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 13),
                TimeFrom = new DateTime(2023, 4, 6, 17, 30, 0),
                TimeTo = new DateTime(2023, 4, 6, 20, 0, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 2.5,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 14),
                TimeFrom = new DateTime(2023, 4, 7, 17, 30, 0),
                TimeTo = new DateTime(2023, 4, 7, 21, 30, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 4,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 15),
                TimeFrom = new DateTime(2023, 4, 8, 9, 0, 0),
                TimeTo = new DateTime(2023, 4, 8, 12, 00, 0),
                DurationTypeName = "Không giới hạn",
                OvertimeTypeName = "Tăng ca cuối tuần 2.0",
                ShiftName = string.Empty,
                TimeShift = string.Empty,
                RegisterHours = 3,
                Status = Status.E_SUBMIT.ToString(),
                StatusName = "Chờ duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 16),
                TimeFrom = new DateTime(2023, 4, 9, 9, 0, 0),
                TimeTo = new DateTime(2023, 4, 9, 12, 00, 0),
                DurationTypeName = "Không giới hạn",
                OvertimeTypeName = "Tăng ca cuối tuần 2.0",
                ShiftName = string.Empty,
                TimeShift = string.Empty,
                RegisterHours = 3,
                Status = Status.E_SUBMIT_TEMP.ToString(),
                StatusName = "Lưu tạm",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 18),
                TimeFrom = new DateTime(2023, 4, 4, 17, 30, 0),
                TimeTo = new DateTime(2023, 4, 4, 19, 30, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 2,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 19),
                TimeFrom = new DateTime(2023, 4, 5, 19, 30, 0),
                TimeTo = new DateTime(2023, 4, 5, 21, 30, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 2,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 20),
                TimeFrom = new DateTime(2023, 4, 6, 17, 30, 0),
                TimeTo = new DateTime(2023, 4, 6, 20, 0, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 2.5,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 21),
                TimeFrom = new DateTime(2023, 4, 7, 17, 30, 0),
                TimeTo = new DateTime(2023, 4, 7, 21, 30, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 4,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 22),
                TimeFrom = new DateTime(2023, 4, 8, 9, 0, 0),
                TimeTo = new DateTime(2023, 4, 8, 12, 00, 0),
                DurationTypeName = "Không giới hạn",
                OvertimeTypeName = "Tăng ca cuối tuần 2.0",
                ShiftName = string.Empty,
                TimeShift = string.Empty,
                RegisterHours = 3,
                Status = Status.E_SUBMIT.ToString(),
                StatusName = "Chờ duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 23),
                TimeFrom = new DateTime(2023, 4, 9, 9, 0, 0),
                TimeTo = new DateTime(2023, 4, 9, 12, 00, 0),
                DurationTypeName = "Không giới hạn",
                OvertimeTypeName = "Tăng ca cuối tuần 2.0",
                ShiftName = string.Empty,
                TimeShift = string.Empty,
                RegisterHours = 3,
                Status = Status.E_SUBMIT_TEMP.ToString(),
                StatusName = "Lưu tạm",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 25),
                TimeFrom = new DateTime(2023, 4, 4, 17, 30, 0),
                TimeTo = new DateTime(2023, 4, 4, 19, 30, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 2,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 26),
                TimeFrom = new DateTime(2023, 4, 5, 19, 30, 0),
                TimeTo = new DateTime(2023, 4, 5, 21, 30, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 2,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 27),
                TimeFrom = new DateTime(2023, 4, 6, 17, 30, 0),
                TimeTo = new DateTime(2023, 4, 6, 20, 0, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 2.5,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 28),
                TimeFrom = new DateTime(2023, 4, 7, 17, 30, 0),
                TimeTo = new DateTime(2023, 4, 7, 21, 30, 0),
                DurationTypeName = "Sau ca",
                OvertimeTypeName = "Tăng ca ngày thường 1.0",
                ShiftName = "Hành Chính",
                TimeShift = "08:00 - 17:30",
                RegisterHours = 4,
                Status = Status.E_APPROVED.ToString(),
                StatusName = "Duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 29),
                TimeFrom = new DateTime(2023, 4, 8, 9, 0, 0),
                TimeTo = new DateTime(2023, 4, 8, 12, 00, 0),
                DurationTypeName = "Không giới hạn",
                OvertimeTypeName = "Tăng ca cuối tuần 2.0",
                ShiftName = string.Empty,
                TimeShift = string.Empty,
                RegisterHours = 3,
                Status = Status.E_SUBMIT.ToString(),
                StatusName = "Chờ duyệt",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            listOvertime.Add(new OvertimeModel()
            {
                Id = Guid.NewGuid(),
                CodeEmp = "00549",
                ProfileName = "Lê Văn Minh",
                ImagePath = "minh00549.png",
                PositionName = "Trưởng nhóm lập trình",
                JobTitleName = "Leader",
                WorkDate = new DateTime(2023, 4, 30),
                TimeFrom = new DateTime(2023, 4, 9, 9, 0, 0),
                TimeTo = new DateTime(2023, 4, 9, 12, 00, 0),
                DurationTypeName = "Không giới hạn",
                OvertimeTypeName = "Tăng ca ngày lễ 3.0",
                ShiftName = string.Empty,
                TimeShift = string.Empty,
                RegisterHours = 3,
                Status = Status.E_SUBMIT_TEMP.ToString(),
                StatusName = "Lưu tạm",
                OvertimeReason = "Làm việc ngoài giờ",

                UserApproveName1 = "Nguyên Hoàng Tú Vân",
                ImagePathUserApprove1 = "",
                UserCommentApprove1 = "Duyệt 1",

                UserApproveName2 = "Hoàng Xuân Giang",
                ImagePathUserApprove2 = "",
                UserCommentApprove2 = "Duyệt 2",

                UserApproveName3 = "Trần Thị Ngọc Trang",
                ImagePathUserApprove3 = "",
                UserCommentApprove3 = "Duyệt 3",

                UserApproveName4 = "Nguyễn Thành Tín",
                ImagePathUserApprove4 = "",
                UserCommentApprove4 = "Duyệt cuối"
            });
            
            listOvertime.OrderByDescending(s => s.WorkDate).ToList();
            SetValueFieldGroupGrid(listOvertime);
            return listOvertime;
        }

        private void SetValueFieldGroupGrid(List<OvertimeModel> listOvertime)
        {
            foreach (var overtime in listOvertime)
            {
                overtime.ProfileInfo = _commonServices.SetValueGroupFieldProfileInfo(overtime);
                overtime.DataTimeInfo = _commonServices.SetValueGroupFieldTimeInfo(overtime);
                overtime.DurationInfo = _commonServices.SetValueGroupFieldDurationType(overtime);
                overtime.StatusInfo = _commonServices.SetValueGroupFieldStatusInfo(overtime, out string? dataNote);
                overtime.DataNote = dataNote;
            }
        }
    }
}

