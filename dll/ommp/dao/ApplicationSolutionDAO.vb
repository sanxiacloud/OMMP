Imports ommp.dto
Imports Foxtable

Namespace dao
    Public Class ApplicationSolutionDAO : Inherits BaseDAO

        Private Const TABLE_FunctionalCI As String = "FunctionalCI"
        Private Const TABLE_ApplicationSolution As String = "ApplicationSolution"
        Private Const QT_ApplicationSolution As String = "QTApplicationSolution"

        Private Function SetProperties(ByVal drFCI As DataRow, ByVal drAS As DataRow) As ApplicationSolution
            Dim item As New ApplicationSolution()

            item.Identify = drFCI("_Identify")
            item.name = drFCI("name")
            item.description = drFCI("description")
            item.code_risk_rating = drFCI("code_risk_rating")
            item.move2production = drFCI("move2production")
            item.finalclass = drFCI("finalclass")
            item.obsolescence_date = drFCI("obsolescence_date")
            item.IsDeleted = drFCI("_IsDeleted")

            item.id = drAS("id")
            item.code_application_status = drAS("code_application_status")
            item.redundancy = drAS("redundancy")
            item.code_sla = drAS("code_sla")
            item.fault_effects = drAS("fault_effects")
            item.attention = drAS("attention")
            item.IsDeleted = drAS("_IsDeleted")

            Return item
        End Function


        ' New SQLJoinTableBuilder(TableName, BaseTable)
        ' AddTable(Table1,Col1,Table2,Col2)
        ' AddCols(Col1, Col2, Col3...)
        ' AddExp(Name, Expression)
        Public Function FindList(ByVal filter As String, ByVal sort As String) As IList(Of ApplicationSolution)
            Dim lists As IList(Of ApplicationSolution) = New Generic.List(Of ApplicationSolution)()

            Dim jb As New SQLJoinTableBuilder(QT_ApplicationSolution, TABLE_FunctionalCI)
            jb.ConnectionName = CONNECTION_NAME
            jb.AddTable(TABLE_FunctionalCI, "_Identify", TABLE_ApplicationSolution, "id")
            jb.AddCols("name", "description", "code_risk_rating", "move2production", "finalclass", "obsolescence_date")
            jb.AddCols("id", "code_application_status", "redundancy", "code_sla", "fault_effects", "attention")
            jb.Build()
            'Output.Show(jb.BuildSql()) ' 测试打印出生成的SQL语句

            Try
                Dim drs As List(Of DataRow)
                Dim item As ApplicationSolution
                If sort IsNot Nothing Then
                    drs = DataTables(QT_ApplicationSolution).Select(filter, sort)
                Else
                    drs = DataTables(QT_ApplicationSolution).Select(filter)
                End If
                For Each dr As DataRow In drs
                    item = New ApplicationSolution

                    item.Identify = dr("_Identify")
                    item.name = dr("name")
                    item.description = dr("description")
                    item.code_risk_rating = dr("code_risk_rating")
                    item.move2production = dr("move2production")
                    item.finalclass = dr("finalclass")
                    item.obsolescence_date = dr("obsolescence_date")
                    item.IsDeleted = dr("_IsDeleted")

                    item.id = dr("id")
                    item.code_application_status = dr("code_application_status")
                    item.redundancy = dr("redundancy")
                    item.code_sla = dr("code_sla")
                    item.fault_effects = dr("fault_effects")
                    item.attention = dr("attention")
                    item.IsDeleted = dr("_IsDeleted")

                    lists.Add(item)
                Next
            Catch ex As Exception
                Output.Show(QT_ApplicationSolution & "->FindList:" & ex.Message)
            End Try

            Return lists
        End Function

        Public Function FindObject(ByVal id As Integer) As ApplicationSolution
            Dim item As New ApplicationSolution()
            Try
                Dim drAS As DataRow = DataTables(TABLE_ApplicationSolution).Find("id = " & id)
                Dim drFCI As DataRow = DataTables(TABLE_FunctionalCI).Find("_Identify = " & id)

                If drAS IsNot Nothing And drFCI IsNot Nothing Then
                    item = SetProperties(drFCI, drAS)
                End If

            Catch ex As Exception
                Output.Show(TABLE_ApplicationSolution & "->FindObject:" & ex.Message)
            End Try

            Return item
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean
            Dim result As Boolean = False
            Try
                Dim drAS As DataRow = DataTables(TABLE_ApplicationSolution).Find("id = " & id)
                drAS("_IsDeleted") = True
                drAS.Save()

                Dim drFCI As DataRow = DataTables(TABLE_FunctionalCI).Find("_Identify = " & id)
                drFCI("_IsDeleted") = True
                drFCI.Save()

                result = True
            Catch ex As Exception
                Output.Show(TABLE_ApplicationSolution & "->Delete:" & ex.Message)
                Output.Show(TABLE_FunctionalCI & "->Delete:" & ex.Message)
            End Try

            Output.Show("Delete is invoked successful!")

            Return result
        End Function

        Public Function Insert(ByVal obj As ApplicationSolution) As Boolean
            Dim result As Boolean = False

            Try
                Dim drFCI As DataRow = DataTables(TABLE_FunctionalCI).AddNew()

                drFCI("name") = obj.name
                drFCI("description") = obj.description
                drFCI("code_risk_rating") = obj.code_risk_rating
                drFCI("move2production") = obj.move2production
                drFCI("finalclass") = TABLE_ApplicationSolution
                drFCI("obsolescence_date") = obj.obsolescence_date
                If obj.IsDeleted = True Or obj.IsDeleted = False Then
                    drFCI("_IsDeleted") = obj.IsDeleted
                Else
                    drFCI("_IsDeleted") = False
                End If

                drFCI.Save()


                Dim drAS As DataRow = DataTables(TABLE_ApplicationSolution).AddNew()

                drAS("id") = drFCI("_Identify")
                drAS("code_application_status") = obj.code_application_status
                drAS("redundancy") = obj.redundancy
                drAS("code_sla") = obj.code_sla
                drAS("fault_effects") = obj.fault_effects
                drAS("attention") = obj.attention
                If obj.IsDeleted = True Or obj.IsDeleted = False Then
                    drAS("_IsDeleted") = obj.IsDeleted
                Else
                    drAS("_IsDeleted") = False
                End If

                drAS.Save()

                result = True
            Catch ex As Exception
                Output.Show(TABLE_ApplicationSolution & "->Insert:" & ex.Message)
            End Try

            Output.Show("Insert is invoked successful!")

            Return result
        End Function


    End Class

End Namespace

