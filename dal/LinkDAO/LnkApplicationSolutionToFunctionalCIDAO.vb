Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class LnkApplicationSolutionToFunctionalCIDAO
        Inherits GenericLinkDAO(Of LnkApplicationSolutionToFunctionalCI)
        Implements ILinkDAO

        Public Function Link(ByVal fromId As Integer, ByVal toId As Integer) As Boolean Implements ILinkDAO.Link
            Dim obj As New LnkApplicationSolutionToFunctionalCI()
            Dim result As Boolean = False

            Try
                obj.applicationsolution_identify = fromId
                obj.functionalci_identify = toId
                InsertObject(obj)

                result = True
            Catch ex As Exception
                Output.Show(obj.GetType().Name & "(DAO) -> Link ")
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