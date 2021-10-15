using Abp.Auditing;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.MyProject.Log
{
    public class MyLogAudited: AuditedEntity
    {
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public string Parameters { get; set; }
        public string ReturnValue { get; set; }
        public DateTime ExecutionTime { get; set; }
        public int ExecutionDuration { get; set; }
        public string ClientIpAddress { get; set; }
        public string ClientName { get; set; }
        public string BrowserInfo { get; set; }
        //public Exception Exception { get; set; }
        public long? ImpersonatorUserId { get; set; }
        public int? ImpersonatorTenantId { get; set; }
        public string CustomData { get; set; }

        public static MyLogAudited CreateFromAuditInfo(AuditInfo auditInfo)
        {
            return new MyLogAudited
            {
                ServiceName = auditInfo.ServiceName,
                MethodName = auditInfo.MethodName,
                Parameters = auditInfo.Parameters,
                ReturnValue = auditInfo.ReturnValue,
                ExecutionTime = auditInfo.ExecutionTime,
                ExecutionDuration = auditInfo.ExecutionDuration,
                ClientIpAddress = auditInfo.ClientIpAddress,
                ClientName = auditInfo.ClientName,
                BrowserInfo = auditInfo.BrowserInfo,
                //Exception = auditInfo.Exception,
                ImpersonatorUserId = auditInfo.ImpersonatorUserId,
                ImpersonatorTenantId = auditInfo.ImpersonatorTenantId,
            };
        }
    }
}
