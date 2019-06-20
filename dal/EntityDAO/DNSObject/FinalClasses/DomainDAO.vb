Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class DomainDAO
        Inherits DNSObjectDAO(Of DomainQT)
        Implements IEntityDAO

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

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteDNSObject(id) And DeleteObject(Of Domain)(id) And BuildJoinTable()
        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As Domain = CType(o, Domain)
            obj.id = InsertDNSObject(o, obj.GetType().Name)
            Return InsertObject(CType(o, Domain)) And BuildJoinTable()
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateDNSObject(o) And UpdateObject(CType(o, Domain)) And BuildJoinTable()
        End Function

    End Class

End Namespace