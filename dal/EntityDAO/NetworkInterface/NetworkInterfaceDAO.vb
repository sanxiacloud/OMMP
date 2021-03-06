﻿Imports ommp.dal.dto

Namespace dal.dao
    Public MustInherit Class NetworkInterfaceDAO(Of T As New)
        Inherits GenericEntityDAO(Of T)
        Protected Function InsertNetworkInterface(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As NetworkInterface = CType(o, NetworkInterface)
            obj.finalclass = finalclass
            Return InsertObject(Of NetworkInterface)(obj)
        End Function

        Protected Function UpdateNetworkInterface(ByVal o As Object) As Boolean
            Return UpdateObject(Of NetworkInterface)(CType(o, NetworkInterface))
        End Function

        Protected Function DeleteNetworkInterface(ByVal id As Integer) As Boolean
            Return DeleteObject(Of NetworkInterface)(id)
        End Function

        Protected MustOverride Function BuildJoinTable() As Boolean
    End Class
End Namespace
