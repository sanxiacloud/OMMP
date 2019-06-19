Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public MustInherit Class ConnectableCIDAO
        Inherits PhysicalDeviceDAO

        Protected Function InsertConnectableCI(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As ConnectableCI = CType(o, ConnectableCI)
            obj.id = InsertPhysicalDevice(o, finalclass)
            Return InsertObject(Of ommp.dal.dto.ConnectableCI)(CType(o, ConnectableCI))
        End Function

        Protected Function UpdateConnectableCI(ByVal o As Object) As Boolean
            Return UpdatePhysicalDevice(o) And UpdateObject(Of ConnectableCI)(CType(o, ConnectableCI))
        End Function

        Protected Function DeleteConnectableCI(ByVal id As Integer) As Boolean
            Return DeletePhysicalDevice(id) And DeleteObject(Of ConnectableCI)(id)
        End Function
    End Class
End Namespace
