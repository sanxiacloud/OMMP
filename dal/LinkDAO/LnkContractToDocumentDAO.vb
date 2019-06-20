Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class LnkContractToDocumentDAO
        Inherits BaseDAO
        Implements ILinkDAO

        Public Function Link(ByVal fromId As Integer, ByVal toId As Integer) As Boolean Implements ILinkDAO.Link
            Dim obj As New LnkContractToDocument()
            Dim result As Boolean = False

            Try
                obj.contract_identify = fromId
                obj.document_identify = toId
                InsertObject(obj)

                result = True
            Catch ex As Exception
                Output.Show(obj.GetType().Name & "(DAO) -> Link ")
                Output.Show(ex.Message)
                Output.Show(ex.StackTrace)
            End Try

            Return result
        End Function


    End Class

End Namespace