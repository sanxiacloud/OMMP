Imports ommp.dal.dto

Namespace dal.dao
    Public MustInherit Class ContractDAO
        Inherits BaseDAO
        Protected Function InsertContract(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As Contract = CType(o, Contract)
            obj.finalclass = finalclass
            Return InsertObject(Of Contract)(obj)
        End Function

        Protected Function UpdateContract(ByVal o As Object) As Boolean
            Return UpdateObject(Of Contract)(CType(o, Contract))
        End Function

        Protected Function DeleteContract(ByVal id As Integer) As Boolean
            Return DeleteObject(Of Contract)(id)
        End Function

        Protected MustOverride Function BuildJoinTable() As Boolean
    End Class
End Namespace