Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class RackDAO
        Inherits ConnectableCIDAO
        Implements IEntityDAO

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

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As Rack = CType(o, Rack)
            obj.id = InsertConnectableCI(o, obj.GetType().Name)
            Return InsertObject(Of Rack)(CType(o, Rack))
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateConnectableCI(o) And UpdateObject(Of Rack)(CType(o, Rack)) And BuildJoinTable()
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteConnectableCI(id) And DeleteObject(Of Rack)(id)
        End Function

    End Class

End Namespace