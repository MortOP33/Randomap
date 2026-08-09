Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class MapView

    Inherits Control

    Private _generation As MapGeneration

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        MyBase.OnPaint(e)

        e.Graphics.Clear(Color.LightGray)

        If _generation Is Nothing Then
            Return
        End If

        DrawMap(e.Graphics)

    End Sub

    Private Sub DrawMap(g As Graphics)

        Dim mapRectangle As RectangleF = GetMapRectangle()

        If mapRectangle.IsEmpty Then
            Return
        End If

        Using mapBrush As New SolidBrush(Color.White)

            g.FillRectangle(
            mapBrush,
            mapRectangle)

        End Using

        DrawInsertionZones(g, mapRectangle)
        DrawObjectiveZones(g, mapRectangle)

    End Sub

    Private Sub DrawInsertionZones(g As Graphics, mapRectangle As RectangleF)

        Using brush As New SolidBrush(Color.LightBlue)

            For Each zone In _generation.InsertionZones

                Dim rectangle As RectangleF = ToScreenRectangleInsertion(zone, mapRectangle)

                g.FillRectangle(brush, rectangle)

            Next

        End Using

    End Sub

    Private Function ToScreenRectangleInsertion(zone As InsertionZone, mapRectangle As RectangleF) As RectangleF

        Dim mapWidth As Integer =
        _generation.Template.WidthCells

        Dim mapHeight As Integer =
        _generation.Template.HeightCells

        Dim scaleX As Single =
        mapRectangle.Width / mapWidth

        Dim scaleY As Single =
        mapRectangle.Height / mapHeight

        Return New RectangleF(
        mapRectangle.X + zone.Y * scaleX,
        mapRectangle.Y + zone.X * scaleY,
        zone.Width * scaleX,
        zone.Height * scaleY)

    End Function

    Private Sub DrawObjectiveZones(g As Graphics, mapRectangle As RectangleF)

        Using brush As New SolidBrush(Color.LightGreen)

            For Each zone In _generation.ObjectiveZones

                Dim rectangle As RectangleF =
                ToScreenRectangleObjective(zone, mapRectangle)

                g.FillRectangle(brush, rectangle)

            Next

        End Using

    End Sub

    Private Function ToScreenRectangleObjective(zone As ObjectiveZone, mapRectangle As RectangleF) As RectangleF

        Dim mapWidth As Integer =
        _generation.Template.WidthCells

        Dim mapHeight As Integer =
        _generation.Template.HeightCells

        Dim scaleX As Single =
        mapRectangle.Width / mapWidth

        Dim scaleY As Single =
        mapRectangle.Height / mapHeight

        Return New RectangleF(
        mapRectangle.X + zone.Y * scaleX,
        mapRectangle.Y + zone.X * scaleY,
        zone.Size * scaleX,
        zone.Size * scaleY)

    End Function

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Generation As MapGeneration
        Get
            Return _generation
        End Get
        Set(value As MapGeneration)
            _generation = value
            Invalidate()
        End Set
    End Property

    Private Function GetMapRectangle() As RectangleF

        Dim mapHeight As Integer = _generation.Template.HeightCells
        Dim mapWidth As Integer = _generation.Template.WidthCells

        If mapHeight <= 0 OrElse mapWidth <= 0 Then
            Return RectangleF.Empty
        End If

        Dim zoomX As Single = ClientSize.Width / CSng(mapWidth)
        Dim zoomY As Single = ClientSize.Height / CSng(mapHeight)

        Dim zoom As Single = Math.Min(zoomX, zoomY)

        Dim renderedWidth As Single = mapWidth * zoom
        Dim renderedHeight As Single = mapHeight * zoom

        Dim offsetX As Single =
            (ClientSize.Width - renderedWidth) / 2.0F

        Dim offsetY As Single =
            (ClientSize.Height - renderedHeight) / 2.0F

        Return New RectangleF(
            offsetX,
            offsetY,
            renderedWidth,
            renderedHeight)

    End Function

End Class
