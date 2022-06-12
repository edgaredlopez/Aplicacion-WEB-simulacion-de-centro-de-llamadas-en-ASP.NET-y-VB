Imports System.Data.Odbc
Imports System.Windows
Imports MySql.Data.MySqlClient

Public Class WebForm1

    Inherits System.Web.UI.Page
    Dim ObjClient As New ClsInterfaz() 'Importar clase de validaciones y mensajes
    Dim ClaseDeConexionMYSQL As New ClsConexionMySQL() 'Importar clase de conexion y operaciones de bd
    Dim StrSQL As New StringBuilder




    Dim strConexion As String


    Public Sub AsignarConexion(Optional ByVal strUsuario As String = "", Optional ByVal strContrasenia As String = "")
        If (strUsuario.Trim.Length > 0 And strContrasenia.Trim.Length > 0) Then 'Evaluamos que los parametros no esten vacios
            strConexion = "server=" & ConfigurationManager.AppSettings.Item("ServidorSQL").ToString & ";uid=" & strUsuario & ";pwd=" & strContrasenia & ";database=" & ConfigurationManager.AppSettings.Item("MySQLBD").ToString & ""
        Else  'Si esta no esta llena
            strConexion = "Dsn=DN_MySql;server=" & ConfigurationManager.AppSettings.Item("ServidorSQL").ToString & ";uid=" & ConfigurationManager.AppSettings.Item("User").ToString & ";pwd=" & ConfigurationManager.AppSettings.Item("Pass").ToString & ";database=" & ConfigurationManager.AppSettings.Item("MySQLBD").ToString & ""
        End If
    End Sub





    'Metodo para cargar datos a lista desplegable
    Public Sub BuscarDatosDeLogin()

        'Para guardar los datos en formato TablaDeDatosEnMemoria para mandarlos a la tabla
        Dim dtTabla As DataTable

        Dim con As New MySqlConnection("server={DESKTOP-P5VS7LV}; uid=root; pwd=toor; database=NotasEstudiantes;")


        Dim strSQL As String = ("SELECT usuario, password FROM Usuarios where usuario = '" & CajaUsuario.Text & "';") 'Consulta a la base de datos


        Dim comando As New MySqlCommand(strSQL, con)

        Try


            Dim ObjetoDataReader As MySqlDataReader
            con.Open()
            ObjetoDataReader = comando.ExecuteReader

            If ObjetoDataReader.Read() Then
                Me.CajaPrueba.Text = ObjetoDataReader.Item("usuario").ToString
            Else
                MessageBox.Show("Nose ha encontrado ningun resulado")
            End If
            ObjetoDataReader.Close()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub





    'Metodo para cargar datos a lista desplegable
    Public Sub CargarCatalogos()
        Dim strSQL As New StringBuilder 'variable string donde se gaurdara la consulta
        strSQL.Append("SELECT usuario FROM Usuarios where IDUsuario=1;") 'Consulta a la base de datos

        'Llamamos al objeto de la clase conexion y llamamos al metodo especializado en listas desplegables
        ' Le mandamos el objeto desplegable y el string de la consulta
        Me.ClaseDeConexionMYSQL.FillObjectList(Me.CajaPrueba, strSQL.ToString) 'el ID del desplegable es pro

        strSQL.Clear()  'Limpiamos el stirng de consulta
    End Sub



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CargarCatalogos()
    End Sub
End Class