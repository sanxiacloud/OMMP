Imports ommp.dto
Imports Foxtable
Namespace dao

    Public Class ConfigAccessDAO
        Inherits BaseDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Private ReadOnly Property _TABLE_NAME() As String
            Get
                Return ConfigAccess.TABLE_NAME
            End Get
        End Property



    End Class

End Namespace
