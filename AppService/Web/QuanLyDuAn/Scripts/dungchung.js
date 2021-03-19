//Tinh chiều cao - chiều cao header
var heightScreen = $(document).height() - $('.main-header').height()-50;
var heightScreenWithFilter = heightScreen - $("#container-filter").parent().parent().parent().parent().height()-65;
var widthScreen = $(document).width();
//Thông số api
const api_version = 1; 
const URL_API_ACC_CMD = "https://api-acc-cmd.tayho.com.vn/api/cmd/v" + api_version;
const URL_API_ACC_READ = "https://api-acc-read.tayho.com.vn/api/read/v" + api_version; 
const URL_API_PM_CMD = "https://api-pm-cmd.tayho.com.vn/api/cmd/v" + api_version;
const URL_API_PM_READ = "https://api-pm-read.tayho.com.vn/api/read/v" + api_version; 
const URL_API_PM_READ_All = "https://api-pm-read.tayho.com.vn/api/read/v" + api_version +"/ProjectManager"; 

const listSexs = [
    {value: 0, text:"Nữ"},
    {value: 1, text:"Nam"},
    {value: 2, text:"Khác"},
];
const typeApprove = [
    { value: 1, text: "Đồng ý" },
    { value: 2, text: "Đồng ý kèm ý kiến" },
    { value: 3, text: "Từ chối" },
    { value: 4, text: "Trả lại" },
]; 
 