Namespace dal.dao

    Public Class GenericEntityDAO(Of T As New)
        Inherits BaseDAO

        Function Find(id As Integer) As T
            Return FindObject(Of T)(id)
        End Function

        Public Function List(Optional filter As String = "", Optional sort As String = Nothing) As IList(Of T)
            Return FindList(Of T)(filter, sort)
        End Function

    End Class
End Namespace
