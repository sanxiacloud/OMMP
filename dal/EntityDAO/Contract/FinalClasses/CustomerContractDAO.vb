Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class CustomerContractDAO
        Inherits ContractDAO
        Implements IEntityDAO

        Public Sub New()
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
        End Sub

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteContract(id) And DeleteObject(Of CustomerContract)(id)
        End Function

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As CustomerContract = CType(o, CustomerContract)
            obj.id = InsertContract(o, obj.GetType().Name)
            Return InsertObject(Of CustomerContract)(CType(o, CustomerContract))
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateContract(o) And UpdateObject(Of CustomerContract)(CType(o, CustomerContract))
        End Function

    End Class

End Namespace