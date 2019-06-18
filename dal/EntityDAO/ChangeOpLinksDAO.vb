Imports ommp.dal.dto

Namespace dal.dao
    Public Class ChangeOpLinksDAO
        Inherits ChangeOpDAO

        Protected Function InsertChangeOpLinks(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As ChangeOpLinks = CType(o, ChangeOpLinks)
            obj.objclass = finalclass
            Return InsertObject(Of ChangeOpLinks)(obj)
        End Function

        Protected Function UpdateChangeOpLinks(ByVal o As Object) As Boolean
            Return UpdateObject(Of ChangeOpLinks)(CType(o, ChangeOpLinks))
        End Function

        Protected Function DeleteChangeOpLinks(ByVal id As Integer) As Boolean
            Return DeleteObject(Of ChangeOpLinks)(id)
        End Function

    End Class
End Namespace