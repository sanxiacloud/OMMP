Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class IPAddressv4DAO
        Inherits IPAddressDAO
        Implements IEntityDAO

        Public Sub New()
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
        End Sub

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As IPAddressv4 = CType(o, IPAddressv4)
            obj.id = InsertIPAddress(o, obj.GetType().Name)
            Return InsertObject(Of IPAddressv4)(CType(o, IPAddressv4))
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteIPAddress(id) And DeleteObject(Of IPAddressv4)(id)
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateIPAddress(o) And UpdateObject(Of IPAddressv4)(CType(o, IPAddressv4))
        End Function

    End Class

End Namespace