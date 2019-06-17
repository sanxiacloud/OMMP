Imports ommp.dal.dto
Imports Foxtable

Namespace dal.dao
    Public Class VirtualHostDAO
        Inherits VirtualDeviceDAO

        Private Const _TABLE_NAME = VirtualHost.TABLE_NAME

        Protected Function InsertVirtualHost(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As VirtualHost = CType(o, VirtualHost)
            obj.id = InsertVirtualDevice(o, finalclass)
            Return InsertObject(Of ommp.dal.dto.VirtualHost)(CType(o, VirtualHost))
        End Function

        Protected Function UpdateVirtualHost(ByVal o As Object) As Boolean
            Return UpdateVirtualDevice(o) And UpdateObject(Of VirtualHost)(CType(o, VirtualHost))
        End Function

        Protected Function DeleteVirtualHost(ByVal id As Integer) As Boolean
            Return DeleteVirtualDevice(id) And DeleteObject(Of VirtualHost)(id)
        End Function

    End Class

End Namespace
