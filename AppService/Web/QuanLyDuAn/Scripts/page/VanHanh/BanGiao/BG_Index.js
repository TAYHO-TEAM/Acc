
var id = 1;
var $WHId = 0;
var $issetHOR = false;
var $keyHOR = 0;
var $isUpdateHOR = true;
var $isInsertHOR = true;
var $isDeleteHOR = true;
var $proviceId = 13;
var $districtId = 76;
var $wardId = 783;
var $hieghtSub = 300;
var $isFinish = true;
var fData = {
    "title": ""
    , "description": ""
    , "note": ""
    , "warehouseStorageId": 0
    , "sendAddress": ""
    , "sendStreet": ""
    , "sendDistrict": ""
    , "sendWard": ""
    , "sendCity": ""
    , "sendCountry": ""
    , "receiveAddress": ""
    , "receiveStreet": ""
    , "receiveDistrict": ""
    , "receiveWard": ""
    , "receiveCity": ""
    , "receiveCountry": ""
    , "isInOrOut": true
    , "priority": 0
    , "noAttachment": 0
    , "type": 0
};
//----------------------------- READ -------------------------------------------------------------

var ACTION_HANDOVERRECEIPT = "HandOverReceipt";
var ACTION_HANDOVERRECEIPTDETAIL = "HandOverReceiptDetail";
var ACTION_HANDOVERITEM = "HandOverItem";
var ACTION_HANDOVERITEMSPECIFICATIONS = "HandOverItemSpecifications";
var ACTION_HANDOVERDELEGATE = "HandOverDelegate";
var ACTION_LISTOFLOCATION = "ListOfLocation";
var ACTION_CATEGORYUNIT = "CategoryUnit";
var ACTION_FILESATTACHMENT = "FilesAttachment";
var KEY = "id";
var WIDTH_CONTAINER = $("#container").width();

