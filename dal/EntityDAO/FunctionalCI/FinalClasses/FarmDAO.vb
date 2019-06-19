Imports ommp.dal.dto
Imports Foxtable


Namespace dal.dao

    Public Class FarmDAO
        Inherits VirtualHostDAO
        Implements IEntityDAO

        Public Sub New()
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
        End Sub

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As Farm = CType(o, Farm)
            obj.id = InsertVirtualHost(o, obj.GetType().Name)
            Return InsertObject(Of ommp.dal.dto.Farm)(CType(o, Farm))
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteVirtualHost(id) And DeleteObject(Of Farm)(id)
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateVirtualHost(o) And UpdateObject(Of Farm)(CType(o, Farm))
        End Function

    End Class

End Namespace