Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class PhysicalInterfaceDAO
        Inherits IPInterfaceDAO(Of PhysicalInterfaceQT)
        Implements IEntityDAO(Of PhysicalInterface)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New PhysicalInterfaceQT()
            Dim baseObject As New NetworkInterface()
            Dim joinObject1 As New IPInterface()
            Dim finalObject As New PhysicalInterface()

            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            builder.AddTable(joinTableName1, C_ID, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of PhysicalInterface)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As PhysicalInterface) As Integer Implements IEntityDAO(Of PhysicalInterface).Insert
            o.id = InsertIPInterface(o, GetType(PhysicalInterface).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As PhysicalInterface) As Boolean Implements IEntityDAO(Of PhysicalInterface).Update
            Return UpdateIPInterface(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Private Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of PhysicalInterface).Delete
            Return DeleteIPInterface(id) And DeleteObject(Of PhysicalInterface)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace