<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Modulos/HeaderMaster.Master" CodeBehind="ABCProductos.aspx.vb" Inherits="AppWeb.Formulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
 
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table style="padding: 40px; border: thick groove #121f3d; width: 600px; font-size:20px; font-family:Arial; margin-top: 50px; margin-bottom: 50px; margin-left: 400px;" id="Tabla">
    <tr>
        <td colspan="2"  class="auto-style1">
            <asp:Label ID="Label3" runat="server" Text="Ingreso estudiantes y notas" CssClass="N"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style7" colspan="2" style="border: thin groove #000000"></td>
    </tr>
    <tr>
        <td class="auto-style7" style="border: thin groove #000000">Clave del estudiante:</td>
        <td class="auto-style7" style="border: thin groove #000000">
            <asp:TextBox ID="Id" runat="server" Width="313px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style6" style="border: thin groove #000000">Nombre estudiante:</td>
        <td style="border: thin groove #000000" class="auto-style5">
            <asp:TextBox ID="Nombre" runat="server" Width="317px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style6" style="border: thin groove #000000">Año cursado: </td>
        <td style="border: thin groove #000000" class="auto-style5">
            <asp:TextBox ID="aniocursado" runat="server" Width="317px" Height="21px"></asp:TextBox>
        </td>
    </tr>
         <tr>
        <td class="auto-style6" style="border: thin groove #000000">Grado: </td>
        <td style="border: thin groove #000000" class="auto-style5">
            <asp:TextBox ID="Grado" runat="server" Width="317px" Height="21px"></asp:TextBox>
        </td>
    </tr>
         <tr>
        <td class="auto-style6" style="border: thin groove #000000">Seccion: </td>
        <td style="border: thin groove #000000" class="auto-style5">
            <asp:TextBox ID="Seccion" runat="server" Width="317px" Height="20px"></asp:TextBox>
        </td>
    </tr>

   
    <tr>
        <td class="auto-style6" style="border: thin groove #000000">Clase:</td>
        <td style="border: thin groove #000000" class="auto-style5">
            <asp:DropDownList ID="ClaseDesplegable" runat="server" Width="317px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style6" style="border: thin groove #000000">Calificación:</td>
        <td style="border: thin groove #000000" class="auto-style5">
            <asp:TextBox ID="Calificacion" runat="server" Width="318px"></asp:TextBox>
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








    <div  style="padding: 4px; border: thick groove #121f3d; width: 70%; margin-top: 50px; font-size:20px; font-family:Arial; margin-bottom: 50px; margin-left: 200px;" class="CajaPadre" > 
        
        <div class="CajaHijo">

             <asp:GridView ID="TablaProductos"   runat="server" BackColor="White" CellPadding="1" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" Text-align:center CssClass="auto-style3">
   
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Seleccion" />
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Eliminar" />
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
