Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class TerrainPiecePreview

    Inherits Control

    Private _piece As TerrainPiece

    Public Sub New()

        DoubleBuffered = True

        BackColor = Color.LightGray

    End Sub


    ' =========================================================
    ' PIECE A AFFICHER
    ' =========================================================

    <DesignerSerializationVisibility(
        DesignerSerializationVisibility.Hidden)>
    Public Property Piece As TerrainPiece

        Get
            Return _piece
        End Get

        Set(value As TerrainPiece)

            _piece = value

            Invalidate()

        End Set

    End Property


    ' =========================================================
    ' DESSIN
    ' =========================================================

    Protected Overrides Sub OnPaint(
        e As PaintEventArgs)

        MyBase.OnPaint(e)

        e.Graphics.Clear(Color.LightGray)

        If _piece Is Nothing Then
            Return
        End If

        If _piece.Cells Is Nothing Then
            Return
        End If

        If _piece.X <= 0 OrElse
           _piece.Y <= 0 Then

            Return

        End If

        DrawPiece(e.Graphics)

    End Sub


    ' =========================================================
    ' DESSIN DE LA PIECE
    ' =========================================================

    Private Sub DrawPiece(
        g As Graphics)

        Dim pieceRectangle As RectangleF =
            GetPieceRectangle()

        If pieceRectangle.IsEmpty Then
            Return
        End If


        ' -----------------------------------------------------
        ' Fond blanc de la grille
        ' -----------------------------------------------------

        Using brush As New SolidBrush(Color.White)

            g.FillRectangle(
                brush,
                pieceRectangle)

        End Using


        ' -----------------------------------------------------
        ' Calcul de la taille d'une cellule
        ' -----------------------------------------------------

        Dim cellWidth As Single =
            pieceRectangle.Width / _piece.Y

        Dim cellHeight As Single =
            pieceRectangle.Height / _piece.X


        ' -----------------------------------------------------
        ' Dessin des cellules
        ' -----------------------------------------------------

        For row As Integer = 0 To _piece.X - 1

            For column As Integer = 0 To _piece.Y - 1

                Dim state As TerrainCellState =
                    _piece.Cells(row, column)

                If state = TerrainCellState.Empty Then

                    Continue For

                End If


                Dim cellRectangle As New RectangleF(
                    pieceRectangle.X +
                        column * cellWidth,
                    pieceRectangle.Y +
                        row * cellHeight,
                    cellWidth,
                    cellHeight)


                Dim cellColor As Color

                Select Case state

                    Case TerrainCellState.Occupied
                        cellColor = Color.Black

                    Case TerrainCellState.Connection
                        cellColor = Color.Red

                    Case Else
                        Continue For

                End Select


                Using brush As New SolidBrush(cellColor)

                    g.FillRectangle(
                        brush,
                        cellRectangle)

                End Using

            Next

        Next


        ' -----------------------------------------------------
        ' Bordure extérieure
        ' -----------------------------------------------------

        Using pen As New Pen(Color.Black, 1.0F)

            g.DrawRectangle(
                pen,
                pieceRectangle.X,
                pieceRectangle.Y,
                pieceRectangle.Width,
                pieceRectangle.Height)

        End Using

    End Sub


    ' =========================================================
    ' CALCUL DU RECTANGLE DE LA PIECE
    ' =========================================================

    Private Function GetPieceRectangle() As RectangleF

        If _piece Is Nothing Then
            Return RectangleF.Empty
        End If

        If _piece.X <= 0 OrElse
           _piece.Y <= 0 Then

            Return RectangleF.Empty

        End If


        Dim pieceHeight As Integer =
            _piece.X

        Dim pieceWidth As Integer =
            _piece.Y


        ' -----------------------------------------------------
        ' Taille maximale disponible
        ' -----------------------------------------------------

        Dim availableWidth As Single =
            ClientSize.Width

        Dim availableHeight As Single =
            ClientSize.Height


        If availableWidth <= 0 OrElse
           availableHeight <= 0 Then

            Return RectangleF.Empty

        End If


        ' -----------------------------------------------------
        ' Même facteur de zoom pour X et Y.
        '
        ' Cela garantit que les cellules restent carrées.
        ' -----------------------------------------------------

        Dim zoomX As Single =
            availableWidth / CSng(pieceWidth)

        Dim zoomY As Single =
            availableHeight / CSng(pieceHeight)

        Dim zoom As Single =
            Math.Min(
                zoomX,
                zoomY)


        ' -----------------------------------------------------
        ' Dimensions réellement affichées
        ' -----------------------------------------------------

        Dim renderedWidth As Single =
            pieceWidth * zoom

        Dim renderedHeight As Single =
            pieceHeight * zoom


        ' -----------------------------------------------------
        ' Centrage dans le contrôle
        ' -----------------------------------------------------

        Dim offsetX As Single =
            (availableWidth - renderedWidth) / 2.0F

        Dim offsetY As Single =
            (availableHeight - renderedHeight) / 2.0F


        Return New RectangleF(
            offsetX,
            offsetY,
            renderedWidth,
            renderedHeight)

    End Function

End Class
