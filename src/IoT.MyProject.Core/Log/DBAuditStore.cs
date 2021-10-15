using Abp.Auditing;
using Abp.Dependency;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.MyProject.Log
{
    public class DBAuditStore : IAuditingStore, ITransientDependency
    {
        private readonly IRepository<MyLogAudited> _auditLogRepository;

        public DBAuditStore(IRepository<MyLogAudited> _auditLogRepository)
        {
            this._auditLogRepository = _auditLogRepository;
        }

        public void Save(AuditInfo auditInfo)
        {
            _auditLogRepository.Insert(MyLogAudited.CreateFromAuditInfo(auditInfo));
        }

        public async Task SaveAsync(AuditInfo auditInfo)
        {
            await _auditLogRepository.InsertAsync(MyLogAudited.CreateFromAuditInfo(auditInfo));
        }
    }
}
