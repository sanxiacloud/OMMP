Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class LnkPasswdToFunctionalCIDAO : Inherits BaseDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Private ReadOnly Property _TABLE_NAME() As String
            Get
                Return LnkPasswdToFunctionalCI.TABLE_NAME
            End Get
        End Property




    End Class

End Namespace