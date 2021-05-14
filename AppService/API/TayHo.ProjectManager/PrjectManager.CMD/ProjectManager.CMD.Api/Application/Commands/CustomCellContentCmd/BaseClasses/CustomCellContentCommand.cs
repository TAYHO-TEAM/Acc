using System.Collections.Generic;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CustomCellContentCommandResponseDTO : CustomCellContentCommandSet
    {
     
    }
    public class FormCustomCellContentCommandResponseDTO : FormCustomCellContentCommandSet
    {

    }
    public class CustomCellContentCommandResponseDTOs 
    {
        public List<CustomCellContentCommandSet> customCellContentCommandSets { get; set; } = new List<CustomCellContentCommandSet>();
    }
}