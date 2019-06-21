Imports ommp.dal.dto
Imports Foxtable


Namespace dal.dao

    Public Class FarmDAO
        Inherits VirtualHostDAO(Of FarmQT)
        Implements IEntityDAO(Of Farm)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New FarmQT()
            Dim baseObject As New FunctionalCI()
            Dim joinObject1 As New VirtualDevice()
            Dim joinObject2 As New VirtualHost()
            Dim finalObject As New Farm()

            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name
            Dim joinTableName2 = joinObject2.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            builder.AddTable(joinTableName1, C_ID, joinTableName2, C_ID)
            builder.AddTable(joinTableName2, C_ID, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of Farm)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub




        Public Function Insert(o As Farm) As Integer Implements IEntityDAO(Of Farm).Insert
            o.id = InsertVirtualHost(o, GetType(Farm).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As Farm) As Boolean Implements IEntityDAO(Of Farm).Update
            Return UpdateVirtualHost(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Private Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of Farm).Delete
            Return DeleteVirtualHost(id) And DeleteObject(Of Farm)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace