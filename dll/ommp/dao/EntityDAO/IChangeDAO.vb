Namespace dao

    Public Interface IChangeDAO

        Function Insert(ByVal o As Object) As Boolean

        Function FindObject(ByVal id As Integer) As Object

        Function FindList(ByVal filter As String, ByVal sort As String) As IList(Of Object)

    End Interface
End Namespace
