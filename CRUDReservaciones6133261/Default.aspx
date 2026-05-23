<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUDReservaciones6133261.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema de Reservaciones</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap/5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f0f2f5;
            padding: 20px;
        }
        .container {
            max-width: 1000px;
            margin: 0 auto;
            background: white;
            border-radius: 10px;
            padding: 25px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
        }
        .title {
            font-size: 28px;
            font-weight: bold;
            color: #1a472a;
            text-align: center;
            margin-bottom: 25px;
            border-bottom: 3px solid #1a472a;
            padding-bottom: 10px;
        }
        .form-section {
            background: #f8f9fa;
            padding: 20px;
            border-radius: 8px;
            margin-bottom: 20px;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            font-weight: 600;
            width: 140px;
            display: inline-block;
        }
        .form-group input, .form-group select {
            width: 250px;
            padding: 6px 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        .buttons {
            margin: 20px 0;
            text-align: center;
        }
        .buttons .btn {
            margin: 0 5px;
            min-width: 90px;
        }
        .grid-container {
            margin-top: 25px;
            overflow-x: auto;
        }
        .table {
            width: 100%;
            border-collapse: collapse;
            font-size: 14px;
        }
        .table th {
            background-color: #1a472a;
            color: white;
            padding: 10px;
            text-align: left;
        }
        .table td {
            padding: 8px 10px;
            border-bottom: 1px solid #ddd;
        }
        .error-message {
            color: #dc3545;
            font-size: 12px;
            margin-left: 145px;
            display: block;
        }
        .mensaje {
            text-align: center;
            padding: 10px;
            margin-top: 15px;
            border-radius: 5px;
        }
        .alert-success {
            background-color: #d4edda;
            color: #155724;
            border: 1px solid #c3e6cb;
        }
        .alert-danger {
            background-color: #f8d7da;
            color: #721c24;
            border: 1px solid #f5c6cb;
        }
        .total-box {
            background: #e9ecef;
            padding: 10px;
            border-radius: 5px;
            margin-top: 10px;
            text-align: right;
            font-weight: bold;
        }
        .required:after {
            content: " *";
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="title">
               RESERVACIONES - HOTEL ARCE
            </div>

            <div class="form-section">
                <div class="form-group">
                    <label class="required">ID Reserva:</label>
                    <asp:TextBox ID="txtId" runat="server" Width="150px" ReadOnly="true" BackColor="#e9ecef"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="btn btn-secondary btn-sm" OnClick="btnSearch_Click" />
                </div>

                <div class="form-group">
                    <label class="required">Nombre:</label>
                    <asp:TextBox ID="txtNombre" runat="server" placeholder="Ej: Carlos"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" 
                        ErrorMessage="El nombre es obligatorio" CssClass="error-message" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label class="required">Apellido:</label>
                    <asp:TextBox ID="txtApellido" runat="server" placeholder="Ej: Martínez"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" 
                        ErrorMessage="El apellido es obligatorio" CssClass="error-message" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label class="required">Documento (DUI/NIT):</label>
                    <asp:TextBox ID="txtDocumento" runat="server" placeholder="Ej: 12345678-9"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ControlToValidate="txtDocumento" 
                        ErrorMessage="El documento es obligatorio" CssClass="error-message" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revDocumento" runat="server" ControlToValidate="txtDocumento"
                        ErrorMessage="Formato: 12345678-9 (8 dígitos, guión, 1 dígito)" 
                        ValidationExpression="^\d{8}-\d$" CssClass="error-message" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <label class="required">Teléfono:</label>
                    <asp:TextBox ID="txtTelefono" runat="server" placeholder="Ej: 70123456"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" 
                        ErrorMessage="El teléfono es obligatorio" CssClass="error-message" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono"
                        ErrorMessage="Ingrese 8 dígitos" ValidationExpression="^\d{8}$" CssClass="error-message" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <label class="required">Correo Electrónico:</label>
                    <asp:TextBox ID="txtCorreo" runat="server" placeholder="Ej: cliente@email.com"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" 
                        ErrorMessage="El correo es obligatorio" CssClass="error-message" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txtCorreo"
                        ErrorMessage="Ingrese un correo válido" 
                        ValidationExpression="^[\w\.-]+@[\w\.-]+\.\w+$" CssClass="error-message" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <label class="required">Tipo de Habitación:</label>
                    <asp:DropDownList ID="ddlTipoHabitacion" runat="server" Width="250px">
                        <asp:ListItem Text="-- Seleccione --" Value=""></asp:ListItem>
                        <asp:ListItem Text="Estándar (US$50/noche)" Value="Estandar"></asp:ListItem>
                        <asp:ListItem Text="Junior Suite (US$85/noche)" Value="Junior"></asp:ListItem>
                        <asp:ListItem Text="Suite Presidencial (US$150/noche)" Value="Suite"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvTipoHabitacion" runat="server" ControlToValidate="ddlTipoHabitacion" 
                        ErrorMessage="Seleccione un tipo de habitación" CssClass="error-message" Display="Dynamic" InitialValue=""></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label class="required">Fecha de Entrada:</label>
                    <asp:TextBox ID="txtFechaEntrada" runat="server" TextMode="Date" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFechaEntrada" runat="server" ControlToValidate="txtFechaEntrada" 
                        ErrorMessage="La fecha de entrada es obligatoria" CssClass="error-message" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label class="required">Fecha de Salida:</label>
                    <asp:TextBox ID="txtFechaSalida" runat="server" TextMode="Date" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFechaSalida" runat="server" ControlToValidate="txtFechaSalida" 
                        ErrorMessage="La fecha de salida es obligatoria" CssClass="error-message" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvFechas" runat="server" ControlToCompare="txtFechaEntrada" ControlToValidate="txtFechaSalida"
                        ErrorMessage="La fecha de salida debe ser posterior a la fecha de entrada" 
                        Operator="GreaterThan" Type="Date" CssClass="error-message" Display="Dynamic"></asp:CompareValidator>
                </div>

                <div class="form-group">
                    <label class="required">Número de Personas:</label>
                    <asp:TextBox ID="txtNumeroPersonas" runat="server" TextMode="Number" Width="100px" placeholder="1-10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNumeroPersonas" runat="server" ControlToValidate="txtNumeroPersonas" 
                        ErrorMessage="Número de personas es obligatorio" CssClass="error-message" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvNumeroPersonas" runat="server" ControlToValidate="txtNumeroPersonas"
                        ErrorMessage="Máximo 10 personas por habitación" MinimumValue="1" MaximumValue="10" 
                        Type="Integer" CssClass="error-message" Display="Dynamic"></asp:RangeValidator>
                </div>

                <div class="form-group">
                    <label class="required">Estado:</label>
                    <asp:DropDownList ID="ddlEstado" runat="server" Width="150px">
                        <asp:ListItem Text="Pendiente" Value="Pendiente"></asp:ListItem>
                        <asp:ListItem Text="Confirmada" Value="Confirmada"></asp:ListItem>
                        <asp:ListItem Text="Cancelada" Value="Cancelada"></asp:ListItem>
                        <asp:ListItem Text="Completada" Value="Completada"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label>Monto Total:</label>
                    <asp:TextBox ID="txtMontoTotal" runat="server" ReadOnly="true" BackColor="#e9ecef" Width="150px"></asp:TextBox>
                    <asp:Button ID="btnCalcular" runat="server" Text="Calcular Monto" CssClass="btn btn-info btn-sm" OnClick="btnCalcular_Click" />
                </div>
            </div>

            <div class="buttons">
                <asp:Button ID="btnNew" runat="server" Text="Nuevo" CssClass="btn btn-secondary" OnClick="btnNew_Click" />
                <asp:Button ID="btnSave" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnSave_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" CssClass="btn btn-warning" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                <asp:Button ID="btnShow" runat="server" Text="Mostrar Todos" CssClass="btn btn-primary" OnClick="btnShow_Click" />
            </div>

            <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje" Visible="false"></asp:Label>

            <div class="grid-container">
                <asp:GridView ID="gvReservaciones" runat="server" CssClass="table" AutoGenerateColumns="True" 
                    OnSelectedIndexChanged="gvReservaciones_SelectedIndexChanged" DataKeyNames="Id">
                    <HeaderStyle BackColor="#1a472a" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#f2f2f2" />
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
