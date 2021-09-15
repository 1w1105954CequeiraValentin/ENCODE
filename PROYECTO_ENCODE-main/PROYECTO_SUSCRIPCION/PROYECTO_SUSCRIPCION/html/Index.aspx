<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PROYECTO_SUSCRIPCION.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <!-- Bootstrap CSS -->
    <link
        rel="stylesheet"
        href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" />
    <!-- Optional JavaScript; choose one of the two! -->

    <!-- Option 1: jQuery and Bootstrap Bundle (includes Popper) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script
        src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js"></script>
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.0/jquery.validate.min.js"></script>--%>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.1/jquery.validate.min.js"></script>

    <%--<script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>--%>
    <link href="../css/Estilos.css" rel="stylesheet" />
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script>
        function MsjNoSeEncontroSuscriptor() {
            swal("Error", "No se encontro el suscriptor", "error");
        }
        function MsjSuscripcionRegistrada() {
            swal("Registro exitoso", "Se registro la suscripcion", "success")
        }
        function MsjIngreseTipoYNroDocumento() {
            swal("Error", "Ingrese Tipo y Nro de Documento", "error")
        }
        function MsjSucriptorRegistrado() {
            swal("Registro exitoso", "Se registro el suscriptor","success")
        }
        function MsjSuscriptorModificado() {
            swal("Modificación exitosa", "Se modificó el suscriptor", "success")
        }
        function MsjDebeIngresarTodosLosDatos() {
            swal("Error", "Debe ingresar todos los datos", "error")
        }
        function MsjTieneSuscripcion() {
            swal("Alerta", "El Suscriptor ya tiene Suscripcion", "warning")
        }
        function MensajeValidacion() {
            swal("Alerta", "Debe ingresar todos los campos", "warning")
        }
        

        function Validaciones() {
            $("#formSuscripcion").validate({
                rules: {
                    cboTipoDoc: {
                        required: true
                    },
                    txtNroDocumento: {
                        required: true,
                        minlength: 7,
                        maxlenght: 8,
                        digits: true
                    },
                    txtNombre: {
                        required: true,
                        digits: false,
                        minlength: 3,
                        maxlenght: 12
                    },
                    txtApellido: {
                        required: true,
                        digits: false,
                        minlength: 3,
                        maxlenght: 12
                    },
                    txtDireccion: {
                        required: true,
                        number: false,
                        minlenght: 4,
                        maxlenght: 20
                    },
                    txtEmail: {
                        required: true,
                        email: true
                    },
                    txtTelefono: {
                        required: true,
                        number: false,
                        digits: true,
                        minlength: 7,
                        maxlenght: 20
                    },
                    txtNombreUsuario: {
                        required: true,
                        number: false,
                        minlenght: 4,
                        maxlenght: 15
                    },
                    txtContrasena: {
                        required: true,
                        minlength: 4,
                        maxlenght: 15
                    }
                },
                messages: {
                    cboTipoDoc: {
                        required: "Debe seleccionar tipo de doc"
                    },
                    txtNroDocumento: {
                        required: "Debe ingresar documento",
                        minlength: "Debe ingresar al menos 7 digitos",
                        maxlenght: "Debe ingresar como máximo 8 digitos",
                        digits: "Debe ingresar solo digitos"
                    },
                    txtNombre: {
                        required: "Ingrese nombre",
                        number: "Ingrese solo letras",
                        minlenght: "Debe ingresar un mínimo de 3 caracteres",
                        maxlenght: "Debe ingresar un máximo de 12 caracteres"
                    },
                    txtApellido: {
                        required: "Ingrese Apellido",
                        digits: "Ingrese solo letras",
                        minlength: "Debe ingresar un mínimo de 3 caracteres",
                        maxlenght: "Debe ingresar un máximo de 12 caracteres"
                    },
                    txtDireccion: {
                        required: "Ingrese dirección",
                        number: "No se permiten números decimales",
                        minlenght: "Debe ingresar un mínimo de 4 caracteres",
                        maxlenght: "Debe ingresar un máximo de 20 caracteres"
                    },
                    txtEmail: {
                        required: "Ingrese email",
                        email: "El email debe tener formato: abc@dominio.com"
                    },
                    txtTelefono: {
                        required: "Ingresar Telefono",
                        number: "No se permiten números decimales",
                        digits: "Debe ingresar solo números",
                        minlength: "Debe ingresar un mínimo de 7 números",
                        maxlenght: "Debe ingresar un máximo de 20 números"
                    },
                    txtNombreUsuario: {
                        required: "Ingresar nombre usuario",
                        number: "No se permiten números decimales",
                        minlenght: "Debe ingresar un mínimo de 4 caracteres",
                        maxlenght: "Debe ingresar un máximo de 15 caracteres"
                    },
                    txtContrasena: {
                        required: "Ingrese una contraseña",
                        minlength: "Debe ingresar un mínimo de 4 caracteres",
                        maxlenght: "Debe ingresar un máximo de 15 caracteres"
                    }
                }
            });
        };
    </script>

    <title></title>

