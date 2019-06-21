Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class MiddlewareInstanceDAO
        Inherits FunctionalCIDAO(Of MiddlewareInstanceQT)
        Implements IEntityDAO(Of MiddlewareInstance)

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

        Public Function Insert(o As MiddlewareInstance) As Integer Implements IEntityDAO(Of MiddlewareInstance).Insert
            o.id = InsertFunctionalCI(o, GetType(MiddlewareInstance).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As MiddlewareInstance) As Boolean Implements IEntityDAO(Of MiddlewareInstance).Update
            Return UpdateFunctionalCI(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Private Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of MiddlewareInstance).Delete
            Return DeleteFunctionalCI(id) And DeleteObject(Of MiddlewareInstance)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace