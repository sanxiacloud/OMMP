Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class DataCenterDeviceDAO
        Inherits ConnectableCIDAO


        Protected Function InsertDataCenterDevice(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As DataCenterDevice = CType(o, DataCenterDevice)
            obj.id = InsertConnectableCI(o, finalclass)
            Return InsertObject(Of ommp.dal.dto.DataCenterDevice)(CType(o, DataCenterDevice))
        End Function

        Protected Function UpdateDataCenterDevice(ByVal o As Object) As Boolean
            Return UpdateConnectableCI(o) And UpdateObject(Of DataCenterDevice)(CType(o, DataCenterDevice))
        End Function

        Protected Function DeleteDataCenterDevice(ByVal id As Integer) As Boolean
            Return DeleteConnectableCI(id) And DeleteObject(Of DataCenterDevice)(id)
        End Function

    End Class

End Namespace
