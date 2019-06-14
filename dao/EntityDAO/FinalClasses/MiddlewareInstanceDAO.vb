Imports ommp.dto
Imports Foxtable
Namespace dao

    Public Class MiddlewareInstanceDAO
        Inherits FunctionalCIDAO
        Implements IEntityDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Private ReadOnly Property _TABLE_NAME() As String
            Get
                Return MiddlewareInstance.TABLE_NAME
            End Get
        End Property




        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete

        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert

        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update

        End Function

    End Class

End Namespace