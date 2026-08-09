Imports System.Windows.Forms

Public Class MainForm

    Private Sub btnGenerer_Click(sender As Object, e As EventArgs) Handles btnGenerer.Click

        Dim selectedTemplate As MapTemplate = GetSelectedTemplate()
        Dim definition As MapTemplateDefinition = MapTemplates.GetDefinition(selectedTemplate)
        Dim generation As MapGeneration = MapTemplateGenerator.Generate(definition)

        mapView.Generation = generation

    End Sub

    Private Function GetSelectedTemplate() As MapTemplate

        If rdoStandard.Checked Then
            Return MapTemplate.Standard
        ElseIf rdoGrand.Checked Then
            Return MapTemplate.Grand
        ElseIf rdoGeant.Checked Then
            Return MapTemplate.Geant
        Else
            Return MapTemplate.Standard
        End If

    End Function

    Private Sub btnAjouterPiece_Click(sender As Object, e As EventArgs) Handles btnAjouterPiece.Click

        Using formPiece As New PieceEditorForm()

            formPiece.ShowDialog(Me)

        End Using

    End Sub

End Class