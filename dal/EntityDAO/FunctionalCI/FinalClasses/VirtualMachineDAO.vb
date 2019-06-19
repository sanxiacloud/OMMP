Imports ommp.dal.dto
Imports Foxtable

Namespace dal.dao
    Public Class VirtualMachineDAO
        Inherits VirtualDeviceDAO
        Implements IEntityDAO

        Public Sub New()
            Dim qtObject As New VirtualMachineQT()
            Dim baseObject As New FunctionalCI()
            Dim joinObject1 As New VirtualDevice()
            Dim finalObject As New VirtualMachine()

            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name 

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            builder.AddTable(joinTableName1, C_ID, finalObject.GetType().Name, C_ID)
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
            Dim lists As IList(Of ommp.dal.dto.VirtualMachineQT) = dao.FindList(Of ommp.dal.dto.VirtualMachineQT)("[name] Like '%Zabbix%'", "id DESC")
            Output.Show("Count : " & lists.Count)
            Output.Show(" --------------------- ")
            For Each dto As ommp.dal.dto.VirtualMachineQT In lists
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
            Dim dto As ommp.dal.dto.VirtualMachineQT = dao.FindObject(Of ommp.dal.dto.VirtualMachineQT)(1868)
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
