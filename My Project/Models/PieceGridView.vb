Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class PieceGridView

    Inherits Control

    Private _rows As Integer = 1
    Private _columns As Integer = 1

    Private _cells(,) As TerrainCellState = New TerrainCellState(0, 0) {}

    Public Sub New()

        SetStyle(
            ControlStyles.UserPaint Or
            ControlStyles.AllPaintingInWmPaint Or
            ControlStyles.OptimizedDoubleBuffer Or
            ControlStyles.ResizeRedraw,
            True)

        BackColor = Color.LightGray

        ResizeGrid(_rows, _columns)

    End Sub

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Rows As Integer
        Get
            Return _rows
        End Get
        Set(value As Integer)

            If value < 1 Then
                value = 1
            End If

            If value = _rows Then
                Return
            End If

            ResizeGrid(value, _columns)

        End Set
    End Property

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Columns As Integer
        Get
            Return _columns
        End Get
        Set(value As Integer)

            If value < 1 Then
                value = 1
            End If

            If value = _columns Then
                Return
            End If

            ResizeGrid(_rows, value)

        End Set
    End Property

    Public Sub ResizeGrid(rows As Integer, columns As Integer)

        If rows < 1 Then
            rows = 1
        End If

        If columns < 1 Then
            columns = 1
        End If

        Dim newCells(
            rows - 1,
            columns - 1
        ) As TerrainCellState

        ' Conserver les cellules existantes lorsque
        ' la nouvelle grille est plus grande.
        Dim copyRows As Integer =
            Math.Min(_rows, rows)

        Dim copyColumns As Integer =
            Math.Min(_columns, columns)

        For row As Integer = 0 To copyRows - 1

            For column As Integer = 0 To copyColumns - 1

                newCells(row, column) =
                    _cells(row, column)

            Next

        Next

        _rows = rows
        _columns = columns
        _cells = newCells

        Invalidate()

    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        MyBase.OnPaint(e)

        e.Graphics.Clear(BackColor)

        If _rows <= 0 OrElse _columns <= 0 Then
            Return
        End If

        Dim gridRectangle As RectangleF =
            GetGridRectangle()

        If gridRectangle.IsEmpty Then
            Return
        End If

        DrawGrid(e.Graphics, gridRectangle)

    End Sub

    Private Function GetGridRectangle() As RectangleF

        If ClientSize.Width <= 0 OrElse
           ClientSize.Height <= 0 Then

            Return RectangleF.Empty

        End If

        Dim cellWidth As Single =
            ClientSize.Width / CSng(_columns)

        Dim cellHeight As Single =
            ClientSize.Height / CSng(_rows)

        ' Une cellule doit toujours rester carrée.
        Dim cellSize As Single =
            Math.Min(cellWidth, cellHeight)

        If cellSize <= 0 Then
            Return RectangleF.Empty
        End If

        Dim gridWidth As Single =
            _columns * cellSize

        Dim gridHeight As Single =
            _rows * cellSize

        Dim offsetX As Single =
            (ClientSize.Width - gridWidth) / 2.0F

        Dim offsetY As Single =
            (ClientSize.Height - gridHeight) / 2.0F

        Return New RectangleF(
            offsetX,
            offsetY,
            gridWidth,
            gridHeight)

    End Function

    Private Sub DrawGrid(
        g As Graphics,
        gridRectangle As RectangleF)

        Dim cellWidth As Single =
            gridRectangle.Width / _columns

        Dim cellHeight As Single =
            gridRectangle.Height / _rows

        For row As Integer = 0 To _rows - 1

            For column As Integer = 0 To _columns - 1

                Dim rectangle As New RectangleF(
                    gridRectangle.X + column * cellWidth,
                    gridRectangle.Y + row * cellHeight,
                    cellWidth,
                    cellHeight)

                DrawCell(
                    g,
                    rectangle,
                    _cells(row, column))

            Next

        Next

    End Sub

    Private Sub DrawCell(
        g As Graphics,
        rectangle As RectangleF,
        state As TerrainCellState)

        Dim fillColor As Color

        Select Case state

            Case TerrainCellState.Empty
                fillColor = Color.White

            Case TerrainCellState.Occupied
                fillColor = Color.Black

            Case TerrainCellState.Connection
                fillColor = Color.Red

            Case Else
                fillColor = Color.White

        End Select

        Using brush As New SolidBrush(fillColor)

            g.FillRectangle(
                brush,
                rectangle)

        End Using

        Using pen As New Pen(Color.DarkGray, 1.0F)

            g.DrawRectangle(
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height)

        End Using

    End Sub

End Class
