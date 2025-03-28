using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmacaspac201.Contracts
{
    public class OperationDto<T>
    {
        public Guid? ReferenceId { get; set; }
        public T? ReferenceData { get; set; }
        public OpStatus? Status { get; set; }
        public string? Message { get; set; }
    }
    public enum OpStatus
    {
        Ok = 0,
        Fail = 1,
    }
}
