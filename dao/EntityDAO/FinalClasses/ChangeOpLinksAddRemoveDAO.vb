Imports ommp.dto
Imports Foxtable
Namespace dao

    Public Class ChangeOpLinksAddRemoveDAO
        Inherits BaseDAO
        Implements IQueryDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Protected Overrides ReadOnly Property TABLE_NAME() As String
            Get
                Return ChangeOpLinksAddRemove.TABLE_NAME
            End Get
        End Property

        Protected Overrides Function SetProperties(ByVal dr As DataRow) As Object

            Return Nothing
        End Function


        Public Function Insert(ByVal o As Object) As Boolean

        End Function

        Public Function FindList(ByVal filter As String, ByVal sort As String) As System.Collections.Generic.IList(Of Object) Implements IQueryDAO.FindList
            Return FindRows(TABLE_NAME, filter, sort)
        End Function

        Public Function FindObject(ByVal id As Integer) As Object Implements IQueryDAO.FindObject
            Return FindRow(TABLE_NAME, id)
        End Function
    End Class

End Namespace
