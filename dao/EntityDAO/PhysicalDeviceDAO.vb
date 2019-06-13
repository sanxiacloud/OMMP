Imports ommp.dto
Imports Foxtable
Namespace dao

    Public MustInherit Class PhysicalDeviceDAO
        Inherits FunctionalCIDAO

        Private Const _TABLE_NAME = PhysicalDevice.TABLE_NAME

        Protected Function InsertPhysicalDevice(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As PhysicalDevice = CType(o, PhysicalDevice)
            Dim result As Boolean = False

            Try
                Dim identify As Integer = InsertFunctionalCI(o, finalclass)

                Dim dr As DataRow = DataTables(_TABLE_NAME).AddNew()

                dr(C_ID) = identify
                dr(C__ISDELETED) = False
                dr(PhysicalDevice.C_ASSET_NUMBER) = obj.asset_number
                dr(PhysicalDevice.C_CODE_BRAND_NAME) = obj.code_brand_name
                dr(PhysicalDevice.C_CODE_MODEL_NAME) = obj.code_model_name
                dr(PhysicalDevice.C_CODE_PHYSICALDEVICE_STATUS) = obj.code_physicaldevice_status
                dr(PhysicalDevice.C_END_OF_WARRANTY) = obj.end_of_warranty
                dr(PhysicalDevice.C_LOCATION_IDENTIFY) = obj.location_identify
                dr(PhysicalDevice.C_PURCHASE_DATE) = obj.purchase_date
                dr(PhysicalDevice.C_SERIALNUMBER) = obj.serialnumber

                dr.Save()

                result = True
            Catch ex As Exception
                Output.Show(_TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        Protected Function UpdatePhysicalDevice(ByVal o As Object) As Boolean
            Dim obj As PhysicalDevice = CType(o, PhysicalDevice)
            Dim result As Boolean = False

            Try
                Dim result1 As Boolean = UpdateFunctionalCI(o)

                Dim dr As DataRow = DataTables(_TABLE_NAME).Find(C_ID & " = " & obj._Identify)
                Dim result2 As Boolean = False
                If dr IsNot Nothing Then
                    If obj.asset_number IsNot Nothing Then
                        dr(PhysicalDevice.C_ASSET_NUMBER) = obj.asset_number
                    End If
                    If obj.code_brand_name >= 0 Then
                        dr(PhysicalDevice.C_CODE_BRAND_NAME) = obj.code_brand_name
                    End If
                    If obj.code_model_name >= 0 Then
                        dr(PhysicalDevice.C_CODE_MODEL_NAME) = obj.code_model_name
                    End If
                    If obj.code_physicaldevice_status >= 0 Then
                        dr(PhysicalDevice.C_CODE_PHYSICALDEVICE_STATUS) = obj.code_physicaldevice_status
                    End If
                    If obj.end_of_warranty <> Nothing Then
                        dr(PhysicalDevice.C_END_OF_WARRANTY) = obj.end_of_warranty
                    End If
                    If obj.location_identify >= 0 Then
                        dr(PhysicalDevice.C_LOCATION_IDENTIFY) = obj.location_identify
                    End If
                    If obj.purchase_date <> Nothing Then
                        dr(PhysicalDevice.C_PURCHASE_DATE) = obj.purchase_date
                    End If
                    If obj.serialnumber IsNot Nothing Then
                        dr(PhysicalDevice.C_SERIALNUMBER) = obj.serialnumber
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

        Protected Function DeletePhysicalDevice(ByVal id As Integer) As Boolean

            Return DeleteFunctionalCI(id) And DeleteObject(_TABLE_NAME, id)

        End Function
    End Class

End Namespace
