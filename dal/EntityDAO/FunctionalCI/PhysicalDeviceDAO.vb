Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public MustInherit Class PhysicalDeviceDAO
        Inherits FunctionalCIDAO

        Protected Function InsertPhysicalDevice(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As PhysicalDevice = CType(o, PhysicalDevice)
            obj.id = InsertFunctionalCI(o, finalclass)
            Return InsertObject(Of PhysicalDevice)(CType(o, PhysicalDevice))
        End Function

        Protected Function UpdatePhysicalDevice(ByVal o As Object) As Boolean
            Return UpdateFunctionalCI(o) And UpdateObject(Of PhysicalDevice)(CType(o, PhysicalDevice))
        End Function

        Protected Function DeletePhysicalDevice(ByVal id As Integer) As Boolean
            Return DeleteFunctionalCI(id) And DeleteObject(Of PhysicalDevice)(id)
        End Function
    End Class

End Namespace
