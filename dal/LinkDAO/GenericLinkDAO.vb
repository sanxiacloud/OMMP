Namespace dal.dao
    Public Class GenericLinkDAO(Of T As New)
        Inherits BaseDAO

        Protected Shared leftName As String
        Protected Shared rightName As String

        Public Function ListByLeft(id As Integer) As IList(Of T)
            Return FindList(Of T)(String.Format("{0}={1}", leftName, id), C__IDENTIFY)
        End Function

        Public Function ListByRight(id As Integer) As IList(Of T)
            Return FindList(Of T)(String.Format("{0}={1}", rightName, id), C__IDENTIFY)
        End Function

    End Class

End Namespace
