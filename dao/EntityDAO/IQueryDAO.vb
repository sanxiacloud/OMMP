Namespace dao

    Public Interface IQueryDAO

        Function FindObject(ByVal id As Integer) As Object

        Function FindList(ByVal filter As String, ByVal sort As String) As IList(Of Object)

    End Interface
End Namespace
