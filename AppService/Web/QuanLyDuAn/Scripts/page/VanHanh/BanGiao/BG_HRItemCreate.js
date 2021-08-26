$(document).ready(function () {
    load_form_HandOverItem();
    function load_form_HandOverItem() {
        $("#form-HandOverItem").dxDataGrid({
            height: heightScreen,
            dataSource: customStore_HandOverItem_All(),
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
                            stylingMode: "filled",
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
            onCellClick: function (e) {
            },
            columns: [
                {
                    dataField: "title",
                    allowFiltering: true,
                    allowEdit: false,
                    caption: "Tiêu đề",
                    dataType: "string",
                    alignment: "center",
                },// SignCode
                {
                    dataField: "description",
                    allowFiltering: true,
                    caption: "Mô tả",
                    dataType: "string",
                    alignment: "center",
                },// firstName
                {
                    dataField: "categoryUnitId",
                    allowFiltering: true,
                    caption: "Đơn vị",
                    dataType: "string",
                    alignment: "center",
                    lookup: {
                        dataSource: customStore_CategoryUnit,
                        valueExpr: "id",
                        displayExpr: "title",
                    },
                    editorType: "dxSelectBox",
                },// LastName
            ],
            editing: {
                allowAdding: true,
                allowUpdating: true,
                allowDeleting: true,
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
            },
            masterDetail: {
                autoExpandAll: false,
                component: null,
                enabled: true,
                render: null,
                template: function (container, options) {
                    $("<div>")
                        .dxTreeList({
                            dataSource: customStore_HandOverItemSpecifications(options.data.id),
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
                            onToolbarPreparing: function (e) {
                                var container = e.component;
                                e.toolbarOptions.items.unshift(
                                    {
                                        location: "after",
                                        widget: "dxButton",
                                        options: {
                                            icon: "refresh",
                                            stylingMode: "filled",
                                            type: "default",
                                            onClick: () => container.refresh()
                                        }
                                    })
                            },
                            onInitNewRow: (e) => {
                                e.data.isActive = true;
                                e.data.isVisible = true;
                                e.data.handOverItemId = options.data.id;
                                console.log(options.data.id);
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
                                    },
                                    editorType: "dxSelectBox",
                                    //editorOptions: {
                                    //    stylingMode: "filled",
                                    //    searchEnabled: true,
                                    //    searchMode: "contains",
                                    //    searchExpr: ['title', 'code'],
                                    //    showClearButton: true,
                                    //    placeholder: "Vui lòng chọn...",
                                    //    dataSource: customStore_CategoryUnit(),
                                    //    valueExpr: "id",
                                    //    readOnly: false,
                                    //    displayExpr: 'title',
                                    //    elementAttr: {
                                    //        id: "elementHOItemCategoryUnitIdId",
                                    //    },
                                    //    onValueChanged: function (data) {

                                    //    }
                                    //},
                                },
                            ],
                            editing: {
                                allowAdding: true,
                                allowUpdating: true,
                                allowDeleting: true,
                                mode: "batch",
                                useIcons: true,
                                confirmDelete: true,
                            },
                        })
                        .attr("style", "margin:auto; width:90%")
                        .appendTo(container);;
                }
            },
        }).dxDataGrid("instance");
    }
});