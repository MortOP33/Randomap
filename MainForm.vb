Imports System.Windows.Forms

Public Class MainForm

    Private Sub btnGenerer_Click(sender As Object, e As EventArgs) Handles btnGenerer.Click

        Dim selectedTemplate As MapTemplate = GetSelectedTemplate()

        Dim definition As MapTemplateDefinition =
        MapTemplates.GetDefinition(selectedTemplate)

        MessageBox.Show(
        $"Gabarit : {selectedTemplate}" & vbCrLf &
        $"X : {definition.X}" & vbCrLf &
        $"Y : {definition.Y}" & vbCrLf &
        $"Grille : {definition.HeightCells} × {definition.WidthCells}" & vbCrLf &
        $"Objectif : {definition.ObjectiveSizeCells} cases"
        )

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

End Class