Imports ommp.dal.dto

Namespace dal.dao
    Public MustInherit Class IPInterfaceDAO(Of T As New)
        Inherits NetworkInterfaceDAO(Of T)

        Protected Function InsertIPInterface(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As IPInterface = CType(o, IPInterface)
            obj.id = InsertNetworkInterface(o, finalclass)
            Return InsertObject(Of IPInterface)(CType(o, IPInterface))
        End Function

        Protected Function UpdateIPInterface(ByVal o As Object) As Boolean
            Return UpdateNetworkInterface(o) And UpdateObject(Of IPInterface)(CType(o, IPInterface))
        End Function

        Protected Function DeleteIPInterface(ByVal id As Integer) As Boolean
            Return DeleteNetworkInterface(id) And DeleteObject(Of IPInterface)(id)
        End Function

    End Class
End Namespace
