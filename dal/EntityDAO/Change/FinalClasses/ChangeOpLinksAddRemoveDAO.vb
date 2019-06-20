Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class ChangeOpLinksAddRemoveDAO
        Inherits ChangeOpLinksDAO(Of ChangeOpLinksAddRemove)
        Implements IEntityDAO

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New ChangeOpLinksAddRemoveQT()
            Dim baseObject As New ChangeOp()
            Dim joinObject1 As New ChangeOpLinks()
            Dim finalObject As New ChangeOpLinksAddRemove()

            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            builder.AddTable(joinTableName1, C_ID, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of ChangeOpLinksAddRemove)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As ChangeOpLinksAddRemove = CType(o, ChangeOpLinksAddRemove)
            obj.id = InsertChangeOpLinks(o, obj.GetType().Name)
            Return InsertObject(Of ChangeOpLinksAddRemove)(CType(o, ChangeOpLinksAddRemove)) And BuildJoinTable()
        End Function

        Public Function Update(o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateChangeOpLinks(o) And UpdateObject(Of ChangeOpLinksAddRemove)(CType(o, ChangeOpLinksAddRemove)) And BuildJoinTable()
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteChangeOpLinks(id) And DeleteObject(Of ChangeOpLinksAddRemove)(id) And BuildJoinTable()
        End Function

    End Class

End Namespace
