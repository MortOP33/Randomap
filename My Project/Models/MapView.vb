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
        DrawPlacedPieces(g, mapRectangle)

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

    Private Sub DrawPlacedPieces(g As Graphics, mapRectangle As RectangleF)

        If _generation.PlacedPieces Is Nothing Then
            Return
        End If

        For Each placedPiece As PlacedTerrainPiece In _generation.PlacedPieces
            DrawPlacedPiece(g, mapRectangle, placedPiece)
        Next

    End Sub

    Private Sub DrawPlacedPiece(g As Graphics, mapRectangle As RectangleF, placedPiece As PlacedTerrainPiece)

        Dim piece As TerrainPiece =
        placedPiece.Piece

        Dim mapWidth As Integer =
        _generation.Template.WidthCells

        Dim mapHeight As Integer =
        _generation.Template.HeightCells

        Dim scaleX As Single =
        mapRectangle.Width / mapWidth

        Dim scaleY As Single =
        mapRectangle.Height / mapHeight


        ' =========================================================
        ' PARCOURS DES CELLULES DE LA PIECE
        ' =========================================================

        Dim rotation As PieceRotation = placedPiece.Rotation
        Dim rotatedHeight As Integer
        Dim rotatedWidth As Integer
        If rotation = PieceRotation.Deg0 OrElse rotation = PieceRotation.Deg180 Then
            rotatedHeight = piece.X
            rotatedWidth = piece.Y
        Else
            rotatedHeight = piece.Y
            rotatedWidth = piece.X
        End If

        For row As Integer = 0 To rotatedHeight - 1

            For column As Integer = 0 To rotatedWidth - 1

                Dim state As TerrainCellState = MapPieceGeometry.GetRotatedCellState(piece, row, column, rotation)

                ' -------------------------------------------------
                ' Les cellules vides ne sont pas affichées.
                ' -------------------------------------------------

                If state = TerrainCellState.Empty Then
                    Continue For
                End If


                ' -------------------------------------------------
                ' Position réelle sur la carte
                ' -------------------------------------------------

                Dim mapX As Integer =
                placedPiece.X + row

                Dim mapY As Integer =
                placedPiece.Y + column


                ' -------------------------------------------------
                ' Sécurité : les cellules actives doivent être
                ' dans la carte.
                ' -------------------------------------------------

                If mapX < 0 OrElse
               mapX >= mapHeight OrElse
               mapY < 0 OrElse
               mapY >= mapWidth Then

                    Continue For

                End If


                ' -------------------------------------------------
                ' Conversion vers l'écran
                ' -------------------------------------------------

                Dim screenX As Single =
                mapRectangle.X +
                mapY * scaleX

                Dim screenY As Single =
                mapRectangle.Y +
                mapX * scaleY


                Dim rectangle As New RectangleF(
                screenX,
                screenY,
                scaleX,
                scaleY)


                ' -------------------------------------------------
                ' Couleur
                ' -------------------------------------------------

                ' =========================================================
                ' RENDU SELON LE TYPE DE PIECE
                ' =========================================================

                If piece.Type = TerrainPieceType.ETAGE Then

                    Using brush As New HatchBrush(HatchStyle.ForwardDiagonal, Color.DimGray, Color.LightGray)
                        g.FillRectangle(brush, rectangle)
                    End Using

                Else

                    Dim cellColor As Color

                    Select Case piece.Type

                        Case TerrainPieceType.LEGER

                            cellColor = Color.LightGray

                        Case TerrainPieceType.LOURD

                            cellColor = Color.DimGray

                        Case Else

                            cellColor = Color.DimGray

                    End Select

                    Using brush As New SolidBrush(cellColor)
                        g.FillRectangle(brush, rectangle)
                    End Using

                End If

            Next

        Next

    End Sub

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
