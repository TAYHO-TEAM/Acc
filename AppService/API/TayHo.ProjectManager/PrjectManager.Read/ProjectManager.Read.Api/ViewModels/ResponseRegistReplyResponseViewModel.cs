using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class ResponseRegistReplyResponseViewModel : BaseResponseChilCountViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReplyAccountId { get; set; }
        public int? ResponseRegitId { get; set; }
        public byte? NoAttachment { get; set; }
    }
}
