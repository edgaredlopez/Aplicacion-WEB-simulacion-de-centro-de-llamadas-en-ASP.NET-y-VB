<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Modulos/HeaderMaster.Master" CodeBehind="Reportes.aspx.vb" Inherits="AppWeb.FormularioReporte"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
 
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <div  style="padding: 4px; border: thick groove #121f3d; width: 90%; margin-top: 50px; font-size:20px; font-family:Arial; margin-bottom: 50px; margin-left: 50px;" class="CajaPadre" > 
          
        <asp:Label ID="CajaMesajeHeaderReporte" runat="server" Text="TextoNotificacion"></asp:Label>
         <br /> <br />
        <asp:Label ID="EtiquetaBuscar" runat="server" Text="Buscar por numero de ticket:"></asp:Label>
        <asp:TextBox ID="CajaFiltroReporte" runat="server"></asp:TextBox> 



        <asp:Label ID="Label1" runat="server" Text="Buscar por RANGO  de FECHA: utilice un formato correcto, ejemplo: 2022-06-18"></asp:Label>
        <asp:TextBox ID="fechainicial" runat="server"></asp:TextBox> 
        <asp:TextBox ID="fechafinal" runat="server"></asp:TextBox> 
        <br />
         <br />
        <asp:Button ID="BUSCARFILTRO" runat="server" Text="Filtrar" />
            <br />
         <br />
        <div class="CajaHijo">

          

             <asp:GridView ID="TablaReportes"   runat="server" BackColor="White" CellPadding="1" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" Text-align:center   CssClass="auto-style3" >
   
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
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
