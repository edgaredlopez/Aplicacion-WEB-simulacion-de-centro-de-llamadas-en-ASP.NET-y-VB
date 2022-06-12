Imports System.Data.Odbc
Public Class ClsConexionMySQL
    'Variable para guardar el String de conexion
    'Dimencion, NOmbre de varible, como, String
    Dim strConexion As String


    'Declaramos  una funcion que reciva Strings como parametro ByCal por valor para evitar modificaciones a este.  Optional para ser opcional. Las inicializamos de una vez
    'Los datos del string de conexin se traen del WEB.CONFIG donde declaramos los datos con sus respectivos nombres y valaores.. mismos que ponemos aqui para invocarlos y traer su contenido
    Public Sub AsignarConexion(Optional ByVal strUsuario As String = "", Optional ByVal strContrasenia As String = "")
        If (strUsuario.Trim.Length > 0 And strContrasenia.Trim.Length > 0) Then 'Evaluamos que los parametros no esten vacios
            strConexion = "server=" & ConfigurationManager.AppSettings.Item("ServidorSQL").ToString & ";uid=" & strUsuario & ";pwd=" & strContrasenia & ";database=" & ConfigurationManager.AppSettings.Item("MySQLBD").ToString & ""
        Else  'Si esta no esta llena
            strConexion = "Dsn=DN_MySql;server=" & ConfigurationManager.AppSettings.Item("ServidorSQL").ToString & ";uid=" & ConfigurationManager.AppSettings.Item("User").ToString & ";pwd=" & ConfigurationManager.AppSettings.Item("Pass").ToString & ";database=" & ConfigurationManager.AppSettings.Item("MySQLBD").ToString & ""
        End If
    End Sub









    'PARA MOSTRAR DATOS EN COMBO BOX
    Public Function FillObjectList(ByVal myObjectList As Object, ByVal SQLString As String) As String

        AsignarConexion() 'Llamamos el metodo que crea el string de conexion
        Dim msgRet As String = "" 'Variable para gaurdar el error si es que lo hauy
        Dim mySQLConexion As New OdbcConnection(strConexion) 'Establecemos la conexion mandando el string de conexion
        Dim mysqlDataAdapter As New OdbcDataAdapter(SQLString, mySQLConexion) 'PREPARAMOS la consulta usando la conexion establecida y el query de consulta. ESPECIAL PARA SELECT


        'Dim mySQLConexion As New MySqlConnection(strConexion)
        'Dim mysqlDataAdapter As New MySqlDataAdapter(SQLString, mySQLConexion)


        'Para guardar datos de la consulta
        Dim dsDatos As New Data.DataSet
        'Para guardar los datos en formato TablaDeDatosEnMemoria para mandarlos a la tabla
        Dim dtTabla As Data.DataTable


        Try
            mysqlDataAdapter.Fill(dsDatos, "TablaDDL") 'Ejecutamos la consulta, guardamos los datos en la vaiable datasetDatos. Y la guardamos pero en formato TABLA

            'Pasamos los datos de dataSet a la variable de datos de tipo TablaDeDatosEnMemoria
            dtTabla = dsDatos.Tables("TablaDDL")
            mysqlDataAdapter.Dispose() 'Cerramos la consulta

            'Empezamos a mandar los datos al objeto que se trajo, ya sea un desplegable
            myObjectList.DataSource = dsDatos 'Ponemos el TablaDeDatosEnMemoria como el reecurso de datos del objeto

            'Mandar los datos al objeto
            myObjectList.DataValueField = dsDatos.Tables(0).Columns(0).ColumnName
            myObjectList.DataTextField = dsDatos.Tables(0).Columns(1).ColumnName
            myObjectList.DataBind() 'Confirmamos 

            'Capturamos cualquier error y lo mostramos
        Catch ex As System.Exception
            msgRet = "Ocurrió el siguiente error! " & vbCrLf & ex.Message
        Finally
            'Cerramos las conexiones
            mySQLConexion.Close()
            mySQLConexion.Dispose()
            mysqlDataAdapter.Dispose()
            dsDatos.Dispose()
        End Try
        Return msgRet
        msgRet = "Conexion exitosa"
    End Function











    'Para llenar datos de TABLAS CUADROS
    Public Function FillDataGrid(ByVal myDataGrid As Object, ByVal SQLString As String) As String

        ' Retorna los registros que cumplen con una condicion en una tabla
        AsignarConexion()
        Dim msgRet As String = ""
        Dim orclConexion As New OdbcConnection(strConexion)
        Dim orclDataAdapter As New OdbcDataAdapter(SQLString, orclConexion)
        Dim dsDatos As New Data.DataSet
        Dim dtTabla As Data.DataTable
        Try
            orclDataAdapter.Fill(dsDatos, "TablaDDL")
            dtTabla = dsDatos.Tables("TablaDDL")
            orclDataAdapter.Dispose()
            myDataGrid.DataSource = dtTabla
            myDataGrid.Databind()
        Catch ex As System.Exception
            msgRet = "Ocurrió el siguiente error! " & vbCrLf & ex.Message
        Finally
            orclConexion.Close()
            orclConexion.Dispose()
            orclDataAdapter.Dispose()
            dsDatos.Dispose()
        End Try
        Return msgRet
    End Function









    '*********agregado para hacer operaciones de insert, update, delete

    Public Function EjecutarOperacionSQL(ByVal strSQL As String) As String


        Dim msgRet As String = "" 'Para guardar los errores que se presenten
        AsignarConexion() 'Creamos el string de conexion

        Dim sqlcConexion As New OdbcConnection(strConexion) 'Creamos la conexion usando el string de conexion
        Dim sqlcComando As New OdbcCommand
        Dim sqlcTransaccion As OdbcTransaction
        Try
            sqlcConexion.Open()
            sqlcTransaccion = sqlcConexion.BeginTransaction
            sqlcComando.Connection = sqlcConexion
            sqlcComando.Transaction = sqlcTransaccion
            sqlcComando.CommandText = strSQL
            sqlcComando.ExecuteNonQuery()
            sqlcTransaccion.Commit()
        Catch ex As Exception
            sqlcTransaccion.Rollback()
            msgRet = "Ocurrió el siguiente error! " & vbCrLf & ex.Message
        Finally
            sqlcConexion.Close()
            sqlcConexion.Dispose()
        End Try
        Return msgRet
    End Function




End Class
