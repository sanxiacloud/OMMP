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
                Dim dr As DataRow = DataTables(obj.GetType().Name).AddNew()

                dr(LnkContractToDocument.C_CONTRACT_IDENTIFY) = fromId
                dr(LnkContractToDocument.C_DOCUMENT_IDENTIFY) = toId
                dr(C__ISDELETED) = False

                dr.Load()
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
            Dim result As Boolean = False

            Try
                Dim filter As String = LnkContractToDocument.C_CONTRACT_IDENTIFY & " = " & fromId
                filter = filter & " AND " & LnkContractToDocument.C_DOCUMENT_IDENTIFY & " = " & toId

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