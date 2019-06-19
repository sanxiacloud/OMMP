Imports ommp.dal.dto

Namespace dal.dao
    Public MustInherit Class TypologyDAO
        Inherits BaseDAO
        Protected Function InsertTypology(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As Typology = CType(o, Typology)
            obj.finalclass = finalclass
            Return InsertObject(Of Typology)(obj)
        End Function

        Protected Function UpdateTypology(ByVal o As Object) As Boolean
            Return UpdateObject(Of Typology)(CType(o, Typology))
        End Function

        Protected Function DeleteTypology(ByVal id As Integer) As Boolean
            Return DeleteObject(Of Typology)(id)
        End Function

        Protected MustOverride Function BuildJoinTable() As Boolean
    End Class
End Namespace
