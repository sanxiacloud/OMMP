Imports ommp.dto
Imports Foxtable
Namespace dao

    Public Class IPSubnetv4DAO : Inherits BaseDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Protected Overrides ReadOnly Property TABLE_NAME() As String
            Get
                Return IPSubnetv4.TABLE_NAME
            End Get
        End Property


        Protected Overrides Function SetProperties(ByVal dr As DataRow) As Object

            Return Nothing
        End Function

    End Class

End Namespace