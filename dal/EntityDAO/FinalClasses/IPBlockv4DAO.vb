Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class IPBlockv4DAO
        Inherits IPBlockDAO
        Implements IEntityDAO

        Public Sub New()
            Dim qtObject As New IPBlockv4QT()
            Dim baseObject As New IPObject()
            Dim joinObject1 As New IPBlock()
            Dim finalObject As New IPBlockv4()

            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            builder.AddTable(joinTableName1, C_ID, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of IPBlockv4)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Sub

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As IPBlockv4 = CType(o, IPBlockv4)
            obj.id = InsertIPBlock(o, obj.GetType().Name)
            Return InsertObject(Of IPBlockv4)(CType(o, IPBlockv4))
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteIPBlock(id) And DeleteObject(Of IPBlockv4)(id)
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateIPBlock(o) And UpdateObject(Of IPBlockv4)(CType(o, IPBlockv4))
        End Function

    End Class

End Namespace