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
        strSQL.Append("SELECT Cod_User,User_Name FROM Usuario inner join Role on Role.Cod_Role=Usuario.Cod_Role where Nom_Role='Interlocutor' or Nom_Role='interlocutor';") 'Consulta a la base de datos
        'Llamamos al objeto de la clase conexion y llamamos al metodo especializado en listas desplegables
        ' Le mandamos el objeto desplegable y el string de la consulta
        Me.ClaseDeConexionMYSQL.FillObjectList(Me.InterlocutorDesplegable, strSQL.ToString) 'el ID del desplegable es pro
        InterlocutorDesplegable.Items.Insert(0, "Seleccione...") 'Insertamos un dato al inicio de la consulta que se hizo
        strSQL.Clear()  'Limpiamos el stirng de consulta


        strSQL.Append("SELECT Cod_Tipo,Nom_Tipo FROM Tipo_Ticket;") 'Consulta a la base de datos
        'Llamamos al objeto de la clase conexion y llamamos al metodo especializado en listas desplegables
        ' Le mandamos el objeto desplegable y el string de la consulta
        Me.ClaseDeConexionMYSQL.FillObjectList(Me.TipoDesplegable, strSQL.ToString) 'el ID del desplegable es pro
        TipoDesplegable.Items.Insert(0, "Seleccione...") 'Insertamos un dato al inicio de la consulta que se hizo
        strSQL.Clear()  'Limpiamos el stirng de consulta

        strSQL.Append("SELECT Cod_Area,Nom_Area FROM Area;") 'Consulta a la base de datos
        'Llamamos al objeto de la clase conexion y llamamos al metodo especializado en listas desplegables
        ' Le mandamos el objeto desplegable y el string de la consulta
        Me.ClaseDeConexionMYSQL.FillObjectList(Me.AreaDesplegable, strSQL.ToString) 'el ID del desplegable es pro
        AreaDesplegable.Items.Insert(0, "Seleccione...") 'Insertamos un dato al inicio de la consulta que se hizo
        strSQL.Clear()  'Limpiamos el stirng de consulta


    End Sub



    'Para actualizar el resultado de la TABLA
    Public Sub CargarProductos()
        'String con consulta para traer datos a la tabla
        StrSQL.Append("SELECT Num_Ticket, Titulo_Ticket, Desc_Ticket, Prioridad, User_Creacion, Fecha_Creacion, ")
        StrSQL.Append("Usuario.User_Name, Tipo_Ticket.Nom_Tipo, Area.Nom_Area ")
        StrSQL.Append("FROM TICKET inner join  ")
        StrSQL.Append(" Usuario on Usuario.Cod_User=Ticket.Cod_User ")
        StrSQL.Append(" inner join Tipo_Ticket on  Tipo_Ticket.Cod_Tipo= Ticket.Cod_Tipo ")
        StrSQL.Append(" inner join Area on Area.Cod_Area= Ticket.Cod_Area")

        'Llamamos el objeto de conexion y el metodo especializado en tablas y le mandamos el objetod 
        'TABLA junto con la consulta sql
        ClaseDeConexionMYSQL.FillDataGrid(Me.TablaProductos, StrSQL.ToString)

        'En el encabezado mandamos cuantos registros tenemos en la tabla, mediante el conteo de filas que la tabla tiene
        Me.CajaMesajeHeader.Text = "En la base de datos hay: " & Me.TablaProductos.Rows.Count.ToString() & " Tickets registrados hasta el momento."

    End Sub










    'Evento para insertar o guardar un producto a la base de datos
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ValidarCampos() Then 'Validamos  que todos los campos esten llenos con el metodo de evalucaion
            If ValidarLongitud() Then ' Validamos el tamaño de los campos de texto con el metodo de longitud


                'QUERY para el insert
                StrSQL.Append("insert into Ticket (Titulo_Ticket, Desc_Ticket, Prioridad, User_Creacion, Fecha_Creacion, Cod_User, Cod_Tipo, Cod_Area) ")
                StrSQL.Append(" VALUES('" & Me.TituloTicket.Text.Trim & "','" & Me.DescripcionTicket.Text.Trim & "', '" & Me.Prioridad.Text.Trim & "','" & Session("User_Name").ToString & "',  CURDATE() , '" & Me.InterlocutorDesplegable.Text.Trim & "', '" & Me.TipoDesplegable.Text.Trim & "', '" & Me.AreaDesplegable.Text.Trim & "') ")
                'Me.ClaseDeConexionMYSQL.EjecutarOperacionSQL(StrSQL.ToString)
                'StrSQL.Clear()

                'StrSQL.Append("insert into clase (Clase,Nota,IDEstudiante) ")
                'StrSQL.Append(" VALUES('" & Me.ClaseDesplegable.Text.Trim & "','" & Me.Calificacion.Text.Trim & "','" & Me.ID.Text.Trim & "') ")

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
        StrSQL.Append("update Ticket set  Titulo_Ticket = '" & TituloTicket.Text & "', Desc_Ticket='" & DescripcionTicket.Text & "', Prioridad='" & Prioridad.Text & "', User_Creacion='" & Session("User_Name").ToString & "' , Fecha_Creacion=CURDATE() , Cod_User='" & InterlocutorDesplegable.Text & "' , Cod_Tipo='" & TipoDesplegable.Text & "' , Cod_Area='" & AreaDesplegable.Text & "' where Num_Ticket = '" & NumTicket.Text & "';")
        'Me.ClaseDeConexionMYSQL.EjecutarOperacionSQL(StrSQL.ToString)
        'StrSQL.Clear()



        ''StrSQL.Append("update Clase set  clase = '" & ClaseDesplegable.Text & "', Nota='" & Calificacion.Text & "'  where IDEstudiante = '" & Id.Text & "';")
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
        Com = Me.TablaProductos.Rows(e.RowIndex).Cells(1).Text

        'Preparamos la consulta
        StrSQL.Append("delete from Ticket where Num_Ticket = '" & Com & "'")
        ' Me.ClaseDeConexionMYSQL.EjecutarOperacionSQL(StrSQL.ToString)
        'StrSQL.Clear()


        ' StrSQL.Append("delete from Estudiantes where IDEstudiante = '" & Com & "'")
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
        Dim NoTicket, TituloTicket, Descripcion, prioridad, usuarioCreacion, Correo, rol, Clase, Calificacion As String

        'Obtenemos los datos de la fila seleccionada en las columnas correspondientes
        NoTicket = TablaProductos.SelectedRow.Cells(1).Text
        TituloTicket = TablaProductos.SelectedRow.Cells(2).Text
        Descripcion = TablaProductos.SelectedRow.Cells(3).Text
        prioridad = TablaProductos.SelectedRow.Cells(4).Text
        'usuarioCreacion = TablaProductos.SelectedRow.Cells(5).Text
        'Correo = TablaProductos.SelectedRow.Cells(7).Text
        'rol = TablaProductos.SelectedRow.Cells(8).Text

        'Clase = TablaProductos.SelectedRow.Cells(7).Text
        'Calificacion = TablaProductos.SelectedRow.Cells(8).Text

        'Pasamos estos datos a cada celda del formulario
        Me.NumTicket.Text = NoTicket
        Me.TituloTicket.Text = TituloTicket
        Me.DescripcionTicket.Text = Descripcion
        Me.Prioridad.Text = prioridad
        'Me..Text = apellido
        'Me.Correo.Text = Correo
        'Me.RolDesplegable.Text = rol

    End Sub





    'Validar si los campos estan llenos
    Public Function ValidarCampos() As Boolean
        Dim ban As Boolean = False 'Variable para guardar booleano si los campos estan llenos o no

        If (Me.TipoDesplegable.SelectedIndex > 0) Then
            If (Me.InterlocutorDesplegable.Text.Trim <> "") Then
                If (Me.TipoDesplegable.Text.Trim <> "") Then
                    If (Me.AreaDesplegable.Text.Trim <> "") Then
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
        If (Me.TipoDesplegable.Text.Trim.Length < 100) Then
            If (Me.DescripcionTicket.Text.Trim.Length < 200) Then
                ban = True
            End If
        End If
        Return (ban)
    End Function



    'Para limpiar los campos  despues de alguna operacion
    Public Sub LimpiarCampos()
        Me.TituloTicket.Text = ""
        Me.DescripcionTicket.Text = ""
        Me.Prioridad.Text = ""
        'Me..Text = ""
        StrSQL.Clear()
    End Sub



End Class



