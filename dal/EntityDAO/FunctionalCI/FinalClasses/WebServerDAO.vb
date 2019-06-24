Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class WebServerDAO
        Inherits SoftwareInstanceDAO(Of WebServerQT)
        Implements IEntityDAO(Of WebServer)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New WebServerQT()
            Dim baseObject As New FunctionalCI()
            Dim joinObject1 As New SoftwareInstance()
            Dim finalObject As New WebServer()

            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            builder.AddTable(joinTableName1, C_ID, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of WebServer)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As WebServer) As Integer Implements IEntityDAO(Of WebServer).Insert
            o.id = InsertSoftwareInstance(o, GetType(WebServer).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As WebServer) As Boolean Implements IEntityDAO(Of WebServer).Update
            Return UpdateSoftwareInstance(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of WebServer).Delete
            Return DeleteSoftwareInstance(id) And DeleteObject(Of WebServer)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace