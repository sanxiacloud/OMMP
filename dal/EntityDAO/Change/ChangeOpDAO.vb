Imports ommp.dal.dto

Namespace dal.dao
    Public MustInherit Class ChangeOpDAO(Of T As New)
        Inherits GenericEntityDAO(Of T)

        Protected Function InsertChangeOp(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As ChangeOp = CType(o, ChangeOp)
            obj.objclass = finalclass
            Return InsertObject(Of ChangeOp)(obj)
        End Function

        Protected Function UpdateChangeOp(ByVal o As Object) As Boolean
            Return UpdateObject(Of ChangeOp)(CType(o, ChangeOp))
        End Function

        Protected Function DeleteChangeOp(ByVal id As Integer) As Boolean
            Return DeleteObject(Of ChangeOp)(id)
        End Function

        Protected MustOverride Function BuildJoinTable() As Boolean
    End Class
End Namespace
