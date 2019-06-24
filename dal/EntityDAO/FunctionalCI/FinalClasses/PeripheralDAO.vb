Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class PeripheralDAO
        Inherits ConnectableCIDAO(Of PeripheralQT)
        Implements IEntityDAO(Of Peripheral)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New PeripheralQT()
            Dim baseObject As New FunctionalCI()
            Dim joinObject1 As New PhysicalDevice()
            Dim joinObject2 As New ConnectableCI()
            Dim finalObject As New Peripheral()

            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name
            Dim joinTableName2 = joinObject2.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            builder.AddTable(joinTableName1, C_ID, joinTableName2, C_ID)
            builder.AddTable(joinTableName2, C_ID, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of Peripheral)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As Peripheral) As Integer Implements IEntityDAO(Of Peripheral).Insert
            o.id = InsertConnectableCI(o, GetType(Peripheral).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function
        Public Function Update(o As Peripheral) As Boolean Implements IEntityDAO(Of Peripheral).Update
            Return UpdateConnectableCI(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of Peripheral).Delete
            Return DeleteConnectableCI(id) And DeleteObject(Of Peripheral)(id) And BuildJoinTable()
        End Function

    End Class

End Namespace