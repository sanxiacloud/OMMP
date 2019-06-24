Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class LogicalInterfaceDAO
        Inherits IPInterfaceDAO(Of LogicalInterfaceQT)
        Implements IEntityDAO(Of LogicalInterface)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New LogicalInterfaceQT()
            Dim baseObject As New NetworkInterface()
            Dim joinObject1 As New IPInterface()
            Dim finalObject As New LogicalInterface()

            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            builder.AddTable(joinTableName1, C_ID, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of LogicalInterface)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As LogicalInterface) As Integer Implements IEntityDAO(Of LogicalInterface).Insert
            o.id = InsertIPInterface(o, GetType(LogicalInterface).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As LogicalInterface) As Boolean Implements IEntityDAO(Of LogicalInterface).Update
            Return UpdateIPInterface(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of LogicalInterface).Delete
            Return DeleteIPInterface(id) And DeleteObject(Of LogicalInterface)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace