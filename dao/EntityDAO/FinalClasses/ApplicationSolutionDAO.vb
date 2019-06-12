Imports ommp.dto
Imports Foxtable

Namespace dao

    ' 已全部测试完成
    '20190611 by Andy
    Public Class ApplicationSolutionDAO
        Inherits FunctionalCIDAO
        Implements IEntityDAO

        Private Const QUERY_TABLE_NAME As String = "QTApplicationSolution"

        Public Sub New()
            ' 创建查询表，用于查询方法使用
            Dim builder As New SQLJoinTableBuilder(QUERY_TABLE_NAME, FunctionalCI.TABLE_NAME)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(FunctionalCI.TABLE_NAME, C__IDENTIFY, TABLE_NAME, C_ID)
            builder.AddCols(FunctionalCI.C_NAME, FunctionalCI.C_DESCRIPTION, FunctionalCI.C_CODE_RISK_RATING, FunctionalCI.C_MOVE2PRODUCTION, FunctionalCI.C_FINALCLASS, FunctionalCI.C_OBSOLESCENCE_DATE)
            builder.AddCols(ApplicationSolution.C_ID, ApplicationSolution.C_CODE_APPLICATION_STATUS, ApplicationSolution.C_REDUNDANCY, ApplicationSolution.C_CODE_SLA, ApplicationSolution.C_FAULT_EFFECTS, ApplicationSolution.C_ATTENTION)
            builder.Build()
            'Output.Show(builder.BuildSql()) ' 测试打印出生成的SQL语句
        End Sub

        Protected Overrides ReadOnly Property TABLE_NAME() As String
            Get
                Return ApplicationSolution.TABLE_NAME
            End Get
        End Property

        ' 添加一个应用方案
        'Dim dao As ommp.dao.ApplicationSolutionDAO = New ommp.dao.ApplicationSolutionDAO()
        'Dim result As Boolean = False
        'Dim dto As New ommp.dto.ApplicationSolution()
        'dto.name = "测试应用系统1-20190611"
        'dto.code_application_status= 2
        'dto.redundancy = 3
        'dto.code_sla = 1
        'dto.fault_effects = 0
        'dto.attention = "测试注意事项内容"
        'dto.IsDeleted = False
        'result = dao.Insert(dto)
        'Output.Show(result)
        Public Function Insert(ByVal o As Object) As Boolean Implements IEntityDAO.Insert
            Dim obj As ApplicationSolution = CType(o, ApplicationSolution)
            Dim result As Boolean = False

            Try
                Dim identify As Integer = InsertFunctionalCI(o, TABLE_NAME)

                Dim dr As DataRow = DataTables(TABLE_NAME).AddNew()
                With obj
                    dr(C_ID) = identify
                    dr(C__ISDELETED) = False
                    dr(ApplicationSolution.C_CODE_APPLICATION_STATUS) = .code_application_status
                    dr(ApplicationSolution.C_REDUNDANCY) = .redundancy
                    dr(ApplicationSolution.C_CODE_SLA) = .code_sla
                    dr(ApplicationSolution.C_FAULT_EFFECTS) = .fault_effects
                    dr(ApplicationSolution.C_ATTENTION) = .attention
                End With
                dr.Save()

                result = True
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        '修改应用方案
        'Dim dao As ommp.dao.ApplicationSolutionDAO = New ommp.dao.ApplicationSolutionDAO()
        'Dim result As Boolean = False
        'Dim dto As ommp.dto.ApplicationSolution = dao.FindObject(1873)
        'dto.name = dto.name & "-2"
        'dto.code_risk_rating = 1
        'dto.move2production = DateTime.Now
        'dto.obsolescence_date = Nothing
        'dto.code_application_status = 2
        'dto.redundancy = "2"
        'dto.code_sla = 2
        'dto.fault_effects = 1
        'dto.attention = dto.attention & "-2"
        'result  = dao.Update(dto)
        'Output.Show(result)
        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Dim obj As ApplicationSolution = CType(o, ApplicationSolution)
            Dim result As Boolean = False

            Try
                Dim result1 As Boolean = UpdateFunctionalCI(o)
                Dim result2 As Boolean = False

                Dim dr As DataRow = DataTables(TABLE_NAME).Find(C_ID & " = " & obj.Identify)

                If dr IsNot Nothing Then
                    If obj.code_application_status >= 0 Then
                        dr(ApplicationSolution.C_CODE_APPLICATION_STATUS) = obj.code_application_status
                    End If
                    If obj.redundancy IsNot Nothing Then
                        dr(ApplicationSolution.C_REDUNDANCY) = obj.redundancy
                    End If
                    If obj.code_sla >= 0 Then
                        dr(ApplicationSolution.C_CODE_SLA) = obj.code_sla
                    End If
                    If obj.fault_effects IsNot Nothing Then
                        dr(ApplicationSolution.C_FAULT_EFFECTS) = obj.fault_effects
                    End If
                    If obj.attention IsNot Nothing Then
                        dr(ApplicationSolution.C_ATTENTION) = obj.attention
                    End If

                    dr.Save()
                    result2 = True

                End If

                result = result1 And result2
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Update:" & ex.Message)
            End Try

            Return result
        End Function

        '删除一个应用方案
        'Dim dao As ommp.dao.ApplicationSolutionDAO = New ommp.dao.ApplicationSolutionDAO()
        'Dim result As Boolean = False
        'result = dao.Delete(591)
        'Output.Show(result)
        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete

            Return DeleteFunctionalCI(id) And DeleteObject(TABLE_NAME, id)

        End Function


        Protected Overrides Function SetProperties(ByVal dr As DataRow) As Object
            Dim item As New ApplicationSolution()

            With item
                .Identify = dr(ApplicationSolution.C_ID)
                .name = dr(FunctionalCI.C_NAME)
                .description = dr(FunctionalCI.C_DESCRIPTION)
                .code_risk_rating = dr(FunctionalCI.C_CODE_RISK_RATING)
                .move2production = dr(FunctionalCI.C_MOVE2PRODUCTION)
                .finalclass = dr(FunctionalCI.C_FINALCLASS)
                .obsolescence_date = dr(FunctionalCI.C_OBSOLESCENCE_DATE)

                .id = dr(ApplicationSolution.C_ID)
                .code_application_status = dr(ApplicationSolution.C_CODE_APPLICATION_STATUS)
                .redundancy = dr(ApplicationSolution.C_REDUNDANCY)
                .code_sla = dr(ApplicationSolution.C_CODE_SLA)
                .fault_effects = dr(ApplicationSolution.C_FAULT_EFFECTS)
                .attention = dr(ApplicationSolution.C_ATTENTION)
            End With

            Return item
        End Function

        ' 查询应用方案列表
        'Dim dao As New ommp.dao.ApplicationSolutionDAO
        'Dim lists As IList(Of Object) = dao.FindList("[name] Like '%Zabbix%'", "id DESC")
        'output.Show("Count : " & lists.Count )
        'Output.Show(" --------------------- ") 
        'For Each dto As ommp.dto.ApplicationSolution In lists 
        '    Output.Show("name = " & dto.name)
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
        Public Function FindList(ByVal filter As String, ByVal sort As String) As IList(Of Object) Implements IQueryDAO.FindList
            Return FindRows(QUERY_TABLE_NAME, filter, sort)
        End Function

        ' 用于 查找一个应用方案
        'Dim dao As ommp.dao.ApplicationSolutionDAO = New ommp.dao.ApplicationSolutionDAO()
        'Dim dto As ommp.dto.ApplicationSolution = dao.FindObject(1873)
        'Output.Show("name = " & dto.name)
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
        Public Function FindObject(ByVal id As Integer) As Object Implements IQueryDAO.FindObject
            Return FindRow(QUERY_TABLE_NAME, id)
        End Function
    End Class

End Namespace

