Namespace dao

    Public Interface IEntityDAO

        Function Insert(ByVal o As Object) As Boolean

        Function Update(ByVal o As Object) As Boolean

        Function Delete(ByVal id As Integer) As Boolean

        Function FindObject(ByVal id As Integer) As Object

        Function FindList(ByVal filter As String, ByVal sort As String) As IList(Of Object)

    End Interface
End Namespace
