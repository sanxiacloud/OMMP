Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao
    Public Class ChangeOpCreateDAO
        Inherits ChangeOpDAO(Of ChangeOpCreateQT)
        Implements IEntityDAO(Of ChangeOpCreate)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New ChangeOpCreateQT()
            Dim baseObject As New ChangeOp()
            Dim finalObject As New ChangeOpCreate()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of ChangeOpCreate)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO(Of ChangeOpCreate).Delete
            Return False  ' 不实现删除方法
        End Function

        Public Function Insert(o As ChangeOpCreate) As Integer Implements IEntityDAO(Of ChangeOpCreate).Insert
            o.id = InsertChangeOp(o, GetType(ChangeOpCreate).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As ChangeOpCreate) As Boolean Implements IEntityDAO(Of ChangeOpCreate).Update
            Return BuildJoinTable()
        End Function

    End Class
End Namespace