//----------------------------------- Get data ----------------------------------------------------
var customStore = () => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_HANDOVERRECEIPT, KEY),
});
var customStore_Receiver = () => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_HANDOVERRECEIPT, KEY),
    filter: [["isInOrOut", "=", 1]],
});
var customStore_Filter = (InOrOut) => new DevExpress.data.DataSource({
    store: $DATASOURCEGET(ACTION_HANDOVERRECEIPT, KEY),
    filter: [["isInOrOut", "=", 1], "and", ["status", "<", 200], "and", ["createBy", "=", UserCurrentInfo.accountId]],
});
var customStore_ById = (Id) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_HANDOVERRECEIPT, KEY),
    filter: [["id", "=", Id]]
});
var customStore_HandOverDelegate = (Id, IsSend) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_HANDOVERDELEGATE, KEY),
    filter: [["handOverReceiptId", "=", Id], "and", ["isSenderOrReceiver", "=", IsSend]]
});
var customStore_HandOverReceiptDetail = (Id) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_HANDOVERRECEIPTDETAIL, KEY),
    filter: [["handOverReceiptId", "=", Id]]
});
var customStore_HandOverItem = (Id) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_HANDOVERITEM, KEY),
    filter: [["id", "=", Id]]
});
var customStore_HandOverItem_All = () => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_HANDOVERITEM, KEY)
});
var customStore_HandOverItemSpecifications = (Id) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_HANDOVERITEMSPECIFICATIONS, KEY),
    filter: [["handOverItemId", "=", Id]]
});
var customStore_ListOfLocation_ProvinceAll = () => new DevExpress.data.DataSource({
    store: $DATASOURCEGET(ACTION_LISTOFLOCATION, KEY),
    filter: [["type", "=", "Province"]]
});
var customStore_ListOfLocation_ByParentId = (Id) => new DevExpress.data.DataSource({
    store: $DATASOURCEGET(ACTION_LISTOFLOCATION, KEY),
    filter: [["parentId", "=", Id]]
});
var customStore_CategoryUnit = $DATASOURCEGET(ACTION_CATEGORYUNIT, KEY);
var customStore_Attachment = (Id, owner) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_FILESATTACHMENT, KEY),
    filter: [["ownerById", "=", Id], "and", ["ownerByTable", "=", owner]]
});
var customStore_Attachment_All = (Owner) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_FILESATTACHMENT, KEY),
    filter: ["ownerByTable", "=", Owner]
});
//----------------------------------- Function ------------------------------------------------------
$(document).ready(function () {
    $(function () {
        loadData();
    });

    var loadData = () => {
        $("#container").dxDataGrid({
            dataSource: customStore(),
            remoteOperations: true,
            height: heightScreen,
            repaintChangesOnly: true,
            remoteOperations: true,
            scrolling: { mode: "standard" },
            showBorders: false,
            showColumnHeaders: true,
            showColumnLines: false,
            hoverStateEnabled: true,
            showRowLines: true,
            columnAutoWidth: true,
            wordWrapEnabled: true,
            rowAlternationEnabled: true,
            filterRow: { visible: true },
            onToolbarPreparing: function (e) {
                var container = e.component;
                e.toolbarOptions.items.unshift(
                    {
                        location: "after",
                        widget: "dxButton",
                        options: {
                            icon: "refresh",
                            type: "default",
                            onClick: () => container.refresh()
                        }
                    })
            },
            onInitNewRow: (e) => {
                e.data.isActive = true;
                e.data.isVisible = true;
                e.data.realEstateId = id;
            },
            onContentReady: (e) => {
                var container = e.component;
                var container = e.component;
                $("#action-add").dxSpeedDialAction({
                    index: 1, icon: "fas fa-file-import",
                    label: "Tiếp nhận",
                    visible: PermitInAction["insert"],
                    onClick: () => {
                        createHOR(true);
                    }
                }).dxSpeedDialAction("instance");
                $("#action-update").dxSpeedDialAction({
                    index: 2, icon: "fas fa-file-export",
                    label: "Bàn giao",
                    visible: PermitInAction["update"],
                    onClick: () => {
                        createHOR(false);
                    }
                }).dxSpeedDialAction("instance");
                DevExpress.config({
                    floatingActionButtonConfig: {
                        icon: "rowfield",
                        label: "Tác vụ",
                        shading: true,
                        position: {
                            of: e.element,
                            my: "right bottom",
                            at: "right bottom",
                            offset: e.component.pageCount() > 1 ? "-15 -60" : "-15 -15"
                        }
                    }
                });
                DevExpress.ui.repaintFloatingActionButton();
            },
            onSelectionChanged: (e) => {
                var $id = e.selectedRowKeys[0];
                var selectedRowData = e.selectedRowsData[0];
                var selectedRowKey = e.selectedRowKeys[0];
                $keyHOR = selectedRowKey;
                console.log($keyHOR);
                if (selectedRowData != null && selectedRowKey != null) {
                    var data = e.component.getRowIndexByKey(selectedRowData.paId);

                    $("#action-delete").dxSpeedDialAction({
                        index: 3,
                        icon: "fas fa-trash",
                        label: "Xóa",
                        visible: (selectedRowData.id != null && PermitInAction["delete"] && selectedRowData.status < 200),
                        onClick: () => {
                            var deferred = $.Deferred();
                            customStore().store().remove(selectedRowKey).then(() => {
                                DevExpress.ui.notify("Xoá thành công", "success", 3000);
                                e.component.refresh();
                            }, deferred.reject);
                            return deferred.promise();
                        }
                    }).dxSpeedDialAction("instance");
                    //$("#action-log").dxSpeedDialAction({
                    //    index: 4,
                    //    icon: "fas fa-shipping-fast",
                    //    label: "Nhật ký xuất nhập",
                    //    visible: PermitInAction["view"],
                    //    onClick: () => {
                    //        var containerE = e.component;
                    //        CALLPOPUP(
                    //            "Lịch sử xuất nhập",
                    //            "/VanHanh/KhoBai/_NhatKyKho?id=" + selectedRowKey,
                    //            ($(window).width() > 767 ? "70%" : "90%"),
                    //            containerE
                    //        );
                    //    }
                    //}).dxSpeedDialAction("instance");
                }
                loadData_Form(selectedRowKey);
            },
            selection: {
                mode: "single"
            },
            columns: [
                {
                    dataField: "code",
                    allowFiltering: true,
                    caption: "Mã",
                    width: "100",
                    dataType: "string",
                    alignment: "center",
                    readOnly: !$isUpdateHOR,
                    allowEditing: false,
                },// code
                {
                    dataField: "title",
                    dataType: "string",
                    alignment: "left",
                    caption: "Tiêu đề",
                },
                {
                    dataField: "isInOrOut",
                    allowFiltering: true,
                    caption: "Tiếp nhận/Bàn giao",
                    dataType: "string",
                    width: "100",
                    alignment: "center",
                    lookup: {
                        dataSource: listIsInOrOutHORStatus,
                        valueExpr: "value", displayExpr: "text",
                    },
                    cellTemplate: (c, o) => {
                        $("<span />").addClass("badge badge-" + listIsInOrOutHORStatus.find(x => x.value == o.value).color).append(
                            $("<i />").addClass("mr-1 " + listIsInOrOutHORStatus.find(x => x.value == o.value).icon), o.text
                        ).appendTo(c);
                    }
                },
                {
                    dataField: "status",
                    dataType: "string",
                    alignment: "center",
                    caption: "Trạng thái",
                    width: "100",
                    lookup: {
                        dataSource: listIsInOrOutVerify,
                        valueExpr: "value", displayExpr: "text",
                    },
                    cellTemplate: (c, o) => {
                        $("<span />").addClass("badge badge-" + listIsInOrOutVerify.find(x => x.value == o.value).color).append(
                            $("<i />").addClass("mr-1 " + listIsInOrOutVerify.find(x => x.value == o.value).icon), o.text
                        ).appendTo(c);
                    }
                },
            ],
            editing: {
                allowAdding: false,
                allowUpdating: false,
                allowDeleting: false,
                mode: "popup",
                useIcons: true,
                confirmDelete: true,
            },
        }).dxDataGrid('instance');
        var elmnt = document.getElementById("container");
        document.getElementById("form-container").style.height = elmnt.offsetHeight + 'px';
    };
    var loadData_Form = (Id) => {
        var elmnt = document.getElementById("container");
        var $heightContaint = elmnt.offsetHeight - 80;
        customStore_ById(Id).store().load().done((rs) => {
            var rsFilterId = rs.filter(x => x.id === Id);
            $issetHOR = (rsFilterId.length > 0);
            if ($issetHOR) {
                $keyHOR = rsFilterId[0].id;
                if (rsFilterId[0].status < 200) {
                    $isFinish = false;
                    $isUpdateHOR = true;
                    $isInsertHOR = true;
                    $isDeleteHOR = true;
                }
                else {
                    $isFinish = true;
                    $isUpdateHOR = false;
                    $isInsertHOR = false;
                    $isDeleteHOR = false;
                }

            }
            $("#form-HandOverReceiptFull").dxForm({
                formData: rsFilterId[0],
                colCount: 12,
                labelLocation: "top",
                "scrolling": {
                    "columnRenderingMode": "standard",
                    "mode": "standard",
                    "rowRenderingMode": "virtual",
                    "useNative": true
                },
                height: $heightContaint,
                items: [
                    {
                        itemType: "group",
                        colSpan: 12,
                        colCount: 12,
                        cssClass: "addressA-group",
                        caption: "Tiếu đề",
                        items: [
                            {
                                colSpan: 12,
                                dataField: "title",
                                label: { text: "Nội dung tiêu đề" },
                                editorType: "dxTextBox",
                                editorOptions: {
                                    stylingMode: "filled",
                                    //allowEditing: false,
                                    readOnly: !$isUpdateHOR,
                                    elementAttr: {
                                        id: "elementTitleId",
                                    },
                                },
                            },
                        ]
                    },
                    {
                        itemType: "group",
                        colSpan: 12,
                        colCount: 12,
                        cssClass: "delegateA-group",
                        caption: "Đại diện bên Giao",
                        items: [
                            {
                                name: "order",
                                visible: true,
                                colSpan: 12,
                                template: function (data, $itemElement) {
                                    $("<div id='delegateA'>")
                                        .appendTo($itemElement)
                                        .dxDataGrid({
                                            dataSource: customStore_HandOverDelegate($keyHOR, true),
                                            remoteOperations: true,
                                            height: $hieghtSub,
                                            repaintChangesOnly: true,
                                            remoteOperations: true,
                                            scrolling: { mode: "standard" },
                                            showBorders: false,
                                            showColumnHeaders: true,
                                            showColumnLines: false,
                                            hoverStateEnabled: true,
                                            showRowLines: true,
                                            columnAutoWidth: true,
                                            wordWrapEnabled: true,
                                            rowAlternationEnabled: true,
                                            filterRow: { visible: true },
                                            onToolbarPreparing: function (e) {
                                                var container = e.component;
                                                e.toolbarOptions.items.unshift(
                                                    {
                                                        location: "after",
                                                        widget: "dxButton",
                                                        options: {
                                                            icon: "refresh",
                                                            type: "default",
                                                            onClick: () => container.refresh()
                                                        }
                                                    })
                                            },
                                            onInitNewRow: (e) => {
                                                e.data.isActive = true;
                                                e.data.isVisible = true;
                                                e.data.HandOverReceiptId = Id;
                                                e.data.isSenderOrReceiver = true;
                                            },
                                            onContentReady: (e) => {
                                                var container = e.component;
                                            },
                                            onSelectionChanged: (e) => {
                                                var $id = e.selectedRowKeys[0];
                                                var selectedRowData = e.selectedRowsData[0];
                                                var selectedRowKey = e.selectedRowKeys[0];
                                            },
                                            selection: {
                                                mode: "single"
                                            },
                                            columns: [
                                                {
                                                    dataField: "fullName",
                                                    dataType: "string",
                                                    caption: "Họ tên",
                                                    alignment: "center",
                                                    readOnly: false,
                                                    allowEditing: true,
                                                },
                                                {
                                                    dataField: "phoneContact",
                                                    dataType: "string",
                                                    caption: "Số Điện Thoại",
                                                    alignment: "center",
                                                    readOnly: false,
                                                    allowEditing: true,
                                                },
                                                {
                                                    dataField: "description",
                                                    dataType: "string",
                                                    caption: "Chức vụ",
                                                    alignment: "center",
                                                    readOnly: false,
                                                    allowEditing: true,
                                                },

                                            ],
                                            editing: {
                                                allowAdding: $isInsertHOR,
                                                allowUpdating: $isUpdateHOR,
                                                allowDeleting: $isDeleteHOR,
                                                mode: "batch",
                                                useIcons: true,
                                                confirmDelete: true,
                                            },
                                        });
                                }
                            }
                        ]
                    },
                    {
                        itemType: "group",
                        colSpan: 12,
                        colCount: 12,
                        cssClass: "addressA-group",
                        caption: "Thông tin bên giao",
                        items: [
                            {
                                colSpan: 12,
                                dataField: "sendAddress",
                                label: { text: "Địa chỉ" },
                                editorType: "dxTextBox",
                                editorOptions: {
                                    stylingMode: "filled",
                                    //allowEditing: false,
                                    readOnly: !$isUpdateHOR,
                                    elementAttr: {
                                        id: "elementSendAddressId",
                                    },
                                },
                            },
                            {
                                colSpan: 4,
                                dataField: "sendCityId",
                                label: { text: "Tỉnh/Thành" },
                                editorType: "dxSelectBox",
                                editorOptions: {
                                    searchEnabled: true,
                                    searchMode: "contains",
                                    searchExpr: ['title'],
                                    showClearButton: true,
                                    placeholder: "Vui lòng chọn...",
                                    dataSource: customStore_ListOfLocation_ProvinceAll(),
                                    stylingMode: "filled",
                                    //allowEditing: false,
                                    valueExpr: "id",
                                    readOnly: !$isUpdateHOR,
                                    displayExpr: "title",
                                    onValueChanged: function (e) {
                                        var selTarget = $('#elementSendDistrictId').dxSelectBox('instance');
                                        selTarget.option('value', null);
                                        console.log(e);
                                        if (e.value > 0) {
                                            console.log(e.value);
                                            selTarget.option("dataSource", customStore_ListOfLocation_ByParentId(e.value));
                                        }
                                        else {
                                            selTarget.option("dataSource", customStore_ListOfLocation_ByParentId($proviceId));
                                        }
                                    },
                                    elementAttr: {
                                        id: "elementSendCityId",
                                    },
                                },
                            },
                            {
                                colSpan: 4,
                                dataField: "sendDistrictId",
                                label: { text: "Quận/huyện" },
                                editorType: "dxSelectBox",
                                editorOptions: {
                                    searchEnabled: true,
                                    searchMode: "contains",
                                    searchExpr: ['title'],
                                    showClearButton: true,
                                    placeholder: "Vui lòng chọn...",
                                    dataSource: customStore_ListOfLocation_ByParentId(0),
                                    stylingMode: "filled",
                                    //allowEditing: false,
                                    valueExpr: "id",
                                    readOnly: !$isUpdateHOR,
                                    displayExpr: "title",
                                    onValueChanged: function (e) {
                                        console.log(e);
                                        var selTarget = $('#elementSendWardId').dxSelectBox('instance');
                                        selTarget.option('value', null);
                                        if (e.value > 0) {
                                            console.log(e.value);
                                            selTarget.option("dataSource", customStore_ListOfLocation_ByParentId(e.value));
                                        }
                                        else {
                                            selTarget.option("dataSource", customStore_ListOfLocation_ByParentId(0));
                                        }
                                    },
                                    elementAttr: {
                                        id: "elementSendDistrictId",
                                    },
                                },

                            },
                            {
                                colSpan: 4,
                                dataField: "sendWardId",
                                label: { text: "Phố/Phường" },
                                editorType: "dxSelectBox",
                                editorOptions: {
                                    searchEnabled: true,
                                    searchMode: "contains",
                                    searchExpr: ['title'],
                                    showClearButton: true,
                                    placeholder: "Vui lòng chọn...",
                                    dataSource: customStore_ListOfLocation_ByParentId(0),
                                    stylingMode: "filled",
                                    //allowEditing: false,
                                    valueExpr: "id",
                                    readOnly: !$isUpdateHOR,
                                    displayExpr: "title",
                                    elementAttr: {
                                        id: "elementSendWardId",
                                    },
                                },
                            },
                        ]
                    },
                    {
                        itemType: "group",
                        colSpan: 12,
                        colCount: 12,
                        cssClass: "delegateB-group",
                        caption: "Đại diện bên Nhận",
                        items: [
                            {
                                name: "order",
                                visible: true,
                                colSpan: 12,
                                template: function (data, $itemElement) {
                                    $("<div id='delegateB'>")
                                        .appendTo($itemElement)
                                        .dxDataGrid({
                                            dataSource: customStore_HandOverDelegate($keyHOR, false),
                                            remoteOperations: true,
                                            height: $hieghtSub,
                                            repaintChangesOnly: true,
                                            remoteOperations: true,
                                            scrolling: { mode: "standard" },
                                            showBorders: false,
                                            showColumnHeaders: true,
                                            showColumnLines: false,
                                            hoverStateEnabled: true,
                                            showRowLines: true,
                                            columnAutoWidth: true,
                                            wordWrapEnabled: true,
                                            rowAlternationEnabled: true,
                                            filterRow: { visible: true },
                                            onToolbarPreparing: function (e) {
                                                var container = e.component;
                                                e.toolbarOptions.items.unshift(
                                                    {
                                                        location: "after",
                                                        widget: "dxButton",
                                                        options: {
                                                            icon: "refresh",
                                                            type: "default",
                                                            onClick: () => container.refresh()
                                                        }
                                                    })
                                            },
                                            onInitNewRow: (e) => {
                                                e.data.isActive = true;
                                                e.data.isVisible = true;
                                                e.data.HandOverReceiptId = Id;
                                                e.data.isSenderOrReceiver = false;
                                            },
                                            onContentReady: (e) => {
                                                var container = e.component;
                                            },
                                            onSelectionChanged: (e) => {
                                                var $id = e.selectedRowKeys[0];
                                                var selectedRowData = e.selectedRowsData[0];
                                                var selectedRowKey = e.selectedRowKeys[0];
                                            },
                                            selection: {
                                                mode: "single"
                                            },
                                            columns: [
                                                {
                                                    dataField: "fullName",
                                                    dataType: "string",
                                                    caption: "Họ tên",
                                                    alignment: "center",
                                                    readOnly: false,
                                                    allowEditing: true,
                                                },
                                                {
                                                    dataField: "phoneContact",
                                                    dataType: "string",
                                                    caption: "Số Điện Thoại",
                                                    alignment: "center",
                                                    readOnly: false,
                                                    allowEditing: true,
                                                },
                                                {
                                                    dataField: "description",
                                                    dataType: "string",
                                                    caption: "Chức vụ",
                                                    alignment: "center",
                                                    readOnly: false,
                                                    allowEditing: true,
                                                },

                                            ],
                                            editing: {
                                                allowAdding: $isInsertHOR,
                                                allowUpdating: $isUpdateHOR,
                                                allowDeleting: $isDeleteHOR,
                                                mode: "batch",
                                                useIcons: true,
                                                confirmDelete: true,
                                            },
                                        });
                                }
                            }
                        ]
                    },
                    {
                        itemType: "group",
                        colSpan: 12,
                        colCount: 12,
                        cssClass: "addressb-group",
                        caption: "Thông tin bên nhận",
                        items: [
                            {
                                colSpan: 12,
                                dataField: "receiveAddress",
                                label: { text: "Địa chỉ" },
                                editorType: "dxTextBox",
                                editorOptions: {
                                    stylingMode: "filled",
                                    //allowEditing: false,
                                    readOnly: !$isUpdateHOR,
                                    elementAttr: {
                                        id: "elementRceiveAddressId",
                                    },
                                },
                            },
                            {
                                colSpan: 4,
                                dataField: "receiveCityId",
                                label: { text: "Tỉnh/Thành" },
                                editorType: "dxSelectBox",
                                editorOptions: {
                                    searchEnabled: true,
                                    searchMode: "contains",
                                    searchExpr: ['title'],
                                    showClearButton: true,
                                    placeholder: "Vui lòng chọn...",
                                    dataSource: customStore_ListOfLocation_ProvinceAll(),
                                    stylingMode: "filled",
                                    //allowEditing: false,
                                    valueExpr: "id",
                                    readOnly: !$isUpdateHOR,
                                    displayExpr: "title",
                                    onValueChanged: function (e) {
                                        var selTarget = $('#elementReceiveDistrictId').dxSelectBox('instance');
                                        selTarget.option('value', null);
                                        if (e.value > 0) {
                                            selTarget.option("dataSource", customStore_ListOfLocation_ByParentId(e.value));
                                        }
                                        else {
                                            selTarget.option("dataSource", customStore_ListOfLocation_ByParentId(0));
                                        }
                                    },
                                    elementAttr: {
                                        id: "elementReceiveCityId",
                                    },
                                },
                            },
                            {
                                colSpan: 4,
                                dataField: "receiveDistrictId",
                                label: { text: "Quận/huyện" },
                                editorType: "dxSelectBox",
                                editorOptions: {
                                    searchEnabled: true,
                                    searchMode: "contains",
                                    searchExpr: ['title'],
                                    showClearButton: true,
                                    placeholder: "Vui lòng chọn...",
                                    dataSource: customStore_ListOfLocation_ByParentId($proviceId),
                                    stylingMode: "filled",
                                    //allowEditing: false,
                                    valueExpr: "id",
                                    readOnly: !$isUpdateHOR,
                                    displayExpr: "title",
                                    onValueChanged: function (e) {
                                        var selTarget = $('#elementReceiveWardId').dxSelectBox('instance');
                                        selTarget.option('value', null);
                                        if (e.value > 0) {
                                            selTarget.option("dataSource", customStore_ListOfLocation_ByParentId(e.value));
                                        }
                                        else {
                                            selTarget.option("dataSource", customStore_ListOfLocation_ByParentId(0));
                                        }
                                    },
                                    elementAttr: {
                                        id: "elementReceiveDistrictId",
                                    },
                                },

                            },
                            {
                                colSpan: 4,
                                dataField: "receiveWardId",
                                label: { text: "Phố/Phường" },
                                editorType: "dxSelectBox",
                                editorOptions: {
                                    searchEnabled: true,
                                    searchMode: "contains",
                                    searchExpr: ['title'],
                                    showClearButton: true,
                                    placeholder: "Vui lòng chọn...",
                                    dataSource: customStore_ListOfLocation_ByParentId(0),
                                    stylingMode: "filled",
                                    //allowEditing: false,
                                    valueExpr: "id",
                                    readOnly: !$isUpdateHOR,
                                    displayExpr: "title",
                                    elementAttr: {
                                        id: "elementReceiveWardId",
                                    },
                                },
                            },
                        ]
                    },
                    {
                        itemType: "group",
                        colSpan: 12,
                        colCount: 12,
                        cssClass: "Item-group",
                        caption: "Nội dung bàn giao",
                        items: [
                            {
                                name: "order",
                                visible: true,
                                colSpan: 12,
                                template: function (data, $itemElement) {
                                    $("<div id='HandOverReceiptDetail'>")
                                        .appendTo($itemElement)
                                        .dxDataGrid({
                                            dataSource: customStore_HandOverReceiptDetail($keyHOR),
                                            remoteOperations: true,
                                            height: $hieghtSub + 300,
                                            repaintChangesOnly: true,
                                            remoteOperations: true,
                                            scrolling: { mode: "standard" },
                                            showBorders: false,
                                            showColumnHeaders: true,
                                            showColumnLines: false,
                                            hoverStateEnabled: true,
                                            showRowLines: true,
                                            columnAutoWidth: true,
                                            wordWrapEnabled: true,
                                            rowAlternationEnabled: true,
                                            filterRow: { visible: true },
                                            onToolbarPreparing: function (e) {
                                                var container = e.component;
                                                e.toolbarOptions.items.unshift(
                                                    {
                                                        location: "after",
                                                        widget: "dxButton",
                                                        options: {
                                                            text: "Thêm mới",
                                                            visible: PermitInAction.insert,
                                                            stylingMode: "filled",
                                                            disabled: !$isUpdateHOR,
                                                            //icon: "add",
                                                            onClick: function () {
                                                                CALLPOPUP(
                                                                    "THÊM MỚI HẠNG MỤC BÀN GIAO",
                                                                    "/VanHanh/BanGiao/_HRDCreate?id=" + $keyHOR,
                                                                    ($(window).width() > 767 ? "50%" : "80%"),
                                                                    container
                                                                );
                                                            }
                                                        }
                                                    },
                                                    {
                                                        location: "after",
                                                        widget: "dxButton",
                                                        options: {
                                                            icon: "refresh",
                                                            type: "default",
                                                            onClick: () => container.refresh()
                                                        }
                                                    })
                                            },
                                            onInitNewRow: (e) => {
                                                e.data.isActive = true;
                                                e.data.isVisible = true;
                                                e.data.isSenderOrReceiver = true;
                                            },
                                            onContentReady: (e) => {
                                                var container = e.component;
                                            },
                                            onSelectionChanged: (e) => {
                                                var $id = e.selectedRowKeys[0];
                                                var selectedRowData = e.selectedRowsData[0];
                                                var selectedRowKey = e.selectedRowKeys[0];
                                            },
                                            selection: {
                                                mode: "single"
                                            },
                                            columns: [
                                                {
                                                    dataField: "fromHandOverReceiptId",
                                                    dataType: "string",
                                                    alignment: "left",
                                                    caption: "Từ đơn tiếp nhận",
                                                    readOnly: false,
                                                    allowEditing: true,
                                                    lookup: {
                                                        dataSource: customStore().store(),
                                                        valueExpr: "id",
                                                        displayExpr: "code",
                                                    }
                                                },
                                                {
                                                    dataField: "handOverItemId",
                                                    dataType: "string",
                                                    caption: "tên",
                                                    alignment: "center",
                                                    readOnly: false,
                                                    allowEditing: true,
                                                    lookup: {
                                                        dataSource: customStore_HandOverItem_All().store(),
                                                        valueExpr: "id",
                                                        displayExpr: "title",
                                                    }
                                                },
                                                {
                                                    dataField: "quantity",
                                                    dataType: "string",
                                                    caption: "Số lượng",
                                                    alignment: "center",
                                                    readOnly: false,
                                                    allowEditing: true,
                                                },
                                                //{
                                                //    dataField: "categoryUnitId",
                                                //    dataType: "string",
                                                //    caption: "Đơn vị",
                                                //    alignment: "center",
                                                //    readOnly: false,
                                                //    allowEditing: true,
                                                //    lookup: {
                                                //        dataSource: customStore_CategoryUnit,
                                                //        valueExpr: "id",
                                                //        displayExpr: "title",
                                                //    }  
                                                //},
                                                {
                                                    dataField: "description",
                                                    dataType: "string",
                                                    alignment: "left",
                                                    caption: "Mô tả",
                                                    alignment: "center",
                                                    readOnly: false,
                                                    allowEditing: true,
                                                },
                                            ],
                                            editing: {
                                                allowAdding: false,
                                                allowUpdating: false,
                                                allowDeleting: $isDeleteHOR,
                                                mode: "batch",
                                                useIcons: true,
                                                confirmDelete: true,
                                            },
                                            masterDetail: {
                                                autoExpandAll: false,
                                                component: null,
                                                enabled: true,
                                                render: null,
                                                template: function (container, options) {
                                                    container.attr("style", "background-color: rgba(248,141,43,0.5) !important; padding: 10px !important;");
                                                    //$("<div>")
                                                    //    .addClass("master-detail-caption")
                                                    //    .text(" Thông tin chi tiết:")
                                                    //    .appendTo(container);
                                                    $("<div>")
                                                        .dxTreeList({
                                                            dataSource: customStore_HandOverItemSpecifications(options.data.handOverItemId),
                                                            remoteOperations: true,
                                                            height: $hieghtSub,
                                                            rootValue: 0,
                                                            parentIdExpr: "parentid",
                                                            keyExpr: "id",
                                                            showBorders: false,
                                                            showColumnHeaders: true,
                                                            showColumnLines: false,
                                                            hoverStateEnabled: true,
                                                            showRowLines: true,
                                                            columnAutoWidth: true,
                                                            wordWrapEnabled: true,
                                                            rowAlternationEnabled: true,
                                                            autoExpandAll: false,
                                                            //onToolbarPreparing: function (e) {
                                                            //    var container = e.component;
                                                            //    e.toolbarOptions.items.unshift(
                                                            //        {
                                                            //            location: "after",
                                                            //            widget: "dxButton",
                                                            //            options: {
                                                            //                icon: "refresh",
                                                            //                type: "default",
                                                            //                onClick: () => container.refresh()
                                                            //            }
                                                            //        })
                                                            //},
                                                            onInitNewRow: (e) => {
                                                                e.data.isActive = true;
                                                                e.data.isVisible = true;
                                                                e.data.isSenderOrReceiver = true;
                                                            },
                                                            onContentReady: (e) => {
                                                                var container = e.component;
                                                            },
                                                            onSelectionChanged: (e) => {
                                                                var $id = e.selectedRowKeys[0];
                                                                var selectedRowData = e.selectedRowsData[0];
                                                                var selectedRowKey = e.selectedRowKeys[0];
                                                            },
                                                            selection: {
                                                                mode: "single"
                                                            },
                                                            columns: [
                                                                {
                                                                    dataField: "title",
                                                                    dataType: "string",
                                                                    alignment: "left",
                                                                    caption: "Tên",
                                                                    readOnly: false,
                                                                    allowEditing: true,
                                                                },
                                                                {
                                                                    dataField: "description",
                                                                    dataType: "string",
                                                                    caption: "Mô tả",
                                                                    alignment: "center",
                                                                    readOnly: false,
                                                                    allowEditing: true,
                                                                },
                                                                {
                                                                    dataField: "quantity",
                                                                    dataType: "string",
                                                                    caption: "Số lượng",
                                                                    alignment: "center",
                                                                    readOnly: false,
                                                                    allowEditing: true,
                                                                },
                                                                {
                                                                    dataField: "categoryUnitId",
                                                                    dataType: "string",
                                                                    caption: "Đơn vị",
                                                                    alignment: "center",
                                                                    readOnly: false,
                                                                    allowEditing: true,
                                                                    lookup: {
                                                                        dataSource: customStore_CategoryUnit,
                                                                        valueExpr: "id",
                                                                        displayExpr: "title",
                                                                    }
                                                                },
                                                            ],
                                                            editing: {
                                                                allowAdding: false,
                                                                allowUpdating: false,
                                                                allowDeleting: false,
                                                                mode: "batch",
                                                                useIcons: true,
                                                                confirmDelete: true,
                                                            },
                                                        })
                                                        .attr("style", "margin:auto; width:96%")
                                                        .appendTo(container);;
                                                }
                                            },
                                        });
                                }
                            }
                        ]
                    },
                    {
                        itemType: "group",
                        colSpan: 12,
                        colCount: 12,
                        cssClass: "description-group",
                        //caption: "Phụ lục",
                        items: [
                            {
                                colSpan: 12,
                                dataField: "description",
                                label: { text: "Phụ lục" },
                                editorType: "dxTextArea",
                                editorOptions: {
                                    stylingMode: "filled",
                                    height: 90,
                                    //allowEditing: false,
                                    readOnly: !$isUpdateHOR,
                                    elementAttr: {
                                        id: "elementDescriptionId",
                                    },
                                },
                            },
                        ]
                    },
                    {
                        itemType: "group",
                        colSpan: 12,
                        colCount: 12,
                        cssClass: "note-group",
                        //caption: "Nghi chú",
                        items: [
                            {
                                colSpan: 12,
                                dataField: "note",
                                label: { text: "Ghi chú" },
                                editorType: "dxTextArea",
                                editorOptions: {
                                    stylingMode: "filled",
                                    height: 90,
                                    //allowEditing: false,
                                    readOnly: !$isUpdateHOR,
                                    elementAttr: {
                                        id: "elementNoteId",
                                    },
                                },
                            },
                        ]
                    },
                    {
                        colSpan: 12,
                        itemType: "simple",
                        name: "Image",
                        editorType: 'dxGallery',
                        editorOptions: {
                            stylingMode: "filled",
                            dataSource: customStore_Attachment($keyHOR, "HandOverReceipt"),
                            height: 100,
                            width: 'auto',
                            slideshowDelay: 1500,
                            itemTemplate: function (data) {
                                var $link = (data.host + data.url + "/" + data.fileName);
                                return $("<a/>").attr("href", $link).attr("target", "_blank").append($("<img />").attr({ "src": $link, onerror: ImgError(this), "style": "max-height: 100px; height : auto ;width : auto ;margin: auto;" }));
                            },
                            onItemClick: function (value) {
                            }
                        },
                        elementAttr: {
                            id: "elementGalleryId",
                        },
                    },
                    {
                        colSpan: 12,
                        visible: $isUpdateHOR,//rs[0].status??0 < 200 ? true : false,
                        template: '<span class="dx-field-item-label-text font-bold">Các tập tin đính kèm</span><div class="file-uploader" id="file-uploader"></div>',
                    },
                    {
                        itemType: "group",
                        name: "button-action",
                        colCount: 12,
                        colSpan: 12,
                        items: [
                            {
                                colSpan: 12,
                                itemType: "button",
                                horizontalAlignment: "center",
                                disabled: !$isUpdateHOR,
                                buttonOptions: {
                                    text: "Cập nhật hình ảnh",
                                    icon: "fa fa-image",
                                    type: "default",
                                    useSubmitBehavior: false,
                                    elementAttr: {
                                        id: "uploadImage",
                                    },
                                    editorOptions: {
                                        stylingMode: "filled",
                                    },
                                    onClick: function (e) {
                                        var deferred = $.Deferred();
                                        var formData = new FormData();
                                        formData.append("key", $keyHOR);
                                        formData.append('token', UserCurrentInfo.accessToken);
                                        var files = $("#file-uploader").dxFileUploader("instance").option("value");
                                        if (files.length > 0) {
                                            $.each(files, function (key, value) {
                                                formData.append(files[key].name, files[key]);
                                            });
                                        }
                                        $.ajax({
                                            type: "POST",
                                            enctype: 'multipart/form-data',
                                            url: "/VanHanh/BanGiao/UploadImages",
                                            data: formData,
                                            processData: false,
                                            contentType: false,
                                            cache: false,
                                            timeout: 600000,
                                            success: function (rs) {
                                                loadingPanel.hide();
                                                DevExpress.ui.notify(rs.result, rs.status, 3000);
                                            },
                                            error: function (xhr, textStatus, errorThrown) {
                                                loadingPanel.hide();
                                                DevExpress.ui.notify("Vui lòng chọn File!", "error", 3000);

                                            }
                                        });
                                        return deferred.promise();
                                    }
                                }
                            },
                        ],
                    },
                    {
                        itemType: "group",
                        name: "button-action",
                        colCount: 12,
                        colSpan: 12,
                        items: [
                            {
                                colSpan: 6,
                                itemType: "button",
                                horizontalAlignment: "right",
                                disabled: !$isUpdateHOR,
                                buttonOptions: {
                                    text: "Cập nhật biên bản",
                                    icon: "fa fa-save",
                                    type: "default",
                                    useSubmitBehavior: false,
                                    elementAttr: {
                                        id: "updateHOR",
                                    },
                                    editorOptions: {
                                        stylingMode: "filled",
                                    }
                                }
                            },
                            {
                                colSpan: 6,
                                itemType: "button",
                                horizontalAlignment: "left",
                                disabled: !$isUpdateHOR,
                                buttonOptions: {
                                    text: "Hoàn tất biên bản",
                                    icon: "fa fa-save",
                                    type: "success",
                                    useSubmitBehavior: true,
                                    elementAttr: {
                                        id: "finishHOR",
                                    },
                                    editorOptions: {
                                        stylingMode: "filled",
                                    }
                                }
                            },
                        ],

                    },
                ]
            }).dxForm('instance');
            fileUploader();
        });
    };
    function createHOR(IsInOrOut) {
        loadingPanel.show();
        customStore(IsInOrOut).store().load().done((rs) => {
            if (rs.length < 1) {
                loadingPanel.hide();
                var obj = {};
                obj["isInOrOut"] = IsInOrOut;
                obj["status"] = 10;
                obj["isDelete"] = false;
                obj["isActive"] = true;
                obj["isVisible"] = true;
                obj["title"] = 'Phiếu giao nhận';
                customStore().store().insert(obj).done((rsSub) => {
                    loadingPanel.hide();
                    $keyHOR = rsSub.result.id;
                    loadData_Form($keyHOR);
                });
            }
            else {
                var rsFilter = rs.filter(x => x.createBy === UserCurrentInfo.accountId && x.status < 200 && isInOrOut === IsInOrOut)
                if (rsFilter.length < 1) {
                    loadingPanel.hide();
                    var obj = {};
                    obj["isInOrOut"] = IsInOrOut;
                    obj["status"] = 10;
                    obj["isDelete"] = false;
                    obj["isActive"] = true;
                    obj["isVisible"] = true;
                    obj["title"] = 'Phiếu giao nhận';
                    customStore().store().insert(obj).done((rsSub) => {
                        loadingPanel.hide();
                        $keyHOR = rsSub.result.id;
                        loadData_Form($keyHOR);
                    });
                }
                else {
                    loadingPanel.hide();
                    $keyHOR = rsFilter[0].id;
                    loadData_Form($keyHOR);
                }

            }
        });
    };
    $("#form-HandOverReceiptFull").on("submit", function (e) {
        e.preventDefault();
        var formdata = $('#form-HandOverReceiptFull').dxForm("instance").option('formData');
        var resValid = true
        if (!resValid) {
            DevExpress.ui.notify("Vui lòng kiểm tra lại file đính kèm!", "error", 3000);
        }
        else {
            loadingPanel.show();
            formdata["status"] = 200;
            var deferred = $.Deferred();
            customStore(0).store().update($keyHOR, formdata).done((rs) => {
                loadingPanel.hide();
                if (rs.isOk) {
                    deferred.resolve(rs);
                    $("#container").dxDataGrid("instance").refresh();
                    $("#form-HandOverReceiptFull").dxForm("instance").repaint();
                    DevExpress.ui.notify("Cập nhật thành công", "success", 3000);
                }
                else {
                    DevExpress.ui.notify("Có lỗi xảy ra", "error", 3000);
                    deferred.resolve(false);
                }
            }, deferred.reject)
            return deferred.promise();
        }
    });
    $(document).on('click', '#updateHOR', '#form-HandOverReceiptDetail', function (e) {
        e.preventDefault();
        var formdata = $('#form-HandOverReceiptFull').dxForm("instance").option('formData');
        var resValid = true
        if (!resValid) {
            DevExpress.ui.notify("Vui lòng kiểm tra lại file đính kèm!", "error", 3000);
        }
        else {
            loadingPanel.show();
            formdata["status"] = 100;
            var deferred = $.Deferred();
            customStore(0).store().update($keyHOR, formdata).done((rs) => {
                loadingPanel.hide();
                if (rs.isOk) {
                    deferred.resolve(rs);
                    $("#container").dxDataGrid("instance").refresh();
                    $("#form-HandOverReceiptFull").dxForm("instance").repaint();
                    DevExpress.ui.notify("Cập nhật thành công", "success", 3000);
                }
                else {
                    DevExpress.ui.notify("Có lỗi xảy ra", "error", 3000);
                    deferred.resolve(false);
                }
            }, deferred.reject);
            return deferred.promise();
        }
    });
    var fileUploader = () => $("#file-uploader").dxFileUploader({
        selectButtonText: "Chọn tập tin...",
        labelText: "Hoặc kéo thả vào đây",
        showFileList: true,
        multiple: true,
        uploadMode: "useForm",
        accept: ".jpg,.jpeg,.gif,.png,.pdf",
        allowedFileExtensions: [".jpg", ".jpeg", ".png", ".pdf"],
        maxFileSize: 52428800,
    }).dxFileUploader("instance");

});