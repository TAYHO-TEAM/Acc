using System;
using System.Collections.Generic;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupAccountCommandResponseDTO : GroupAccountCommandSet
    {
     
    }
    public class GroupAccountListCommandResponseDTO 
    {
        public List<GroupAccountCommandResponseDTO> groupAccountCommandResponseDTOs { get; set; } = new List<GroupAccountCommandResponseDTO>();
    }
}