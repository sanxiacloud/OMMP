Namespace dal.dao

    Public Interface IBaseDAO

        Function InsertObject(Of T As New)(ByVal item As T) As Integer

        Function UpdateObject(Of T As New)(ByVal item As T) As Boolean

        Function DeleteObject(Of T As New)(ByVal id As Integer) As Boolean

        Function FindObject(Of T As {New})(ByVal id As Integer) As T

        Function FindObject(Of T As New)(ByVal id As String) As T

        Function FindList(Of T As {New})(ByVal filter As String, ByVal sort As String) As System.Collections.Generic.IList(Of T)

    End Interface
End Namespace
