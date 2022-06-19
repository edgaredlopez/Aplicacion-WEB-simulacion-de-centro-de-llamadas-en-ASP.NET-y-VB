Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim NombreUsuarioAMostrar, ed As String

        'Obtenemos los datos de la fila seleccionada en las columnas correspondientes
        NombreUsuarioAMostrar = Session("User_Name")

        Me.pruebasesion.Text = NombreUsuarioAMostrar

    End Sub

End Class