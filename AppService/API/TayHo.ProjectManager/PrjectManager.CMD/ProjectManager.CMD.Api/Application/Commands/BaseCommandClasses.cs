using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class BaseCommandClasses
    {
        public int? Id { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsVisible { get; set; }
        public byte? Status { get; set; }
    }
}
