Imports ommp.dto
Imports Foxtable

Namespace dao
    Public MustInherit Class FunctionalCIDAO
        Inherits BaseDAO

        Public Sub New()
            ' empty
        End Sub

        Protected Function InsertFunctionalCI(ByVal o As Object, ByVal finalclass As String) As Integer
            Dim obj As FunctionalCI = CType(o, FunctionalCI)
            Dim identify As Integer = 0

            Try
                Dim dr As DataRow = DataTables(FunctionalCI.TABLE_NAME).AddNew()

                dr(C__ISDELETED) = False
                dr(FunctionalCI.C_NAME) = obj.name
                dr(FunctionalCI.C_DESCRIPTION) = obj.description
                dr(FunctionalCI.C_CODE_RISK_RATING) = obj.code_risk_rating
                dr(FunctionalCI.C_MOVE2PRODUCTION) = obj.move2production
                dr(FunctionalCI.C_FINALCLASS) = finalclass
                dr(FunctionalCI.C_OBSOLESCENCE_DATE) = obj.obsolescence_date

                dr.Save()

                identify = dr(C__IDENTIFY)

            Catch ex As Exception
                Output.Show(FunctionalCI.TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return identify
        End Function

        ' finalclass 列不可修改
        Protected Function UpdateFunctionalCI(ByVal o As Object) As Boolean
            Dim obj As FunctionalCI = CType(o, FunctionalCI)
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(FunctionalCI.TABLE_NAME).Find(C__IDENTIFY & " = " & obj.Identify)
                If dr IsNot Nothing Then
                    If obj.name IsNot Nothing Then
                        dr(ApplicationSolution.C_NAME) = obj.name
                    End If
                    If obj.code_risk_rating >= 0 Then
                        dr(ApplicationSolution.C_CODE_RISK_RATING) = obj.code_risk_rating
                    End If
                    If obj.description IsNot Nothing Then
                        dr(ApplicationSolution.C_DESCRIPTION) = obj.description
                    End If
                    If obj.move2production <> Nothing Then
                        dr(ApplicationSolution.C_MOVE2PRODUCTION) = obj.move2production
                    End If
                    If obj.obsolescence_date <> Nothing Then
                        dr(ApplicationSolution.C_OBSOLESCENCE_DATE) = obj.obsolescence_date
                    End If

                    dr.Save()
                    result = True
                End If

            Catch ex As Exception
                Output.Show(FunctionalCI.TABLE_NAME & "->Update:" & ex.Message)
            End Try

            Return result

        End Function

        Protected Function DeleteFunctionalCI(ByVal id As Integer) As Boolean

            Return DeleteObject(FunctionalCI.TABLE_NAME, id)

        End Function
    End Class
End Namespace

