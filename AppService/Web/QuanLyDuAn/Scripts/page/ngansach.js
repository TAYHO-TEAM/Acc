const ACTION_PROJECT            = "/Projects";
const ACTION_NHOMCONGVIEC       = "/NS_NhomCongViec";
const ACTION_CONGVIEC           = "/NS_CongViec";
const ACTION_NHOMCONGVIECDETAIL = "/NS_NhomCongViecDetail";
const ACTION_HANGMUC            = "/NS_HangMuc";
const ACTION_LOAICONGVIEC       = "/NS_LoaiCongViec";
const ACTION_GIAIDOAN           = "/NS_GiaiDoan";
const ACTION_HANGMUCDETAIL      = "/NS_HangMucDetail";
const ACTION_CONGVIECDETAIL     = "/NS_CongViecDetail";
const ACTION_GOITHAU            = "/NS_GoiThau";
const ACTION_NHOMCHIPHI         = "/NS_NhomChiPhi";
const ACTION_REASON             = "/NS_Reason";
const ACTION_CONTRACTORINFO     = "/ContractorInfo ";
const ACTION_NGHIEMTHU          = "/NS_NghiemThu";

const ACTION_PHAT               = "/NS_Phat";
const ACTION_PHAT_THEODOI       = "/NS_Phat_TheoDoi";
const ACTION_PHAT_NHOM          = "/NS_Phat_Nhom";
const ACTION_TAMUNG             = "/NS_TamUng";
const ACTION_TAMUNG_THEODOI     = "/NS_TamUng_TheoDoi";
const ACTION_KHAUTRU            = "/NS_KhauTru";
const ACTION_KHAUTRU_THEODOI    = "/NS_KhauTru_TheoDoi";

const ACTION_DUCHI              = "/NS_DuChi";
const ACTION_THUCCHI = "/NS_ThucChi";

const ACTION_GROUP = "/Groups"; 
var GIAIDOANID = isNullOrEmpty(localStorage.getItem("giaiDoanIdCurrent")) ? parseInt(localStorage.getItem("giaiDoanIdCurrent")) : 0;

var listActiveStatus = [
    { value: true, text: "Hoạt động", color: "success", icon: 'fa fa-check-circle' },
    { value: false, text: "Tạm dừng", color: "danger", icon: 'fa fa-minus-circle' },
]

var customStore_Projects = new DevExpress.data.DataSource({
    store: new DevExpress.data.CustomStore({
        key: "id",
        load: (values) => ajax_read(ACTION_PROJECT, values),
        byKey: (key) => {
            var deferred = $.Deferred();
            customStore_Projects.store().load().done((rs) => {
                deferred.resolve(rs.find(x => x.id == key));
            });
            return deferred.promise();
        },
    }),
    filter: ["isActive", "=", 1]
});

var customStore_Phat_Nhom = new DevExpress.data.CustomStore({
    key: "id", loadMode: "raw",
    load: (values) => {
        var deferred = $.Deferred();
        var params = { "FindId": 'isActive,1;IsVisible,1' };
        $.ajax({
            headers: header, dataType: "json",
            data: params,
            url: URL_API_PM_READ + ACTION_PHAT_NHOM,
            success: (data) => deferred.resolve(data.result.items),
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Projects'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
});
 