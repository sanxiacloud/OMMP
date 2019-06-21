Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class ChangeOpLinksAddRemoveDAO
        Inherits ChangeOpLinksDAO(Of ChangeOpLinksAddRemoveQT)
        Implements IEntityDAO(Of ChangeOpLinksAddRemove)

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

        Public Function Insert(o As ChangeOpLinksAddRemove) As Integer Implements IEntityDAO(Of ChangeOpLinksAddRemove).Insert
            o.id = InsertChangeOpLinks(o, GetType(ChangeOpLinksAddRemove).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As ChangeOpLinksAddRemove) As Boolean Implements IEntityDAO(Of ChangeOpLinksAddRemove).Update
            Return False ' 不实现更新方法
        End Function

        Private Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of ChangeOpLinksAddRemove).Delete
            Return False  ' 不实现删除方法
        End Function
    End Class

End Namespace
