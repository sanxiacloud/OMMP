Imports ommp.dal.dto
Imports Foxtable

Namespace dal.dao

    Public Class BackupsDAO
        Inherits BaseDAO
        Implements IEntityDAO

        Public Function Insert(o As Object) As Integer Implements IEntityDAO.Insert
            Return InsertObject(Of Organization)(o)
        End Function

        Public Function Update(o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateObject(Of Organization)(o)
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteObject(Of Organization)(id)
        End Function

        Public Function Find(ByVal id As Integer) As Organization
            Return FindObject(Of Organization)(id)
        End Function

        Public Function List(ByVal Optional filter As String = "", ByVal Optional sort As String = Nothing) As IList(Of Organization)
            Return FindList(Of Organization)(filter, sort)
        End Function
    End Class

End Namespace
