var id = 1;
var $WHId = 0;
var $issetHOR = false;
var $keyHOR = 0;
var $isUpdateHOR = false;
var $isInsertHOR = false;
var $isDeleteHOR = false;
var $proviceId = 13;
var $districtId = 76;
var $wardId = 783;
var formData = {
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
    , "noAttachment":0
    , "type": 0
};
//----------------------------- READ -------------------------------------------------------------

var ACTION_HANDOVERRECEIPT = "HandOverReceipt/";
var ACTION_HANDOVERRECEIPTDETAIL = "HandOverReceiptDetail/";
var ACTION_HANDOVERITEM = "HandOverItem/";
var ACTION_HANDOVERITEMSPECIFICATIONS = "HandOverItemSpecifications/";
var ACTION_HANDOVERDELEGATE = "HandOverDelegate";
var ACTION_LISTOFLOCATION = "ListOfLocation/";
var ACTION_CATEGORYGOODS = "CategoryGoods/";
var ACTION_FILESATTACHMENT = "FilesAttachment/";
var KEY = "id";
var WIDTH_CONTAINER = $("#container").width();

//----------------------------------- Get data ----------------------------------------------------
var customStore = () => new DevExpress.data.DataSource({
    store: $DATASOURCEGET(ACTION_HANDOVERRECEIPT, KEY),
});
var customStore_ById = (Id) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_HANDOVERRECEIPT, KEY),
    filter: [["id", "=", id]]
});
var customStore_HandOverDelegate = (Id) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_HANDOVERRECEIPT, KEY),
    filter: [["HandOverReceiptId", "=", id]]
});
var customStore_ListOfLocation_ProvinceAll = () => new DevExpress.data.DataSource({
    store: $DATASOURCEGET(ACTION_LISTOFLOCATION, KEY),
    filter: [["type", "=", "Province"]]
});
var customStore_ListOfLocation_ByParentId = (Id) => new DevExpress.data.DataSource({
    store: $DATASOURCEGET(ACTION_LISTOFLOCATION, KEY),
    filter: [["parentId", "=", id === 0 ? 1 : id ]]
});
var customStore_CategoryUnit = $DATASOURCEGET(ACTION_CATEGORYUNIT, KEY);
var customStore_Attachment = (id, owner) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_FILESATTACHMENT, KEY),
    filter: [["ownerById", "=", id], "and", ["ownerByTable", "=", owner]]
});
var customStore_Attachment_All = (owner) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_FILESATTACHMENT, KEY),
    filter: ["ownerByTable", "=", owner]
});
//----------------------------------- Function ------------------------------------------------------
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
            $WarehouseStorageID = selectedRowKey;

            if (selectedRowData != null && selectedRowKey != null) {
                var data = e.component.getRowIndexByKey(selectedRowData.paId);
                $("#action-update").dxSpeedDialAction({
                    index: 2, icon: "fas fa-file-import",
                    label: "Nhập kho",
                    visible: PermitInAction["update"],
                    onClick: () => {
                        var containerE = e.component;
                        CALLPOPUP(
                            "Phiếu nhập kho",
                            "/VanHanh/KhoBai/_XuatNhapCreate?id=" + selectedRowKey + "&isIn=true",
                            ($(window).width() > 767 ? "50%" : "80%"),
                            containerE
                        );
                    }
                }).dxSpeedDialAction("instance");
                $("#action-delete").dxSpeedDialAction({
                    index: 3,
                    icon: "fas fa-file-export",
                    label: "Xuất kho",
                    visible: (selectedRowData.id != null && PermitInAction["delete"]),
                    onClick: () => {
                        var containerE = e.component;
                        CALLPOPUP(
                            "Phiếu xuất kho",
                            "/VanHanh/KhoBai/_XuatNhapCreate?id=" + selectedRowKey + "&isIn=false",
                            ($(window).width() > 767 ? "50%" : "80%"),
                            containerE
                        );
                    }
                }).dxSpeedDialAction("instance");
                $("#action-log").dxSpeedDialAction({
                    index: 4,
                    icon: "fas fa-shipping-fast",
                    label: "Nhật ký xuất nhập",
                    visible: PermitInAction["view"],
                    onClick: () => {
                        var containerE = e.component;
                        CALLPOPUP(
                            "Lịch sử xuất nhập",
                            "/VanHanh/KhoBai/_NhatKyKho?id=" + selectedRowKey,
                            ($(window).width() > 767 ? "70%" : "90%"),
                            containerE
                        );
                    }
                }).dxSpeedDialAction("instance");
            }
            loadData_Detail($id);
        },
        selection: {
            mode: "single"
        },
        columns: [
            {
                dataField: "code",
                allowFiltering: true,
                caption: "Mã",
                width: "250",
                dataType: "string",
                alignment: "center",
                readOnly: true,
                allowEditing: false,
            },// code
            {
                dataField: "title",
                dataType: "string",
                alignment: "left",
                caption: "Tiêu đề",
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
};
var loadData_Form = (id) => {
    customStore_ById(id).load().done((rs) => {
        $issetHOR = (rs.length > 0);
        if ($issetHOR) {
            $keyHOR = rs[0].id;
        }
        $("#form-HandOverReceiptFull").dxForm({
            formData: rs[0],
            labelLocation: "top",
            height: heightScreen,
            items: [
                {
                    itemType: "group",
                    colCount: 12,
                    cssClass: "delegateA-group",
                    caption: "Bên Giao",
                    items: [
                        {
                            name: "order",
                            visible: isOrderShown,
                            template: function (data, $itemElement) {
                                $("<div id='delegateA'>")
                                    .appendTo($itemElement)
                                    .dxDataGrid({
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
                                                alignment: "left",
                                                caption: "Họ tên",
                                                alignment: "center",
                                                readOnly: false,
                                                allowEditing: true,
                                            },
                                            {
                                                dataField: "phoneContact",
                                                dataType: "string",
                                                alignment: "left",
                                                caption: "Số Điện Thoại",
                                                alignment: "center",
                                                readOnly: false,
                                                allowEditing: true,
                                            },
                                            {
                                                dataField: "description",
                                                dataType: "string",
                                                alignment: "left",
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
                                readOnly: true,
                                elementAttr: {
                                    id: "elementSendAddressId",
                                },
                            },
                        },
                        {
                            colSpan: 3,
                            dataField: "sendCity",
                            label: { text: "Tỉnh/Thành" },
                            editorType: "dxSelectBox",
                            editorOptions: {
                                dataSource: customStore_ListOfLocation_ProvinceAll(),
                                stylingMode: "filled",
                                //allowEditing: false,
                                valueExpr: "id",
                                readOnly: true,
                                displayExpr: "code",
                                value: id,
                                elementAttr: {
                                    id: "elementSendCityId",
                                },
                            },
                        },
                        {
                            colSpan: 3,
                            dataField: "sendDistrict",
                            label: { text: "Quận/huyện" },
                            editorType: "dxSelectBox",
                            editorOptions: {
                                dataSource: customStore_ListOfLocation_ByParentId($proviceId),
                                stylingMode: "filled",
                                //allowEditing: false,
                                valueExpr: "id",
                                readOnly: true,
                                displayExpr: "code",
                                value: id,
                                elementAttr: {
                                    id: "elementSendDistrictId",
                                },
                            },
                        },
                        {
                            colSpan: 3,
                            dataField: "sendWard",
                            label: { text: "Phố/Phường" },
                            editorType: "dxSelectBox",
                            editorOptions: {
                                dataSource: customStore_ListOfLocation_ByParentId($districtId),
                                stylingMode: "filled",
                                //allowEditing: false,
                                valueExpr: "id",
                                readOnly: true,
                                displayExpr: "code",
                                value: id,
                                elementAttr: {
                                    id: "elementSendWardId",
                                },
                            },
                        },
                    ]
                },
                {
                    itemType: "group",
                    colCount: 12,
                    cssClass: "delegateB-group",
                    caption: "Bên Nhận",
                    items: [
                        {
                            name: "order",
                            visible: isOrderShown,
                            template: function (data, $itemElement) {
                                $("<div id='delegateB'>")
                                    .appendTo($itemElement)
                                    .dxDataGrid({
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
                                                alignment: "left",
                                                caption: "Họ tên",
                                                alignment: "center",
                                                readOnly: false,
                                                allowEditing: true,
                                            },
                                            {
                                                dataField: "phoneContact",
                                                dataType: "string",
                                                alignment: "left",
                                                caption: "Số Điện Thoại",
                                                alignment: "center",
                                                readOnly: false,
                                                allowEditing: true,
                                            },
                                            {
                                                dataField: "description",
                                                dataType: "string",
                                                alignment: "left",
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
                    colCount: 12,
                    cssClass: "addressb-group",
                    caption: "Thông tin bên nhận",
                },
            ]
        });
    });
};