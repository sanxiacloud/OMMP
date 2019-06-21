Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class OSFamilyDAO
        Inherits TypologyDAO(Of OSFamilyQT)
        Implements IEntityDAO(Of OSFamily)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New OSFamilyQT()
            Dim baseObject As New FunctionalCI()
            Dim finalObject As New OSFamily()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of OSFamily)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(ByVal o As OSFamily) As Integer Implements IEntityDAO(Of OSFamily).Insert
            o.id = InsertTypology(o, GetType(OSFamily).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As OSFamily) As Boolean Implements IEntityDAO(Of OSFamily).Update
            Return UpdateTypology(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Private Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of OSFamily).Delete
            Return DeleteTypology(id) And DeleteObject(Of OSFamily)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace