Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class DBServerDAO
        Inherits SoftwareInstanceDAO(Of DBServerQT)
        Implements IEntityDAO(Of DBServer)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New DBServerQT()
            Dim baseObject As New FunctionalCI()
            Dim joinObject1 As New SoftwareInstance()
            Dim finalObject As New DBServer()

            Dim baseTableName = baseObject.GetType().Name
            Dim joinTableName1 = joinObject1.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, joinTableName1, C_ID)
            builder.AddTable(joinTableName1, C_ID, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of DBServer)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As DBServer) As Integer Implements IEntityDAO(Of DBServer).Insert
            o.id = InsertSoftwareInstance(o, GetType(DBServer).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As DBServer) As Boolean Implements IEntityDAO(Of DBServer).Update
            Return UpdateSoftwareInstance(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Private Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of DBServer).Delete
            Return DeleteSoftwareInstance(id) And DeleteObject(Of DBServer)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace