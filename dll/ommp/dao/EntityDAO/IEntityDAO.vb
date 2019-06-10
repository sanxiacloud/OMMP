Namespace dao

    Public Interface IEntityDAO
        Inherits IQueryDAO

        Function Insert(ByVal o As Object) As Boolean

        Function Update(ByVal o As Object) As Boolean

        Function Delete(ByVal id As Integer) As Boolean

    End Interface
End Namespace
