var id = 1;
var $WHId = 0;
//-----------------------------READ -------------------------------------------------------------
var ACTION_FILESATTACHMENT = "FilesAttachment/";
var ACTION_WAREHOUSEALLGOODS = "WareHouseAllGoods/";
var ACTION_CONSTRUCTIONITEMS = "ConstructionItems/";
var ACTION_REALESTATE = "RealEstate/";
var ACTION_WAREHOUSESTORAGE = "WarehouseStorage/";
var ACTION_WAREHOUSEGOODSLOG = "WarehouseGoodsLog/";
var ACTION_CATEGORYUNIT = "CategoryUnit/";
var ACTION_CATEGORYGOODS = "CategoryGoods/";
var ACTION_WAREHOUSERELEASED = "WarehouseReleased/";
var ACTION_WAREHOUSERELEASEDDETAIL = "WarehouseReleasedDetail/";
var KEY = "id";
var WIDTH_CONTAINER = $("#container").width();
var WareHouseID = isNullOrEmpty(localStorage.getItem("WareHouseCurrent")) ? parseInt(localStorage.getItem("WareHouseCurrent")) : 14;
var WarehouseStorageID = isNullOrEmpty(localStorage.getItem("WarehouseStorageCurrent")) ? parseInt(localStorage.getItem("WarehouseStorageCurrent")) : 14;
var $WareHouseID = 0;
var $realEstateId = 0;
var $WarehouseStorageID = 0;

//..........................Get data -------------------------------------------------------------
var customStore_Attachment = (id, owner) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_FILESATTACHMENT, KEY),
    filter: [["ownerById", "=", id], "and", ["ownerByTable", "=", owner]]
});
var customStore_Attachment_All = (owner) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_FILESATTACHMENT, KEY),
    filter: ["ownerByTable", "=", owner]
});
var customStore = (id) => new DevExpress.data.DataSource({
    store: $DATASOURCEGET(ACTION_WAREHOUSEALLGOODS, KEY),
    filter: ["WarehouseStorageId", "=", id]
});
var customStore_Detail = (id) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_FEEDBACK, KEY),
    filter: ["id", "=", id]
});
var customStore_WareHouse = new DevExpress.data.DataSource({
    store: $DATASOURCEGET(ACTION_CONSTRUCTIONITEMS, KEY),
    filter: [["parentId", "=", 0], "and", ["status", "=", 201]]
});
var customStore_WarehouseStorage = (id) => new DevExpress.data.DataSource({
    store: $DATASOURCEGET(ACTION_WAREHOUSESTORAGE, KEY),
    filter: ["realEstateId", "=", id]
});
var customStore_RealEstate = (id) => new DevExpress.data.DataSource({
    store: $DATASOURCEGET(ACTION_REALESTATE, KEY),
    filter: [["ConstructionItemsId", "=", id]]
});
var customStore_WarehouseGoodsLog = (id) => new DevExpress.data.DataSource({
    store: $DATASOURCEGET(ACTION_WAREHOUSEGOODSLOG, KEY),
    filter: [["WarehouseStorageId", "=", id]]
});
var customStore_CategoryGoods = $DATASOURCEGET(ACTION_CATEGORYGOODS, KEY);
var customStore_CategoryGoods_Id = (Id) => new DevExpress.data.DataSource({
    store: $DATASOURCEGET(ACTION_CATEGORYGOODS, KEY),
    filter: [["id", "=", Id]]
});
var customStore_CategoryUnit = $DATASOURCEGET(ACTION_CATEGORYUNIT, KEY);
var customStore_Goods = $DATASOURCEGET(ACTION_WAREHOUSEALLGOODS, KEY);
var customStore_WarehouseStorageList = $DATASOURCEGET(ACTION_WAREHOUSESTORAGE, KEY);
var customStore_WarehouseReleased = (InOrOut) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_WAREHOUSERELEASED, KEY),
    filter: [["IsInOrOut", "=", InOrOut], "and", ["status", "<", 200], "and", ["CreateBy", "=", UserCurrentInfo.accountId]]
});
var customStore_WarehouseReleased_Id = (Id) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_WAREHOUSERELEASED, KEY),
    filter: [["id", "=", Id]]
});
var customStore_WarehouseReleased_WHSId = (Id) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_WAREHOUSERELEASED, KEY),
    filter: [["WarehouseStorageId", "=", Id]]
});
var customStore_WarehouseReleasedDetail = (id) => new DevExpress.data.DataSource({
    store: $DATASOURCE(ACTION_WAREHOUSERELEASEDDETAIL, KEY),
    filter: [["WarehouseReleasedId", "=", id]]
});

//------------------------- Check validate ------------------------------------------
var checkInventory = function (id) {
    if (WarehouseStorageID === null) {
        WarehouseStorageID = isNullOrEmpty(localStorage.getItem("WarehouseStorageCurrent")) ? parseInt(localStorage.getItem("WarehouseStorageCurrent")) : 14;
    };
    var dCheck = $.Deferred();
    //setTimeout(function () {
    //    d.resolve(value === validEmail);
    //}, 1000);
    console.log(id);
    customStore_WarehouseGoodsLog(WarehouseStorageID).load().done((rs) => {
        var quantity = rs.find(x => x.id == id).quantity;
        console.log(rs);
        dCheck.resolve(quantity);
    });
    return dCheck.promise();
};

