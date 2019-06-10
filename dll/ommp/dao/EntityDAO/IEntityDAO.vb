Namespace dao

    Public Interface IEntityDAO
        Inherits IChangeDAO

        Function Update(ByVal o As Object) As Boolean

        Function Delete(ByVal id As Integer) As Boolean

    End Interface
End Namespace
