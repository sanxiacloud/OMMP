Imports ommp.dal.dto

Namespace dal.dao
    Public MustInherit Class DNSObjectDAO
        Inherits BaseDAO
        Protected Function InsertDNSObject(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As DNSObject = CType(o, DNSObject)
            obj.finalclass = finalclass
            Return InsertObject(Of DNSObject)(obj)
        End Function

        Protected Function UpdateDNSObject(ByVal o As Object) As Boolean
            Return UpdateObject(Of DNSObject)(CType(o, DNSObject))
        End Function

        Protected Function DeleteDNSObject(ByVal id As Integer) As Boolean
            Return DeleteObject(Of DNSObject)(id)
        End Function

        Protected MustOverride Function BuildJoinTable() As Boolean
    End Class
End Namespace