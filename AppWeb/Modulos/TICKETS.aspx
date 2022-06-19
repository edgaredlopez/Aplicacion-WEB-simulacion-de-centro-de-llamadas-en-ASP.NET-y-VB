<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Modulos/HeaderMaster.Master" CodeBehind="TICKETS.aspx.vb" Inherits="AppWeb.Formulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
 
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table style="padding: 40px; border: thick groove #121f3d; width: 600px; font-size:20px; font-family:Arial; margin-top: 50px; margin-bottom: 50px; margin-left: 400px;" id="Tabla">
    <tr>
        <td colspan="2"  class="auto-style1">
            <asp:Label ID="Label3" runat="server" Text="Registro de tickets" CssClass="N"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style7"  colspan="2" style="border: thin groove #000000"></td>
    </tr>
      <tr>

        <td class="auto-style7" style="border: thin groove #000000">Numero de ticket(no editable):</td>
        <td class="auto-style7" style="border: thin groove #000000">
            <asp:TextBox ID="NumTicket" runat="server" Width="313px" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>

        <td class="auto-style7" style="border: thin groove #000000">Titulo de ticket:</td>
        <td class="auto-style7" style="border: thin groove #000000">
            <asp:TextBox ID="TituloTicket" runat="server" Width="313px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style6" style="border: thin groove #000000">Descripcion de ticket:</td>
        <td style="border: thin groove #000000" class="auto-style5">
            <asp:TextBox ID="DescripcionTicket" runat="server" Width="317px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style6" style="border: thin groove #000000">Prioridad: </td>
        <td style="border: thin groove #000000" class="auto-style5">
            <asp:TextBox ID="Prioridad" runat="server" Width="317px" Height="21px"></asp:TextBox>
        </td>
     <tr>
        <td class="auto-style6" style="border: thin groove #000000">Interlocutor:</td>
        <td style="border: thin groove #000000" class="auto-style5">
            <asp:DropDownList ID="InterlocutorDesplegable" runat="server" Width="317px">
            </asp:DropDownList>
        </td>
    </tr>

   
    <tr>
        <td class="auto-style6" style="border: thin groove #000000">Tipo de ticket:</td>
        <td style="border: thin groove #000000" class="auto-style5">
            <asp:DropDownList ID="TipoDesplegable" runat="server" Width="317px">
            </asp:DropDownList>
        </td>
    </tr>
        <tr>
        <td class="auto-style6" style="border: thin groove #000000">Area:</td>
        <td style="border: thin groove #000000" class="auto-style5">
            <asp:DropDownList ID="AreaDesplegable" runat="server" Width="317px">
            </asp:DropDownList>
        </td>
    </tr>

    
    <tr>
  
        <td class="auto-style4" colspan="2" style="border: thin groove #000000">

            <asp:Button  CssClass="Botones" ID="Button2" runat="server" Text="Modificar"  />
            <asp:Button CssClass="Botones" ID="Button1" runat="server" Text="Agregar" />
        </td>
    </tr>
           
        <asp:Label style="font-size:20px; font-family:Arial;" id="CajaMesajeHeader" runat="server"></asp:Label>
    
</table>








    <div  style="padding: 4px; border: thick groove #121f3d; width: 70%; margin-top: 50px; font-size:20px; font-family:Arial; margin-bottom: 50px; margin-left: 50px;" class="CajaPadre" > 
        
        <div class="CajaHijo">

             <asp:GridView ID="TablaProductos"   runat="server" BackColor="White" CellPadding="1" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" Text-align:center CssClass="auto-style3">
   
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Seleccion" />
  
        </Columns>
        <FooterStyle BackColor="red" />
        <HeaderStyle BackColor="#0E9622" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="Azure" Font-Bold="True" ForeColor="Red" />
        <SortedAscendingCellStyle BackColor="#121f3d" />
        <SortedAscendingHeaderStyle BackColor="Gray" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>

        </div>
       

    </div>
    
</asp:Content>
