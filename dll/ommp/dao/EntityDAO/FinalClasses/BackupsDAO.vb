Namespace dao

    Public Class BackupsDAO
        Inherits BaseDAO
        Implements IEntityDAO


        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete

        End Function

        Public Function FindList(ByVal filter As String, ByVal sort As String) As System.Collections.Generic.IList(Of Object) Implements IEntityDAO.FindList
            Return Nothing
        End Function

        Public Function FindObject(ByVal id As Integer) As Object Implements IEntityDAO.FindObject
            Return Nothing
        End Function

        Public Function Insert(ByVal o As Object) As Boolean Implements IEntityDAO.Insert

        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update

        End Function
    End Class

End Namespace
