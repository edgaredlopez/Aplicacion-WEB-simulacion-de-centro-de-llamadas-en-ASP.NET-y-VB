Imports System.Data.Odbc
Imports System.Windows
Imports MySql.Data.MySqlClient

Public Class WebForm1

    Inherits System.Web.UI.Page
    Dim ObjClient As New ClsInterfaz()
    Dim ClsConexion As New ClsConexionMySQL()
    Dim StrSQL As New StringBuilder
    Dim URLDireccionamientoCorrecto As String = "Inicio.aspx"  'pagina de inicio 
    Dim RedirectLoginFailed As String = "Login.aspx" 'pagina de fallo al loguearse

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then 'la primera vez
            Try
                Session.Remove("cod_usuario")
                Session.Remove("User_Name")
                Session.Remove("pass_usuario")
                Session.Remove("rol")

                SetFocus(Me.CajaUsuario)
                Session.Timeout = 360
            Catch

            End Try
            'txtLoginUsuario.Attributes.Add("onkeydown", "if (event.keyCode==13 || event.which==13 ) event.keyCode=9;")
        End If
    End Sub

    Public Function ValidarCampos()
        Dim ban As Boolean
        ban = False
        If (Me.CajaUsuario.Text.Trim <> "") Then
            If (Me.CajaPassword.Text.Trim <> "") Then
                ban = True
            End If
        End If
        Return (ban)
    End Function
    Public Sub LimpiarCampos()
        Me.CajaUsuario.Text = ""
        Me.CajaPassword.Text = ""
        StrSQL.Clear()
    End Sub

    Private Function FnValidarLogin() As Boolean
        Dim ValResult As Boolean = False
        Dim StrResultado As String = ""
        Dim dtPermisos As New DataTable()

        StrSQL.Append("SELECT Usuario.Cod_User,Usuario.Cod_User, Usuario.User_Name, Usuario.Password, Role.Nom_Role  ")
        ' StrSQL.Append("CASE WHEN Usuario.Cod_User=Usuario.Cod_User THEN Cod_User ELSE Cod_User END edgar ")
        StrSQL.Append("FROM Usuario inner join Role on Usuario.Cod_Role=Role.Cod_Role ")
        StrSQL.Append("WHERE Usuario.User_Name= '" + Me.CajaUsuario.Text.Trim + "' and Usuario.Password = '" + Me.CajaPassword.Text.Trim + "' ")
        StrResultado = ClsConexion.FillDataTable(dtPermisos, StrSQL.ToString)


        If dtPermisos.Rows.Count > 0 Then
            'variables de sesion con el login y password del usuario
            Session("User_Name") = UCase(Me.CajaUsuario.Text.Trim)
            Session("pass_usuario") = UCase(Me.CajaPassword.Text.Trim)
            Session("cod_usuario") = dtPermisos.Rows(0).Item("Cod_User").ToString()
            Session("rol") = dtPermisos.Rows(0).Item("Nom_Role").ToString()

            ValResult = True
        Else
            ValResult = False
        End If

        Return ValResult
    End Function



    Protected Sub BotonIniciarSesion_Click(sender As Object, e As EventArgs) Handles BotonIniciarSesion.Click

        If ValidarCampos() Then 'Validamos todos los campos
            If FnValidarLogin() Then
                Response.Redirect(URLDireccionamientoCorrecto)
                'ObjClient.MostrarMensaje("Login Exitoso!!!", Me)
            Else ObjClient.MostrarMensaje("Usuario o Password Incorrecto!!!.  Vuelva a intentarlo.", Me)
            End If
        Else ObjClient.MostrarMensaje("Ingrese los campos Usuario y Password son obligatorios, debe de llenarlos.", Me)
        End If
    End Sub
End Class