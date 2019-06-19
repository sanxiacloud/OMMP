Namespace dal.dao

    Public Interface IGenericEntityDAO(Of T)

        Function Insert(ByVal o As T) As Integer

        Function Update(ByVal o As T) As Boolean

        Function Delete(ByVal id As T) As Boolean

        Function Find(ByVal id As Integer) As T

        Function List(ByVal Optional filter As String = "", ByVal Optional sort As String = Nothing) As IList(Of T)
    End Interface
End Namespace
