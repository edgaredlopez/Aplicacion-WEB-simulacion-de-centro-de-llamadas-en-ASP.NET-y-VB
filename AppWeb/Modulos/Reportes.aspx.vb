Public Class FormularioReporte
    Inherits System.Web.UI.Page


    Dim ObjClient As New ClsInterfaz() 'Importar clase de validaciones y mensajes
    Dim ClaseDeConexionMYSQL As New ClsConexionMySQL() 'Importar clase de conexion y operaciones de bd

    Dim StrSQL As New StringBuilder

    'Metodos a ejecutar cuando se inicia la pagina o carga la pagina
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack Then  'SOLO LA PRIMERA VEZ LO HACE

            Me.fechainicial.Text = "2022-06-18"
            Me.fechafinal.Text = "2022-06-18"
            Me.CargarReporteTickets() 'Para lista desplegamble
        End If

    End Sub


    'Para actualizar el resultado de la TABLA
    Public Sub CargarReporteTickets()
        'String con consulta para traer datos a la tabla

        StrSQL.Append("SELECT Num_Ticket, Area.Nom_Area, Tipo_Ticket.Nom_Tipo, Titulo_Ticket, Usuario.User_Name, User_Creacion, Fecha_Creacion , Desc_Ticket, Prioridad ")

        StrSQL.Append(" FROM TICKET inner join  ")
        StrSQL.Append(" Usuario on Usuario.Cod_User=Ticket.Cod_User ")
        StrSQL.Append(" inner join Tipo_Ticket on  Tipo_Ticket.Cod_Tipo= Ticket.Cod_Tipo ")
        StrSQL.Append(" inner join Area on Area.Cod_Area= Ticket.Cod_Area ")


        StrSQL.Append("WHERE (TICKET.Num_Ticket Like '%" + Me.CajaFiltroReporte.Text.Trim + "%' AND Usuario.User_Name='" + Session("User_Name") + "')  AND (Fecha_Creacion BETWEEN '" + Me.fechainicial.Text.Trim + "' AND '" + Me.fechafinal.Text.Trim + "')")




        'StrSQL.Append("Select Estudiantes.IDEstudiante,estudiantes.Nombre, Estudiantes.Anio, Estudiantes.Grado, Estudiantes. Seccion, Clase.clase, Clase.Nota from Estudiantes  INNER JOIN Clase On clase.IDEstudiante=Estudiantes.IDEstudiante")
        'StrSQL.Append("WHERE estudiantes.Nombre Like '%Laynez%';")

        'Llamamos el objeto de conexion y el metodo especializado en tablas y le mandamos el objetod 
        'TABLA junto con la consulta sql
        ClaseDeConexionMYSQL.FillDataGrid(Me.TablaReportes, StrSQL.ToString)

        'En el encabezado mandamos cuantos registros tenemos en la tabla, mediante el conteo de filas que la tabla tiene
        Me.CajaMesajeHeaderReporte.Text = "En la base de datos hay: " & Me.TablaReportes.Rows.Count.ToString() & " tickets registrados para usted hasta el momento."

    End Sub


    'PARA ELMIMINAR UN REGISTRO EN LA TABLA
    Protected Sub Productos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles TablaReportes.RowDeleting

        'Declaramos variable para guardar el ID DEL PRODUCTO 
        Dim Com As String

        'Obtenemos el ID del producto
        Com = Me.TablaReportes.Rows(e.RowIndex).Cells(1).Text

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

        Me.CargarReporteTickets()
    End Sub


    Protected Sub CajaFiltroReporte_TextChanged(sender As Object, e As EventArgs) Handles CajaFiltroReporte.TextChanged
        CargarReporteTickets()

    End Sub

    Protected Sub TablaReportes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TablaReportes.SelectedIndexChanged

    End Sub

    Protected Sub BUSCARFILTRO_Click(sender As Object, e As EventArgs) Handles BUSCARFILTRO.Click
        CargarReporteTickets()
    End Sub
End Class



