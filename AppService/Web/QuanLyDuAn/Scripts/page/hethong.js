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


let customStore_AccountInfo = (type) => new DevExpress.data.DataSource({
    store: new DevExpress.data.CustomStore({
        key: "id",
        loadMode: "raw",
        load: (values) => ajax_read(ACTION_ACCOUNT_INFO, values),
    }),
    //filter: [["type", "=", type]]
});


 