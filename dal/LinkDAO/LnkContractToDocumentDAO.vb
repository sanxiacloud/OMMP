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

        Public Function UnLink(ByVal fromId As Integer, ByVal toId As Integer) As Boolean Implements ILinkDAO.UnLink
            Dim obj As New LnkContractToDocument()
            Dim fromObject As New Contract()
            Dim toObject As New Documents()
            Dim result As Boolean = False

            Try
                Dim filter As String = fromObject.GetType().Name & C__IDENTIFY & " = " & fromId
                filter = filter & " AND " & toObject.GetType().Name & C__IDENTIFY & " = " & toId

                Dim drs As List(Of DataRow)
                drs = DataTables(obj.GetType().Name).Select(filter)

                For Each dr As DataRow In drs
                    dr(C__ISDELETED) = True
                    dr.Load()
                Next

                result = True
            Catch ex As Exception
                Output.Show(obj.GetType().Name & "(DAO) -> UnLink ")
                Output.Show(ex.Message)
                Output.Show(ex.StackTrace)
            End Try

            Return result
        End Function

    End Class

End Namespace