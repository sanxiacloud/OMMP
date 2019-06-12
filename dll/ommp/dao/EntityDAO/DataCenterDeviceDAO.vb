Imports ommp.dto
Imports Foxtable
Namespace dao

    Public MustInherit Class DataCenterDeviceDAO
        Inherits ConnectableCIDAO


        Private Const _TABLE_NAME = DataCenterDevice.TABLE_NAME

        Protected Function InsertDataCenterDevice(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As DataCenterDevice = CType(o, DataCenterDevice)
            Dim result As Boolean = False

            Try
                Dim identify As Integer = InsertConnectableCI(o, finalclass)

                Dim dr As DataRow = DataTables(_TABLE_NAME).AddNew()

                dr(C_ID) = identify
                dr(C__ISDELETED) = False
                dr(DataCenterDevice.C_ENCLOSURE_IDENTITY) = obj.enclosure_identity
                dr(DataCenterDevice.C_MANAGEMENTIP) = obj.managementip
                dr(DataCenterDevice.C_NB_U) = obj.nb_u
                dr(DataCenterDevice.C_RACK_IDENTIFY) = obj.rack_identify
                dr(DataCenterDevice.C_REDUNDANCY) = obj.redundancy

                dr.Save()

                result = True
            Catch ex As Exception
                Output.Show(_TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        Protected Function UpdateDataCenterDevice(ByVal o As Object) As Boolean
            Dim obj As DataCenterDevice = CType(o, DataCenterDevice)
            Dim result As Boolean = False

            Try
                Dim result1 As Boolean = UpdateConnectableCI(o)

                Dim dr As DataRow = DataTables(_TABLE_NAME).Find(C_ID & " = " & obj.Identify)
                Dim result2 As Boolean = False
                If dr IsNot Nothing Then
                    If obj.enclosure_identity >= 0 Then
                        dr(DataCenterDevice.C_ENCLOSURE_IDENTITY) = obj.enclosure_identity
                    End If
                    If obj.managementip >= 0 Then
                        dr(DataCenterDevice.C_MANAGEMENTIP) = obj.managementip
                    End If
                    If obj.nb_u >= 0 Then
                        dr(DataCenterDevice.C_NB_U) = obj.nb_u
                    End If
                    If obj.rack_identify >= 0 Then
                        dr(DataCenterDevice.C_RACK_IDENTIFY) = obj.rack_identify
                    End If
                    If obj.redundancy IsNot Nothing Then
                        dr(DataCenterDevice.C_REDUNDANCY) = obj.redundancy
                    End If

                    dr.Save()
                    result2 = True

                End If

                result = result1 And result2
            Catch ex As Exception
                Output.Show(_TABLE_NAME & "->Update:" & ex.Message)
            End Try

            Return result
        End Function

        Protected Function DeleteDataCenterDevice(ByVal id As Integer) As Boolean

            Return DeleteConnectableCI(id) And DeleteObject(_TABLE_NAME, id)

        End Function


    End Class

End Namespace
