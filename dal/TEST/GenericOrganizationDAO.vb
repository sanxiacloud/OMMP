Imports System.Reflection
Imports ommp.dal.dto
Imports Foxtable

Namespace dal.dao

    Public Class GenericOrganizationDAO
        Implements IGenericEntityDAO(Of Organization)

        Public Function Insert(o As Organization) As Integer Implements IGenericEntityDAO(Of Organization).Insert
            Throw New NotImplementedException()
        End Function

        Public Function Update(o As Organization) As Boolean Implements IGenericEntityDAO(Of Organization).Update
            Throw New NotImplementedException()
        End Function

        Public Function Delete(id As Organization) As Boolean Implements IGenericEntityDAO(Of Organization).Delete
            Throw New NotImplementedException()
        End Function

        Public Function Find(id As Integer) As Organization Implements IGenericEntityDAO(Of Organization).Find
            Throw New NotImplementedException()
        End Function

        Public Function List(Optional filter As String = "", Optional sort As String = Nothing) As IList(Of Organization) Implements IGenericEntityDAO(Of Organization).List
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace
