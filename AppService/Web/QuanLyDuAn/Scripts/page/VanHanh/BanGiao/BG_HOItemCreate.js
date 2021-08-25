
$(document).ready(function () {
    load_form();
    function load_form() {
        $("#form-HandOverItem").dxForm({
            //formData: formdata,
            labelLocation: "top",
            items: [
                {
                    itemType: "group",
                    colCount: 12,
                    items: [
                        {
                            colSpan: 3,
                            dataField: "fromHandOverReceiptId",
                            label: { text: "Từ đơn tiếp nhận" },
                            editorType: "dxSelectBox",
                            type: "string",
                            editorOptions: {
                                stylingMode: "filled",
                                searchEnabled: true,
                                searchMode: "contains",
                                searchExpr: ['title', 'code'],
                                showClearButton: true,
                                placeholder: "Vui lòng chọn...",
                                dataSource: customStore_Receiver(),
                                valueExpr: "id",
                                readOnly:false,
                                displayExpr: 'code',
                                elementAttr: {
                                    id: "elementFromHandOverReceiptId",
                                },
                                onValueChanged: function (e) {
                                    var selTarget = $('#elementHandOverItemId').dxSelectBox('instance');
                                    selTarget.option('value', null);
                                    if (e.value > 0) {
                                        customStore_ById(e.value).store().load().done((rs) => {
                                            console.log(rs);
                                            if (rs.leght > 0) {
                                                rs.each(function (item) {
                                                    console.log(item);
                                                });
                                                selTarget.option("dataSource", customStore_ById(e.value));
                                            }
                                        });
                                       
                                    }
                                    else {
                                        selTarget.option("dataSource", customStore_HandOverItem_All());
                                    }
                                }
                            },
                            validationRules: [{ type: "required" }],
                        },
                        {
                            colSpan: 3,
                            dataField: "handOverItemId",
                            label: { text: "Tên hàng hóa" },
                            editorType: "dxSelectBox",
                            type: "string",
                            lookup: {
                                dataSource: customStore_HandOverItem_All(),
                                valueExpr: "id",
                                displayExpr: "code",
                            },
                            editorOptions: {
                                stylingMode: "filled",
                                searchEnabled: true,
                                searchMode: "contains",
                                searchExpr: ['title', 'code'],
                                showClearButton: true,
                                placeholder: "Vui lòng chọn...",
                                dataSource: customStore_HandOverItem_All(),
                                valueExpr: "id",
                                readOnly: false,
                                displayExpr: 'code',
                                elementAttr: {
                                    id: "elementHandOverItemId",
                                },
                                onValueChanged: function (data) {
                                    $WarehouseStorageID = data.value;
                                }
                            },
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
                            validationRules: [{ type: "required" }],
                        },
                        {
                            colSpan: 3,
                            label: { text: "Tồn" },
                            editorType: "dxTextBox",
                            type: "string",
                            lookup: {
                                dataSource: customStore_HandOverItem(0),
                                valueExpr: "id",
                                displayExpr: "code",
                            },
                            editorOptions: {
                                stylingMode: "filled",
                                readOnly:true,
                                elementAttr: {
                                    id: "elementTotalItemId",
                                },
                                onValueChanged: function (data) {
                                    $WarehouseStorageID = data.value;
                                }
                            },
                        },
                        {
                            colSpan: 3,
                            dataField: "quantity",
                            label: { text: "Số lượng" },
                            editorType: "dxNumberBox",
                            type: "number",
                            editorOptions: {
                                stylingMode: "filled",
                            },
                        },
                        {
                            colSpan: 12,
                            dataField: "description",
                            label: { text: "Mô tả" },
                            editorType: "dxTextArea",
                            editorOptions: {
                                stylingMode: "filled",
                                height: 90,
                            },
                            type: "string",
                        },
                        {
                            colSpan: 12,
                            itemType: "button",
                            horizontalAlignment: "center",
                            disabled: id == 0,
                            buttonOptions: {
                                text: "Thêm hàng hóa",
                                icon: "fa fa-save",
                                type: "success",
                                useSubmitBehavior: true,
                                elementAttr: {
                                    id: "addHRD",
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
    }
    $("#form-HandOverItem").on("submit", function (e) {
        e.preventDefault();
        var formdata = $('#form-HandOverItem').dxForm("instance").option('formData');
        var resValid = true
        if (!resValid) {
            DevExpress.ui.notify("Vui lòng kiểm tra lại file đính kèm!", "error", 3000);
        }
        else {
            loadingPanel.show();
            formdata["HandOverReceiptId"] = $model;
            formdata["status"] = 1;
            var deferred = $.Deferred();
            customStore_WarehouseReleasedDetail(0).store().insert(formdata).done((rs) => {
                loadingPanel.hide();
                if (rs.isOk) {
                    deferred.resolve(rs);
                    $("#HandOverReceiptDetail").dxDataGrid("instance").refresh();
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
});