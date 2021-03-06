﻿Imports ommp.dal.dto

Namespace dal.dao
    Public MustInherit Class VirtualDeviceDAO(Of T As New)
        Inherits FunctionalCIDAO(Of T)

        Protected Function InsertVirtualDevice(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As VirtualDevice = CType(o, VirtualDevice)
            obj.id = InsertFunctionalCI(o, finalclass)
            Return InsertObject(Of ommp.dal.dto.VirtualDevice)(CType(o, VirtualDevice))
        End Function

        Protected Function UpdateVirtualDevice(ByVal o As Object) As Boolean
            Return UpdateFunctionalCI(o) And UpdateObject(Of VirtualDevice)(CType(o, VirtualDevice))
        End Function

        Protected Function DeleteVirtualDevice(ByVal id As Integer) As Boolean
            Return DeleteFunctionalCI(id) And DeleteObject(Of VirtualDevice)(id)
        End Function

    End Class

End Namespace
