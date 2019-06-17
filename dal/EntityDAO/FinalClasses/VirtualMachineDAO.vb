Imports ommp.dal.dto
Imports Foxtable

Namespace dal.dao
    Public Class VirtualMachineDAO
        Inherits VirtualDeviceDAO
        Implements IEntityDAO

        Private ReadOnly Property _TABLE_NAME() As String
            Get
                Return VirtualMachine.TABLE_NAME
            End Get
        End Property

        Private ReadOnly Property QUERY_TABLE_NAME() As String
            Get
                Return VirtualMachineQT.TABLE_NAME
            End Get
        End Property

        Public Sub New()
            Dim theObject As New VirtualMachineQT()
            Dim baseObject As New FunctionalCI()
            Dim joinObject1 As New VirtualDevice()
            Dim joinObject2 As New VirtualMachine()

            Dim queryTableName = theObject.GetType().Name
            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name
            Dim joinTableName2 = joinObject2.GetType().Name

            Dim builder As New SQLJoinTableBuilder(queryTableName, baseTableName)
            builder.ConnectionName = CONNECTION_NAME

            'builder.AddCols(C__IDENTIFY, FunctionalCI.C_NAME, FunctionalCI.C_DESCRIPTION, FunctionalCI.C_CODE_RISK_RATING, FunctionalCI.C_MOVE2PRODUCTION, FunctionalCI.C_FINALCLASS, FunctionalCI.C_OBSOLESCENCE_DATE)
            ' FunctionalCI -> VirtualDevice
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            'builder.AddCols(VirtualDevice.C_CODE_VIRTUALDEVICE_STATUS)

            ' VirtualDevice -> VirtualMachine
            builder.AddTable(joinTableName1, C_ID, joinTableName2, C_ID)
            ' builder.AddCols(VirtualDevice.TABLE_NAME & "." & C_ID, VirtualMachine.C_VIRTUALHOST_IDENTIFY, VirtualMachine.C_OSFAMILY_IDENTIFY, VirtualMachine.C_OSLICENCE_IDENTIFY, VirtualMachine.C_OSVERSION_IDENTIFY, VirtualMachine.C_MANAGEMENTIP_IDENTIFY, VirtualMachine.C_CODE_BACKUP_PLAN, VirtualMachine.C_CPU, VirtualMachine.C_RAM)

            AddQueryTableCols(Of VirtualMachine)(builder)

            builder.Build()
            'Output.Show(builder.BuildSql())
        End Sub

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As VirtualMachine = CType(o, VirtualMachine)
            obj.id = InsertVirtualDevice(o, obj.GetType().Name)
            Return InsertObject(Of ommp.dal.dto.VirtualMachine)(CType(o, VirtualMachine))
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteVirtualDevice(id) And DeleteObject(Of VirtualMachine)(id)
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateVirtualDevice(o) And UpdateObject(Of VirtualMachine)(CType(o, VirtualMachine))
        End Function

        ' 添加一台虚拟机
        Private Sub TestInsert()
            Dim dao As ommp.dal.dao.VirtualMachineDAO = New ommp.dal.dao.VirtualMachineDAO()
            Dim result As Boolean = False
            Dim dto As New ommp.dal.dto.VirtualMachine()
            dto.name = "测试虚拟机1-20190614-1"
            dto.code_risk_rating = 2
            dto.description = "测试虚拟机1-描述"
            dto.move2production = DateTime.Now
            dto.obsolescence_date = DateTime.Now

            dto.code_virtualdevice_status = 1

            dto.virtualhost_identify = 1
            dto.osfamily_identify = 1
            dto.oslicence_identify = 1
            dto.osversion_identify = 1
            dto.managementip_identify = 1
            dto.code_backup_plan = 1
            dto.cpu = "8"
            dto.ram = "8G"

            result = dao.Insert(dto)
            Output.Show(result)

            Output.Logs("INFO").Clear()

        End Sub

        ' 查询虚拟机列表
        Private Sub TestFindList()
            Dim dao As New ommp.dal.dao.VirtualMachineDAO
            Dim lists As IList(Of Object) = dao.FindList(Of VirtualMachine)("[name] Like '%Zabbix%'", "id DESC")
            Output.Show("Count : " & lists.Count)
            Output.Show(" --------------------- ")
            For Each dto As ommp.dal.dto.VirtualMachine In lists
                Output.Show("Identify = " & dto._Identify)
                Output.Show("name = " & dto.name)
                Output.Show("description = " & dto.description)
                Output.Show("code_risk_rating = " & dto.code_risk_rating)
                Output.Show("move2production = " & dto.move2production)
                Output.Show("finalclass = " & dto.finalclass)
                Output.Show("obsolescence_date = " & dto.obsolescence_date)
                Output.Show("code_virtualdevice_status = " & dto.code_virtualdevice_status)
                Output.Show("id = " & dto.id)
                Output.Show("virtualhost_identify = " & dto.virtualhost_identify)
                Output.Show("osfamily_identify = " & dto.osfamily_identify)
                Output.Show("oslicence_identify = " & dto.oslicence_identify)
                Output.Show("osversion_identify = " & dto.osversion_identify)
                Output.Show("managementip_identify = " & dto.managementip_identify)
                Output.Show("code_backup_plan = " & dto.code_backup_plan)
                Output.Show("cpu = " & dto.cpu)
                Output.Show("ram = " & dto.ram)
                Output.Show("IsDeleted = " & dto._IsDeleted)
                Output.Show(" --------------------- ")
            Next
        End Sub

        '查找一个虚拟机
        Private Sub TestFindObject()
            Dim dao As ommp.dal.dao.VirtualMachineDAO = New ommp.dal.dao.VirtualMachineDAO()
            Dim dto As ommp.dal.dto.VirtualMachine = dao.FindObject(Of ommp.dal.dto.VirtualMachine)(1868)
            Output.Show("Identify = " & dto._Identify)
            Output.Show("name = " & dto.name)
            Output.Show("description = " & dto.description)
            Output.Show("code_risk_rating = " & dto.code_risk_rating)
            Output.Show("move2production = " & dto.move2production)
            Output.Show("finalclass = " & dto.finalclass)
            Output.Show("obsolescence_date = " & dto.obsolescence_date)
            Output.Show("code_virtualdevice_status = " & dto.code_virtualdevice_status)
            Output.Show("id = " & dto.id)
            Output.Show("virtualhost_identify = " & dto.virtualhost_identify)
            Output.Show("osfamily_identify = " & dto.osfamily_identify)
            Output.Show("oslicence_identify = " & dto.oslicence_identify)
            Output.Show("osversion_identify = " & dto.osversion_identify)
            Output.Show("managementip_identify = " & dto.managementip_identify)
            Output.Show("code_backup_plan = " & dto.code_backup_plan)
            Output.Show("cpu = " & dto.cpu)
            Output.Show("ram = " & dto.ram)
            Output.Show("IsDeleted = " & dto._IsDeleted)
        End Sub
    End Class
End Namespace
