Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class LnkApplicationSolutionToFunctionalCIDAO
        Inherits BaseDAO
        Implements ILinkDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Public Function Link(ByVal fromId As Integer, ByVal toId As Integer) As Boolean Implements ILinkDAO.Link
            Dim obj As New LnkApplicationSolutionToFunctionalCI()
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(obj.GetType().Name).AddNew()

                dr(LnkApplicationSolutionToFunctionalCI.C_APPLICATIONSOLUTION_IDENTIFY) = fromId
                dr(LnkApplicationSolutionToFunctionalCI.C_FUNCTIONALCI_IDENTIFY) = toId
                dr(C__ISDELETED) = False

                dr.Save()
                result = True
            Catch ex As Exception
                Output.Show(obj.GetType().Name & "(DAO) -> Link ")
                Output.Show(ex.Message)
                Output.Show(ex.StackTrace)
            End Try

            Return result
        End Function

        Public Function UnLink(ByVal fromId As Integer, ByVal toId As Integer) As Boolean Implements ILinkDAO.UnLink
            Dim obj As New LnkApplicationSolutionToFunctionalCI()
            Dim result As Boolean = False

            Try
                Dim filter As String = LnkApplicationSolutionToFunctionalCI.C_APPLICATIONSOLUTION_IDENTIFY & " = " & fromId
                filter = filter & " AND " & LnkApplicationSolutionToFunctionalCI.C_FUNCTIONALCI_IDENTIFY & " = " & toId

                Dim drs As List(Of DataRow)
                drs = DataTables(obj.GetType().Name).Select(filter)

                For Each dr As DataRow In drs
                    dr(C__ISDELETED) = True
                    dr.Save()
                Next

                result = True
            Catch ex As Exception
                Output.Show(obj.GetType().Name & "(DAO) -> UnLink ")
                Output.Show(ex.Message)
                Output.Show(ex.StackTrace)
            End Try

            Return result
        End Function

        Private Sub TestFindList()
            Dim dao As New ommp.dal.dao.LnkApplicationSolutionToFunctionalCIDAO
            Dim lists As IList(Of ommp.dal.dto.LnkApplicationSolutionToFunctionalCI) = dao.FindList(Of ommp.dal.dto.LnkApplicationSolutionToFunctionalCI)("[applicationsolution_identify] = 21", "functionalci_identify")
            Output.Show("Count : " & lists.Count)
            Output.Show(" --------------------- ")
            For Each dto As ommp.dal.dto.LnkApplicationSolutionToFunctionalCI In lists
                Output.Show("Identify = " & dto._Identify)
                Output.Show("functionalci_identify = " & dto.functionalci_identify)
                Output.Show("applicationsolution_identify = " & dto.applicationsolution_identify)
                Output.Show("IsDeleted = " & dto._IsDeleted)
                Output.Show(" --------------------- ")
            Next
        End Sub

    End Class

End Namespace