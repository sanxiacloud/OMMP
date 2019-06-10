Imports ommp.dto
Imports Foxtable

Namespace dao
    Public Class VirtualMachineDAO
        Inherits VirtualDeviceDAO
        Implements IEntityDAO

        Private Const QUERY_TABLE_NAME As String = "QTVirtualMachine"

        Public Sub New()
            Dim builder As New SQLJoinTableBuilder(QUERY_TABLE_NAME, FunctionalCI.TABLE_NAME)
            builder.ConnectionName = CONNECTION_NAME
            ' FunctionalCI -> VirtualDevice
            builder.AddTable(FunctionalCI.TABLE_NAME, C__IDENTIFY, VirtualDevice.TABLE_NAME, C_ID)
            builder.AddCols(FunctionalCI.C_NAME, FunctionalCI.C_DESCRIPTION, FunctionalCI.C_CODE_RISK_RATING, FunctionalCI.C_MOVE2PRODUCTION, FunctionalCI.C_FINALCLASS, FunctionalCI.C_OBSOLESCENCE_DATE)
            builder.AddCols(VirtualDevice.C_ID, VirtualDevice.C_CODE_VIRTUALDEVICE_STATUS)
            ' VirtualDevice -> VirtualMachine
            builder.AddTable(VirtualDevice.TABLE_NAME, C_ID, TABLE_NAME, C_ID)
            builder.AddCols(VirtualMachine.C_VIRTUALHOST_IDENTIFY, VirtualMachine.C_OSFAMILY_IDENTIFY, VirtualMachine.C_OSLICENCE_IDENTIFY, VirtualMachine.C_OSVERSION_IDENTIFY, VirtualMachine.C_MANAGEMENTIP_IDENTIFY, VirtualMachine.C_CODE_BACKUP_PLAN, VirtualMachine.C_CPU, VirtualMachine.C_RAM)

            builder.Build()
            'Output.Show(builder.BuildSql())
        End Sub

        Protected Overrides ReadOnly Property TABLE_NAME() As String
            Get
                Return VirtualMachine.TABLE_NAME
            End Get
        End Property

        Protected Overrides Function SetProperties(ByVal dr As DataRow) As Object
            Dim item As New VirtualMachine()

            item.Identify = dr(ApplicationSolution.C_ID)
            item.name = dr(FunctionalCI.C_NAME)
            item.description = dr(FunctionalCI.C_DESCRIPTION)
            item.code_risk_rating = dr(FunctionalCI.C_CODE_RISK_RATING)
            item.move2production = dr(FunctionalCI.C_MOVE2PRODUCTION)
            item.finalclass = dr(FunctionalCI.C_FINALCLASS)
            item.obsolescence_date = dr(FunctionalCI.C_OBSOLESCENCE_DATE)

            item.code_virtualdevice_status = dr(VirtualDevice.C_CODE_VIRTUALDEVICE_STATUS)

            item.id = dr(ApplicationSolution.C_ID)
            item.virtualhost_identify = dr(VirtualMachine.C_VIRTUALHOST_IDENTIFY)
            item.osfamily_identify = dr(VirtualMachine.C_OSFAMILY_IDENTIFY)
            item.oslicence_identify = dr(VirtualMachine.C_OSLICENCE_IDENTIFY)
            item.osversion_identify = dr(VirtualMachine.C_OSVERSION_IDENTIFY)
            item.managementip_identify = dr(VirtualMachine.C_MANAGEMENTIP_IDENTIFY)
            item.code_backup_plan = dr(VirtualMachine.C_CODE_BACKUP_PLAN)
            item.cpu = dr(VirtualMachine.C_CPU)
            item.ram = dr(VirtualMachine.C_RAM)

            Return item
        End Function


        Public Function Insert(ByVal o As Object) As Boolean Implements IEntityDAO.Insert
            Dim obj As VirtualMachine = CType(o, VirtualMachine)
            Dim result As Boolean = False

            Try
                Dim identify As Integer = InsertVirtualDevice(o, TABLE_NAME)

                Dim dr As DataRow = DataTables(TABLE_NAME).AddNew()

                dr(C_ID) = identify
                dr(C__ISDELETED) = False
                dr(VirtualMachine.C_VIRTUALHOST_IDENTIFY) = obj.virtualhost_identify
                dr(VirtualMachine.C_OSFAMILY_IDENTIFY) = obj.osfamily_identify
                dr(VirtualMachine.C_OSLICENCE_IDENTIFY) = obj.oslicence_identify
                dr(VirtualMachine.C_OSVERSION_IDENTIFY) = obj.osversion_identify
                dr(VirtualMachine.C_MANAGEMENTIP_IDENTIFY) = obj.managementip_identify
                dr(VirtualMachine.C_CODE_BACKUP_PLAN) = obj.code_backup_plan
                dr(VirtualMachine.C_CODE_BACKUP_PLAN) = obj.cpu
                dr(VirtualMachine.C_RAM) = obj.ram

                dr.Save()

                result = True
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete

            Return DeleteVirtualDevice(id) And DeleteObject(TABLE_NAME, id)

        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Dim obj As VirtualMachine = CType(o, VirtualMachine)
            Dim result As Boolean = False

            Try
                Dim result1 As Boolean = UpdateVirtualDevice(o)
                Dim result2 As Boolean = False

                Dim dr As DataRow = DataTables(TABLE_NAME).Find(C_ID & " = " & obj.Identify)
                If dr IsNot Nothing Then
                    If obj.virtualhost_identify >= 0 Then
                        dr(VirtualMachine.C_VIRTUALHOST_IDENTIFY) = obj.virtualhost_identify
                    End If
                    If obj.osfamily_identify >= 0 Then
                        dr(VirtualMachine.C_OSFAMILY_IDENTIFY) = obj.osfamily_identify
                    End If
                    If obj.oslicence_identify >= 0 Then
                        dr(VirtualMachine.C_OSLICENCE_IDENTIFY) = obj.oslicence_identify
                    End If
                    If obj.osversion_identify >= 0 Then
                        dr(VirtualMachine.C_OSVERSION_IDENTIFY) = obj.osversion_identify
                    End If
                    If obj.managementip_identify >= 0 Then
                        dr(VirtualMachine.C_MANAGEMENTIP_IDENTIFY) = obj.managementip_identify
                    End If
                    If obj.code_backup_plan >= 0 Then
                        dr(VirtualMachine.C_CODE_BACKUP_PLAN) = obj.code_backup_plan
                    End If
                    If obj.cpu IsNot Nothing Then
                        dr(VirtualMachine.C_CPU) = obj.cpu
                    End If
                    If obj.ram IsNot Nothing Then
                        dr(VirtualMachine.C_RAM) = obj.ram
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
            Return FindRows(TABLE_NAME, filter, sort)
        End Function

        Public Function FindObject(ByVal id As Integer) As Object Implements IQueryDAO.FindObject
            Return FindRow(TABLE_NAME, id)
        End Function
    End Class
End Namespace
