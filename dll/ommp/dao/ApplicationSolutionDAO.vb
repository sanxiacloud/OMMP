Imports ommp.dto
Imports Foxtable

Namespace dao
    Public Class ApplicationSolutionDAO

        Private Const TABLE_FunctionalCI As String = "FunctionalCI"
        Private Const TABLE_ApplicationSolution As String = "ApplicationSolution"

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
            item.code_sla = drAS("code_sla")
            item.attention = drAS("attention")
            item.IsDeleted = drAS("_IsDeleted")

            Return item
        End Function

        'Relations 表示关联集合，可以获得指定名称的关联
        'Add(RelationName, ParentCol, ChildCol,Visible, RelationPath) 
        'RelationName:    关联名称
        'ParentCol:       父表关联列
        'ChildCol:        子表关联列
        'Visible:         可选参数,是否显示关联表  
        'RelationPath:    RelationPathEnum型枚举，用于设置关联表生成模式，有三个可选值，分别是:One(单向生成),Both(双向生成),None(不生成)
        Public Function FindList(ByVal filter As String, ByVal sort As String) As IList(Of ApplicationSolution)
            Dim lists As IList(Of ApplicationSolution) = New Generic.List(Of ApplicationSolution)()
            Relations.Add("rASofFCI", DataTables(TABLE_FunctionalCI).DataCols("_Identify"), DataTables(TABLE_ApplicationSolution).DataCols("id"), True, RelationPathEnum.One)
            Dim re As Relation = Relations("rASofFCI")

            Try
                Dim drs As List(Of DataRow)
                If sort IsNot Nothing Then
                    drs = DataTables(TABLE_NAME).Select(filter, sort)
                Else
                    drs = DataTables(TABLE_NAME).Select(filter)
                End If
                For Each dr As DataRow In drs
                    lists.Add(SetProperties(dr))
                Next
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->FindList:" & ex.Message)
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

