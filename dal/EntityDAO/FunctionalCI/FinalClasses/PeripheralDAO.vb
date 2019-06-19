Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class PeripheralDAO
        Inherits ConnectableCIDAO
        Implements IEntityDAO

        Public Sub New()
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
        End Sub

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As Peripheral = CType(o, Peripheral)
            obj.id = InsertConnectableCI(o, obj.GetType().Name)
            Return InsertObject(Of Peripheral)(obj)
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateConnectableCI(o) And UpdateObject(Of Peripheral)(CType(o, Peripheral))
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteConnectableCI(id) And DeleteObject(Of Peripheral)(id)
        End Function

    End Class

End Namespace