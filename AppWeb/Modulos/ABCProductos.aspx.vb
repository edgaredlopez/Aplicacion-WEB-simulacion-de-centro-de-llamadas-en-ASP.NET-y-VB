Public Class Formulario
    Inherits System.Web.UI.Page

    Dim ObjClient As New ClsInterfaz() 'Importar clase de validaciones y mensajes
    Dim ClaseDeConexionMYSQL As New ClsConexionMySQL() 'Importar clase de conexion y operaciones de bd

    Dim StrSQL As New StringBuilder




    'Metodos a ejecutar cuando se inicia la pagina o carga la pagina
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack Then  'SOLO LA PRIMERA VEZ LO HACE
            Me.CargarCatalogos() 'Para lista desplegamble
            Me.CargarProductos() 'Para la tabla de productos insertados
        End If
    End Sub





    'Metodo para cargar datos a lista desplegable
    Public Sub CargarCatalogos()
        Dim strSQL As New StringBuilder 'variable string donde se gaurdara la consulta
        strSQL.Append("SELECT Clase,Clase FROM NotasEstudiantes.clase;") 'Consulta a la base de datos

        'Llamamos al objeto de la clase conexion y llamamos al metodo especializado en listas desplegables
        ' Le mandamos el objeto desplegable y el string de la consulta
        Me.ClaseDeConexionMYSQL.FillObjectList(Me.ClaseDesplegable, strSQL.ToString) 'el ID del desplegable es pro
        ClaseDesplegable.Items.Insert(0, "Seleccione...") 'Insertamos un dato al inicio de la consulta que se hizo
        strSQL.Clear()  'Limpiamos el stirng de consulta
    End Sub



    'Para actualizar el resultado de la TABLA
    Public Sub CargarProductos()
        'String con consulta para traer datos a la tabla
        StrSQL.Append("select Estudiantes.IDEstudiante,Nombre,Anio,Grado,Seccion, clase.clase,clase.Nota from Estudiantes INNER JOIN clase on clase.IDEstudiante=Estudiantes.IDEstudiante")

        'Llamamos el objeto de conexion y el metodo especializado en tablas y le mandamos el objetod 
        'TABLA junto con la consulta sql
        ClaseDeConexionMYSQL.FillDataGrid(Me.TablaProductos, StrSQL.ToString)

        'En el encabezado mandamos cuantos registros tenemos en la tabla, mediante el conteo de filas que la tabla tiene
        Me.CajaMesajeHeader.Text = "En la base de datos hay: " & Me.TablaProductos.Rows.Count.ToString() & " estudiantes registrados hasta el momento."

    End Sub










    'Evento para insertar o guardar un producto a la base de datos
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ValidarCampos() Then 'Validamos  que todos los campos esten llenos con el metodo de evalucaion
            If ValidarLongitud() Then ' Validamos el tamaño de los campos de texto con el metodo de longitud

                'QUERY para el insert
                StrSQL.Append("insert into Estudiantes (IDEstudiante,Nombre,Anio,Grado,Seccion) ")
                StrSQL.Append(" VALUES('" & Me.Id.Text.Trim & "','" & Me.Nombre.Text.Trim & "', '" & Me.aniocursado.Text.Trim & "','" & Me.Grado.Text.Trim & "', '" & Me.Seccion.Text.Trim & "') ")
                Me.ClaseDeConexionMYSQL.EjecutarOperacionSQL(StrSQL.ToString)
                StrSQL.Clear()

                StrSQL.Append("insert into clase (Clase,Nota,IDEstudiante) ")
                StrSQL.Append(" VALUES('" & Me.ClaseDesplegable.Text.Trim & "','" & Me.Calificacion.Text.Trim & "','" & Me.Id.Text.Trim & "') ")

                Me.ObjClient.MonstrarMsgBD(Me.ClaseDeConexionMYSQL.EjecutarOperacionSQL(StrSQL.ToString), Me)
                StrSQL.Clear()
                Me.CargarProductos()
                Me.LimpiarCampos()


            Else ObjClient.MostrarMensaje("Verifique que la longitud de los campos no exceda el tamaño permitido.", Me)
            End If
        Else ObjClient.MostrarMensaje("Ingrese todos los campos obligatorios, debe de llenarlos.", Me)
        End If
    End Sub



    'PARA ACTUALIZAR usando el boton de MODIFICAR EN EL FORMULARIO
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'Creamos string de mysql para ejecutar la actualizacion, jalamos los datos en cada campo del formulario
        StrSQL.Append("update Estudiantes set  Nombre = '" & Nombre.Text & "', Anio='" & aniocursado.Text & "', Grado='" & Grado.Text & "', Seccion='" & Seccion.Text & "'  where IDEstudiante = '" & Id.Text & "';")
        Me.ClaseDeConexionMYSQL.EjecutarOperacionSQL(StrSQL.ToString)
        StrSQL.Clear()



        StrSQL.Append("update Clase set  clase = '" & ClaseDesplegable.Text & "', Nota='" & Calificacion.Text & "'  where IDEstudiante = '" & Id.Text & "';")
        'Llamamos el objeto OBJCLIENTE que creamos arriba y con ese llamamos la funcion de MostrarMSGDBD para que nos
        'muestre un mensaje segun el valor que nos retorne la ejecuionh del script. 
        'El Script sera usando la clase de conexion y llamamos el metoodo de operacion sql y le mandamos el string y los datos a modificar

        Me.ObjClient.MonstrarMsgBD(Me.ClaseDeConexionMYSQL.EjecutarOperacionSQL(StrSQL.ToString), Me)

        StrSQL.Clear()
        Me.CargarProductos()

    End Sub









    'PARA ELMIMINAR UN REGISTRO EN LA TABLA
    Protected Sub Productos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles TablaProductos.RowDeleting

        'Declaramos variable para guardar el ID DEL PRODUCTO 
        Dim Com As String

        'Obtenemos el ID del producto
        Com = Me.TablaProductos.Rows(e.RowIndex).Cells(2).Text

        'Preparamos la consulta
        StrSQL.Append("delete from Clase where IDEstudiante = '" & Com & "'")
        Me.ClaseDeConexionMYSQL.EjecutarOperacionSQL(StrSQL.ToString)
        StrSQL.Clear()


        StrSQL.Append("delete from Estudiantes where IDEstudiante = '" & Com & "'")
        'Llamamos el objeto OBJCLIENTE que creamos arriba y con ese llamamos la funcion de MostrarMSGDBD para que nos
        'muestre un mensaje segun el valor que nos retorne la ejecuionh del script. 
        'El Script sera usando la clase de conexion y llamamos el metoodo de operacion sql y le mandamos el string y los datos a Eliminar
        Me.ObjClient.MonstrarMsgBD(Me.ClaseDeConexionMYSQL.EjecutarOperacionSQL(StrSQL.ToString), Me)
        StrSQL.Clear()

        Me.CargarProductos()
        Me.LimpiarCampos()
    End Sub








    'Para pasar los datos de la fila seleccionada en la tabla hacia el formulario
    Protected Sub Productos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TablaProductos.SelectedIndexChanged

        'Declaramos variables
        Dim Idp, Nombre, anio, Grado, Seccion, Clase, Calificacion As String

        'Obtenemos los datos de la fila seleccionada en las columnas correspondientes
        Idp = TablaProductos.SelectedRow.Cells(2).Text
        Nombre = TablaProductos.SelectedRow.Cells(3).Text
        anio = TablaProductos.SelectedRow.Cells(4).Text
        Grado = TablaProductos.SelectedRow.Cells(5).Text
        Seccion = TablaProductos.SelectedRow.Cells(6).Text
        Clase = TablaProductos.SelectedRow.Cells(7).Text
        Calificacion = TablaProductos.SelectedRow.Cells(8).Text

        'Pasamos estos datos a cada celda del formulario
        Me.Id.Text = Idp
        Me.Nombre.Text = Nombre
        Me.aniocursado.Text = anio
        Me.Grado.Text = Grado
        Me.Seccion.Text = Seccion
        Me.ClaseDesplegable.Text = Clase
        Me.Calificacion.Text = Calificacion

    End Sub





    'Validar si los campos estan llenos
    Public Function ValidarCampos() As Boolean
        Dim ban As Boolean = False 'Variable para guardar booleano si los campos estan llenos o no

        If (Me.ClaseDesplegable.SelectedIndex > 0) Then
            If (Me.Nombre.Text.Trim <> "") Then
                If (Me.aniocursado.Text.Trim <> "") Then
                    If (Me.Calificacion.Text.Trim <> "") Then
                        ban = True
                    End If
                End If
            End If
        End If
        Return ban
    End Function




    'Validar que el campo de nombre y descripcion de longitud no pase la cantidad sportada de caracterers de la base de datos
    Public Function ValidarLongitud()
        Dim ban As Boolean
        ban = False
        If (Me.Nombre.Text.Trim.Length < 50) Then
            If (Me.aniocursado.Text.Trim.Length < 100) Then
                ban = True
            End If
        End If
        Return (ban)
    End Function



    'Para limpiar los campos  despues de alguna operacion
    Public Sub LimpiarCampos()
        Me.Id.Text = ""
        Me.Nombre.Text = ""
        Me.aniocursado.Text = ""
        Me.Calificacion.Text = ""
        StrSQL.Clear()
    End Sub



End Class



