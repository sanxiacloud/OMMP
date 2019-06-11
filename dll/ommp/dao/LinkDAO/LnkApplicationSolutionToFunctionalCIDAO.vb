Imports ommp.dto
Imports Foxtable
Namespace dao

    Public Class LnkApplicationSolutionToFunctionalCIDAO
        Inherits BaseDAO
        Implements ILinkDAO


        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        Protected Overrides ReadOnly Property TABLE_NAME() As String
            Get
                Return LnkApplicationSolutionToFunctionalCI.TABLE_NAME
            End Get
        End Property


        Protected Overrides Function SetProperties(ByVal dr As DataRow) As Object
            Dim item As New LnkApplicationSolutionToFunctionalCI()

            item.Identify = dr(C_ID)
            item.functionalci_identify = dr(LnkApplicationSolutionToFunctionalCI.C_FUNCTIONALCI_IDENTIFY)
            item.applicationsolution_identify = dr(LnkApplicationSolutionToFunctionalCI.C_APPLICATIONSOLUTION_IDENTIFY)

            Return item
        End Function

        Public Function FindList(ByVal filter As String, ByVal sort As String) As System.Collections.Generic.IList(Of Object) Implements ILinkDAO.FindList
            Return FindRows(TABLE_NAME, filter, sort)
        End Function

        Public Function Link(ByVal fromId As Integer, ByVal toId As Integer) As Boolean Implements ILinkDAO.Link
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(TABLE_NAME).AddNew()

                dr(LnkApplicationSolutionToFunctionalCI.C_APPLICATIONSOLUTION_IDENTIFY) = fromId
                dr(LnkApplicationSolutionToFunctionalCI.C_FUNCTIONALCI_IDENTIFY) = toId
                dr(C__ISDELETED) = False

                dr.Save()
                result = True
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Link:" & ex.Message)
            End Try

            Return result
        End Function

        Public Function UnLink(ByVal fromId As Integer, ByVal toId As Integer) As Boolean Implements ILinkDAO.UnLink
            Dim result As Boolean = False

            Try
                Dim filter As String = LnkApplicationSolutionToFunctionalCI.C_APPLICATIONSOLUTION_IDENTIFY & " = " & fromId
                filter = filter & " AND " & LnkApplicationSolutionToFunctionalCI.C_FUNCTIONALCI_IDENTIFY & " = " & toId

                Dim drs As List(Of DataRow)
                drs = DataTables(TABLE_NAME).Select(filter)

                For Each dr As DataRow In drs
                    dr(C__ISDELETED) = True
                    dr.Save()
                Next

                result = True
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->UnLink:" & ex.Message)
            End Try

            Return result
        End Function
    End Class

End Namespace