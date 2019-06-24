Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class ChangeOpSetAttScalarDAO
        Inherits ChangeOpDAO(Of ChangeOpSetAttScalarQT)
        Implements IEntityDAO(Of ChangeOpSetAttScalar)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New ChangeOpSetAttScalarQT()
            Dim baseObject As New ChangeOp()
            Dim finalObject As New ChangeOpSetAttScalar()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of ChangeOpSetAttScalar)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As ChangeOpSetAttScalar) As Integer Implements IEntityDAO(Of ChangeOpSetAttScalar).Insert
            o.id = InsertChangeOp(o, GetType(ChangeOpSetAttScalar).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As ChangeOpSetAttScalar) As Boolean Implements IEntityDAO(Of ChangeOpSetAttScalar).Update
            Return False  ' 不实现更新方法
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of ChangeOpSetAttScalar).Delete
            Return False  ' 不实现删除方法
        End Function
    End Class

End Namespace
