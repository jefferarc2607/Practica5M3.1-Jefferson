<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="CRUDReservaciones6133261.Empleados" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel Arce - Empleados</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <center>
            <div class="container mt-4">
                <div class="card shadow-lg" style="max-width: 800px;">
                    <div class="card-header bg-success text-white">
                        <h3>Hotel Arce - El Salvador</h3>
                        <h4>Gestión de Empleados</h4>
                    </div>
                    <div class="card-body">
                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>ID Empleado:</label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtEmpleadoID" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="btn btn-info" Width="100px" OnClick="btnSearch_Click" />
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Apellido:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Nombre:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Inicial:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtMiddleInitial" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Dirección:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Ciudad:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Estado (Departamento):</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtState" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Zip Code:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Teléfono:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Email:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Contraseña:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Estado Registro:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Activo" Value="A"></asp:ListItem>
                                    <asp:ListItem Text="Inactivo" Value="I"></asp:ListItem>
                                </asp:DropDownList>
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
                                <asp:GridView ID="gvEmpleados" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="True"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </center>
    </form>
</body>
</html>