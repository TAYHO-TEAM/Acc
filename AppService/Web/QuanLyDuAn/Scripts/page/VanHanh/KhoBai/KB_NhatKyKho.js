$(document).ready(function () {

    //..........................  Load View -------------------------------------------------------------
    $(function () {
        loadData_popup($id);
    });
    var loadData_popup = (id) => {
        $("#container_popup").dxDataGrid({
            height: heightScreen,
            dataSource: customStore_WarehouseReleased_WHSId($WarehouseStorageID),
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
                    column: "id",
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
                            icon: "refresh", tylingMode: "filled", type: "default",
                            onClick: () => container.refresh()
                        },

                    },
                )
            },
            onInitNewRow: (e) => {
            },
            onRowUpdating: (e) => {
            },
            onRowDblClick: function (e) {
                var container = e.component;
            },
            selection: {
                mode: "single"
            },
            onSelectionChanged: (e) => {
                var container = e.component;
            },
            columns: [
                {
                    dataField: "code",
                    allowFiltering: true,
                    caption: "Mã đơn",
                    dataType: "string",
                    alignment: "center",
                    readOnly: true,
                    allowEditing: false,
                },
                {
                    dataField: "description",
                    allowFiltering: true,
                    caption: "Mô tả",
                    dataType: "number",
                    alignment: "center",
                },
                {
                    dataField: "transporter",
                    allowFiltering: false,
                    caption: "Người giao/nhận",
                    dataType: "string",
                    alignment: "center",
                },
                {
                    dataField: "phoneContact",
                    allowFiltering: false,
                    caption: "Số ĐT",
                    dataType: "string",
                    alignment: "center",
                },
                {
                    dataField: "createDate",
                    allowFiltering: false,
                    caption: "Ngày tạo",
                    dataType: "datetime",
                    alignment: "center",
                },
                {
                    dataField: "isInOrOut",
                    allowFiltering: true,
                    caption: "Xuất/Nhập",
                    dataType: "string",
                    alignment: "center",
                    lookup: {
                        dataSource: listIsInOrOutStatus,
                        valueExpr: "value", displayExpr: "text",
                    },
                    cellTemplate: (c, o) => {
                        $("<span />").addClass("badge badge-" + listIsInOrOutStatus.find(x => x.value == o.value).color).append(
                            $("<i />").addClass("mr-1 " + listIsInOrOutStatus.find(x => x.value == o.value).icon), o.text
                        ).appendTo(c);
                    }
                }, 
                {
                    dataField: "status",
                    allowFiltering: true,
                    caption: "Trạng thái",
                    dataType: "string",
                    alignment: "center",
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
                {
                    type: "buttons",
                    width: 110,
                    alignment: "right",
                    buttons: [
                        {
                            icon: "info",
                            visible: function (e) {
                                return true;
                            },
                            onClick: function (e) {
                              
                            }
                        },
                        {
                            icon: "download",
                            visible: function (e) {
                                return true;
                            },
                            onClick: function (e) {
                                var containerE = e.component;
                                console.log(e);
                                var fdata = new FormData();
                                var obj = {};
                                obj[("@Id")] = e.row.data.id;
                                fdata.append("key", 6);
                                fdata.append("values", JSON.stringify(obj));

                                downloadFromAjaxPost("https://api-om-crud.tayho.com.vn/api/v1/Report", fdata);
                            }
                        },
                    ]
                }
            ],
            editing: {
                allowAdding: false,
                allowUpdating: false,
                allowDeleting: false,
                mode: "rown",
                useIcons: true,
                confirmDelete: true,
                popup: {
                    width: "30%",
                    height: "45%",
                    showTitle: true,
                    title: "Thêm căn hộ mới",
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
                            colSpan: 12,
                            dataField: "code",
                            label: { text: "Mã cắn hộ" },
                        },
                        {
                            colSpan: 12,
                            dataField: "address",
                            label: { text: "Địa chỉ" },
                            editorOptions: {
                                stylingMode: "filled",
                                placeholder: "Vui lòng nhập...",
                            },
                        },
                        {
                            colSpan: 12,
                            dataField: "isActive",
                            label: { text: "Trạng thái" },
                            editorType: "dxSwitch",
                            editorOptions: {
                                dataSource: listActiveStatus,
                                valueExpr: "value",
                                displayExpr: "text",
                            },
                        },
                    ],
                },
            },
        });
    };
});