<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="CRUDReservaciones6133261.Productos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel Arce - Productos</title>
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
                        <h4>Gestión de Productos</h4>
                    </div>
                    <div class="card-body">
                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Category ID:</label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCategoryID" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="btn btn-info" Width="100px" OnClick="btnSearch_Click" />
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Supplier ID:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtSupplierID" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Producto:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtProduct" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Descripción:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Precio (US$):</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Stock:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtNumberInStock" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                          <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Pedidos:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtNumberOnOrder" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-3 text-end">
                                <label>Stock Mínimo:</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtReorderLevel" runat="server" CssClass="form-control"></asp:TextBox>
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
                                <asp:GridView ID="gvProductos" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="True"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </center>
    </form>
</body>
</html>