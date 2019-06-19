Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class ProviderContractDAO
        Inherits ContractDAO
        Implements IEntityDAO

        Public Sub New()
            Dim qtObject As New ProviderContractQT()
            Dim baseObject As New Contract()
            Dim finalObject As New ProviderContract()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of ProviderContract)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Sub

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteContract(id) And DeleteObject(Of ProviderContract)(id)
        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As ProviderContract = CType(o, ProviderContract)
            obj.id = InsertContract(o, obj.GetType().Name)
            Return InsertObject(Of ProviderContract)(CType(o, ProviderContract))
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateContract(o) And UpdateObject(Of ProviderContract)(CType(o, ProviderContract))
        End Function

    End Class

End Namespace