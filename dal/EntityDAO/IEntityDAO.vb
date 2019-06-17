Namespace dal.dao

    Public Interface IEntityDAO

        Function Insert(ByVal o As Object) As Integer

        Function Update(ByVal o As Object) As Boolean

        Function Delete(ByVal id As Integer) As Boolean

    End Interface
End Namespace
