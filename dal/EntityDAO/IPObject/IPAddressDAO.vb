Imports ommp.dal.dto

Namespace dal.dao
    Public MustInherit Class IPAddressDAO
        Inherits IPObjectDAO

        Protected Function InsertIPAddress(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As IPAddress = CType(o, IPAddress)
            obj.id = InsertIPObject(o, finalclass)
            Return InsertObject(Of IPAddress)(CType(o, IPAddress))
        End Function

        Protected Function UpdateIPAddress(ByVal o As Object) As Boolean
            Return UpdateIPObject(o) And UpdateObject(Of IPAddress)(CType(o, IPAddress))
        End Function

        Protected Function DeleteIPAddress(ByVal id As Integer) As Boolean
            Return DeleteIPObject(id) And DeleteObject(Of IPAddress)(id)
        End Function

    End Class
End Namespace