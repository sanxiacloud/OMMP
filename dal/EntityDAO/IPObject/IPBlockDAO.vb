Imports ommp.dal.dto

Namespace dal.dao
    Public MustInherit Class IPBlockDAO(Of T As New)
        Inherits IPObjectDAO(Of T)

        Protected Function InsertIPBlock(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As IPBlock = CType(o, IPBlock)
            obj.id = InsertIPObject(o, finalclass)
            Return InsertObject(Of ommp.dal.dto.IPBlock)(CType(o, IPBlock))
        End Function

        Protected Function UpdateIPBlock(ByVal o As Object) As Boolean
            Return UpdateIPObject(o) And UpdateObject(Of IPBlock)(CType(o, IPBlock))
        End Function

        Protected Function DeleteIPBlock(ByVal id As Integer) As Boolean
            Return DeleteIPObject(id) And DeleteObject(Of IPBlock)(id)
        End Function

    End Class
End Namespace
