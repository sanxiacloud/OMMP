Imports System.Reflection
Imports ommp.dal.dto
Imports Foxtable

Namespace dal.dao
    Public Class ApplicationSolutionDAO
        Inherits FunctionalCIDAO(Of ApplicationSolutionQT)
        Implements IEntityDAO(Of ApplicationSolution)

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New ApplicationSolutionQT()
            Dim baseObject As New FunctionalCI()
            Dim finalObject As New ApplicationSolution()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of ApplicationSolution)(builder)
            builder.Build()
            'Output.Show(builder.BuildSql())
            Return True
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(o As ApplicationSolution) As Integer Implements IEntityDAO(Of ApplicationSolution).Insert
            o.id = InsertFunctionalCI(o, GetType(ApplicationSolution).Name)
            Return InsertObject(o) And BuildJoinTable()
        End Function

        Public Function Update(o As ApplicationSolution) As Boolean Implements IEntityDAO(Of ApplicationSolution).Update
            Return UpdateFunctionalCI(o) And UpdateObject(o) And BuildJoinTable()
        End Function

        Public Function Delete(id As Integer) As Boolean Implements IEntityDAO(Of ApplicationSolution).Delete
            Return DeleteFunctionalCI(id) And DeleteObject(Of ApplicationSolution)(id) And BuildJoinTable()
        End Function

        ' 查询一个应用方案
        Private Sub TestFindObject()
            Dim dao As New ommp.dal.dao.ApplicationSolutionDAO()
            Dim result As Boolean = False
            Dim dto As ommp.dal.dto.ApplicationSolutionQT = dao.FindObject(Of ommp.dal.dto.ApplicationSolutionQT)(1897)
            If dto IsNot Nothing Then
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
            End If
        End Sub

        Private Sub TestInsert()
            ' 添加一个应用方案
            Dim dao As New ommp.dal.dao.ApplicationSolutionDAO()
            Dim result As Boolean = False
            Dim dto As New ommp.dal.dto.ApplicationSolution()
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
            Dim dao As New ommp.dal.dao.ApplicationSolutionDAO()
            Dim dto As ommp.dal.dto.ApplicationSolutionQT = dao.FindObject(Of ommp.dal.dto.ApplicationSolutionQT)(1897)
            Output.Show(dto.name)
            dto.name = "测试组织 20190619 修改 1"
            dto.move2production = DateTime.Now
            dto.redundancy = "hahahaha..."
            Output.Show(dao.Update(dto))
            dto = dao.FindObject(Of ommp.dal.dto.ApplicationSolutionQT)(1897)
            Output.Show(dto.name)
        End Sub

        Private Sub TestDelete()
            Dim dao As New ommp.dal.dao.ApplicationSolutionDAO()
            Output.Show(dao.Delete(1886))
        End Sub

    End Class

End Namespace

