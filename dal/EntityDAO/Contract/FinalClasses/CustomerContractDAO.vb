Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class CustomerContractDAO
        Inherits ContractDAO(Of CustomerContractQT)
        Implements IEntityDAO(Of CustomerContract)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New CustomerContractQT()
            Dim baseObject As New Contract()
            Dim finalObject As New CustomerContract()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of CustomerContract)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As CustomerContract) As Integer Implements IEntityDAO(Of CustomerContract).Insert
            o.id = InsertContract(o, GetType(CustomerContract).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As CustomerContract) As Boolean Implements IEntityDAO(Of CustomerContract).Update
            Return UpdateContract(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of CustomerContract).Delete
            Return DeleteContract(id) And DeleteObject(Of CustomerContract)(id) And BuildJoinTable()
        End Function
    End Class

End Namespace