//..........................  Load View -------------------------------------------------------------
$(function () {
    loadData();
});

var loadData = () => {
    if (WarehouseStorageID === null) {
        WarehouseStorageID = isNullOrEmpty(localStorage.getItem("WarehouseStorageCurrent")) ? parseInt(localStorage.getItem("WarehouseStorageCurrent")) : 14;
    };
    $("#container").dxTreeList({
        dataSource: customStore_WarehouseStorage(WarehouseStorageID),
        remoteOperations: true,
        height: heightScreen,
        rootValue: 0,
        parentIdExpr: "parentId",
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
        searchPanel: {
            visible: false,
        },
        paging: { enabled: false },
        onToolbarPreparing: function (e) {
            var container = e.component;
            e.toolbarOptions.items.unshift(
                {
                    location: "before",
                    widget: "dxSelectBox",
                    options: {
                        dataSource: customStore_WareHouse,
                        valueExpr: "id",
                        displayExpr: "title",
                        width: "150",
                        searchEnabled: true,
                        searchMode: "contains",
                        showClearButton: false,
                        stylingMode: "filled",
                        value: WareHouseID,
                        onValueChanged: function (data) {
                            WareHouseID = data.value;
                            localStorage.setItem('WareHouseCurrent', data.value);
                        },
                    },
                },
                {
                    location: "before",
                    widget: "dxSelectBox",
                    options: {
                        dataSource: customStore_RealEstate(WareHouseID),
                        valueExpr: "id",
                        displayExpr: "address",
                        width: "150",
                        searchEnabled: true,
                        searchMode: "contains",
                        showClearButton: false,
                        stylingMode: "filled",
                        value: WarehouseStorageID,
                        onValueChanged: function (data) {
                            WarehouseStorageID = data.value;
                            localStorage.setItem('WarehouseStorageCurrent', data.value);
                            loadData();
                        },
                    },
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
                caption: "Tên",
            },
        ],
        editing: {
            allowAdding: false,
            allowUpdating: false,
            allowDeleting: false,
            mode: "popup",
            useIcons: true,
            confirmDelete: true,
            popup: {
                width: "60%",
                height: "60%",
                showTitle: true,
                title: "Thêm hạng mục vận hành",
                closeOnOutsideClick: false,
                showCloseButton: true,
            },
            form: {
                labelLocation: "left",
                itemType: "group",
                colCount: 12,
                showRequiredMark: true,
                requiredMark: "(*)",
                items: [
                    {
                        colSpan: 4,
                        dataField: "title",
                        label: { text: "Tên" },
                        editorOptions: {
                            stylingMode: "filled",
                            placeholder: "Vui lòng nhập...",
                        },
                        validationRules: [{ type: "required" }],
                    },
                ],
            },
        },
    })
};
var loadData_Detail = (ItemID) => {
    $("#container-detail").dxDataGrid({
        height: heightScreen,
        dataSource: customStore(ItemID),
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
        summary: {
            groupItems: [{
                column: "pmIsVisible",
                summaryType: "count"
            },
            ]
        },
        paging: {
            enabled: true,
            pageSize: 20
        },
        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [10, 20, 40],
            showInfo: true,
        },
        searchPanel: {
            highlightCaseSensitive: true,
            highlightSearchText: true,
            searchVisibleColumnsOnly: true,
            visible: WIDTH_CONTAINER > 350
        },
        onToolbarPreparing: function (e) {
            var container = e.component;
            e.toolbarOptions.items.unshift(
                {
                    location: "after",
                    widget: "dxButton",
                    options: {
                        icon: "decreaseindent",
                        tylingMode: "filled",
                        type: "default",
                        onClick: () => {
                            CALLPOPUP(
                                "Phiếu xuất kho",
                                "/VanHanh/KhoBai/_XuatNhapCreate?id=" + ItemID + "&isIn=false",
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
                        icon: "increaseindent",
                        tylingMode: "filled",
                        type: "default",
                        onClick: () => {
                            CALLPOPUP(
                                "Phiếu nhập kho",
                                "/VanHanh/KhoBai/_XuatNhapCreate?id=" + ItemID + "&isIn=true",
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
                        tylingMode: "filled",
                        type: "default",
                        onClick: () => container.refresh()
                    },

                },

            )
        },
        onInitNewRow: (e) => {
            e.data.isActive = true;
            e.data.isVisible = true;
        },
        onRowUpdating: (e) => {
            console.log(e);
            e.newData['isVisible'] = e.newData['pmIsVisible'];
            e.newData['id'] = e.oldData['id'];
        },
        onCellPrepared: (e) => {
            if (e.rowType == "data" && e.columnIndex == 1)
                e.cellElement.find('.dx-treelist-empty-space').toggleClass("dx-treelist-collapsed", e.data.chilCount > 0)
        },
        onRowDblClick: function (e) {
            var container = e.component;
        },
        selection: {
            mode: "single"
        },
        onContentReady: (e) => {

        },
        onSelectionChanged: (e) => {

        },
        onCellClick: function (e) {

        },
        columns: [
            {
                dataField: "categoryGoodsId",
                allowFiltering: true,
                caption: "Hàng hóa",
                width: "250",
                dataType: "string",
                alignment: "center",
                readOnly: true,
                allowEditing: false,
                lookup: {
                    dataSource: customStore_CategoryGoods,
                    valueExpr: "id",
                    displayExpr: "title",
                },
            },// code
            {
                dataField: "quantity",
                allowFiltering: true,
                caption: "Tồn kho",
                dataType: "number",
                alignment: "center",
                readOnly: true,
                allowEditing: false,
            },// code
            {
                dataField: "unitId",
                allowFiltering: true,
                caption: "Đơn vị",
                dataType: "string",
                alignment: "center",
                readOnly: true,
                allowEditing: false,
                lookup: {
                    dataSource: customStore_CategoryUnit,
                    valueExpr: "id",
                    displayExpr: "title",
                },
            },// code
        ],
        editing: {
            allowAdding: false,
            allowUpdating: false,
            allowDeleting: false,
            mode: "batch",
            useIcons: true,
            confirmDelete: true,
            popup: {
                width: "50%",
                height: "50%",
                showTitle: true,
                title: "kế hoạch công việc",
                closeOnOutsideClick: false,
                showCloseButton: true,
            },
            form: {
                labelLocation: "left",
                itemType: "group",
                colCount: 12,
                showRequiredMark: true,
                requiredMark: "(*)",
                items: [
                    {
                        colSpan: 3,
                        dataField: "name",
                        label: { text: "Mã " },
                        editorOptions: {
                            stylingMode: "filled",
                            placeholder: "Vui lòng nhập...",
                        },
                    },
                ],
            },
        },
    });
};
var loadData_Goods = () => {
    $("#container-goods").dxDataGrid({
        height: heightScreen,
        dataSource: customStore_Goods(),
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
        summary: {
            groupItems: [{
                column: "pmIsVisible",
                summaryType: "count"
            },
            ]
        },
        paging: {
            enabled: true,
            pageSize: 20
        },
        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [10, 20, 40],
            showInfo: true,
        },
        searchPanel: {
            highlightCaseSensitive: true,
            highlightSearchText: true,
            searchVisibleColumnsOnly: true,
            visible: WIDTH_CONTAINER > 350
        },
        onToolbarPreparing: function (e) {
            var container = e.component;
            e.toolbarOptions.items.unshift(
                {
                    location: "after",
                    widget: "dxButton",
                    options: {
                        icon: "refresh",
                        tylingMode: "filled",
                        type: "default",
                        onClick: () => container.refresh()
                    },

                },

            )
        },
        onInitNewRow: (e) => {
            e.data.isActive = true;
            e.data.isVisible = true;
        },
        onRowUpdating: (e) => {
            console.log(e);
        },
        onCellPrepared: (e) => {

        },
        onRowDblClick: function (e) {
            var container = e.component;
        },
        selection: {
            mode: "single"
        },
        onContentReady: (e) => {

        },
        onSelectionChanged: (e) => {

        },
        onCellClick: function (e) {

        },
        columns: [
            {
                dataField: "warehouseStorageId",
                allowFiltering: true,
                caption: "Kho",
                width: "250",
                dataType: "string",
                alignment: "center",
                readOnly: true,
                allowEditing: false,
                lookup: {
                    dataSource: customStore_WarehouseStorageList,
                    valueExpr: "id",
                    displayExpr: "title",
                },
            },// code
            {
                dataField: "categoryGoodsId",
                allowFiltering: true,
                caption: "Hàng hóa",
                width: "250",
                dataType: "string",
                alignment: "center",
                readOnly: true,
                allowEditing: false,
                lookup: {
                    dataSource: customStore_CategoryGoods,
                    valueExpr: "id",
                    displayExpr: "title",
                },
            },// code
            {
                dataField: "quantity",
                allowFiltering: true,
                caption: "Tồn kho",
                dataType: "number",
                alignment: "center",
                readOnly: true,
                allowEditing: false,
            },// code

        ],
        editing: {
            allowAdding: false,
            allowUpdating: false,
            allowDeleting: false,
            mode: "batch",
            useIcons: true,
            confirmDelete: true,
            popup: {
                width: "50%",
                height: "50%",
                showTitle: true,
                title: "kế hoạch công việc",
                closeOnOutsideClick: false,
                showCloseButton: true,
            },
            form: {
                labelLocation: "left",
                itemType: "group",
                colCount: 12,
                showRequiredMark: true,
                requiredMark: "(*)",
                items: [
                    {
                        colSpan: 3,
                        dataField: "name",
                        label: { text: "Mã " },
                        editorOptions: {
                            stylingMode: "filled",
                            placeholder: "Vui lòng nhập...",
                        },
                    },
                ],
            },
        },
    });
}