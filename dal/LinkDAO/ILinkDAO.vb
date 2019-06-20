Namespace dal.dao
    Public Interface ILinkDAO

        Function Link(ByVal leftId As Integer, ByVal rightId As Integer) As Boolean

        Function UnLink(ByVal leftId As Integer, ByVal rightId As Integer) As Boolean

    End Interface
End Namespace
