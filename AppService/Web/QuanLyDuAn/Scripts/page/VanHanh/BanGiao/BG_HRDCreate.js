$(document).ready(function () {
    load_form_HandOverReceiptDetail();
    function load_form_HandOverReceiptDetail() {
        $("#form-HandOverReceiptDetail").dxForm({
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
                                readOnly: false,
                                displayExpr: 'code',
                                elementAttr: {
                                    id: "elementFromHandOverReceiptId",
                                },
                                onValueChanged: function (e) {
                                    var selTarget = $('#elementHandOverItemId').dxSelectBox('instance');
                                    selTarget.option('value', null);
                                    selTarget.option('dataSource', null);
                                    if (e.value > 0) {
                                        customStore_HandOverReceiptDetail(e.value).store().load({ filter: [["handOverReceiptId", "=", e.value]] }).done((rs) => {
                                            if (rs.length > 0) {
                                                var listItem = rs.map(a => a.handOverItemId);
                                                var listItemDetail = [];
                                                listItem.forEach(element => {
                                                    customStore_HandOverItem(element).store().load({ filter:[["id", "=", element]]}).done((rsItemDetail) => {
                                                        rsItemDetail.forEach(elementsub => {
                                                            listItemDetail.push(elementsub);
                                                        });
                                                    });
                                                });
                                            }
                                            console.log(listItemDetail);
                                            selTarget.option("dataSource", listItemDetail);
                                        });
                                    }
                                    else {
                                        customStore_HandOverItem_All().store().load().done((rsItemDetail) => {
                                            selTarget.option("dataSource", rsItemDetail);
                                        });

                                    }
                                }
                            },
                        },
                        {
                            colSpan: 4,
                            dataField: "handOverItemId",
                            label: { text: "Tên hàng hóa" },
                            editorType: "dxSelectBox",
                            type: "string",
                            lookup: {
                                dataSource: customStore_HandOverItem_All(),
                                valueExpr: "id",
                                displayExpr: "title",
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
                                displayExpr: 'title',
                                elementAttr: {
                                    id: "elementHandOverItemId",
                                },
                                onValueChanged: function (e) {
                                    var selTarget = $('#elementTotalItemId').dxTextBox('instance');
                                    var receiptId = $('#elementFromHandOverReceiptId').dxSelectBox('instance').option('value');
                                    selTarget.option('value', null);
                                    if (receiptId > 0) {
                                        if (e.value > 0) {
                                            var $total = 0;
                                            customStore_HandOverReceiptDetail_ReceiptItem(receiptId, e.value).load().done((rs) => {
                                                rs.forEach(element => {
                                                    $total += element.quantity;
                                                    console.log($total);
                                                });
                                                console.log($total);
                                                customStore_HandOverReceiptDetail_FormReceiptItem(receiptId, e.value).load().done((rsSub) => {
                                                    rsSub.forEach(element => {
                                                        console.log(element);
                                                        console.log($total);
                                                        console.log(element.quantity);
                                                        $total = $total - element.quantity;
                                                        console.log($total);
                                                    });
                                                    console.log($total);
                                                    selTarget.option("value", $total);
                                                });

                                            });
                                        }
                                        else {
                                            selTarget.option("dataSource", customStore_HandOverItem_All());
                                        }
                                    }
                                }
                            },
                            //cellTemplate: (c, o) => {
                            //    console.log(o.value);
                            //    customStore_CategoryGoods_Id(o.value).load().then((rsGoods) => {
                            //        var item = rsGoods[0];
                            //        customStore_CategoryUnit.load().then((rsUnit) => {
                            //            var itemUnit = rsUnit.filter(x => x.id == item.unitId).shift();
                            //            if (typeof itemUnit !== "undefined") {
                            //                $("<span />").append(itemUnit.title).appendTo(c);
                            //            }
                            //        });
                            //    });
                            //},
                            validationRules: [{ type: "required" }],
                        },
                        {
                            colSpan: 1,
                            itemType: "button",
                            horizontalAlignment: "left",
                            disabled: false,
                            buttonOptions: {
                                icon: "fa fa-plus",
                                type: "default",
                                useSubmitBehavior: false,
                                elementAttr: {
                                    id: "addHOItem",
                                },
                                editorOptions: {
                                    stylingMode: "contained",
                                    cssClass: "bg-info",
                                },
                                onClick: function (e) {
                                    var containerE = $("#elementHandOverItemId").dxSelectBox("getDataSource");
                                    CALLPOPUPMULTI(
                                        "Thêm thiết bị, hàng hóa",
                                        "/VanHanh/BanGiao/_HRItemCreate",
                                        ($(window).width() > 767 ? "50%" : "80%"),
                                        containerE,
                                        "popup-sub"
                                    );
                                },
                            }
                        },
                        {
                            colSpan: 2,
                            dataField: "quantity",
                            label: { text: "Số lượng" },
                            editorType: "dxNumberBox",
                            type: "number",
                            editorOptions: {
                                stylingMode: "filled",
                            },
                            validationRules: [{
                                type: "required",
                            },
                            {
                                type: "async",
                                message: "Số lượng vượt tồn kho",
                                validationCallback: function (params) {

                                    var selTarget = $('#elementTotalItemId').dxTextBox('instance').option('value');

                                    var d = $.Deferred();
                                    if (selTarget > 0 && selTarget < params.value) {
                                        d.resolve(false);
                                    }
                                    else {
                                        d.resolve(true);
                                    }

                                    return d.promise();
                                }
                            }],
                        },
                        {
                            colSpan: 2,
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
                                readOnly: true,
                                elementAttr: {
                                    id: "elementTotalItemId",
                                },
                                onValueChanged: function (data) {
                                    $WarehouseStorageID = data.value;
                                }
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
                            itemType: "group",
                            name: "button-action",
                            colCount: 12,
                            colSpan: 12,
                            items: [
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
                            ],

                        },
                    ]
                },

            ],
        }).dxForm("instance");
    }
    $("#form-HandOverReceiptDetail").on("submit", function (e) {
        e.preventDefault();
        var formdata = $('#form-HandOverReceiptDetail').dxForm("instance").option('formData');
        var resValid = true
        if (!resValid) {
            DevExpress.ui.notify("Vui lòng kiểm tra lại file đính kèm!", "error", 3000);
        }
        else {
            loadingPanel.show();
            formdata["handOverReceiptId"] = $model;
            formdata["status"] = 1;
            var deferred = $.Deferred();
            customStore_HandOverReceiptDetail(0).store().insert(formdata).done((rs) => {
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
    $(document).on('click', '#addHOItem', '#form-HandOverReceiptDetail', function (e) {

    });
});