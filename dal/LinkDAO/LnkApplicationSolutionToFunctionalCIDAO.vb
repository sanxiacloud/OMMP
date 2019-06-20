Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class LnkApplicationSolutionToFunctionalCIDAO
        Inherits GenericLinkDAO(Of LnkApplicationSolutionToFunctionalCI)
        Implements ILinkDAO


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