</head>
<body>
    <form class="container" id="formSuscripcion" runat="server">
        <h1>Suscripcion</h1>
        <h6>Para realizar la suscripcion complete los siguientes datos</h6>
        <h3>Buscar Suscriptor</h3>
        <%-----------------------BUSCAR-------------------------------------%>
        <%--<div class="container">--%>
            <div class="row">
                <div class="col-5">
                    <label>Tipo Documento</label>
                    <asp:DropDownList ID="cboTipoDoc" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Seleccione un tipo de documento..." />
                        <asp:ListItem Text="DNI"/>
                        <asp:ListItem Text="LC" />
                        <asp:ListItem Text="PASAPORTE"/>
                    </asp:DropDownList>
                </div>
                <div class="col-5">
                    <label>Numero de Documento</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtNroDocumento" placeholder="" type="text" />
                </div>
                <div class="col-2">
                    <asp:Button runat="server" CssClass="btn btn-success mt-4 btn-lg" ID="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click" OnClientClick="Validaciones();"/>
                </div>
            </div>

            <%-------------------------NUEVO-----------------------------------%>
            <h3>Datos del Suscriptor</h3>

            <div class="row">
                <div class="col-5">
                    <label>Nombre</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" placeholder="" type="text" />
                </div>
                <div class="col-5">
                    <label>Apellido</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" placeholder="" type="text" />
                </div>
                <div class="col-2">
                    <asp:Button runat="server" CssClass="btn btn-info mt-4 btn-lg" ID="btnNuevo" Text="Nuevo" OnClick="btnNuevo_Click" />
                </div>
            </div>

            <%--------------------------MODIFICAR----------------------------------%>
            <div class="row">
                <div class="col-5">
                    <label>Direccion</label>
                    <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtDireccion" placeholder="" type="text" />
                </div>
                <div class="col-5">
                    <label>Email</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" placeholder="" TextMode="Email" />
                </div>
                <div class="col-2">
                    <asp:Button runat="server" CssClass="btn btn-primary mt-4 btn-lg" ID="btnModificar" Text="Modificar" OnClick="btnModificar_Click" />
                </div>
            </div>
            <%---------------------------GUARDAR---------------------------------%>
            <div class="row">
                <div class="col-5">
                    <label>Telefono</label>
                    <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtTelefono" placeholder="" type="text" />
                </div>
                <div class="col-5">
                    <label>Estado</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEstado" placeholder="" type="text" />
                </div>
                <div class="col-2">
                    <asp:Button runat="server" CssClass="btn btn-success mt-4 btn-lg" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" OnClientClick="Validaciones();" />
                </div>
            </div>
        
        <%----------------------------CANCELAR--------------------------------%>
        <div class="row">
            <div class="col-5">
                <label>Nombre de usuario</label>
                <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtNombreUsuario" placeholder="" type="text" />
            </div>
            <div class="col-5">
                <label>Contraseña</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtContrasena" placeholder="" type="password" />
            </div>
            <div class="col-2">
                <asp:Button Text="Cancelar" runat="server" ID="btnCancelar2" CssClass="btn btn-warning mt-4 btn-lg" OnClick="btnCancelar2_Click"/>
            </div>
        </div>
        <%--</div>--%>
        <%------------------------REGISTRAR SUSCRIPCION------------------------------------%>
        <div>
            <asp:Button runat="server" CssClass="btn btn-success mt-3 btn-lg" ID="btnRegistrarSuscripcion" Text="Registrar Suscripcion" OnClick="btnRegistrarSuscripcion_Click" />
        </div>
    </form>
   <%-- <script>
        function recargarPagina() {
            // Recargo la página
            location.reload();
        }
    </script>--%>
</body>
</html>
