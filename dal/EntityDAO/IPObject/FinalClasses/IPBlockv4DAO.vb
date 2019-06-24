Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class IPBlockv4DAO
        Inherits IPBlockDAO(Of IPBlockv4QT)
        Implements IEntityDAO(Of IPBlockv4)

        Protected Overrides Function BuildJoinTable() As Boolean
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
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As IPBlockv4) As Integer Implements IEntityDAO(Of IPBlockv4).Insert
            o.id = InsertIPBlock(o, GetType(IPBlockv4).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As IPBlockv4) As Boolean Implements IEntityDAO(Of IPBlockv4).Update
            Return UpdateIPBlock(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of IPBlockv4).Delete
            Return DeleteIPBlock(id) And DeleteObject(Of IPBlockv4)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace