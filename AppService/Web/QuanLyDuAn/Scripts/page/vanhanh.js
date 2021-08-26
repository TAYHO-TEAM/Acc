const ACTION_READ_REQUESTREGISTBYACC = "/RequestRegist/GetByAccountID";
const ACTION_READ_REQUESTREGISTDETAIL = "/RequestRegist/GetDetail";
const ACTION_READ_RESPONSEBYACC = "/ResponseRegist/getByAccount";
const ACTION_READ_RESPONSE = "/ResponseRegist";
const ACTION_READ_FILEGET = "/FilesAttachment/getBy";
const ACTION_READ_PROJECT = "/Projects";
const ACTION_READ_HANGMUC = "/WorkItems";
const ACTION_READ_DOCUMENTTYPE = "/DocumentType";
const ACTION_READ_REPLY = "/ResponseRegistReply";
const ACTION_READ_ACCOUNTINFO = "/AccountInfo";

const ACTION_CMD_REQUESTREGIST = "/RequestRegist";
const ACTION_CMD_RESPONSEREGIST = "/ResponseRegist";
var CUNSTRITEMS = isNullOrEmpty(localStorage.getItem("CItemsCurrent")) ? parseInt(localStorage.getItem("CItemsCurrent")) : 1;
var GROUPOWNERID = isNullOrEmpty(localStorage.getItem("groupOwnerIdCurrent")) ? parseInt(localStorage.getItem("groupOwnerIdCurrent")) : 0;
var ITEMSID = isNullOrEmpty(localStorage.getItem("ItemsIdCurrent")) ? 1 : parseInt(localStorage.getItem("ItemsIdCurrent"));
var HOST = 'https://api-om-crud.tayho.com.vn/api/v1/'; ///'https://api-om-crud.tayho.com.vn/api/v1/''http://localhost:54323/api/v1/http://localhost:8088/api/v1/

var $DATASOURCE = (link, key) => {
    var url = HOST + link;
    return new DevExpress.data.AspNet.createStore({
        key: key ?? "id",
        loadUrl: url,
        insertUrl: url,
        updateUrl: url,
        deleteUrl: url,
        onBeforeSend: (method, options) => {
            //options.xhrFields = { withCredentials: true };
            options.headers = {
                'Authorization': 'Bearer ' + UserCurrentInfo.accessToken,
            };
        },
        reshapeOnPush :true
    });
};
var $DATASOURCEGET = (link, key) => {
    var url = HOST + link;
    return new DevExpress.data.AspNet.createStore({
        key: key ?? "id",
        loadUrl: url,
        insertUrl: url,
        onBeforeSend: (method, options) => {
            options.headers = {
                'Authorization': 'Bearer ' + UserCurrentInfo.accessToken,
            };
        },
        reshapeOnPush : true
    });
};
////---------------------------CMD--------------------------- 
let customStore_CMD_READ = (CMD, READ) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {
        let deferred = $.Deferred(), params = {};

        if (values.filter && values.filter[0] == "parentId") params['FindParentId'] = values.filter[2];
        if (values.sort) {
            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
        }
        $.ajax({
            headers: header,
            url: URL_API_PM_READ + READ,
            dataType: "json",
            data: params,
            success: function (data) {
                let list = data.result.items;
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách. Mở Console để xem chi tiết.");
            },
            timeout: 10000//10 giây
        });

        return deferred.promise();
    },
    insert: (values) => ajax_insert(URL_API_PM_CMD + CMD, values),
    update: (key, values) => ajax_update(URL_API_PM_CMD + CMD, key, values),
    remove: (key) => ajax_delete(URL_API_PM_CMD + CMD, key),
});

