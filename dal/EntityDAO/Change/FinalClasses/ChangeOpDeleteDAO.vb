Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao
    Public Class ChangeOpDeleteDAO
        Inherits ChangeOpDAO(Of ChangeOpDeleteQT)
        Implements IEntityDAO(Of ChangeOpDelete)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New ChangeOpDeleteQT()
            Dim baseObject As New ChangeOp()
            Dim finalObject As New ChangeOpDelete()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of ChangeOpDelete)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As ChangeOpDelete) As Integer Implements IEntityDAO(Of ChangeOpDelete).Insert
            o.id = InsertChangeOp(o, GetType(ChangeOpDelete).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As ChangeOpDelete) As Boolean Implements IEntityDAO(Of ChangeOpDelete).Update
            Return False ' 不实现更新方法
        End Function

        Private Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of ChangeOpDelete).Delete
            Return False  ' 不实现删除方法
        End Function
    End Class
End Namespace
