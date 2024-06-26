<%@ Page Title="" Language="C#" MasterPageFile="~/LoginRegister.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CarDealer.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function enviarPostback() {
            __doPostBack('Log', '');
        }
    </script>
    <style>
        body{
            overflow:hidden;
        }
        .login-box {
    position: relative;
    top: 50%;
    left: 50%;
    width: 33vw;
    height: 90%;
    padding: 40px;
    transform: translate(-50%, -50%);
    background: rgba(24, 20, 20, 0.987);
    box-sizing: border-box;
    box-shadow: 0 15px 25px rgba(0,0,0,.6);
    border-radius: 10px;
    min-width: 275px;
  }
  
  .login-box .user-box {
    position: relative;
  }
  
  .login-box .user-box input {
    width: 100%;
    padding: 10px 0;
    font-size: 16px;
    color: #fff;
    margin-bottom: 30px;
    border: none;
    border-bottom: 1px solid #fff;
    outline: none;
    background: transparent;
  }

  input:-webkit-autofill,
  input:-webkit-autofill:hover,
  input:-webkit-autofill:focus,
  input:-webkit-autofill:active {
      transition: background-color 5000s ease-in-out 0s;
      -webkit-text-fill-color: #fff !important;
  }
  
  
  .login-box .Contenedor a {
    position: relative;
    display: inline-block;
    padding: 10px 20px;
    color: #ffffff;
    font-size: 16px;
    text-decoration: none;
    text-transform: uppercase;
    overflow: hidden;
    transition: .5s;
    margin-top: 20px;
    letter-spacing: 4px
  }
  
  .login-box a:hover {
    background: #03f40f;
    color: #fff;
    border-radius: 5px;
    box-shadow: 0 0 5px #03f40f,
                0 0 25px #03f40f,
                0 0 50px #03f40f,
                0 0 100px #03f40f;
  }

  
  .login-box a span {
    position: absolute;
    display: block;
  }
  
  @keyframes btn-anim1 {
    0% {
      left: -100%;
    }
  
    50%,100% {
      left: 100%;
    }
  }
  
  .login-box a span:nth-child(1) {
    bottom: 2px;
    left: -100%;
    width: 100%;
    height: 2px;
    background: linear-gradient(90deg, transparent, #03f40f);
    animation: btn-anim1 2s linear infinite;
  }

.RegularExp{
  font-size: 11px;
  position: absolute;
  display: flex;
  align-self: center;
  margin-top: -23px;
}
    </style>
    <div class="row">
        <div class="col">
            <div class="login-box  mt-5">
                <div class="Contenedor">
                    <div class="user-box mb-3">
                        <asp:TextBox PlaceHolder="Email" ID="EmailBox" runat="server" TextMode="Email"></asp:TextBox>
                        <asp:RegularExpressionValidator CssClass="RegularExp" ClientIDMode="Static" ID="EmailFormat" runat="server" Text="Ingrese un Email Valido" ToolTip="Porfavor Ingrese un Mail valido" ControlToValidate="EmailBox" ValidationExpression="(\w)+@(\w)+.com(.(\w)+)*" ForeColor="Red"/>
                    </div>
                    <div class="user-box">
                        <asp:TextBox  PlaceHolder="Contraseña" ID="PassBox" runat="server" TextMode="Password" ></asp:TextBox>
                        <asp:Label ID="LabelError" ClientIDMode="Static" runat="server" Text="Error en el Login, el Email y\o la Clave son Erroneas"
                            CssClass="RegularExp" Visible="false" ForeColor="Red"></asp:Label>
                    </div>
                    <center class="mt-3">
                        <a href="#" onclick="enviarPostback(); return false;" id="btnLog" TabIndex="0">Login
                        <span></span>
                        </a>
                        <asp:Button ID="Defaultbtn" runat="server" Text="Button" CssClass="d-none" OnClick="Login_Click"/>
                    </center>
                </div>
            </div>
            
        </div>
    </div>
</asp:Content>