let customStore_CMD_READ_WITHPROJECTID = (CMD, READ) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {
        let deferred = $.Deferred(), params = { 'FindId': 'projectId,' + PROJECTID };

        if (values.filter && values.filter[0] == "parentId") params['FindParentId'] = values.filter[2];
        if (values.sort) {
            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
            params['FindId'] = 'projectId,' + PROJECTID;
        }
        $.ajax({
            headers: header,
            url: URL_API_PM_READ + READ,
            dataType: "json",
            data: params,
            success: function (data) {
                let list = data.result.items;
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách. Mở Console để xem chi tiết.");
            },
            timeout: 10000//10 giây
        });

        return deferred.promise();
    },
    insert: (values) => ajax_insert(URL_API_PM_CMD + CMD, values),
    update: (key, values) => ajax_update(URL_API_PM_CMD + CMD, key, values),
    remove: (key) => ajax_delete(URL_API_PM_CMD + CMD, key),
});
let customStore_CMD_READ_WITHGROUPOWNERID = (CMD, READ) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {
        let deferred = $.Deferred(), params = { 'Type': GROUPOWNERID };

        if (values.filter && values.filter[0] == "parentId") params['FindParentId'] = values.filter[2];
        if (values.sort) {
            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
            params['Type'] = GROUPOWNERID;
        }
        $.ajax({
            headers: header,
            url: URL_API_PM_READ + READ,
            dataType: "json",
            data: params,
            success: function (data) {
                let list = data.result.items;
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách. Mở Console để xem chi tiết.");
            },
            timeout: 10000//10 giây
        });

        return deferred.promise();
    },
    insert: (values) => ajax_insert(URL_API_PM_CMD + CMD, values),
    update: (key, values) => ajax_update(URL_API_PM_CMD + CMD, key, values),
    remove: (key) => ajax_delete(URL_API_PM_CMD + CMD, key),
});
var customStore_CMD_READ_PLANPROJECTID = (CMD, READ, ID) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {
        let deferred = $.Deferred(), params = { 'Type': GROUPOWNERID };
        params['FindId'] = 'PlanProjectId,' + ConvertProjectToPlanProject(ID);
        if (values.filter && values.filter[0] == "parentId") params['FindParentId'] = values.filter[2];
        if (values.sort) {
            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
        }
        $.ajax({
            headers: header,
            url: URL_API_PM_READ + READ,
            dataType: "json",
            data: params,
            success: function (data) {
                let list = data.result.items;
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách. Mở Console để xem chi tiết.");
            },
            timeout: 10000//10 giây
        });

        return deferred.promise();
    },
    insert: (values) => ajax_insert(URL_API_PM_CMD + CMD, values),
    update: (key, values) => ajax_update(URL_API_PM_CMD + CMD, key, values),
    remove: (key) => ajax_delete(URL_API_PM_CMD + CMD, key),
});
let customStore_UPDATE_READ = (ID, CMD, READ) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {
        var deferred = $.Deferred();
        var params = {
            'PageSize': isNullOrEmpty(values.take) ? values.take : 0,
            'PageNumber': (isNullOrEmpty(values.take) && isNullOrEmpty(values.skip)) ? ((values.skip / values.take) + 1) : 0,
            'FindId': ID
        }
        if (values.sort) {
            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
        }
        $.ajax({
            headers: header, dataType: "json",
            data: params,
            url: URL_API_PM_READ + READ,
            success: function (data) {
                var list = data.result.items;
                deferred.resolve(
                    list,
                    {
                        totalCount: list.length,
                    }
                );
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
    update: (key, values) => ajax_update(URL_API_PM_CMD + CMD, key, values),
});
let customStore_INSERT_READ = (INSERT, READ) => new DevExpress.data.CustomStore({
    key: "id",

    load: (values) => {
        var deferred = $.Deferred();
        var params = {
            'PageSize': isNullOrEmpty(values.take) ? values.take : 0,
            'PageNumber': (isNullOrEmpty(values.take) && isNullOrEmpty(values.skip)) ? ((values.skip / values.take) + 1) : 0,
            'FindId': ID
        }
        if (values.sort) {
            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
        }
        $.ajax({
            headers: header, dataType: "json",
            data: params,
            url: URL_API_PM_READ + READ,
            success: function (data) {
                var list = data.result.items;
                deferred.resolve(
                    list,
                    {
                        totalCount: list.length,
                    }
                );
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
    insert: (values) => ajax_insert(URL_API_PM_CMD + INSERT, values),
});
let customStore_CMD_READ_FILTER_FK = (CMD, READ, FKID) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {
        let deferred = $.Deferred(), params = {};

        //if (values.filter && values.filter[0] == "parentId") params['FindParentId'] = values.filter[2];
        params['FindParentId'] = FKID;
        if (values.sort) {
            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
        }
        $.ajax({
            headers: header,
            url: URL_API_PM_READ + READ,
            dataType: "json",
            data: params,
            success: function (data) {
                let list = data.result.items;
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách. Mở Console để xem chi tiết.");
            },
            timeout: 10000//10 giây
        });

        return deferred.promise();
    },
    insert: (values) => ajax_insert(URL_API_PM_CMD + CMD, values),
    update: (key, values) => ajax_update(URL_API_PM_CMD + CMD, key, values),
    remove: (key) => ajax_delete(URL_API_PM_CMD + CMD, key),
});
let customStore_CMD_READ_FILTER_ID = (CMD, READ, ID) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {

        var deferred = $.Deferred();
        var params = {
            'PageSize': isNullOrEmpty(values.take) ? values.take : 0,
            'PageNumber': (isNullOrEmpty(values.take) && isNullOrEmpty(values.skip)) ? ((values.skip / values.take) + 1) : 0,
            'FindId': ID
        }
        if (values.sort) {
            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
        }
        $.ajax({
            headers: header, dataType: "json",
            data: params,
            url: URL_API_PM_READ + READ,
            success: function (data) {
                var list = data.result.items;
                deferred.resolve(
                    list,
                    {
                        totalCount: list.length,
                    }
                );
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
    insert: (values) => ajax_insert(URL_API_PM_CMD + CMD, values),
    update: (key, values) => ajax_update(URL_API_PM_CMD + CMD, key, values),
    remove: (key) => ajax_delete(URL_API_PM_CMD + CMD, key),
});
let customStore_CMD_READ_FILTER_ID_KEYWORD = (CMD, READ, ID, KEYWORD) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {

        var deferred = $.Deferred();
        var params = {
            'PageSize': isNullOrEmpty(values.take) ? values.take : 0,
            'PageNumber': (isNullOrEmpty(values.take) && isNullOrEmpty(values.skip)) ? ((values.skip / values.take) + 1) : 0,
            'FindId': ID,
            'KeyWord': KEYWORD
        }
        if (values.sort) {
            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
        }
        $.ajax({
            headers: header, dataType: "json",
            data: params,
            url: URL_API_PM_READ + READ,
            success: function (data) {
                var list = data.result.items;
                deferred.resolve(
                    list,
                    {
                        totalCount: list.length,
                    }
                );
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
    insert: (values) => ajax_insert(URL_API_PM_CMD + CMD, values),
    update: (key, values) => ajax_update(URL_API_PM_CMD + CMD, key, values),
    remove: (key) => ajax_delete(URL_API_PM_CMD + CMD, key),
});
let customStore_DELETE_READDATASOURCE = (CMD, DATASOURCE) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {
        let deferred = $.Deferred(), params = {};

        deferred.resolve(DATASOURCE);

        return deferred.promise();
    },
    remove: (key) => ajax_delete(URL_API_PM_CMD + CMD, key),
});
let customStore_CMD_READ_WITHPROJECTID_PAGGING = (CMD, READ) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {
        let deferred = $.Deferred(), params = { 'FindId': 'projectId,' + PROJECTID };
        params = {
            'PageSize': isNullOrEmpty(values.take) ? values.take : 0,
            'PageNumber': (isNullOrEmpty(values.take) && isNullOrEmpty(values.skip)) ? ((values.skip / values.take) + 1) : 0,
        }
        if (values.filter && values.filter[0] == "parentId") params['FindParentId'] = values.filter[2];
        if (values.sort) {

            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
            params['FindId'] = 'projectId,' + PROJECTID;
        }
        $.ajax({
            headers: header,
            url: URL_API_PM_READ + READ,
            dataType: "json",
            data: params,
            success: function (data) {
                let list = data.result.items;
                deferred.resolve(list, {
                    totalCount: data.result.pagingInfo.totalItems,
                });
            },
            error: function (xhr, textStatus, errorThrown) {
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách. Mở Console để xem chi tiết.");
            },
            timeout: 10000//10 giây
        });

        return deferred.promise();
    },
    insert: (values) => ajax_insert(URL_API_PM_CMD + CMD, values),
    update: (key, values) => ajax_update(URL_API_PM_CMD + CMD, key, values),
    remove: (key) => ajax_delete(URL_API_PM_CMD + CMD, key),
});
////---------------------------READ--------------------------- 
let customStore_AccountInfo = (type) => new DevExpress.data.DataSource({
    store: new DevExpress.data.CustomStore({
        key: "id",
        loadMode: "raw",
        load: (values) => ajax_read(ACTION_READ_ACCOUNTINFO, values),
    }),
    //filter: [["type", "=", type]]
});
let customStore_READ_ALL_ACC = (READ) => new DevExpress.data.CustomStore({
    key: "id",
    loadMode: "raw",
    load: (values) => {
        var deferred = $.Deferred();
        $.ajax({
            headers: header, dataType: "json",
            url: URL_API_ACC_READ + READ,
            success: function (data) {
                var list = data.result.items.filter(x => x.isActive == true && x.isVisible == true);
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
});
let customStore_READ_ALL = (READ) => new DevExpress.data.CustomStore({
    key: "id", loadMode: "raw",
    load: (values) => {
        var deferred = $.Deferred();
        $.ajax({
            headers: header, dataType: "json",
            url: URL_API_PM_READ + READ,
            success: function (data) {
                var list = data.result.items.filter(x => x.isActive == true && x.isVisible == true);
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
});
let customStore_READ_FILTER = (READ, FILTER) => new DevExpress.data.CustomStore({
    key: "id", loadMode: "raw",
    load: (values) => {
        let deferred = $.Deferred(), params = { 'FindId': FILTER };
        $.ajax({
            headers: header, dataType: "json",
            url: URL_API_PM_READ + READ,
            data: params,
            success: function (data) {
                var list = data.result.items.filter(x => x.isActive == true && x.isVisible == true);
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
});
let customStore_READ_ID = (READ, ID) => new DevExpress.data.CustomStore({
    key: "id",
    loadMode: "raw",
    load: (values) => {
        var deferred = $.Deferred();
        var params = {
            'PageSize': isNullOrEmpty(values.take) ? values.take : 0,
            'PageNumber': (isNullOrEmpty(values.take) && isNullOrEmpty(values.skip)) ? ((values.skip / values.take) + 1) : 0,
            'FindId': ID,
        }
        $.ajax({
            headers: header, dataType: "json",
            data: params,
            url: URL_API_PM_READ + READ,
            success: function (data) {
                var list = data.result.items.filter(x => x.isActive == true && x.isVisible == true);
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
});
let customStore_GET_LINK = (LINK) => new DevExpress.data.CustomStore({
    key: 'id',
    loadMode: "raw",
    load: () => {
        var deferred = $.Deferred();
        $.ajax({
            headers: header,
            dataType: "json",
            url: LINK,
            success: function (data) {
                var list = data.result.items;
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
});
let customStore_READDATASOURCE = (DATASOURCE) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {
        let deferred = $.Deferred(), params = {};

        deferred.resolve(DATASOURCE);

        return deferred.promise();
    },
});
let customStore_READ_FILTER_KEYWORD = (READ, KEYWORD) => new DevExpress.data.CustomStore({
    key: "id", loadMode: "raw",
    load: (values) => {
        var deferred = $.Deferred();
        var params = {
            'PageSize': isNullOrEmpty(values.take) ? values.take : 0,
            'PageNumber': (isNullOrEmpty(values.take) && isNullOrEmpty(values.skip)) ? ((values.skip / values.take) + 1) : 0,
            'KeyWord': KEYWORD
        }
        $.ajax({
            headers: header,
            dataType: "json",
            data: params,
            url: URL_API_PM_READ + READ,
            success: function (data) {
                var list = data.result.items.filter(x => x.isActive == true && x.isVisible == true);
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
});

var dataGridOptions = {
    height: heightScreen,
    paging: {
        enabled: true, pageSize: 20
    },
    pager: {
        showPageSizeSelector: true, showInfo: true,
        allowedPageSizes: [10, 20, 40, 80],
    },
    searchPanel: {
        highlightCaseSensitive: true,
        highlightSearchText: true,
        searchVisibleColumnsOnly: true,
        visible: true
    },
    showBorders: false,
    showColumnHeaders: true,
    showColumnLines: false,
    hoverStateEnabled: true,
    showRowLines: true,
    columnAutoWidth: true,
    wordWrapEnabled: true,
    rowAlternationEnabled: true,
};
function CALLPOPUP(title, url, width, container) {
    var isFullscreen = false;
    if (width == "100%") isFullscreen = true;
    $("#popup-main").dxPopup({
        width: width,
        height: "90vh",
        fullScreen: isFullscreen,
        position: { my: 'center', at: 'center', of: window },
        dragEnabled: true,
        resizeEnabled: true,
        visible: true,
        showTitle: true,
        closeOnOutsideClick: false,
        showCloseButton: true,
        title: title,
        contentTemplate: function (container) {
            var scrollView = $("<div id='scrollView'></div>");
            var content = $("<div/>");
            content.load(url);
            scrollView.append(content);
            scrollView.dxScrollView({
                width: '100%',
                height: '100%'
            });
            container.append(scrollView);
            return container;
        },
        onHiding: function () {
            container.refresh();
        },
        onHidden: function () {
            //loadData(ITEMSID);
        }
    });
}
function CALLPOPUPMULTI(title, url, width, container, popupId) {
    var isFullscreen = false;
    if (width == "100%") isFullscreen = true;
    $("#" + popupId).dxPopup({
        width: width,
        height: "auto",
        fullScreen: isFullscreen,
        position: { my: 'top', at: 'top', of: window },
        dragEnabled: true,
        resizeEnabled: true,
        visible: true,
        showTitle: true,
        closeOnOutsideClick: false,
        showCloseButton: true,
        title: title,
        contentTemplate: function (container) {
            var scrollView = $("<div id='scrollView'></div>");
            var content = $("<div/>");
            content.load(url);
            scrollView.append(content);
            scrollView.dxScrollView({
                width: '100%',
                height: '100%'
            });
            container.append(scrollView);
            return container;
        },
        onHiding: function () {
            try {
                container.refresh();
            }
            catch (exception_var) {
                container.reload();
            }
            finally {
            }
        },
        onHidden: function () {
        }
    });
}
function ConvertProjectToPlanProject(PLANPROJECT) {

    switch (PLANPROJECT) {
        case 1:
            return '1';
            break;
        case 2:
            return '2';
            break;
        case 3:
            return '3';
            break;
        default:
            return '1';
    }
}

function downloadFromAjaxPost(url, params, callback) {
    var $header = {
        'Accept': '*/*',
        //'X-Requested-With': 'XMLHttpRequest',
        //'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content'),
        //'Access-Control-Expose-Headers': 'x-dl-units-left',
        'Access-Control-Expose-Headers': '*',
        'Access-Control-Allow-Origin': '*',
        //'Access-Control-Request-Headers': '*',
        //'Content-Disposition':'*',
        //'Content-Type': '*/*',
        'Authorization': 'Bearer ' + UserCurrentInfo.accessToken,
    };
    var xhr = new XMLHttpRequest();
    xhr.open('PUT', url, true);
    xhr.responseType = 'blob';
    xhr.onload = function () {
        loadingPanel.hide();
        if (this.status === 200) {
            //var contentDisposition = xhr.get('content-disposition');
            //console.log(contentDisposition);
            var filename = "";
            var disposition = xhr.getResponseHeader('content-disposition');
            //attachment=>inline  
            if (disposition && disposition.indexOf('attachment') !== -1) {
                var filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
                var matches = filenameRegex.exec(disposition);
                if (matches != null && matches[1]) filename = matches[1].replace(/['"]/g, '');
            }
            var type = xhr.getResponseHeader('Content-Type');

            var blob = new Blob([this.response], { type: type });
            if (typeof window.navigator.msSaveBlob !== 'undefined') {
                // IE workaround for "HTML7007: One or more blob URLs were revoked by closing the blob for which they were created. These URLs will no longer resolve as the data backing the URL has been freed."
                window.navigator.msSaveBlob(blob, filename);
            } else {
                var URL = window.URL || window.webkitURL;
                var downloadUrl = URL.createObjectURL(blob);

                if (filename) {
                    // use HTML5 a[download] attribute to specify filename
                    var a = document.createElement("a");
                    // safari doesn't support this yet
                    if (typeof a.download === 'undefined') {
                        window.location = downloadUrl;
                    } else {
                        a.href = downloadUrl;
                        a.download = filename;
                        document.body.appendChild(a);
                        a.click();
                    }
                } else {
                    window.location = downloadUrl;
                }

                setTimeout(function () { URL.revokeObjectURL(downloadUrl); }, 100); // cleanup
            }
            DevExpress.ui.notify("Tải dữ liệu thành công", "success", 3000);
        }
        else {
            DevExpress.ui.notify("Lỗi sai biến truyền vào", "error", 3000);
        }
        if (callback) {
            callback();
        }
    };
    //xhr.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
    $.each($header, function (key, value) {
        xhr.setRequestHeader(key, value);
    });

    xhr.send(params);
    //xhr.send($.param(params));
}

//--------------------------Unity Function ------------------
function getTemplateMarkup(data, containerClass) {
    console.log(data);
    return "<div class='" + containerClass + "'><img src='" +
        data.Picture + "' /><div>" +
        (data.firstName ?? "") + " " + (data.lastName ?? "")+ "</div></div>";
}
function getDisplayExpr(item) {
    if (!item) {
        return "";
    }
    return (item.firstName ?? "") + " " + (item.lastName ?? "") ;
}
//-----------------------Unity OBJ -----------------------
const Category = [{
    "CategoryName": "Email",
},
{
    "CategoryName": "Notify",
},
{
    "CategoryName": "SMS",
}];

const unit = [
    {
        ID: '%',
        Name: '%'
    },
    {
        ID: 'Người',
        Name: 'Người'
    },
    {
        ID: 'Kg',
        Name: 'Kg'
    },
    {
        ID: 'Ngày',
        Name: 'Ngày'
    },
    {
        ID: 'm2',
        Name: 'm2'
    },
    {
        ID: 'Khác',
        Name: 'Khác'
    }
];
const important = [
    {
        ID: 0,
        Name: 'Trung bình'
    },
    {
        ID: 1,
        Name: 'Quan trọng'
    },
    {
        ID: 2,
        Name: 'Cấp bách'
    }
];
const groupOwner = [
    {
        ID: 0,
        Name: 'Tất cả'
    },
    {
        ID: 9,
        Name: 'Của tôi'
    },
    {
        ID: 7,
        Name: 'Được phân công'
    },
    //{
    //    ID: '3',
    //    Name: 'Phân công giám sát'
    //},
];
const permisionAassign = [
    //{
    //    ID: '0',
    //    Name: 'Tất cả'
    //},
    {
        ID: 9,
        Name: 'Của tôi'
    },
    {
        ID: 7,
        Name: 'Phân công thực hiện'
    },
    //{
    //    ID: '3',
    //    Name: 'Phân công giám sát'
    //},
];
const planProject = [
    //{
    //    ID: '0',
    //    Name: 'Tất cả'
    //},
    {
        ID: 1,
        Name: 'Compase One'
    },
    {
        ID: 2,
        Name: 'Long Thành'
    },
    //{
    //    ID: '3',
    //    Name: 'Phân công giám sát'
    //},
];
const reportPeriodicalType = [
    //{
    //    ID: '1',
    //    Name: 'Hàng giờ'
    //},
    {
        ID: 1,
        Name: 'Hàng ngày'
    },
    {
        ID: 7,
        Name: 'Hàng tuần'
    },
    {
        ID: 30,
        Name: 'Hàng tháng'
    },
    //{
    //    ID: 5,
    //    Name: 'Hàng năm'
    //},
    //{
    //    ID: '3',
    //    Name: 'Phân công giám sát'
    //},
];
const parameterType = [
    {
        ID: 'dxTextBox',
        Name: 'TextBox',
        Type: 'string'
    },
    {
        ID: 'dxDateBox',
        Name: 'Ngày tháng',
        Type: 'datetime'
    },
    {
        ID: 'dxCheckBox',
        Name: 'CheckBox',
        Type: 'string'
    },
    {
        ID: 'dxSelectBox',
        Name: 'SelectBox',
        Type: 'bool'
    },
    //{
    //    ID: 'dxFileUploader',
    //    Name: 'UpImages',
    //    Type: 'img'
    //},
    {
        ID: 'dxFileUploader',
        Name: 'UpFile',
        Type: 'file'
    },
    {
        ID: 'dxRadioGroup',
        Name: 'RadioGroup',
        Type: 'string'
    },
    //{
    //    ID: '3',
    //    Name: 'Phân công giám sát'
    //},
];
const Type = [
    {
        ID: 'string',
        Name: 'Chữ',
    },
    {
        ID: 'datetime',
        Name: 'Ngày tháng',
    },
    {
        ID: 'number',
        Name: 'Số',
    },
];
const Approve = [
    {
        ID: 10,
        Name: 'Chưa duyệt',
    },
    {
        ID: 1,
        Name: 'Duyệt',
    },
    {
        ID: 2,
        Name: 'Từ chối duyệt',
    },

];
const SetPermit = [
    {
        ID: 1,
        Name: 'Quyền xem',
    },
    {
        ID: 6,
        Name: 'Quyền quản trị',
    },
    {
        ID: 7,
        Name: 'Quyền phân công',
    },
    {
        ID: 8,
        Name: 'Quyền thực hiện',
    },
    {
        ID: 9,
        Name: 'Quyền sở hữu',
    },
];
const Sex = [
    {
        ID: 0,
        Name: 'Nam',
    },
    {
        ID: 2,
        Name: 'Nữ',
    },
    {
        ID: 3,
        Name: 'Khác',
    },
];
var listActiveStatus = [
    { value: true, text: "Hoạt động", color: "success", icon: 'fa fa-check-circle' },
    { value: false, text: "Tạm dừng", color: "danger", icon: 'fa fa-minus-circle' },
];
var listRemind = [
    { value: true, text: "Nhắc", color: "success", icon: 'fa fa-check-circle' },
    { value: false, text: "Không nhắc", color: "danger", icon: 'fa fa-minus-circle' },
];

var listIsInOrOutStatus = [
    { value: true, text: "Nhập kho", color: "success", icon: 'fa fa-check-circle' },
    { value: false, text: "Xuất kho", color: "danger", icon: 'fa fa-minus-circle' },
];
var listIsInOrOutHORStatus = [
    { value: true, text: "Tiếp nhận", color: "success", icon: 'fa fa-check-circle' },
    { value: false, text: "Bàn giao", color: "danger", icon: 'fa fa-minus-circle' },
];
var listIsInOrOutVerify = [
    { value: 10, text: "Đang lên đơn", color: "warning", icon: 'fa fa-check-circle' },
    { value: 100, text: "Đang cập nhật", color: "primary", icon: 'fa fa-minus-circle' },
    { value: 200, text: "Đã nghi nhận", color: "info", icon: 'fa fa-minus-circle' },
    { value: 220, text: "Đã xác nhận", color: "success", icon: 'fa fa-minus-circle' },
];
var complaintStatus = [
    { value: 1, text: "Chờ giải quyết", color: "warning", icon: 'fa fa-minus-circle' },
    { value: 101, text: "Chờ hỗ trợ", color: "info", icon: 'fa fa-pause-circle' },
    { value: 200, text: "Đã giải quyết", color: "success", icon: 'fa fa-check-circle' },
];
var maintenanceLogStatus = [
    { value: 1, text: "Vừa Tạo", color: "primary", icon: 'fa fa-plus-circle' },
    { value: 9, text: "Quá Hạn ", color: "danger", icon: 'fa fa-minus-circle' },
    { value: 10, text: "Chờ BT", color: "warning", icon: 'fa fa-pause-circle' },
    { value: 11, text: "Đang BT", color: "info", icon: 'fa fa-play-circle' },
    { value: 200, text: "Đã NT ", color: "success", icon: 'fa fa-check-circle' },
];

var remidBy = [
    {
        ID: "Call",
        Name: "Call",
    },
    {
        ID: "Notify",
        Name: "Notify",
    },
    {
        ID: "Email",
        Name: "Email",
    },

];
const statusDefect = [
    {
        ID: 0,
        Name: 'Chờ'
    },
    {
        ID: 10,
        Name: 'Chờ xác nhận'
    },
    {
        ID: 11,
        Name: 'Đã xác nhận'
    },
    {
        ID: 20,
        Name: 'Chờ khắc phục'
    },
    {
        ID: 21,
        Name: 'Đang khắc phục'
    },
    {
        ID: 22,
        Name: 'Đã khắc phục'
    },
    {
        ID: 30,
        Name: 'Chờ nghiệm thu'
    },
    {
        ID: 31,
        Name: 'Đang nghiệm thu'
    },
    {
        ID: 101,
        Name: 'Từ chỗi nghiệm thu'
    },
    {
        ID: 200,
        Name: 'Đã nghiệm thu'
    },
];