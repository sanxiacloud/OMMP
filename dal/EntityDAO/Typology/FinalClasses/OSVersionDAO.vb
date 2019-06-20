Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class OSVersionDAO
        Inherits TypologyDAO(Of OSVersion)
        Implements IEntityDAO

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New OSVersionQT()
            Dim baseObject As New FunctionalCI()
            Dim finalObject As New OSVersion()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of OSVersion)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteTypology(id) And DeleteObject(Of OSVersion)(id) And BuildJoinTable()
        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As OSVersion = CType(o, OSVersion)
            obj.id = InsertTypology(o, obj.GetType().Name)
            Return InsertObject(Of OSVersion)(CType(o, OSVersion)) And BuildJoinTable()
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateTypology(o) And UpdateObject(Of OSVersion)(CType(o, OSVersion)) And BuildJoinTable()
        End Function
    End Class

End Namespace