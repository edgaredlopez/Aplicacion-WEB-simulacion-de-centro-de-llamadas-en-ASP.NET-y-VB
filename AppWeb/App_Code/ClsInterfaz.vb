Public Class ClsInterfaz

    'Evalua el retorno de la base de datos y retorna mensaje segun sea correspondiente
    Public Sub MonstrarMsgBD(ByVal ResultadoBD As String, ByRef pagina As Object)

        Dim MensajeBaseDatos As String
        If (ResultadoBD.Length = 0) Then
            MensajeBaseDatos = "La Operación fue generada exitosamente"
        Else
            MensajeBaseDatos = "Se produjo un error a nivel de base de datos, No se efectuo la operación. Consulte al administrador del sistema"
        End If
        MostrarMensaje(MensajeBaseDatos, pagina)
    End Sub



    ''' <summary>
    ''' Función para mostrar mensajes al usuario mediante un javaScript con un alert
    ''' Nota: usarlo para mensajes cortos y sencillos no para desplegar errores tecnicos del sistema
    ''' </summary>
    ''' <param name="StringMensaje"></param>
    ''' <param name="pagina"></param>
    Public Sub MostrarMensaje(ByVal StringMensaje As String, ByRef pagina As Object)

        If (StringMensaje.Length > 0) Then
            ScriptManager.RegisterClientScriptBlock(
                  pagina,
                  GetType(Page),
                  "ToggleScript",
                  "alert('" & StringMensaje & "')",
                  True)
        End If
    End Sub








    ''' <summary>
    ''' Inserta un elemento en un objeto enviado por referencia con un ID y un valor
    ''' </summary>
    ''' <param name="pObjeto">Objeto listbox o dropdownlist</param>
    ''' <param name="pTexto">Nombre del item a agregar</param>
    ''' <param name="pValor">Valor del item a agregar</param>
    Public Sub InsertarListItem(ByRef pObjeto As Object, ByVal pTexto As String, ByVal pValor As String)
        Dim item As New ListItem With {
            .Value = pValor.Trim,
            .Text = pTexto.Trim
        }
        pObjeto.Items.Add(item)
    End Sub

    ''' <summary>
    ''' Obtiene el nombre de la pagina actual
    ''' </summary>
    ''' <returns>Nombre Página (String)</returns>
    Public Function GetPageName() As String
        Dim arrResult() As String = HttpContext.Current.Request.RawUrl.Split("/")
        Dim result As String = arrResult(arrResult.Length - 1)
        arrResult = result.Split("?")
        Return (arrResult(0))
    End Function
End Class
