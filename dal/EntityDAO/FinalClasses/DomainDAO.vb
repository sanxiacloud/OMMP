Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class DomainDAO
        Inherits DNSObjectDAO
        Implements IEntityDAO

        Public Sub New()
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
        End Sub

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteDNSObject(id) And DeleteObject(Of Domain)(id)
        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As Domain = CType(o, Domain)
            obj.id = InsertDNSObject(o, obj.GetType().Name)
            Return InsertObject(Of Domain)(CType(o, Domain))
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateDNSObject(o) And UpdateObject(Of Domain)(CType(o, Domain))
        End Function

    End Class

End Namespace