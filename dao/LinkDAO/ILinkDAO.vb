Namespace dao
    Public Interface ILinkDAO

        Function Link(ByVal fromId As Integer, ByVal toId As Integer) As Boolean

        Function UnLink(ByVal fromId As Integer, ByVal toId As Integer) As Boolean

    End Interface
End Namespace
