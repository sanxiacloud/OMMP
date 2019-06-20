Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class IPSubnetv4DAO
        Inherits IPSubnetDAO(Of IPSubnetv4QT)
        Implements IEntityDAO

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

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As IPSubnetv4 = CType(o, IPSubnetv4)
            obj.id = InsertIPSubnet(o, obj.GetType().Name)
            Return InsertObject(Of IPSubnetv4)(CType(o, IPSubnetv4)) And BuildJoinTable()
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteIPSubnet(id) And DeleteObject(Of IPSubnetv4)(id) And BuildJoinTable()
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateIPSubnet(o) And UpdateObject(Of IPSubnetv4)(CType(o, IPSubnetv4)) And BuildJoinTable()
        End Function


    End Class

End Namespace