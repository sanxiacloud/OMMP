Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class ServerDAO
        Inherits DataCenterDeviceDAO
        Implements IEntityDAO

        Private Const QUERY_TABLE_NAME As String = "QTServer"

        Public Sub New()
            Dim builder As New SQLJoinTableBuilder(QUERY_TABLE_NAME, FunctionalCI.TABLE_NAME)
            builder.ConnectionName = CONNECTION_NAME
            ' FunctionalCI -> PhysicalDevice
            builder.AddTable(FunctionalCI.TABLE_NAME, C__IDENTIFY, PhysicalDevice.TABLE_NAME, C_ID)
            builder.AddCols(C__IDENTIFY, FunctionalCI.C_NAME, FunctionalCI.C_DESCRIPTION, FunctionalCI.C_CODE_RISK_RATING, FunctionalCI.C_MOVE2PRODUCTION, FunctionalCI.C_FINALCLASS, FunctionalCI.C_OBSOLESCENCE_DATE)
            builder.AddCols(PhysicalDevice.C_ASSET_NUMBER, PhysicalDevice.C_CODE_BRAND_NAME, PhysicalDevice.C_CODE_MODEL_NAME, PhysicalDevice.C_CODE_PHYSICALDEVICE_STATUS, PhysicalDevice.C_END_OF_WARRANTY, PhysicalDevice.C_LOCATION_IDENTIFY, PhysicalDevice.C_PURCHASE_DATE, PhysicalDevice.C_SERIALNUMBER)
            ' PhysicalDevice -> ConnectableCI
            builder.AddTable(PhysicalDevice.TABLE_NAME, C_ID, ConnectableCI.TABLE_NAME, C_ID)
            ' ConnectableCI 只有 id & isdeleted 字段
            ' ConnectableCI -> DataCenterDevice
            builder.AddTable(ConnectableCI.TABLE_NAME, C_ID, DataCenterDevice.TABLE_NAME, C_ID)
            builder.AddCols(DataCenterDevice.C_RACK_IDENTIFY, DataCenterDevice.C_ENCLOSURE_IDENTITY, DataCenterDevice.C_MANAGEMENTIP, DataCenterDevice.C_NB_U, DataCenterDevice.C_REDUNDANCY)
            ' DataCenterDevice -> Server
            builder.AddTable(Server.TABLE_NAME, C_ID, _TABLE_NAME, C_ID)
            builder.AddCols(_TABLE_NAME & "." & C_ID, Server.C_OSFAMILY_ID, Server.C_OSLICENCE_ID, Server.C_OSVERSION_ID, Server.C_CPU, Server.C_RAM)

            builder.Build()
        End Sub

        Private ReadOnly Property _TABLE_NAME() As String
            Get
                Return Server.TABLE_NAME
            End Get
        End Property


        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete

            Return DeleteDataCenterDevice(id) And DeleteObject(Of Server)(id)

        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As Server = CType(o, Server)
            Dim result As Boolean = False

            Try
                Dim identify As Integer = InsertDataCenterDevice(o, _TABLE_NAME)

                Dim dr As DataRow = DataTables(_TABLE_NAME).AddNew()

                dr(C_ID) = identify
                dr(C__ISDELETED) = False
                dr(Server.C_OSFAMILY_ID) = obj.osfamily_id
                dr(Server.C_OSLICENCE_ID) = obj.oslicence_id
                dr(Server.C_OSVERSION_ID) = obj.osversion_id
                dr(Server.C_CPU) = obj.cpu
                dr(Server.C_RAM) = obj.ram

                dr.Save()

                result = True
            Catch ex As Exception
                Output.Show(_TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update

        End Function


    End Class

End Namespace