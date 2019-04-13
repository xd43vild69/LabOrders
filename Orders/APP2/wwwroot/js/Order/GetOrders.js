
const urlRootApi = 'http://localhost:51224/api';
let msg = null;
let OrderPatientID = null;
let MODES_FORM = Object.freeze({ "PUT": 1, "POST": 2 });
let modeForm = 2;

$(function () {
    OrderSearch.View.InitView();
});

var OrderSearch = {
    View: {
        InitView() {
            console.log("Init OrderSearch");
            OrderSearch.View.EventsButtons();
            OrderSearch.View.formMode(MODES_FORM.POST);
        },
        EventsButtons() {
            $('#btnSearch').click(function () {
                OrderSearch.Services.getOrder($("#patient").val());
            });
            $('#btnSave').click(function () {
                OrderSearch.Controller.saveOrder();
            });
            $('#btnUpdate').click(function () {
                OrderSearch.Controller.putOrder();
            });
            $('#OrderModal').on('hidden.bs.modal', function (e) {
                OrderSearch.View.formMode(MODES_FORM.POST);
            })
        },
        gridList(data) {
            records = data;
            $("#jsGrid").jsGrid({
                width: "100%",
                height: "200px",
                inserting: false,
                editing: false,
                sorting: false,
                paging: false,
                data: records,
                fields: [

                    { name: "NameType", type: "text", width: 10, title: "Tipo Orden" },
                    { name: "Posology", type: "text", width: 10, title: "Posología" },
                    { name: "NameOrderPriority", type: "text", width: 5, title: "Prioridad" },
                    { name: "NameOrderState", type: "text", width: 10, title: "Estado" },
                    { name: "FirstName", type: "text", width: 5, title: "Nombre" },
                    { name: "MedicalHistory", type: "text", width: 10, title: "Historia Medica" },
                    {
                        headerTemplate: function () {

                        }
                        , itemTemplate: function (value, item) {
                            return $("<input>").prop("type", "button")
                                .val("Editar")
                                .addClass('btn btn-primary')
                                .click(function () {
                                    OrderSearch.Controller.editOrder(item);
                                });
                        },
                        width: 10
                    },

                ]
            });

        },
        cleanForm() {
            $("#Posology").val("");
            $("#patient").val("1");
            $("#OrderTypeID").val("1");
            $("#OrderStateID").val("1");
            $("#OrderPriorityID").val("1");
        },
        formMode(mode) {
            debugger;
            if (mode === MODES_FORM.PUT) {
                $("#OrderTypeID").prop('disabled', true);
                $("#Posology").prop('disabled', true);
                $("#OrderPriorityID").prop('disabled', true);
                $('#divJustification').css('visibility', 'visible');
                $('#btnSave').hide();
                $('#btnUpdate').show();                
                return;
            }
            if (mode === MODES_FORM.POST) {
                $("#OrderTypeID").prop('disabled', true);
                $("#Posology").prop('disabled', false);
                $("#OrderPriorityID").prop('disabled', false);
                $('#divJustification').css('visibility', 'hidden');
                $('#btnSave').show();
                $('#btnUpdate').hide();

                OrderSearch.View.cleanForm();
                return;
            }
        }
    },
    Controller: {
        okGet(data) {
            OrderSearch.View.gridList(data);
        },
        okPost() {
            OrderSearch.Services.getOrder($("#patient").val());
            $('#OrderModal').modal('toggle');
            OrderSearch.View.cleanForm();
            OrderSearch.Messages.okPost();
        },
        errorGet() {
            OrderSearch.Messages.errorGet();
        },
        errorPost() {
            OrderSearch.Messages.errorPost();
        },
        editOrder(item) {
            OrderSearch.View.formMode(MODES_FORM.PUT);
            OrderPatientID = item.OrderPatientID;
            $("#Posology").val(item.Posology);
            $("#OrderTypeID").val(item.OrderTypeID);
            $("#OrderStateID").val(item.OrderStateID);
            $("#OrderPriorityID").val(item.OrderPriorityID);
            $('#OrderModal').modal('show');
        },
        putOrder() {
            let entity = OrderSearch.Controller.createEntity(OrderPatientID);
            OrderSearch.Services.putOrder(entity);
        },
        saveOrder() {
            let newOrderPatientID = 0;
            let entity = OrderSearch.Controller.createEntity(newOrderPatientID);
            OrderSearch.Services.postOrder(entity);
        },
        createEntity(id) {
            let entity = {
                Posology: $("#Posology").val(),
                PatientID: $("#patient").val(),
                OrderTypeID: $("#OrderTypeID").val(),
                OrderStateID: $("#OrderStateID").val(),
                OrderPriorityID: $("#OrderPriorityID").val(),
                OrderPatientID: id
            };
            return JSON.stringify(entity);
        },
    },
    Services: {
        getOrder() {
            let urlRootApi = `/Order/${$("#patient").val()}`;
            OrderSearch.Services.callApi(urlRootApi, "GET", OrderSearch.Controller.okGet, OrderSearch.Controller.okGet, null);
        },
        postOrder(entity) {
            let urlRootApi = `/Order/`;
            OrderSearch.Services.callApi(urlRootApi, "POST", OrderSearch.Controller.okPost, OrderSearch.Controller.errorPost, entity);
        },
        putOrder(entity) {
            let urlRootApi = `/Order/`;
            OrderSearch.Services.callApi(urlRootApi, "PUT", OrderSearch.Controller.okPost, OrderSearch.Controller.errorPut, entity);
        },
        callApi: function (urlApi, typeCall, functionApi, functionErrorApi, entity) {
            $.ajax({
                url: urlRootApi + urlApi,
                type: typeCall,
                data: entity,
                contentType: 'application/json',
                dataType: 'json',
                success: function (data) {
                    functionApi(data);
                },
                error: function (data) {
                    functionErrorApi(data);
                }
            });
        }
    },
    Messages: {
        okPost() {
            msg = "Orden salvada exitosamente.";
            OrderSearch.Messages.callMessage();
        },
        errorGet() {
            msg = "Ocurrio un error en la consulta.";
            OrderSearch.Messages.callMessage();
        },
        errorPost() {
            msg = "Ocurrio un error guardando los datos.";
            OrderSearch.Messages.callMessage();
        },
        errorPut() {
            msg = "Ocurrio un error guardando los datos.";
            OrderSearch.Messages.callMessage();
        },
        validationForm() {
            msg = "La información ingresada no es valida.";
            OrderSearch.Messages.callMessage();
        },
        callMessage() {
            $.alert({
                title: 'Eureka!',
                content: msg,
            });
        }
    }
}