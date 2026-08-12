Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class PieceGridView

    Inherits Control

    Private _rows As Integer = 1
    Private _columns As Integer = 1

    Private _cells(,) As TerrainCellState = New TerrainCellState(0, 0) {}

    Private _isDrawing As Boolean = False
    Private _drawingButton As MouseButtons = MouseButtons.None
    Private _drawingState As TerrainCellState = TerrainCellState.Empty
    Private _lastDrawingCell As Point? = Nothing

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

    Private Function GetCellAt(location As Point) As Point?

        Dim gridRectangle As RectangleF =
            GetGridRectangle()

        If gridRectangle.IsEmpty Then
            Return Nothing
        End If

        If Not gridRectangle.Contains(location) Then
            Return Nothing
        End If

        Dim cellWidth As Single =
            gridRectangle.Width / _columns

        Dim cellHeight As Single =
            gridRectangle.Height / _rows

        Dim column As Integer =
            CInt(Math.Floor(
                (location.X - gridRectangle.X) / cellWidth))

        Dim row As Integer =
            CInt(Math.Floor(
                (location.Y - gridRectangle.Y) / cellHeight))

        If row < 0 OrElse row >= _rows Then
            Return Nothing
        End If

        If column < 0 OrElse column >= _columns Then
            Return Nothing
        End If

        Return New Point(column, row)

    End Function

    Private Sub SetCellState(cell As Point, state As TerrainCellState)

        Dim column As Integer = cell.X
        Dim row As Integer = cell.Y

        If row < 0 OrElse row >= _rows Then
            Return
        End If

        If column < 0 OrElse column >= _columns Then
            Return
        End If

        If _cells(row, column) = state Then
            Return
        End If

        _cells(row, column) = state

        Invalidate()

    End Sub

    Public Sub SetCells(cells As TerrainCellState(,))

        If cells Is Nothing Then
            Return
        End If

        Dim rows As Integer =
        cells.GetLength(0)

        Dim columns As Integer =
        cells.GetLength(1)

        Me.Rows = rows
        Me.Columns = columns

        For row As Integer = 0 To rows - 1

            For column As Integer = 0 To columns - 1

                _cells(row, column) =
                cells(row, column)

            Next

        Next

        Invalidate()

    End Sub

    Private Function GetNextCellState(currentState As TerrainCellState, button As MouseButtons) As TerrainCellState

        If button = MouseButtons.Left Then

            Select Case currentState

                Case TerrainCellState.Empty
                    Return TerrainCellState.Occupied

                Case TerrainCellState.Occupied
                    Return TerrainCellState.Empty

                Case TerrainCellState.Connection
                    Return TerrainCellState.Occupied

                Case Else
                    Return TerrainCellState.Empty

            End Select

        End If

        If button = MouseButtons.Right Then

            Select Case currentState

                Case TerrainCellState.Empty
                    Return TerrainCellState.Connection

                Case TerrainCellState.Occupied
                    Return TerrainCellState.Connection

                Case TerrainCellState.Connection
                    Return TerrainCellState.Empty

                Case Else
                    Return TerrainCellState.Empty

            End Select

        End If

        Return currentState

    End Function

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)

        MyBase.OnMouseDown(e)

        If e.Button <> MouseButtons.Left AndAlso
       e.Button <> MouseButtons.Right Then

            Return
        End If

        Dim cell As Point? =
        GetCellAt(e.Location)

        If Not cell.HasValue Then
            Return
        End If

        ' Début d'un nouveau geste
        _isDrawing = True
        _drawingButton = e.Button

        Dim currentState As TerrainCellState =
        _cells(
            cell.Value.Y,
            cell.Value.X)

        ' Le premier clic détermine le pinceau
        _drawingState =
        GetNextCellState(
            currentState,
            _drawingButton)

        ' Appliquer immédiatement le pinceau
        SetCellState(
        cell.Value,
        _drawingState)

        ' Mémoriser la dernière cellule traversée
        _lastDrawingCell = cell.Value

    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)

        MyBase.OnMouseMove(e)

        If Not _isDrawing Then
            Return
        End If

        Dim cell As Point? =
        GetCellAt(e.Location)

        If Not cell.HasValue Then
            Return
        End If

        ' La souris est toujours dans la même cellule
        If _lastDrawingCell.HasValue AndAlso
       _lastDrawingCell.Value = cell.Value Then

            Return
        End If

        ' Nouvelle cellule :
        ' on applique le même état que celui déterminé
        ' par le clic initial.
        SetCellState(
        cell.Value,
        _drawingState)

        _lastDrawingCell = cell.Value

    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)

        MyBase.OnMouseUp(e)

        If e.Button <> MouseButtons.Left AndAlso
       e.Button <> MouseButtons.Right Then

            Return
        End If

        _isDrawing = False
        _drawingButton = MouseButtons.None
        _drawingState = TerrainCellState.Empty
        _lastDrawingCell = Nothing

    End Sub

    Private Sub ApplyDrawingToCell(cell As Point)

        Dim currentState As TerrainCellState = _cells(cell.Y, cell.X)

        Dim newState As TerrainCellState = GetNextCellState(currentState, _drawingButton)

        SetCellState(cell, newState)

    End Sub

    Public Function GetCellsCopy() As TerrainCellState(,)

        Dim result(
            _rows - 1,
            _columns - 1
        ) As TerrainCellState

        For row As Integer = 0 To _rows - 1

            For column As Integer = 0 To _columns - 1

                result(row, column) =
                    _cells(row, column)

            Next

        Next

        Return result

    End Function

End Class
