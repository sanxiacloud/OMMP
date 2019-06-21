Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class DomainDAO
        Inherits DNSObjectDAO(Of DomainQT)
        Implements IEntityDAO(Of Domain)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New DomainQT()
            Dim baseObject As New DNSObject()
            Dim finalObject As New Domain()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of Domain)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As Domain) As Integer Implements IEntityDAO(Of Domain).Insert
            o.id = InsertDNSObject(o, GetType(Domain).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As Domain) As Boolean Implements IEntityDAO(Of Domain).Update
            Return UpdateDNSObject(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Private Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of Domain).Delete
            Return DeleteDNSObject(id) And DeleteObject(Of Domain)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace