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
            builder.AddCols(C__IDENTIFY, FunctionalCI.C_NAME, FunctionalCI.C_DESCRIPTION, FunctionalCI.C_CODE_RISK_RATING, FunctionalCI.C_MOVE2PRODUCTION, FunctionalCI.C_FINALCLASS, FunctionalCI.C_OBSOLESCENCE_DATE)
            builder.AddCols(VirtualDevice.C_CODE_VIRTUALDEVICE_STATUS)
            ' VirtualDevice -> VirtualMachine
            builder.AddTable(VirtualDevice.TABLE_NAME, C_ID, _TABLE_NAME, C_ID)
            builder.AddCols(VirtualDevice.TABLE_NAME & "." & C_ID, VirtualMachine.C_VIRTUALHOST_IDENTIFY, VirtualMachine.C_OSFAMILY_IDENTIFY, VirtualMachine.C_OSLICENCE_IDENTIFY, VirtualMachine.C_OSVERSION_IDENTIFY, VirtualMachine.C_MANAGEMENTIP_IDENTIFY, VirtualMachine.C_CODE_BACKUP_PLAN, VirtualMachine.C_CPU, VirtualMachine.C_RAM)

            builder.Build()
            'Output.Show(builder.BuildSql())
        End Sub

        Private ReadOnly Property _TABLE_NAME() As String
            Get
                Return VirtualMachine.TABLE_NAME
            End Get
        End Property



        ' 添加一台虚拟机
        'Dim dao As ommp.dao.VirtualMachineDAO = New ommp.dao.VirtualMachineDAO()
        'Dim result As Boolean = False
        'Dim dto As New ommp.dto.VirtualMachine()
        'dto.name = "测试虚拟机1-20190611-1"
        'dto.description = "描述"

        'dto.code_application_status= 2
        'dto.redundancy = 3
        'dto.code_sla = 1
        'dto.fault_effects = 0
        'dto.attention = "测试注意事项内容"
        'dto.IsDeleted = False
        'result = dao.Insert(dto)
        'Output.Show(result)
        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As VirtualMachine = CType(o, VirtualMachine)
            Dim result As Boolean = False

            Try
                Dim identify As Integer = InsertVirtualDevice(o, _TABLE_NAME)

                Dim dr As DataRow = DataTables(_TABLE_NAME).AddNew()

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
                Output.Show(_TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete

            Return DeleteVirtualDevice(id) And DeleteObject(Of VirtualMachine)(id)

        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Dim obj As VirtualMachine = CType(o, VirtualMachine)
            Dim result As Boolean = False

            Try
                Dim result1 As Boolean = UpdateVirtualDevice(o)
                Dim result2 As Boolean = False

                Dim dr As DataRow = DataTables(_TABLE_NAME).Find(C_ID & " = " & obj._Identify)
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
                Output.Show(_TABLE_NAME & "->Update:" & ex.Message)
            End Try

            Return result
        End Function

        ' 查询虚拟机列表
        'Dim dao As New ommp.dao.VirtualMachineDAO
        'Dim lists As IList(Of Object) = dao.FindList("[name] Like '%Zabbix%'", "id DESC")
        'output.Show("Count : " & lists.Count )
        'Output.Show(" --------------------- ") 
        'For Each dto As ommp.dto.VirtualMachine In lists 
        '    Output.Show("Identify = " & dto._Identify)
        '    Output.Show("name = " & dto.name)
        '    Output.Show("description = " & dto.description)
        '    Output.Show("code_risk_rating = " & dto.code_risk_rating)
        '    Output.Show("move2production = " & dto.move2production)
        '    Output.Show("finalclass = " & dto.finalclass)
        '    Output.Show("obsolescence_date = " & dto.obsolescence_date)
        '    Output.Show("code_virtualdevice_status = " & dto.code_virtualdevice_status)
        '    Output.Show("id = " & dto.id)
        '    Output.Show("virtualhost_identify = " & dto.virtualhost_identify)
        '    Output.Show("osfamily_identify = " & dto.osfamily_identify)
        '    Output.Show("oslicence_identify = " & dto.oslicence_identify)
        '    Output.Show("osversion_identify = " & dto.osversion_identify)
        '    Output.Show("managementip_identify = " & dto.managementip_identify)
        '    Output.Show("code_backup_plan = " & dto.code_backup_plan)
        '    Output.Show("cpu = " & dto.cpu)
        '    Output.Show("ram = " & dto.ram)
        '    Output.Show("IsDeleted = " & dto.IsDeleted)
        '    Output.Show(" --------------------- ") 
        'Next


        '查找一个虚拟机
        'Dim dao As ommp.dao.VirtualMachineDAO = New ommp.dao.VirtualMachineDAO()
        'Dim dto  As ommp.dto.VirtualMachine = dao.FindObject(1868)
        'Output.Show("Identify = " & dto._Identify)
        'Output.Show("name = " & dto.name)
        'Output.Show("description = " & dto.description)
        'Output.Show("code_risk_rating = " & dto.code_risk_rating)
        'Output.Show("move2production = " & dto.move2production)
        'Output.Show("finalclass = " & dto.finalclass)
        'Output.Show("obsolescence_date = " & dto.obsolescence_date)
        'Output.Show("code_virtualdevice_status = " & dto.code_virtualdevice_status)
        'Output.Show("id = " & dto.id)
        'Output.Show("virtualhost_identify = " & dto.virtualhost_identify)
        'Output.Show("osfamily_identify = " & dto.osfamily_identify)
        'Output.Show("oslicence_identify = " & dto.oslicence_identify)
        'Output.Show("osversion_identify = " & dto.osversion_identify)
        'Output.Show("managementip_identify = " & dto.managementip_identify)
        'Output.Show("code_backup_plan = " & dto.code_backup_plan)
        'Output.Show("cpu = " & dto.cpu)
        'Output.Show("ram = " & dto.ram)
        'Output.Show("IsDeleted = " & dto.IsDeleted)

    End Class
End Namespace
