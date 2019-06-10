Namespace dao
    Public Interface ILinkDAO

        Function Link(ByVal fromId As Integer, ByVal toId As Integer) As Boolean

        Function UnLink(ByVal fromId As Integer, ByVal toId As Integer) As Boolean

        Function FindList(ByVal filter As String, ByVal sort As String) As IList(Of Object)
    End Interface
End Namespace
