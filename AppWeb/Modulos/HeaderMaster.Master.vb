Public Class Plantilla
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("rol").ToString = "Analista" Then  'SOLO LA PRIMERA VEZ LO HACE
            Me.ModuloAnalista.Visible = True 'Para lista desplegamble
            Me.ModuloInterlocutor.Visible = False
        End If
        If Session("rol").ToString = "Interlocutor" Then  'SOLO LA PRIMERA VEZ LO HACE
            Me.ModuloAnalista.Visible = False 'Para lista desplegamble
            Me.ModuloInterlocutor.Visible = True
        End If
    End Sub



End Class