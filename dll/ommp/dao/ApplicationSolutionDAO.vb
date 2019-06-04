Imports ommp.dto
Imports Foxtable

Namespace dao
    Public Class ApplicationSolutionDAO : Inherits BaseDAO

        Private Const QT_ApplicationSolution As String = "QTApplicationSolution"

        Public Sub New()
            ' 创建查询表，用于查询方法使用
            Dim builder As New SQLJoinTableBuilder(QT_ApplicationSolution, FunctionalCI.TABLE_NAME)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(FunctionalCI.TABLE_NAME, FunctionalCI.C__IDENTIFY, ApplicationSolution.TABLE_NAME, ApplicationSolution.C_ID)
            builder.AddCols(FunctionalCI.C_NAME, FunctionalCI.C_DESCRIPTION, FunctionalCI.C_CODE_RISK_RATING, FunctionalCI.C_MOVE2PRODUCTION, FunctionalCI.C_FINALCLASS, FunctionalCI.C_OBSOLESCENCE_DATE)
            builder.AddCols(ApplicationSolution.C_ID, ApplicationSolution.C_CODE_APPLICATION_STATUS, ApplicationSolution.C_REDUNDANCY, ApplicationSolution.C_CODE_SLA, ApplicationSolution.C_FAULT_EFFECTS, ApplicationSolution.C_ATTENTION)
            builder.Build()
            'Output.Show(builder.BuildSql()) ' 测试打印出生成的SQL语句
        End Sub

        ' 添加一个应用方案
        'Dim dao As ommp.dao.ApplicationSolutionDAO = New ommp.dao.ApplicationSolutionDAO()
        'Dim result As Boolean = False
        'Dim dto As New ommp.dto.ApplicationSolution()
        'dto.name = "测试应用系统1-20190603"
        'dto.code_application_status= 2
        'dto.redundancy = 3
        'dto.code_sla = 1
        'dto.fault_effects = 0
        'dto.attention = "测试注意事项内容"
        'dto.IsDeleted = False
        'result = dao.Insert(dto)
        'Output.Show(result)
        Public Function Insert(ByVal obj As ApplicationSolution) As Boolean
            Dim result As Boolean = False

            Try
                Dim drFCI As DataRow = DataTables(FunctionalCI.TABLE_NAME).AddNew()

                drFCI(FunctionalCI.C_NAME) = obj.name
                drFCI(FunctionalCI.C_DESCRIPTION) = obj.description
                drFCI(FunctionalCI.C_CODE_RISK_RATING) = obj.code_risk_rating
                drFCI(FunctionalCI.C_MOVE2PRODUCTION) = obj.move2production
                drFCI(FunctionalCI.C_FINALCLASS) = ApplicationSolution.TABLE_NAME
                drFCI(FunctionalCI.C_OBSOLESCENCE_DATE) = obj.obsolescence_date
                If obj.IsDeleted = True Or obj.IsDeleted = False Then
                    drFCI(FunctionalCI.C__ISDELETED) = obj.IsDeleted
                Else
                    drFCI(FunctionalCI.C__ISDELETED) = False
                End If

                drFCI.Save()


                Dim drAS As DataRow = DataTables(ApplicationSolution.TABLE_NAME).AddNew()

                drAS(ApplicationSolution.C_ID) = drFCI(FunctionalCI.C__IDENTIFY)
                drAS(ApplicationSolution.C_CODE_APPLICATION_STATUS) = obj.code_application_status
                drAS(ApplicationSolution.C_REDUNDANCY) = obj.redundancy
                drAS(ApplicationSolution.C_CODE_SLA) = obj.code_sla
                drAS(ApplicationSolution.C_FAULT_EFFECTS) = obj.fault_effects
                drAS(ApplicationSolution.C_ATTENTION) = obj.attention
                If obj.IsDeleted = True Or obj.IsDeleted = False Then
                    drAS(ApplicationSolution.C__ISDELETED) = obj.IsDeleted
                Else
                    drAS(ApplicationSolution.C__ISDELETED) = False
                End If

                drAS.Save()

                result = True
            Catch ex As Exception
                Output.Show(ApplicationSolution.TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        '删除一个应用方案
        'Dim dao As ommp.dao.ApplicationSolutionDAO = New ommp.dao.ApplicationSolutionDAO()
        'Dim result As Boolean = False
        'result = dao.Delete(591)
        'Output.Show(result)
        Public Function Delete(ByVal id As Integer) As Boolean
            Dim result As Boolean = False
            Try
                Dim drAS As DataRow = DataTables(ApplicationSolution.TABLE_NAME).Find(ApplicationSolution.C_ID & " = " & id)
                drAS(ApplicationSolution.C__ISDELETED) = True
                drAS.Save()

                Dim drFCI As DataRow = DataTables(FunctionalCI.TABLE_NAME).Find(FunctionalCI.C__IDENTIFY & " = " & id)
                drFCI(FunctionalCI.C__ISDELETED) = True
                drFCI.Save()

                result = True
            Catch ex As Exception
                Output.Show(ApplicationSolution.TABLE_NAME & ":" & FunctionalCI.TABLE_NAME & "->Delete:" & ex.Message)
            End Try

            Return result
        End Function

        ' 查找一个应用方案
        'Dim dao As ommp.dao.ApplicationSolutionDAO = New ommp.dao.ApplicationSolutionDAO()
        'Dim dto As ommp.dto.ApplicationSolution = dao.FindObject(331)
        'Output.Show("name = " & dto.name) ' 短信平台
        'Output.Show("code_risk_rating = " & dto.code_risk_rating) 
        'Output.Show("move2production = " & dto.move2production) 
        'Output.Show("obsolescence_date = " & dto.obsolescence_date) 
        'Output.Show("finalclass = " & dto.finalclass) 

        'Output.Show("code_application_status = " & dto.code_application_status) 
        'Output.Show("redundancy = " & dto.redundancy) 
        'Output.Show("code_sla = " & dto.code_sla) 
        'Output.Show("fault_effects = " & dto.fault_effects) 
        'Output.Show("attention = " & dto.attention) 
        'Output.Show("_IsDeleted = " & dto.IsDeleted) 
        Public Function FindObject(ByVal id As Integer) As ApplicationSolution
            Dim item As New ApplicationSolution()
            Try
                Dim dr As DataRow = DataTables(QT_ApplicationSolution).Find(ApplicationSolution.C_ID & " = " & id)

                If dr IsNot Nothing Then
                    item = New ApplicationSolution()

                    item.Identify = dr(ApplicationSolution.C_ID)
                    item.name = dr(FunctionalCI.C_NAME)
                    item.description = dr(FunctionalCI.C_DESCRIPTION)
                    item.code_risk_rating = dr(FunctionalCI.C_CODE_RISK_RATING)
                    item.move2production = dr(FunctionalCI.C_MOVE2PRODUCTION)
                    item.finalclass = dr(FunctionalCI.C_FINALCLASS)
                    item.obsolescence_date = dr(FunctionalCI.C_OBSOLESCENCE_DATE)

                    item.id = dr(ApplicationSolution.C_ID)
                    item.code_application_status = dr(ApplicationSolution.C_CODE_APPLICATION_STATUS)
                    item.redundancy = dr(ApplicationSolution.C_REDUNDANCY)
                    item.code_sla = dr(ApplicationSolution.C_CODE_SLA)
                    item.fault_effects = dr(ApplicationSolution.C_FAULT_EFFECTS)
                    item.attention = dr(ApplicationSolution.C_ATTENTION)
                End If

            Catch ex As Exception
                Output.Show(ApplicationSolution.TABLE_NAME & "->FindObject:" & ex.Message)
            End Try

            Return item
        End Function

        ' 查询应用方案列表
        'Dim dao As New ommp.dao.ApplicationSolutionDAO
        'Dim lists As IList(Of ommp.dto.ApplicationSolution) = dao.FindList("[name] Like '%Zabbix%'", "id DESC")
        'output.Show("Count : " & lists.Count )
        'Output.Show(" --------------------- ") 
        'For Each dto As ommp.dto.ApplicationSolution In lists 
        '    Output.Show("name = " & dto.name) ' 短信平台
        '    Output.Show("code_risk_rating = " & dto.code_risk_rating) 
        '    Output.Show("move2production = " & dto.move2production) 
        '    Output.Show("obsolescence_date = " & dto.obsolescence_date) 
        '    Output.Show("finalclass = " & dto.finalclass) 

        '    Output.Show("code_application_status = " & dto.code_application_status) 
        '    Output.Show("redundancy = " & dto.redundancy) 
        '    Output.Show("code_sla = " & dto.code_sla) 
        '    Output.Show("fault_effects = " & dto.fault_effects) 
        '    Output.Show("attention = " & dto.attention) 
        '    Output.Show("_IsDeleted = " & dto.IsDeleted) 
        '    Output.Show(" --------------------- ") 
        'Next
        Public Function FindList(ByVal filter As String, ByVal sort As String) As IList(Of ApplicationSolution)
            Dim lists As IList(Of ApplicationSolution) = New Generic.List(Of ApplicationSolution)()

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

                    item.Identify = dr(ApplicationSolution.C_ID)
                    item.name = dr(FunctionalCI.C_NAME)
                    item.description = dr(FunctionalCI.C_DESCRIPTION)
                    item.code_risk_rating = dr(FunctionalCI.C_CODE_RISK_RATING)
                    item.move2production = dr(FunctionalCI.C_MOVE2PRODUCTION)
                    item.finalclass = dr(FunctionalCI.C_FINALCLASS)
                    item.obsolescence_date = dr(FunctionalCI.C_OBSOLESCENCE_DATE)

                    item.id = dr(ApplicationSolution.C_ID)
                    item.code_application_status = dr(ApplicationSolution.C_CODE_APPLICATION_STATUS)
                    item.redundancy = dr(ApplicationSolution.C_REDUNDANCY)
                    item.code_sla = dr(ApplicationSolution.C_CODE_SLA)
                    item.fault_effects = dr(ApplicationSolution.C_FAULT_EFFECTS)
                    item.attention = dr(ApplicationSolution.C_ATTENTION)

                    lists.Add(item)
                Next
            Catch ex As Exception
                Output.Show(QT_ApplicationSolution & "->FindList:" & ex.Message)
            End Try

            Return lists
        End Function

    End Class

End Namespace

