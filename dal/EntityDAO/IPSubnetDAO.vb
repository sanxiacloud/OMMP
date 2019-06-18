Imports ommp.dal.dto

Namespace dal.dao
    Public Class IPSubnetDAO
        Inherits IPObjectDAO

        Protected Function InsertIPSubnet(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As IPSubnet = CType(o, IPSubnet)
            obj.id = InsertIPObject(o, finalclass)
            Return InsertObject(Of IPSubnet)(CType(o, IPSubnet))
        End Function

        Protected Function UpdateIPSubnet(ByVal o As Object) As Boolean
            Return UpdateIPObject(o) And UpdateObject(Of IPSubnet)(CType(o, IPSubnet))
        End Function

        Protected Function DeleteIPSubnet(ByVal id As Integer) As Boolean
            Return DeleteIPObject(id) And DeleteObject(Of IPSubnet)(id)
        End Function

    End Class
End Namespace
