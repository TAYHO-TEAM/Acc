let checkLogin = () => (isNullOrEmpty(localStorage.getItem("userCurrent")) && isNullOrEmpty(window.localStorage.getItem("userCurrentInfo")));
var UserCurrent = localStorage.getItem("userCurrent");
var UserCurrentInfo = JSON.parse(localStorage.getItem("userCurrentInfo"));
var PROJECTID = isNullOrEmpty(localStorage.getItem("projectIdCurrent")) ? parseInt(localStorage.getItem("projectIdCurrent")) : 1;
var header = {};
var PermitInAction = { id: 0, view: false, insert: false, update: false, delete: false, readonly: false, assign: false, approve:false };

DevExpress.localization.locale('vi');

$(function () { 
    if (checkLogin()) loadMenu();
    else logout(window.location.pathname);
});

function ImgError(image) {
    image.onerror = "";
    image.src = "https://duan.tayho.com.vn/Content/img/avatar.png";
    return true;
}

function logout(url) {
    if (url == null || url.length == 0 || url == "/") url = "/Home";
    localStorage.clear();
    window.location = "/Account/Login?url=" + url;
} 
function loadMenu() {    
    //loadHeader
    header = {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'Authorization': 'Bearer ' + UserCurrentInfo.accessToken,
    };
    //loadInfo
    $('.user-panel div.image img')
        .attr("src", "data:image/png;base64," + UserCurrentInfo.avatarImg)
        .attr("alt", UserCurrentInfo.UserCurrent)
        .attr("onerror","ImgError(this);");
    $('.user-panel div.info a').html(UserCurrentInfo.userName != null ? UserCurrentInfo.userName : UserCurrent);
    $('.user-panel div.info span').html(UserCurrentInfo.title != null ? UserCurrentInfo.title:"Không xác định");
    //LoadMenu
    var rs = "", url = URL_API_ACC_READ + "/Actions/getMenuOfUser";
    var container = $(".list-menu-left");

    $.ajax({
        headers: header, url: url, dataType: "json", data: { FindParentId: 5 }, async: false,
        success: function (data) {
            if (data.isOk) { 
                container.html(null);
                var listMenu = data.result.items;
                listMenu.filter(e => e.parentId === 0).forEach(x => rs += menuItem(x, listMenu));
            } else {
                DevExpress.ui.notify("Xảy ra lỗi trong quá trình lấy danh sách menu", "error", 3000);
                console.log(jqXHR);
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            DevExpress.ui.notify("Xảy ra lỗi trong quá trình lấy danh sách menu", "error", 3000);
            console.log(xhr);
        },
        complete: function () {
            container.html(rs);
            $.each($('.nav').find('li'), function () {
                var aTarget = $(this).find('a');
                $(this).toggleClass("menu-open", window.location.pathname.includes(aTarget.attr('href')));
                if (window.location.pathname == aTarget.attr('href')) {
                    checkPermitInAction(aTarget.data('id'), url);
                    $(this).children(".nav-link").addClass('active', true);
                     
                    var title = aTarget.data('descriptions').toUpperCase()
                    $('.title-page').append(title);
                    document.title = aTarget.data('descriptions') + ' - ' + document.title;
                } else if (window.location.pathname == "/" && aTarget.attr('href') == "/Home") {
                    checkPermitInAction(aTarget.data('id'), url);
                    $(this).children(".nav-link").addClass('active');
                }
            });
            if (!PermitInAction.view) window.location = "/Account/NoAuthentication";
        },
    });
}

var checkPermitInAction = (id, url) => {
    $.ajax({
        headers: header, url: url, dataType: "json", data: { FindId: id }, async: false,
        success: (data) => {
            if (data && data.isOk && data.result && data.result.items.length > 0) {
                var list = data.result.items;
                PermitInAction = {
                    id: id,
                    readonly: list.filter(x => x.permistionId == 1).length > 0,
                    insert: list.filter(x => x.permistionId == 2).length > 0,
                    update: list.filter(x => x.permistionId == 3).length > 0,
                    delete: list.filter(x => x.permistionId == 4).length > 0,
                    view: list.filter(x => x.permistionId == 5).length > 0,
                    assign: list.filter(x => x.permistionId == 7).length > 0,
                    approve: list.filter(x => x.permistionId == 8).length > 0,
                };                
            } else {
                DevExpress.ui.notify("Xảy ra lỗi trong quá trình lấy quyền theo menu", "error", 3000);
                console.log(data);
            }
        },
        error: (xhr, textStatus, errorThrown) => {
            DevExpress.ui.notify("Xảy ra lỗi trong quá trình lấy quyền theo menu", "error", 3000);
            console.log(xhr);
        }, 
    });    
}

let menuItem = (item, list) => {
    var listChild = list.filter(x => x.parentId == item.id);
    var rs = "<li class='nav-item has-treeview'>\
        <a class='nav-link' data-id='"+ item.id + "' data-descriptions='" + item.descriptions + "' href='" + item.url + "'>\
        <i class='nav-icon mr-2 " + item.icon + "'></i>\
        <p>" + item.title + ((listChild != null && listChild.length > 0) ? "<i class='fas fa-caret-left text-muted right'></i>" : "") + "</p>\
        </a>";
    if (listChild != null && listChild.length > 0) {
        rs += "<ul class='nav nav-treeview'>";
        listChild.forEach(x => rs += menuItem(x, list));
        rs += "</ul>";
    }
    rs += "</li>";

    return rs;
}

var loadingPanel = $("#loading-panel").dxLoadPanel({
    shadingColor: "rgba(0,0,0,0.3)",
    visible: false, message: "Vui lòng chờ ...",
    showIndicator: true,
    showPane: true,
    shading: true,
    closeOnOutsideClick: false,
}).dxLoadPanel("instance");

function isNullOrEmpty(value) {
    return value !== undefined && value !== null && value !== "" && value !== "null";
}

function getParamInUrl(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}
var ajax_read = (name, loadOptions) => {
    //loadingPanel.show();  

    var data = {
        'nameEF': (name.indexOf('/') == 0 ? name.split('/')[name.split('/').length - 1] : name),
        'devRequestLoadOptionsViewModel': loadOptions
    };
    var deferred = $.Deferred();
    $.ajax({
        headers: header, url: URL_API_PM_READ_All, dataType: "json", type: "POST",
        data: JSON.stringify(data),
        success: function (result) {
            deferred.resolve(result.data, {
                totalCount: result.totalCount,
                summary: result.summary,
                groupCount: result.groupCount
            });
        },
        error: function (xhr) {
            console.log(xhr.responseJSON ? xhr.responseJSON.Message : xhr.statusText);
            deferred.reject("Đã có lỗi xảy ra trong quá trình này. Mở Console để xem chi tiết hoặc liên hệ Quản trị viên.");
        },
    });
    return deferred.promise();
}
var ajax_insert = (url, values) => {
    //loadingPanel.show();
    var deferred = $.Deferred();
    $.ajax({
        headers: header, url: url, dataType: "json", type: "POST",
        data: JSON.stringify(values),
        success: function (data) {
            //loadingPanel.hide();
            if (data != null && data.isOk && data.result != null)
                deferred.resolve(data.result);
            else
                deferred.reject("Có lỗi xảy ra trong quá trình thêm dữ liệu.");
        },
        error: function (xhr) {
            //loadingPanel.hide();
            console.log(xhr.responseJSON ? xhr.responseJSON.Message : xhr.statusText);
            deferred.reject("Đã có lỗi xảy ra trong quá trình này. Mở Console để xem chi tiết hoặc liên hệ Quản trị viên.");
        },
    });
    return deferred.promise();
}
var ajax_update = (url, key, values) => {
    //loadingPanel.show();
    var keyObj = JSON.parse('{"id":' + key + '}');
    var deferred = $.Deferred();
    $.ajax({
        headers: header, url: url, dataType: "json", type: "PUT",
        data: JSON.stringify($.extend(keyObj, values)),
        success: function (data) {
            //loadingPanel.hide();
            deferred.resolve();
        },
        error: function (xhr) {
            //loadingPanel.hide();
            console.log(xhr.responseJSON ? xhr.responseJSON.Message : xhr.statusText);
            deferred.reject("Đã có lỗi xảy ra trong quá trình này. Mở Console để xem chi tiết hoặc liên hệ Quản trị viên.");
        },
    });
    return deferred.promise();
}
var ajax_delete = (url, key) => {
    //loadingPanel.show();
    var deferred = $.Deferred();
    var keys = typeof (key) == 'number' ? [key] : key;
    $.ajax({
        headers: header, url: url, dataType: "json", type: "DELETE",
        data: JSON.stringify({ "ids": keys }),
        success: function (data) {
            //loadingPanel.hide();
            deferred.resolve();
        },
        error: function (xhr) {
            //loadingPanel.hide();
            console.log(xhr.responseJSON ? xhr.responseJSON.Message : xhr.statusText);
            deferred.reject("Đã có lỗi xảy ra trong quá trình này. Mở Console để xem chi tiết hoặc liên hệ Quản trị viên.");
        },
    });
    return deferred.promise();
}

var ajax_log_insert = (event, table, key, values) => {
    var data = {
        event: event,
        action: PermitInAction.id.toString(),
        ownerById: key,
        ownerByTable: table.replace('/', ''),
        message: values != null ? JSON.stringify(values) : null
    };
    ajax_insert(URL_API_ACC_CMD + "/LogEvent", data);
}

var callLogEvent = (id, table) => {
    var eventList = [
        {
            value : "Insert",
            text : "Tạo mới"
        },
        {
            value : "Update",
            text : "Cập nhật"
        },
        {
            value : "Delete",
            text : "Xóa bỏ"
        }
    ];
    var customStoreEvent = new DevExpress.data.CustomStore({
        key: "id",
        load: (values) => {
            let deferred = $.Deferred(), params = {};
            params = {
                'PageSize': isNullOrEmpty(values.take) ? values.take : 0,
                'PageNumber': (isNullOrEmpty(values.take) && isNullOrEmpty(values.skip)) ? ((values.skip / values.take) + 1) : 0,
                'FindId': "ownerById," + id + ";ownerByTable,'" + table.replace('/', '')+"'",
                'SortCol': 'createDate',
                'SortADSC':'0'
            }; 

            $.ajax({
                headers: header, url: URL_API_ACC_READ + "/LogEvent", dataType: "json", data: params,
                success: function (data) {
                    deferred.resolve(data.result.items);
                },
                error: function (xhr) {
                    console.log(xhr.responseJSON ? xhr.responseJSON.Message : xhr.statusText);
                    deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách. Mở Console để xem chi tiết.");
                }
            });
            return deferred.promise();
        },
    }); 

    $("#popup-log-event").dxPopup({
        width: 900, height: "auto",
        fullScreen: $(window).width() <= 900,
        dragEnabled: true, resizeEnabled: false,
        showTitle: true, title: "Nhật ký cập nhật",
        showCloseButton: true, closeOnOutsideClick: false,
        visible: true,
        position: { my: 'top', at: 'top', of: window },
        contentTemplate: (container) => {
            var scrollView = $("<div id='scrollView'></div>");
            var content = $("<div />");
            content.dxDataGrid({
                dataSource: customStoreEvent,
                showBorders: true, showColumnHeaders: true, showColumnLines: false, rowAlternationEnabled: false,
                showRowLines: true, columnAutoWidth: true, wordWrapEnabled: false, hoverStateEnabled: false,
                columns: [ 
                    {
                        dataField: "createBy_Name", caption: "Người tạo",
                        alignment: "center", width: 200,
                        cellTemplate: (c, o) => {
                            if (o.data.createBy_Name != null) {
                                $("<div />").addClass("d-flex").append(
                                    $("<img />").attr("src", "data:image/png;base64," + o.data.createBy_Avartar).addClass("img-circle elevation-2 img-size-30"),
                                    $("<div />").addClass("ml-2 text-left").append(
                                        $("<div />").addClass("font-weight-bold").append(o.value),
                                        $("<em />").addClass("small").append(o.data.createBy_Title + ' - ' + o.data.createBy_Department)
                                    )
                                ).appendTo(c); 
                            }
                        }
                    },
                    {
                        dataField: "event", caption: "Sự kiện",
                        width: 80, alignment: "center",
                        lookup: {
                            dataSource: eventList,
                            valueExpr: "value", displayExpr: "text",
                        },
                        cssClass:"font-weight-bold"
                    },
                    {
                        dataField: "createDate", dataType: "date", caption: "Thời gian", alignment: "center",
                        cellTemplate: (c, o) => {
                            $("<div />").append(
                                $("<em />").addClass("small").append("Cách đây " + moment(o.value).locale("vi").fromNow()),
                                $("<div/>").addClass("font-weight-bold").append(moment(o.value).format("HH:mm DD/MM/YY"))
                            ).appendTo(c);
                        }
                    },
                    {
                        dataField: "message", caption: "Nội dung cập nhật",
                        cellTemplate: (c, o) => c.append(o.value)
                    },
                ]
            });
            scrollView.append(content);
            scrollView.dxScrollView({ width: '100%', height: '100%' });
            container.append(scrollView);
            return container;
        }
    }).dxPopup('instance');
}