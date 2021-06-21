"<%@ Page Language = "C#" AutoEventWireup="true"
   CodeBehind="QCCode.aspx.cs"
   Inherits="QRCodeSample.QCCode" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml%22%3E">

   <head runat="server"> 
       QR Code Generatorr</title>
   </head>
   <body>
      <form id="QCFrom" runat="server">
         <div>
            <asp:TextBox ID = "txtQCCode" runat="server">
            </asp:TextBox >
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID = "btnQCGenerate" runat="server"
               Text="Create My QR Code"
               OnClick="btnQCGenerate_Click" />
            <hr/>
            <asp:Image ID = "imgageQRCode" Width="100px"
               Height="100px" runat="server"
               Visible="true" /> <br /><br />

             <asp:Button ID = "btnQCDowload" Text="Dowload My QR Code"
               runat="server" OnClick="btnQCdownload_click" Width="205px" />
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Button ID = "btnQCRead" Text="Read My QR Code"
               runat="server" OnClick="btnQCRead_Click" />
               <br /><br />


            <asp:Label ID = "lblQRCode" runat="server">
            </asp:Label>
         </div>
      </form>
   </body >
   </html >