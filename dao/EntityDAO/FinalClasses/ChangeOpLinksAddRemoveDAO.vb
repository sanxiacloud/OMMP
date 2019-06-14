Imports ommp.dto
Imports Foxtable
Namespace dao

    Public Class ChangeOpLinksAddRemoveDAO
        Inherits BaseDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Private ReadOnly Property _TABLE_NAME() As String
            Get
                Return ChangeOpLinksAddRemove.TABLE_NAME
            End Get
        End Property

        Public Function Insert(ByVal o As Object) As Boolean

        End Function

    End Class

End Namespace
