Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class SANSwitchDAO
        Inherits DataCenterDeviceDAO
        Implements IEntityDAO

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New SANSwitchQT()
            Dim baseObject As New FunctionalCI()
            Dim joinObject1 As New PhysicalDevice()
            Dim joinObject2 As New ConnectableCI()
            Dim joinObject3 As New DataCenterDevice()
            Dim finalObject As New SANSwitch()

            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name
            Dim joinTableName2 = joinObject2.GetType().Name
            Dim joinTableName3 = joinObject3.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            builder.AddTable(joinTableName1, C_ID, joinTableName2, C_ID)
            builder.AddTable(joinTableName2, C_ID, joinTableName3, C_ID)
            builder.AddTable(joinTableName3, C_ID, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of SANSwitch)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As Server = CType(o, Server)
            obj.id = InsertDataCenterDevice(o, obj.GetType().Name)
            Return InsertObject(Of SANSwitch)(CType(o, SANSwitch)) And BuildJoinTable()
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateDataCenterDevice(o) And UpdateObject(Of SANSwitch)(CType(o, SANSwitch)) And BuildJoinTable()
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteDataCenterDevice(id) And DeleteObject(Of SANSwitch)(id) And BuildJoinTable()
        End Function

    End Class

End Namespace