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
var formDataVerify = {
    "key": $model,
};
var $WarehouseReleasedId = 0;
var fdata = new FormData();
$(document).ready(function () {
    customStore_WarehouseReleased_Id($model).load().done((rs) => {
        if (rs.length !== 0) {
            $WarehouseReleasedId = rs[0].id;
        }
        $("#form-warehousereleased-verify").dxForm({
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
                            label: { text: "Người nhận" },
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
                    ]
                },

            ],
        }).dxForm("instance");
        if ($WarehouseReleasedId > 0) {
            document.getElementById('elementwarehouseStorageId').style.display = 'block';
            document.getElementById('elementTransporterWHR').style.display = 'block';
            document.getElementById('elementPhoneContactWHR').style.display = 'block';
            document.getElementById('elementDescriptionWHR').style.display = 'block';
            load_WarehouseReleasedDetail_verify($WarehouseReleasedId ?? 0);
        }
    });
    function load_WarehouseReleasedDetail_verify(ItemID) {
        $("#container-warehousereleaseddetail-verify").dxDataGrid({
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
                allowAdding: false,
                allowUpdating: false,
                allowDeleting: false,
                mode: "batch",
                useIcons: true,
                confirmDelete: true,
            },
        }).dxDataGrid("instance");
        formSubInstance();
        fileUploader();
    };
    function formSubInstance() {
        console.log($model);
        $("#form-warehousereleaseddetail-verify").dxForm({
            formData: formData,
            labelLocation: "top",
            items: [
                {
                    itemType: "group",
                    name: "input",
                    colCount: 12,
                    items: [
                        {
                            colSpan: 12,
                            itemType: "simple",
                            name: "Image",
                            editorType: 'dxGallery',
                            editorOptions: {
                                stylingMode: "filled",
                                dataSource: customStore_Attachment($model,"WarehouseReleased"),
                                height: 100,
                                width: 'auto',
                                slideshowDelay: 1500,
                                itemTemplate: function (data) {
                                    var $link = (data.host + data.url + "/" + data.fileName);
                                    return $("<a/>").attr("href", $link).attr("target", "_blank").append($("<img />").attr({ "src": $link, onerror: ImgError(this), "style": "max-height: 100px; height : auto ;width : auto ;margin: auto;" })) ;
                                },
                                onItemClick: function (value) {
                                }
                            },
                        },
                        {
                            colSpan: 12,
                            visible: true,//rs[0].status??0 < 200 ? true : false,
                            template: '<span class="dx-field-item-label-text font-bold">Các tập tin đính kèm</span><div class="file-uploader" id="file-uploader"></div>' ,
                        },
                        {
                            colSpan: 12,
                            itemType: "button",
                            horizontalAlignment: "center",
                            buttonOptions: {
                                text:"Xác nhận hình ảnh",
                                icon: "fa fa-save",
                                type: "success",
                                visible:  true,
                                useSubmitBehavior: true,
                                elementAttr: {
                                    id: "verify",
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
    };
    $("#form-warehousereleaseddetail-verify").on("submit", function (e) {
        e.preventDefault();
        var fData = new FormData();
        var resValid = true
        var files = $("#file-uploader").dxFileUploader("instance").option("value");
        fData.append('key', $model);
        fData.append('token', UserCurrentInfo.accessToken);
        if (files.length > 0) {
            $.each(files, function (key, value) {
                fData.append(files[key].name, files[key]);
            });
        }
        else {
            resValid = false;
        }
        if (!resValid) {
            DevExpress.ui.notify("Vui lòng kiểm tra lại file đính kèm!", "error", 3000);
        }
        else {
            loadingPanel.show();
            var deferred = $.Deferred();
            $.ajax({
                type: "POST",
                enctype: 'multipart/form-data',
                url: "/VanHanh/KhoBai/_XuatNhapVerify",
                data: fData,
                processData: false,
                contentType: false,
                cache: false,
                timeout: 600000,
                success: function (rs) {
                    loadingPanel.hide();
                    DevExpress.ui.notify(rs.result, rs.status, 3000);
                    $("#popup-sub").dxPopup("hide");
                },
                error: function (xhr, textStatus, errorThrown) {
                    loadingPanel.hide();
                    DevExpress.ui.notify("Vui lòng chọn File!", "error", 3000);

                }
            });
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
