Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class LogicalInterfaceDAO
        Inherits IPInterfaceDAO
        Implements IEntityDAO

        Public Sub New()
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
        End Sub

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As LogicalInterface = CType(o, LogicalInterface)
            obj.id = InsertIPInterface(o, obj.GetType().Name)
            Return InsertObject(Of LogicalInterface)(CType(o, LogicalInterface))
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteIPInterface(id) And DeleteObject(Of LogicalInterface)(id)
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateIPInterface(o) And UpdateObject(Of LogicalInterface)(CType(o, LogicalInterface))
        End Function


    End Class

End Namespace