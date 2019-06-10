Namespace dao

    Public Class ChangeOpLinksAddRemoveDAO
        Inherits BaseDAO
        Implements IChangeDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub


        Public Function FindList(ByVal filter As String, ByVal sort As String) As System.Collections.Generic.IList(Of Object) Implements IChangeDAO.FindList
            ' TODO : 返回一个对象列表，需要联合查询

            Return Nothing
        End Function

        Public Function FindObject(ByVal id As Integer) As Object Implements IChangeDAO.FindObject
            ' TODO : 返回一个对象，需要联合查询

            Return Nothing
        End Function

        Public Function Insert(ByVal o As Object) As Boolean Implements IChangeDAO.Insert

        End Function
    End Class

End Namespace
