Imports ommp.dto
Imports Foxtable
Namespace dao

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
            builder.AddTable(Server.TABLE_NAME, C_ID, TABLE_NAME, C_ID)
            builder.AddCols(TABLE_NAME & "." & C_ID, Server.C_OSFAMILY_ID, Server.C_OSLICENCE_ID, Server.C_OSVERSION_ID, Server.C_CPU, Server.C_RAM)

            builder.Build()
        End Sub

        Protected Overrides ReadOnly Property TABLE_NAME() As String
            Get
                Return Server.TABLE_NAME
            End Get
        End Property

        Protected Overrides Function SetProperties(ByVal dr As DataRow) As Object
            Dim item As New Server()
            With item
                .Identify = dr(C__IDENTIFY)
                .name = dr(FunctionalCI.C_NAME)
                .description = dr(FunctionalCI.C_DESCRIPTION)
                .code_risk_rating = dr(FunctionalCI.C_CODE_RISK_RATING)
                .move2production = dr(FunctionalCI.C_MOVE2PRODUCTION)
                .finalclass = dr(FunctionalCI.C_FINALCLASS)
                .obsolescence_date = dr(FunctionalCI.C_OBSOLESCENCE_DATE)

                .id = dr(C_ID)
                .asset_number = dr(PhysicalDevice.C_ASSET_NUMBER)
                .code_brand_name = dr(PhysicalDevice.C_CODE_BRAND_NAME)
                .code_model_name = dr(PhysicalDevice.C_CODE_MODEL_NAME)
                .code_physicaldevice_status = dr(PhysicalDevice.C_CODE_PHYSICALDEVICE_STATUS)
                .end_of_warranty = dr(PhysicalDevice.C_END_OF_WARRANTY)
                .location_identify = dr(PhysicalDevice.C_LOCATION_IDENTIFY)
                .purchase_date = dr(PhysicalDevice.C_PURCHASE_DATE)
                .serialnumber = dr(PhysicalDevice.C_SERIALNUMBER)

                .rack_identify = dr(Server.C_RACK_IDENTIFY)
                .enclosure_identity = dr(Server.C_ENCLOSURE_IDENTITY)
                .managementip = dr(Server.C_MANAGEMENTIP)
                .nb_u = dr(Server.C_NB_U)
                .redundancy = dr(Server.C_REDUNDANCY)

                .osfamily_id = dr(Server.C_OSFAMILY_ID)
                .oslicence_id = dr(Server.C_OSLICENCE_ID)
                .osversion_id = dr(Server.C_OSVERSION_ID)
                .cpu = dr(Server.C_CPU)
                .ram = dr(Server.C_RAM)
            End With

            Return item
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete

        End Function

        Public Function Insert(ByVal o As Object) As Boolean Implements IEntityDAO.Insert

        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update

        End Function

        Public Function FindList(ByVal filter As String, ByVal sort As String) As System.Collections.Generic.IList(Of Object) Implements IQueryDAO.FindList
            Return FindRows(QUERY_TABLE_NAME, filter, sort)
        End Function

        Public Function FindObject(ByVal id As Integer) As Object Implements IQueryDAO.FindObject
            Return FindRow(QUERY_TABLE_NAME, id)
        End Function
    End Class

End Namespace