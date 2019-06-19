Imports ommp.dal.dto
Imports Foxtable
Namespace dal.dao

    Public Class WebApplicationDAO
        Inherits FunctionalCIDAO
        Implements IEntityDAO

        Protected Overrides Function BuildJoinTable() As Boolean
            Dim qtObject As New WebApplicationQT()
            Dim baseObject As New FunctionalCI()
            Dim finalObject As New WebApplication()

            Dim baseTableName = baseObject.GetType().Name

            Dim builder As New SQLJoinTableBuilder(qtObject.GetType().Name, baseTableName)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(baseTableName, C__IDENTIFY, finalObject.GetType().Name, C_ID)
            AddQueryTableCols(Of WebApplication)(builder)
            builder.Build()
        End Function

        Public Sub New()
            BuildJoinTable()
        End Sub

        Public Function Insert(ByVal o As Object) As Integer Implements IEntityDAO.Insert
            Dim obj As WebApplication = CType(o, WebApplication)
            obj.id = InsertFunctionalCI(o, obj.GetType().Name)
            Return InsertObject(Of WebApplication)(CType(o, WebApplication))
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Return UpdateFunctionalCI(o) And UpdateObject(Of WebApplication)(CType(o, WebApplication)) And BuildJoinTable()
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteFunctionalCI(id) And DeleteObject(Of WebApplication)(id)
        End Function

        ' 添加一个 Web应用
        ' 测试时没有 添加外键表数据字段 dto.webserver_identify = Nothing 无法插入行
        Private Sub TestInsert()
            Dim dao As ommp.dal.dao.WebApplicationDAO = New ommp.dal.dao.WebApplicationDAO()
            Dim result As Boolean = False
            Dim dto As New ommp.dal.dto.WebApplication()
            dto.name = "Web应用1-20190611-1"
            dto.description = "description"
            dto.code_risk_rating = 2
            dto.move2production = DateTime.Now
            dto.finalclass = "WebApplication"
            dto.obsolescence_date = Nothing

            dto.webserver_identify = Nothing
            dto.url = "http://www.baidu.com"
            result = dao.Insert(dto)
            Output.Show(result)
        End Sub

        ' 查询 Web应用 列表
        Private Sub TestFindList()
            Dim dao As New ommp.dal.dao.WebApplicationDAO
            Dim result As Boolean = False
            Dim lists As IList(Of ommp.dal.dto.WebApplicationQT) = dao.FindList(Of ommp.dal.dto.WebApplicationQT)("[name] Like '%Zabbix%'", "id DESC")
            Output.Show("Count : " & lists.Count)
            Output.Show(" --------------------- ")
            For Each dto As ommp.dal.dto.WebApplicationQT In lists
                Output.Show("name = " & dto.name)
                Output.Show("code_risk_rating = " & dto.code_risk_rating)
                Output.Show("move2production = " & dto.move2production)
                Output.Show("obsolescence_date = " & dto.obsolescence_date)
                Output.Show("finalclass = " & dto.finalclass)

                Output.Show("id = " & dto.id)
                Output.Show("webserver_identify = " & dto.webserver_identify)
                Output.Show("url = " & dto.url)
                Output.Show(" --------------------- ")
            Next
        End Sub

        ' 用于 查找一个Web应用
        Private Sub TestFindObject()
            Dim dao As ommp.dal.dao.WebApplicationDAO = New ommp.dal.dao.WebApplicationDAO()
            Dim dto As ommp.dal.dto.WebApplicationQT = dao.FindObject(Of ommp.dal.dto.WebApplicationQT)(1873)
            Output.Show("name = " & dto.name)
            Output.Show("code_risk_rating = " & dto.code_risk_rating)
            Output.Show("move2production = " & dto.move2production)
            Output.Show("obsolescence_date = " & dto.obsolescence_date)
            Output.Show("finalclass = " & dto.finalclass)

            Output.Show("id = " & dto.id)
            Output.Show("webserver_identify = " & dto.webserver_identify)
            Output.Show("url = " & dto.url)
        End Sub
    End Class

End Namespace