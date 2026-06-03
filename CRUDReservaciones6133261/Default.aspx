<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUDReservaciones6133261.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel Arce - El Salvador</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700&display=swap" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap/5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <center>
            <div class="container mt-5">
                <div class="card shadow-lg" style="max-width: 600px;">
                    <div class="card-header bg-success text-white">
                        <h2>Hotel Arce - El Salvador</h2>
                    </div>
                    <div class="card-body">
                        <asp:Button ID="btnReservaciones" runat="server" Text="Reservaciones" CssClass="btn btn-primary m-2" OnClick="btnReservaciones_Click" Width="200px" />
                        <asp:Button ID="btnProductos" runat="server" Text="Productos" CssClass="btn btn-primary m-2" OnClick="btnProductos_Click" Width="200px" />
                        <asp:Button ID="btnEmpleados" runat="server" Text="Empleados" CssClass="btn btn-primary m-2" OnClick="btnEmpleados_Click" Width="200px" />
                    </div>
                    <div class="card-footer text-muted">
                        Bienvenido a Hotelería Salvadoreña
                    </div>
                </div>
            </div>
        </center>
    </form>
</body>
</html>