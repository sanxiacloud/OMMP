Namespace dal.dao

    Public Interface IEntityDAO(Of T)

        Function Insert(ByVal o As T) As Integer

        Function Update(ByVal o As T) As Boolean

        Function Delete(ByVal id As Integer) As Boolean

    End Interface
End Namespace
