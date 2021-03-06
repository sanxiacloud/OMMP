Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class StorageSystemDAO
        Inherits DataCenterDeviceDAO(Of StorageSystemQT)
        Implements IEntityDAO(Of StorageSystem)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New StorageSystemQT()
            Dim baseObject As New FunctionalCI()
            Dim joinObject1 As New PhysicalDevice()
            Dim joinObject2 As New ConnectableCI()
            Dim joinObject3 As New DataCenterDevice()
            Dim finalObject As New StorageSystem()

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
            AddQueryTableCols(Of StorageSystem)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As StorageSystem) As Integer Implements IEntityDAO(Of StorageSystem).Insert
            o.id = InsertDataCenterDevice(o, GetType(StorageSystem).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As StorageSystem) As Boolean Implements IEntityDAO(Of StorageSystem).Update
            Return UpdateDataCenterDevice(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of StorageSystem).Delete
            Return DeleteDataCenterDevice(id) And DeleteObject(Of StorageSystem)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace