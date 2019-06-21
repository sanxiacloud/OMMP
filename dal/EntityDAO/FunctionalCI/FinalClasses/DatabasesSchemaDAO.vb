Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class DatabasesSchemaDAO
        Inherits FunctionalCIDAO(Of DatabasesSchemaQT)
        Implements IEntityDAO(Of DatabasesSchema)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New DatabasesSchemaQT()
            Dim baseObject As New FunctionalCI()
            Dim finalObject As New DatabasesSchema()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of DatabasesSchema)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As DatabasesSchema) As Integer Implements IEntityDAO(Of DatabasesSchema).Insert
            o.id = InsertFunctionalCI(o, GetType(DatabasesSchema).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As DatabasesSchema) As Boolean Implements IEntityDAO(Of DatabasesSchema).Update
            Return UpdateFunctionalCI(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Private Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of DatabasesSchema).Delete
            Return DeleteFunctionalCI(id) And DeleteObject(Of DatabasesSchema)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace