using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IRepositoty;
using Tuby.Api.IServices;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{
    public class LeaveRecordServices : BaseServices<LeaveRecordView>, ILeaveRecordServices
    {
        public ILeaveRecordRepository _dal;

        public LeaveRecordServices(ILeaveRecordRepository dal)
        {
            this._dal = dal;
        }
        public Task<List<LeaveRecordView>> QueryMuchTable()
        {
            return _dal.QueryMuchTable();
        }
    }
}
