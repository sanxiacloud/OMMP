Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class OSVersionDAO
        Inherits TypologyDAO(Of OSVersionQT)
        Implements IEntityDAO(Of OSVersion)

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

        Public Function Insert(o As OSVersion) As Integer Implements IEntityDAO(Of OSVersion).Insert
            o.id = InsertTypology(o, GetType(OSVersion).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As OSVersion) As Boolean Implements IEntityDAO(Of OSVersion).Update
            Return UpdateTypology(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of OSVersion).Delete
            Return DeleteTypology(id) And DeleteObject(Of OSVersion)(id) And BuildJoinTable()
        End Function

    End Class

End Namespace