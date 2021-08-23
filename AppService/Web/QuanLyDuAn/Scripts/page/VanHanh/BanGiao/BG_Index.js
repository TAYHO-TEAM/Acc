var id = 1;
var $WHId = 0;
//----------------------------- READ -------------------------------------------------------------

var ACTION_HANDOVERRECEIPT = "HandOverReceipt/";
var ACTION_HANDOVERRECEIPTDETAIL = "HandOverReceiptDetail/";
var ACTION_HANDOVERITEM = "HandOverItem/";
var ACTION_HANDOVERITEMSPECIFICATIONS = "HandOverItemSpecifications/";
var ACTION_CATEGORYGOODS = "CategoryGoods/";
var ACTION_FILESATTACHMENT = "FilesAttachment/";
var KEY = "id";
var WIDTH_CONTAINER = $("#container").width();

//----------------------------------- Get data ----------------------------------------------------
var customStore = () => new DevExpress.data.DataSource({
    store: $DATASOURCEGET(ACTION_WAREHOUSEALLGOODS, KEY),
    filter: ["WarehouseStorageId", "=", id]
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
    $("#container").dxTreeList({
        dataSource: customStore(),
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