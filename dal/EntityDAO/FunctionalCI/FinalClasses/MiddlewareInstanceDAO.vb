Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class MiddlewareInstanceDAO
        Inherits FunctionalCIDAO
        Implements IEntityDAO

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New MiddlewareInstanceQT()
            Dim baseObject As New FunctionalCI()
            Dim finalObject As New MiddlewareInstance()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of MiddlewareInstance)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As MiddlewareInstance = CType(o, MiddlewareInstance)
            obj.id = InsertFunctionalCI(o, obj.GetType().Name)
            Return InsertObject(Of MiddlewareInstance)(CType(o, MiddlewareInstance)) And BuildJoinTable()
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateFunctionalCI(o) And UpdateObject(Of MiddlewareInstance)(CType(o, MiddlewareInstance)) And BuildJoinTable()
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteFunctionalCI(id) And DeleteObject(Of MiddlewareInstance)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace