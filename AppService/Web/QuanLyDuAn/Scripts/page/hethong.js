const ACTION_ACCOUNT = "/Accounts"; 
const ACTION_CMD_ACCOUNT = "/Account"; 
const ACTION_ACCOUNT_INFO = "/AccountInfo"; 
const ACTION_GROUP_ACCOUNT = "/GroupAccount"; 
const ACTION_GROUP = "/Groups"; 
const ACTION_GROUP_ACTION_PERMISTION = "/GroupActionPermistion"; 
const ACTION_PERMISTION = "/Permistions"; 
const ACTION_ACTION = "/Actions"; 
const ACTION_CONTRACTOR = "/ContractorInfo";


var listActiveStatus = [
    { value: true, text: "Hoạt động", color: "success", icon: 'fa fa-check-circle' },
    { value: false, text: "Tạm dừng", color: "danger", icon: 'fa fa-minus-circle' },
]


const AccountType = [
    {
        ID: 1,
        Name: "Cty Tây Hồ",
    },
    {
        ID: 2,
        Name: "Nhà thầu",
    },
];
 