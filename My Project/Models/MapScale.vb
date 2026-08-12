Public Module MapScale

    Public Const CellsPerInch As Integer = 4

    Public Const InsertionDepthXInches As Integer = 6

    Public Const InsertionDepthYInches As Integer = 3

    Public ReadOnly Property InsertionDepthXCells As Integer
        Get
            Return InsertionDepthXInches * CellsPerInch
        End Get
    End Property

    Public ReadOnly Property InsertionDepthYCells As Integer
        Get
            Return InsertionDepthYInches * CellsPerInch
        End Get
    End Property

End Module
