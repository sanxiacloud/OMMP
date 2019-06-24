Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class RackDAO
        Inherits ConnectableCIDAO(Of RackQT)
        Implements IEntityDAO(Of Rack)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New RackQT()
            Dim baseObject As New FunctionalCI()
            Dim joinObject1 As New PhysicalDevice()
            Dim joinObject2 As New ConnectableCI()
            Dim finalObject As New Rack()

            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name
            Dim joinTableName2 = joinObject2.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            builder.AddTable(joinTableName1, C_ID, joinTableName2, C_ID)
            builder.AddTable(joinTableName2, C_ID, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of Rack)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As Rack) As Integer Implements IEntityDAO(Of Rack).Insert
            o.id = InsertConnectableCI(o, GetType(Rack).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As Rack) As Boolean Implements IEntityDAO(Of Rack).Update
            Return UpdateConnectableCI(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of Rack).Delete
            Return DeleteConnectableCI(id) And DeleteObject(Of Rack)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace