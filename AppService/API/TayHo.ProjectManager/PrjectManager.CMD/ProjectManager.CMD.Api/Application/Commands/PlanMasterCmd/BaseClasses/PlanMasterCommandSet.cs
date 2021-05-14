using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class PlanMasterCommandSet : BaseCommandClasses
    {
        public string Code { get; set; }
        public int? ParentId { get; set; }
        public string PlanProjectId { get; set; }
        //[Required(ErrorMessage = "Không được để trống")]
        public string Title { get; set; }
        public int? TimeLine { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Unit { get; set; }
        public int? Amount { get; set; }
        public string ReportPeriodicalType { get; set; }
        public int? ReportPeriodical { get; set; }
        public int? ReportFrequency { get; set; }
        public int? Priority { get; set; }
        public byte? ImportantLevel { get; set; }
        public byte? NoAttachment { get; set; }
        private IFormFileCollection _formFiles { get; set; }
        public void setFile(IFormFileCollection FormFiles)
        {
            _formFiles = FormFiles;
        }
        public IFormFileCollection getFile()
        {
            return _formFiles;
        }

    }
}
