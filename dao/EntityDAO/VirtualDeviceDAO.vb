Imports ommp.dto
Imports Foxtable

Namespace dao
    Public MustInherit Class VirtualDeviceDAO
        Inherits FunctionalCIDAO

        Private Const _TABLE_NAME = VirtualDevice.TABLE_NAME

        Protected Function InsertVirtualDevice(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As VirtualDevice = CType(o, VirtualDevice)
            Dim result As Boolean = False

            Try
                Dim identify As Integer = InsertFunctionalCI(o, finalclass)

                Dim dr As DataRow = DataTables(_TABLE_NAME).AddNew()

                dr(C_ID) = identify
                dr(C__ISDELETED) = False
                dr(VirtualDevice.C_CODE_VIRTUALDEVICE_STATUS) = obj.code_virtualdevice_status

                dr.Save()

                result = True
            Catch ex As Exception
                Output.Show(_TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        Protected Function UpdateVirtualDevice(ByVal o As Object) As Boolean
            Dim obj As VirtualDevice = CType(o, VirtualDevice)
            Dim result As Boolean = False

            Try
                Dim result1 As Boolean = UpdateFunctionalCI(o)

                Dim dr As DataRow = DataTables(_TABLE_NAME).Find(VirtualDevice.C_ID & " = " & obj._Identify)
                Dim result2 As Boolean = False
                If dr IsNot Nothing Then
                    If obj.code_virtualdevice_status >= 0 Then
                        dr(VirtualDevice.C_CODE_VIRTUALDEVICE_STATUS) = obj.code_virtualdevice_status
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

        Protected Function DeleteVirtualDevice(ByVal id As Integer) As Boolean

            Return DeleteFunctionalCI(id) And DeleteObject(_TABLE_NAME, id)

        End Function
    End Class

End Namespace
