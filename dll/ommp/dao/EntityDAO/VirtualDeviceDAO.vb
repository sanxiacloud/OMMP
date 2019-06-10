Imports ommp.dto
Imports Foxtable

Namespace dao
    Public Class VirtualDeviceDAO
        Inherits FunctionalCIDAO

        Private Const TABLE_NAME As String = VirtualDevice.TABLE_NAME

        Protected Function InsertVirtualDevice(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As VirtualDevice = CType(o, VirtualDevice)
            Dim result As Boolean = False

            Try
                Dim identify As Integer = InsertFunctionalCI(o, finalclass)

                Dim dr As DataRow = DataTables(TABLE_NAME).AddNew()

                dr(VirtualDevice.C_ID) = identify
                dr(VirtualDevice.C_CODE_VIRTUALDEVICE_STATUS) = obj.code_virtualdevice_status
                If obj.IsDeleted = True Or obj.IsDeleted = False Then
                    dr(VirtualDevice.C__ISDELETED) = obj.IsDeleted
                Else
                    dr(VirtualDevice.C__ISDELETED) = False
                End If

                dr.Save()

                result = True
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        Protected Function UpdateVirtualDevice(ByVal o As Object) As Boolean
            Dim obj As VirtualDevice = CType(o, VirtualDevice)
            Dim result As Boolean = False

            Try
                Dim result1 As Boolean = UpdateFunctionalCI(o)

                Dim dr As DataRow = DataTables(TABLE_NAME).Find(VirtualDevice.C_ID & " = " & obj.Identify)
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
                Output.Show(TABLE_NAME & "->Update:" & ex.Message)
            End Try

            Return result
        End Function

        Protected Function DeleteVirtualDevice(ByVal id As Integer) As Boolean

            Return DeleteFunctionalCI(id) And DeleteObject(TABLE_NAME, id)

        End Function
    End Class

End Namespace
