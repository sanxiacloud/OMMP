Imports ommp.dto
Imports Foxtable

Namespace dao

    ' 已全部测试完成
    '20190611 by Andy
    Public Class ApplicationSolutionDAO
        Inherits FunctionalCIDAO
        Implements IEntityDAO

        Private ReadOnly Property _TABLE_NAME() As String
            Get
                Return ApplicationSolution.TABLE_NAME
            End Get
        End Property

        Private ReadOnly Property QUERY_TABLE_NAME() As String
            Get
                Return ApplicationSolutionQT.TABLE_NAME
            End Get
        End Property

        Public Sub New()
            Dim builder As New SQLJoinTableBuilder(QUERY_TABLE_NAME, FunctionalCI.TABLE_NAME)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(FunctionalCI.TABLE_NAME, C__IDENTIFY, _TABLE_NAME, C_ID)
            builder.AddCols(C__IDENTIFY, FunctionalCI.C_NAME, FunctionalCI.C_DESCRIPTION, FunctionalCI.C_CODE_RISK_RATING, FunctionalCI.C_MOVE2PRODUCTION, FunctionalCI.C_FINALCLASS, FunctionalCI.C_OBSOLESCENCE_DATE)
            builder.AddCols(_TABLE_NAME & "." & C__ISDELETED, ApplicationSolution.C_ID, ApplicationSolution.C_CODE_APPLICATION_STATUS, ApplicationSolution.C_REDUNDANCY, ApplicationSolution.C_CODE_SLA, ApplicationSolution.C_FAULT_EFFECTS, ApplicationSolution.C_ATTENTION)
            builder.Build()
            'Output.Show(builder.BuildSql())
        End Sub

        ' 查询一个应用方案
        Private Sub TestFindObject()
            Dim dao As ommp.dao.ApplicationSolutionDAO = New ommp.dao.ApplicationSolutionDAO()
            Dim result As Boolean = False
            Dim dto As ommp.dto.ApplicationSolutionQT = dao.FindObject(Of ommp.dto.ApplicationSolutionQT)(1886)

            Output.Show("Identify = " & dto._Identify)
            Output.Show("name = " & dto.name)
            Output.Show("code_risk_rating = " & dto.code_risk_rating)
            Output.Show("move2production = " & dto.move2production)
            Output.Show("obsolescence_date = " & dto.obsolescence_date)
            Output.Show("description = " & dto.description)
            Output.Show("finalclass = " & dto.finalclass)
            Output.Show("_IsDeleted = " & dto._IsDeleted)

            Output.Show("id = " & dto.id)
            Output.Show("code_application_status = " & dto.code_application_status)
            Output.Show("attention = " & dto.attention)
            Output.Show("code_sla = " & dto.code_sla)
            Output.Show("fault_effects = " & dto.fault_effects)
            Output.Show("redundancy = " & dto.redundancy)
        End Sub

        Private Sub TestInsert()
            ' 添加一个应用方案
            Dim dao As New ommp.dao.ApplicationSolutionDAO()
            Dim result As Boolean = False
            Dim dto As New ommp.dto.ApplicationSolution()
            dto.name = "测试应用系统1-20190613-1"
            dto.code_application_status = 2
            dto.redundancy = 3
            dto.code_sla = 1
            dto.fault_effects = 0
            dto.attention = "测试注意事项内容"
            dto._IsDeleted = False
            result = dao.Insert(dto)
            Output.Show(result)
        End Sub

        Private Sub TestUpdate()
            Dim dao As New ommp.dao.ApplicationSolutionDAO()
            Dim result As Boolean = False
            Dim dto As ommp.dto.ApplicationSolutionQT = dao.FindObject(Of ommp.dto.ApplicationSolutionQT)(1886)
            dto.name = "测试组织 20190614 修改 2"
            dto.move2production = DateTime.Now
            Output.Show(dao.Update(dto))
        End Sub

        Private Sub TestDelete()
            Dim dao As New ommp.dao.ApplicationSolutionDAO()
            Output.Show(dao.Delete(1886))
        End Sub

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As ApplicationSolution = CType(o, ApplicationSolution)
            obj.id = InsertFunctionalCI(o, obj.GetType().Name)
            Return InsertObject(Of ommp.dto.ApplicationSolution)(CType(o, ApplicationSolution))
        End Function
        
        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Dim obj As ApplicationSolution = CType(o, ApplicationSolution)
            Return UpdateFunctionalCI(o) And UpdateObject(Of ApplicationSolution)(CType(o, ApplicationSolution))
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteFunctionalCI(id) And DeleteObject(Of ApplicationSolution)(id)
        End Function
         
    End Class

End Namespace

