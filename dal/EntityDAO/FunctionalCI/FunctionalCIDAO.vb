Imports ommp.dal.dto

Namespace dal.dao
    Public MustInherit Class FunctionalCIDAO(Of T As New)
        Inherits GenericEntityDAO(Of T)

        Protected Function InsertFunctionalCI(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As FunctionalCI = CType(o, FunctionalCI)
            obj.finalclass = finalclass
            Return InsertObject(Of ommp.dal.dto.FunctionalCI)(obj)
        End Function

        Protected Function UpdateFunctionalCI(ByVal o As Object) As Boolean
            Return UpdateObject(Of FunctionalCI)(CType(o, FunctionalCI))
        End Function

        Protected Function DeleteFunctionalCI(ByVal id As Integer) As Boolean
            Return DeleteObject(Of FunctionalCI)(id)
        End Function

        Protected MustOverride Function BuildJoinTable() As Boolean
    End Class
End Namespace

