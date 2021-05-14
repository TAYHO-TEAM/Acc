using Acc.Read.Api.ViewModels.BaseClasses;
using System;

namespace Acc.Read.Api.ViewModels
{
    public class StagesResponseViewModel : BaseResponseViewModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
    }
}
