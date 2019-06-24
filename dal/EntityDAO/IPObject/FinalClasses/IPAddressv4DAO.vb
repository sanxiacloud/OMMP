Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class IPAddressv4DAO
        Inherits IPAddressDAO(Of IPAddressv4QT)
        Implements IEntityDAO(Of IPAddressv4)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New IPAddressv4QT()
            Dim baseObject As New IPObject()
            Dim joinObject1 As New IPAddress()
            Dim finalObject As New IPAddressv4()

            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            builder.AddTable(joinTableName1, C_ID, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of IPAddressv4)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As IPAddressv4) As Integer Implements IEntityDAO(Of IPAddressv4).Insert
            o.id = InsertIPAddress(o, GetType(IPAddressv4).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As IPAddressv4) As Boolean Implements IEntityDAO(Of IPAddressv4).Update
            Return UpdateIPAddress(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of IPAddressv4).Delete
            Return DeleteIPAddress(id) And DeleteObject(Of IPAddressv4)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace