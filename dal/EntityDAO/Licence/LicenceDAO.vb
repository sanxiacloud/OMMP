Imports ommp.dal.dto

Namespace dal.dao
    Public MustInherit Class LicenceDAO
        Inherits BaseDAO
        Protected Function InsertLicence(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As Licence = CType(o, Licence)
            obj.finalclass = finalclass
            Return InsertObject(Of Licence)(obj)
        End Function

        Protected Function UpdateLicence(ByVal o As Object) As Boolean
            Return UpdateObject(Of Licence)(CType(o, Licence))
        End Function

        Protected Function DeleteLicence(ByVal id As Integer) As Boolean
            Return DeleteObject(Of Licence)(id)
        End Function

        Protected MustOverride Function BuildJoinTable() As Boolean

    End Class
End Namespace