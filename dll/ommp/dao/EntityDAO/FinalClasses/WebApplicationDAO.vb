Imports ommp.dto
Imports Foxtable
Namespace dao

    Public Class WebApplicationDAO
        Inherits FunctionalCIDAO
        Implements IEntityDAO

        Private Const QUERY_TABLE_NAME As String = "QTWebApplication"

        Public Sub New()
            Dim builder As New SQLJoinTableBuilder(QUERY_TABLE_NAME, FunctionalCI.TABLE_NAME)
            builder.ConnectionName = CONNECTION_NAME
            builder.AddTable(FunctionalCI.TABLE_NAME, C__IDENTIFY, TABLE_NAME, C_ID)
            builder.AddCols(FunctionalCI.C_NAME, FunctionalCI.C_DESCRIPTION, FunctionalCI.C_CODE_RISK_RATING, FunctionalCI.C_MOVE2PRODUCTION, FunctionalCI.C_FINALCLASS, FunctionalCI.C_OBSOLESCENCE_DATE)
            builder.AddCols(C_ID, WebApplication.C_URL, WebApplication.C_WEBSERVER_IDENTIFY)
            builder.Build()
        End Sub

        Protected Overrides ReadOnly Property TABLE_NAME() As String
            Get
                Return WebApplication.TABLE_NAME
            End Get
        End Property

        Protected Overrides Function SetProperties(ByVal dr As DataRow) As Object
            Dim item As New WebApplication()

            With item
                .Identify = dr(C_ID)
                .name = dr(FunctionalCI.C_NAME)
                .description = dr(FunctionalCI.C_DESCRIPTION)
                .code_risk_rating = dr(FunctionalCI.C_CODE_RISK_RATING)
                .move2production = dr(FunctionalCI.C_MOVE2PRODUCTION)
                .finalclass = dr(FunctionalCI.C_FINALCLASS)
                .obsolescence_date = dr(FunctionalCI.C_OBSOLESCENCE_DATE)

                .id = dr(C_ID)
                .webserver_identify = dr(WebApplication.C_WEBSERVER_IDENTIFY)
                .url = dr(WebApplication.C_URL)
            End With

            Return item
        End Function

        Public Function Delete(ByVal id As Integer) As Boolean Implements IEntityDAO.Delete
            Return DeleteFunctionalCI(id) And DeleteObject(TABLE_NAME, id)
        End Function

        ' 添加一个 Web应用
        ' 测试时没有 添加外键表数据字段 dto.webserver_identify = Nothing 无法插入行
        'Dim dao As ommp.dao.WebApplicationDAO = New ommp.dao.WebApplicationDAO()
        'Dim result As Boolean = False
        'Dim dto As New ommp.dto.WebApplication()
        'dto.name = "Web应用1-20190611-1"
        'dto.description = "description"
        'dto.code_risk_rating = 2
        'dto.move2production = DateTime.Now
        'dto.finalclass = "WebApplication"
        'dto.obsolescence_date = Nothing

        'dto.webserver_identify = Nothing
        'dto.url = "http://www.baidu.com"
        'dto.IsDeleted = False
        'result = dao.Insert(dto)
        'Output.Show(result)
        Public Function Insert(ByVal o As Object) As Boolean Implements IEntityDAO.Insert
            Dim obj As WebApplication = CType(o, WebApplication)
            Dim result As Boolean = False

            Try
                Dim identify As Integer = InsertFunctionalCI(o, TABLE_NAME)

                Dim dr As DataRow = DataTables(TABLE_NAME).AddNew()

                dr(C_ID) = identify
                dr(C__ISDELETED) = False
                dr(WebApplication.C_WEBSERVER_IDENTIFY) = obj.webserver_identify
                dr(WebApplication.C_URL) = obj.url

                dr.Save()

                result = True
            Catch ex As Exception
                Output.Show(TABLE_NAME & "->Insert:" & ex.Message)
            End Try

            Return result
        End Function

        Public Function Update(ByVal o As Object) As Boolean Implements IEntityDAO.Update
            Dim obj As WebApplication = CType(o, WebApplication)
            Dim result As Boolean = False

            Try
                Dim result1 As Boolean = UpdateFunctionalCI(o)
                Dim result2 As Boolean = False

                Dim dr As DataRow = DataTables(TABLE_NAME).Find(C_ID & " = " & obj.Identify)

                If dr IsNot Nothing Then
                    If obj.webserver_identify >= 0 Then
                        dr(WebApplication.C_WEBSERVER_IDENTIFY) = obj.webserver_identify
                    End If
                    If obj.url >= 0 Then
                        dr(WebApplication.C_URL) = obj.url
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

        ' 查询 Web应用 列表
        'Dim dao As New ommp.dao.WebApplicationDAO
        'Dim lists As IList(Of Object) = dao.FindList("[name] Like '%Zabbix%'", "id DESC")
        'output.Show("Count : " & lists.Count )
        'Output.Show(" --------------------- ") 
        'For Each dto As ommp.dto.WebApplication In lists 
        '    Output.Show("name = " & dto.name)
        '    Output.Show("code_risk_rating = " & dto.code_risk_rating) 
        '    Output.Show("move2production = " & dto.move2production) 
        '    Output.Show("obsolescence_date = " & dto.obsolescence_date) 
        '    Output.Show("finalclass = " & dto.finalclass) 

        '    Output.Show("id = " & dto.id) 
        '    Output.Show("webserver_identify = " & dto.webserver_identify) 
        '    Output.Show("url = " & dto.url)
        '    Output.Show(" --------------------- ") 
        'Next
        Public Function FindList(ByVal filter As String, ByVal sort As String) As System.Collections.Generic.IList(Of Object) Implements IQueryDAO.FindList
            Return FindRows(QUERY_TABLE_NAME, filter, sort)
        End Function

        ' 用于 查找一个Web应用
        'Dim dao As ommp.dao.WebApplicationDAO = New ommp.dao.WebApplicationDAO()
        'Dim dto As ommp.dto.WebApplication = dao.FindObject(1873)
        'Output.Show("name = " & dto.name)
        'Output.Show("code_risk_rating = " & dto.code_risk_rating) 
        'Output.Show("move2production = " & dto.move2production) 
        'Output.Show("obsolescence_date = " & dto.obsolescence_date) 
        'Output.Show("finalclass = " & dto.finalclass) 

        'Output.Show("id = " & dto.id) 
        'Output.Show("webserver_identify = " & dto.webserver_identify) 
        'Output.Show("url = " & dto.url)
        Public Function FindObject(ByVal id As Integer) As Object Implements IQueryDAO.FindObject
            Return FindRow(QUERY_TABLE_NAME, id)
        End Function
    End Class

End Namespace