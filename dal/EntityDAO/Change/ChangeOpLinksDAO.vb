﻿Imports ommp.dal.dto

Namespace dal.dao
    Public MustInherit Class ChangeOpLinksDAO(Of T As New)
        Inherits ChangeOpDAO(Of T)

        Protected Function InsertChangeOpLinks(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As ChangeOpLinks = CType(o, ChangeOpLinks)
            obj.objclass = finalclass
            Return InsertObject(Of ChangeOpLinks)(obj)
        End Function


    End Class
End Namespace