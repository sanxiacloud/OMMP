Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class DatabasesSchemaDAO
        Inherits FunctionalCIDAO
        Implements IEntityDAO

        Public Sub New()
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
        End Sub

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteFunctionalCI(id) And DeleteObject(Of DatabasesSchema)(id)
        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As DatabasesSchema = CType(o, DatabasesSchema)
            obj.id = InsertFunctionalCI(o, obj.GetType().Name)
            Return InsertObject(Of ommp.dal.dto.DatabasesSchema)(CType(o, DatabasesSchema))
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateFunctionalCI(o) And UpdateObject(Of DatabasesSchema)(CType(o, DatabasesSchema))
        End Function

    End Class

End Namespace