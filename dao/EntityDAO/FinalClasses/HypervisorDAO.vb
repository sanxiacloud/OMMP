Imports ommp.dto
Imports Foxtable
Namespace dao

    Public Class HypervisorDAO
        Inherits VirtualHostDAO
        Implements IEntityDAO

        Private Const QUERY_TABLE_NAME As String = "QTHypervisor"

        Public Sub New()
            Dim builder As New SQLJoinTableBuilder(QUERY_TABLE_NAME, FunctionalCI.TABLE_NAME)
            builder.ConnectionName = CONNECTION_NAME
            ' FunctionalCI -> VirtualDevice
            builder.AddTable(FunctionalCI.TABLE_NAME, C__IDENTIFY, VirtualDevice.TABLE_NAME, C_ID)
            builder.AddCols(C__IDENTIFY, FunctionalCI.C_NAME, FunctionalCI.C_DESCRIPTION, FunctionalCI.C_CODE_RISK_RATING, FunctionalCI.C_MOVE2PRODUCTION, FunctionalCI.C_FINALCLASS, FunctionalCI.C_OBSOLESCENCE_DATE)
            builder.AddCols(VirtualDevice.C_CODE_VIRTUALDEVICE_STATUS)
            ' VirtualDevice -> VirtualHost
            builder.AddTable(VirtualDevice.TABLE_NAME, C_ID, VirtualHost.TABLE_NAME, C_ID)
            ' VirtualHost -> Hypervisor
            builder.AddTable(VirtualHost.TABLE_NAME, C_ID, TABLE_NAME, C_ID)
            builder.AddCols(TABLE_NAME & "." & C_ID, Hypervisor.C_FARM_IDENTIFY, Hypervisor.C_SERVER_IDENTIFY)

            builder.Build()
        End Sub

        Protected Overrides ReadOnly Property TABLE_NAME() As String
            Get
                Return Hypervisor.TABLE_NAME
            End Get
        End Property


        Protected Overrides Function SetProperties(ByVal dr As DataRow) As Object
            Dim item As New Hypervisor()

            item._Identify = dr(ApplicationSolution.C_ID)
            item.name = dr(FunctionalCI.C_NAME)
            item.description = dr(FunctionalCI.C_DESCRIPTION)
            item.code_risk_rating = dr(FunctionalCI.C_CODE_RISK_RATING)
            item.move2production = dr(FunctionalCI.C_MOVE2PRODUCTION)
            item.finalclass = dr(FunctionalCI.C_FINALCLASS)
            item.obsolescence_date = dr(FunctionalCI.C_OBSOLESCENCE_DATE)

            item.code_virtualdevice_status = dr(VirtualDevice.C_CODE_VIRTUALDEVICE_STATUS)

            item.id = dr(ApplicationSolution.C_ID)
            item.farm_identify = dr(Hypervisor.C_FARM_IDENTIFY)
            item.server_identify = dr(Hypervisor.C_SERVER_IDENTIFY)

            Return item
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete

            Return DeleteVirtualDevice(id) And DeleteObject(TABLE_NAME, id)
        End Function

        Public Function Insert(ByVal o As Object) As Boolean Implements IEntityDAO.Insert
            Dim obj As Hypervisor = CType(o, Hypervisor)
            Dim result As Boolean = False

            Try
                Dim identify As Integer = InsertVirtualDevice(o, TABLE_NAME)

                Dim dr As DataRow = DataTables(TABLE_NAME).AddNew()

                dr(C_ID) = identify
                dr(C__ISDELETED) = False
                dr(Hypervisor.C_FARM_IDENTIFY) = obj.farm_identify
                dr(Hypervisor.C_SERVER_IDENTIFY) = obj.server_identify

                dr.Save()

                result = True
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Dim obj As Hypervisor = CType(o, Hypervisor)
            Dim result As Boolean = False

            Try
                Dim result1 As Boolean = UpdateVirtualDevice(o)
                Dim result2 As Boolean = False

                Dim dr As DataRow = DataTables(TABLE_NAME).Find(C_ID & " = " & obj._Identify)
                If dr IsNot Nothing Then
                    If obj.farm_identify >= 0 Then
                        dr(Hypervisor.C_FARM_IDENTIFY) = obj.farm_identify
                    End If
                    If obj.server_identify >= 0 Then
                        dr(Hypervisor.C_SERVER_IDENTIFY) = obj.server_identify
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

        Public Function FindList(ByVal filter As String, ByVal sort As String) As System.Collections.Generic.IList(Of Object) Implements IQueryDAO.FindList
            Return FindRows(QUERY_TABLE_NAME, filter, sort)
        End Function

        Public Function FindObject(ByVal id As Integer) As Object Implements IQueryDAO.FindObject
            Return FindRow(QUERY_TABLE_NAME, id)
        End Function
    End Class

End Namespace