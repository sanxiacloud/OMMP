﻿Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao
    Public Class ChangeOpDeleteDAO
        Inherits ChangeOpDAO
        Implements IEntityDAO

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

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return False  ' 不实现删除方法
        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As ChangeOpDelete = CType(o, ChangeOpDelete)
            obj.id = InsertChangeOp(o, obj.GetType().Name)
            Return InsertObject(Of ChangeOpDelete)(CType(o, ChangeOpDelete)) And BuildJoinTable()
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return BuildJoinTable()  ' 不实现更新方法
        End Function
    End Class
End Namespace
