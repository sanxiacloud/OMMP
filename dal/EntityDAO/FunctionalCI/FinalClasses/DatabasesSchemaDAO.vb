Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class DatabasesSchemaDAO
        Inherits FunctionalCIDAO(Of DatabasesSchema)
        Implements IEntityDAO

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

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteFunctionalCI(id) And DeleteObject(Of DatabasesSchema)(id) And BuildJoinTable()
        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As DatabasesSchema = CType(o, DatabasesSchema)
            obj.id = InsertFunctionalCI(o, obj.GetType().Name)
            Return InsertObject(Of DatabasesSchema)(CType(o, DatabasesSchema)) And BuildJoinTable()
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateFunctionalCI(o) And UpdateObject(Of DatabasesSchema)(CType(o, DatabasesSchema)) And BuildJoinTable()
        End Function

        Public Function Find(ByVal id As Integer) As DatabasesSchema
            Return FindObject(Of DatabasesSchema)(id)
        End Function

        Public Function List(ByVal Optional filter As String = "", ByVal Optional sort As String = Nothing) As IList(Of DatabasesSchema)
            Return FindList(Of DatabasesSchema)(filter, sort)
        End Function
    End Class

End Namespace