﻿Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao
    Public Class ChangeOpCreateDAO
        Inherits ChangeOpDAO
        Implements IEntityDAO

        Public Sub New()
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
        End Sub

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return False  ' 不实现删除方法
        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As ChangeOpCreate = CType(o, ChangeOpCreate)
            obj.id = InsertChangeOp(o, obj.GetType().Name)
            Return InsertObject(Of ChangeOpCreate)(CType(o, ChangeOpCreate))
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return False  ' 不实现更新方法
        End Function

    End Class
End Namespace