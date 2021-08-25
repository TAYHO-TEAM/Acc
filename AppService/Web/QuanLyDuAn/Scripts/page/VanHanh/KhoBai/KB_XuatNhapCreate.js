var formData = {
    "warehouseStorageId": "",
    "categoryGoodsId": "",
    "quantity": "",
    "code": "",
    "barcode": "",
    "title": "",
    "description": "",
    "checkInDate": "",
    "checkOutDate": "",
    "checkInBy": "",
    "checkOutBy": "",
    "isInOrOut": "",
    "priority": "",
    "transporterId": "",
    "transporter": "",
    "phoneContact": ""
};
var $WarehouseReleasedId = 0;
var fdata = new FormData();
$(document).ready(function () {
    customStore_WarehouseReleased($isIn).load().done((rs) => {
        if (rs.length !== 0) {
            $WarehouseReleasedId = rs[0].id;
        }
        $("#form-warehousereleased").dxForm({
            formData: rs[0],
            labelLocation: "top",
            items: [
                {
                    itemType: "group",
                    colCount: 12,
                    items: [
                        {
                            colSpan: 4,
                            dataField: "warehouseStorageId",
                            label: { text: "Kho" },
                            editorType: "dxSelectBox",
                            type: "string",
                            lookup: {
                                dataSource: customStore_WarehouseStorage(WarehouseStorageID),
                                valueExpr: "id",
                                displayExpr: "title",
                            },
                            editorOptions: {
                                stylingMode: "filled",
                                searchEnabled: true,
                                searchMode: "contains",
                                searchExpr: ['title', 'description'],
                                showClearButton: true,
                                placeholder: "Vui lòng chọn...",
                                dataSource: customStore_WarehouseStorage(WarehouseStorageID),
                                value: $model,
                                valueExpr: "id",
                                readOnly: $WarehouseReleasedId > 0 ? true : false,
                                displayExpr: 'title',
                                elementAttr: {
                                    id: "elementwarehouseStorageId",
                                },
                                onValueChanged: function (data) {
                                    $WarehouseStorageID = data.value;
                                }
                            },
                            validationRules: [{ type: "required" }],
                        },
                        //{
                        //    colSpan: 4,
                        //    dataField: "transporterId",
                        //    label: { text: $isIn ?  "Mã người gửi" :"Mã người nhận"},
                        //    editorType: "dxSelectBox",
                        //    type: "string",
                        //    visible: true ,
                        //    editorOptions: {
                        //        stylingMode: "filled",
                        //        placeholder: "Vui lòng chọn...",
                        //    },
                        //},
                        {
                            colSpan: 4,
                            dataField: "transporter",
                            label: { text: $isIn ? "Người gửi" : "Người nhận" },
                            editorType: "dxTextBox",
                            visible: true,
                            type: "string",
                            editorOptions: {
                                readOnly: $WarehouseReleasedId > 0 ? true : false,
                                stylingMode: "filled",
                                placeholder: "Vui lòng nhập tên...",
                                elementAttr: {
                                    id: "elementTransporterWHR",
                                },
                            },
                            validationRules: [{ type: "required" }],
                        },
                        {
                            colSpan: 4,
                            dataField: "phoneContact",
                            label: { text: "Số ĐT Liên Lạc" },
                            editorType: "dxTextBox",
                            type: "string",
                            visible: true,
                            editorOptions: {
                                readOnly: $WarehouseReleasedId > 0 ? true : false,
                                stylingMode: "filled",
                                placeholder: "Vui lòng nhập số điện thoại...",
                                elementAttr: {
                                    id: "elementPhoneContactWHR",
                                },
                            },
                            validationRules: [{ type: "required" }],
                        },
                        {
                            colSpan: 12,
                            dataField: "description",
                            label: { text: "Ghi chú" },
                            editorType: "dxTextBox",
                            editorOptions: {
                                readOnly: $WarehouseReleasedId > 0 ? true : false,
                                stylingMode: "filled",
                                placeholder: "Vui lòng nhập...",
                                elementAttr: {
                                    id: "elementDescriptionWHR",
                                },
                            },
                        },
                        {
                            colSpan: 12,
                            itemType: "button",
                            horizontalAlignment: "center",
                            buttonOptions: {
                                text: $isIn ? "Tạo phiếu nhập" : "Tạo phiếu xuất",
                                icon: "fa fa-save",
                                type: "success",
                                visible: $WarehouseReleasedId > 0 ? false : true,
                                useSubmitBehavior: true,
                                elementAttr: {
                                    id: "export",
                                },
                                editorOptions: {
                                    stylingMode: "filled",
                                }
                            }
                        },
                    ]
                },

            ],
        }).dxForm("instance");
        if ($WarehouseReleasedId > 0) {
            document.getElementById('elementwarehouseStorageId').style.display = 'block';
            document.getElementById('elementTransporterWHR').style.display = 'block';
            document.getElementById('elementPhoneContactWHR').style.display = 'block';
            document.getElementById('elementDescriptionWHR').style.display = 'block';
            document.getElementById('export').style.pointerEvents = 'none';
            document.getElementById('export').style.visibility = 'hidden';
            load_WarehouseReleasedDetail($WarehouseReleasedId ?? 0);
        }
    });

    $("#form-warehousereleased").on("submit", function (e) {
        e.preventDefault();
        var resValid = true
        if (!resValid) {
            DevExpress.ui.notify("Vui lòng kiểm tra lại file đính kèm!", "error", 3000);
        }
        else {
            loadingPanel.show();
            var formdata = $('#form-warehousereleased').dxForm("instance").option('formData');
            formdata["IsInOrOut"] = $isIn;
            formdata["Status"] = 10;
            var deferred = $.Deferred();
            customStore_WarehouseReleased(0).store().insert(formdata).done((rs) => {
                loadingPanel.hide();
                if (rs.isOk) {
                    console.log(rs.result.id)
                    $WarehouseReleasedId = parseInt(rs.result.id);
                    deferred.resolve(rs);
                    document.getElementById('elementwarehouseStorageId').style.display = 'block';
                    document.getElementById('elementTransporterWHR').style.display = 'block';
                    document.getElementById('elementPhoneContactWHR').style.display = 'block';
                    document.getElementById('elementDescriptionWHR').style.display = 'block';
                    document.getElementById('export').style.pointerEvents = 'none';
                    document.getElementById('export').style.visibility = 'hidden';
                    load_WarehouseReleasedDetail($WarehouseReleasedId ?? 0);
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
    function load_WarehouseReleasedDetail(ItemID) {
        $("#container-warehousereleaseddetail").dxDataGrid({
            height: 300,
            dataSource: customStore_WarehouseReleasedDetail(ItemID),
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
                e.data.WarehouseReleasedId = ItemID;
                e.data.warehouseStorageId = WarehouseStorageID;
                e.data.isActive = true;
                e.data.isVisible = true;
            },
            onRowUpdating: (e) => {
                e.newData['isVisible'] = e.newData['pmIsVisible'];
                e.newData['id'] = e.oldData['id'];
            },
            onRowDblClick: function (e) {
                var container = e.component;
            },
            selection: {
                mode: "single"
            },
            columns: [
                {
                    dataField: "categoryGoodsId",
                    allowFiltering: true,
                    caption: "Loại hàng hóa",
                    dataType: "string",
                    alignment: "center",
                    visible: true,
                    lookup: {
                        dataSource: customStore_CategoryGoods,
                        valueExpr: "id",
                        displayExpr: "title",
                    },
                },// code
                {
                    dataField: "quantity",
                    allowFiltering: true,
                    caption: "Số lượng",
                    dataType: "string",
                    alignment: "center",
                    visible: true,
                },// code
                {
                    dataField: "categoryGoodsId",
                    allowFiltering: true,
                    caption: "Đơn vị",
                    dataType: "string",
                    alignment: "center",
                    visible: true,
                    //lookup: {
                    //    dataSource: customStore_CategoryGoods,
                    //    valueExpr: "id",
                    //    displayExpr: "unitId",
                    //},
                    cellTemplate: (c, o) => {
                        console.log(o.value);
                        customStore_CategoryGoods_Id(o.value).load().then((rsGoods) => {
                            var item = rsGoods[0];
                            customStore_CategoryUnit.load().then((rsUnit) => {
                                var itemUnit = rsUnit.filter(x => x.id == item.unitId).shift();
                                if (typeof itemUnit !== "undefined") {
                                    $("<span />").append(itemUnit.title).appendTo(c);
                                }
                            });
                        });
                    },
                },// code
            ],
            editing: {
                //allowAdding: true,
                //allowUpdating: true,
                allowDeleting: true,
                mode: "batch",
                useIcons: true,
                confirmDelete: true,
            },
        }).dxDataGrid("instance");
        formSubInstance();
    };
    function formSubInstance() {
        $("#form-warehousereleaseddetail").dxForm({
            formData: formData,
            labelLocation: "top",
            items: [
                {
                    itemType: "group",
                    name: "input",
                    colCount: 12,
                    items: [
                        {
                            colSpan: 4,
                            dataField: "categoryGoodsId",
                            label: { text: "Loại hàng" },
                            type: "string",
                            editorType: "dxSelectBox",
                            lookup: {
                                dataSource: customStore_CategoryGoods,
                                valueExpr: "id",
                                displayExpr: "title",
                            },
                            editorOptions: {
                                stylingMode: "filled",
                                searchEnabled: true,
                                searchMode: "contains",
                                searchExpr: ['title', 'description'],
                                showClearButton: true,
                                placeholder: "Vui lòng chọn...",
                                dataSource: customStore_CategoryGoods,
                                valueExpr: "id",
                                displayExpr: 'title',
                                elementAttr: {
                                    id: "elementcategoryGoodsId",
                                },
                                onValueChanged: function (data) {
                                    $('#elementQuantity').dxNumberBox('instance').option('value', 0);
                                    customStore_CategoryGoods.load().then((rs) => {
                                        var goods = rs.filter(x => x.id === data.value).shift();
                                        customStore_CategoryUnit.load().then((rsUnit) => {
                                            var item = rsUnit.filter(x => x.id === goods.unitId).shift();
                                            $('#elementUnitItem').dxTextBox('instance')
                                                .option('value', item == null ? "" : (item.title));
                                        });
                                    });
                                    customStore($WarehouseStorageID).load().then((rsInventory) => {
                                        console.log($WarehouseStorageID);
                                        var item = rsInventory.filter(x => x.categoryGoodsId === data.value).shift();
                                        console.log(rsInventory);
                                        $('#elementInventory').dxTextBox('instance')
                                            .option('value', item == null ? 0 : (item.quantity));

                                    });
                                },
                            },
                            validationRules: [{ type: "required" }],
                        },
                        {
                            colSpan: 3,
                            dataField: "quantity",
                            label: { text: "Số lượng" },
                            editorType: "dxNumberBox",
                            type: "number",
                            editorOptions: {
                                elementAttr: {
                                    id: "elementQuantity",
                                },
                                stylingMode: "filled",
                                placeholder: "Vui lòng nhập số lượng...",
                            },
                            validationRules: [{
                                type: "required",
                            },
                            {
                                type: "async",
                                message: "Email is already registered",
                                validationCallback: function (params) {
                                    var $categoryGoodsId = $('#elementcategoryGoodsId').dxSelectBox("instance").option('value');
                                    console.log($categoryGoodsId);
                                    var d = $.Deferred();
                                    if (!$isIn) {
                                        customStore($WarehouseStorageID).load().then((rsInventory) => {
                                            var _item = rsInventory.find(x => x.categoryGoodsId == $categoryGoodsId);
                                            if (typeof _item !== 'undefined') {
                                                console.log(_item);
                                                var quantity = _item.quantity;
                                                console.log(quantity);
                                                if (quantity > 0) {
                                                    d.resolve(quantity >= params.value);
                                                }
                                                else {
                                                    d.resolve(false);
                                                }
                                            }
                                            else {
                                                d.resolve(false);
                                            }
                                        });
                                    }
                                    else {
                                        d.resolve(true);
                                    }

                                    return d.promise();
                                }
                            }],
                        },
                        {
                            colSpan: 3,
                            label: { text: "Đơn vị" },
                            editorType: "dxTextBox",
                            type: "string",
                            editorOptions: {
                                stylingMode: "filled",
                                readOnly: true,
                                elementAttr: {
                                    id: "elementUnitItem",
                                },
                            },
                        },
                        {
                            colSpan: 2,
                            label: { text: "Tồn kho" },
                            editorType: "dxTextBox",
                            type: "string",
                            editorOptions: {
                                stylingMode: "filled",
                                readOnly: true,
                                elementAttr: {
                                    id: "elementInventory",
                                },
                            },
                        },
                    ]
                },
                {
                    itemType: "group",
                    name: "button-action",
                    colCount: 12,
                    items: [
                        {
                            colSpan: 6,
                            itemType: "button",
                            horizontalAlignment: "right",
                            disabled: id == 0,
                            buttonOptions: {
                                text: "Thêm sản phẩm",
                                icon: "fa fa-save",
                                type: "success",
                                useSubmitBehavior: true,
                                elementAttr: {
                                    id: "addItem",
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
                            disabled: id == 0,
                            buttonOptions: {
                                text: $isIn? "Nhập kho": "Xuất kho",
                                icon: "fa fa-clipboard",
                                type: "default",
                                useSubmitBehavior: false,
                                elementAttr: {
                                    id: "resolveFinish",
                                },
                                editorOptions: {
                                    stylingMode: "contained",
                                    cssClass: "bg-info",
                                }
                            }
                        },
                    ],

                },
            ],
        }).dxForm("instance");
    };
    $("#form-warehousereleaseddetail").on("submit", function (e) {
        e.preventDefault();
        var formdata = $('#form-warehousereleaseddetail').dxForm("instance").option('formData');
        var resValid = true
        if (!resValid) {
            DevExpress.ui.notify("Vui lòng kiểm tra lại file đính kèm!", "error", 3000);
        }
        else {
            loadingPanel.show();
            formdata["WarehouseStorageId"] = $WarehouseStorageID;
            formdata["WarehouseReleasedId"] = $WarehouseReleasedId;
            formdata["status"] = 10;
            var deferred = $.Deferred();
            customStore_WarehouseReleasedDetail(0).store().insert(formdata).done((rs) => {
                loadingPanel.hide();
                if (rs.isOk) {
                    deferred.resolve(rs);
                    $("#container-warehousereleaseddetail").dxDataGrid("instance").refresh();
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
    $(document).on('click', '#resolveFinish', '#form-warehousereleaseddetail', function (e) {
        e.preventDefault();
        var resValid = true
        if (!resValid) {
            DevExpress.ui.notify("Vui lòng kiểm tra lại file đính kèm!", "error", 3000);
        }
        else {
            loadingPanel.show();
            var deferred = $.Deferred();
            var object = {};
            object["status"] = 200;
            if ($WarehouseReleasedId > 0) {
                customStore_WarehouseReleased(0).store().update($WarehouseReleasedId, object).done((rs) => {
                    loadingPanel.hide();
                    if (rs.isOk) {
                        $("#popup-main").dxPopup('instance').hide();
                        deferred.resolve(rs);
                        DevExpress.ui.notify("Cập nhật thành công", "success", 3000);
                    }
                    else {
                        DevExpress.ui.notify("Có lỗi xảy ra", "error", 3000);
                        deferred.resolve(false);
                    }
                }, deferred.reject)
            }
            return deferred.promise();
        }
    });
});
