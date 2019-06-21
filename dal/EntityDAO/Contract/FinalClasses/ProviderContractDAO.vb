Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class ProviderContractDAO
        Inherits ContractDAO(Of ProviderContractQT)
        Implements IEntityDAO(Of ProviderContract)

        Protected Overrides Function BuildJoinTable() As Boolean
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
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As ProviderContract) As Integer Implements IEntityDAO(Of ProviderContract).Insert
            o.id = InsertContract(o, GetType(ProviderContract).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As ProviderContract) As Boolean Implements IEntityDAO(Of ProviderContract).Update
            Return UpdateContract(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Private Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of ProviderContract).Delete
            Return DeleteContract(id) And DeleteObject(Of ProviderContract)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace
