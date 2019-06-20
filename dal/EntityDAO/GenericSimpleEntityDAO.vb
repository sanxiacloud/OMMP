Namespace dal.dao

    Public Class GenericSimpleEntityDAO(Of T As New)
        Inherits GenericEntityDAO(Of T)

        Public Function Insert(o As T) As Integer
            Return InsertObject(o)
        End Function

        Public Function Update(o As T) As Boolean
            Return UpdateObject(o)
        End Function

        Public Function Delete(id As Integer) As Boolean
            Return DeleteObject(Of T)(id)
        End Function

    End Class
End Namespace
