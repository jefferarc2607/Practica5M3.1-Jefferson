<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservaciones.aspx.cs" Inherits="CRUDReservaciones6133261.Reservaciones" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel Arce - Reservaciones</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700&display=swap" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap/5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <center>
            <div class="container mt-4">
                <div class="card shadow-lg" style="max-width: 800px;">
                    <div class="card-header bg-success text-white">
                        <h3>Hotel Arce - El Salvador</h3>
                        <h4>Gestión de Reservaciones</h4>
                    </div>
                    <div class="card-body">
                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>ID Reserva:</label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="btn btn-info" Width="100px" OnClick="btnSearch_Click" />
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Nombre Cliente:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Apellido Cliente:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Documento (DUI):</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Teléfono:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Email:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                         <div class="row mb-3">
                         <div class="col-md-3 text-end">
                             <label>Tipo de Habitación:</label>
                         </div>
                         <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Tipo Habitacion:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlTipoHabitacion" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoHabitacion_SelectedIndexChanged">
                                    <asp:ListItem Text="Seleccione" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Individual" Value="Individual"></asp:ListItem>
                                    <asp:ListItem Text="Doble" Value="Doble"></asp:ListItem>
                                    <asp:ListItem Text="Suite" Value="Suite"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                         </div>
                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Fecha Ingreso:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtFechaIngreso" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Fecha Salida:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtFechaSalida" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Número Personas:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtPersonas" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Estado:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Pendiente" Value="Pendiente"></asp:ListItem>
                                    <asp:ListItem Text="Confirmada" Value="Confirmada"></asp:ListItem>
                                    <asp:ListItem Text="Cancelada" Value="Cancelada"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Monto Total (US$):</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtMontoTotal" runat="server" CssClass="form-control" ReadOnly="true" BackColor="#e9ecef"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mt-4">
                            <div class="col text-center">
                                <asp:Button ID="btnNew" runat="server" Text="Nuevo" CssClass="btn btn-secondary" OnClick="btnNew_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnSave_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" CssClass="btn btn-warning" OnClick="btnUpdate_Click" />
                                <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                                <asp:Button ID="btnShow" runat="server" Text="Mostrar" CssClass="btn btn-primary" OnClick="btnShow_Click" />
                            </div>
                        </div>

                        <div class="row mt-4">
                            <div class="col">
                                <asp:GridView ID="gvReservaciones" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="True"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </center>
    </form>
</body>
</html>