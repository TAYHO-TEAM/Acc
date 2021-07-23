$(function () {

    var loadingPanel = $("#loading-panel").dxLoadPanel({
        shadingColor: "rgba(0,0,0,0.3)",
        visible: false, message: "Vui lòng chờ ...",
        showIndicator: true,
        showPane: true,
        shading: true,
        closeOnOutsideClick: false,
    }).dxLoadPanel("instance");

    var form = $("#loginForm").dxForm({
        formData: {
            "userName": "",
            "password": "",
            "deviceToken": "",
            "device": "",
            "browser":""
        },
        items: [
            {
                itemType: "group", colCount: 12,
                items: [
                    {
                        colSpan: 12,
                        label: { text: "Tên đăng nhập" },
                        dataField: "userName",
                        editorType: "dxTextBox",
                        editorOptions: {
                            placeholder: "Tên đăng nhập ...", 
                        },
                        validationRules: [
                            {
                                type: "required",
                                message: "Vui lòng nhập thông tin"
                            }
                        ]
                    },
                    {
                        colSpan: 12,
                        label: { text: "Và mật khẩu" },
                        dataField: "password",
                        editorType: "dxTextBox",
                        editorOptions: {
                            placeholder: "Mật khẩu ...",
                            mode: "password",
                            elementAttr: {
                                id: "passwordEditor"
                            },
                            buttons: [
                                {
                                    name: "view-password",
                                    location: "after",
                                    options: {
                                        icon: "ti ti-eye",
                                        onClick: function () {
                                            var input_pass = $("#passwordEditor").dxTextBox("instance");
                                            input_pass.option("mode", input_pass.option("mode") === "text" ? "password" : "text");
                                        }
                                    }
                                }, 
                            ],
                        },
                        validationRules: [
                            {
                                type: "required",
                                message: "Vui lòng nhập thông tin"
                            }
                        ]
                    },
                    {
                        colSpan: 12,
                        itemType: "button",
                        horizontalAlignment: "right",
                        buttonOptions: {
                            text: "Đăng nhập",
                            icon: "fas fa-paper-plane",
                            type: "default",
                            useSubmitBehavior: true
                        }
                    }
                ]
            }
        ]
    }).dxForm("instance"); 

    $("#loginForm").on("submit", function (e) {
        e.preventDefault();
        loadingPanel.show();
        $.ajax({ 
            type: 'POST',
            url: URL_API_ACC_CMD + "/Account/Login",
            contentType: 'application/json',
            data: JSON.stringify(form.option("formData")),
        }).done(function (data) {
            loadingPanel.hide();
            if (data.isOk) {
                localStorage.setItem("userCurrent", form.option("formData").userName);
                localStorage.setItem("userCurrentInfo", JSON.stringify(data.result));
                window.location = getParamInUrl("url", window.location.href);
            }
        }).fail(function (jqXHR, textStatus) {
            loadingPanel.hide();
            var rs = JSON.parse(jqXHR.responseText);
            DevExpress.ui.notify(rs.errorMessages[0].errorMessage, "error", 3000);
        });
    });
});

function getParamInUrl(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}