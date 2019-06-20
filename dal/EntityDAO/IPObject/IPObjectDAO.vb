Imports ommp.dal.dto

Namespace dal.dao
    Public MustInherit Class IPObjectDAO(Of T As New)
        Inherits GenericEntityDAO(Of T)
        Protected Function InsertIPObject(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As IPObject = CType(o, IPObject)
            obj.finalclass = finalclass
            Return InsertObject(Of IPObject)(obj)
        End Function

        Protected Function UpdateIPObject(ByVal o As Object) As Boolean
            Return UpdateObject(Of IPObject)(CType(o, IPObject))
        End Function

        Protected Function DeleteIPObject(ByVal id As Integer) As Boolean
            Return DeleteObject(Of IPObject)(id)
        End Function

        Protected MustOverride Function BuildJoinTable() As Boolean

    End Class
End Namespace
