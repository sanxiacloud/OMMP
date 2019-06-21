Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class IPSubnetv4DAO
        Inherits IPSubnetDAO(Of IPSubnetv4QT)
        Implements IEntityDAO(Of IPSubnetv4)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New IPSubnetv4QT()
            Dim baseObject As New IPObject()
            Dim joinObject1 As New IPSubnet()
            Dim finalObject As New IPSubnetv4()

            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            builder.AddTable(joinTableName1, C_ID, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of IPSubnetv4)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As IPSubnetv4) As Integer Implements IEntityDAO(Of IPSubnetv4).Insert
            o.id = InsertIPSubnet(o, GetType(IPSubnetv4).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As IPSubnetv4) As Boolean Implements IEntityDAO(Of IPSubnetv4).Update
            Return UpdateIPSubnet(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Private Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of IPSubnetv4).Delete
            Return DeleteIPSubnet(id) And DeleteObject(Of IPSubnetv4)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace